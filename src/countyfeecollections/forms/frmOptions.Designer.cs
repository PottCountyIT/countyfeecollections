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

namespace county.feecollections
{
    partial class frmOptions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabPageConnection = new System.Windows.Forms.TabPage();
            this.chkIntegratedSecurity = new System.Windows.Forms.CheckBox();
            this.btnDBTest = new System.Windows.Forms.Button();
            this.btnDBSave = new System.Windows.Forms.Button();
            this.txtDBName = new System.Windows.Forms.TextBox();
            this.lblDBName = new System.Windows.Forms.Label();
            this.txtDBPassword = new System.Windows.Forms.TextBox();
            this.lblDBPassword = new System.Windows.Forms.Label();
            this.txtDBUser = new System.Windows.Forms.TextBox();
            this.lblDBUser = new System.Windows.Forms.Label();
            this.txtDBServer = new System.Windows.Forms.TextBox();
            this.lblDBServer = new System.Windows.Forms.Label();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.btnReportsSave = new System.Windows.Forms.Button();
            this.grpMailMergeReportDir = new System.Windows.Forms.GroupBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.txtMailMergeReportDir = new System.Windows.Forms.TextBox();
            this.tabPagePreferences = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbbCounties = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxLenientBilling = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSavePreferences = new System.Windows.Forms.Button();
            this.tabOptions.SuspendLayout();
            this.tabPageConnection.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.grpMailMergeReportDir.SuspendLayout();
            this.tabPagePreferences.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabPageConnection);
            this.tabOptions.Controls.Add(this.tabPageReports);
            this.tabOptions.Controls.Add(this.tabPagePreferences);
            this.tabOptions.Location = new System.Drawing.Point(12, 12);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(470, 269);
            this.tabOptions.TabIndex = 0;
            // 
            // tabPageConnection
            // 
            this.tabPageConnection.AutoScroll = true;
            this.tabPageConnection.Controls.Add(this.chkIntegratedSecurity);
            this.tabPageConnection.Controls.Add(this.btnDBTest);
            this.tabPageConnection.Controls.Add(this.btnDBSave);
            this.tabPageConnection.Controls.Add(this.txtDBName);
            this.tabPageConnection.Controls.Add(this.lblDBName);
            this.tabPageConnection.Controls.Add(this.txtDBPassword);
            this.tabPageConnection.Controls.Add(this.lblDBPassword);
            this.tabPageConnection.Controls.Add(this.txtDBUser);
            this.tabPageConnection.Controls.Add(this.lblDBUser);
            this.tabPageConnection.Controls.Add(this.txtDBServer);
            this.tabPageConnection.Controls.Add(this.lblDBServer);
            this.tabPageConnection.Location = new System.Drawing.Point(4, 22);
            this.tabPageConnection.Name = "tabPageConnection";
            this.tabPageConnection.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConnection.Size = new System.Drawing.Size(462, 243);
            this.tabPageConnection.TabIndex = 0;
            this.tabPageConnection.Text = "Connection";
            this.tabPageConnection.UseVisualStyleBackColor = true;
            // 
            // chkIntegratedSecurity
            // 
            this.chkIntegratedSecurity.AutoSize = true;
            this.chkIntegratedSecurity.Checked = true;
            this.chkIntegratedSecurity.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIntegratedSecurity.Location = new System.Drawing.Point(104, 97);
            this.chkIntegratedSecurity.Name = "chkIntegratedSecurity";
            this.chkIntegratedSecurity.Size = new System.Drawing.Size(132, 17);
            this.chkIntegratedSecurity.TabIndex = 3;
            this.chkIntegratedSecurity.Text = "use integrated security";
            this.chkIntegratedSecurity.UseVisualStyleBackColor = true;
            this.chkIntegratedSecurity.CheckedChanged += new System.EventHandler(this.chkIntegratedSecurity_CheckedChanged);
            // 
            // btnDBTest
            // 
            this.btnDBTest.Location = new System.Drawing.Point(346, 202);
            this.btnDBTest.Name = "btnDBTest";
            this.btnDBTest.Size = new System.Drawing.Size(108, 23);
            this.btnDBTest.TabIndex = 6;
            this.btnDBTest.Text = "Test Connection";
            this.btnDBTest.UseVisualStyleBackColor = true;
            this.btnDBTest.Click += new System.EventHandler(this.btnDBTest_Click);
            // 
            // btnDBSave
            // 
            this.btnDBSave.Location = new System.Drawing.Point(265, 202);
            this.btnDBSave.Name = "btnDBSave";
            this.btnDBSave.Size = new System.Drawing.Size(75, 23);
            this.btnDBSave.TabIndex = 7;
            this.btnDBSave.Text = "Save";
            this.btnDBSave.UseVisualStyleBackColor = true;
            this.btnDBSave.Click += new System.EventHandler(this.btnDBSave_Click);
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(103, 61);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Size = new System.Drawing.Size(350, 20);
            this.txtDBName.TabIndex = 2;
            // 
            // lblDBName
            // 
            this.lblDBName.AutoSize = true;
            this.lblDBName.Location = new System.Drawing.Point(10, 65);
            this.lblDBName.Name = "lblDBName";
            this.lblDBName.Size = new System.Drawing.Size(87, 13);
            this.lblDBName.TabIndex = 8;
            this.lblDBName.Text = "Database Name:";
            // 
            // txtDBPassword
            // 
            this.txtDBPassword.Enabled = false;
            this.txtDBPassword.Location = new System.Drawing.Point(103, 167);
            this.txtDBPassword.Name = "txtDBPassword";
            this.txtDBPassword.PasswordChar = '*';
            this.txtDBPassword.Size = new System.Drawing.Size(350, 20);
            this.txtDBPassword.TabIndex = 5;
            // 
            // lblDBPassword
            // 
            this.lblDBPassword.AutoSize = true;
            this.lblDBPassword.Location = new System.Drawing.Point(41, 171);
            this.lblDBPassword.Name = "lblDBPassword";
            this.lblDBPassword.Size = new System.Drawing.Size(56, 13);
            this.lblDBPassword.TabIndex = 4;
            this.lblDBPassword.Text = "Password:";
            // 
            // txtDBUser
            // 
            this.txtDBUser.Enabled = false;
            this.txtDBUser.Location = new System.Drawing.Point(103, 131);
            this.txtDBUser.Name = "txtDBUser";
            this.txtDBUser.Size = new System.Drawing.Size(350, 20);
            this.txtDBUser.TabIndex = 4;
            // 
            // lblDBUser
            // 
            this.lblDBUser.AutoSize = true;
            this.lblDBUser.Location = new System.Drawing.Point(39, 135);
            this.lblDBUser.Name = "lblDBUser";
            this.lblDBUser.Size = new System.Drawing.Size(58, 13);
            this.lblDBUser.TabIndex = 2;
            this.lblDBUser.Text = "Username:";
            // 
            // txtDBServer
            // 
            this.txtDBServer.Location = new System.Drawing.Point(103, 26);
            this.txtDBServer.Name = "txtDBServer";
            this.txtDBServer.Size = new System.Drawing.Size(350, 20);
            this.txtDBServer.TabIndex = 1;
            // 
            // lblDBServer
            // 
            this.lblDBServer.AutoSize = true;
            this.lblDBServer.Location = new System.Drawing.Point(56, 30);
            this.lblDBServer.Name = "lblDBServer";
            this.lblDBServer.Size = new System.Drawing.Size(41, 13);
            this.lblDBServer.TabIndex = 0;
            this.lblDBServer.Text = "Server:";
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.btnReportsSave);
            this.tabPageReports.Controls.Add(this.grpMailMergeReportDir);
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(462, 243);
            this.tabPageReports.TabIndex = 1;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // btnReportsSave
            // 
            this.btnReportsSave.Location = new System.Drawing.Point(375, 214);
            this.btnReportsSave.Name = "btnReportsSave";
            this.btnReportsSave.Size = new System.Drawing.Size(75, 23);
            this.btnReportsSave.TabIndex = 1;
            this.btnReportsSave.Text = "Save";
            this.btnReportsSave.UseVisualStyleBackColor = true;
            this.btnReportsSave.Click += new System.EventHandler(this.btnReportSave_Click);
            // 
            // grpMailMergeReportDir
            // 
            this.grpMailMergeReportDir.Controls.Add(this.btnSelectFolder);
            this.grpMailMergeReportDir.Controls.Add(this.txtMailMergeReportDir);
            this.grpMailMergeReportDir.Location = new System.Drawing.Point(6, 21);
            this.grpMailMergeReportDir.Name = "grpMailMergeReportDir";
            this.grpMailMergeReportDir.Size = new System.Drawing.Size(450, 69);
            this.grpMailMergeReportDir.TabIndex = 0;
            this.grpMailMergeReportDir.TabStop = false;
            this.grpMailMergeReportDir.Text = "Mail Merge Report Directory";
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolder.Location = new System.Drawing.Point(416, 28);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(28, 23);
            this.btnSelectFolder.TabIndex = 2;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // txtMailMergeReportDir
            // 
            this.txtMailMergeReportDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMailMergeReportDir.Location = new System.Drawing.Point(6, 29);
            this.txtMailMergeReportDir.Name = "txtMailMergeReportDir";
            this.txtMailMergeReportDir.Size = new System.Drawing.Size(409, 20);
            this.txtMailMergeReportDir.TabIndex = 1;
            // 
            // tabPagePreferences
            // 
            this.tabPagePreferences.Controls.Add(this.btnSavePreferences);
            this.tabPagePreferences.Controls.Add(this.groupBox2);
            this.tabPagePreferences.Controls.Add(this.groupBox1);
            this.tabPagePreferences.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreferences.Name = "tabPagePreferences";
            this.tabPagePreferences.Size = new System.Drawing.Size(462, 243);
            this.tabPagePreferences.TabIndex = 2;
            this.tabPagePreferences.Text = "Preferences";
            this.tabPagePreferences.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbCounties);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(4, 81);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(447, 48);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Home County";
            // 
            // cbbCounties
            // 
            this.cbbCounties.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCounties.FormattingEnabled = true;
            this.cbbCounties.Location = new System.Drawing.Point(89, 17);
            this.cbbCounties.Name = "cbbCounties";
            this.cbbCounties.Size = new System.Drawing.Size(121, 21);
            this.cbbCounties.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select County:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxLenientBilling);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lenient Billing";
            // 
            // cbxLenientBilling
            // 
            this.cbxLenientBilling.AutoSize = true;
            this.cbxLenientBilling.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxLenientBilling.Location = new System.Drawing.Point(7, 50);
            this.cbxLenientBilling.Name = "cbxLenientBilling";
            this.cbxLenientBilling.Size = new System.Drawing.Size(91, 17);
            this.cbxLenientBilling.TabIndex = 1;
            this.cbxLenientBilling.Text = "Lenient Billing";
            this.cbxLenientBilling.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(7, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(434, 35);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "When checked, customers will only be marked as delinquent when their last payment was made over 30 days ago.";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(403, 288);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // btnSavePreferences
            // 
            this.btnSavePreferences.Location = new System.Drawing.Point(376, 206);
            this.btnSavePreferences.Name = "btnSavePreferences";
            this.btnSavePreferences.Size = new System.Drawing.Size(75, 23);
            this.btnSavePreferences.TabIndex = 2;
            this.btnSavePreferences.Text = "Save";
            this.btnSavePreferences.UseVisualStyleBackColor = true;
            this.btnSavePreferences.Click += new System.EventHandler( this.btnSavePreferences_Click );
            // 
            // frmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 323);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.tabOptions.ResumeLayout(false);
            this.tabPageConnection.ResumeLayout(false);
            this.tabPageConnection.PerformLayout();
            this.tabPageReports.ResumeLayout(false);
            this.grpMailMergeReportDir.ResumeLayout(false);
            this.grpMailMergeReportDir.PerformLayout();
            this.tabPagePreferences.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabPageConnection;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.TextBox txtDBName;
        private System.Windows.Forms.Label lblDBName;
        private System.Windows.Forms.TextBox txtDBPassword;
        private System.Windows.Forms.Label lblDBPassword;
        private System.Windows.Forms.TextBox txtDBUser;
        private System.Windows.Forms.Label lblDBUser;
        private System.Windows.Forms.TextBox txtDBServer;
        private System.Windows.Forms.Label lblDBServer;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDBTest;
        private System.Windows.Forms.Button btnDBSave;
        private System.Windows.Forms.CheckBox chkIntegratedSecurity;
        private System.Windows.Forms.GroupBox grpMailMergeReportDir;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtMailMergeReportDir;
        private System.Windows.Forms.Button btnReportsSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.TabPage tabPagePreferences;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox cbxLenientBilling;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbbCounties;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSavePreferences;
    }
}
