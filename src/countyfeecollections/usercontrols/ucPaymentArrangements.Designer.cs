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
    partial class ucPaymentArrangements
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucPaymentArrangements));
            this.dgvPaymentArrangements = new System.Windows.Forms.DataGridView();
            this.dgvPaymentArrangementsClmPaymentArrangementTypeId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvPaymentArrangementsClmPayPeriodTypeId = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvPaymentArrangementsClmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentArrangementsClmStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentArrangementsClmEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingPaymentArrangements = new System.Windows.Forms.BindingSource(this.components);
            this.mnuPaymentArrangements = new System.Windows.Forms.ToolStrip();
            this.mnuPaymentArrangementsRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuPaymentArrangementsAdd = new System.Windows.Forms.ToolStripButton();
            this.mnuPaymentArrangementsCalcEndDate = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentArrangements)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPaymentArrangements)).BeginInit();
            this.mnuPaymentArrangements.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPaymentArrangements
            // 
            this.dgvPaymentArrangements.AllowUserToAddRows = false;
            this.dgvPaymentArrangements.AllowUserToDeleteRows = false;
            this.dgvPaymentArrangements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPaymentArrangements.AutoGenerateColumns = false;
            this.dgvPaymentArrangements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPaymentArrangements.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentArrangements.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaymentArrangements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPaymentArrangementsClmPaymentArrangementTypeId,
            this.dgvPaymentArrangementsClmPayPeriodTypeId,
            this.dgvPaymentArrangementsClmAmount,
            this.dgvPaymentArrangementsClmStartDate,
            this.dgvPaymentArrangementsClmEndDate});
            this.dgvPaymentArrangements.DataSource = this.bindingPaymentArrangements;
            this.dgvPaymentArrangements.Location = new System.Drawing.Point(0, 0);
            this.dgvPaymentArrangements.Name = "dgvPaymentArrangements";
            this.dgvPaymentArrangements.RowHeadersVisible = false;
            this.dgvPaymentArrangements.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPaymentArrangements.Size = new System.Drawing.Size(430, 204);
            this.dgvPaymentArrangements.TabIndex = 2;            
            // 
            // dgvPaymentArrangementsClmPaymentArrangementTypeId
            // 
            this.dgvPaymentArrangementsClmPaymentArrangementTypeId.DataPropertyName = "PaymentArrangementTypeId";
            this.dgvPaymentArrangementsClmPaymentArrangementTypeId.FillWeight = 200F;
            this.dgvPaymentArrangementsClmPaymentArrangementTypeId.HeaderText = "Payment Arrangement Type";
            this.dgvPaymentArrangementsClmPaymentArrangementTypeId.Name = "dgvPaymentArrangementsClmPaymentArrangementTypeId";
            this.dgvPaymentArrangementsClmPaymentArrangementTypeId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentArrangementsClmPaymentArrangementTypeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvPaymentArrangementsClmPayPeriodTypeId
            // 
            this.dgvPaymentArrangementsClmPayPeriodTypeId.DataPropertyName = "PayPeriodTypeId";
            this.dgvPaymentArrangementsClmPayPeriodTypeId.FillWeight = 125F;
            this.dgvPaymentArrangementsClmPayPeriodTypeId.HeaderText = "Pay Period Type";
            this.dgvPaymentArrangementsClmPayPeriodTypeId.Name = "dgvPaymentArrangementsClmPayPeriodTypeId";
            this.dgvPaymentArrangementsClmPayPeriodTypeId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPaymentArrangementsClmPayPeriodTypeId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvPaymentArrangementsClmAmount
            // 
            this.dgvPaymentArrangementsClmAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "c2";
            dataGridViewCellStyle2.NullValue = "0";
            this.dgvPaymentArrangementsClmAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaymentArrangementsClmAmount.FillWeight = 75F;
            this.dgvPaymentArrangementsClmAmount.HeaderText = "Amount";
            this.dgvPaymentArrangementsClmAmount.Name = "dgvPaymentArrangementsClmAmount";
            // 
            // dgvPaymentArrangementsClmStartDate
            // 
            this.dgvPaymentArrangementsClmStartDate.DataPropertyName = "StartDate";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.dgvPaymentArrangementsClmStartDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPaymentArrangementsClmStartDate.FillWeight = 75F;
            this.dgvPaymentArrangementsClmStartDate.HeaderText = "Start";
            this.dgvPaymentArrangementsClmStartDate.Name = "dgvPaymentArrangementsClmStartDate";
            // 
            // dgvPaymentArrangementsClmEndDate
            // 
            this.dgvPaymentArrangementsClmEndDate.DataPropertyName = "EndDate";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            this.dgvPaymentArrangementsClmEndDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaymentArrangementsClmEndDate.FillWeight = 75F;
            this.dgvPaymentArrangementsClmEndDate.HeaderText = "End";
            this.dgvPaymentArrangementsClmEndDate.Name = "dgvPaymentArrangementsClmEndDate";
            // 
            // bindingPaymentArrangements
            // 
            this.bindingPaymentArrangements.DataSource = typeof(county.feecollections.PlanPaymentArrangement);
            // 
            // mnuPaymentArrangements
            // 
            this.mnuPaymentArrangements.AllowMerge = false;
            this.mnuPaymentArrangements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mnuPaymentArrangements.AutoSize = false;
            this.mnuPaymentArrangements.CanOverflow = false;
            this.mnuPaymentArrangements.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuPaymentArrangements.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuPaymentArrangements.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPaymentArrangementsRemove,
            this.mnuPaymentArrangementsAdd,
            this.mnuPaymentArrangementsCalcEndDate});
            this.mnuPaymentArrangements.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuPaymentArrangements.Location = new System.Drawing.Point(0, 206);
            this.mnuPaymentArrangements.Name = "mnuPaymentArrangements";
            this.mnuPaymentArrangements.Size = new System.Drawing.Size(431, 20);
            this.mnuPaymentArrangements.TabIndex = 3;
            this.mnuPaymentArrangements.TabStop = true;
            // 
            // mnuPaymentArrangementsRemove
            // 
            this.mnuPaymentArrangementsRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPaymentArrangementsRemove.Image = global::county.feecollections.Properties.Resources.sub_remove;
            this.mnuPaymentArrangementsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPaymentArrangementsRemove.Margin = new System.Windows.Forms.Padding(1);
            this.mnuPaymentArrangementsRemove.Name = "mnuPaymentArrangementsRemove";
            this.mnuPaymentArrangementsRemove.Size = new System.Drawing.Size(70, 18);
            this.mnuPaymentArrangementsRemove.Text = "Remove";
            this.mnuPaymentArrangementsRemove.Click += new System.EventHandler(this.mnuPaymentArrangements_Click);
            // 
            // mnuPaymentArrangementsAdd
            // 
            this.mnuPaymentArrangementsAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPaymentArrangementsAdd.Image = global::county.feecollections.Properties.Resources.sub_add;
            this.mnuPaymentArrangementsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPaymentArrangementsAdd.Margin = new System.Windows.Forms.Padding(1);
            this.mnuPaymentArrangementsAdd.Name = "mnuPaymentArrangementsAdd";
            this.mnuPaymentArrangementsAdd.Size = new System.Drawing.Size(49, 18);
            this.mnuPaymentArrangementsAdd.Text = "&Add";
            this.mnuPaymentArrangementsAdd.Click += new System.EventHandler(this.mnuPaymentArrangements_Click);
            // 
            // mnuPaymentArrangementsCalcEndDate
            // 
            this.mnuPaymentArrangementsCalcEndDate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.mnuPaymentArrangementsCalcEndDate.Image = ((System.Drawing.Image)(resources.GetObject("mnuPaymentArrangementsCalcEndDate.Image")));
            this.mnuPaymentArrangementsCalcEndDate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPaymentArrangementsCalcEndDate.Name = "mnuPaymentArrangementsCalcEndDate";
            this.mnuPaymentArrangementsCalcEndDate.Size = new System.Drawing.Size(84, 17);
            this.mnuPaymentArrangementsCalcEndDate.Text = "Calc End Date";
            this.mnuPaymentArrangementsCalcEndDate.Click += new System.EventHandler(this.mnuPaymentArrangements_Click);
            // 
            // ucPaymentArrangements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mnuPaymentArrangements);
            this.Controls.Add(this.dgvPaymentArrangements);
            this.DoubleBuffered = true;
            this.Name = "ucPaymentArrangements";
            this.Size = new System.Drawing.Size(430, 227);
            this.Leave += new System.EventHandler(this.ucPaymentArrangements_Leave);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentArrangements)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPaymentArrangements)).EndInit();
            this.mnuPaymentArrangements.ResumeLayout(false);
            this.mnuPaymentArrangements.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.BindingSource bindingPaymentArrangements;
        private System.Windows.Forms.DataGridView dgvPaymentArrangements;
        private System.Windows.Forms.ToolStrip mnuPaymentArrangements;
        private System.Windows.Forms.ToolStripButton mnuPaymentArrangementsRemove;
        private System.Windows.Forms.ToolStripButton mnuPaymentArrangementsAdd;
        private System.Windows.Forms.ToolStripButton mnuPaymentArrangementsCalcEndDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvPaymentArrangementsClmPaymentArrangementTypeId;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvPaymentArrangementsClmPayPeriodTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentArrangementsClmAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentArrangementsClmStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentArrangementsClmEndDate;
    }
}
