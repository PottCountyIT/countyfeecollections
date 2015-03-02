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
    partial class frmPaymentArrangementTypes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmPaymentArrangementTypes ) );
            
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingPaymentArrangementTypes = new System.Windows.Forms.BindingSource( this.components );
            this.mnuPaymentArrangementType = new System.Windows.Forms.BindingNavigator( this.components );
            this.mnuPaymentArrangementTypeNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPaymentArrangementTypeRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuPaymentArrangementTypeRefresh = new System.Windows.Forms.ToolStripButton();
            this.mnuPaymentArrangementTypeSave = new System.Windows.Forms.ToolStripButton();
            this.mnuPaymentArrangementTypeCancel = new System.Windows.Forms.ToolStripButton();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvPaymentArrangementTypesClmPaymentArrangementTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dgvPaymentArrangementTypes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingPaymentArrangementTypes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuPaymentArrangementType)).BeginInit();
            this.mnuPaymentArrangementType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvPaymentArrangementTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingPaymentArrangementTypes
            // 
            this.bindingPaymentArrangementTypes.DataSource = typeof( county.feecollections.PaymentArrangementType );
            // 
            // mnuPaymentArrangementType
            // 
            this.mnuPaymentArrangementType.AddNewItem = null;
            this.mnuPaymentArrangementType.CountItem = null;
            this.mnuPaymentArrangementType.DeleteItem = null;
            this.mnuPaymentArrangementType.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuPaymentArrangementType.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.mnuPaymentArrangementTypeNew,
            this.toolStripSeparator1,
            this.mnuPaymentArrangementTypeRemove,
            this.mnuPaymentArrangementTypeRefresh,
            this.mnuPaymentArrangementTypeSave,
            this.mnuPaymentArrangementTypeCancel} );
            this.mnuPaymentArrangementType.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuPaymentArrangementType.Location = new System.Drawing.Point( 0, 0 );
            this.mnuPaymentArrangementType.MoveFirstItem = null;
            this.mnuPaymentArrangementType.MoveLastItem = null;
            this.mnuPaymentArrangementType.MoveNextItem = null;
            this.mnuPaymentArrangementType.MovePreviousItem = null;
            this.mnuPaymentArrangementType.Name = "mnuPaymentArrangementType";
            this.mnuPaymentArrangementType.PositionItem = null;
            this.mnuPaymentArrangementType.Size = new System.Drawing.Size( 376, 25 );
            this.mnuPaymentArrangementType.TabIndex = 22;
            this.mnuPaymentArrangementType.Text = "mnu";
            // 
            // mnuPaymentArrangementTypeNew
            // 
            this.mnuPaymentArrangementTypeNew.Image = ((System.Drawing.Image)(resources.GetObject( "mnuPaymentArrangementTypeNew.Image" )));
            this.mnuPaymentArrangementTypeNew.Name = "mnuPaymentArrangementTypeNew";
            this.mnuPaymentArrangementTypeNew.RightToLeftAutoMirrorImage = true;
            this.mnuPaymentArrangementTypeNew.Size = new System.Drawing.Size( 51, 22 );
            this.mnuPaymentArrangementTypeNew.Text = "&New";
            this.mnuPaymentArrangementTypeNew.Click += new System.EventHandler( this.mnuPaymentArrangementType_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 25 );
            // 
            // mnuPaymentArrangementTypeRemove
            // 
            this.mnuPaymentArrangementTypeRemove.Enabled = false;
            this.mnuPaymentArrangementTypeRemove.Image = ((System.Drawing.Image)(resources.GetObject( "mnuPaymentArrangementTypeRemove.Image" )));
            this.mnuPaymentArrangementTypeRemove.Name = "mnuPaymentArrangementTypeRemove";
            this.mnuPaymentArrangementTypeRemove.RightToLeftAutoMirrorImage = true;
            this.mnuPaymentArrangementTypeRemove.Size = new System.Drawing.Size( 70, 22 );
            this.mnuPaymentArrangementTypeRemove.Text = "&Remove";
            this.mnuPaymentArrangementTypeRemove.Click += new System.EventHandler( this.mnuPaymentArrangementType_Click );
            // 
            // mnuPaymentArrangementTypeRefresh
            // 
            this.mnuPaymentArrangementTypeRefresh.Enabled = false;
            this.mnuPaymentArrangementTypeRefresh.Image = ((System.Drawing.Image)(resources.GetObject( "mnuPaymentArrangementTypeRefresh.Image" )));
            this.mnuPaymentArrangementTypeRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPaymentArrangementTypeRefresh.Name = "mnuPaymentArrangementTypeRefresh";
            this.mnuPaymentArrangementTypeRefresh.Size = new System.Drawing.Size( 66, 22 );
            this.mnuPaymentArrangementTypeRefresh.Text = "Re&fresh";
            this.mnuPaymentArrangementTypeRefresh.Click += new System.EventHandler( this.mnuPaymentArrangementType_Click );
            // 
            // mnuPaymentArrangementTypeSave
            // 
            this.mnuPaymentArrangementTypeSave.Enabled = false;
            this.mnuPaymentArrangementTypeSave.Image = ((System.Drawing.Image)(resources.GetObject( "mnuPaymentArrangementTypeSave.Image" )));
            this.mnuPaymentArrangementTypeSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPaymentArrangementTypeSave.Name = "mnuPaymentArrangementTypeSave";
            this.mnuPaymentArrangementTypeSave.Size = new System.Drawing.Size( 51, 22 );
            this.mnuPaymentArrangementTypeSave.Text = "&Save";
            this.mnuPaymentArrangementTypeSave.Click += new System.EventHandler( this.mnuPaymentArrangementType_Click );
            // 
            // mnuPaymentArrangementTypeCancel
            // 
            this.mnuPaymentArrangementTypeCancel.Enabled = false;
            this.mnuPaymentArrangementTypeCancel.Image = ((System.Drawing.Image)(resources.GetObject( "mnuPaymentArrangementTypeCancel.Image" )));
            this.mnuPaymentArrangementTypeCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuPaymentArrangementTypeCancel.Name = "mnuPaymentArrangementTypeCancel";
            this.mnuPaymentArrangementTypeCancel.Size = new System.Drawing.Size( 63, 22 );
            this.mnuPaymentArrangementTypeCancel.Text = "&Cancel";
            this.mnuPaymentArrangementTypeCancel.Click += new System.EventHandler( this.mnuPaymentArrangementType_Click );
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point( 289, 308 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // dgvPaymentArrangementTypesClmPaymentArrangementTypeName
            // 
            this.dgvPaymentArrangementTypesClmPaymentArrangementTypeName.DataPropertyName = "PaymentArrangementTypeName";
            this.dgvPaymentArrangementTypesClmPaymentArrangementTypeName.HeaderText = "Payment Arrangement ";
            this.dgvPaymentArrangementTypesClmPaymentArrangementTypeName.Name = "dgvPaymentArrangementTypesClmPaymentArrangementTypeName";
            // 
            // dgvPaymentArrangementTypes
            // 
            dgvPaymentArrangementTypes.AllowUserToAddRows = false;
            dgvPaymentArrangementTypes.AllowUserToDeleteRows = false;
            dgvPaymentArrangementTypes.AllowUserToResizeRows = false;
            dgvPaymentArrangementTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dgvPaymentArrangementTypes.AutoGenerateColumns = false;
            dgvPaymentArrangementTypes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvPaymentArrangementTypes.BackgroundColor = System.Drawing.SystemColors.Window;
            dgvPaymentArrangementTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPaymentArrangementTypes.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvPaymentArrangementTypesClmPaymentArrangementTypeName} );
            dgvPaymentArrangementTypes.DataSource = this.bindingPaymentArrangementTypes;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvPaymentArrangementTypes.DefaultCellStyle = dataGridViewCellStyle1;
            dgvPaymentArrangementTypes.Location = new System.Drawing.Point( 0, 30 );
            dgvPaymentArrangementTypes.MultiSelect = false;
            dgvPaymentArrangementTypes.Name = "dgvPaymentArrangementTypes";
            dgvPaymentArrangementTypes.RowHeadersVisible = false;
            dgvPaymentArrangementTypes.Size = new System.Drawing.Size( 376, 274 );
            dgvPaymentArrangementTypes.StandardTab = true;
            dgvPaymentArrangementTypes.TabIndex = 25;
            dgvPaymentArrangementTypes.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler( this.dgvPaymentArrangementTypes_RowValidating );
            // 
            // frmPaymentArrangementTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 376, 334 );
            this.Controls.Add( dgvPaymentArrangementTypes );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.mnuPaymentArrangementType );
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 382, 150 );
            this.Name = "frmPaymentArrangementTypes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Payment Arrangement Types Master List";
            this.Load += new System.EventHandler( this.frmPaymentArrangementTypes_Load );
            ((System.ComponentModel.ISupportInitialize)(this.bindingPaymentArrangementTypes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuPaymentArrangementType)).EndInit();
            this.mnuPaymentArrangementType.ResumeLayout( false );
            this.mnuPaymentArrangementType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(dgvPaymentArrangementTypes)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.DataGridView dgvPaymentArrangementTypes;
        private System.Windows.Forms.BindingNavigator mnuPaymentArrangementType;
        private System.Windows.Forms.ToolStripButton mnuPaymentArrangementTypeNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuPaymentArrangementTypeRemove;
        private System.Windows.Forms.ToolStripButton mnuPaymentArrangementTypeRefresh;
        private System.Windows.Forms.ToolStripButton mnuPaymentArrangementTypeSave;
        private System.Windows.Forms.ToolStripButton mnuPaymentArrangementTypeCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingSource bindingPaymentArrangementTypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPaymentArrangementTypesClmPaymentArrangementTypeName;
    }
}
