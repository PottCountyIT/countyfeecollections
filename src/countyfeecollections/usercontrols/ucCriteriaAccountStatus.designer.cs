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
    partial class ucCriteriaAccountStatus
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
            this.dtpAccountStatus = new System.Windows.Forms.DateTimePicker();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dtpAccountStatus
            // 
            this.dtpAccountStatus.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpAccountStatus.Location = new System.Drawing.Point(16, 42);
            this.dtpAccountStatus.Name = "dtpAccountStatus";
            this.dtpAccountStatus.Size = new System.Drawing.Size(141, 20);
            this.dtpAccountStatus.TabIndex = 0;
            // 
            // lblInstructions
            // 
            this.lblInstructions.AutoSize = true;
            this.lblInstructions.Location = new System.Drawing.Point(13, 16);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(201, 13);
            this.lblInstructions.TabIndex = 1;
            this.lblInstructions.Text = "Calculate Account Status at point in time:";
            // 
            // ucCriteriaAccountStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblInstructions);
            this.Controls.Add(this.dtpAccountStatus);
            this.Name = "ucCriteriaAccountStatus";
            this.Size = new System.Drawing.Size(247, 163);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpAccountStatus;
        private System.Windows.Forms.Label lblInstructions;
    }
}
