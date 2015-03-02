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
    partial class ucPlans
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
            this.bindingPlans = new System.Windows.Forms.BindingSource(this.components);
            this.grpPlans = new System.Windows.Forms.GroupBox();
            this.splitContainerPlanDetails = new System.Windows.Forms.SplitContainer();
            this.grpPayments = new System.Windows.Forms.GroupBox();
            this.ucPayments = new county.feecollections.ucPayments();
            this.grpFees = new System.Windows.Forms.GroupBox();
            this.ucFees = new county.feecollections.ucFees();
            this.grpCases = new System.Windows.Forms.GroupBox();
            this.ucCases = new county.feecollections.ucCases();
            this.grpPaymentArrangements = new System.Windows.Forms.GroupBox();
            this.ucPaymentArrangements = new county.feecollections.ucPaymentArrangements();
            this.pnlPlan = new System.Windows.Forms.Panel();
            this.mskFiledDate = new System.Windows.Forms.MaskedTextBox();
            this.lblFiledDate = new System.Windows.Forms.Label();
            this.chkNonCAPP = new System.Windows.Forms.CheckBox();
            this.chkCAPP = new System.Windows.Forms.CheckBox();
            this.chkContempt = new System.Windows.Forms.CheckBox();
            this.chkInsurance = new System.Windows.Forms.CheckBox();
            this.chkNoncompliance = new System.Windows.Forms.CheckBox();
            this.chkFiled = new System.Windows.Forms.CheckBox();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblRemainingBalanceValue = new System.Windows.Forms.Label();
            this.lblTotalAmountPaidValue = new System.Windows.Forms.Label();
            this.lblTotalAmountDueValue = new System.Windows.Forms.Label();
            this.lblRemainingBalance = new System.Windows.Forms.Label();
            this.lblTotalAmountPaid = new System.Windows.Forms.Label();
            this.lblTotalAmountDue = new System.Windows.Forms.Label();
            this.cmbPlans = new System.Windows.Forms.ComboBox();
            this.mnuPlan = new System.Windows.Forms.BindingNavigator(this.components);
            this.mnuPlanAdd = new System.Windows.Forms.ToolStripButton();
            this.mnuPlanRemove = new System.Windows.Forms.ToolStripButton();
            this.planBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingPlans)).BeginInit();
            this.grpPlans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPlanDetails)).BeginInit();
            this.splitContainerPlanDetails.Panel1.SuspendLayout();
            this.splitContainerPlanDetails.Panel2.SuspendLayout();
            this.splitContainerPlanDetails.SuspendLayout();
            this.grpPayments.SuspendLayout();
            this.grpFees.SuspendLayout();
            this.grpCases.SuspendLayout();
            this.grpPaymentArrangements.SuspendLayout();
            this.pnlPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuPlan)).BeginInit();
            this.mnuPlan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingPlans
            // 
            this.bindingPlans.DataMember = "Plans";
            // 
            // grpPlans
            // 
            this.grpPlans.Controls.Add(this.splitContainerPlanDetails);
            this.grpPlans.Controls.Add(this.pnlPlan);
            this.grpPlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPlans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlans.Location = new System.Drawing.Point(0, 0);
            this.grpPlans.Name = "grpPlans";
            this.grpPlans.Size = new System.Drawing.Size(797, 497);
            this.grpPlans.TabIndex = 25;
            this.grpPlans.TabStop = false;
            this.grpPlans.Text = "Plans";
            // 
            // splitContainerPlanDetails
            // 
            this.splitContainerPlanDetails.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerPlanDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPlanDetails.Location = new System.Drawing.Point(3, 78);
            this.splitContainerPlanDetails.Name = "splitContainerPlanDetails";
            // 
            // splitContainerPlanDetails.Panel1
            // 
            this.splitContainerPlanDetails.Panel1.Controls.Add(this.grpPayments);
            this.splitContainerPlanDetails.Panel1.Controls.Add(this.grpFees);
            // 
            // splitContainerPlanDetails.Panel2
            // 
            this.splitContainerPlanDetails.Panel2.Controls.Add(this.grpCases);
            this.splitContainerPlanDetails.Panel2.Controls.Add(this.grpPaymentArrangements);
            this.splitContainerPlanDetails.Size = new System.Drawing.Size(791, 416);
            this.splitContainerPlanDetails.SplitterDistance = 317;
            this.splitContainerPlanDetails.TabIndex = 18;
            // 
            // grpPayments
            // 
            this.grpPayments.Controls.Add(this.ucPayments);
            this.grpPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPayments.Location = new System.Drawing.Point(0, 148);
            this.grpPayments.Name = "grpPayments";
            this.grpPayments.Size = new System.Drawing.Size(313, 264);
            this.grpPayments.TabIndex = 11;
            this.grpPayments.TabStop = false;
            this.grpPayments.Text = "Payments";
            // 
            // ucPayments
            // 
            this.ucPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPayments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPayments.Location = new System.Drawing.Point(3, 16);
            this.ucPayments.Name = "ucPayments";
            this.ucPayments.Size = new System.Drawing.Size(307, 245);
            this.ucPayments.TabIndex = 1;
            // 
            // grpFees
            // 
            this.grpFees.Controls.Add(this.ucFees);
            this.grpFees.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpFees.Location = new System.Drawing.Point(0, 0);
            this.grpFees.Name = "grpFees";
            this.grpFees.Size = new System.Drawing.Size(313, 148);
            this.grpFees.TabIndex = 9;
            this.grpFees.TabStop = false;
            this.grpFees.Text = "Fees";
            // 
            // ucFees
            // 
            this.ucFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucFees.Location = new System.Drawing.Point(3, 16);
            this.ucFees.Name = "ucFees";
            this.ucFees.Size = new System.Drawing.Size(307, 129);
            this.ucFees.TabIndex = 7;
            // 
            // grpCases
            // 
            this.grpCases.Controls.Add(this.ucCases);
            this.grpCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCases.Location = new System.Drawing.Point(0, 148);
            this.grpCases.Name = "grpCases";
            this.grpCases.Size = new System.Drawing.Size(466, 264);
            this.grpCases.TabIndex = 18;
            this.grpCases.TabStop = false;
            this.grpCases.Text = "Cases";
            // 
            // ucCases
            // 
            this.ucCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucCases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucCases.Location = new System.Drawing.Point(3, 16);
            this.ucCases.Name = "ucCases";
            this.ucCases.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.ucCases.Size = new System.Drawing.Size(460, 245);
            this.ucCases.TabIndex = 6;
            // 
            // grpPaymentArrangements
            // 
            this.grpPaymentArrangements.Controls.Add(this.ucPaymentArrangements);
            this.grpPaymentArrangements.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPaymentArrangements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPaymentArrangements.Location = new System.Drawing.Point(0, 0);
            this.grpPaymentArrangements.Name = "grpPaymentArrangements";
            this.grpPaymentArrangements.Size = new System.Drawing.Size(466, 148);
            this.grpPaymentArrangements.TabIndex = 17;
            this.grpPaymentArrangements.TabStop = false;
            this.grpPaymentArrangements.Text = "Payment Arrangements";
            // 
            // ucPaymentArrangements
            // 
            this.ucPaymentArrangements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPaymentArrangements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ucPaymentArrangements.Location = new System.Drawing.Point(3, 16);
            this.ucPaymentArrangements.Name = "ucPaymentArrangements";
            this.ucPaymentArrangements.RemainingBalance = 0D;
            this.ucPaymentArrangements.Size = new System.Drawing.Size(460, 129);
            this.ucPaymentArrangements.TabIndex = 14;
            // 
            // pnlPlan
            // 
            this.pnlPlan.Controls.Add(this.mskFiledDate);
            this.pnlPlan.Controls.Add(this.lblFiledDate);
            this.pnlPlan.Controls.Add(this.chkNonCAPP);
            this.pnlPlan.Controls.Add(this.chkCAPP);
            this.pnlPlan.Controls.Add(this.chkContempt);
            this.pnlPlan.Controls.Add(this.chkInsurance);
            this.pnlPlan.Controls.Add(this.chkNoncompliance);
            this.pnlPlan.Controls.Add(this.chkFiled);
            this.pnlPlan.Controls.Add(this.lblLine);
            this.pnlPlan.Controls.Add(this.lblRemainingBalanceValue);
            this.pnlPlan.Controls.Add(this.lblTotalAmountPaidValue);
            this.pnlPlan.Controls.Add(this.lblTotalAmountDueValue);
            this.pnlPlan.Controls.Add(this.lblRemainingBalance);
            this.pnlPlan.Controls.Add(this.lblTotalAmountPaid);
            this.pnlPlan.Controls.Add(this.lblTotalAmountDue);
            this.pnlPlan.Controls.Add(this.cmbPlans);
            this.pnlPlan.Controls.Add(this.mnuPlan);
            this.pnlPlan.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlPlan.Location = new System.Drawing.Point(3, 16);
            this.pnlPlan.Name = "pnlPlan";
            this.pnlPlan.Size = new System.Drawing.Size(791, 62);
            this.pnlPlan.TabIndex = 14;
            // 
            // mskFiledDate
            // 
            this.mskFiledDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mskFiledDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mskFiledDate.Location = new System.Drawing.Point(534, 30);
            this.mskFiledDate.Mask = "##/##/####";
            this.mskFiledDate.Name = "mskFiledDate";
            this.mskFiledDate.Size = new System.Drawing.Size(70, 20);
            this.mskFiledDate.TabIndex = 18;
            this.mskFiledDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblFiledDate
            // 
            this.lblFiledDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFiledDate.AutoSize = true;
            this.lblFiledDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiledDate.Location = new System.Drawing.Point(496, 34);
            this.lblFiledDate.Name = "lblFiledDate";
            this.lblFiledDate.Size = new System.Drawing.Size(32, 13);
            this.lblFiledDate.TabIndex = 19;
            this.lblFiledDate.Text = "Filed:";
            // 
            // chkNonCAPP
            // 
            this.chkNonCAPP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNonCAPP.AutoSize = true;
            this.chkNonCAPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNonCAPP.Location = new System.Drawing.Point(90, 32);
            this.chkNonCAPP.Name = "chkNonCAPP";
            this.chkNonCAPP.Size = new System.Drawing.Size(71, 17);
            this.chkNonCAPP.TabIndex = 2;
            this.chkNonCAPP.Text = "NonCapp";
            this.chkNonCAPP.UseVisualStyleBackColor = true;
            // 
            // chkCAPP
            // 
            this.chkCAPP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkCAPP.AutoSize = true;
            this.chkCAPP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCAPP.Location = new System.Drawing.Point(30, 32);
            this.chkCAPP.Name = "chkCAPP";
            this.chkCAPP.Size = new System.Drawing.Size(54, 17);
            this.chkCAPP.TabIndex = 1;
            this.chkCAPP.Text = "CAPP";
            this.chkCAPP.UseVisualStyleBackColor = true;
            // 
            // chkContempt
            // 
            this.chkContempt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkContempt.AutoSize = true;
            this.chkContempt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkContempt.Location = new System.Drawing.Point(221, 32);
            this.chkContempt.Name = "chkContempt";
            this.chkContempt.Size = new System.Drawing.Size(71, 17);
            this.chkContempt.TabIndex = 6;
            this.chkContempt.Text = "Contempt";
            this.chkContempt.UseVisualStyleBackColor = true;
            // 
            // chkInsurance
            // 
            this.chkInsurance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInsurance.AutoSize = true;
            this.chkInsurance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInsurance.Location = new System.Drawing.Point(298, 32);
            this.chkInsurance.Name = "chkInsurance";
            this.chkInsurance.Size = new System.Drawing.Size(73, 17);
            this.chkInsurance.TabIndex = 5;
            this.chkInsurance.Text = "Insurance";
            this.chkInsurance.UseVisualStyleBackColor = true;
            // 
            // chkNoncompliance
            // 
            this.chkNoncompliance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNoncompliance.AutoSize = true;
            this.chkNoncompliance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNoncompliance.Location = new System.Drawing.Point(377, 32);
            this.chkNoncompliance.Name = "chkNoncompliance";
            this.chkNoncompliance.Size = new System.Drawing.Size(100, 17);
            this.chkNoncompliance.TabIndex = 4;
            this.chkNoncompliance.Text = "Noncompliance";
            this.chkNoncompliance.UseVisualStyleBackColor = true;
            // 
            // chkFiled
            // 
            this.chkFiled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFiled.AutoSize = true;
            this.chkFiled.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFiled.Location = new System.Drawing.Point(167, 32);
            this.chkFiled.Name = "chkFiled";
            this.chkFiled.Size = new System.Drawing.Size(48, 17);
            this.chkFiled.TabIndex = 3;
            this.chkFiled.Text = "Filed";
            this.chkFiled.UseVisualStyleBackColor = true;
            // 
            // lblLine
            // 
            this.lblLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLine.BackColor = System.Drawing.Color.Black;
            this.lblLine.Location = new System.Drawing.Point(611, 43);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(177, 1);
            this.lblLine.TabIndex = 17;
            // 
            // lblRemainingBalanceValue
            // 
            this.lblRemainingBalanceValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemainingBalanceValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingBalanceValue.Location = new System.Drawing.Point(715, 45);
            this.lblRemainingBalanceValue.Name = "lblRemainingBalanceValue";
            this.lblRemainingBalanceValue.Size = new System.Drawing.Size(66, 13);
            this.lblRemainingBalanceValue.TabIndex = 16;
            this.lblRemainingBalanceValue.Text = "0";
            this.lblRemainingBalanceValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmountPaidValue
            // 
            this.lblTotalAmountPaidValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmountPaidValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountPaidValue.Location = new System.Drawing.Point(715, 27);
            this.lblTotalAmountPaidValue.Name = "lblTotalAmountPaidValue";
            this.lblTotalAmountPaidValue.Size = new System.Drawing.Size(66, 13);
            this.lblTotalAmountPaidValue.TabIndex = 15;
            this.lblTotalAmountPaidValue.Text = "0";
            this.lblTotalAmountPaidValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalAmountDueValue
            // 
            this.lblTotalAmountDueValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmountDueValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountDueValue.Location = new System.Drawing.Point(715, 9);
            this.lblTotalAmountDueValue.Name = "lblTotalAmountDueValue";
            this.lblTotalAmountDueValue.Size = new System.Drawing.Size(66, 13);
            this.lblTotalAmountDueValue.TabIndex = 14;
            this.lblTotalAmountDueValue.Text = "0";
            this.lblTotalAmountDueValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblRemainingBalance
            // 
            this.lblRemainingBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRemainingBalance.AutoSize = true;
            this.lblRemainingBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRemainingBalance.Location = new System.Drawing.Point(617, 45);
            this.lblRemainingBalance.Name = "lblRemainingBalance";
            this.lblRemainingBalance.Size = new System.Drawing.Size(102, 13);
            this.lblRemainingBalance.TabIndex = 13;
            this.lblRemainingBalance.Text = "Remaining Balance:";
            // 
            // lblTotalAmountPaid
            // 
            this.lblTotalAmountPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmountPaid.AutoSize = true;
            this.lblTotalAmountPaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountPaid.Location = new System.Drawing.Point(622, 27);
            this.lblTotalAmountPaid.Name = "lblTotalAmountPaid";
            this.lblTotalAmountPaid.Size = new System.Drawing.Size(97, 13);
            this.lblTotalAmountPaid.TabIndex = 12;
            this.lblTotalAmountPaid.Text = "Total Amount Paid:";
            // 
            // lblTotalAmountDue
            // 
            this.lblTotalAmountDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalAmountDue.AutoSize = true;
            this.lblTotalAmountDue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmountDue.Location = new System.Drawing.Point(623, 9);
            this.lblTotalAmountDue.Name = "lblTotalAmountDue";
            this.lblTotalAmountDue.Size = new System.Drawing.Size(96, 13);
            this.lblTotalAmountDue.TabIndex = 11;
            this.lblTotalAmountDue.Text = "Total Amount Due:";
            // 
            // cmbPlans
            // 
            this.cmbPlans.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPlans.DataSource = this.bindingPlans;
            this.cmbPlans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlans.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPlans.FormattingEnabled = true;
            this.cmbPlans.Location = new System.Drawing.Point(137, 1);
            this.cmbPlans.Name = "cmbPlans";
            this.cmbPlans.Size = new System.Drawing.Size(467, 21);
            this.cmbPlans.TabIndex = 0;
            // 
            // mnuPlan
            // 
            this.mnuPlan.AddNewItem = null;
            this.mnuPlan.AutoSize = false;
            this.mnuPlan.CountItem = null;
            this.mnuPlan.DeleteItem = null;
            this.mnuPlan.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuPlan.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuPlan.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlanAdd,
            this.mnuPlanRemove});
            this.mnuPlan.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mnuPlan.Location = new System.Drawing.Point(0, 0);
            this.mnuPlan.MoveFirstItem = null;
            this.mnuPlan.MoveLastItem = null;
            this.mnuPlan.MoveNextItem = null;
            this.mnuPlan.MovePreviousItem = null;
            this.mnuPlan.Name = "mnuPlan";
            this.mnuPlan.PositionItem = null;
            this.mnuPlan.Size = new System.Drawing.Size(139, 22);
            this.mnuPlan.TabIndex = 7;
            this.mnuPlan.Text = "Defendant Menu";
            // 
            // mnuPlanAdd
            // 
            this.mnuPlanAdd.Image = global::county.feecollections.Properties.Resources.sub_add;
            this.mnuPlanAdd.Name = "mnuPlanAdd";
            this.mnuPlanAdd.Size = new System.Drawing.Size(58, 20);
            this.mnuPlanAdd.Text = "&Add...";
            this.mnuPlanAdd.Click += new System.EventHandler(this.mnuPlan_Click);
            // 
            // mnuPlanRemove
            // 
            this.mnuPlanRemove.Image = global::county.feecollections.Properties.Resources.sub_remove;
            this.mnuPlanRemove.Name = "mnuPlanRemove";
            this.mnuPlanRemove.RightToLeftAutoMirrorImage = true;
            this.mnuPlanRemove.Size = new System.Drawing.Size(70, 20);
            this.mnuPlanRemove.Text = "&Remove";
            this.mnuPlanRemove.Click += new System.EventHandler(this.mnuPlan_Click);
            // 
            // planBindingSource
            // 
            this.planBindingSource.DataSource = typeof(county.feecollections.Plan);
            // 
            // ucPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.grpPlans);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(683, 420);
            this.Name = "ucPlans";
            this.Size = new System.Drawing.Size(797, 497);
            ((System.ComponentModel.ISupportInitialize)(this.bindingPlans)).EndInit();
            this.grpPlans.ResumeLayout(false);
            this.splitContainerPlanDetails.Panel1.ResumeLayout(false);
            this.splitContainerPlanDetails.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerPlanDetails)).EndInit();
            this.splitContainerPlanDetails.ResumeLayout(false);
            this.grpPayments.ResumeLayout(false);
            this.grpFees.ResumeLayout(false);
            this.grpCases.ResumeLayout(false);
            this.grpPaymentArrangements.ResumeLayout(false);
            this.pnlPlan.ResumeLayout(false);
            this.pnlPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuPlan)).EndInit();
            this.mnuPlan.ResumeLayout(false);
            this.mnuPlan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingPlans;
        private System.Windows.Forms.GroupBox grpPlans;
        private System.Windows.Forms.SplitContainer splitContainerPlanDetails;
        private System.Windows.Forms.GroupBox grpPayments;
        private ucPayments ucPayments;
        private System.Windows.Forms.GroupBox grpFees;
        private ucFees ucFees;
        private System.Windows.Forms.GroupBox grpCases;
        private ucCases ucCases;
        private System.Windows.Forms.GroupBox grpPaymentArrangements;
        private ucPaymentArrangements ucPaymentArrangements;
        private System.Windows.Forms.Panel pnlPlan;
        private System.Windows.Forms.ComboBox cmbPlans;
        private System.Windows.Forms.BindingNavigator mnuPlan;
        private System.Windows.Forms.ToolStripButton mnuPlanAdd;
        private System.Windows.Forms.ToolStripButton mnuPlanRemove;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.Label lblRemainingBalanceValue;
        private System.Windows.Forms.Label lblTotalAmountPaidValue;
        private System.Windows.Forms.Label lblTotalAmountDueValue;
        private System.Windows.Forms.Label lblRemainingBalance;
        private System.Windows.Forms.Label lblTotalAmountPaid;
        private System.Windows.Forms.Label lblTotalAmountDue;
        private System.Windows.Forms.CheckBox chkContempt;
        private System.Windows.Forms.CheckBox chkInsurance;
        private System.Windows.Forms.CheckBox chkNoncompliance;
        private System.Windows.Forms.CheckBox chkFiled;
        private System.Windows.Forms.CheckBox chkNonCAPP;
        private System.Windows.Forms.CheckBox chkCAPP;
        private System.Windows.Forms.BindingSource planBindingSource;
        private System.Windows.Forms.MaskedTextBox mskFiledDate;
        private System.Windows.Forms.Label lblFiledDate;
    }
}
