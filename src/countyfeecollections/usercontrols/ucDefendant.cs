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

    public partial class ucDefendant : UserControl
    {




        #region public ucDefendant()
        public ucDefendant()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

            this.GotFocus += new EventHandler( ucDefendant_GotFocus );
        } 
        #endregion

        #region public void SetBindingSource( ref BindingSource bindingDefendants )
        public void SetBindingSource( ref BindingSource bindingDefendants )
        {
            this.SuspendLayout();

            SetBindings( ref bindingDefendants );
            ucEmployer.SetBindingSource( ref bindingDefendants );

            this.bindingPlans.DataMember = "Plans";
            this.bindingPlans.DataSource = bindingDefendants;

            this.ResumeLayout();
        } 
        #endregion

        #region private void SetBindings( ref BindingSource bindingDefendants )
        private void SetBindings( ref BindingSource bindingDefendants )
        {
            // State Drop Down List
            cmbStates.DataSource = Helper.StateList;
            cmbStates.ValueMember = "stateid";
            cmbStates.DisplayMember = "abbreviation";

            this.txtLastName.DataBindings.Add( "Text", bindingDefendants, "LastName", true, DataSourceUpdateMode.OnPropertyChanged );
            this.txtMiddleName.DataBindings.Add( "Text", bindingDefendants, "MiddleName", true, DataSourceUpdateMode.OnPropertyChanged );
            this.txtFirstName.DataBindings.Add( "Text", bindingDefendants, "FirstName", true, DataSourceUpdateMode.OnPropertyChanged );
            this.txtAka.DataBindings.Add( "Text", bindingDefendants, "Aka", true, DataSourceUpdateMode.OnPropertyChanged );
            this.mskSSN.DataBindings.Add( "Text", bindingDefendants, "SSN", true, DataSourceUpdateMode.OnPropertyChanged );
            this.mskBirthDate.DataBindings.Add( "Text", bindingDefendants, "BirthDate", true, DataSourceUpdateMode.OnPropertyChanged, "", "MM/dd/yyyy" );
            this.mskBirthDate.DataBindings["Text"].Parse += new ConvertEventHandler( mskdTextBoxValidator );
            this.txtDriversLicense.DataBindings.Add( "Text", bindingDefendants, "DriversLicense", true, DataSourceUpdateMode.OnPropertyChanged );

            this.txtStreet1.DataBindings.Add( "Text", bindingDefendants, "Street1", true, DataSourceUpdateMode.OnPropertyChanged );
            this.txtStreet2.DataBindings.Add( "Text", bindingDefendants, "Street2", true, DataSourceUpdateMode.OnPropertyChanged );
            this.txtCity.DataBindings.Add( "Text", bindingDefendants, "City", true, DataSourceUpdateMode.OnPropertyChanged );
            this.cmbStates.DataBindings.Add( "SelectedValue", bindingDefendants, "StateId", true, DataSourceUpdateMode.OnPropertyChanged );
            this.mskZip.DataBindings.Add( "Text", bindingDefendants, "Zip", true, DataSourceUpdateMode.OnPropertyChanged );
            this.mskPhoneHome.DataBindings.Add( "Text", bindingDefendants, "HomePhone", true, DataSourceUpdateMode.OnPropertyChanged );
            this.mskPhoneMobile.DataBindings.Add( "Text", bindingDefendants, "MobilePhone", true, DataSourceUpdateMode.OnPropertyChanged );

            this.chkHasProbationOfficer.DataBindings.Add( "Checked", bindingDefendants, "HasProbationOfficer", true, DataSourceUpdateMode.OnPropertyChanged );
            this.txtProbationOfficer.DataBindings.Add( "Text", bindingDefendants, "ProbationOfficer", true, DataSourceUpdateMode.OnPropertyChanged );
            this.mskBarredUntil.DataBindings.Add( "Text", bindingDefendants, "BarredUntil", true, DataSourceUpdateMode.OnPropertyChanged, "", "MM/dd/yyyy" );
            this.mskBarredUntil.DataBindings["Text"].Parse += new ConvertEventHandler( mskdTextBoxValidator );

            this.tbDaysInJail.DataBindings.Add("Text", bindingDefendants, "DaysInJail", true, DataSourceUpdateMode.OnPropertyChanged);
            this.tbBookingNumber.DataBindings.Add("Text", bindingDefendants, "BookingNumber", true, DataSourceUpdateMode.OnPropertyChanged);
            this.tbJudgmentDate.DataBindings.Add("Text", bindingDefendants, "JudgmentDate", true, DataSourceUpdateMode.OnPropertyChanged, "", "MM/dd/yyyy");
            SetJailMode();
        }
        #endregion

        #region SetJailMode
        public void SetJailMode()
        {
            LocalUser user = new LocalUser();
            if (!user.JailMode)
            {
                
                if (!this.tabcontrolModeFields.TabPages.Contains(tabAttorneyPage))
                {
                    this.tabcontrolModeFields.TabPages.Add(tabAttorneyPage);
                }
                if (!this.tabcontrolModeFields.TabPages.Contains(tabBankruptcy))
                {
                    this.tabcontrolModeFields.TabPages.Add(tabBankruptcy);
                }

                this.tabcontrolModeFields.SelectedTab = this.tabAttorneyPage;

                if (this.tabcontrolModeFields.TabPages.Contains(tabJailPage))
                {
                    this.tabcontrolModeFields.TabPages.Remove(tabJailPage);
                }
                //lblDaysInJail.Visible = false;
                //tbDaysInJail.Visible = false;
                //lblBookingNumber.Visible = false;
                //tbBookingNumber.Visible = false;
                //lblJudgmentDate.Visible = false;
                //tbJudgmentDate.Visible = false;
                //chkHasProbationOfficer.Visible = true;
                //txtProbationOfficer.Visible = true;

            }
            else
            {
                if (!this.tabcontrolModeFields.TabPages.Contains(tabJailPage))
                {
                    this.tabcontrolModeFields.TabPages.Add(tabJailPage);
                }

                this.tabcontrolModeFields.SelectedTab = this.tabJailPage;

                if (this.tabcontrolModeFields.TabPages.Contains(tabAttorneyPage))
                {
                    this.tabcontrolModeFields.TabPages.Remove(tabAttorneyPage);
                }
                if (this.tabcontrolModeFields.TabPages.Contains(tabBankruptcy))
                {
                    this.tabcontrolModeFields.TabPages.Remove(tabBankruptcy);
                }
                //lblDaysInJail.Visible = true;
                //tbDaysInJail.Visible = true;
                //lblBookingNumber.Visible = true;
                //tbBookingNumber.Visible = true;
                //lblJudgmentDate.Visible = true;
                //tbJudgmentDate.Visible = true;
                //chkHasProbationOfficer.Visible = false;
                //txtProbationOfficer.Visible = false;
            }
        }
        #endregion

        #region private void ucDefendant_GotFocus( object sender, System.EventArgs e )
        private void ucDefendant_GotFocus( object sender, System.EventArgs e )
        {
            this.txtFirstName.Focus();
            this.txtFirstName.Select( 0, 0 );

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

        private void cbxInBankruptcy_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
