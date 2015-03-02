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
using System.Text.RegularExpressions;
using System.IO;


namespace county.feecollections
{
    public partial class frmMailMergeSaveAs : Form
    {

        private string _strFileName;

        #region public string FileName
        public string FileName
        {
            get { return _strFileName; }
        } 
        #endregion

        #region public frmMailMergeSaveAs()
        public frmMailMergeSaveAs()
        {
            InitializeComponent();


            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );


            this.dgvTemplates.SuspendLayout(); 
            this.SuspendLayout();

            this.dgvTemplates.AutoGenerateColumns = false;
            this.dgvTemplates.DataSource = MailMerge.MailMergeTemplates;

            this.dgvTemplates.ResumeLayout();
            this.ResumeLayout();

            this.dgvTemplates.ClearSelection();

            this.btnCancel.Select();
        } 
        #endregion

        #region private void txtFileName_Validating( object sender, CancelEventArgs e )
        private void txtFileName_Validating( object sender, CancelEventArgs e )
        {

            string regexSearch = string.Format("{0}{1}", new string(Path.GetInvalidFileNameChars()), new string(Path.GetInvalidPathChars()));
            Regex r = new Regex( string.Format( "[{0}]", Regex.Escape(regexSearch)) );
            
            if( r.IsMatch( txtFileName.Text.Trim() ) )
            {

                txtFileName.Text = string.Empty;
                MessageBox.Show( this, "A file name cannot contain any of the following characters:    \\ / : * ? \" < > | ", "File Name Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                e.Cancel = true;

            }

        } 
        #endregion

        #region private void btnOkOverwrite_Click( object sender, EventArgs e )
        private void btnOkOverwrite_Click( object sender, EventArgs e )
        {

            if( dgvTemplates.SelectedRows.Count == 1 )
            {
                _strFileName = dgvTemplates.SelectedRows[0].Cells[0].Value.ToString().Substring( 0, dgvTemplates.SelectedRows[0].Cells[0].Value.ToString().LastIndexOf( "." ) );

            }

        } 
        #endregion

        #region private void btnOkNew_Click( object sender, EventArgs e )
        private void btnOkNew_Click( object sender, EventArgs e )
        {

            _strFileName = txtFileName.Text.Trim();

        } 
        #endregion


    }
}
