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

    public partial class frmFeeTypes : Form
    {

        private FeeType _feeTypeTemp;
        private GridViewState _GridViewState = GridViewState.None;
        private FeeTypes _feeTypes;



        #region public frmFeeTypes()
        public frmFeeTypes()
        {

            try
            {
                _feeTypes = Helper.FeeTypeList;

            }
            catch( MyException myex )
            {
                MyMessageBox.Show( this, "Fee Type Master List", MyDisplayMessage.FormOpenError, myex );
                this.Close();
                return;
            }

            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );
            
            
        } 
        #endregion



        
        #region private void frmFeeTypes_Load( object sender, EventArgs e )
        private void frmFeeTypes_Load( object sender, EventArgs e )
        {

            
            bindingFeeTypes.RaiseListChangedEvents = false;
            bindingFeeTypes.DataSource = _feeTypes;
            bindingFeeTypes.RaiseListChangedEvents = true;

            bindingFeeTypes.Sort = "PaymentOrder ASC";

            bindingFeeTypes.ResetBindings( false );
            UpdateFeeTypeMenu( null, null );

            bindingFeeTypes.CurrentItemChanged += new System.EventHandler( this.UpdateFeeTypeMenu );
            dgvFeeTypes.CellMouseDown += new DataGridViewCellMouseEventHandler( dgvFeeTypes_CellMouseDown );
            dgvFeeTypes.Sorted += new EventHandler( dgvFeeTypes_Sorted );
            
        }
        #endregion

        #region private void mnuFeeType_Click( object sender, EventArgs e )
        private void mnuFeeType_Click( object sender, EventArgs e )
        {

            FeeType feetype = (FeeType)bindingFeeTypes.Current;

            if( sender.Equals( mnuFeeTypeNew ) )
            {
                /********************************************************************************
                *   New
                ********************************************************************************/
                if( CanChangeCurrentFeeType() )
                {

                    _GridViewState = GridViewState.Adding;
                    bindingFeeTypes.AddNew();
                    _GridViewState = GridViewState.None;

                }

            }
            else if( sender.Equals( mnuFeeTypeRemove ) )
            {
                /********************************************************************************
                *   Remove
                ********************************************************************************/
                if( DialogResult.OK == MyMessageBox.Show( this, "Fee Type", MyDisplayMessage.RemoveConfirm ) )
                {
                    try
                    {
                        bindingFeeTypes.RemoveCurrent();
                        bindingFeeTypes.ResetBindings( false );
                    }
                    catch( MyException ex )
                    {
                        MyMessageBox.Show( this, "Fee Type", MyDisplayMessage.RemoveError, ex );
                    }

                }
            }
            else if( sender.Equals( mnuFeeTypeRefresh ) )
            {
                /********************************************************************************
                *   Refresh
                ********************************************************************************/
                if( !feetype.MyState.Equals( MyObjectState.Current ) )
                {
                    if( DialogResult.Cancel == MyMessageBox.Show( this, "Fee Type", MyDisplayMessage.RefreshConfirm ) )
                    {
                        return;
                    }
                }

                try
                {
                    feetype.Refresh();
                    bindingFeeTypes.ResetBindings( false );
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Fee Type", MyDisplayMessage.RefreshError, ex );
                }

            }
            else if( sender.Equals( mnuFeeTypeSave ) )
            {
                /********************************************************************************
                *   Save
                ********************************************************************************/
                dgvFeeTypes.EndEdit();
                bindingFeeTypes.EndEdit();
                try
                {
                    feetype.Save( true );
                    bindingFeeTypes.ResetBindings( false );
                    /*
                     * 
                     * 
                     * will need to come up with better sorting when this form is updated.
                     * 
                     * 
                     * 
                     * 
                     */
                    bindingFeeTypes.Sort = "";
                    if( dgvFeeTypes.SortOrder == SortOrder.Descending )
                    {
                        bindingFeeTypes.Sort = dgvFeeTypes.SortedColumn.DataPropertyName + " DESC";
                    }
                    else
                    {
                        bindingFeeTypes.Sort = dgvFeeTypes.SortedColumn.DataPropertyName + " ASC";
                    }

                    ResetDataGridViewFeeType( feetype );
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Fee Type", MyDisplayMessage.SaveError, ex );
                }

            }
            else if( sender.Equals( mnuFeeTypeCancel ) )
            {
                /********************************************************************************
                *   Cancel
                ********************************************************************************/
                if( feetype.MyState == MyObjectState.New )
                {

                    bindingFeeTypes.RemoveCurrent();

                }
                else
                {
                    feetype.Reset();
                    bindingFeeTypes.ResetCurrentItem();
                }
            }

        }
        #endregion

        #region private void UpdateFeeTypeMenu( object sender, System.EventArgs e )
        private void UpdateFeeTypeMenu( object sender, System.EventArgs e )
        {

            if( bindingFeeTypes.Current != null )
            {

                switch( ((FeeType)bindingFeeTypes.Current).MyState )
                {

                    case MyObjectState.Modified:
                        mnuFeeTypeRemove.Enabled = true;
                        mnuFeeTypeRefresh.Enabled = true;
                        mnuFeeTypeSave.Enabled = true;
                        mnuFeeTypeCancel.Enabled = true;
                        break;

                    case MyObjectState.New:
                        mnuFeeTypeRemove.Enabled = true;
                        mnuFeeTypeRefresh.Enabled = false;
                        mnuFeeTypeSave.Enabled = true;
                        mnuFeeTypeCancel.Enabled = true;
                        break;

                    case MyObjectState.Current:
                        mnuFeeTypeRemove.Enabled = true;
                        mnuFeeTypeRefresh.Enabled = true;
                        mnuFeeTypeSave.Enabled = false;
                        mnuFeeTypeCancel.Enabled = false;
                        break;

                    default:
                        mnuFeeTypeRemove.Enabled = false;
                        mnuFeeTypeRefresh.Enabled = false;
                        mnuFeeTypeSave.Enabled = false;
                        mnuFeeTypeCancel.Enabled = false;
                        break;

                }

            }
            else
            {

                mnuFeeTypeRemove.Enabled = false;
                mnuFeeTypeRefresh.Enabled = false;
                mnuFeeTypeSave.Enabled = false;
                mnuFeeTypeCancel.Enabled = false;

            }

        }
        #endregion



        
        #region private bool CanChangeCurrentFeeType()
        private bool CanChangeCurrentFeeType()
        {
            bool rtnValue = true;

            if( bindingFeeTypes.Current != null )
            {

                FeeType feetype = (FeeType)bindingFeeTypes.Current;

                switch( feetype.MyState )
                {


                    case MyObjectState.New:
                    case MyObjectState.Modified:

                        switch( MyMessageBox.Show( this, "Fee Type", MyDisplayMessage.SaveConfirm ) )
                        {

                            case DialogResult.Yes:
                                dgvFeeTypes.EndEdit();
                                bindingFeeTypes.EndEdit();
                                try
                                {
                                    feetype.Save( true );
                                    bindingFeeTypes.ResetCurrentItem();
                                    rtnValue = true;
                                }
                                catch( MyException ex )
                                {
                                    MyMessageBox.Show( this, "Fee Type", MyDisplayMessage.SaveError, ex );
                                    rtnValue = false;
                                }
                                break;

                            case DialogResult.No:
                                if( feetype.MyState == MyObjectState.New )
                                {
                                    bindingFeeTypes.RemoveCurrent();
                                    bindingFeeTypes.ResetBindings( false );
                                }
                                else
                                {
                                    feetype.Reset();
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

        #region private void ResetDataGridViewFeeType( FeeType feeType )
        private void ResetDataGridViewFeeType( FeeType feeType )
        {

            if( feeType != null )
            {
                int row = bindingFeeTypes.IndexOf( feeType );
                if( row >= 0 )
                {
                    dgvFeeTypes.BeginInvoke( (MethodInvoker)delegate()
                    {
                        dgvFeeTypes.Rows[row].Selected = true;
                        dgvFeeTypes.CurrentCell = dgvFeeTypes[0, row];
                    } );
                }
            }

        }
        #endregion
        
        #region private void dgvFeeTypes_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        /// <summary>
        /// This method catches a change in the datagridview selection and prompts the user
        /// to either save, disregard, or simply cancel the datagridviewchange if the state 
        /// of the current object is anything other than current. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvFeeTypes_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        {

            if( (dgvFeeTypes.Focused) && (_GridViewState != GridViewState.Adding && _GridViewState != GridViewState.Sorting) )
                if( !CanChangeCurrentFeeType() )
                    e.Cancel = true;

        }
        #endregion
        
        #region private void dgvFeeTypes_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        private void dgvFeeTypes_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( e.RowIndex == -1 && dgvFeeTypes.SelectedRows.Count > 0 )
            {
                _GridViewState = GridViewState.Sorting;
                _feeTypeTemp = ((FeeType)dgvFeeTypes.SelectedRows[0].DataBoundItem);
            }
        }
        #endregion

        #region private void dgvFeeTypes_Sorted( object sender, EventArgs e )
        private void dgvFeeTypes_Sorted( object sender, EventArgs e )
        {


            if( _feeTypeTemp != null )
            {
                int row = bindingFeeTypes.IndexOf( _feeTypeTemp );
                dgvFeeTypes.BeginInvoke( (MethodInvoker)delegate()
                {
                    dgvFeeTypes.Rows[row].Selected = true;
                    dgvFeeTypes.CurrentCell = dgvFeeTypes[0, row];
                } );

            }
            _feeTypeTemp = null;
            _GridViewState = GridViewState.None;

        }
        #endregion



        #region private void btnClose_Click( object sender, EventArgs e )
        private void btnClose_Click( object sender, EventArgs e )
        {

            if( CanChangeCurrentFeeType() )
            {
                this.Close();
            }
        }
        #endregion

        

    }
}
