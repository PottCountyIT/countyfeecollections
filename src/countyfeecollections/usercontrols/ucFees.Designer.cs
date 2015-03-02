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
    partial class ucFees
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
            this.mnuPlanFees = new System.Windows.Forms.ToolStrip();
            this.mnuPlanFeeRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuPlanFeeAdd = new System.Windows.Forms.ToolStripButton();
            this.dgvFees = new System.Windows.Forms.DataGridView();
            this.dgvFeesClmFeeTypes = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvFeesClmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingFees = new System.Windows.Forms.BindingSource( this.components );
            this.mnuPlanFees.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFees)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuPlanFees
            // 
            this.mnuPlanFees.AllowMerge = false;
            this.mnuPlanFees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mnuPlanFees.AutoSize = false;
            this.mnuPlanFees.CanOverflow = false;
            this.mnuPlanFees.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuPlanFees.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuPlanFees.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlanFeeRemove,
            this.mnuPlanFeeAdd} );
            this.mnuPlanFees.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuPlanFees.Location = new System.Drawing.Point( 0, 145 );
            this.mnuPlanFees.Name = "mnuPlanFees";
            this.mnuPlanFees.Size = new System.Drawing.Size( 386, 20 );
            this.mnuPlanFees.TabIndex = 5;
            this.mnuPlanFees.TabStop = true;
            // 
            // mnuPlanFeeRemove
            // 
            this.mnuPlanFeeRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPlanFeeRemove.Image = global::county.feecollections.Properties.Resources.sub_remove;
            this.mnuPlanFeeRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPlanFeeRemove.Margin = new System.Windows.Forms.Padding( 1 );
            this.mnuPlanFeeRemove.Name = "mnuPlanFeeRemove";
            this.mnuPlanFeeRemove.Size = new System.Drawing.Size( 70, 18 );
            this.mnuPlanFeeRemove.Text = "Remove";
            this.mnuPlanFeeRemove.Click += new System.EventHandler( this.mnuPlanFee_Click );
            // 
            // mnuPlanFeeAdd
            // 
            this.mnuPlanFeeAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPlanFeeAdd.Image = global::county.feecollections.Properties.Resources.sub_add;
            this.mnuPlanFeeAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPlanFeeAdd.Margin = new System.Windows.Forms.Padding( 1 );
            this.mnuPlanFeeAdd.Name = "mnuPlanFeeAdd";
            this.mnuPlanFeeAdd.Size = new System.Drawing.Size( 49, 18 );
            this.mnuPlanFeeAdd.Text = "&Add";
            this.mnuPlanFeeAdd.Click += new System.EventHandler( this.mnuPlanFee_Click );
            // 
            // dgvFees
            // 
            this.dgvFees.AllowUserToAddRows = false;
            this.dgvFees.AllowUserToDeleteRows = false;
            this.dgvFees.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFees.AutoGenerateColumns = false;
            this.dgvFees.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFees.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFees.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFees.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvFeesClmFeeTypes,
            this.dgvFeesClmAmount} );
            this.dgvFees.DataSource = this.bindingFees;
            this.dgvFees.Location = new System.Drawing.Point( 0, 0 );
            this.dgvFees.Name = "dgvFees";
            this.dgvFees.RowHeadersVisible = false;
            this.dgvFees.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFees.Size = new System.Drawing.Size( 385, 145 );
            this.dgvFees.TabIndex = 4;
            // 
            // dgvFeesClmFeeTypes
            // 
            this.dgvFeesClmFeeTypes.DataPropertyName = "FeeTypeId";
            this.dgvFeesClmFeeTypes.HeaderText = "Fee Type";
            this.dgvFeesClmFeeTypes.Name = "dgvFeesClmFeeTypes";
            this.dgvFeesClmFeeTypes.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvFeesClmAmount
            // 
            this.dgvFeesClmAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvFeesClmAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.dgvFeesClmAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFeesClmAmount.HeaderText = "Amount";
            this.dgvFeesClmAmount.Name = "dgvFeesClmAmount";
            this.dgvFeesClmAmount.Width = 68;
            // 
            // bindingFees
            // 
            this.bindingFees.DataMember = "Fees";
            // 
            // ucFees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.mnuPlanFees );
            this.Controls.Add( this.dgvFees );
            this.DoubleBuffered = true;
            this.Name = "ucFees";
            this.Size = new System.Drawing.Size( 385, 167 );
            this.Leave += new System.EventHandler( this.ucFees_Leave );
            this.mnuPlanFees.ResumeLayout( false );
            this.mnuPlanFees.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFees)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFees)).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.ToolStrip mnuPlanFees;
        private System.Windows.Forms.ToolStripButton mnuPlanFeeRemove;
        private System.Windows.Forms.ToolStripButton mnuPlanFeeAdd;
        private System.Windows.Forms.DataGridView dgvFees;
        private System.Windows.Forms.BindingSource bindingFees;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvFeesClmFeeTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFeesClmAmount;

    }
}
