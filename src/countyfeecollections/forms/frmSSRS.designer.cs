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

    partial class frmSSRS
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
            this.reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cmbReports = new System.Windows.Forms.ComboBox();
            this.btnRender = new System.Windows.Forms.Button();
            this.lblRenderTimeValue = new System.Windows.Forms.Label();
            this.grpReportParameters = new System.Windows.Forms.GroupBox();
            this.lblNoReportParameters = new System.Windows.Forms.Label();
            this.grpCurrentReport = new System.Windows.Forms.GroupBox();
            this.lblReportNameValue = new System.Windows.Forms.Label();
            this.lblGenerated = new System.Windows.Forms.Label();
            this.lblRenderTime = new System.Windows.Forms.Label();
            this.lblGeneratedValue = new System.Windows.Forms.Label();
            this.lblReportName = new System.Windows.Forms.Label();
            this.grpReportParameters.SuspendLayout();
            this.grpCurrentReport.SuspendLayout();
            this.SuspendLayout();
            // 
            // reportViewer
            // 
            this.reportViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer.Location = new System.Drawing.Point(1, 173);
            this.reportViewer.Name = "reportViewer";
            this.reportViewer.Size = new System.Drawing.Size(1008, 559);
            this.reportViewer.TabIndex = 0;
            // 
            // cmbReports
            // 
            this.cmbReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbReports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReports.FormattingEnabled = true;
            this.cmbReports.Location = new System.Drawing.Point(12, 22);
            this.cmbReports.Name = "cmbReports";
            this.cmbReports.Size = new System.Drawing.Size(564, 21);
            this.cmbReports.TabIndex = 1;
            this.cmbReports.SelectedIndexChanged += new System.EventHandler(this.cmbReports_SelectedIndexChanged);
            // 
            // btnRender
            // 
            this.btnRender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRender.Location = new System.Drawing.Point(582, 118);
            this.btnRender.Name = "btnRender";
            this.btnRender.Size = new System.Drawing.Size(414, 49);
            this.btnRender.TabIndex = 2;
            this.btnRender.Text = "&Render";
            this.btnRender.UseVisualStyleBackColor = true;
            this.btnRender.Click += new System.EventHandler(this.btnRender_Click);
            // 
            // lblRenderTimeValue
            // 
            this.lblRenderTimeValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRenderTimeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenderTimeValue.Location = new System.Drawing.Point(100, 71);
            this.lblRenderTimeValue.Name = "lblRenderTimeValue";
            this.lblRenderTimeValue.Size = new System.Drawing.Size(299, 13);
            this.lblRenderTimeValue.TabIndex = 3;
            // 
            // grpReportParameters
            // 
            this.grpReportParameters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReportParameters.Controls.Add(this.lblNoReportParameters);
            this.grpReportParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpReportParameters.Location = new System.Drawing.Point(12, 49);
            this.grpReportParameters.Name = "grpReportParameters";
            this.grpReportParameters.Size = new System.Drawing.Size(564, 118);
            this.grpReportParameters.TabIndex = 6;
            this.grpReportParameters.TabStop = false;
            this.grpReportParameters.Text = "Report Parameters";
            // 
            // lblNoReportParameters
            // 
            this.lblNoReportParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoReportParameters.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoReportParameters.Location = new System.Drawing.Point(3, 16);
            this.lblNoReportParameters.Name = "lblNoReportParameters";
            this.lblNoReportParameters.Size = new System.Drawing.Size(558, 99);
            this.lblNoReportParameters.TabIndex = 0;
            this.lblNoReportParameters.Text = "The selected report has no configurable parameters.";
            this.lblNoReportParameters.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpCurrentReport
            // 
            this.grpCurrentReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCurrentReport.Controls.Add(this.lblReportNameValue);
            this.grpCurrentReport.Controls.Add(this.lblGenerated);
            this.grpCurrentReport.Controls.Add(this.lblRenderTime);
            this.grpCurrentReport.Controls.Add(this.lblGeneratedValue);
            this.grpCurrentReport.Controls.Add(this.lblReportName);
            this.grpCurrentReport.Controls.Add(this.lblRenderTimeValue);
            this.grpCurrentReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCurrentReport.Location = new System.Drawing.Point(582, 20);
            this.grpCurrentReport.Name = "grpCurrentReport";
            this.grpCurrentReport.Size = new System.Drawing.Size(414, 94);
            this.grpCurrentReport.TabIndex = 7;
            this.grpCurrentReport.TabStop = false;
            this.grpCurrentReport.Text = "Displayed Report Information";
            // 
            // lblReportNameValue
            // 
            this.lblReportNameValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblReportNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportNameValue.Location = new System.Drawing.Point(100, 21);
            this.lblReportNameValue.Name = "lblReportNameValue";
            this.lblReportNameValue.Size = new System.Drawing.Size(299, 13);
            this.lblReportNameValue.TabIndex = 5;
            // 
            // lblGenerated
            // 
            this.lblGenerated.AutoSize = true;
            this.lblGenerated.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenerated.Location = new System.Drawing.Point(34, 46);
            this.lblGenerated.Name = "lblGenerated";
            this.lblGenerated.Size = new System.Drawing.Size(60, 13);
            this.lblGenerated.TabIndex = 8;
            this.lblGenerated.Text = "Generated:";
            // 
            // lblRenderTime
            // 
            this.lblRenderTime.AutoSize = true;
            this.lblRenderTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenderTime.Location = new System.Drawing.Point(11, 71);
            this.lblRenderTime.Name = "lblRenderTime";
            this.lblRenderTime.Size = new System.Drawing.Size(83, 13);
            this.lblRenderTime.TabIndex = 7;
            this.lblRenderTime.Text = "Time to Render:";
            // 
            // lblGeneratedValue
            // 
            this.lblGeneratedValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGeneratedValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeneratedValue.Location = new System.Drawing.Point(100, 46);
            this.lblGeneratedValue.Name = "lblGeneratedValue";
            this.lblGeneratedValue.Size = new System.Drawing.Size(299, 13);
            this.lblGeneratedValue.TabIndex = 6;
            // 
            // lblReportName
            // 
            this.lblReportName.AutoSize = true;
            this.lblReportName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportName.Location = new System.Drawing.Point(21, 21);
            this.lblReportName.Name = "lblReportName";
            this.lblReportName.Size = new System.Drawing.Size(73, 13);
            this.lblReportName.TabIndex = 4;
            this.lblReportName.Text = "Report Name:";
            // 
            // frmSSRS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 732);
            this.Controls.Add(this.grpCurrentReport);
            this.Controls.Add(this.grpReportParameters);
            this.Controls.Add(this.btnRender);
            this.Controls.Add(this.cmbReports);
            this.Controls.Add(this.reportViewer);
            this.DoubleBuffered = true;
            this.Icon = global::county.feecollections.Properties.Resources.feecollection;
            this.Name = "frmSSRS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fee Collections SSRS Reports";
            this.grpReportParameters.ResumeLayout(false);
            this.grpCurrentReport.ResumeLayout(false);
            this.grpCurrentReport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer;
        private System.Windows.Forms.ComboBox cmbReports;
        private System.Windows.Forms.Button btnRender;
        private System.Windows.Forms.Label lblRenderTimeValue;
        private System.Windows.Forms.GroupBox grpReportParameters;
        private System.Windows.Forms.GroupBox grpCurrentReport;
        private System.Windows.Forms.Label lblGenerated;
        private System.Windows.Forms.Label lblRenderTime;
        private System.Windows.Forms.Label lblGeneratedValue;
        private System.Windows.Forms.Label lblReportNameValue;
        private System.Windows.Forms.Label lblReportName;
        private System.Windows.Forms.Label lblNoReportParameters;
    }
}

