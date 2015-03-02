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
    partial class frmDefendantEmployers
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label lblCityStZip;
            System.Windows.Forms.Label lblEmployerName;
            System.Windows.Forms.Label lblPhone;
            System.Windows.Forms.Label lblSeparationDate;
            System.Windows.Forms.Label lblStreet1;
            System.Windows.Forms.Label lblStreet2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.dgvEmployers = new System.Windows.Forms.DataGridView();
            this.dgvEmployersClmEmployerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingEmployers = new System.Windows.Forms.BindingSource( this.components );
            this.ucFilter = new county.feecollections.ucFilter();
            this.btnEmployerMasterList = new System.Windows.Forms.Button();
            this.mskSeparationDate = new System.Windows.Forms.MaskedTextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtEmployerName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtStateName = new System.Windows.Forms.TextBox();
            this.txtStreet1 = new System.Windows.Forms.TextBox();
            this.txtStreet2 = new System.Windows.Forms.TextBox();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblNote = new System.Windows.Forms.Label();
            lblCityStZip = new System.Windows.Forms.Label();
            lblEmployerName = new System.Windows.Forms.Label();
            lblPhone = new System.Windows.Forms.Label();
            lblSeparationDate = new System.Windows.Forms.Label();
            lblStreet1 = new System.Windows.Forms.Label();
            lblStreet2 = new System.Windows.Forms.Label();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCityStZip
            // 
            lblCityStZip.AutoSize = true;
            lblCityStZip.Location = new System.Drawing.Point( 14, 121 );
            lblCityStZip.Name = "lblCityStZip";
            lblCityStZip.Size = new System.Drawing.Size( 76, 13 );
            lblCityStZip.TabIndex = 6;
            lblCityStZip.Text = "City, State Zip:";
            // 
            // lblEmployerName
            // 
            lblEmployerName.AutoSize = true;
            lblEmployerName.Location = new System.Drawing.Point( 6, 31 );
            lblEmployerName.Name = "lblEmployerName";
            lblEmployerName.Size = new System.Drawing.Size( 84, 13 );
            lblEmployerName.TabIndex = 8;
            lblEmployerName.Text = "Employer Name:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new System.Drawing.Point( 49, 151 );
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new System.Drawing.Size( 41, 13 );
            lblPhone.TabIndex = 14;
            lblPhone.Text = "Phone:";
            // 
            // lblSeparationDate
            // 
            lblSeparationDate.AutoSize = true;
            lblSeparationDate.Location = new System.Drawing.Point( 3, 181 );
            lblSeparationDate.Name = "lblSeparationDate";
            lblSeparationDate.Size = new System.Drawing.Size( 87, 13 );
            lblSeparationDate.TabIndex = 18;
            lblSeparationDate.Text = "Separation Date:";
            // 
            // lblStreet1
            // 
            lblStreet1.AutoSize = true;
            lblStreet1.Location = new System.Drawing.Point( 46, 61 );
            lblStreet1.Name = "lblStreet1";
            lblStreet1.Size = new System.Drawing.Size( 44, 13 );
            lblStreet1.TabIndex = 24;
            lblStreet1.Text = "Street1:";
            // 
            // lblStreet2
            // 
            lblStreet2.AutoSize = true;
            lblStreet2.Location = new System.Drawing.Point( 46, 91 );
            lblStreet2.Name = "lblStreet2";
            lblStreet2.Size = new System.Drawing.Size( 44, 13 );
            lblStreet2.TabIndex = 26;
            lblStreet2.Text = "Street2:";
            // 
            // splitContainer
            // 
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point( 0, 0 );
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add( this.dgvEmployers );
            this.splitContainer.Panel1.Controls.Add( this.ucFilter );
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add( this.lblNote );
            this.splitContainer.Panel2.Controls.Add( this.btnEmployerMasterList );
            this.splitContainer.Panel2.Controls.Add( this.mskSeparationDate );
            this.splitContainer.Panel2.Controls.Add( this.txtCity );
            this.splitContainer.Panel2.Controls.Add( this.txtEmployerName );
            this.splitContainer.Panel2.Controls.Add( this.txtPhone );
            this.splitContainer.Panel2.Controls.Add( this.txtStateName );
            this.splitContainer.Panel2.Controls.Add( this.txtStreet1 );
            this.splitContainer.Panel2.Controls.Add( this.txtStreet2 );
            this.splitContainer.Panel2.Controls.Add( this.txtZip );
            this.splitContainer.Panel2.Controls.Add( this.btnAdd );
            this.splitContainer.Panel2.Controls.Add( this.btnCancel );
            this.splitContainer.Panel2.Controls.Add( lblCityStZip );
            this.splitContainer.Panel2.Controls.Add( lblEmployerName );
            this.splitContainer.Panel2.Controls.Add( lblPhone );
            this.splitContainer.Panel2.Controls.Add( lblSeparationDate );
            this.splitContainer.Panel2.Controls.Add( lblStreet1 );
            this.splitContainer.Panel2.Controls.Add( lblStreet2 );
            this.splitContainer.Size = new System.Drawing.Size( 576, 250 );
            this.splitContainer.SplitterDistance = 266;
            this.splitContainer.TabIndex = 6;
            // 
            // dgvEmployers
            // 
            this.dgvEmployers.AllowUserToAddRows = false;
            this.dgvEmployers.AllowUserToDeleteRows = false;
            this.dgvEmployers.AllowUserToOrderColumns = true;
            this.dgvEmployers.AllowUserToResizeRows = false;
            this.dgvEmployers.AutoGenerateColumns = false;
            this.dgvEmployers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEmployers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployers.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvEmployersClmEmployerName} );
            this.dgvEmployers.DataSource = this.bindingEmployers;
            this.dgvEmployers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmployers.Location = new System.Drawing.Point( 0, 89 );
            this.dgvEmployers.MultiSelect = false;
            this.dgvEmployers.Name = "dgvEmployers";
            this.dgvEmployers.ReadOnly = true;
            this.dgvEmployers.RowHeadersVisible = false;
            this.dgvEmployers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployers.Size = new System.Drawing.Size( 262, 157 );
            this.dgvEmployers.StandardTab = true;
            this.dgvEmployers.TabIndex = 11;
            // 
            // dgvEmployersClmEmployerName
            // 
            this.dgvEmployersClmEmployerName.DataPropertyName = "EmployerName";
            dataGridViewCellStyle4.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.dgvEmployersClmEmployerName.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEmployersClmEmployerName.FillWeight = 151.7345F;
            this.dgvEmployersClmEmployerName.HeaderText = "EmployerName";
            this.dgvEmployersClmEmployerName.Name = "dgvEmployersClmEmployerName";
            this.dgvEmployersClmEmployerName.ReadOnly = true;
            // 
            // bindingEmployers
            // 
            this.bindingEmployers.DataSource = typeof( county.feecollections.Employers );
            // 
            // ucFilter
            // 
            this.ucFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFilter.Location = new System.Drawing.Point( 0, 0 );
            this.ucFilter.Name = "ucFilter";
            this.ucFilter.Size = new System.Drawing.Size( 262, 89 );
            this.ucFilter.TabIndex = 10;
            // 
            // btnEmployerMasterList
            // 
            this.btnEmployerMasterList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmployerMasterList.Location = new System.Drawing.Point( 6, 213 );
            this.btnEmployerMasterList.Name = "btnEmployerMasterList";
            this.btnEmployerMasterList.Size = new System.Drawing.Size( 126, 23 );
            this.btnEmployerMasterList.TabIndex = 8;
            this.btnEmployerMasterList.Text = "Master Employer List...";
            this.btnEmployerMasterList.UseVisualStyleBackColor = true;
            this.btnEmployerMasterList.Click += new System.EventHandler( this.btnEmployerMasterList_Click );
            // 
            // mskSeparationDate
            // 
            this.mskSeparationDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mskSeparationDate.Location = new System.Drawing.Point( 86, 178 );
            this.mskSeparationDate.Mask = "00/00/0000";
            this.mskSeparationDate.Name = "mskSeparationDate";
            this.mskSeparationDate.Size = new System.Drawing.Size( 211, 20 );
            this.mskSeparationDate.TabIndex = 34;
            this.mskSeparationDate.ValidatingType = typeof( System.DateTime );
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.BackColor = System.Drawing.SystemColors.Window;
            this.txtCity.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "City", true ) );
            this.txtCity.Enabled = false;
            this.txtCity.Location = new System.Drawing.Point( 86, 117 );
            this.txtCity.Name = "txtCity";
            this.txtCity.ReadOnly = true;
            this.txtCity.Size = new System.Drawing.Size( 102, 20 );
            this.txtCity.TabIndex = 7;
            // 
            // txtEmployerName
            // 
            this.txtEmployerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmployerName.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmployerName.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "EmployerName", true ) );
            this.txtEmployerName.Enabled = false;
            this.txtEmployerName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.txtEmployerName.Location = new System.Drawing.Point( 86, 27 );
            this.txtEmployerName.Name = "txtEmployerName";
            this.txtEmployerName.ReadOnly = true;
            this.txtEmployerName.Size = new System.Drawing.Size( 211, 20 );
            this.txtEmployerName.TabIndex = 9;
            // 
            // txtPhone
            // 
            this.txtPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhone.BackColor = System.Drawing.SystemColors.Window;
            this.txtPhone.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "Phone", true ) );
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point( 86, 147 );
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.ReadOnly = true;
            this.txtPhone.Size = new System.Drawing.Size( 211, 20 );
            this.txtPhone.TabIndex = 15;
            // 
            // txtStateName
            // 
            this.txtStateName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStateName.BackColor = System.Drawing.SystemColors.Window;
            this.txtStateName.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "StateName", true ) );
            this.txtStateName.Enabled = false;
            this.txtStateName.Location = new System.Drawing.Point( 194, 117 );
            this.txtStateName.Name = "txtStateName";
            this.txtStateName.ReadOnly = true;
            this.txtStateName.Size = new System.Drawing.Size( 29, 20 );
            this.txtStateName.TabIndex = 23;
            // 
            // txtStreet1
            // 
            this.txtStreet1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet1.BackColor = System.Drawing.SystemColors.Window;
            this.txtStreet1.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "Street1", true ) );
            this.txtStreet1.Enabled = false;
            this.txtStreet1.Location = new System.Drawing.Point( 86, 57 );
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.ReadOnly = true;
            this.txtStreet1.Size = new System.Drawing.Size( 211, 20 );
            this.txtStreet1.TabIndex = 25;
            // 
            // txtStreet2
            // 
            this.txtStreet2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet2.BackColor = System.Drawing.SystemColors.Window;
            this.txtStreet2.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "Street2", true ) );
            this.txtStreet2.Enabled = false;
            this.txtStreet2.Location = new System.Drawing.Point( 86, 87 );
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.ReadOnly = true;
            this.txtStreet2.Size = new System.Drawing.Size( 211, 20 );
            this.txtStreet2.TabIndex = 27;
            // 
            // txtZip
            // 
            this.txtZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtZip.BackColor = System.Drawing.SystemColors.Window;
            this.txtZip.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "Zip", true ) );
            this.txtZip.Enabled = false;
            this.txtZip.Location = new System.Drawing.Point( 229, 117 );
            this.txtZip.Name = "txtZip";
            this.txtZip.ReadOnly = true;
            this.txtZip.Size = new System.Drawing.Size( 68, 20 );
            this.txtZip.TabIndex = 33;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Location = new System.Drawing.Point( 141, 213 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 75, 23 );
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 222, 213 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblNote.Location = new System.Drawing.Point( 86, 198 );
            this.lblNote.Margin = new System.Windows.Forms.Padding( 3, 0, 0, 0 );
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size( 122, 13 );
            this.lblNote.TabIndex = 35;
            this.lblNote.Text = "*Blank indicates current.";
            // 
            // frmDefendantEmployers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 576, 250 );
            this.Controls.Add( this.splitContainer );
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 592, 286 );
            this.Name = "frmDefendantEmployers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employers";
            this.Load += new System.EventHandler( this.frmEmployers_Load );
            this.splitContainer.Panel1.ResumeLayout( false );
            this.splitContainer.Panel2.ResumeLayout( false );
            this.splitContainer.Panel2.PerformLayout();
            this.splitContainer.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployers)).EndInit();
            this.ResumeLayout( false );

        }


        #endregion

        private System.Windows.Forms.BindingSource bindingEmployers;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtEmployerName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtStateName;
        private System.Windows.Forms.TextBox txtStreet1;
        private System.Windows.Forms.TextBox txtStreet2;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.Button btnEmployerMasterList;
        private System.Windows.Forms.MaskedTextBox mskSeparationDate;
        private System.Windows.Forms.DataGridView dgvEmployers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmployersClmEmployerName;
        private ucFilter ucFilter;
        private System.Windows.Forms.Label lblNote;
    }
}
