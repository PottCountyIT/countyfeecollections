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

    public partial class ucPlans : UserControl
    {


        #region public int PlanId
        public int PlanId
        {
            get
            {
                if( this.cmbPlans.SelectedIndex >= 0 )
                    return Convert.ToInt32( cmbPlans.SelectedValue );
                else
                    return -1;
            }
        } 
        #endregion




        #region public ucPlans()
        public ucPlans()
        {

            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );
        }  
        #endregion




        #region public void SetBindingSource( ref BindingSource bindingDefendants )
        public void SetBindingSource( ref BindingSource bindingDefendants )
        {
            this.SuspendLayout();
            ucCases.SuspendLayout();
            ucFees.SuspendLayout();
            ucPaymentArrangements.SuspendLayout();
            ucPayments.SuspendLayout();

            this.bindingPlans.DataMember = "Plans";
            this.bindingPlans.DataSource = bindingDefendants;

            this.cmbPlans.DisplayMember = "PlanName";
            this.cmbPlans.ValueMember = "ID";

            this.chkCAPP.DataBindings.Add( "Checked", bindingPlans, "CAPP", true, DataSourceUpdateMode.OnPropertyChanged );
            this.chkNonCAPP.DataBindings.Add( "Checked", bindingPlans, "NonCAPP", true, DataSourceUpdateMode.OnPropertyChanged );
            this.chkFiled.DataBindings.Add( "Checked", bindingPlans, "IsFiled", true, DataSourceUpdateMode.OnPropertyChanged );
            this.chkNoncompliance.DataBindings.Add( "Checked", bindingPlans, "NonComplianceNotice", true, DataSourceUpdateMode.OnPropertyChanged );
            this.chkInsurance.DataBindings.Add( "Checked", bindingPlans, "HasInsurance", true, DataSourceUpdateMode.OnPropertyChanged );
            this.chkContempt.DataBindings.Add( "Checked", bindingPlans, "InContempt", true, DataSourceUpdateMode.OnPropertyChanged );
            this.mskFiledDate.DataBindings.Add( "Text", bindingPlans, "FiledDate", true, DataSourceUpdateMode.OnPropertyChanged, "", "MM/dd/yyyy" );
            this.mskFiledDate.DataBindings["Text"].Parse += new ConvertEventHandler( mskdTextBoxValidator );            

            ucCases.SetBindingSource( ref bindingPlans );
            ucFees.SetBindingSource( ref bindingPlans );
            ucPaymentArrangements.SetBindingSource( ref bindingPlans );
            ucPayments.SetBindingSource( ref bindingPlans );
            ucPaymentArrangements.DataBindings.Add( "RemainingBalance", lblRemainingBalanceValue, "Text", true, DataSourceUpdateMode.OnPropertyChanged );

            bindingDefendants.PositionChanged += new EventHandler( UpdateGUIState );
            ucFees.PropertyChanged += new PropertyChangedEventHandler( TotalsChanged );
            ucPayments.PropertyChanged += new PropertyChangedEventHandler( TotalsChanged );

            this.lblTotalAmountDueValue.DataBindings.Add( "Text", ucFees, "TotalAmountDue", true, DataSourceUpdateMode.OnPropertyChanged, "", "C2" );
            this.lblTotalAmountPaidValue.DataBindings.Add( "Text", ucPayments, "TotalAmountPaid", true, DataSourceUpdateMode.OnPropertyChanged, "", "C2" );

            UpdateGUIState( this, null );

            ucPayments.ResumeLayout( false );
            ucPaymentArrangements.ResumeLayout( false );
            ucFees.ResumeLayout( false );
            ucCases.ResumeLayout( false );
            this.ResumeLayout( false );
        }


        #endregion

        #region private void TotalsChanged( object sender, PropertyChangedEventArgs e )
        private void TotalsChanged( object sender, PropertyChangedEventArgs e )
        {
            ucPaymentArrangements.RemainingBalance = this.ucFees.TotalAmountDue - this.ucPayments.TotalAmountPaid;
            this.lblRemainingBalanceValue.Text = ucPaymentArrangements.RemainingBalance.ToString( "C2" );
        }  
        #endregion

        #region private void UpdateGUIState( object sender, EventArgs e )
        private void UpdateGUIState( object sender, EventArgs e )
        {

            bool IsEnabled = (bindingPlans != null && bindingPlans.Count > 0);

            chkCAPP.Enabled = IsEnabled;
            chkNonCAPP.Enabled = IsEnabled;
            chkFiled.Enabled = IsEnabled;
            chkNoncompliance.Enabled = IsEnabled;
            chkInsurance.Enabled = IsEnabled;
            chkContempt.Enabled = IsEnabled;
            mskFiledDate.Enabled = IsEnabled;
            ucCases.Enabled = IsEnabled;
            ucFees.Enabled = IsEnabled;
            ucPaymentArrangements.Enabled = IsEnabled;
            ucPayments.Enabled = IsEnabled;
            cmbPlans.Enabled = IsEnabled;

            SetJailMode();
        }
        #endregion

        #region SetJailMode
        public void SetJailMode()
        {
            //Jail enhancements
            LocalUser user = new LocalUser();
            if (user.JailMode)
            {
                chkCAPP.Visible = false;
                chkNonCAPP.Visible = false;
                chkFiled.Visible = false;
                chkNoncompliance.Visible = false;
                chkInsurance.Visible = false;
            }
            else
            {
                chkCAPP.Visible = true;
                chkNonCAPP.Visible = true;
                chkFiled.Visible = true;
                chkNoncompliance.Visible = true;
                chkInsurance.Visible = true;
            }
        }
            #endregion
            #region private void mnuPlan_Click( object sender, EventArgs e )
            private void mnuPlan_Click( object sender, EventArgs e )
        {

            /********************************************************************************
            *   Add
            ********************************************************************************/
            if( sender.Equals( mnuPlanAdd ) )
            {

                frmPlanNew frm = new frmPlanNew( bindingPlans.Count );

                if( !frm.IsDisposed && DialogResult.OK == frm.ShowDialog() )
                {
                    if( !string.IsNullOrEmpty( frm.PlanName ) )
                    {

                        this.SuspendLayout();
                        cmbPlans.SuspendLayout();

                        Plan plan = new Plan( ((Defendant)((BindingSource)bindingPlans.DataSource).Current).ID );
                        plan.PlanName = frm.PlanName;
                        if (plan.PlanName.StartsWith("OWMG"))
                        {
                            plan.CAPP = true;
                        }

                        ((Plan)bindingPlans[bindingPlans.Add( plan )]).MyState = MyObjectState.New;

                        cmbPlans.ResumeLayout();
                        this.ResumeLayout();

                        bindingPlans.ResetBindings( false );

                        cmbPlans.SelectedValue = plan.ID;

                    }

                }

            }
            /********************************************************************************
            *   Remove
            ********************************************************************************/
            else if( sender.Equals( mnuPlanRemove ) )
            {

                if( bindingPlans.Current != null && DialogResult.OK == MyMessageBox.Show( this, ((Plan)bindingPlans.Current).PlanName, MyDisplayMessage.RemoveConfirm ) )
                {

                    this.SuspendLayout();
                    cmbPlans.SuspendLayout();

                    bindingPlans.Remove( bindingPlans.Current );
                    bindingPlans.ResetBindings( false );

                    if( bindingPlans.Count <= 0 )
                    {
                        ucCases.Clear();
                        ucPaymentArrangements.Clear();
                        ucPayments.Clear();
                        ucFees.Clear();
                    }

                    cmbPlans.ResumeLayout();
                    this.ResumeLayout();

                }

            }

            UpdateGUIState( this, null );


        }  
        #endregion

        #region private void mskdTextBoxValidator( object sender, ConvertEventArgs e )
        private void mskdTextBoxValidator( object sender, ConvertEventArgs e )
        {

            if( e.Value == null || string.IsNullOrEmpty( e.Value.ToString() ) || string.IsNullOrEmpty( e.Value.ToString().Replace( "/", "" ).Trim() ) )
            {
                e.Value = null;
            }

        }  
        #endregion



    }
}
