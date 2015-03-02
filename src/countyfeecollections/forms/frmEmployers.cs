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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace county.feecollections
{

    public partial class frmEmployers : Form
    {

        private Employer _employerTemp;
        private GridViewState _GridViewState = GridViewState.None;
        private string _strFilter;
        private Employers _employers;




        #region public frmEmployers()
        public frmEmployers()
        {

            try
            {
                _employers = new Employers();
            }
            catch( MyException myex )
            {
                MyMessageBox.Show( this, "Employer Master List", MyDisplayMessage.FormOpenError, myex );
                this.Close();
                return;
            }

            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

            InitializeFilter();

            cmbStates.DataSource = Helper.StateList;
            cmbStates.ValueMember = "stateid";
            cmbStates.DisplayMember = "abbreviation";
            
        } 
        #endregion




        #region private void InitializeFilter()
        private void InitializeFilter()
        {

            MyFilterField field;
            List<MyFilterField> fields = new List<MyFilterField>();

            field = new MyFilterField();
            field.FieldValue = "EmployerName";
            field.FieldName = "Employer Name";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "Street1";
            field.FieldName = "Street1";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "Street2";
            field.FieldName = "Street2";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "City";
            field.FieldName = "City";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "StateName";
            field.FieldName = "StateName";
            field.FieldType = typeof( string );
            fields.Add( field );

            ucFilter.Filters = fields;

            ucFilter.OnFilterChanged += new ucFilter.FilterValueChanged( ucFilter_OnFilterChanged );


        }
        #endregion

        #region private void frmMain_Load( object sender, EventArgs e )
        private void frmEmployers_Load( object sender, EventArgs e )
        {

            bindingEmployers.RaiseListChangedEvents = false;
            bindingEmployers.DataSource = _employers;
            bindingEmployers.RaiseListChangedEvents = true;

            bindingEmployers.Sort = "EmployerName ASC";

            bindingEmployers.ResetBindings( false );
            UpdateEmployerMenu( null, null );

            bindingEmployers.CurrentItemChanged += new System.EventHandler( this.UpdateEmployerMenu );
            dgvEmployers.CellMouseDown += new DataGridViewCellMouseEventHandler( dgvEmployers_CellMouseDown );
            dgvEmployers.Sorted += new EventHandler( dgvEmployers_Sorted );

            ucFilter.Focus();

        }
        #endregion
        
        #region private void mnuEmployer_Click( object sender, EventArgs e )
        private void mnuEmployer_Click( object sender, EventArgs e )
        {

            Employer employer = (Employer)bindingEmployers.Current;

            if( sender.Equals( mnuEmployerNew ) )
            {
                /********************************************************************************
                *   New
                ********************************************************************************/
                if( CanChangeCurrentEmployer() )
                {

                    _GridViewState = GridViewState.Adding;
                    bindingEmployers.AddNew();
                    _GridViewState = GridViewState.None;
                    
                    this.txtEmployerName.Focus();
                }

            }
            else if( sender.Equals( mnuEmployerRemove ) )
            {
                /********************************************************************************
                *   Remove
                ********************************************************************************/
                if( DialogResult.OK == MyMessageBox.Show( this, "Employer", MyDisplayMessage.RemoveConfirm ) )
                {
                    try
                    {
                        bindingEmployers.RemoveCurrent();
                        bindingEmployers.ResetBindings( false );
                        this.ucFilter.Focus();
                    }
                    catch( MyException ex )
                    {
                        MyMessageBox.Show( this, "Employer", MyDisplayMessage.RemoveError, ex );
                    }
                }
            }
            else if( sender.Equals( mnuEmployerRefresh ) )
            {
                /********************************************************************************
                *   Refresh
                ********************************************************************************/
                if( !employer.MyState.Equals( MyObjectState.Current ) )
                {
                    if( DialogResult.Cancel == MyMessageBox.Show( this, "Employer", MyDisplayMessage.RefreshConfirm ) )
                    {
                        return;
                    }
                }

                try
                {
                    employer.Refresh();
                    bindingEmployers.ResetBindings( false );
                    this.txtEmployerName.Focus();
                    this.txtEmployerName.Select(0,0);
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Employer", MyDisplayMessage.RefreshError, ex );
                }
             
            }
            else if( sender.Equals( mnuEmployerSave ) )
            {
                /********************************************************************************
                *   Save
                ********************************************************************************/
                bindingEmployers.EndEdit();
                try
                {
                    employer.Save( true );
                    bindingEmployers.ResetBindings( false );
                    bindingEmployers.Sort = "";

                    if( dgvEmployers.SortOrder == SortOrder.Descending )
                    {
                        bindingEmployers.Sort = dgvEmployers.SortedColumn.DataPropertyName + " DESC";
                    }
                    else
                    {
                        bindingEmployers.Sort = dgvEmployers.SortedColumn.DataPropertyName + " ASC";
                    }

                    ResetDataGridViewEmployer( employer );
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Employer", MyDisplayMessage.SaveError, ex );
                }
                 
            }
            else if( sender.Equals( mnuEmployerCancel ) )
            {
                /********************************************************************************
                *   Cancel
                ********************************************************************************/
                if( employer.MyState == MyObjectState.New )
                {
                    bindingEmployers.RemoveCurrent();
                    if( bindingEmployers.Count > 0 )
                    {
                        bindingEmployers.Position = 0;
                        this.txtEmployerName.Focus();
                        this.txtEmployerName.Select( 0, 0 );
                    }
                    else
                    {
                        this.ucFilter.Focus();
                    }
                }
                else
                {
                    employer.Reset();
                    bindingEmployers.ResetCurrentItem();
                }
            }

        } 
        #endregion

        #region private void UpdateEmployerMenu( object sender, System.EventArgs e )
        private void UpdateEmployerMenu( object sender, System.EventArgs e )
        {

            if( bindingEmployers.Current != null )
            {

                this.txtEmployerName.ReadOnly = false;
                this.txtStreet1.ReadOnly = false;
                this.txtStreet2.ReadOnly = false;
                this.txtCity.ReadOnly = false;
                this.cmbStates.Enabled = true;
                this.mskZip.ReadOnly = false;
                this.mskPhone.ReadOnly = false;

                switch( ((Employer)bindingEmployers.Current).MyState )
                {

                    case MyObjectState.Modified:
                        mnuEmployerRemove.Enabled = true;
                        mnuEmployerRefresh.Enabled = true;
                        mnuEmployerSave.Enabled = true;
                        mnuEmployerCancel.Enabled = true;
                        break;

                    case MyObjectState.New:
                        mnuEmployerRemove.Enabled = true;
                        mnuEmployerRefresh.Enabled = false;
                        mnuEmployerSave.Enabled = true;
                        mnuEmployerCancel.Enabled = true;
                        break;

                    case MyObjectState.Current:
                        mnuEmployerRemove.Enabled = true;
                        mnuEmployerRefresh.Enabled = true;
                        mnuEmployerSave.Enabled = false;
                        mnuEmployerCancel.Enabled = false;
                        break;

                    default:
                        mnuEmployerRemove.Enabled = false;
                        mnuEmployerRefresh.Enabled = false;
                        mnuEmployerSave.Enabled = false;
                        mnuEmployerCancel.Enabled = false;
                        break;

                }

            }
            else
            {

                mnuEmployerRemove.Enabled = false;
                mnuEmployerRefresh.Enabled = false;
                mnuEmployerSave.Enabled = false;
                mnuEmployerCancel.Enabled = false;

                this.txtEmployerName.ReadOnly = true;
                this.txtStreet1.ReadOnly = true;
                this.txtStreet2.ReadOnly = true;
                this.txtCity.ReadOnly = true;
                this.cmbStates.Enabled = false;
                this.mskZip.ReadOnly = true;
                this.mskPhone.ReadOnly = true;

            }

        } 
        #endregion




        #region private bool CanChangeCurrentEmployer()
        private bool CanChangeCurrentEmployer()
        {
            bool rtnValue = true;

            if( bindingEmployers.Current != null )
            {

                Employer employer = (Employer)bindingEmployers.Current;

                switch( employer.MyState )
                {


                    case MyObjectState.New:
                    case MyObjectState.Modified:

                        switch( MyMessageBox.Show( this, "Employer", MyDisplayMessage.SaveConfirm ) )
                        {

                            case DialogResult.Yes:
                                try
                                {
                                    employer.Save( true );
                                    bindingEmployers.ResetCurrentItem();
                                    rtnValue = true;
                                }
                                catch( MyException ex )
                                {
                                    MyMessageBox.Show( this, "Employer", MyDisplayMessage.SaveError, ex );
                                    rtnValue = false;
                                }
                                break;

                            case DialogResult.No:
                                if( employer.MyState == MyObjectState.New )
                                {
                                    bindingEmployers.RemoveCurrent();
                                    bindingEmployers.ResetBindings( false );
                                    this.txtEmployerName.Focus();
                                }
                                else
                                {
                                    employer.Reset();
                                }
                                rtnValue = true;
                                break;

                            case DialogResult.Cancel:
                                rtnValue = false;
                                break;

                        }
                        break;

                }

            }

            return rtnValue;

        }
        #endregion

        #region private void ResetDataGridViewEmployer( Employer employer )
        private void ResetDataGridViewEmployer( Employer employer )
        {

            if( employer != null )
            {
                int row = bindingEmployers.IndexOf( employer );
                if( row >= 0 )
                {
                    dgvEmployers.BeginInvoke( (MethodInvoker)delegate()
                    {
                        dgvEmployers.Rows[row].Selected = true;
                        dgvEmployers.CurrentCell = dgvEmployers[0, row];
                    } );
                }
            }

        }
        #endregion




        #region private void ucFilter_OnFilterChanged( object sender, string filterString )
        private void ucFilter_OnFilterChanged( object sender, string filterString )
        {
            if( CanChangeCurrentEmployer() )
            {

                // can change the defendant; save current, so it can be reselcted after the filter
                if( bindingEmployers.Current != null )
                    _employerTemp = ((Employer)dgvEmployers.SelectedRows[0].DataBoundItem);

                // set the filter
                bindingEmployers.Filter = filterString;
                _strFilter = ((ucFilter)sender).FilterValue;

                if( _employerTemp != null )
                {
                    ResetDataGridViewEmployer( _employerTemp );
                    _employerTemp = null;
                }

            }
            else
            {
                // set the filter back to the previous value
                ((ucFilter)sender).FilterValue = _strFilter;
            }
        }
        #endregion

        #region private void dgvEmployers_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        /// <summary>
        /// This method catches a change in the datagridview selection and prompts the user
        /// to either save, disregard, or simply cancel the datagridviewchange if the state 
        /// of the current object is anything other than current. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvEmployers_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        {
            
            if( (dgvEmployers.Focused) && ( _GridViewState != GridViewState.Adding && _GridViewState != GridViewState.Sorting ) )
                if( !CanChangeCurrentEmployer() )
                    e.Cancel = true;

        } 
        #endregion

        #region private void dgvEmployers_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        private void dgvEmployers_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( e.RowIndex == -1 && dgvEmployers.SelectedRows.Count > 0 )
            {
                _GridViewState = GridViewState.Sorting;
                _employerTemp = ((Employer)dgvEmployers.SelectedRows[0].DataBoundItem);
            }
        } 
        #endregion

        #region private void dgvEmployers_Sorted( object sender, EventArgs e )
        private void dgvEmployers_Sorted( object sender, EventArgs e )
        {


            if( _employerTemp != null )
            {
                int row = bindingEmployers.IndexOf( _employerTemp );
                dgvEmployers.BeginInvoke( (MethodInvoker)delegate()
                {
                    dgvEmployers.Rows[row].Selected = true;
                    dgvEmployers.CurrentCell = dgvEmployers[0, row];
                } );

            }
            _employerTemp = null;
            _GridViewState = GridViewState.None;

        } 
        #endregion 

        #region private void dgvDefendants_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
        private void dgvDefendants_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
        {

            dgvDefendants.ClearSelection();

        }
        #endregion 

        #region private void btnClose_Click( object sender, EventArgs e )
        private void btnClose_Click( object sender, EventArgs e )
        {

            if( CanChangeCurrentEmployer() )
                this.Close();
        }
        #endregion


    }

}
