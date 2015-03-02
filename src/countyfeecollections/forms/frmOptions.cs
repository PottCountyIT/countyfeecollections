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
    public partial class frmOptions : Form
    {
        LocalUser _user;

        #region public frmOptions()
        public frmOptions()
        {
            _user = new LocalUser();

            InitializeComponent();
            InitializeConnectionTab();
            InitializeReportsTab();
            InitializePreferencesTab();
        } 
        #endregion

        public bool IsEmpty()
        {
            return ((txtDBName.Text.Trim() == "") && (txtDBServer.Text.Trim() == ""));
        }

        #region private void InitializeConnectionTab()
        private void InitializeConnectionTab()
        {
            txtDBServer.DataBindings.Add( "Text", LocalUser.DatabaseSettings, "ServerName" );
            txtDBName.DataBindings.Add( "Text", LocalUser.DatabaseSettings, "DatabaseName" );
            txtDBUser.DataBindings.Add( "Text", LocalUser.DatabaseSettings, "UserName" );
            txtDBPassword.DataBindings.Add( "Text", LocalUser.DatabaseSettings, "Password" );
            chkIntegratedSecurity.DataBindings.Add( "Checked", LocalUser.DatabaseSettings, "UseIntegratedSecurity" );
        } 
        #endregion

        #region private void InitializePreferencesTab()
        private void InitializePreferencesTab()
        {
            try
            {
                DBSettings.TestConnection();
                
                cbbCounties.DataSource = Helper.IowaCountyList;
                cbbCounties.DisplayMember = "county";
                cbbCounties.ValueMember = "countyid";

                cbbCounties.SelectedValue = _user.HomeCountyId;
                cbxLenientBilling.Checked = _user.LenientBilling;
            }
            catch
            {

            }

        } 
        #endregion

        private void chkIntegratedSecurity_CheckedChanged( object sender, EventArgs e )
        {
            if( this.chkIntegratedSecurity.Checked )
            {
                this.txtDBUser.ReadOnly = true;
                this.txtDBUser.Enabled = false;

                this.txtDBPassword.ReadOnly = true;
                this.txtDBPassword.Enabled = false;
            }
            else
            {
                this.txtDBUser.Enabled = true;
                this.txtDBUser.ReadOnly = false;
                this.txtDBPassword.Enabled = true;
                this.txtDBPassword.ReadOnly = false;
            }
        }

        private void btnDBTest_Click( object sender, EventArgs e )
        {
            bool success = DBSettings.TestConnection( txtDBServer.Text.Trim(), txtDBName.Text.Trim(), txtDBUser.Text.Trim(), txtDBPassword.Text.Trim(), chkIntegratedSecurity.Checked );
            if (success)
            {
                MyMessageBox.Show(this, "Database Settings", MyDisplayMessage.TestSuccess);
                InitializePreferencesTab(); 
            }
            else
            {
                MessageBox.Show("A connection could not be made to the database.  Please check your connection information.", "Database Error", MessageBoxButtons.OK);
            }           
        }        

        private void btnDBSave_Click( object sender, EventArgs e )
        {
            LocalUser.DatabaseSettings.SaveSettings();
            MyMessageBox.Show( this, "Database Settings", MyDisplayMessage.SaveSuccess );        
        } 

        private void InitializeReportsTab()
        {
            txtMailMergeReportDir.DataBindings.Add( "Text", _user, "MailMergeDirectory", true, DataSourceUpdateMode.OnPropertyChanged );
        }

        private void btnClose_Click( object sender, EventArgs e )
        {
            if( LocalUser.DatabaseSettings.IsDirty || _user.IsDirty  )
            {
                if( DialogResult.Yes == MyMessageBox.Show( this, "Database Settings", MyDisplayMessage.SaveConfirm ) )
                {
                    LocalUser.DatabaseSettings.SaveSettings();
                    _user.SaveSettings();
                }
            }
            this.Close();
        } 

        private void btnReportSave_Click( object sender, EventArgs e )
        {
            _user.SaveSettings();
            MyMessageBox.Show( this, "Report Settings", MyDisplayMessage.SaveSuccess );
        } 

        private void btnSelectFolder_Click( object sender, EventArgs e )
        {
            if( DialogResult.OK == folderBrowserDialog.ShowDialog( this ) )
            {
                txtMailMergeReportDir.Text = folderBrowserDialog.SelectedPath;
            }
        }


        #region private void btnSavePreferences_Click( object sender, EventArgs e )
        private void btnSavePreferences_Click( object sender, EventArgs e )
        {

            int testInt;

            _user.LenientBilling = cbxLenientBilling.Checked;
            if( int.TryParse( cbbCounties.SelectedValue.ToString(), out testInt ) )
            {
                _user.HomeCountyId = testInt;
                _user.HomeCountyName = cbbCounties.Text;
            }

            _user.SaveSettings();
            MyMessageBox.Show( this, "Preferences", MyDisplayMessage.SaveSuccess );
        } 
        #endregion


    }
}
