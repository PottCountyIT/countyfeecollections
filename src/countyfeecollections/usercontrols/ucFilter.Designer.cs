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
    partial class ucFilter
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
            this.lblLookFor = new System.Windows.Forms.Label();
            this.lblFilteredBy = new System.Windows.Forms.Label();
            this.cmbFilteredBy = new System.Windows.Forms.ComboBox();
            this.txtLookFor = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblLookFor
            // 
            this.lblLookFor.AutoSize = true;
            this.lblLookFor.Location = new System.Drawing.Point( 4, 45 );
            this.lblLookFor.Name = "lblLookFor";
            this.lblLookFor.Size = new System.Drawing.Size( 49, 13 );
            this.lblLookFor.TabIndex = 15;
            this.lblLookFor.Text = "Look for:";
            // 
            // lblFilteredBy
            // 
            this.lblFilteredBy.AutoSize = true;
            this.lblFilteredBy.Location = new System.Drawing.Point( 4, 5 );
            this.lblFilteredBy.Name = "lblFilteredBy";
            this.lblFilteredBy.Size = new System.Drawing.Size( 58, 13 );
            this.lblFilteredBy.TabIndex = 14;
            this.lblFilteredBy.Text = "Filtered by:";
            // 
            // cmbFilteredBy
            // 
            this.cmbFilteredBy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbFilteredBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFilteredBy.FormattingEnabled = true;
            this.cmbFilteredBy.Location = new System.Drawing.Point( 4, 21 );
            this.cmbFilteredBy.Name = "cmbFilteredBy";
            this.cmbFilteredBy.Size = new System.Drawing.Size( 217, 21 );
            this.cmbFilteredBy.TabIndex = 1;
            this.cmbFilteredBy.TabStop = false;
            // 
            // txtLookFor
            // 
            this.txtLookFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookFor.Location = new System.Drawing.Point( 4, 61 );
            this.txtLookFor.Name = "txtLookFor";
            this.txtLookFor.Size = new System.Drawing.Size( 217, 20 );
            this.txtLookFor.TabIndex = 0;
            this.txtLookFor.Leave += new System.EventHandler( this.txtLookFor_Leave );
            this.txtLookFor.Enter += new System.EventHandler( this.txtLookFor_Enter );
            this.txtLookFor.MouseUp += new System.Windows.Forms.MouseEventHandler( this.txtLookFor_MouseUp );
            // 
            // ucFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.lblLookFor );
            this.Controls.Add( this.lblFilteredBy );
            this.Controls.Add( this.cmbFilteredBy );
            this.Controls.Add( this.txtLookFor );
            this.DoubleBuffered = true;
            this.Name = "ucFilter";
            this.Size = new System.Drawing.Size( 225, 87 );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLookFor;
        private System.Windows.Forms.Label lblFilteredBy;
        private System.Windows.Forms.ComboBox cmbFilteredBy;
        private System.Windows.Forms.TextBox txtLookFor;
    }
}
