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
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainLists = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainListsEmployers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainListsFeeTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainListsPaymentArrangementTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainListsRestrictedCasePrefixes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainTools = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainToolsOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainToolsOptionsPrintDelinquentLetters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainReports = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainReportsSSRS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainReportsMailMerge = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStatus = new System.Windows.Forms.StatusStrip();
            this.mnuStatusWindowsUserName = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuStatusVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.pnlScroll = new System.Windows.Forms.Panel();
            this.splitContainerDefendant = new System.Windows.Forms.SplitContainer();
            this.ucDefendant = new county.feecollections.ucDefendant();
            this.ucPlans = new county.feecollections.ucPlans();
            this.lblTitleBar = new System.Windows.Forms.Label();
            this.mnuDefendant = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingDefendants = new System.Windows.Forms.BindingSource(this.components);
            this.mnuDefendantNew = new System.Windows.Forms.ToolStripButton();
            this.mnuDefendantSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDefendantRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuDefendantRefresh = new System.Windows.Forms.ToolStripButton();
            this.mnuDefendantSave = new System.Windows.Forms.ToolStripButton();
            this.mnuDefendantCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDefendantNotes = new System.Windows.Forms.ToolStripButton();
            this.mnuDefendantMailMerge = new System.Windows.Forms.ToolStripButton();
            this.mnuDefendantPayment = new System.Windows.Forms.ToolStripButton();
            this.mnuDefendantArchive = new System.Windows.Forms.ToolStripButton();
            this.dgvDefendants = new System.Windows.Forms.DataGridView();
            this.dgvDefendantsClmLastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDefendantsClmFirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucFilter = new county.feecollections.ucFilter();
            this.mnuMain.SuspendLayout();
            this.mnuStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.pnlScroll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDefendant)).BeginInit();
            this.splitContainerDefendant.Panel1.SuspendLayout();
            this.splitContainerDefendant.Panel2.SuspendLayout();
            this.splitContainerDefendant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mnuDefendant)).BeginInit();
            this.mnuDefendant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingDefendants)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefendants)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainFile,
            this.mnuMainLists,
            this.mnuMainTools,
            this.mnuMainReports});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1008, 24);
            this.mnuMain.TabIndex = 0;
            // 
            // mnuMainFile
            // 
            this.mnuMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainFileExit});
            this.mnuMainFile.Name = "mnuMainFile";
            this.mnuMainFile.Size = new System.Drawing.Size(37, 20);
            this.mnuMainFile.Text = "&File";
            // 
            // mnuMainFileExit
            // 
            this.mnuMainFileExit.Name = "mnuMainFileExit";
            this.mnuMainFileExit.Size = new System.Drawing.Size(92, 22);
            this.mnuMainFileExit.Text = "E&xit";
            this.mnuMainFileExit.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuMainLists
            // 
            this.mnuMainLists.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainListsEmployers,
            this.mnuMainListsFeeTypes,
            this.mnuMainListsPaymentArrangementTypes,
            this.mnuMainListsRestrictedCasePrefixes});
            this.mnuMainLists.Name = "mnuMainLists";
            this.mnuMainLists.Size = new System.Drawing.Size(42, 20);
            this.mnuMainLists.Text = "&Lists";
            // 
            // mnuMainListsEmployers
            // 
            this.mnuMainListsEmployers.Name = "mnuMainListsEmployers";
            this.mnuMainListsEmployers.Size = new System.Drawing.Size(228, 22);
            this.mnuMainListsEmployers.Text = "&Employers";
            this.mnuMainListsEmployers.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuMainListsFeeTypes
            // 
            this.mnuMainListsFeeTypes.Name = "mnuMainListsFeeTypes";
            this.mnuMainListsFeeTypes.Size = new System.Drawing.Size(228, 22);
            this.mnuMainListsFeeTypes.Text = "Fee Types";
            this.mnuMainListsFeeTypes.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuMainListsPaymentArrangementTypes
            // 
            this.mnuMainListsPaymentArrangementTypes.Name = "mnuMainListsPaymentArrangementTypes";
            this.mnuMainListsPaymentArrangementTypes.Size = new System.Drawing.Size(228, 22);
            this.mnuMainListsPaymentArrangementTypes.Text = "Payment Arrangement Types";
            this.mnuMainListsPaymentArrangementTypes.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuMainListsRestrictedCasePrefixes
            // 
            this.mnuMainListsRestrictedCasePrefixes.Name = "mnuMainListsRestrictedCasePrefixes";
            this.mnuMainListsRestrictedCasePrefixes.Size = new System.Drawing.Size(228, 22);
            this.mnuMainListsRestrictedCasePrefixes.Text = "Restricted Case Prefixes";
            this.mnuMainListsRestrictedCasePrefixes.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuMainTools
            // 
            this.mnuMainTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainToolsOptions,
            this.mnuMainToolsOptionsPrintDelinquentLetters});
            this.mnuMainTools.Name = "mnuMainTools";
            this.mnuMainTools.Size = new System.Drawing.Size(48, 20);
            this.mnuMainTools.Text = "&Tools";
            // 
            // mnuMainToolsOptions
            // 
            this.mnuMainToolsOptions.Name = "mnuMainToolsOptions";
            this.mnuMainToolsOptions.Size = new System.Drawing.Size(198, 22);
            this.mnuMainToolsOptions.Text = "&Options";
            this.mnuMainToolsOptions.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuMainToolsOptionsPrintDelinquentLetters
            // 
            this.mnuMainToolsOptionsPrintDelinquentLetters.Name = "mnuMainToolsOptionsPrintDelinquentLetters";
            this.mnuMainToolsOptionsPrintDelinquentLetters.Size = new System.Drawing.Size(198, 22);
            this.mnuMainToolsOptionsPrintDelinquentLetters.Text = "&Print Delinquent Letters";
            this.mnuMainToolsOptionsPrintDelinquentLetters.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuMainReports
            // 
            this.mnuMainReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainReportsSSRS,
            this.mnuMainReportsMailMerge});
            this.mnuMainReports.Name = "mnuMainReports";
            this.mnuMainReports.Size = new System.Drawing.Size(59, 20);
            this.mnuMainReports.Text = "&Reports";
            // 
            // mnuMainReportsSSRS
            // 
            this.mnuMainReportsSSRS.Name = "mnuMainReportsSSRS";
            this.mnuMainReportsSSRS.Size = new System.Drawing.Size(131, 22);
            this.mnuMainReportsSSRS.Text = "SSRS";
            this.mnuMainReportsSSRS.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuMainReportsMailMerge
            // 
            this.mnuMainReportsMailMerge.Name = "mnuMainReportsMailMerge";
            this.mnuMainReportsMailMerge.Size = new System.Drawing.Size(131, 22);
            this.mnuMainReportsMailMerge.Text = "&MailMerge";
            this.mnuMainReportsMailMerge.Click += new System.EventHandler(this.mnuMain_Click);
            // 
            // mnuStatus
            // 
            this.mnuStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStatusWindowsUserName,
            this.mnuStatusVersion});
            this.mnuStatus.Location = new System.Drawing.Point(0, 708);
            this.mnuStatus.Name = "mnuStatus";
            this.mnuStatus.Size = new System.Drawing.Size(1008, 22);
            this.mnuStatus.TabIndex = 0;
            this.mnuStatus.Text = "statusStrip1";
            // 
            // mnuStatusWindowsUserName
            // 
            this.mnuStatusWindowsUserName.Name = "mnuStatusWindowsUserName";
            this.mnuStatusWindowsUserName.Size = new System.Drawing.Size(883, 17);
            this.mnuStatusWindowsUserName.Spring = true;
            this.mnuStatusWindowsUserName.Text = "Windows Username";
            this.mnuStatusWindowsUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mnuStatusVersion
            // 
            this.mnuStatusVersion.Name = "mnuStatusVersion";
            this.mnuStatusVersion.Size = new System.Drawing.Size(110, 17);
            this.mnuStatusVersion.Text = "Application Version";
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 24);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.AutoScroll = true;
            this.splitContainerMain.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.splitContainerMain.Panel1.Controls.Add(this.pnlScroll);
            this.splitContainerMain.Panel1.Controls.Add(this.lblTitleBar);
            this.splitContainerMain.Panel1.Controls.Add(this.mnuDefendant);
            this.splitContainerMain.Panel1MinSize = 750;
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.Controls.Add(this.dgvDefendants);
            this.splitContainerMain.Panel2.Controls.Add(this.ucFilter);
            this.splitContainerMain.Size = new System.Drawing.Size(1008, 684);
            this.splitContainerMain.SplitterDistance = 796;
            this.splitContainerMain.TabIndex = 25;
            this.splitContainerMain.Resize += new System.EventHandler(this.splitContainerDefendant_Resize);
            // 
            // pnlScroll
            // 
            this.pnlScroll.AutoScroll = true;
            this.pnlScroll.BackColor = System.Drawing.SystemColors.Control;
            this.pnlScroll.Controls.Add(this.splitContainerDefendant);
            this.pnlScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScroll.Location = new System.Drawing.Point(0, 60);
            this.pnlScroll.Name = "pnlScroll";
            this.pnlScroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.pnlScroll.Size = new System.Drawing.Size(792, 620);
            this.pnlScroll.TabIndex = 14;
            // 
            // splitContainerDefendant
            // 
            this.splitContainerDefendant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerDefendant.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerDefendant.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDefendant.MinimumSize = new System.Drawing.Size(750, 800);
            this.splitContainerDefendant.Name = "splitContainerDefendant";
            this.splitContainerDefendant.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDefendant.Panel1
            // 
            this.splitContainerDefendant.Panel1.Controls.Add(this.ucDefendant);
            this.splitContainerDefendant.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerDefendant.Panel1MinSize = 0;
            // 
            // splitContainerDefendant.Panel2
            // 
            this.splitContainerDefendant.Panel2.Controls.Add(this.ucPlans);
            this.splitContainerDefendant.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainerDefendant.Size = new System.Drawing.Size(750, 842);
            this.splitContainerDefendant.SplitterDistance = 370;
            this.splitContainerDefendant.SplitterWidth = 2;
            this.splitContainerDefendant.TabIndex = 31;
            this.splitContainerDefendant.Resize += new System.EventHandler(this.splitContainerDefendant_Resize);
            // 
            // ucDefendant
            // 
            this.ucDefendant.AutoScroll = true;
            this.ucDefendant.BackColor = System.Drawing.SystemColors.Control;
            this.ucDefendant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucDefendant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDefendant.Location = new System.Drawing.Point(0, 0);
            this.ucDefendant.MinimumSize = new System.Drawing.Size(561, 2);
            this.ucDefendant.Name = "ucDefendant";
            this.ucDefendant.Size = new System.Drawing.Size(750, 370);
            this.ucDefendant.TabIndex = 19;
            // 
            // ucPlans
            // 
            this.ucPlans.AutoScroll = true;
            this.ucPlans.AutoSize = true;
            this.ucPlans.BackColor = System.Drawing.SystemColors.Control;
            this.ucPlans.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucPlans.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPlans.Location = new System.Drawing.Point(0, 0);
            this.ucPlans.MinimumSize = new System.Drawing.Size(683, 420);
            this.ucPlans.Name = "ucPlans";
            this.ucPlans.Size = new System.Drawing.Size(750, 470);
            this.ucPlans.TabIndex = 0;
            // 
            // lblTitleBar
            // 
            this.lblTitleBar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitleBar.Image = global::county.feecollections.Properties.Resources.expanded;
            this.lblTitleBar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitleBar.Location = new System.Drawing.Point(0, 25);
            this.lblTitleBar.Name = "lblTitleBar";
            this.lblTitleBar.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblTitleBar.Size = new System.Drawing.Size(792, 35);
            this.lblTitleBar.TabIndex = 13;
            this.lblTitleBar.Text = "     Defendant Name";
            this.lblTitleBar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitleBar.Click += new System.EventHandler(this.lblTitleBar_Click);
            // 
            // mnuDefendant
            // 
            this.mnuDefendant.AddNewItem = null;
            this.mnuDefendant.BindingSource = this.bindingDefendants;
            this.mnuDefendant.CountItem = null;
            this.mnuDefendant.DeleteItem = null;
            this.mnuDefendant.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuDefendant.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDefendantNew,
            this.mnuDefendantSeparator1,
            this.mnuDefendantRemove,
            this.mnuDefendantRefresh,
            this.mnuDefendantSave,
            this.mnuDefendantCancel,
            this.toolStripSeparator1,
            this.mnuDefendantNotes,
            this.mnuDefendantMailMerge,
            this.mnuDefendantPayment,
            this.mnuDefendantArchive});
            this.mnuDefendant.Location = new System.Drawing.Point(0, 0);
            this.mnuDefendant.MoveFirstItem = null;
            this.mnuDefendant.MoveLastItem = null;
            this.mnuDefendant.MoveNextItem = null;
            this.mnuDefendant.MovePreviousItem = null;
            this.mnuDefendant.Name = "mnuDefendant";
            this.mnuDefendant.PositionItem = null;
            this.mnuDefendant.Size = new System.Drawing.Size(792, 25);
            this.mnuDefendant.Stretch = true;
            this.mnuDefendant.TabIndex = 1;
            this.mnuDefendant.Text = "Defendant Menu";
            // 
            // bindingDefendants
            // 
            this.bindingDefendants.DataSource = typeof(county.feecollections.Defendant);
            // 
            // mnuDefendantNew
            // 
            this.mnuDefendantNew.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantNew.Image")));
            this.mnuDefendantNew.Name = "mnuDefendantNew";
            this.mnuDefendantNew.RightToLeftAutoMirrorImage = true;
            this.mnuDefendantNew.Size = new System.Drawing.Size(51, 22);
            this.mnuDefendantNew.Text = "&New";
            this.mnuDefendantNew.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // mnuDefendantSeparator1
            // 
            this.mnuDefendantSeparator1.Name = "mnuDefendantSeparator1";
            this.mnuDefendantSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuDefendantRemove
            // 
            this.mnuDefendantRemove.Enabled = false;
            this.mnuDefendantRemove.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantRemove.Image")));
            this.mnuDefendantRemove.Name = "mnuDefendantRemove";
            this.mnuDefendantRemove.RightToLeftAutoMirrorImage = true;
            this.mnuDefendantRemove.Size = new System.Drawing.Size(70, 22);
            this.mnuDefendantRemove.Text = "&Remove";
            this.mnuDefendantRemove.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // mnuDefendantRefresh
            // 
            this.mnuDefendantRefresh.Enabled = false;
            this.mnuDefendantRefresh.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantRefresh.Image")));
            this.mnuDefendantRefresh.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.mnuDefendantRefresh.Name = "mnuDefendantRefresh";
            this.mnuDefendantRefresh.Size = new System.Drawing.Size(66, 22);
            this.mnuDefendantRefresh.Text = "Re&fresh";
            this.mnuDefendantRefresh.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // mnuDefendantSave
            // 
            this.mnuDefendantSave.Enabled = false;
            this.mnuDefendantSave.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantSave.Image")));
            this.mnuDefendantSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDefendantSave.Name = "mnuDefendantSave";
            this.mnuDefendantSave.Size = new System.Drawing.Size(51, 22);
            this.mnuDefendantSave.Text = "&Save";
            this.mnuDefendantSave.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // mnuDefendantCancel
            // 
            this.mnuDefendantCancel.Enabled = false;
            this.mnuDefendantCancel.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantCancel.Image")));
            this.mnuDefendantCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDefendantCancel.Name = "mnuDefendantCancel";
            this.mnuDefendantCancel.Size = new System.Drawing.Size(63, 22);
            this.mnuDefendantCancel.Text = "&Cancel";
            this.mnuDefendantCancel.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuDefendantNotes
            // 
            this.mnuDefendantNotes.Enabled = false;
            this.mnuDefendantNotes.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantNotes.Image")));
            this.mnuDefendantNotes.ImageTransparentColor = System.Drawing.Color.Black;
            this.mnuDefendantNotes.Name = "mnuDefendantNotes";
            this.mnuDefendantNotes.Size = new System.Drawing.Size(58, 22);
            this.mnuDefendantNotes.Text = "&Notes";
            this.mnuDefendantNotes.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // mnuDefendantMailMerge
            // 
            this.mnuDefendantMailMerge.Enabled = false;
            this.mnuDefendantMailMerge.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantMailMerge.Image")));
            this.mnuDefendantMailMerge.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDefendantMailMerge.Name = "mnuDefendantMailMerge";
            this.mnuDefendantMailMerge.Size = new System.Drawing.Size(87, 22);
            this.mnuDefendantMailMerge.Text = "&Mail Merge";
            this.mnuDefendantMailMerge.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // mnuDefendantPayment
            // 
            this.mnuDefendantPayment.Enabled = false;
            this.mnuDefendantPayment.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantPayment.Image")));
            this.mnuDefendantPayment.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDefendantPayment.Name = "mnuDefendantPayment";
            this.mnuDefendantPayment.Size = new System.Drawing.Size(83, 22);
            this.mnuDefendantPayment.Text = "&Payment...";
            this.mnuDefendantPayment.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // mnuDefendantArchive
            // 
            this.mnuDefendantArchive.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuDefendantArchive.Enabled = false;
            this.mnuDefendantArchive.Image = ((System.Drawing.Image)(resources.GetObject("mnuDefendantArchive.Image")));
            this.mnuDefendantArchive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDefendantArchive.Name = "mnuDefendantArchive";
            this.mnuDefendantArchive.Size = new System.Drawing.Size(67, 22);
            this.mnuDefendantArchive.Text = "Archive";
            this.mnuDefendantArchive.Visible = false;
            this.mnuDefendantArchive.Click += new System.EventHandler(this.mnuDefendant_Click);
            // 
            // dgvDefendants
            // 
            this.dgvDefendants.AllowUserToAddRows = false;
            this.dgvDefendants.AllowUserToDeleteRows = false;
            this.dgvDefendants.AllowUserToOrderColumns = true;
            this.dgvDefendants.AllowUserToResizeColumns = false;
            this.dgvDefendants.AllowUserToResizeRows = false;
            this.dgvDefendants.AutoGenerateColumns = false;
            this.dgvDefendants.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvDefendants.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgvDefendants.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDefendants.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDefendants.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvDefendantsClmLastName,
            this.dgvDefendantsClmFirstName});
            this.dgvDefendants.DataBindings.Add(new System.Windows.Forms.Binding("Tag", this.bindingDefendants, "UpdatedBy", true));
            this.dgvDefendants.DataSource = this.bindingDefendants;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDefendants.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDefendants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefendants.Location = new System.Drawing.Point(0, 92);
            this.dgvDefendants.MultiSelect = false;
            this.dgvDefendants.Name = "dgvDefendants";
            this.dgvDefendants.ReadOnly = true;
            this.dgvDefendants.RowHeadersVisible = false;
            this.dgvDefendants.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefendants.Size = new System.Drawing.Size(204, 588);
            this.dgvDefendants.StandardTab = true;
            this.dgvDefendants.TabIndex = 25;
            this.dgvDefendants.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDefendants_RowValidating);
            // 
            // dgvDefendantsClmLastName
            // 
            this.dgvDefendantsClmLastName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvDefendantsClmLastName.DataPropertyName = "LastName";
            this.dgvDefendantsClmLastName.HeaderText = "LastName";
            this.dgvDefendantsClmLastName.Name = "dgvDefendantsClmLastName";
            this.dgvDefendantsClmLastName.ReadOnly = true;
            this.dgvDefendantsClmLastName.ToolTipText = "LastName";
            // 
            // dgvDefendantsClmFirstName
            // 
            this.dgvDefendantsClmFirstName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dgvDefendantsClmFirstName.DataPropertyName = "FirstName";
            this.dgvDefendantsClmFirstName.HeaderText = "FirstName";
            this.dgvDefendantsClmFirstName.Name = "dgvDefendantsClmFirstName";
            this.dgvDefendantsClmFirstName.ReadOnly = true;
            // 
            // ucFilter
            // 
            this.ucFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.ucFilter.Location = new System.Drawing.Point(0, 0);
            this.ucFilter.Name = "ucFilter";
            this.ucFilter.Size = new System.Drawing.Size(204, 92);
            this.ucFilter.TabIndex = 24;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.splitContainerMain);
            this.Controls.Add(this.mnuStatus);
            this.Controls.Add(this.mnuMain);
            this.DoubleBuffered = true;
            this.Icon = global::county.feecollections.Properties.Resources.feecollection;
            this.KeyPreview = true;
            this.MainMenuStrip = this.mnuMain;
            this.MinimumSize = new System.Drawing.Size(1024, 718);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.mnuStatus.ResumeLayout(false);
            this.mnuStatus.PerformLayout();
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.pnlScroll.ResumeLayout(false);
            this.splitContainerDefendant.Panel1.ResumeLayout(false);
            this.splitContainerDefendant.Panel2.ResumeLayout(false);
            this.splitContainerDefendant.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDefendant)).EndInit();
            this.splitContainerDefendant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mnuDefendant)).EndInit();
            this.mnuDefendant.ResumeLayout(false);
            this.mnuDefendant.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingDefendants)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefendants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.StatusStrip mnuStatus;
        private System.Windows.Forms.ToolStripMenuItem mnuMainFile;
        private System.Windows.Forms.ToolStripMenuItem mnuMainFileExit;
        private System.Windows.Forms.ToolStripMenuItem mnuMainTools;
        private System.Windows.Forms.ToolStripMenuItem mnuMainToolsOptions;
        private System.Windows.Forms.ToolStripStatusLabel mnuStatusWindowsUserName;
        private System.Windows.Forms.BindingSource bindingDefendants;
        private System.Windows.Forms.ToolStripStatusLabel mnuStatusVersion;
        private System.Windows.Forms.ToolStripMenuItem mnuMainLists;
        private System.Windows.Forms.ToolStripMenuItem mnuMainListsEmployers;
        private System.Windows.Forms.ToolStripMenuItem mnuMainListsFeeTypes;
        private System.Windows.Forms.ToolStripMenuItem mnuMainListsPaymentArrangementTypes;
        private System.Windows.Forms.ToolStripMenuItem mnuMainReports;
        private System.Windows.Forms.ToolStripMenuItem mnuMainReportsSSRS;
        private System.Windows.Forms.ToolStripMenuItem mnuMainReportsMailMerge;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.Label lblTitleBar;
        private System.Windows.Forms.BindingNavigator mnuDefendant;
        private System.Windows.Forms.ToolStripButton mnuDefendantNew;
        private System.Windows.Forms.ToolStripSeparator mnuDefendantSeparator1;
        private System.Windows.Forms.ToolStripButton mnuDefendantRemove;
        private System.Windows.Forms.ToolStripButton mnuDefendantRefresh;
        private System.Windows.Forms.ToolStripButton mnuDefendantSave;
        private System.Windows.Forms.ToolStripButton mnuDefendantCancel;
        private System.Windows.Forms.ToolStripButton mnuDefendantArchive;
        private System.Windows.Forms.ToolStripButton mnuDefendantMailMerge;
        private System.Windows.Forms.ToolStripButton mnuDefendantNotes;
        private ucPlans ucPlans;
        private ucDefendant ucDefendant;
        private System.Windows.Forms.Panel pnlScroll;
        private System.Windows.Forms.SplitContainer splitContainerDefendant;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridView dgvDefendants;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDefendantsClmLastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvDefendantsClmFirstName;
        private ucFilter ucFilter;
        private System.Windows.Forms.ToolStripMenuItem mnuMainListsRestrictedCasePrefixes;
        private System.Windows.Forms.ToolStripButton mnuDefendantPayment;
        private System.Windows.Forms.ToolStripMenuItem mnuMainToolsOptionsPrintDelinquentLetters;

        
        
    }
}
