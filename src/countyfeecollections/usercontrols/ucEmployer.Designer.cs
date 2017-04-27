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
    partial class ucEmployer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.employerPanel = new System.Windows.Forms.Panel();
            this.dgvEmployers = new System.Windows.Forms.DataGridView();
            this.dgvEmployersClmSeparationDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEmployersClmName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingEmployers = new System.Windows.Forms.BindingSource(this.components);
            this.mnuDefendantEmployer = new System.Windows.Forms.ToolStrip();
            this.mnuDefendantEmployerRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuDefendantEmployerAdd = new System.Windows.Forms.ToolStripButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.lblNote = new System.Windows.Forms.Label();
            this.lblEmployers = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployers)).BeginInit();
            this.mnuDefendantEmployer.SuspendLayout();
            this.SuspendLayout();
            // 
            // employerPanel
            // 
            this.employerPanel.Location = new System.Drawing.Point(0, 0);
            this.employerPanel.Name = "employerPanel";
            this.employerPanel.Size = new System.Drawing.Size(458, 226);
            this.employerPanel.TabIndex = 0;
            // 
            // dgvEmployers
            // 
            this.dgvEmployers.AllowUserToAddRows = false;
            this.dgvEmployers.AllowUserToDeleteRows = false;
            this.dgvEmployers.AllowUserToOrderColumns = true;
            this.dgvEmployers.AllowUserToResizeRows = false;
            this.dgvEmployers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmployers.AutoGenerateColumns = false;
            this.dgvEmployers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmployers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEmployers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmployers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvEmployers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvEmployersClmSeparationDate,
            this.dgvEmployersClmName});
            this.dgvEmployers.DataSource = this.bindingEmployers;
            this.dgvEmployers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvEmployers.Location = new System.Drawing.Point(0, 20);
            this.dgvEmployers.MultiSelect = false;
            this.dgvEmployers.Name = "dgvEmployers";
            this.dgvEmployers.RowHeadersVisible = false;
            this.dgvEmployers.ShowCellToolTips = false;
            this.dgvEmployers.Size = new System.Drawing.Size(430, 178);
            this.dgvEmployers.TabIndex = 0;
            this.dgvEmployers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvEmployers_DataBindingComplete);
            // 
            // dgvEmployersClmSeparationDate
            // 
            this.dgvEmployersClmSeparationDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgvEmployersClmSeparationDate.DataPropertyName = "SeparationDate";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = "current";
            this.dgvEmployersClmSeparationDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvEmployersClmSeparationDate.FillWeight = 138.4815F;
            this.dgvEmployersClmSeparationDate.HeaderText = "Separation Date*";
            this.dgvEmployersClmSeparationDate.Name = "dgvEmployersClmSeparationDate";
            this.dgvEmployersClmSeparationDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmployersClmSeparationDate.Width = 113;
            // 
            // dgvEmployersClmName
            // 
            this.dgvEmployersClmName.DataPropertyName = "EmployerName";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvEmployersClmName.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvEmployersClmName.FillWeight = 134.3271F;
            this.dgvEmployersClmName.HeaderText = "Employer Name";
            this.dgvEmployersClmName.MinimumWidth = 50;
            this.dgvEmployersClmName.Name = "dgvEmployersClmName";
            this.dgvEmployersClmName.ReadOnly = true;
            // 
            // bindingEmployers
            // 
            this.bindingEmployers.DataMember = "Employers";
            this.bindingEmployers.CurrentChanged += new System.EventHandler(this.bindingEmployers_CurrentChanged);
            // 
            // mnuDefendantEmployer
            // 
            this.mnuDefendantEmployer.AllowMerge = false;
            this.mnuDefendantEmployer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.mnuDefendantEmployer.AutoSize = false;
            this.mnuDefendantEmployer.CanOverflow = false;
            this.mnuDefendantEmployer.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuDefendantEmployer.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.mnuDefendantEmployer.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuDefendantEmployer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDefendantEmployerRemove,
            this.mnuDefendantEmployerAdd});
            this.mnuDefendantEmployer.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuDefendantEmployer.Location = new System.Drawing.Point(299, 204);
            this.mnuDefendantEmployer.Name = "mnuDefendantEmployer";
            this.mnuDefendantEmployer.Size = new System.Drawing.Size(137, 22);
            this.mnuDefendantEmployer.TabIndex = 1;
            this.mnuDefendantEmployer.TabStop = true;
            // 
            // mnuDefendantEmployerRemove
            // 
            this.mnuDefendantEmployerRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuDefendantEmployerRemove.Image = global::county.feecollections.Properties.Resources.sub_remove;
            this.mnuDefendantEmployerRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDefendantEmployerRemove.Margin = new System.Windows.Forms.Padding(0);
            this.mnuDefendantEmployerRemove.Name = "mnuDefendantEmployerRemove";
            this.mnuDefendantEmployerRemove.Size = new System.Drawing.Size(70, 22);
            this.mnuDefendantEmployerRemove.Text = "Remove";
            this.mnuDefendantEmployerRemove.ToolTipText = "Removes the currently selected Employer.";
            this.mnuDefendantEmployerRemove.Click += new System.EventHandler(this.mnuDefendantEmployer_Click);
            // 
            // mnuDefendantEmployerAdd
            // 
            this.mnuDefendantEmployerAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuDefendantEmployerAdd.Image = global::county.feecollections.Properties.Resources.sub_add;
            this.mnuDefendantEmployerAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.mnuDefendantEmployerAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuDefendantEmployerAdd.Margin = new System.Windows.Forms.Padding(0);
            this.mnuDefendantEmployerAdd.Name = "mnuDefendantEmployerAdd";
            this.mnuDefendantEmployerAdd.Size = new System.Drawing.Size(58, 22);
            this.mnuDefendantEmployerAdd.Text = "&Add...";
            this.mnuDefendantEmployerAdd.ToolTipText = "Opens a list of employers to select from.";
            this.mnuDefendantEmployerAdd.Click += new System.EventHandler(this.mnuDefendantEmployer_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutomaticDelay = 0;
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 1;
            this.toolTip.ReshowDelay = 1;
            this.toolTip.ShowAlways = true;
            // 
            // lblNote
            // 
            this.lblNote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblNote.AutoSize = true;
            this.lblNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNote.Location = new System.Drawing.Point(4, 210);
            this.lblNote.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblNote.Name = "lblNote";
            this.lblNote.Size = new System.Drawing.Size(122, 13);
            this.lblNote.TabIndex = 2;
            this.lblNote.Text = "*Blank indicates current.";
            // 
            // lblEmployers
            // 
            this.lblEmployers.AutoSize = true;
            this.lblEmployers.Location = new System.Drawing.Point(7, 4);
            this.lblEmployers.Name = "lblEmployers";
            this.lblEmployers.Size = new System.Drawing.Size(55, 13);
            this.lblEmployers.TabIndex = 3;
            this.lblEmployers.Text = "Employers";
            // 
            // ucEmployer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblEmployers);
            this.Controls.Add(this.lblNote);
            this.Controls.Add(this.mnuDefendantEmployer);
            this.Controls.Add(this.dgvEmployers);
            this.DoubleBuffered = true;
            this.Name = "ucEmployer";
            this.Size = new System.Drawing.Size(435, 226);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingEmployers)).EndInit();
            this.mnuDefendantEmployer.ResumeLayout(false);
            this.mnuDefendantEmployer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Panel employerPanel;
        private System.Windows.Forms.BindingSource bindingEmployers;
        private System.Windows.Forms.DataGridView dgvEmployers;
        private System.Windows.Forms.ToolStrip mnuDefendantEmployer;
        private System.Windows.Forms.ToolStripButton mnuDefendantEmployerRemove;
        private System.Windows.Forms.ToolStripButton mnuDefendantEmployerAdd;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmployersClmSeparationDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvEmployersClmName;
        private System.Windows.Forms.Label lblEmployers;
    }
}
