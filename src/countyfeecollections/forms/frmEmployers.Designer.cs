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
    partial class frmEmployers
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
            System.Windows.Forms.Label employerNameLabel;
            System.Windows.Forms.Label street1Label;
            System.Windows.Forms.Label street2Label;
            System.Windows.Forms.Label lblCityStateZip;
            System.Windows.Forms.Label lblPhone;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmEmployers ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.mnuEmployer = new System.Windows.Forms.BindingNavigator( this.components );
            this.bindingEmployers = new System.Windows.Forms.BindingSource( this.components );
            this.mnuEmployerNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEmployerRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuEmployerRefresh = new System.Windows.Forms.ToolStripButton();
            this.mnuEmployerSave = new System.Windows.Forms.ToolStripButton();
            this.mnuEmployerCancel = new System.Windows.Forms.ToolStripButton();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.txtEmployerName = new System.Windows.Forms.TextBox();
            this.txtStreet1 = new System.Windows.Forms.TextBox();
            this.txtStreet2 = new System.Windows.Forms.TextBox();
            this.grpEmployer = new System.Windows.Forms.GroupBox();
            this.mskPhone = new System.Windows.Forms.MaskedTextBox();
            this.mskZip = new System.Windows.Forms.MaskedTextBox();
            this.cmbStates = new System.Windows.Forms.ComboBox();
            this.dgvEmployers = new System.Windows.Forms.DataGridView();
            this.dgvEmployersClmEmployerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpDefendants = new System.Windows.Forms.GroupBox();
            this.dgvDefendants = new System.Windows.Forms.DataGridView();
            this.dgvDefendantsClmLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDefendantsClmFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingDefendants = new System.Windows.Forms.BindingSource( this.components );
            this.grpEmployerFilter = new System.Windows.Forms.GroupBox();
            this.ucFilter = new county.feecollections.ucFilter();
            employerNameLabel = new System.Windows.Forms.Label();
            street1Label = new System.Windows.Forms.Label();
            street2Label = new System.Windows.Forms.Label();
            lblCityStateZip = new System.Windows.Forms.Label();
            lblPhone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mnuEmployer)).BeginInit();
            this.mnuEmployer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployers)).BeginInit();
            this.grpEmployer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployers)).BeginInit();
            this.grpDefendants.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefendants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingDefendants)).BeginInit();
            this.grpEmployerFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // employerNameLabel
            // 
            employerNameLabel.AutoSize = true;
            employerNameLabel.Location = new System.Drawing.Point( 6, 23 );
            employerNameLabel.Name = "employerNameLabel";
            employerNameLabel.Size = new System.Drawing.Size( 84, 13 );
            employerNameLabel.TabIndex = 23;
            employerNameLabel.Text = "Employer Name:";
            // 
            // street1Label
            // 
            street1Label.AutoSize = true;
            street1Label.Location = new System.Drawing.Point( 46, 56 );
            street1Label.Name = "street1Label";
            street1Label.Size = new System.Drawing.Size( 44, 13 );
            street1Label.TabIndex = 33;
            street1Label.Text = "Street1:";
            // 
            // street2Label
            // 
            street2Label.AutoSize = true;
            street2Label.Location = new System.Drawing.Point( 46, 89 );
            street2Label.Name = "street2Label";
            street2Label.Size = new System.Drawing.Size( 44, 13 );
            street2Label.TabIndex = 35;
            street2Label.Text = "Street2:";
            // 
            // lblCityStateZip
            // 
            lblCityStateZip.AutoSize = true;
            lblCityStateZip.Location = new System.Drawing.Point( 14, 122 );
            lblCityStateZip.Name = "lblCityStateZip";
            lblCityStateZip.Size = new System.Drawing.Size( 76, 13 );
            lblCityStateZip.TabIndex = 2;
            lblCityStateZip.Text = "City, State Zip:";
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new System.Drawing.Point( 49, 155 );
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new System.Drawing.Size( 41, 13 );
            lblPhone.TabIndex = 36;
            lblPhone.Text = "Phone:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point( 572, 332 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 37;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // mnuEmployer
            // 
            this.mnuEmployer.AddNewItem = null;
            this.mnuEmployer.BindingSource = this.bindingEmployers;
            this.mnuEmployer.CountItem = null;
            this.mnuEmployer.DeleteItem = null;
            this.mnuEmployer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuEmployer.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.mnuEmployerNew,
            this.toolStripSeparator1,
            this.mnuEmployerRemove,
            this.mnuEmployerRefresh,
            this.mnuEmployerSave,
            this.mnuEmployerCancel} );
            this.mnuEmployer.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuEmployer.Location = new System.Drawing.Point( 0, 0 );
            this.mnuEmployer.MoveFirstItem = null;
            this.mnuEmployer.MoveLastItem = null;
            this.mnuEmployer.MoveNextItem = null;
            this.mnuEmployer.MovePreviousItem = null;
            this.mnuEmployer.Name = "mnuEmployer";
            this.mnuEmployer.PositionItem = null;
            this.mnuEmployer.Size = new System.Drawing.Size( 653, 25 );
            this.mnuEmployer.TabIndex = 21;
            this.mnuEmployer.Text = "mnuEmployer";
            // 
            // bindingEmployers
            // 
            this.bindingEmployers.DataSource = typeof( county.feecollections.Employer );
            // 
            // mnuEmployerNew
            // 
            this.mnuEmployerNew.Image = ((System.Drawing.Image)(resources.GetObject( "mnuEmployerNew.Image" )));
            this.mnuEmployerNew.Name = "mnuEmployerNew";
            this.mnuEmployerNew.RightToLeftAutoMirrorImage = true;
            this.mnuEmployerNew.Size = new System.Drawing.Size( 51, 22 );
            this.mnuEmployerNew.Text = "&New";
            this.mnuEmployerNew.Click += new System.EventHandler( this.mnuEmployer_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 25 );
            // 
            // mnuEmployerRemove
            // 
            this.mnuEmployerRemove.Enabled = false;
            this.mnuEmployerRemove.Image = ((System.Drawing.Image)(resources.GetObject( "mnuEmployerRemove.Image" )));
            this.mnuEmployerRemove.Name = "mnuEmployerRemove";
            this.mnuEmployerRemove.RightToLeftAutoMirrorImage = true;
            this.mnuEmployerRemove.Size = new System.Drawing.Size( 70, 22 );
            this.mnuEmployerRemove.Text = "&Remove";
            this.mnuEmployerRemove.Click += new System.EventHandler( this.mnuEmployer_Click );
            // 
            // mnuEmployerRefresh
            // 
            this.mnuEmployerRefresh.Enabled = false;
            this.mnuEmployerRefresh.Image = ((System.Drawing.Image)(resources.GetObject( "mnuEmployerRefresh.Image" )));
            this.mnuEmployerRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEmployerRefresh.Name = "mnuEmployerRefresh";
            this.mnuEmployerRefresh.Size = new System.Drawing.Size( 66, 22 );
            this.mnuEmployerRefresh.Text = "Re&fresh";
            this.mnuEmployerRefresh.Click += new System.EventHandler( this.mnuEmployer_Click );
            // 
            // mnuEmployerSave
            // 
            this.mnuEmployerSave.Enabled = false;
            this.mnuEmployerSave.Image = ((System.Drawing.Image)(resources.GetObject( "mnuEmployerSave.Image" )));
            this.mnuEmployerSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEmployerSave.Name = "mnuEmployerSave";
            this.mnuEmployerSave.Size = new System.Drawing.Size( 51, 22 );
            this.mnuEmployerSave.Text = "&Save";
            this.mnuEmployerSave.Click += new System.EventHandler( this.mnuEmployer_Click );
            // 
            // mnuEmployerCancel
            // 
            this.mnuEmployerCancel.Enabled = false;
            this.mnuEmployerCancel.Image = ((System.Drawing.Image)(resources.GetObject( "mnuEmployerCancel.Image" )));
            this.mnuEmployerCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuEmployerCancel.Name = "mnuEmployerCancel";
            this.mnuEmployerCancel.Size = new System.Drawing.Size( 63, 22 );
            this.mnuEmployerCancel.Text = "&Cancel";
            this.mnuEmployerCancel.Click += new System.EventHandler( this.mnuEmployer_Click );
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "City", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
            this.txtCity.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.txtCity.Location = new System.Drawing.Point( 87, 118 );
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size( 167, 20 );
            this.txtCity.TabIndex = 34;
            // 
            // txtEmployerName
            // 
            this.txtEmployerName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmployerName.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "EmployerName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
            this.txtEmployerName.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.txtEmployerName.Location = new System.Drawing.Point( 87, 19 );
            this.txtEmployerName.Name = "txtEmployerName";
            this.txtEmployerName.Size = new System.Drawing.Size( 298, 20 );
            this.txtEmployerName.TabIndex = 31;
            // 
            // txtStreet1
            // 
            this.txtStreet1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet1.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "Street1", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
            this.txtStreet1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.txtStreet1.Location = new System.Drawing.Point( 87, 52 );
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.Size = new System.Drawing.Size( 298, 20 );
            this.txtStreet1.TabIndex = 32;
            // 
            // txtStreet2
            // 
            this.txtStreet2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet2.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "Street2", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
            this.txtStreet2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.txtStreet2.Location = new System.Drawing.Point( 87, 85 );
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size( 298, 20 );
            this.txtStreet2.TabIndex = 33;
            // 
            // grpEmployer
            // 
            this.grpEmployer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEmployer.Controls.Add( this.mskPhone );
            this.grpEmployer.Controls.Add( lblPhone );
            this.grpEmployer.Controls.Add( this.mskZip );
            this.grpEmployer.Controls.Add( this.cmbStates );
            this.grpEmployer.Controls.Add( this.txtCity );
            this.grpEmployer.Controls.Add( this.txtEmployerName );
            this.grpEmployer.Controls.Add( this.txtStreet1 );
            this.grpEmployer.Controls.Add( this.txtStreet2 );
            this.grpEmployer.Controls.Add( lblCityStateZip );
            this.grpEmployer.Controls.Add( street2Label );
            this.grpEmployer.Controls.Add( street1Label );
            this.grpEmployer.Controls.Add( employerNameLabel );
            this.grpEmployer.Location = new System.Drawing.Point( 253, 28 );
            this.grpEmployer.Name = "grpEmployer";
            this.grpEmployer.Size = new System.Drawing.Size( 391, 184 );
            this.grpEmployer.TabIndex = 1;
            this.grpEmployer.TabStop = false;
            this.grpEmployer.Text = "Employer Details";
            // 
            // mskPhone
            // 
            this.mskPhone.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "Phone", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
            this.mskPhone.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.mskPhone.Location = new System.Drawing.Point( 87, 151 );
            this.mskPhone.Mask = "(999) 000-0000";
            this.mskPhone.Name = "mskPhone";
            this.mskPhone.Size = new System.Drawing.Size( 298, 20 );
            this.mskPhone.TabIndex = 37;
            // 
            // mskZip
            // 
            this.mskZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mskZip.DataBindings.Add( new System.Windows.Forms.Binding( "Text", this.bindingEmployers, "Zip", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
            this.mskZip.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.mskZip.Location = new System.Drawing.Point( 309, 118 );
            this.mskZip.Mask = "00000-9999";
            this.mskZip.Name = "mskZip";
            this.mskZip.Size = new System.Drawing.Size( 76, 20 );
            this.mskZip.TabIndex = 36;
            // 
            // cmbStates
            // 
            this.cmbStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStates.DataBindings.Add( new System.Windows.Forms.Binding( "SelectedValue", this.bindingEmployers, "StateID", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged ) );
            this.cmbStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStates.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.cmbStates.FormattingEnabled = true;
            this.cmbStates.Location = new System.Drawing.Point( 260, 118 );
            this.cmbStates.Name = "cmbStates";
            this.cmbStates.Size = new System.Drawing.Size( 43, 21 );
            this.cmbStates.TabIndex = 35;
            // 
            // dgvEmployers
            // 
            this.dgvEmployers.AllowUserToAddRows = false;
            this.dgvEmployers.AllowUserToDeleteRows = false;
            this.dgvEmployers.AllowUserToResizeColumns = false;
            this.dgvEmployers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployers.AutoGenerateColumns = false;
            this.dgvEmployers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEmployers.CausesValidation = false;
            this.dgvEmployers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployers.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvEmployersClmEmployerName} );
            this.dgvEmployers.DataSource = this.bindingEmployers;
            this.dgvEmployers.Location = new System.Drawing.Point( 6, 112 );
            this.dgvEmployers.MultiSelect = false;
            this.dgvEmployers.Name = "dgvEmployers";
            this.dgvEmployers.RowHeadersVisible = false;
            this.dgvEmployers.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvEmployers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmployers.Size = new System.Drawing.Size( 225, 184 );
            this.dgvEmployers.StandardTab = true;
            this.dgvEmployers.TabIndex = 20;
            this.dgvEmployers.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler( this.dgvEmployers_RowValidating );
            // 
            // dgvEmployersClmEmployerName
            // 
            this.dgvEmployersClmEmployerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvEmployersClmEmployerName.DataPropertyName = "EmployerName";
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.dgvEmployersClmEmployerName.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvEmployersClmEmployerName.HeaderText = "EmployerName";
            this.dgvEmployersClmEmployerName.Name = "dgvEmployersClmEmployerName";
            this.dgvEmployersClmEmployerName.ReadOnly = true;
            // 
            // grpDefendants
            // 
            this.grpDefendants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDefendants.Controls.Add( this.dgvDefendants );
            this.grpDefendants.Location = new System.Drawing.Point( 256, 218 );
            this.grpDefendants.Name = "grpDefendants";
            this.grpDefendants.Size = new System.Drawing.Size( 391, 112 );
            this.grpDefendants.TabIndex = 2;
            this.grpDefendants.TabStop = false;
            this.grpDefendants.Text = "Related Defendants";
            // 
            // dgvDefendants
            // 
            this.dgvDefendants.AllowUserToAddRows = false;
            this.dgvDefendants.AllowUserToDeleteRows = false;
            this.dgvDefendants.AllowUserToResizeRows = false;
            this.dgvDefendants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDefendants.AutoGenerateColumns = false;
            this.dgvDefendants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDefendants.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDefendants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefendants.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvDefendantsClmLastName,
            this.dgvDefendantsClmFirstName} );
            this.dgvDefendants.DataSource = this.bindingDefendants;
            this.dgvDefendants.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvDefendants.Location = new System.Drawing.Point( 6, 19 );
            this.dgvDefendants.MultiSelect = false;
            this.dgvDefendants.Name = "dgvDefendants";
            this.dgvDefendants.ReadOnly = true;
            this.dgvDefendants.RowHeadersVisible = false;
            this.dgvDefendants.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.dgvDefendants.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.dgvDefendants.RowTemplate.ReadOnly = true;
            this.dgvDefendants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefendants.Size = new System.Drawing.Size( 379, 80 );
            this.dgvDefendants.TabIndex = 0;
            this.dgvDefendants.TabStop = false;
            this.dgvDefendants.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler( this.dgvDefendants_DataBindingComplete );
            // 
            // dgvDefendantsClmLastName
            // 
            this.dgvDefendantsClmLastName.DataPropertyName = "LastName";
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.dgvDefendantsClmLastName.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDefendantsClmLastName.HeaderText = "LastName";
            this.dgvDefendantsClmLastName.Name = "dgvDefendantsClmLastName";
            this.dgvDefendantsClmLastName.ReadOnly = true;
            // 
            // dgvDefendantsClmFirstName
            // 
            this.dgvDefendantsClmFirstName.DataPropertyName = "FirstName";
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.dgvDefendantsClmFirstName.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDefendantsClmFirstName.HeaderText = "FirstName";
            this.dgvDefendantsClmFirstName.Name = "dgvDefendantsClmFirstName";
            this.dgvDefendantsClmFirstName.ReadOnly = true;
            // 
            // bindingDefendants
            // 
            this.bindingDefendants.AllowNew = false;
            this.bindingDefendants.DataMember = "Defendants";
            this.bindingDefendants.DataSource = this.bindingEmployers;
            // 
            // grpEmployerFilter
            // 
            this.grpEmployerFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grpEmployerFilter.Controls.Add( this.dgvEmployers );
            this.grpEmployerFilter.Controls.Add( this.ucFilter );
            this.grpEmployerFilter.Location = new System.Drawing.Point( 9, 28 );
            this.grpEmployerFilter.Name = "grpEmployerFilter";
            this.grpEmployerFilter.Size = new System.Drawing.Size( 238, 302 );
            this.grpEmployerFilter.TabIndex = 0;
            this.grpEmployerFilter.TabStop = false;
            this.grpEmployerFilter.Text = "EmployerFilter";
            // 
            // ucFilter
            // 
            this.ucFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFilter.Location = new System.Drawing.Point( 6, 19 );
            this.ucFilter.Name = "ucFilter";
            this.ucFilter.Size = new System.Drawing.Size( 225, 87 );
            this.ucFilter.TabIndex = 10;
            // 
            // frmEmployers
            // 
            this.AcceptButton = this.btnClose;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 653, 367 );
            this.Controls.Add( this.grpEmployerFilter );
            this.Controls.Add( this.grpDefendants );
            this.Controls.Add( this.grpEmployer );
            this.Controls.Add( this.mnuEmployer );
            this.Controls.Add( this.btnClose );
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 548, 333 );
            this.Name = "frmEmployers";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Employer Master List";
            this.Load += new System.EventHandler( this.frmEmployers_Load );
            ((System.ComponentModel.ISupportInitialize)(this.mnuEmployer)).EndInit();
            this.mnuEmployer.ResumeLayout( false );
            this.mnuEmployer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployers)).EndInit();
            this.grpEmployer.ResumeLayout( false );
            this.grpEmployer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployers)).EndInit();
            this.grpDefendants.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefendants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingDefendants)).EndInit();
            this.grpEmployerFilter.ResumeLayout( false );
            this.ResumeLayout( false );
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingEmployers;
        private System.Windows.Forms.BindingNavigator mnuEmployer;
        private System.Windows.Forms.ToolStripButton mnuEmployerNew;
        private System.Windows.Forms.ToolStripButton mnuEmployerRemove;
        private System.Windows.Forms.ToolStripButton mnuEmployerSave;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.TextBox txtEmployerName;
        private System.Windows.Forms.TextBox txtStreet1;
        private System.Windows.Forms.TextBox txtStreet2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuEmployerCancel;
        private System.Windows.Forms.GroupBox grpEmployer;
        private System.Windows.Forms.ComboBox cmbStates;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmployersClmEmployerName;
        private System.Windows.Forms.DataGridView dgvEmployers;
        private System.Windows.Forms.ToolStripButton mnuEmployerRefresh;
        private ucFilter ucFilter;
        private System.Windows.Forms.GroupBox grpDefendants;
        private System.Windows.Forms.DataGridView dgvDefendants;
        private System.Windows.Forms.BindingSource bindingDefendants;
        private System.Windows.Forms.GroupBox grpEmployerFilter;
        private System.Windows.Forms.MaskedTextBox mskZip;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDefendantsClmLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDefendantsClmFirstName;
        private System.Windows.Forms.MaskedTextBox mskPhone;
    }
}
