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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace county.feecollections
{

    public partial class ucCases : UserControl
    {


        #region public ucCases()
        public ucCases()
        {

            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );
        } 
        #endregion

        #region public void SetBindingSource( ref BindingSource bindingPlans )
        public void SetBindingSource( ref BindingSource bindingPlans )
        {
            this.SuspendLayout();

            dgvCasesClmCountyId.DataSource = Helper.IowaCountyList;
            dgvCasesClmCountyId.ValueMember = "countyid";
            dgvCasesClmCountyId.DisplayMember = "county";

            this.bindingCases.DataMember = "Cases";
            this.bindingCases.DataSource = bindingPlans;

            this.mnuPlanCaseCommitUntil.SelectedIndex = 0;

            this.ResumeLayout();


            this.Focus();
        } 
        #endregion

        #region private void mnuPlanCase_Click( object sender, EventArgs e )
        private void mnuPlanCase_Click( object sender, EventArgs e )
        {
            /********************************************************************************
            *   Add
            ********************************************************************************/
            if( sender.Equals( mnuPlanCaseAdd ) )
            {
                dgvCases.EndEdit();

                this.SuspendLayout();
                dgvCases.SuspendLayout();

                bindingCases.AddNew();

                dgvCases.CurrentCell = dgvCases.CurrentRow.Cells[0];
                dgvCases.CurrentCell.Selected = true;
                dgvCases.BeginEdit( true );

                dgvCases.ResumeLayout( false );
                this.ResumeLayout( false );
            }
            /********************************************************************************
            *   Remove
            ********************************************************************************/
            else if( sender.Equals( mnuPlanCaseRemove ) )
            {
                List<PlanCase> lstPlanCases = new List<PlanCase>();

                foreach( DataGridViewRow dgr in dgvCases.SelectedRows )
                {
                    lstPlanCases.Add( (PlanCase)dgr.DataBoundItem );
                }

                dgvCases.SuspendLayout();
                if( lstPlanCases.Count > 0 )
                {

                    foreach( PlanCase plancase in lstPlanCases )
                    {
                        try
                        {
                            bindingCases.Remove( plancase );
                        }
                        catch( MyException ex )
                        {
                            MyMessageBox.Show( this, "Plan Case", MyDisplayMessage.RemoveError, ex );
                        }
                    }

                }
                dgvCases.ResumeLayout();

                lstPlanCases.Clear();

                dgvCases.ClearSelection();
            }
            /********************************************************************************
            *   Paste
            ********************************************************************************/
            else if( sender.Equals( mnuPlanCasePaste ) )
            {
                PasteClipboard();
            }
            /********************************************************************************
            *   Commit
            ********************************************************************************/
            else if( sender.Equals( mnuPlanCaseCommit ) )
            {
                List<PlanCase> lstPlanCases = new List<PlanCase>();

                foreach( DataGridViewRow dgr in dgvCases.SelectedRows )
                {
                    lstPlanCases.Add( (PlanCase)dgr.DataBoundItem );
                }

                dgvCases.SuspendLayout();
                if( lstPlanCases.Count > 0 )
                {
                    foreach( PlanCase plancase in lstPlanCases )
                    {
                        DateTime commitdate = DateTime.Now;

                        plancase.CommitBaseDate = commitdate.ToString();
                        plancase.CommitDaysTill = Convert.ToDouble( mnuPlanCaseCommitUntil.SelectedItem );

                        plancase.CommitDate = commitdate.AddDays( plancase.CommitDaysTill ).ToString();
                    }
                }
                dgvCases.ResumeLayout();
                lstPlanCases.Clear();
                dgvCases.ClearSelection();
            }
        } 
        #endregion

        #region private void ucCases_Leave( object sender, System.EventArgs e )
        private void ucCases_Leave( object sender, System.EventArgs e )
        {
            dgvCases.EndEdit();
            dgvCases.ClearSelection();
        }  
        #endregion

        #region private void PasteClipboard()
        /*
         * 
         * This particular function is very specific in how it pastes data based on specific client requests.
         * 
         * in this case I don't care about all the cells that come out of the columns.  
         * All we really want is the first column.  This should accomodate pasting using ALT, or
         * selecting all rows and columns and then pasting.
         */
        private void PasteClipboard()
        {
            bool dataFormatCorrect = true;
            bool excludedDupes = false;
            bool excludedPrefixes = false;
            string strCaseName = string.Empty;
            string strClipboardData = string.Empty;
            string[] rowSplitter = { "\r\n", "\r", "\n" };

            this.SuspendLayout();
            dgvCases.SuspendLayout();

            // get text from clipboard
            try
            {
                strClipboardData = ((IDataObject)Clipboard.GetDataObject()).GetData( DataFormats.Text ).ToString();
            }
            catch { }

            if( !string.IsNullOrEmpty( strClipboardData ) )
            {
                // split clipboard data into lines and add each as row in datagridview
                foreach( string strRow in strClipboardData.Split( rowSplitter, StringSplitOptions.RemoveEmptyEntries ) )
                {
                    // 132 character matches input file.
                    if( strRow.Length == 132 )
                    {
                        // checking obligor, owed, paid, and balance columns
                        if( !strRow.Substring( 78, 14 ).Contains( "$" ) || !strRow.Substring( 93, 14 ).Contains( "$" ) ||
                            !strRow.Substring( 108, 14 ).Contains( "$" ) || strRow.Substring( 28, 25 ).Trim().Length < 1 )
                        {
                            dataFormatCorrect = false;
                            continue;
                        }

                        strCaseName = strRow.Substring( 0, 18 ).Trim();
                    }
                    else if( strRow.Trim().Length <= 18 && strRow.Trim().Length > 0 && !strRow.ToLower().Contains( "rows selected" ) )
                    {
                        strCaseName = strRow.Trim();
                    }
                    else
                    {
                        dataFormatCorrect = false;
                        continue;
                    }

                    // does the case already exist
                    if( CaseExists( strCaseName ) )
                    {
                        excludedDupes = true;
                        continue;
                    }

                    // does the case have an excluded prefix
                    if( Helper.HasRestrictedCasePrefix( strCaseName ) )
                    {
                        excludedPrefixes = true;
                        continue;
                    }

                    // adding case
                    PlanCase plancase = (PlanCase)bindingCases.AddNew();
                    plancase.CaseName = strCaseName;
                    if( strCaseName.ToUpper().Contains( "NT" ) || strCaseName.ToUpper().Contains( "ST" ) )
                    {
                        plancase.CAPP = true;
                    }
                }

                bindingCases.ResetBindings( false );
            }

            dgvCases.ResumeLayout( false );
            this.ResumeLayout( false );

            if( excludedDupes || excludedPrefixes || !dataFormatCorrect )
            {
                string strMessage = "";

                if( excludedDupes )
                    strMessage += "Duplicate case(s) encountered.\n";

                if( excludedPrefixes )
                    strMessage += "Case(s) encountered that had an excluded prefix.\n";

                if( !dataFormatCorrect )
                    strMessage += "*Clipboard line(s) encountered that do not match a recognizable format:\n\n"
                            + "1.  a line exactly 132 characters.\n"
                            + "2.  a line that is 19 characters or less.\n\n"
                            + "*This message should be expected if pasting an entire file and not specific rows.";

                MessageBox.Show( this, strMessage, "Cases", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
        }  
        #endregion

        #region private bool CaseExists( string caseName )
        private bool CaseExists( string caseName )
        {
            return (bindingCases.Find( "CaseName", caseName ) >= 0) ? true : false;
        }  
        #endregion

        #region private void dgvCases_CellValidated( object sender, DataGridViewCellEventArgs e )
        private void dgvCases_CellValidated( object sender, DataGridViewCellEventArgs e )
        {
            if( e.ColumnIndex == 0 )
            {
                this.SuspendLayout();
                this.dgvCases.SuspendLayout();

                List<string> cases = new List<string>();

                for( int i = 0; i < dgvCases.Rows.Count - 1; i++ )
                {
                    if( i != e.RowIndex )
                        cases.Add( dgvCases.Rows[i].Cells[e.ColumnIndex].Value.ToString() );
                }

                if( cases.Contains( dgvCases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() ) || Helper.HasRestrictedCasePrefix( dgvCases.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() ) )
                {
                    dgvCases.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightPink;
                }


                this.dgvCases.ResumeLayout( false );
                this.ResumeLayout( false );
                this.dgvCases.ClearSelection();
            }
        }  
        #endregion

        #region public void Clear()
        public void Clear()
        {
            dgvCases.SuspendLayout();
            bindingCases.Clear();
            dgvCases.ResumeLayout();
        } 
        #endregion


    }
}
