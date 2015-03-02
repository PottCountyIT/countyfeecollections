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
    partial class frmRestrictedCasePrefixes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( frmRestrictedCasePrefixes ) );
            this.bindingRestrictedCasePrefixes = new System.Windows.Forms.BindingSource( this.components );
            this.btnClose = new System.Windows.Forms.Button();
            this.mnuRestrictedCasePrefixes = new System.Windows.Forms.BindingNavigator( this.components );
            this.mnuRestrictedCasePrefixesNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuRestrictedCasePrefixesRemove = new System.Windows.Forms.ToolStripButton();
            this.mnuRestrictedCasePrefixesRefresh = new System.Windows.Forms.ToolStripButton();
            this.mnuRestrictedCasePrefixesSave = new System.Windows.Forms.ToolStripButton();
            this.mnuRestrictedCasePrefixesCancel = new System.Windows.Forms.ToolStripButton();
            this.dgvRestrictedCasePrefixes = new System.Windows.Forms.DataGridView();
            this.dgvRestrictedCasePrefixesCasePrefix = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingRestrictedCasePrefixes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuRestrictedCasePrefixes)).BeginInit();
            this.mnuRestrictedCasePrefixes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestrictedCasePrefixes)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingRestrictedCasePrefixes
            // 
            this.bindingRestrictedCasePrefixes.DataSource = typeof( county.feecollections.RestrictedCasePrefix );
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnClose.Location = new System.Drawing.Point( 250, 222 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // mnuRestrictedCasePrefixes
            // 
            this.mnuRestrictedCasePrefixes.AddNewItem = null;
            this.mnuRestrictedCasePrefixes.CountItem = null;
            this.mnuRestrictedCasePrefixes.DeleteItem = null;
            this.mnuRestrictedCasePrefixes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.mnuRestrictedCasePrefixes.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.mnuRestrictedCasePrefixesNew,
            this.toolStripSeparator1,
            this.mnuRestrictedCasePrefixesRemove,
            this.mnuRestrictedCasePrefixesRefresh,
            this.mnuRestrictedCasePrefixesSave,
            this.mnuRestrictedCasePrefixesCancel} );
            this.mnuRestrictedCasePrefixes.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.mnuRestrictedCasePrefixes.Location = new System.Drawing.Point( 0, 0 );
            this.mnuRestrictedCasePrefixes.MoveFirstItem = null;
            this.mnuRestrictedCasePrefixes.MoveLastItem = null;
            this.mnuRestrictedCasePrefixes.MoveNextItem = null;
            this.mnuRestrictedCasePrefixes.MovePreviousItem = null;
            this.mnuRestrictedCasePrefixes.Name = "mnuRestrictedCasePrefixes";
            this.mnuRestrictedCasePrefixes.PositionItem = null;
            this.mnuRestrictedCasePrefixes.Size = new System.Drawing.Size( 332, 25 );
            this.mnuRestrictedCasePrefixes.TabIndex = 26;
            this.mnuRestrictedCasePrefixes.Text = "mnu";
            // 
            // mnuRestrictedCasePrefixesNew
            // 
            this.mnuRestrictedCasePrefixesNew.Image = ((System.Drawing.Image)(resources.GetObject( "mnuRestrictedCasePrefixesNew.Image" )));
            this.mnuRestrictedCasePrefixesNew.Name = "mnuRestrictedCasePrefixesNew";
            this.mnuRestrictedCasePrefixesNew.RightToLeftAutoMirrorImage = true;
            this.mnuRestrictedCasePrefixesNew.Size = new System.Drawing.Size( 51, 22 );
            this.mnuRestrictedCasePrefixesNew.Text = "&New";
            this.mnuRestrictedCasePrefixesNew.Click += new System.EventHandler( this.mnuRestrictedCasePrefixes_Click );
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size( 6, 25 );
            // 
            // mnuRestrictedCasePrefixesRemove
            // 
            this.mnuRestrictedCasePrefixesRemove.Enabled = false;
            this.mnuRestrictedCasePrefixesRemove.Image = ((System.Drawing.Image)(resources.GetObject( "mnuRestrictedCasePrefixesRemove.Image" )));
            this.mnuRestrictedCasePrefixesRemove.Name = "mnuRestrictedCasePrefixesRemove";
            this.mnuRestrictedCasePrefixesRemove.RightToLeftAutoMirrorImage = true;
            this.mnuRestrictedCasePrefixesRemove.Size = new System.Drawing.Size( 70, 22 );
            this.mnuRestrictedCasePrefixesRemove.Text = "&Remove";
            this.mnuRestrictedCasePrefixesRemove.Click += new System.EventHandler( this.mnuRestrictedCasePrefixes_Click );
            // 
            // mnuRestrictedCasePrefixesRefresh
            // 
            this.mnuRestrictedCasePrefixesRefresh.Enabled = false;
            this.mnuRestrictedCasePrefixesRefresh.Image = ((System.Drawing.Image)(resources.GetObject( "mnuRestrictedCasePrefixesRefresh.Image" )));
            this.mnuRestrictedCasePrefixesRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRestrictedCasePrefixesRefresh.Name = "mnuRestrictedCasePrefixesRefresh";
            this.mnuRestrictedCasePrefixesRefresh.Size = new System.Drawing.Size( 66, 22 );
            this.mnuRestrictedCasePrefixesRefresh.Text = "Re&fresh";
            this.mnuRestrictedCasePrefixesRefresh.Click += new System.EventHandler( this.mnuRestrictedCasePrefixes_Click );
            // 
            // mnuRestrictedCasePrefixesSave
            // 
            this.mnuRestrictedCasePrefixesSave.Enabled = false;
            this.mnuRestrictedCasePrefixesSave.Image = ((System.Drawing.Image)(resources.GetObject( "mnuRestrictedCasePrefixesSave.Image" )));
            this.mnuRestrictedCasePrefixesSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRestrictedCasePrefixesSave.Name = "mnuRestrictedCasePrefixesSave";
            this.mnuRestrictedCasePrefixesSave.Size = new System.Drawing.Size( 51, 22 );
            this.mnuRestrictedCasePrefixesSave.Text = "&Save";
            this.mnuRestrictedCasePrefixesSave.Click += new System.EventHandler( this.mnuRestrictedCasePrefixes_Click );
            // 
            // mnuRestrictedCasePrefixesCancel
            // 
            this.mnuRestrictedCasePrefixesCancel.Enabled = false;
            this.mnuRestrictedCasePrefixesCancel.Image = ((System.Drawing.Image)(resources.GetObject( "mnuRestrictedCasePrefixesCancel.Image" )));
            this.mnuRestrictedCasePrefixesCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuRestrictedCasePrefixesCancel.Name = "mnuRestrictedCasePrefixesCancel";
            this.mnuRestrictedCasePrefixesCancel.Size = new System.Drawing.Size( 63, 22 );
            this.mnuRestrictedCasePrefixesCancel.Text = "&Cancel";
            this.mnuRestrictedCasePrefixesCancel.Click += new System.EventHandler( this.mnuRestrictedCasePrefixes_Click );
            // 
            // dgvRestrictedCasePrefixes
            // 
            this.dgvRestrictedCasePrefixes.AllowUserToAddRows = false;
            this.dgvRestrictedCasePrefixes.AllowUserToDeleteRows = false;
            this.dgvRestrictedCasePrefixes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRestrictedCasePrefixes.AutoGenerateColumns = false;
            this.dgvRestrictedCasePrefixes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRestrictedCasePrefixes.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRestrictedCasePrefixes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRestrictedCasePrefixes.Columns.AddRange( new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvRestrictedCasePrefixesCasePrefix} );
            this.dgvRestrictedCasePrefixes.DataSource = this.bindingRestrictedCasePrefixes;
            this.dgvRestrictedCasePrefixes.Location = new System.Drawing.Point( 0, 28 );
            this.dgvRestrictedCasePrefixes.MultiSelect = false;
            this.dgvRestrictedCasePrefixes.Name = "dgvRestrictedCasePrefixes";
            this.dgvRestrictedCasePrefixes.RowHeadersVisible = false;
            this.dgvRestrictedCasePrefixes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRestrictedCasePrefixes.Size = new System.Drawing.Size( 332, 188 );
            this.dgvRestrictedCasePrefixes.TabIndex = 28;
            this.dgvRestrictedCasePrefixes.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler( this.dgvRestrictedCasePrefixes_RowValidating );
            // 
            // dgvRestrictedCasePrefixesCasePrefix
            // 
            this.dgvRestrictedCasePrefixesCasePrefix.DataPropertyName = "CasePrefix";
            this.dgvRestrictedCasePrefixesCasePrefix.HeaderText = "CasePrefix";
            this.dgvRestrictedCasePrefixesCasePrefix.Name = "dgvRestrictedCasePrefixesCasePrefix";
            // 
            // frmRestrictedCasePrefixes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 332, 251 );
            this.Controls.Add( this.dgvRestrictedCasePrefixes );
            this.Controls.Add( this.btnClose );
            this.Controls.Add( this.mnuRestrictedCasePrefixes );
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRestrictedCasePrefixes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Restricted Case Prefixes Master List";
            this.Load += new System.EventHandler( this.frmRestrictedCasePrefixes_Load );
            ((System.ComponentModel.ISupportInitialize)(this.bindingRestrictedCasePrefixes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mnuRestrictedCasePrefixes)).EndInit();
            this.mnuRestrictedCasePrefixes.ResumeLayout( false );
            this.mnuRestrictedCasePrefixes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRestrictedCasePrefixes)).EndInit();
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.BindingNavigator mnuRestrictedCasePrefixes;
        private System.Windows.Forms.ToolStripButton mnuRestrictedCasePrefixesNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton mnuRestrictedCasePrefixesRemove;
        private System.Windows.Forms.ToolStripButton mnuRestrictedCasePrefixesRefresh;
        private System.Windows.Forms.ToolStripButton mnuRestrictedCasePrefixesSave;
        private System.Windows.Forms.ToolStripButton mnuRestrictedCasePrefixesCancel;
        private System.Windows.Forms.BindingSource bindingRestrictedCasePrefixes;
        private System.Windows.Forms.DataGridView dgvRestrictedCasePrefixes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvRestrictedCasePrefixesCasePrefix;
    }
}
