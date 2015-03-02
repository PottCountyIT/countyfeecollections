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
    partial class ucCriteriaSubReportCases
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
            this.lblIncludeCaseTypes = new System.Windows.Forms.Label();
            this.chkCAPP = new System.Windows.Forms.CheckBox();
            this.chkNonCAPP = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblIncludeCaseTypes
            // 
            this.lblIncludeCaseTypes.AutoSize = true;
            this.lblIncludeCaseTypes.Location = new System.Drawing.Point( 15, 15 );
            this.lblIncludeCaseTypes.Name = "lblIncludeCaseTypes";
            this.lblIncludeCaseTypes.Size = new System.Drawing.Size( 45, 13 );
            this.lblIncludeCaseTypes.TabIndex = 0;
            this.lblIncludeCaseTypes.Text = "Include:";
            // 
            // chkCAPP
            // 
            this.chkCAPP.AutoSize = true;
            this.chkCAPP.Checked = true;
            this.chkCAPP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCAPP.Location = new System.Drawing.Point( 31, 40 );
            this.chkCAPP.Name = "chkCAPP";
            this.chkCAPP.Size = new System.Drawing.Size( 85, 17 );
            this.chkCAPP.TabIndex = 1;
            this.chkCAPP.Text = "CAPP cases";
            this.chkCAPP.UseVisualStyleBackColor = true;
            // 
            // chkNonCAPP
            // 
            this.chkNonCAPP.AutoSize = true;
            this.chkNonCAPP.Checked = true;
            this.chkNonCAPP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNonCAPP.Location = new System.Drawing.Point( 31, 58 );
            this.chkNonCAPP.Name = "chkNonCAPP";
            this.chkNonCAPP.Size = new System.Drawing.Size( 105, 17 );
            this.chkNonCAPP.TabIndex = 2;
            this.chkNonCAPP.Text = "NonCAPP cases";
            this.chkNonCAPP.UseVisualStyleBackColor = true;
            // 
            // ucCriteriaSubReportCases
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add( this.chkNonCAPP );
            this.Controls.Add( this.chkCAPP );
            this.Controls.Add( this.lblIncludeCaseTypes );
            this.Name = "ucCriteriaSubReportCases";
            this.Size = new System.Drawing.Size( 193, 124 );
            this.ResumeLayout( false );
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIncludeCaseTypes;
        private System.Windows.Forms.CheckBox chkCAPP;
        private System.Windows.Forms.CheckBox chkNonCAPP;
    }
}
