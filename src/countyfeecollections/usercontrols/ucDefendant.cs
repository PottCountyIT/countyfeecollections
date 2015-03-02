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
    }
}
