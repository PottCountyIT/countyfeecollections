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
    partial class frmMailMergeSaveAs
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblInstruct1 = new System.Windows.Forms.Label();
            this.dgvTemplates = new System.Windows.Forms.DataGridView();
            this.TemplateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastWrittenTo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpOverwrite = new System.Windows.Forms.GroupBox();
            this.btnOkOverwrite = new System.Windows.Forms.Button();
            this.grpSaveNew = new System.Windows.Forms.GroupBox();
            this.btnOkNew = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.lblInstruct = new System.Windows.Forms.Label();
            this.lblOR = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).BeginInit();
            this.grpOverwrite.SuspendLayout();
            this.grpSaveNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 324, 372 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblInstruct1
            // 
            this.lblInstruct1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruct1.Location = new System.Drawing.Point( 5, 366 );
            this.lblInstruct1.Name = "lblInstruct1";
            this.lblInstruct1.Size = new System.Drawing.Size( 313, 33 );
            this.lblInstruct1.TabIndex = 5;
            this.lblInstruct1.Text = "If the document you are storing has not been saved MS Word is going to prompt you" +
                " after clicking Ok.";
            // 
            // dgvTemplates
            // 
            this.dgvTemplates.AllowUserToAddRows = false;
            this.dgvTemplates.AllowUserToDeleteRows = false;
            this.dgvTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTemplates.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemplates.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.TemplateName,
            this.LastWrittenTo} );
            this.dgvTemplates.Location = new System.Drawing.Point( 6, 19 );
            this.dgvTemplates.MultiSelect = false;
            this.dgvTemplates.Name = "dgvTemplates";
            this.dgvTemplates.ReadOnly = true;
            this.dgvTemplates.RowHeadersVisible = false;
            this.dgvTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTemplates.Size = new System.Drawing.Size( 393, 170 );
            this.dgvTemplates.TabIndex = 6;
            // 
            // TemplateName
            // 
            this.TemplateName.DataPropertyName = "TemplateName";
            this.TemplateName.HeaderText = "Template Name";
            this.TemplateName.Name = "TemplateName";
            this.TemplateName.ReadOnly = true;
            // 
            // LastWrittenTo
            // 
            this.LastWrittenTo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.LastWrittenTo.DataPropertyName = "LastWrittenTo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "d";
            this.LastWrittenTo.DefaultCellStyle = dataGridViewCellStyle1;
            this.LastWrittenTo.HeaderText = "Last Write Time";
            this.LastWrittenTo.Name = "LastWrittenTo";
            this.LastWrittenTo.ReadOnly = true;
            this.LastWrittenTo.Width = 97;
            // 
            // grpOverwrite
            // 
            this.grpOverwrite.Controls.Add( this.btnOkOverwrite );
            this.grpOverwrite.Controls.Add( this.dgvTemplates );
            this.grpOverwrite.Location = new System.Drawing.Point( 2, 142 );
            this.grpOverwrite.Name = "grpOverwrite";
            this.grpOverwrite.Size = new System.Drawing.Size( 405, 224 );
            this.grpOverwrite.TabIndex = 7;
            this.grpOverwrite.TabStop = false;
            this.grpOverwrite.Text = "Overwite Existing";
            // 
            // btnOkOverwrite
            // 
            this.btnOkOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkOverwrite.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkOverwrite.Location = new System.Drawing.Point( 322, 195 );
            this.btnOkOverwrite.Name = "btnOkOverwrite";
            this.btnOkOverwrite.Size = new System.Drawing.Size( 75, 23 );
            this.btnOkOverwrite.TabIndex = 7;
            this.btnOkOverwrite.Text = "Ok";
            this.btnOkOverwrite.UseVisualStyleBackColor = true;
            this.btnOkOverwrite.Click += new System.EventHandler( this.btnOkOverwrite_Click );
            // 
            // grpSaveNew
            // 
            this.grpSaveNew.Controls.Add( this.btnOkNew );
            this.grpSaveNew.Controls.Add( this.txtFileName );
            this.grpSaveNew.Controls.Add( this.lblFileName );
            this.grpSaveNew.Controls.Add( this.lblInstruct );
            this.grpSaveNew.Location = new System.Drawing.Point( 2, 2 );
            this.grpSaveNew.Name = "grpSaveNew";
            this.grpSaveNew.Size = new System.Drawing.Size( 405, 121 );
            this.grpSaveNew.TabIndex = 8;
            this.grpSaveNew.TabStop = false;
            this.grpSaveNew.Text = "Save New";
            // 
            // btnOkNew
            // 
            this.btnOkNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkNew.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOkNew.Location = new System.Drawing.Point( 323, 92 );
            this.btnOkNew.Name = "btnOkNew";
            this.btnOkNew.Size = new System.Drawing.Size( 75, 23 );
            this.btnOkNew.TabIndex = 8;
            this.btnOkNew.Text = "Ok";
            this.btnOkNew.UseVisualStyleBackColor = true;
            this.btnOkNew.Click += new System.EventHandler( this.btnOkNew_Click );
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point( 66, 64 );
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size( 333, 20 );
            this.txtFileName.TabIndex = 7;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point( 3, 62 );
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size( 57, 13 );
            this.lblFileName.TabIndex = 6;
            this.lblFileName.Text = "File Name:";
            // 
            // lblInstruct
            // 
            this.lblInstruct.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstruct.Location = new System.Drawing.Point( 8, 16 );
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size( 389, 34 );
            this.lblInstruct.TabIndex = 5;
            this.lblInstruct.Text = "Please enter a file name with no extension or period character (i.e. .doc).  A fi" +
                "le name cannot contain any of the following characters:    \\ / : * ? \" < > | ";
            // 
            // lblOR
            // 
            this.lblOR.AutoSize = true;
            this.lblOR.Location = new System.Drawing.Point( 167, 126 );
            this.lblOR.Name = "lblOR";
            this.lblOR.Size = new System.Drawing.Size( 35, 13 );
            this.lblOR.TabIndex = 9;
            this.lblOR.Text = "- OR -";
            // 
            // frmMailMergeSaveAs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size( 412, 407 );
            this.Controls.Add( this.lblOR );
            this.Controls.Add( this.grpSaveNew );
            this.Controls.Add( this.grpOverwrite );
            this.Controls.Add( this.lblInstruct1 );
            this.Controls.Add( this.btnCancel );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = global::county.feecollections.Properties.Resources.msword;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMailMergeSaveAs";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save Template As";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemplates)).EndInit();
            this.grpOverwrite.ResumeLayout( false );
            this.grpSaveNew.ResumeLayout( false );
            this.grpSaveNew.PerformLayout();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblInstruct1;
        private System.Windows.Forms.DataGridView dgvTemplates;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastWrittenTo;
        private System.Windows.Forms.GroupBox grpOverwrite;
        private System.Windows.Forms.GroupBox grpSaveNew;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.Label lblOR;
        private System.Windows.Forms.Button btnOkOverwrite;
        private System.Windows.Forms.Button btnOkNew;
    }
}
