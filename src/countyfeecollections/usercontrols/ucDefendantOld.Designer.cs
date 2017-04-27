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
    partial class ucDefendantOld
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.GroupBox grpDefendnatInfo;
            System.Windows.Forms.Label lblCellPhone;
            System.Windows.Forms.Label lblHomePhone;
            System.Windows.Forms.Label lblCityStateZip;
            System.Windows.Forms.Label lblStreet2;
            System.Windows.Forms.Label lblStreet1;
            System.Windows.Forms.Label lblFirstName;
            System.Windows.Forms.Label lblSSN;
            System.Windows.Forms.Label lblLastName;
            System.Windows.Forms.Label lblMiddleName;
            System.Windows.Forms.Label lblDriversLicense;
            System.Windows.Forms.Label lblAKA;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainerDefendantDetail = new System.Windows.Forms.SplitContainer();
            this.lblAddress = new System.Windows.Forms.Label();
            this.mskPhoneMobile = new System.Windows.Forms.MaskedTextBox();
            this.mskPhoneHome = new System.Windows.Forms.MaskedTextBox();
            this.mskZip = new System.Windows.Forms.MaskedTextBox();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.cmbStates = new System.Windows.Forms.ComboBox();
            this.txtStreet1 = new System.Windows.Forms.TextBox();
            this.txtStreet2 = new System.Windows.Forms.TextBox();
            this.mskBirthDate = new System.Windows.Forms.MaskedTextBox();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.txtDriversLicense = new System.Windows.Forms.TextBox();
            this.txtAka = new System.Windows.Forms.TextBox();
            this.mskSSN = new System.Windows.Forms.MaskedTextBox();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lblBirthdate = new System.Windows.Forms.Label();
            this.dgvPlanSummary = new System.Windows.Forms.DataGridView();
            this.planname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CAPP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NonCAPP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Filed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Contempt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Insurance = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Noncompliance = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.fileddate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingPlans = new System.Windows.Forms.BindingSource(this.components);
            this.mskBarredUntil = new System.Windows.Forms.MaskedTextBox();
            this.lblBarredUntil = new System.Windows.Forms.Label();
            this.lblEmployers = new System.Windows.Forms.Label();
            this.ucEmployer = new county.feecollections.ucEmployer();
            this.txtProbationOfficer = new System.Windows.Forms.TextBox();
            this.chkHasProbationOfficer = new System.Windows.Forms.CheckBox();
            this.lblDaysInJail = new System.Windows.Forms.Label();
            this.lblJudgmentDate = new System.Windows.Forms.Label();
            this.lblBookingNumber = new System.Windows.Forms.Label();
            this.tbDaysInJail = new System.Windows.Forms.MaskedTextBox();
            this.tbBookingNumber = new System.Windows.Forms.TextBox();
            this.tbJudgmentDate = new System.Windows.Forms.MaskedTextBox();
            grpDefendnatInfo = new System.Windows.Forms.GroupBox();
            lblCellPhone = new System.Windows.Forms.Label();
            lblHomePhone = new System.Windows.Forms.Label();
            lblCityStateZip = new System.Windows.Forms.Label();
            lblStreet2 = new System.Windows.Forms.Label();
            lblStreet1 = new System.Windows.Forms.Label();
            lblFirstName = new System.Windows.Forms.Label();
            lblSSN = new System.Windows.Forms.Label();
            lblLastName = new System.Windows.Forms.Label();
            lblMiddleName = new System.Windows.Forms.Label();
            lblDriversLicense = new System.Windows.Forms.Label();
            lblAKA = new System.Windows.Forms.Label();
            grpDefendnatInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDefendantDetail)).BeginInit();
            this.splitContainerDefendantDetail.Panel1.SuspendLayout();
            this.splitContainerDefendantDetail.Panel2.SuspendLayout();
            this.splitContainerDefendantDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPlans)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDefendnatInfo
            // 
            grpDefendnatInfo.Controls.Add(this.splitContainerDefendantDetail);
            grpDefendnatInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            grpDefendnatInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            grpDefendnatInfo.Location = new System.Drawing.Point(0, 0);
            grpDefendnatInfo.MinimumSize = new System.Drawing.Size(567, 375);
            grpDefendnatInfo.Name = "grpDefendnatInfo";
            grpDefendnatInfo.Size = new System.Drawing.Size(723, 375);
            grpDefendnatInfo.TabIndex = 10;
            grpDefendnatInfo.TabStop = false;
            grpDefendnatInfo.Text = "Defendant Information";
            // 
            // splitContainerDefendantDetail
            // 
            this.splitContainerDefendantDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerDefendantDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDefendantDetail.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerDefendantDetail.Location = new System.Drawing.Point(3, 16);
            this.splitContainerDefendantDetail.MinimumSize = new System.Drawing.Size(561, 356);
            this.splitContainerDefendantDetail.Name = "splitContainerDefendantDetail";
            // 
            // splitContainerDefendantDetail.Panel1
            // 
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.lblAddress);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.mskPhoneMobile);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.mskPhoneHome);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblCellPhone);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblHomePhone);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.mskZip);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.txtCity);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.cmbStates);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.txtStreet1);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.txtStreet2);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblCityStateZip);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblStreet2);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblStreet1);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.mskBirthDate);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.txtLastName);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.txtDriversLicense);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.txtAka);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.mskSSN);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.txtFirstName);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.txtMiddleName);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(this.lblBirthdate);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblFirstName);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblSSN);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblLastName);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblMiddleName);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblDriversLicense);
            this.splitContainerDefendantDetail.Panel1.Controls.Add(lblAKA);
            this.splitContainerDefendantDetail.Panel1MinSize = 280;
            // 
            // splitContainerDefendantDetail.Panel2
            // 
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.tbJudgmentDate);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.tbBookingNumber);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.tbDaysInJail);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.lblBookingNumber);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.lblJudgmentDate);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.lblDaysInJail);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.dgvPlanSummary);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.mskBarredUntil);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.lblBarredUntil);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.lblEmployers);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.ucEmployer);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.txtProbationOfficer);
            this.splitContainerDefendantDetail.Panel2.Controls.Add(this.chkHasProbationOfficer);
            this.splitContainerDefendantDetail.Size = new System.Drawing.Size(717, 356);
            this.splitContainerDefendantDetail.SplitterDistance = 280;
            this.splitContainerDefendantDetail.SplitterWidth = 1;
            this.splitContainerDefendantDetail.TabIndex = 0;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(11, 221);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(48, 13);
            this.lblAddress.TabIndex = 51;
            this.lblAddress.Text = "Address:";
            // 
            // mskPhoneMobile
            // 
            this.mskPhoneMobile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskPhoneMobile.Location = new System.Drawing.Point(190, 320);
            this.mskPhoneMobile.Mask = "(999) 000-0000";
            this.mskPhoneMobile.Name = "mskPhoneMobile";
            this.mskPhoneMobile.Size = new System.Drawing.Size(80, 20);
            this.mskPhoneMobile.TabIndex = 13;
            this.mskPhoneMobile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // mskPhoneHome
            // 
            this.mskPhoneHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskPhoneHome.Location = new System.Drawing.Point(86, 320);
            this.mskPhoneHome.Mask = "(999) 000-0000";
            this.mskPhoneHome.Name = "mskPhoneHome";
            this.mskPhoneHome.Size = new System.Drawing.Size(80, 20);
            this.mskPhoneHome.TabIndex = 12;
            this.mskPhoneHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblCellPhone
            // 
            lblCellPhone.AutoSize = true;
            lblCellPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblCellPhone.Location = new System.Drawing.Point(193, 308);
            lblCellPhone.Name = "lblCellPhone";
            lblCellPhone.Size = new System.Drawing.Size(75, 13);
            lblCellPhone.TabIndex = 50;
            lblCellPhone.Text = "Mobile Phone:";
            lblCellPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblHomePhone
            // 
            lblHomePhone.AutoSize = true;
            lblHomePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblHomePhone.Location = new System.Drawing.Point(90, 308);
            lblHomePhone.Name = "lblHomePhone";
            lblHomePhone.Size = new System.Drawing.Size(72, 13);
            lblHomePhone.TabIndex = 49;
            lblHomePhone.Text = "Home Phone:";
            lblHomePhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mskZip
            // 
            this.mskZip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mskZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskZip.Location = new System.Drawing.Point(204, 283);
            this.mskZip.Mask = "00000-9999";
            this.mskZip.Name = "mskZip";
            this.mskZip.Size = new System.Drawing.Size(67, 20);
            this.mskZip.TabIndex = 11;
            this.mskZip.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCity
            // 
            this.txtCity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(84, 284);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(73, 20);
            this.txtCity.TabIndex = 9;
            this.txtCity.Text = "Council Bluffs";
            // 
            // cmbStates
            // 
            this.cmbStates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStates.FormattingEnabled = true;
            this.cmbStates.Location = new System.Drawing.Point(160, 283);
            this.cmbStates.Name = "cmbStates";
            this.cmbStates.Size = new System.Drawing.Size(42, 21);
            this.cmbStates.TabIndex = 10;
            // 
            // txtStreet1
            // 
            this.txtStreet1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet1.Location = new System.Drawing.Point(84, 237);
            this.txtStreet1.Name = "txtStreet1";
            this.txtStreet1.Size = new System.Drawing.Size(187, 20);
            this.txtStreet1.TabIndex = 7;
            // 
            // txtStreet2
            // 
            this.txtStreet2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStreet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStreet2.Location = new System.Drawing.Point(84, 261);
            this.txtStreet2.Name = "txtStreet2";
            this.txtStreet2.Size = new System.Drawing.Size(187, 20);
            this.txtStreet2.TabIndex = 8;
            // 
            // lblCityStateZip
            // 
            lblCityStateZip.AutoSize = true;
            lblCityStateZip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblCityStateZip.Location = new System.Drawing.Point(11, 288);
            lblCityStateZip.Name = "lblCityStateZip";
            lblCityStateZip.Size = new System.Drawing.Size(76, 13);
            lblCityStateZip.TabIndex = 47;
            lblCityStateZip.Text = "City, State Zip:";
            // 
            // lblStreet2
            // 
            lblStreet2.AutoSize = true;
            lblStreet2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblStreet2.Location = new System.Drawing.Point(43, 265);
            lblStreet2.Name = "lblStreet2";
            lblStreet2.Size = new System.Drawing.Size(44, 13);
            lblStreet2.TabIndex = 48;
            lblStreet2.Text = "Street2:";
            // 
            // lblStreet1
            // 
            lblStreet1.AutoSize = true;
            lblStreet1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblStreet1.Location = new System.Drawing.Point(43, 241);
            lblStreet1.Name = "lblStreet1";
            lblStreet1.Size = new System.Drawing.Size(44, 13);
            lblStreet1.TabIndex = 46;
            lblStreet1.Text = "Street1:";
            // 
            // mskBirthDate
            // 
            this.mskBirthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskBirthDate.Location = new System.Drawing.Point(84, 136);
            this.mskBirthDate.Mask = "00/00/0000";
            this.mskBirthDate.Name = "mskBirthDate";
            this.mskBirthDate.Size = new System.Drawing.Size(70, 20);
            this.mskBirthDate.TabIndex = 5;
            this.mskBirthDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskBirthDate.ValidatingType = typeof(System.DateTime);
            // 
            // txtLastName
            // 
            this.txtLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(84, 58);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(187, 20);
            this.txtLastName.TabIndex = 2;
            // 
            // txtDriversLicense
            // 
            this.txtDriversLicense.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDriversLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDriversLicense.Location = new System.Drawing.Point(84, 162);
            this.txtDriversLicense.Name = "txtDriversLicense";
            this.txtDriversLicense.Size = new System.Drawing.Size(187, 20);
            this.txtDriversLicense.TabIndex = 6;
            // 
            // txtAka
            // 
            this.txtAka.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAka.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAka.Location = new System.Drawing.Point(84, 84);
            this.txtAka.Name = "txtAka";
            this.txtAka.Size = new System.Drawing.Size(187, 20);
            this.txtAka.TabIndex = 3;
            // 
            // mskSSN
            // 
            this.mskSSN.AllowPromptAsInput = false;
            this.mskSSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskSSN.Location = new System.Drawing.Point(84, 110);
            this.mskSSN.Mask = "000-00-0000";
            this.mskSSN.Name = "mskSSN";
            this.mskSSN.Size = new System.Drawing.Size(70, 20);
            this.mskSSN.TabIndex = 4;
            this.mskSSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(84, 6);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(187, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMiddleName.Location = new System.Drawing.Point(84, 32);
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(187, 20);
            this.txtMiddleName.TabIndex = 1;
            // 
            // lblBirthdate
            // 
            this.lblBirthdate.AutoSize = true;
            this.lblBirthdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthdate.Location = new System.Drawing.Point(30, 140);
            this.lblBirthdate.Name = "lblBirthdate";
            this.lblBirthdate.Size = new System.Drawing.Size(57, 13);
            this.lblBirthdate.TabIndex = 37;
            this.lblBirthdate.Text = "Birth Date:";
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblFirstName.Location = new System.Drawing.Point(27, 10);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new System.Drawing.Size(60, 13);
            lblFirstName.TabIndex = 29;
            lblFirstName.Text = "First Name:";
            // 
            // lblSSN
            // 
            lblSSN.AutoSize = true;
            lblSSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblSSN.Location = new System.Drawing.Point(55, 114);
            lblSSN.Name = "lblSSN";
            lblSSN.Size = new System.Drawing.Size(32, 13);
            lblSSN.TabIndex = 35;
            lblSSN.Text = "SSN:";
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblLastName.Location = new System.Drawing.Point(26, 62);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new System.Drawing.Size(61, 13);
            lblLastName.TabIndex = 33;
            lblLastName.Text = "Last Name:";
            // 
            // lblMiddleName
            // 
            lblMiddleName.AutoSize = true;
            lblMiddleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblMiddleName.Location = new System.Drawing.Point(15, 36);
            lblMiddleName.Name = "lblMiddleName";
            lblMiddleName.Size = new System.Drawing.Size(72, 13);
            lblMiddleName.TabIndex = 34;
            lblMiddleName.Text = "Middle Name:";
            // 
            // lblDriversLicense
            // 
            lblDriversLicense.AutoSize = true;
            lblDriversLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblDriversLicense.Location = new System.Drawing.Point(4, 165);
            lblDriversLicense.Name = "lblDriversLicense";
            lblDriversLicense.Size = new System.Drawing.Size(83, 13);
            lblDriversLicense.TabIndex = 38;
            lblDriversLicense.Text = "Drivers License:";
            // 
            // lblAKA
            // 
            lblAKA.AutoSize = true;
            lblAKA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lblAKA.Location = new System.Drawing.Point(56, 88);
            lblAKA.Name = "lblAKA";
            lblAKA.Size = new System.Drawing.Size(31, 13);
            lblAKA.TabIndex = 36;
            lblAKA.Text = "AKA:";
            // 
            // dgvPlanSummary
            // 
            this.dgvPlanSummary.AllowUserToAddRows = false;
            this.dgvPlanSummary.AllowUserToDeleteRows = false;
            this.dgvPlanSummary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPlanSummary.AutoGenerateColumns = false;
            this.dgvPlanSummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPlanSummary.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlanSummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.planname,
            this.CAPP,
            this.NonCAPP,
            this.Filed,
            this.Contempt,
            this.Insurance,
            this.Noncompliance,
            this.fileddate});
            this.dgvPlanSummary.DataSource = this.bindingPlans;
            this.dgvPlanSummary.Location = new System.Drawing.Point(0, 0);
            this.dgvPlanSummary.MultiSelect = false;
            this.dgvPlanSummary.Name = "dgvPlanSummary";
            this.dgvPlanSummary.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanSummary.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPlanSummary.RowHeadersVisible = false;
            this.dgvPlanSummary.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvPlanSummary.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.Window;
            this.dgvPlanSummary.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            this.dgvPlanSummary.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanSummary.Size = new System.Drawing.Size(435, 144);
            this.dgvPlanSummary.TabIndex = 15;
            // 
            // planname
            // 
            this.planname.DataPropertyName = "PlanName";
            this.planname.FillWeight = 163.7316F;
            this.planname.HeaderText = "Plan";
            this.planname.Name = "planname";
            this.planname.ReadOnly = true;
            // 
            // CAPP
            // 
            this.CAPP.DataPropertyName = "CAPP";
            this.CAPP.FillWeight = 60.9137F;
            this.CAPP.HeaderText = "CAPP";
            this.CAPP.Name = "CAPP";
            this.CAPP.ReadOnly = true;
            this.CAPP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // NonCAPP
            // 
            this.NonCAPP.DataPropertyName = "NonCAPP";
            this.NonCAPP.FillWeight = 84.02335F;
            this.NonCAPP.HeaderText = "NonCAPP";
            this.NonCAPP.Name = "NonCAPP";
            this.NonCAPP.ReadOnly = true;
            this.NonCAPP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Filed
            // 
            this.Filed.DataPropertyName = "IsFiled";
            this.Filed.FillWeight = 66.57639F;
            this.Filed.HeaderText = "Filed";
            this.Filed.Name = "Filed";
            this.Filed.ReadOnly = true;
            this.Filed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Contempt
            // 
            this.Contempt.DataPropertyName = "InContempt";
            this.Contempt.FillWeight = 95.08791F;
            this.Contempt.HeaderText = "Contempt";
            this.Contempt.Name = "Contempt";
            this.Contempt.ReadOnly = true;
            this.Contempt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Contempt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Insurance
            // 
            this.Insurance.DataPropertyName = "HasInsurance";
            this.Insurance.FillWeight = 97.94103F;
            this.Insurance.HeaderText = "Insurance";
            this.Insurance.Name = "Insurance";
            this.Insurance.ReadOnly = true;
            this.Insurance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Noncompliance
            // 
            this.Noncompliance.DataPropertyName = "NonComplianceNotice";
            this.Noncompliance.FillWeight = 136.7069F;
            this.Noncompliance.HeaderText = "Noncompliance";
            this.Noncompliance.Name = "Noncompliance";
            this.Noncompliance.ReadOnly = true;
            this.Noncompliance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // fileddate
            // 
            this.fileddate.DataPropertyName = "FiledDate";
            this.fileddate.FillWeight = 95.01917F;
            this.fileddate.HeaderText = "filed";
            this.fileddate.Name = "fileddate";
            this.fileddate.ReadOnly = true;
            // 
            // bindingPlans
            // 
            this.bindingPlans.AllowNew = false;
            this.bindingPlans.DataMember = "Plans";
            // 
            // mskBarredUntil
            // 
            this.mskBarredUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskBarredUntil.Location = new System.Drawing.Point(62, 147);
            this.mskBarredUntil.Mask = "00/00/0000";
            this.mskBarredUntil.Name = "mskBarredUntil";
            this.mskBarredUntil.Size = new System.Drawing.Size(70, 20);
            this.mskBarredUntil.TabIndex = 10;
            this.mskBarredUntil.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.mskBarredUntil.ValidatingType = typeof(System.DateTime);
            // 
            // lblBarredUntil
            // 
            this.lblBarredUntil.AutoSize = true;
            this.lblBarredUntil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBarredUntil.Location = new System.Drawing.Point(3, 151);
            this.lblBarredUntil.Name = "lblBarredUntil";
            this.lblBarredUntil.Size = new System.Drawing.Size(65, 13);
            this.lblBarredUntil.TabIndex = 14;
            this.lblBarredUntil.Text = "Barred Until:";
            // 
            // lblEmployers
            // 
            this.lblEmployers.AutoSize = true;
            this.lblEmployers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployers.Location = new System.Drawing.Point(13, 221);
            this.lblEmployers.Name = "lblEmployers";
            this.lblEmployers.Size = new System.Drawing.Size(58, 13);
            this.lblEmployers.TabIndex = 11;
            this.lblEmployers.Text = "Employers:";
            // 
            // ucEmployer
            // 
            this.ucEmployer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucEmployer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucEmployer.Location = new System.Drawing.Point(0, 237);
            this.ucEmployer.Name = "ucEmployer";
            this.ucEmployer.Size = new System.Drawing.Size(435, 112);
            this.ucEmployer.TabIndex = 12;
            // 
            // txtProbationOfficer
            // 
            this.txtProbationOfficer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProbationOfficer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProbationOfficer.Location = new System.Drawing.Point(109, 189);
            this.txtProbationOfficer.Name = "txtProbationOfficer";
            this.txtProbationOfficer.Size = new System.Drawing.Size(326, 20);
            this.txtProbationOfficer.TabIndex = 7;
            // 
            // chkHasProbationOfficer
            // 
            this.chkHasProbationOfficer.AutoSize = true;
            this.chkHasProbationOfficer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHasProbationOfficer.Location = new System.Drawing.Point(7, 191);
            this.chkHasProbationOfficer.Name = "chkHasProbationOfficer";
            this.chkHasProbationOfficer.Size = new System.Drawing.Size(108, 17);
            this.chkHasProbationOfficer.TabIndex = 6;
            this.chkHasProbationOfficer.Text = "Probation Officer:";
            this.chkHasProbationOfficer.UseVisualStyleBackColor = true;
            // 
            // lblDaysInJail
            // 
            this.lblDaysInJail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDaysInJail.AutoSize = true;
            this.lblDaysInJail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblDaysInJail.Location = new System.Drawing.Point(146, 151);
            this.lblDaysInJail.Name = "lblDaysInJail";
            this.lblDaysInJail.Size = new System.Drawing.Size(70, 13);
            this.lblDaysInJail.TabIndex = 16;
            this.lblDaysInJail.Text = "# Days in Jail";
            // 
            // lblJudgmentDate
            // 
            this.lblJudgmentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblJudgmentDate.AutoSize = true;
            this.lblJudgmentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblJudgmentDate.Location = new System.Drawing.Point(146, 171);
            this.lblJudgmentDate.Name = "lblJudgmentDate";
            this.lblJudgmentDate.Size = new System.Drawing.Size(79, 13);
            this.lblJudgmentDate.TabIndex = 17;
            this.lblJudgmentDate.Text = "Judgment Date";
            // 
            // lblBookingNumber
            // 
            this.lblBookingNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBookingNumber.AutoSize = true;
            this.lblBookingNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblBookingNumber.Location = new System.Drawing.Point(273, 150);
            this.lblBookingNumber.Name = "lblBookingNumber";
            this.lblBookingNumber.Size = new System.Drawing.Size(56, 13);
            this.lblBookingNumber.TabIndex = 18;
            this.lblBookingNumber.Text = "Booking #";
            // 
            // tbDaysInJail
            // 
            this.tbDaysInJail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDaysInJail.Location = new System.Drawing.Point(222, 147);
            this.tbDaysInJail.Mask = "#####";
            this.tbDaysInJail.Name = "tbDaysInJail";
            this.tbDaysInJail.Size = new System.Drawing.Size(45, 20);
            this.tbDaysInJail.TabIndex = 22;
            // 
            // tbBookingNumber
            // 
            this.tbBookingNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbBookingNumber.Location = new System.Drawing.Point(330, 147);
            this.tbBookingNumber.MaxLength = 10;
            this.tbBookingNumber.Name = "tbBookingNumber";
            this.tbBookingNumber.Size = new System.Drawing.Size(99, 20);
            this.tbBookingNumber.TabIndex = 23;
            // 
            // tbJudgmentDate
            // 
            this.tbJudgmentDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbJudgmentDate.Location = new System.Drawing.Point(222, 168);
            this.tbJudgmentDate.Mask = "00/00/0000";
            this.tbJudgmentDate.Name = "tbJudgmentDate";
            this.tbJudgmentDate.Size = new System.Drawing.Size(80, 20);
            this.tbJudgmentDate.TabIndex = 24;
            // 
            // ucDefendantOld
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(grpDefendnatInfo);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(567, 375);
            this.Name = "ucDefendantOld";
            this.Size = new System.Drawing.Size(723, 375);
            this.GotFocus += new System.EventHandler(this.ucDefendantOld_GotFocus);
            grpDefendnatInfo.ResumeLayout(false);
            this.splitContainerDefendantDetail.Panel1.ResumeLayout(false);
            this.splitContainerDefendantDetail.Panel1.PerformLayout();
            this.splitContainerDefendantDetail.Panel2.ResumeLayout(false);
            this.splitContainerDefendantDetail.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDefendantDetail)).EndInit();
            this.splitContainerDefendantDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPlans)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.SplitContainer splitContainerDefendantDetail;
        private System.Windows.Forms.MaskedTextBox mskBirthDate;
        public System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.TextBox txtDriversLicense;
        private System.Windows.Forms.TextBox txtAka;
        private System.Windows.Forms.MaskedTextBox mskSSN;
        public System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.TextBox txtMiddleName;
        private System.Windows.Forms.Label lblBirthdate;
        private System.Windows.Forms.MaskedTextBox mskBarredUntil;
        private System.Windows.Forms.TextBox txtProbationOfficer;
        private System.Windows.Forms.CheckBox chkHasProbationOfficer;
        private System.Windows.Forms.MaskedTextBox mskPhoneMobile;
        private System.Windows.Forms.MaskedTextBox mskPhoneHome;
        private System.Windows.Forms.MaskedTextBox mskZip;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.ComboBox cmbStates;
        private System.Windows.Forms.TextBox txtStreet1;
        private System.Windows.Forms.TextBox txtStreet2;
        private System.Windows.Forms.Label lblEmployers;
        private ucEmployer ucEmployer;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblBarredUntil;
        private System.Windows.Forms.DataGridView dgvPlanSummary;
        private System.Windows.Forms.BindingSource bindingPlans;
        private System.Windows.Forms.DataGridViewTextBoxColumn planname;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CAPP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NonCAPP;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Filed;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Contempt;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Insurance;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Noncompliance;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileddate;
        private System.Windows.Forms.TextBox tbBookingNumber;
        private System.Windows.Forms.MaskedTextBox tbDaysInJail;
        private System.Windows.Forms.Label lblBookingNumber;
        private System.Windows.Forms.Label lblJudgmentDate;
        private System.Windows.Forms.Label lblDaysInJail;
        private System.Windows.Forms.MaskedTextBox tbJudgmentDate;
    }
}
