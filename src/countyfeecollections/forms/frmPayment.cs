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
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace county.feecollections
{
    public partial class frmPayment : Form
    {

        private double _dblTotalAmountPaid;
        private DataTable _dtFeePayments;




        #region public frmPayment()
        public frmPayment()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );
        } 
        #endregion

        #region public frmPayment( ref BindingSource bindingPayments ) : this()
        public frmPayment( ref BindingSource bindingPayments ) : this()
        {

            this.bindingPayments = bindingPayments;

            // filling plan drop down list with plans that have fees.
            BindingSource bindingPlans = new BindingSource();
            bindingPlans.DataSource = ((Defendant)((BindingSource)((BindingSource)bindingPayments.DataSource).DataSource).Current).Plans.Clone();
            bindingPlans.Filter = "FeeCount > 0";

            // if no plan has any fees, then there are no payments to be made.
            if( bindingPlans.Count <= 0 )
            {
                MessageBox.Show( this, "The defendant does not owe any fees", "Payment", MessageBoxButtons.OK, MessageBoxIcon.Information );
                this.Close();
                return;
            }

            _dtFeePayments = new DataTable();
            _dtFeePayments.Columns.Add( "planid", typeof( int ) );
            _dtFeePayments.Columns.Add( "plan", typeof( string ) );
            _dtFeePayments.Columns.Add( "feetypeid", typeof( int ) );
            _dtFeePayments.Columns.Add( "feetype", typeof( string ) );
            _dtFeePayments.Columns.Add( "total", typeof( double ) );
            _dtFeePayments.Columns.Add( "paid", typeof( double ) );
            _dtFeePayments.Columns.Add( "remaining", typeof( double ) );
            _dtFeePayments.Columns.Add( "apply", typeof( double ) );
            _dtFeePayments.Columns.Add( "sortorder", typeof( int ) );
            _dtFeePayments.Columns["paid"].Expression = "total - remaining";

            foreach( Plan plan in ((Defendant)((BindingSource)((BindingSource)bindingPayments.DataSource).DataSource).Current).Plans )
            {
                foreach( PlanFee fee in plan.Fees )
                {
                    DataRow dr = _dtFeePayments.NewRow();
                    dr["planid"] = plan.ID;
                    dr["plan"] = plan.PlanName;
                    dr["feetypeid"] = fee.FeeTypeId;
                    dr["feetype"] = fee.FeeTypeName;
                    dr["total"] = fee.Amount;
                    dr["remaining"] = fee.Amount;
                    dr["sortorder"] = fee.PaymentOrder;

                    foreach( FeePayment payment in plan.Payments )
                    {
                        if( payment.FeeTypeId == fee.FeeTypeId )
                            dr["remaining"] = (double)dr["remaining"] - payment.Amount;
                    }

                    _dtFeePayments.Rows.Add( dr );
                }
            }

            _dtFeePayments.DefaultView.Sort = "sortorder ASC";
            _dtFeePayments.AcceptChanges();

            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.DataSource = _dtFeePayments;
            this.dgvPayments.CellEndEdit += new DataGridViewCellEventHandler( dgvPayments_CreateTotalAmount );
            this.dgvPayments.DataBindingComplete += new DataGridViewBindingCompleteEventHandler( dgvPayments_DataBindingComplete );
            this.txtAmount.Select();
        } 
        #endregion




        #region private void payment_TextChanged( object sender, EventArgs e )
        private void payment_TextChanged( object sender, EventArgs e )
        {
            double total = 0;
            double splits = 0;
            if( Double.TryParse( txtAmount.Text.Trim().Replace( "$", "" ), out total ) ) { }
            if( Double.TryParse( lblSplitTotalValue.Text.Replace( "$", "" ), out splits ) ) { }
            this.lblRemainderValue.Text = (total - splits).ToString( "C2" );
        } 
        #endregion

        #region private void dgvPayments_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
        private void dgvPayments_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
        {
            this.dgvPayments.SuspendLayout();
            this.dgvPayments.DataBindingComplete -= new DataGridViewBindingCompleteEventHandler( dgvPayments_DataBindingComplete );

            foreach( DataGridViewRow dgr in dgvPayments.Rows )
            {
                DataRowView drv = (DataRowView)dgr.DataBoundItem;
                drv.BeginEdit();
                double dblRemainingBalance = 0;

                if( Double.TryParse( drv["remaining"].ToString(), out dblRemainingBalance ) )
                {
                    if( dblRemainingBalance == 0 )
                    {
                        drv.BeginEdit();
                        drv["apply"] = 0;
                        drv.EndEdit();
                        dgr.DefaultCellStyle.BackColor = System.Drawing.SystemColors.ControlLight;
                        dgr.Cells["apply"].ReadOnly = true;
                    }
                }
                drv.EndEdit();
            }
            this.dgvPayments.DataBindingComplete += new DataGridViewBindingCompleteEventHandler( dgvPayments_DataBindingComplete );
            this.dgvPayments.ResumeLayout( false );
            dgvPayments_CreateTotalAmount( this, new DataGridViewCellEventArgs( 1, 0 ) );
        } 
        #endregion

        #region private void dgvPayments_CreateTotalAmount( object sender, DataGridViewCellEventArgs e )
        private void dgvPayments_CreateTotalAmount( object sender, DataGridViewCellEventArgs e )
        {
            _dblTotalAmountPaid = 0;
            double dblApplyAmount = 0;

            if( _dtFeePayments != null && _dtFeePayments.Rows.Count > 0 )
            {
                foreach( DataRow dr in _dtFeePayments.Rows )
                {
                    if( !string.IsNullOrEmpty( dr["apply"].ToString() ) && Helper.FeeTypeList[Helper.FeeTypeList.Find( "ID", (int)dr["feetypeid"] )].Billable )
                    {
                        if( Double.TryParse( dr["apply"].ToString(), out dblApplyAmount ) )
                        {
                            _dblTotalAmountPaid += dblApplyAmount;
                        }
                    }
                }
            }

            this.lblSplitTotalValue.Text = _dblTotalAmountPaid.ToString( "C2" );
        } 
        #endregion

        #region private void txtAmount_Validating( object sender, CancelEventArgs e )
        private void txtAmount_Validating( object sender, CancelEventArgs e )
        {
            double payment = 0;

            if( double.TryParse( txtAmount.Text.Trim(), out payment ) && _dtFeePayments.Rows.Count >= 0 )
            {
                foreach( DataRow dr in _dtFeePayments.Rows )
                {
                    double remaining = Math.Round( (double)dr["remaining"], 2 );
                    // does the defendant still owe for this fee
                    if( remaining > 0 )
                    {
                        // is the payment amount more than what is left remaining
                        if( payment <= remaining )
                        {
                            dr["apply"] = payment;
                            payment = 0;
                            break;
                        }
                        else
                        {
                            dr["apply"] = remaining;
                            payment -= remaining;
                        }
                    }
                }

                if( payment > 0 )
                {
                    MyMessageBox.Show( this, "Payment", MyDisplayMessage.PaymentMoreThanOwed );
                }

                this.Select();
            }

            dgvPayments_CreateTotalAmount( this, new DataGridViewCellEventArgs( 2, 0 ) );

        }  
        #endregion

        #region private void txtAmount_KeyDown( object sender, KeyEventArgs e )
        private void txtAmount_KeyDown( object sender, KeyEventArgs e )
        {
            if( e.KeyCode == Keys.Return )
            {
                this.dgvPayments.Select();
            }
        }  
        #endregion

        #region private void btnOK_Click( object sender, EventArgs e )
        private void btnOK_Click( object sender, EventArgs e )
        {
            FeePayment payment;

            if( CheckData() )
            {
                double dblSplitAmount = 0;

                foreach( DataRow dr in _dtFeePayments.Rows )
                {
                    if( Double.TryParse( dr["apply"].ToString(), out dblSplitAmount ) && dblSplitAmount > 0 )
                    {

                        // adding payment to correct plan
                        Plans plns = ((Defendant)((BindingSource)((BindingSource)bindingPayments.DataSource).DataSource).Current).Plans;
                        var lnq = from s in plns where s.ID == (int)dr["planid"] select s;

                        payment = (FeePayment)lnq.First().Payments.AddNew();
                        payment.PlanId = (int)dr["planid"];
                        payment.FeeTypeId = (int)dr["feetypeid"];
                        payment.ReceivedDate = this.dtpReceivedDate.Value;
                        payment.Amount = dblSplitAmount;
                    }
                }

                bindingPayments.ResetBindings( false );
                this.Close();

            }
        } 
        #endregion

        #region private bool CheckData()
        private bool CheckData()
        {
            float dblPaymentAmount = 0;
            float dblTotalSplit = 0;
            float dblTotalBalance = 0;
            float dblSplitPayments = 0;
            float dblTemp;

            if( float.TryParse( txtAmount.Text.Trim().Replace( "$", "" ), out dblPaymentAmount ) ) { }

            // adding total splits 
            foreach( DataRow dr in _dtFeePayments.Rows )
            {
                if( float.TryParse( dr["apply"].ToString(), out dblTemp ) )
                {
                    dblTotalSplit += dblTemp;
                }
            }

            // do the splits equal the total
            if( dblTotalSplit != dblPaymentAmount )
            {
                MessageBox.Show( this, "Payment amount does not equal sum of splits.", "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
            }

            string strError = "";
            string strReportToCountyClerk = "";
            string strOtherCounty = "";

            LocalUser usr = new LocalUser();


            foreach( Plan plan in ((Defendant)((BindingSource)((BindingSource)bindingPayments.DataSource).DataSource).Current).Plans )
            {
                dblTotalBalance = 0;
                dblSplitPayments = 0;

                DataRow[] drs = _dtFeePayments.Select( "planid = " + plan.ID );

                // calculating remaining balance
                foreach( DataRow dr in drs )
                {
                    if( float.TryParse( dr["remaining"].ToString(), out dblTemp ) )
                        dblTotalBalance += dblTemp;

                    if( float.TryParse( dr["apply"].ToString(), out dblTemp ) )
                        dblSplitPayments += dblTemp;
                }

                // has the defendant paid more than owed.
                if( (dblTotalBalance - dblSplitPayments) < 0 )
                {
                    strError += plan.PlanName + ":  Payment made is greater than what the defendant owes.\n";
                }

                // is this the last payment made.
                if( string.IsNullOrEmpty( strError ) && (dblTotalBalance - dblSplitPayments) == 0 )
                {
                    strReportToCountyClerk += plan.PlanName + "\n";
                }

                // is a payment being posted to a plan with cases in other counties
                if( dblSplitPayments > 0 )
                {
                    var lnq = from cs in plan.Cases where cs.CountyId != usr.HomeCountyId select cs;
                    if( lnq.Count() > 0 )
                    {
                        strOtherCounty += plan.PlanName + "\n";
                    }
                }

            }

            if( !string.IsNullOrEmpty( strError ) )
            {
                MessageBox.Show( this, strError, "Payment Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
            }
            else
            {

                string msg = "";

                // is this the last payment made.
                if( !string.IsNullOrEmpty( strReportToCountyClerk ) )
                    msg += "Report to Clerk Needed:\n\n " + strReportToCountyClerk;

                // is this payment out of county.
                if( !string.IsNullOrEmpty( strOtherCounty ) )
                {
                    msg += (msg.Length > 0) ? "\n" : "";
                    msg += "A payment is being made to a plan or plans with at least one case in another county:\n\n " + strOtherCounty;
                }

                if( !string.IsNullOrEmpty( msg ) )
                {
                    this.Hide();
                    MessageBox.Show( this, msg, "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }

            }

            return true;
        } 
        #endregion 


    }
}
