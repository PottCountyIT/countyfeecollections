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
    partial class frmPayment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblPaymentAmount = new System.Windows.Forms.Label();
            this.lblSplitTotal = new System.Windows.Forms.Label();
            this.lblRemainder = new System.Windows.Forms.Label();
            this.lblRemainderValue = new System.Windows.Forms.Label();
            this.lblSplitTotalValue = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpLine = new System.Windows.Forms.GroupBox();
            this.lblReceivedDate = new System.Windows.Forms.Label();
            this.dtpReceivedDate = new System.Windows.Forms.DateTimePicker();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.bindingPayments = new System.Windows.Forms.BindingSource( this.components );
            this.grpSplitPayments = new System.Windows.Forms.GroupBox();
            this.dgvPayments = new System.Windows.Forms.DataGridView();
            this.plan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.remaining = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apply = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblInstructions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPayments)).BeginInit();
            this.grpSplitPayments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPaymentAmount
            // 
            this.lblPaymentAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaymentAmount.AutoSize = true;
            this.lblPaymentAmount.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblPaymentAmount.Location = new System.Drawing.Point( 337, 49 );
            this.lblPaymentAmount.Name = "lblPaymentAmount";
            this.lblPaymentAmount.Size = new System.Drawing.Size( 105, 13 );
            this.lblPaymentAmount.TabIndex = 1;
            this.lblPaymentAmount.Text = "Payment Amount:";
            // 
            // lblSplitTotal
            // 
            this.lblSplitTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSplitTotal.AutoSize = true;
            this.lblSplitTotal.Location = new System.Drawing.Point( 13, 204 );
            this.lblSplitTotal.Name = "lblSplitTotal";
            this.lblSplitTotal.Size = new System.Drawing.Size( 57, 13 );
            this.lblSplitTotal.TabIndex = 3;
            this.lblSplitTotal.Text = "Split Total:";
            // 
            // lblRemainder
            // 
            this.lblRemainder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemainder.AutoSize = true;
            this.lblRemainder.Location = new System.Drawing.Point( 9, 227 );
            this.lblRemainder.Name = "lblRemainder";
            this.lblRemainder.Size = new System.Drawing.Size( 61, 13 );
            this.lblRemainder.TabIndex = 4;
            this.lblRemainder.Text = "Remainder:";
            // 
            // lblRemainderValue
            // 
            this.lblRemainderValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblRemainderValue.Location = new System.Drawing.Point( 66, 227 );
            this.lblRemainderValue.Name = "lblRemainderValue";
            this.lblRemainderValue.Size = new System.Drawing.Size( 97, 13 );
            this.lblRemainderValue.TabIndex = 5;
            this.lblRemainderValue.Text = "$0.00";
            this.lblRemainderValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSplitTotalValue
            // 
            this.lblSplitTotalValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSplitTotalValue.Location = new System.Drawing.Point( 66, 204 );
            this.lblSplitTotalValue.Name = "lblSplitTotalValue";
            this.lblSplitTotalValue.Size = new System.Drawing.Size( 97, 13 );
            this.lblSplitTotalValue.TabIndex = 6;
            this.lblSplitTotalValue.Text = "$0.00";
            this.lblSplitTotalValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSplitTotalValue.TextChanged += new System.EventHandler( this.payment_TextChanged );
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point( 377, 220 );
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size( 75, 23 );
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler( this.btnOK_Click );
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point( 458, 220 );
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size( 75, 23 );
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // grpLine
            // 
            this.grpLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpLine.Location = new System.Drawing.Point( 91, 221 );
            this.grpLine.MaximumSize = new System.Drawing.Size( 70, 3 );
            this.grpLine.Name = "grpLine";
            this.grpLine.Size = new System.Drawing.Size( 70, 3 );
            this.grpLine.TabIndex = 13;
            this.grpLine.TabStop = false;
            // 
            // lblReceivedDate
            // 
            this.lblReceivedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReceivedDate.AutoSize = true;
            this.lblReceivedDate.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblReceivedDate.Location = new System.Drawing.Point( 377, 18 );
            this.lblReceivedDate.Name = "lblReceivedDate";
            this.lblReceivedDate.Size = new System.Drawing.Size( 65, 13 );
            this.lblReceivedDate.TabIndex = 15;
            this.lblReceivedDate.Text = "Received:";
            // 
            // dtpReceivedDate
            // 
            this.dtpReceivedDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpReceivedDate.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.dtpReceivedDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReceivedDate.Location = new System.Drawing.Point( 439, 14 );
            this.dtpReceivedDate.Name = "dtpReceivedDate";
            this.dtpReceivedDate.Size = new System.Drawing.Size( 99, 20 );
            this.dtpReceivedDate.TabIndex = 0;
            // 
            // txtAmount
            // 
            this.txtAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAmount.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.txtAmount.Location = new System.Drawing.Point( 439, 45 );
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size( 99, 20 );
            this.txtAmount.TabIndex = 1;
            this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAmount.KeyDown += new System.Windows.Forms.KeyEventHandler( this.txtAmount_KeyDown );
            this.txtAmount.Validating += new System.ComponentModel.CancelEventHandler( this.txtAmount_Validating );
            // 
            // grpSplitPayments
            // 
            this.grpSplitPayments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSplitPayments.Controls.Add( this.dgvPayments );
            this.grpSplitPayments.Location = new System.Drawing.Point( 4, 75 );
            this.grpSplitPayments.Name = "grpSplitPayments";
            this.grpSplitPayments.Size = new System.Drawing.Size( 537, 113 );
            this.grpSplitPayments.TabIndex = 17;
            this.grpSplitPayments.TabStop = false;
            this.grpSplitPayments.Text = "Split Payment";
            // 
            // dgvPayments
            // 
            this.dgvPayments.AllowUserToAddRows = false;
            this.dgvPayments.AllowUserToDeleteRows = false;
            this.dgvPayments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPayments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPayments.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPayments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPayments.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.plan,
            this.feetype,
            this.total,
            this.paid,
            this.remaining,
            this.apply} );
            this.dgvPayments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPayments.Location = new System.Drawing.Point( 3, 16 );
            this.dgvPayments.Name = "dgvPayments";
            this.dgvPayments.RowHeadersVisible = false;
            this.dgvPayments.Size = new System.Drawing.Size( 531, 94 );
            this.dgvPayments.TabIndex = 17;
            // 
            // plan
            // 
            this.plan.DataPropertyName = "plan";
            this.plan.HeaderText = "Plan";
            this.plan.Name = "plan";
            this.plan.ReadOnly = true;
            this.plan.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // feetype
            // 
            this.feetype.DataPropertyName = "feetype";
            this.feetype.HeaderText = "Fee Type";
            this.feetype.Name = "feetype";
            this.feetype.ReadOnly = true;
            this.feetype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // total
            // 
            this.total.DataPropertyName = "total";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "c2";
            this.total.DefaultCellStyle = dataGridViewCellStyle5;
            this.total.HeaderText = "Owed";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // paid
            // 
            this.paid.DataPropertyName = "paid";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "c2";
            this.paid.DefaultCellStyle = dataGridViewCellStyle6;
            this.paid.HeaderText = "Paid";
            this.paid.Name = "paid";
            this.paid.ReadOnly = true;
            this.paid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // remaining
            // 
            this.remaining.DataPropertyName = "remaining";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "c2";
            this.remaining.DefaultCellStyle = dataGridViewCellStyle7;
            this.remaining.HeaderText = "Balance";
            this.remaining.Name = "remaining";
            this.remaining.ReadOnly = true;
            this.remaining.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // apply
            // 
            this.apply.DataPropertyName = "apply";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "c2";
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.apply.DefaultCellStyle = dataGridViewCellStyle8;
            this.apply.HeaderText = "Apply To";
            this.apply.Name = "apply";
            this.apply.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstructions.Location = new System.Drawing.Point( 13, 13 );
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size( 323, 49 );
            this.lblInstructions.TabIndex = 18;
            this.lblInstructions.Text = "Enter the total payment amount and press enter to auto apply the payment to plan " +
                "fees.  Split lines may then be edited individually.";
            // 
            // frmPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 545, 251 );
            this.Controls.Add( this.lblInstructions );
            this.Controls.Add( this.grpSplitPayments );
            this.Controls.Add( this.txtAmount );
            this.Controls.Add( this.dtpReceivedDate );
            this.Controls.Add( this.lblReceivedDate );
            this.Controls.Add( this.grpLine );
            this.Controls.Add( this.btnCancel );
            this.Controls.Add( this.btnOK );
            this.Controls.Add( this.lblSplitTotalValue );
            this.Controls.Add( this.lblRemainderValue );
            this.Controls.Add( this.lblRemainder );
            this.Controls.Add( this.lblSplitTotal );
            this.Controls.Add( this.lblPaymentAmount );
            this.DoubleBuffered = true;
            this.Icon = global::county.feecollections.Properties.Resources.payment;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPayment";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment";
            ((System.ComponentModel.ISupportInitialize)(this.bindingPayments)).EndInit();
            this.grpSplitPayments.ResumeLayout( false );
            ((System.ComponentModel.ISupportInitialize)(this.dgvPayments)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Label lblPaymentAmount;
        private System.Windows.Forms.Label lblSplitTotal;
        private System.Windows.Forms.Label lblRemainder;
        private System.Windows.Forms.Label lblRemainderValue;
        private System.Windows.Forms.Label lblSplitTotalValue;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpLine;
        private System.Windows.Forms.Label lblReceivedDate;
        private System.Windows.Forms.DateTimePicker dtpReceivedDate;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.BindingSource bindingPayments;
        private System.Windows.Forms.GroupBox grpSplitPayments;
        private System.Windows.Forms.DataGridView dgvPayments;
        private System.Windows.Forms.DataGridViewTextBoxColumn plan;
        private System.Windows.Forms.DataGridViewTextBoxColumn feetype;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn paid;
        private System.Windows.Forms.DataGridViewTextBoxColumn remaining;
        private System.Windows.Forms.DataGridViewTextBoxColumn apply;
        private System.Windows.Forms.Label lblInstructions;
    }
}
