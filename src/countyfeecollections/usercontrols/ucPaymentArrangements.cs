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
    public partial class ucPaymentArrangements : UserControl
    {
        private double _dblRemainingBalance;

        #region public double RemainingBalance
        public double RemainingBalance
        {
            get { return _dblRemainingBalance; }
            set { _dblRemainingBalance = value; }
        } 
        #endregion

        #region public ucPaymentArrangements()
        public ucPaymentArrangements()
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
            this.dgvPaymentArrangements.SuspendLayout();

            dgvPaymentArrangementsClmPayPeriodTypeId.DataSource = Helper.PayPeriodTypeList;
            dgvPaymentArrangementsClmPayPeriodTypeId.ValueMember = "ID";
            dgvPaymentArrangementsClmPayPeriodTypeId.DisplayMember = "PayPeriodTypeName";


            dgvPaymentArrangementsClmPaymentArrangementTypeId.DataSource = Helper.PaymentArrangementTypeList;
            dgvPaymentArrangementsClmPaymentArrangementTypeId.ValueMember = "ID";
            dgvPaymentArrangementsClmPaymentArrangementTypeId.DisplayMember = "PaymentArrangementTypeName";

            this.bindingPaymentArrangements.DataSource = bindingPlans;
            this.bindingPaymentArrangements.DataMember = "PaymentArrangements";


            

            this.Focus();

            this.dgvPaymentArrangements.ResumeLayout( false );
            this.ResumeLayout( false );

        }
        #endregion
        
        private void mnuPaymentArrangements_Click( object sender, EventArgs e )
        {
            /********************************************************************************
            *   Add
            ********************************************************************************/
            if( sender.Equals( mnuPaymentArrangementsAdd ) )
            {

                dgvPaymentArrangements.EndEdit();
                dgvPaymentArrangements.SuspendLayout();
                
                bindingPaymentArrangements.AddNew();
                dgvPaymentArrangements.CurrentCell = dgvPaymentArrangements.CurrentRow.Cells[0];
                dgvPaymentArrangements.CurrentCell.Selected = true;
                
                dgvPaymentArrangements.ResumeLayout();
                dgvPaymentArrangements.BeginEdit( true );

            }
            /********************************************************************************
            *   Remove
            ********************************************************************************/
            else if( sender.Equals( mnuPaymentArrangementsRemove ) )
            {
                if (MessageBox.Show("Delete payment arrangement(s)?", "Confirm delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.SuspendLayout();
                    dgvPaymentArrangements.SuspendLayout();

                    List<PlanPaymentArrangement> lstPlanPmtArrangements = new List<PlanPaymentArrangement>();
                    foreach (DataGridViewRow dgr in dgvPaymentArrangements.SelectedRows)
                    {
                        lstPlanPmtArrangements.Add((PlanPaymentArrangement)dgr.DataBoundItem);
                    }

                    if (lstPlanPmtArrangements.Count > 0)
                    {
                        foreach (PlanPaymentArrangement planfee in lstPlanPmtArrangements)
                        {
                            try
                            {
                                bindingPaymentArrangements.Remove(planfee);
                            }
                            catch (MyException ex)
                            {
                                MyMessageBox.Show(this, "Plan Payment Arrangement", MyDisplayMessage.RemoveError, ex);
                            }
                        }
                    }

                    lstPlanPmtArrangements.Clear();
                    dgvPaymentArrangements.ClearSelection();

                    dgvPaymentArrangements.ResumeLayout();
                    this.ResumeLayout();
                }
            }
            /********************************************************************************
            *   Calculate End Date
            ********************************************************************************/
            else if( sender.Equals( mnuPaymentArrangementsCalcEndDate ) )
            {
                this.SuspendLayout();
                dgvPaymentArrangements.SuspendLayout();

                List<PlanPaymentArrangement> lstPlanPaymentArrangements = new List<PlanPaymentArrangement>();

                foreach( DataGridViewRow dgr in dgvPaymentArrangements.SelectedRows )
                {
                    lstPlanPaymentArrangements.Add( (PlanPaymentArrangement)dgr.DataBoundItem );
                }

                if( lstPlanPaymentArrangements.Count > 0 )
                {
                    foreach( PlanPaymentArrangement paymentarrangement in lstPlanPaymentArrangements )
                    {
                        DateTime StartDate;
                        DateTime EndDate = DateTime.Now;
                        double dblPaymentAmount;
                        
                        // is there a start date
                        if( !DateTime.TryParse( paymentarrangement.StartDate, out StartDate ) )
                        {
                            paymentarrangement.StartDate = DateTime.Now.ToShortDateString();
                        }

                        // is there a payment amount
                        if( !Double.TryParse( paymentarrangement.Amount.ToString(), out dblPaymentAmount ) )
                        {
                            paymentarrangement.Amount = 0;
                        }

                        // no payment amount = end date of infinity
                        if( dblPaymentAmount <= 0 )
                        {
                            paymentarrangement.EndDate = DateTime.MaxValue.ToString();
                            break;
                        }

                        // no balance means defendant is done making payments
                        if( _dblRemainingBalance <= 0 )
                        {
                            paymentarrangement.EndDate = DateTime.Now.ToShortDateString();
                            break;
                        }

                        int intPaymentCount = (int)Math.Ceiling( _dblRemainingBalance / dblPaymentAmount );
                        string strPayPeriod = Helper.GetPayPeriodName( paymentarrangement.PayPeriodTypeId );

                        switch( strPayPeriod.ToLower() )
                        {
                            case "weekly":
                                EndDate = StartDate.AddDays( (7 * intPaymentCount) );
                                break;

                            case "monthly":
                                EndDate = StartDate.AddMonths( intPaymentCount );
                                break;

                            case "bi-weekly":
                                EndDate = StartDate.AddDays( (14 * intPaymentCount) );
                                break;

                            case "bi-monthly":
                                EndDate = StartDate.AddMonths( (intPaymentCount / 2) );
                                break;
                        }

                        ((PlanPaymentArrangement)bindingPaymentArrangements.Current).EndDate = EndDate.ToString( "d" );
                    }
                }

                dgvPaymentArrangements.ResumeLayout();
                this.ResumeLayout();

                dgvPaymentArrangements.ClearSelection();
                bindingPaymentArrangements.ResetBindings( false );
            }
        }

        private void ucPaymentArrangements_Leave( object sender, System.EventArgs e )
        {
            dgvPaymentArrangements.EndEdit();
            dgvPaymentArrangements.ClearSelection();
        } 

        public void Clear()
        {
            dgvPaymentArrangements.SuspendLayout();
            bindingPaymentArrangements.Clear();
            dgvPaymentArrangements.ResumeLayout();
        }
    }
}
