/*
County Fee Collections, a .NET application for managing fee payments
Copyright (C) 2015  Pottawattamie County, Iowa

This program is free software; you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation; either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License along
with this program; if not, write to the Free Software Foundation, Inc.,
51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Office.Interop.Word;
using System.IO;



namespace county.feecollections
{
    public partial class frmMailMerge : Form
    {
        private object _objMissing = System.Reflection.Missing.Value;
        private object _objTrue = true;
        private object _objFalse = false;
        private Microsoft.Office.Interop.Word.Application _wrdApp;

        private delegate void UpdateActiveDocumentDelegate( string message );

        public void UpdateActiveDocument( string docName )
        {

            if( lblCurrentlySelectedValue.InvokeRequired )
            {
                lblCurrentlySelectedValue.BeginInvoke( new UpdateActiveDocumentDelegate( this.UpdateActiveDocument ), new object[] { docName } );
            }
            else
            {
                this.lblCurrentlySelectedValue.Text = docName;
            }
        } 

        public frmMailMerge()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

            if( !MailMerge.StoreDirectoryConfigured() && !MailMerge.StoreDirectoryExists() )
            {
                MyMessageBox.Show( this, "MS Word Mail Merge", MyDisplayMessage.MailMergeDirectoryError );
                this.Close();
                return;
            }

            this.SuspendLayout();
            this.trvDefendant.SuspendLayout();

            MailMerge.CreateMergeFieldsTreeView( ref this.trvDefendant );    
            trvDefendant.ExpandAll();
            UpdateGUIState();

            this.trvDefendant.ResumeLayout();
            this.ResumeLayout();
        }

        private void trvDefendant_DoubleClick( object sender, System.EventArgs e )
        {
            btnInsertField_Click( null, null );
        } 

        private void btnInsertField_Click( object sender, EventArgs e )
        {
            if( trvDefendant.SelectedNode != null && _wrdApp != null && _wrdApp.Documents.Count > 0 )
            {
                _wrdApp.ActiveDocument.MailMerge.Fields.Add( _wrdApp.Selection.Range, trvDefendant.SelectedNode.Text.Trim().Replace( " ", "_" ) );
                _wrdApp.Activate();
            }
        } 

        private void btnOpenDoc_Click( object sender, EventArgs e )
        {
            cmsDocumentOpen.Show( btnOpenDoc, 0, 0 );
        } 

        private void cmsDocumentOpen_ItemClicked( object sender, ToolStripItemClickedEventArgs e )
        {
            // start word 
            if( _wrdApp == null )
            {
                _wrdApp = new Microsoft.Office.Interop.Word.Application();
                _wrdApp.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler( _wrdApp_DocumentBeforeSave );
                _wrdApp.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler( _wrdApp_DocumentBeforeClose );
                _wrdApp.WindowActivate += new ApplicationEvents4_WindowActivateEventHandler( _wrdApp_WindowActivate );
                ((Microsoft.Office.Interop.Word.ApplicationEvents4_Event)_wrdApp).Quit += new ApplicationEvents4_QuitEventHandler( _wrdApp_Quit );
            }

            // opening word document based on user selection
            Document wrdDoc = new Document();

            /********************************************************************************
            *   New Document
            ********************************************************************************/
            if( e.ClickedItem.Equals( cmsDocumentOpenNew ) )
            {
                wrdDoc = _wrdApp.Documents.Add( ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );
            }
            /********************************************************************************
            *  Existing Document
            ********************************************************************************/
            else if( e.ClickedItem.Equals( cmsDocumentOpenExisting ) )
            {
                if( DialogResult.Cancel == openFileDialog.ShowDialog() )
                {
                    return;
                }

                object fileName = openFileDialog.FileName;

                wrdDoc = _wrdApp.Documents.Open( ref fileName, ref _objMissing, ref _objFalse, ref _objMissing, 
                        ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, 
                        ref _objMissing, ref _objTrue, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );
            }
            /********************************************************************************
            *   Stored Document
            ********************************************************************************/
            else if( e.ClickedItem.Equals( cmsDocumentOpenStored ) )
            {
                if( !MailMerge.StoreDirectoryConfigured() && !MailMerge.StoreDirectoryExists() )
                {
                    MyMessageBox.Show( this, "MS Word Mail Merge", MyDisplayMessage.MailMergeDirectoryError );
                    return;
                }

                frmMailMergeTemplates frm = new frmMailMergeTemplates();
                if( DialogResult.Cancel == frm.ShowDialog( this ) || string.IsNullOrEmpty( frm.SelectedMailMergeTemplatePath ) )
                {
                    return;
                }

                try
                {
                    object objFileName = MailMerge.CopyTempStoredMailMergeFile( frm.SelectedMailMergeTemplatePath ).FullName;

                    wrdDoc = _wrdApp.Documents.Open( ref objFileName, ref _objMissing, ref _objFalse, ref _objMissing,
                            ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                            ref _objMissing, ref _objTrue, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );
                }
                catch( IOException )
                {
                    MessageBox.Show( this, "A document with the same name is already open", "Mail Merge", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
                catch( Exception  )
                {
                    MessageBox.Show( this, "Error opening MS Word", "Mail Merge", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
            }

            _wrdApp.Visible = true;
            wrdDoc.Activate();
            
            UpdateGUIState();
        }

        private void btnCloseDoc_Click( object sender, EventArgs e )
        {

            if( !_wrdApp.ActiveDocument.Saved )
            {
                _wrdApp.DocumentBeforeSave -= new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler( _wrdApp_DocumentBeforeSave );

                try
                {
                    _wrdApp.ActiveDocument.Save();
                }
                catch 
                {
                    _wrdApp.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler( _wrdApp_DocumentBeforeSave );
                    return;
                }
            }


            // app (and not word) is closing the document, so no need to catch the close event
            _wrdApp.DocumentBeforeClose -= new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler( _wrdApp_DocumentBeforeClose );
            ((_Document)_wrdApp.ActiveDocument).Close( ref _objFalse, ref _objMissing, ref _objMissing );
            _wrdApp.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler( _wrdApp_DocumentBeforeClose );

            _wrdApp.Visible = true;
            UpdateGUIState();

        }

        private void btnStoreDoc_Click( object sender, EventArgs e )
        {

            frmMailMergeSaveAs frm = new frmMailMergeSaveAs();

            if( DialogResult.OK == frm.ShowDialog( this ) )
            {

                if( !string.IsNullOrEmpty( frm.FileName ) )
                {

                    // is the file saved and ready to go since this will involve a copy operation.
                    if( !_wrdApp.ActiveDocument.Saved )
                    {
                        _wrdApp.DocumentBeforeSave -= new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler( _wrdApp_DocumentBeforeSave );
                        _wrdApp.ActiveDocument.Save();
                        _wrdApp.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler( _wrdApp_DocumentBeforeSave );
                    }



                    // check if filename already exists in dir.  
                    if( MailMerge.TemplateExists( frm.FileName )
                            && DialogResult.No == MyMessageBox.Show( this, "MS Word Mail Merge", MyDisplayMessage.OverWriteConfirm ) )
                    {
                        return;
                    }

                    MailMerge.StoreTemplate( frm.FileName, _wrdApp.ActiveDocument.FullName );

                }

            }

        }

        private void btnPreview_Click( object sender, EventArgs e )
        {


            // don't fire any events when performing the merge
            _wrdApp.DocumentBeforeSave -= new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler( _wrdApp_DocumentBeforeSave );
            _wrdApp.DocumentBeforeClose -= new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler( _wrdApp_DocumentBeforeClose );
            _wrdApp.WindowActivate -= new ApplicationEvents4_WindowActivateEventHandler( _wrdApp_WindowActivate );

            
            MailMerge.PreviewMailMerge( _wrdApp );

            _wrdApp.DocumentBeforeSave += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeSaveEventHandler( _wrdApp_DocumentBeforeSave );
            _wrdApp.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler( _wrdApp_DocumentBeforeClose );
            _wrdApp.WindowActivate += new ApplicationEvents4_WindowActivateEventHandler( _wrdApp_WindowActivate );

        } 

        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void UpdateGUIState()
        {
            if( _wrdApp != null && _wrdApp.Documents.Count > 0 )
            {                    
                btnCloseDoc.Enabled = true;
                btnStoreDoc.Enabled = true;
                trvDefendant.Enabled = true;
                btnPreview.Enabled = true;
                UpdateActiveDocument( _wrdApp.ActiveDocument.Name );
            }
            else
            {
                btnCloseDoc.Enabled = false;
                btnStoreDoc.Enabled = false;
                trvDefendant.Enabled = false;
                btnPreview.Enabled = false;
                UpdateActiveDocument( "None" );
            }
        }

        private void _wrdApp_WindowActivate( Document Doc, Window Wn )
        {
            UpdateGUIState();
        }

        private void _wrdApp_DocumentBeforeClose( Document Doc, ref bool Cancel )
        {


            if( DialogResult.Yes == MyMessageBox.Show( null, "MS Word Mail Merge", MyDisplayMessage.MailMergeDocumentCloseWarning ) )
            {
                
                UpdateGUIState();

            }
            else
            {
                Cancel = true;

            }


        }

        private void _wrdApp_DocumentBeforeSave( Document Doc, ref bool SaveAsUI, ref bool Cancel )
        {

            if( SaveAsUI )
            {
                MyMessageBox.Show( null, "MS Word Mail Merge", MyDisplayMessage.MailMergeDocumentSaveWarning );
            }

        }

        private void _wrdApp_Quit()
        {
            _wrdApp = null;
        }

        private void frmMain_FormClosing( object sender, FormClosingEventArgs e )
        {

            if( _wrdApp != null )
            {

                if( _wrdApp.Documents.Count > 0 )
                {
                    _wrdApp.DocumentBeforeClose -= new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler( _wrdApp_DocumentBeforeClose );
                    _wrdApp.Documents.Close( ref _objFalse, ref _objMissing, ref _objMissing );
                    _wrdApp.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler( _wrdApp_DocumentBeforeClose );
                }

                ((Microsoft.Office.Interop.Word._Application)_wrdApp).Quit( ref _objMissing, ref _objMissing, ref _objMissing );

            }
            _wrdApp = null;

        }
    }
}
