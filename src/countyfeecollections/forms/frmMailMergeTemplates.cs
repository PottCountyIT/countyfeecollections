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

namespace county.feecollections
{
    public partial class frmMailMergeTemplates : Form
    {
        public string SelectedMailMergeTemplatePath
        {
            get
            {
                return ( dgvTemplates.SelectedRows.Count > 0 ) ? ((DataRowView)dgvTemplates.SelectedRows[0].DataBoundItem)["TemplatePath"].ToString() : string.Empty;
            }
        } 

        public frmMailMergeTemplates()
        {
            if( !MailMerge.StoreDirectoryConfigured() && !MailMerge.StoreDirectoryExists() )
            {
                MyMessageBox.Show( this, "MS Word Mail Merge", MyDisplayMessage.MailMergeDirectoryError );
                this.Close();
                return;
            }

            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );


            this.dgvTemplates.AutoGenerateColumns = false;
            this.dgvTemplates.DataSource = MailMerge.MailMergeTemplates;

            this.dgvTemplates.ClearSelection();
        } 

        private void btnDelete_Click( object sender, EventArgs e )
        {
            if( !string.IsNullOrEmpty( SelectedMailMergeTemplatePath ) )
            {
                string strTemplateName = ((DataRowView)dgvTemplates.SelectedRows[0].DataBoundItem)["TemplateName"].ToString();
                if( DialogResult.OK == MyMessageBox.Show( this, strTemplateName, MyDisplayMessage.RemoveConfirm ) )
                {

                    if( MailMerge.DeleteTemplate( SelectedMailMergeTemplatePath ) )
                    {

                        this.dgvTemplates.DataSource = MailMerge.MailMergeTemplates;
                        this.dgvTemplates.ClearSelection();
                    }
                    else
                    {
                        MyMessageBox.Show( this, strTemplateName, MyDisplayMessage.RemoveError, new MyException( "Unable to delete template.  Check the event viewer for more info.", new Exception() ) );
                    }

                    
                }
            }

        } 
    }
}
