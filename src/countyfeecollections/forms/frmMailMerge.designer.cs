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
    partial class frmMailMerge
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode( "First Name" );
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode( "Last Name" );
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode( "Street1" );
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode( "Street2" );
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode( "City" );
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode( "State" );
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode( "Zip" );
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode( "Plan Name" );
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode( "Cases" );
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode( "Plans", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9} );
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnClose = new System.Windows.Forms.Button();
            this.grpDocument = new System.Windows.Forms.GroupBox();
            this.btnCloseDoc = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lblCurrentlySelectedValue = new System.Windows.Forms.Label();
            this.btnStoreDoc = new System.Windows.Forms.Button();
            this.lblCurrentlySelected = new System.Windows.Forms.Label();
            this.btnOpenDoc = new System.Windows.Forms.Button();
            this.grpMailMergeFields = new System.Windows.Forms.GroupBox();
            this.trvDefendant = new System.Windows.Forms.TreeView();
            this.cmsDocumentOpen = new System.Windows.Forms.ContextMenuStrip( this.components );
            this.cmsDocumentOpenNew = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDocumentOpenExisting = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsDocumentOpenStored = new System.Windows.Forms.ToolStripMenuItem();
            this.grpDocument.SuspendLayout();
            this.grpMailMergeFields.SuspendLayout();
            this.cmsDocumentOpen.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point( 251, 291 );
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size( 75, 23 );
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler( this.btnClose_Click );
            // 
            // grpDocument
            // 
            this.grpDocument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDocument.Controls.Add( this.lblCurrentlySelectedValue );
            this.grpDocument.Controls.Add( this.lblCurrentlySelected );
            this.grpDocument.Location = new System.Drawing.Point( 5, 3 );
            this.grpDocument.Name = "grpDocument";
            this.grpDocument.Size = new System.Drawing.Size( 321, 112 );
            this.grpDocument.TabIndex = 10;
            this.grpDocument.TabStop = false;
            this.grpDocument.Text = "Document";
            // 
            // btnCloseDoc
            // 
            this.btnCloseDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseDoc.Location = new System.Drawing.Point( 9, 48 );
            this.btnCloseDoc.Name = "btnCloseDoc";
            this.btnCloseDoc.Size = new System.Drawing.Size( 91, 23 );
            this.btnCloseDoc.TabIndex = 11;
            this.btnCloseDoc.Text = "Close";
            this.btnCloseDoc.UseVisualStyleBackColor = true;
            this.btnCloseDoc.Click += new System.EventHandler( this.btnCloseDoc_Click );
            // 
            // btnPreview
            // 
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Location = new System.Drawing.Point( 9, 109 );
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size( 91, 26 );
            this.btnPreview.TabIndex = 7;
            this.btnPreview.Text = "Preview";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler( this.btnPreview_Click );
            // 
            // lblCurrentlySelectedValue
            // 
            this.lblCurrentlySelectedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentlySelectedValue.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblCurrentlySelectedValue.Location = new System.Drawing.Point( 7, 57 );
            this.lblCurrentlySelectedValue.Name = "lblCurrentlySelectedValue";
            this.lblCurrentlySelectedValue.Size = new System.Drawing.Size( 306, 52 );
            this.lblCurrentlySelectedValue.TabIndex = 17;
            this.lblCurrentlySelectedValue.Text = "None";
            this.lblCurrentlySelectedValue.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnStoreDoc
            // 
            this.btnStoreDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStoreDoc.Location = new System.Drawing.Point( 9, 77 );
            this.btnStoreDoc.Name = "btnStoreDoc";
            this.btnStoreDoc.Size = new System.Drawing.Size( 91, 26 );
            this.btnStoreDoc.TabIndex = 8;
            this.btnStoreDoc.Text = "Store Template";
            this.btnStoreDoc.UseVisualStyleBackColor = true;
            this.btnStoreDoc.Click += new System.EventHandler( this.btnStoreDoc_Click );
            // 
            // lblCurrentlySelected
            // 
            this.lblCurrentlySelected.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCurrentlySelected.AutoSize = true;
            this.lblCurrentlySelected.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)) );
            this.lblCurrentlySelected.Location = new System.Drawing.Point( 103, 26 );
            this.lblCurrentlySelected.Name = "lblCurrentlySelected";
            this.lblCurrentlySelected.Size = new System.Drawing.Size( 120, 13 );
            this.lblCurrentlySelected.TabIndex = 16;
            this.lblCurrentlySelected.Text = "Currently Managing:";
            // 
            // btnOpenDoc
            // 
            this.btnOpenDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDoc.Location = new System.Drawing.Point( 9, 19 );
            this.btnOpenDoc.Name = "btnOpenDoc";
            this.btnOpenDoc.Size = new System.Drawing.Size( 91, 23 );
            this.btnOpenDoc.TabIndex = 10;
            this.btnOpenDoc.Text = "Open";
            this.btnOpenDoc.UseVisualStyleBackColor = true;
            this.btnOpenDoc.Click += new System.EventHandler( this.btnOpenDoc_Click );
            // 
            // grpMailMergeFields
            // 
            this.grpMailMergeFields.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMailMergeFields.Controls.Add( this.trvDefendant );
            this.grpMailMergeFields.Controls.Add( this.btnCloseDoc );
            this.grpMailMergeFields.Controls.Add( this.btnOpenDoc );
            this.grpMailMergeFields.Controls.Add( this.btnStoreDoc );
            this.grpMailMergeFields.Controls.Add( this.btnPreview );
            this.grpMailMergeFields.Location = new System.Drawing.Point( 5, 121 );
            this.grpMailMergeFields.Name = "grpMailMergeFields";
            this.grpMailMergeFields.Size = new System.Drawing.Size( 321, 167 );
            this.grpMailMergeFields.TabIndex = 11;
            this.grpMailMergeFields.TabStop = false;
            this.grpMailMergeFields.Text = "Mail Merge Fields";
            // 
            // trvDefendant
            // 
            this.trvDefendant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvDefendant.Location = new System.Drawing.Point( 109, 19 );
            this.trvDefendant.Name = "trvDefendant";
            treeNode1.Name = "nodFirstName";
            treeNode1.Text = "First Name";
            treeNode2.Name = "nodLastName";
            treeNode2.Text = "Last Name";
            treeNode3.Name = "nodStreet1";
            treeNode3.Text = "Street1";
            treeNode4.Name = "nodStreet2";
            treeNode4.Text = "Street2";
            treeNode5.Name = "nodCity";
            treeNode5.Text = "City";
            treeNode6.Name = "nodState";
            treeNode6.Text = "State";
            treeNode7.Name = "nodZip";
            treeNode7.Text = "Zip";
            treeNode8.Name = "nodPlanName";
            treeNode8.Text = "Plan Name";
            treeNode9.Name = "nodCases";
            treeNode9.Text = "Cases";
            treeNode10.Name = "nodPlans";
            treeNode10.Text = "Plans";
            this.trvDefendant.Nodes.AddRange( new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode10} );
            this.trvDefendant.ShowNodeToolTips = true;
            this.trvDefendant.Size = new System.Drawing.Size( 205, 136 );
            this.trvDefendant.TabIndex = 6;
            this.trvDefendant.DoubleClick += new System.EventHandler( this.trvDefendant_DoubleClick );
            // 
            // cmsDocumentOpen
            // 
            this.cmsDocumentOpen.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.cmsDocumentOpenNew,
            this.cmsDocumentOpenExisting,
            this.cmsDocumentOpenStored} );
            this.cmsDocumentOpen.Name = "cmsDocumentOpen";
            this.cmsDocumentOpen.ShowImageMargin = false;
            this.cmsDocumentOpen.Size = new System.Drawing.Size( 149, 70 );
            this.cmsDocumentOpen.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler( this.cmsDocumentOpen_ItemClicked );
            // 
            // cmsDocumentOpenNew
            // 
            this.cmsDocumentOpenNew.Name = "cmsDocumentOpenNew";
            this.cmsDocumentOpenNew.Size = new System.Drawing.Size( 148, 22 );
            this.cmsDocumentOpenNew.Text = "New Document";
            this.cmsDocumentOpenNew.ToolTipText = "Opens a new MS Word Document";
            // 
            // cmsDocumentOpenExisting
            // 
            this.cmsDocumentOpenExisting.Name = "cmsDocumentOpenExisting";
            this.cmsDocumentOpenExisting.Size = new System.Drawing.Size( 148, 22 );
            this.cmsDocumentOpenExisting.Text = "Existing Document";
            this.cmsDocumentOpenExisting.ToolTipText = "Opens a File Dialog to select any exisitng document";
            // 
            // cmsDocumentOpenStored
            // 
            this.cmsDocumentOpenStored.Checked = true;
            this.cmsDocumentOpenStored.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmsDocumentOpenStored.Name = "cmsDocumentOpenStored";
            this.cmsDocumentOpenStored.Size = new System.Drawing.Size( 148, 22 );
            this.cmsDocumentOpenStored.Text = "Stored Document";
            this.cmsDocumentOpenStored.ToolTipText = "Opens a list of stored templates";
            // 
            // frmMailMerge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 332, 316 );
            this.Controls.Add( this.grpDocument );
            this.Controls.Add( this.grpMailMergeFields );
            this.Controls.Add( this.btnClose );
            this.DoubleBuffered = true;
            this.Icon = global::county.feecollections.Properties.Resources.msword;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size( 233, 320 );
            this.Name = "frmMailMerge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MS Word MailMerge";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.frmMain_FormClosing );
            this.grpDocument.ResumeLayout( false );
            this.grpDocument.PerformLayout();
            this.grpMailMergeFields.ResumeLayout( false );
            this.cmsDocumentOpen.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grpDocument;
        private System.Windows.Forms.Button btnOpenDoc;
        private System.Windows.Forms.GroupBox grpMailMergeFields;
        private System.Windows.Forms.TreeView trvDefendant;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label lblCurrentlySelectedValue;
        private System.Windows.Forms.Label lblCurrentlySelected;
        private System.Windows.Forms.Button btnStoreDoc;
        private System.Windows.Forms.ContextMenuStrip cmsDocumentOpen;
        private System.Windows.Forms.ToolStripMenuItem cmsDocumentOpenNew;
        private System.Windows.Forms.ToolStripMenuItem cmsDocumentOpenStored;
        private System.Windows.Forms.ToolStripMenuItem cmsDocumentOpenExisting;
        private System.Windows.Forms.Button btnCloseDoc;
    }
}

