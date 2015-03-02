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
    partial class ucPayments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( ucPayments ) );
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.mnuPlanPayments = new System.Windows.Forms.ToolStrip();
            this.mnuPlanPaymentsRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuPlanPaymentsAdd = new System.Windows.Forms.ToolStripButton();
            this.bindingPayments = new System.Windows.Forms.BindingSource( this.components );
            this.dgvPaymentsClmReceivedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentsClmFeeTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPaymentsClmAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.mnuPlanPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPayments
            // 
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPayments.AutoGenerateColumns = false;
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPayments.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPaymentsClmReceivedDate,
            this.dgvPaymentsClmFeeTypeId,
            this.dgvPaymentsClmAmount} );
            this.dgvPayments.DataSource = this.bindingPayments;
            this.dgvPayments.Location = new System.Drawing.Point( 0, 0 );
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.ReadOnly = true;
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPayments.Size = new System.Drawing.Size( 292, 177 );
            this.dgvPayments.TabIndex = 1;
            // 
            // mnuPlanPayments
            // 
            this.mnuPlanPayments.AllowMerge = false;
            this.mnuPlanPayments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mnuPlanPayments.AutoSize = false;
            this.mnuPlanPayments.CanOverflow = false;
            this.mnuPlanPayments.Dock = System.Windows.Forms.DockStyle.None;
            this.mnuPlanPayments.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuPlanPayments.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.mnuPlanPaymentsRemove,
            this.mnuPlanPaymentsAdd} );
            this.mnuPlanPayments.Location = new System.Drawing.Point( 2, 177 );
            this.mnuPlanPayments.Name = "mnuPlanPayments";
            this.mnuPlanPayments.Size = new System.Drawing.Size( 291, 20 );
            this.mnuPlanPayments.TabIndex = 4;
            this.mnuPlanPayments.TabStop = true;
            // 
            // mnuPlanPaymentsRemove
            // 
            this.mnuPlanPaymentsRemove.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPlanPaymentsRemove.Image = ((System.Drawing.Image)(resources.GetObject( "mnuPlanPaymentsRemove.Image" )));
            this.mnuPlanPaymentsRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPlanPaymentsRemove.Margin = new System.Windows.Forms.Padding( 1 );
            this.mnuPlanPaymentsRemove.Name = "mnuPlanPaymentsRemove";
            this.mnuPlanPaymentsRemove.Size = new System.Drawing.Size( 70, 18 );
            this.mnuPlanPaymentsRemove.Text = "Remove";
            this.mnuPlanPaymentsRemove.Click += new System.EventHandler( this.mnuPayments_Click );
            // 
            // mnuPlanPaymentsAdd
            // 
            this.mnuPlanPaymentsAdd.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.mnuPlanPaymentsAdd.Image = ((System.Drawing.Image)(resources.GetObject( "mnuPlanPaymentsAdd.Image" )));
            this.mnuPlanPaymentsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPlanPaymentsAdd.Margin = new System.Windows.Forms.Padding( 1 );
            this.mnuPlanPaymentsAdd.Name = "mnuPlanPaymentsAdd";
            this.mnuPlanPaymentsAdd.Size = new System.Drawing.Size( 58, 18 );
            this.mnuPlanPaymentsAdd.Text = "&Add...";
            this.mnuPlanPaymentsAdd.Click += new System.EventHandler( this.mnuPayments_Click );
            // 
            // bindingPayments
            // 
            this.bindingPayments.DataMember = "Payments";
            this.bindingPayments.DataSource = typeof( county.feecollections.Plan );
            // 
            // dgvPaymentsClmReceivedDate
            // 
            this.dgvPaymentsClmReceivedDate.DataPropertyName = "ReceivedDate";
            dataGridViewCellStyle1.Format = "d";
            this.dgvPaymentsClmReceivedDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPaymentsClmReceivedDate.FillWeight = 67.56757F;
            this.dgvPaymentsClmReceivedDate.HeaderText = "Received";
            this.dgvPaymentsClmReceivedDate.Name = "dgvPaymentsClmReceivedDate";
            this.dgvPaymentsClmReceivedDate.ReadOnly = true;
            // 
            // dgvPaymentsClmFeeTypeId
            // 
            this.dgvPaymentsClmFeeTypeId.DataPropertyName = "FeeTypeName";
            this.dgvPaymentsClmFeeTypeId.FillWeight = 132.4324F;
            this.dgvPaymentsClmFeeTypeId.HeaderText = "Fee Type";
            this.dgvPaymentsClmFeeTypeId.Name = "dgvPaymentsClmFeeTypeId";
            this.dgvPaymentsClmFeeTypeId.ReadOnly = true;
            this.dgvPaymentsClmFeeTypeId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dgvPaymentsClmAmount
            // 
            this.dgvPaymentsClmAmount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dgvPaymentsClmAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = "0";
            this.dgvPaymentsClmAmount.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPaymentsClmAmount.HeaderText = "Amount";
            this.dgvPaymentsClmAmount.Name = "dgvPaymentsClmAmount";
            this.dgvPaymentsClmAmount.ReadOnly = true;
            this.dgvPaymentsClmAmount.Width = 68;
            // 
            // ucPayments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.mnuPlanPayments );
            this.Controls.Add( this.dgvPayments );
            this.DoubleBuffered = true;
            this.Name = "ucPayments";
            this.Size = new System.Drawing.Size( 292, 197 );
            this.Leave += new System.EventHandler( this.ucPayments_Leave );
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.mnuPlanPayments.ResumeLayout( false );
            this.mnuPlanPayments.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPayments)).EndInit();
            this.ResumeLayout( false );

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingPayments;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.ToolStrip mnuPlanPayments;
        private System.Windows.Forms.ToolStripButton mnuPlanPaymentsRemove;
        private System.Windows.Forms.ToolStripButton mnuPlanPaymentsAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentsClmReceivedDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentsClmFeeTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentsClmAmount;
    }
}
