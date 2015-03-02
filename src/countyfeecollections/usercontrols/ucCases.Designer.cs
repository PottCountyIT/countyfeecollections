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
    partial class ucCases
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucCases));
            this.dgvCases = new System.Windows.Forms.DataGridView();
            this.dgvCasesClmCaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCasesClmCountyId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvCasesClmCommitted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvCasesClmCommitDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCasesClmCAPP = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingCases = new System.Windows.Forms.BindingSource(this.components);
            this.mnuPlanCases = new System.Windows.Forms.ToolStrip();
            this.mnuPlanCaseRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuPlanCaseAdd = new System.Windows.Forms.ToolStripButton();
            this.mnuPlanCasePaste = new System.Windows.Forms.ToolStripButton();
            this.mnuPlanCaseCommitUntil = new System.Windows.Forms.ToolStripComboBox();
            this.mnuPlanCaseCommit = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCases)).BeginInit();
            this.mnuPlanCases.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCases
            // 
            this.dgvCases.AllowUserToAddRows = false;
            this.dgvCases.AllowUserToDeleteRows = false;
            this.dgvCases.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCases.AutoGenerateColumns = false;
            this.dgvCases.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCases.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCases.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCases.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvCasesClmCaseName,
            this.dgvCasesClmCountyId,
            this.dgvCasesClmCommitted,
            this.dgvCasesClmCommitDate,
            this.dgvCasesClmCAPP});
            this.dgvCases.DataSource = this.bindingCases;
            this.dgvCases.Location = new System.Drawing.Point(0, 0);
            this.dgvCases.Name = "dgvCases";
            this.dgvCases.RowHeadersVisible = false;
            this.dgvCases.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCases.Size = new System.Drawing.Size(430, 205);
            this.dgvCases.TabIndex = 2;
            this.dgvCases.CellValidated += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCases_CellValidated);
            // 
            // dgvCasesClmCaseName
            // 
            this.dgvCasesClmCaseName.DataPropertyName = "CaseName";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvCasesClmCaseName.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCasesClmCaseName.FillWeight = 23.92225F;
            this.dgvCasesClmCaseName.HeaderText = "CaseName";
            this.dgvCasesClmCaseName.Name = "dgvCasesClmCaseName";
            // 
            // dgvCasesClmCountyId
            // 
            this.dgvCasesClmCountyId.DataPropertyName = "CountyId";
            this.dgvCasesClmCountyId.FillWeight = 25.1269F;
            this.dgvCasesClmCountyId.HeaderText = "County";
            this.dgvCasesClmCountyId.Name = "dgvCasesClmCountyId";
            // 
            // dgvCasesClmCommitted
            // 
            this.dgvCasesClmCommitted.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvCasesClmCommitted.DataPropertyName = "Committed";
            this.dgvCasesClmCommitted.FillWeight = 14.18749F;
            this.dgvCasesClmCommitted.HeaderText = "Committed";
            this.dgvCasesClmCommitted.Name = "dgvCasesClmCommitted";
            this.dgvCasesClmCommitted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvCasesClmCommitted.Width = 81;
            // 
            // dgvCasesClmCommitDate
            // 
            this.dgvCasesClmCommitDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvCasesClmCommitDate.DataPropertyName = "CommitDate";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.dgvCasesClmCommitDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCasesClmCommitDate.FillWeight = 14.06629F;
            this.dgvCasesClmCommitDate.HeaderText = "CommitDate";
            this.dgvCasesClmCommitDate.Name = "dgvCasesClmCommitDate";
            this.dgvCasesClmCommitDate.Width = 89;
            // 
            // dgvCasesClmCAPP
            // 
            this.dgvCasesClmCAPP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dgvCasesClmCAPP.DataPropertyName = "CAPP";
            this.dgvCasesClmCAPP.FillWeight = 32.69707F;
            this.dgvCasesClmCAPP.HeaderText = "CAPP";
            this.dgvCasesClmCAPP.Name = "dgvCasesClmCAPP";
            this.dgvCasesClmCAPP.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCasesClmCAPP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgvCasesClmCAPP.Width = 60;
            // 
            // bindingCases
            // 
            this.bindingCases.DataMember = "PlanCases";
            // 
            // mnuPlanCases
            // 
            this.mnuPlanCases.AllowMerge = false;
            this.mnuPlanCases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mnuPlanCases.AutoSize = false;
            this.mnuPlanCases.CanOverflow = false;
            this.mnuPlanCases.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuPlanCases.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuPlanCases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlanCaseRemove,
            this.mnuPlanCaseAdd,
            this.mnuPlanCasePaste,
            this.mnuPlanCaseCommitUntil,
            this.mnuPlanCaseCommit});
            this.mnuPlanCases.Location = new System.Drawing.Point(0, 206);
            this.mnuPlanCases.Name = "mnuPlanCases";
            this.mnuPlanCases.Size = new System.Drawing.Size(431, 20);
            this.mnuPlanCases.TabIndex = 3;
            this.mnuPlanCases.TabStop = true;
            // 
            // mnuPlanCaseRemove
            // 
            this.mnuPlanCaseRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPlanCaseRemove.Image = global::county.feecollections.Properties.Resources.sub_remove;
            this.mnuPlanCaseRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPlanCaseRemove.Margin = new System.Windows.Forms.Padding(1);
            this.mnuPlanCaseRemove.Name = "mnuPlanCaseRemove";
            this.mnuPlanCaseRemove.Size = new System.Drawing.Size(70, 18);
            this.mnuPlanCaseRemove.Text = "&Remove";
            this.mnuPlanCaseRemove.Click += new System.EventHandler(this.mnuPlanCase_Click);
            // 
            // mnuPlanCaseAdd
            // 
            this.mnuPlanCaseAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPlanCaseAdd.Image = global::county.feecollections.Properties.Resources.sub_add;
            this.mnuPlanCaseAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPlanCaseAdd.Margin = new System.Windows.Forms.Padding(1);
            this.mnuPlanCaseAdd.Name = "mnuPlanCaseAdd";
            this.mnuPlanCaseAdd.Size = new System.Drawing.Size(49, 18);
            this.mnuPlanCaseAdd.Text = "&Add";
            this.mnuPlanCaseAdd.Click += new System.EventHandler(this.mnuPlanCase_Click);
            // 
            // mnuPlanCasePaste
            // 
            this.mnuPlanCasePaste.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPlanCasePaste.Image = global::county.feecollections.Properties.Resources.paste;
            this.mnuPlanCasePaste.ImageTransparentColor = System.Drawing.Color.Black;
            this.mnuPlanCasePaste.Margin = new System.Windows.Forms.Padding(1);
            this.mnuPlanCasePaste.Name = "mnuPlanCasePaste";
            this.mnuPlanCasePaste.Size = new System.Drawing.Size(55, 18);
            this.mnuPlanCasePaste.Text = "Paste";
            this.mnuPlanCasePaste.Click += new System.EventHandler(this.mnuPlanCase_Click);
            // 
            // mnuPlanCaseCommitUntil
            // 
            this.mnuPlanCaseCommitUntil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mnuPlanCaseCommitUntil.Items.AddRange(new object[] {
            "  0",
            "30",
            "60",
            "90"});
            this.mnuPlanCaseCommitUntil.MaxDropDownItems = 4;
            this.mnuPlanCaseCommitUntil.Name = "mnuPlanCaseCommitUntil";
            this.mnuPlanCaseCommitUntil.Size = new System.Drawing.Size(75, 20);
            // 
            // mnuPlanCaseCommit
            // 
            this.mnuPlanCaseCommit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuPlanCaseCommit.Image = ((System.Drawing.Image)(resources.GetObject("mnuPlanCaseCommit.Image")));
            this.mnuPlanCaseCommit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPlanCaseCommit.Name = "mnuPlanCaseCommit";
            this.mnuPlanCaseCommit.Size = new System.Drawing.Size(101, 17);
            this.mnuPlanCaseCommit.Text = "Set Commit Date";
            this.mnuPlanCaseCommit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.mnuPlanCaseCommit.ToolTipText = "Sets the currently selected case commit date to relative date in the future.";
            this.mnuPlanCaseCommit.Click += new System.EventHandler(this.mnuPlanCase_Click);
            // 
            // ucCases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mnuPlanCases);
            this.Controls.Add(this.dgvCases);
            this.DoubleBuffered = true;
            this.Name = "ucCases";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 1);
            this.Size = new System.Drawing.Size(430, 227);
            this.Leave += new System.EventHandler(this.ucCases_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingCases)).EndInit();
            this.mnuPlanCases.ResumeLayout(false);
            this.mnuPlanCases.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.BindingSource bindingCases;
        private System.Windows.Forms.DataGridView dgvCases;
        private System.Windows.Forms.ToolStrip mnuPlanCases;
        private System.Windows.Forms.ToolStripButton mnuPlanCaseRemove;
        private System.Windows.Forms.ToolStripButton mnuPlanCaseAdd;
        private System.Windows.Forms.ToolStripButton mnuPlanCasePaste;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCasesClmCaseName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvCasesClmCountyId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvCasesClmCommitted;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCasesClmCommitDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvCasesClmCAPP;
        private System.Windows.Forms.ToolStripButton mnuPlanCaseCommit;
        private System.Windows.Forms.ToolStripComboBox mnuPlanCaseCommitUntil;
    }
}
