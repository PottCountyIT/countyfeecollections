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
    partial class frmFeeTypes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmFeeTypes ) );
            this.dgvFeeTypes = new System.Windows.Forms.DataGridView();
            this.dgvFeeTypesClmPaymentOrder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvFeeTypesClmBillable = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.mnuFeeType = new System.Windows.Forms.BindingNavigator( this.components );
            this.mnuFeeTypeNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFeeTypeRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuFeeTypeRefresh = new System.Windows.Forms.ToolStripButton();
            this.mnuFeeTypeSave = new System.Windows.Forms.ToolStripButton();
            this.mnuFeeTypeCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFeeTypeHelp = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvFeeTypesClmFeeTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingFeeTypes = new System.Windows.Forms.BindingSource( this.components );
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuFeeType)).BeginInit();
            this.mnuFeeType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFeeTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFeeTypes
            // 
            this.dgvFeeTypes.AllowUserToAddRows = false;
            this.dgvFeeTypes.AllowUserToDeleteRows = false;
            this.dgvFeeTypes.AllowUserToResizeRows = false;
            this.dgvFeeTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFeeTypes.AutoGenerateColumns = false;
            this.dgvFeeTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFeeTypes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvFeeTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeeTypes.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvFeeTypesClmFeeTypeName,
            this.dgvFeeTypesClmPaymentOrder,
            this.dgvFeeTypesClmBillable} );
            this.dgvFeeTypes.DataSource = this.bindingFeeTypes;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFeeTypes.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFeeTypes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvFeeTypes.Location = new System.Drawing.Point( 0, 28 );
            this.dgvFeeTypes.MultiSelect = false;
            this.dgvFeeTypes.Name = "dgvFeeTypes";
            this.dgvFeeTypes.RowHeadersVisible = false;
            this.dgvFeeTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFeeTypes.Size = new System.Drawing.Size( 366, 256 );
            this.dgvFeeTypes.StandardTab = true;
            this.dgvFeeTypes.TabIndex = 0;
            this.dgvFeeTypes.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler( this.dgvFeeTypes_RowValidating );
            // 
            // dgvFeeTypesClmPaymentOrder
            // 
            this.dgvFeeTypesClmPaymentOrder.DataPropertyName = "PaymentOrder";
            this.dgvFeeTypesClmPaymentOrder.HeaderText = "PaymentOrder";
            this.dgvFeeTypesClmPaymentOrder.Name = "dgvFeeTypesClmPaymentOrder";
            // 
            // dgvFeeTypesClmBillable
            // 
            this.dgvFeeTypesClmBillable.DataPropertyName = "Billable";
            this.dgvFeeTypesClmBillable.HeaderText = "Billable";
            this.dgvFeeTypesClmBillable.Name = "dgvFeeTypesClmBillable";
            this.dgvFeeTypesClmBillable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // mnuFeeType
            // 
            this.mnuFeeType.AddNewItem = null;
            this.mnuFeeType.CountItem = null;
            this.mnuFeeType.DeleteItem = null;
            this.mnuFeeType.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuFeeType.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.mnuFeeTypeNew,
            this.toolStripSeparator1,
            this.mnuFeeTypeRemove,
            this.mnuFeeTypeRefresh,
            this.mnuFeeTypeSave,
            this.mnuFeeTypeCancel,
            this.toolStripSeparator,
            this.mnuFeeTypeHelp} );
            this.mnuFeeType.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuFeeType.Location = new System.Drawing.Point( 0, 0 );
            this.mnuFeeType.MoveFirstItem = null;
            this.mnuFeeType.MoveLastItem = null;
            this.mnuFeeType.MoveNextItem = null;
            this.mnuFeeType.MovePreviousItem = null;
            this.mnuFeeType.Name = "mnuFeeType";
            this.mnuFeeType.PositionItem = null;
            this.mnuFeeType.Size = new System.Drawing.Size( 366, 25 );
            this.mnuFeeType.TabIndex = 22;
            this.mnuFeeType.Text = "mnuFeeType";
            // 
            // mnuFeeTypeNew
            // 
            this.mnuFeeTypeNew.Image = ((System.Drawing.Image)(resources.GetObject( "mnuFeeTypeNew.Image" )));
            this.mnuFeeTypeNew.Name = "mnuFeeTypeNew";
            this.mnuFeeTypeNew.RightToLeftAutoMirrorImage = true;
            this.mnuFeeTypeNew.Size = new System.Drawing.Size( 51, 22 );
            this.mnuFeeTypeNew.Text = "&New";
            this.mnuFeeTypeNew.Click += new System.EventHandler( this.mnuFeeType_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 25 );
            // 
            // mnuFeeTypeRemove
            // 
            this.mnuFeeTypeRemove.Enabled = false;
            this.mnuFeeTypeRemove.Image = ((System.Drawing.Image)(resources.GetObject( "mnuFeeTypeRemove.Image" )));
            this.mnuFeeTypeRemove.Name = "mnuFeeTypeRemove";
            this.mnuFeeTypeRemove.RightToLeftAutoMirrorImage = true;
            this.mnuFeeTypeRemove.Size = new System.Drawing.Size( 70, 22 );
            this.mnuFeeTypeRemove.Text = "&Remove";
            this.mnuFeeTypeRemove.Click += new System.EventHandler( this.mnuFeeType_Click );
            // 
            // mnuFeeTypeRefresh
            // 
            this.mnuFeeTypeRefresh.Enabled = false;
            this.mnuFeeTypeRefresh.Image = ((System.Drawing.Image)(resources.GetObject( "mnuFeeTypeRefresh.Image" )));
            this.mnuFeeTypeRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFeeTypeRefresh.Name = "mnuFeeTypeRefresh";
            this.mnuFeeTypeRefresh.Size = new System.Drawing.Size( 66, 22 );
            this.mnuFeeTypeRefresh.Text = "Re&fresh";
            this.mnuFeeTypeRefresh.Click += new System.EventHandler( this.mnuFeeType_Click );
            // 
            // mnuFeeTypeSave
            // 
            this.mnuFeeTypeSave.Enabled = false;
            this.mnuFeeTypeSave.Image = ((System.Drawing.Image)(resources.GetObject( "mnuFeeTypeSave.Image" )));
            this.mnuFeeTypeSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFeeTypeSave.Name = "mnuFeeTypeSave";
            this.mnuFeeTypeSave.Size = new System.Drawing.Size( 51, 22 );
            this.mnuFeeTypeSave.Text = "&Save";
            this.mnuFeeTypeSave.Click += new System.EventHandler( this.mnuFeeType_Click );
            // 
            // mnuFeeTypeCancel
            // 
            this.mnuFeeTypeCancel.Enabled = false;
            this.mnuFeeTypeCancel.Image = ((System.Drawing.Image)(resources.GetObject( "mnuFeeTypeCancel.Image" )));
            this.mnuFeeTypeCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFeeTypeCancel.Name = "mnuFeeTypeCancel";
            this.mnuFeeTypeCancel.Size = new System.Drawing.Size( 63, 22 );
            this.mnuFeeTypeCancel.Text = "&Cancel";
            this.mnuFeeTypeCancel.Click += new System.EventHandler( this.mnuFeeType_Click );
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size( 6, 25 );
            // 
            // mnuFeeTypeHelp
            // 
            this.mnuFeeTypeHelp.Enabled = false;
            this.mnuFeeTypeHelp.Image = ((System.Drawing.Image)(resources.GetObject( "mnuFeeTypeHelp.Image" )));
            this.mnuFeeTypeHelp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuFeeTypeHelp.Name = "mnuFeeTypeHelp";
            this.mnuFeeTypeHelp.Size = new System.Drawing.Size( 52, 22 );
            this.mnuFeeTypeHelp.Text = "He&lp";
            this.mnuFeeTypeHelp.Click += new System.EventHandler( this.mnuFeeType_Click );
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point( 279, 290 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // dgvFeeTypesClmFeeTypeName
            // 
            this.dgvFeeTypesClmFeeTypeName.DataPropertyName = "FeeTypeName";
            this.dgvFeeTypesClmFeeTypeName.HeaderText = "Fee Type";
            this.dgvFeeTypesClmFeeTypeName.Name = "dgvFeeTypesClmFeeTypeName";
            // 
            // bindingFeeTypes
            // 
            this.bindingFeeTypes.DataSource = typeof( county.feecollections.FeeType );
            // 
            // frmFeeTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 366, 316 );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.mnuFeeType );
            this.Controls.Add( this.dgvFeeTypes );
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 382, 150 );
            this.Name = "frmFeeTypes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Fee Types Master List";
            this.Load += new System.EventHandler( this.frmFeeTypes_Load );
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeeTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuFeeType)).EndInit();
            this.mnuFeeType.ResumeLayout( false );
            this.mnuFeeType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFeeTypes)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dgvFeeTypes;
        private System.Windows.Forms.BindingNavigator mnuFeeType;
        private System.Windows.Forms.ToolStripButton mnuFeeTypeNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuFeeTypeRemove;
        private System.Windows.Forms.ToolStripButton mnuFeeTypeRefresh;
        private System.Windows.Forms.ToolStripButton mnuFeeTypeSave;
        private System.Windows.Forms.ToolStripButton mnuFeeTypeCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton mnuFeeTypeHelp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingFeeTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFeeTypesClmFeeTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvFeeTypesClmPaymentOrder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgvFeeTypesClmBillable;
    }
}
