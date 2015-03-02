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

    public partial class frmPaymentArrangementTypes : Form
    {

        private PaymentArrangementType _paymentArrangementTypeTemp;
        private PaymentArrangementTypes _paymentArrangementTypes;        
        private GridViewState _GridViewState = GridViewState.None;
        


        #region public frmPaymentArrangementTypes()
        public frmPaymentArrangementTypes()
        {

            try
            {
                _paymentArrangementTypes = Helper.PaymentArrangementTypeList;

            }
            catch( MyException myex )
            {
                MyMessageBox.Show( this, "Payment Arrangement Type Master List", MyDisplayMessage.FormOpenError, myex );
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




        #region private void frmPaymentArrangementTypes_Load( object sender, EventArgs e )
        private void frmPaymentArrangementTypes_Load( object sender, EventArgs e )
        {

            
            bindingPaymentArrangementTypes.RaiseListChangedEvents = false;
            bindingPaymentArrangementTypes.DataSource = _paymentArrangementTypes;
            bindingPaymentArrangementTypes.RaiseListChangedEvents = true;

            bindingPaymentArrangementTypes.Sort = "PaymentArrangementTypeName ASC";

            bindingPaymentArrangementTypes.ResetBindings( false );
            UpdatePaymentArrangementTypeMenu( null, null );

            bindingPaymentArrangementTypes.CurrentItemChanged += new System.EventHandler( this.UpdatePaymentArrangementTypeMenu );
            
            dgvPaymentArrangementTypes.CellMouseDown += new DataGridViewCellMouseEventHandler( dgvPaymentArrangementTypes_CellMouseDown );
            dgvPaymentArrangementTypes.Sorted += new EventHandler( dgvPaymentArrangementTypes_Sorted );
            
        }
        #endregion

        #region private void mnuPaymentArrangementType_Click( object sender, EventArgs e )
        private void mnuPaymentArrangementType_Click( object sender, EventArgs e )
        {

            PaymentArrangementType paymentarrangementtype = (PaymentArrangementType)bindingPaymentArrangementTypes.Current;

            /********************************************************************************
            *   New
            ********************************************************************************/
            if( sender.Equals( mnuPaymentArrangementTypeNew ) )
            {
                if( CanChangeCurrentPaymentArrangementType() )
                {

                    _GridViewState = GridViewState.Adding;
                    bindingPaymentArrangementTypes.AddNew();
                    _GridViewState = GridViewState.None;

                }

            }
            /********************************************************************************
            *   Remove
            ********************************************************************************/
            else if( sender.Equals( mnuPaymentArrangementTypeRemove ) )
            {
                if( DialogResult.OK == MyMessageBox.Show( this, "Payment Arrangement Type", MyDisplayMessage.RemoveConfirm ) )
                {
                    try
                    {
                        bindingPaymentArrangementTypes.RemoveCurrent();
                        bindingPaymentArrangementTypes.ResetBindings( false );
                    }
                    catch( MyException ex )
                    {
                        MyMessageBox.Show( this, "Payment Arrangement Type", MyDisplayMessage.RemoveError, ex );
                    }

                }
            }
            /********************************************************************************
            *   Refresh
            ********************************************************************************/
            else if( sender.Equals( mnuPaymentArrangementTypeRefresh ) )
            {
                if( !paymentarrangementtype.MyState.Equals( MyObjectState.Current ) )
                {
                    if( DialogResult.Cancel == MyMessageBox.Show( this, "Payment Arrangement Type", MyDisplayMessage.RefreshConfirm ) )
                    {
                        return;
                    }
                }

                try
                {
                    paymentarrangementtype.Refresh();
                    bindingPaymentArrangementTypes.ResetBindings( false );
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Payment Arrangement Type", MyDisplayMessage.RefreshError, ex );
                }

            }
            /********************************************************************************
            *   Save
            ********************************************************************************/
            else if( sender.Equals( mnuPaymentArrangementTypeSave ) )
            {
                dgvPaymentArrangementTypes.EndEdit();
                bindingPaymentArrangementTypes.EndEdit();
                try
                {
                    paymentarrangementtype.Save( true );
                    bindingPaymentArrangementTypes.ResetBindings( false );


                    bindingPaymentArrangementTypes.Sort = "";
                    if( dgvPaymentArrangementTypes.SortOrder == SortOrder.Descending )
                    {
                        bindingPaymentArrangementTypes.Sort = dgvPaymentArrangementTypes.SortedColumn.DataPropertyName + " DESC";
                    }
                    else
                    {
                        bindingPaymentArrangementTypes.Sort = dgvPaymentArrangementTypes.SortedColumn.DataPropertyName + " ASC";
                    }

                    ResetDataGridViewPaymentArrangementType( paymentarrangementtype );
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Payment Arrangement Type", MyDisplayMessage.SaveError, ex );
                }

            }
            /********************************************************************************
            *   Cancel
            ********************************************************************************/
            else if( sender.Equals( mnuPaymentArrangementTypeCancel ) )
            {
                if( paymentarrangementtype.MyState == MyObjectState.New )
                {

                    bindingPaymentArrangementTypes.RemoveCurrent();

                }
                else
                {
                    paymentarrangementtype.Reset();
                    bindingPaymentArrangementTypes.ResetCurrentItem();
                }
            }

        }
        #endregion

        #region private void UpdatePaymentArrangementTypeMenu( object sender, System.EventArgs e )
        private void UpdatePaymentArrangementTypeMenu( object sender, System.EventArgs e )
        {

            if( bindingPaymentArrangementTypes.Current != null )
            {

                switch( ((PaymentArrangementType)bindingPaymentArrangementTypes.Current).MyState )
                {

                    case MyObjectState.Modified:
                        mnuPaymentArrangementTypeRemove.Enabled = true;
                        mnuPaymentArrangementTypeRefresh.Enabled = true;
                        mnuPaymentArrangementTypeSave.Enabled = true;
                        mnuPaymentArrangementTypeCancel.Enabled = true;
                        break;

                    case MyObjectState.New:
                        mnuPaymentArrangementTypeRemove.Enabled = true;
                        mnuPaymentArrangementTypeRefresh.Enabled = false;
                        mnuPaymentArrangementTypeSave.Enabled = true;
                        mnuPaymentArrangementTypeCancel.Enabled = true;
                        break;

                    case MyObjectState.Current:
                        mnuPaymentArrangementTypeRemove.Enabled = true;
                        mnuPaymentArrangementTypeRefresh.Enabled = true;
                        mnuPaymentArrangementTypeSave.Enabled = false;
                        mnuPaymentArrangementTypeCancel.Enabled = false;
                        break;

                    default:
                        mnuPaymentArrangementTypeRemove.Enabled = false;
                        mnuPaymentArrangementTypeRefresh.Enabled = false;
                        mnuPaymentArrangementTypeSave.Enabled = false;
                        mnuPaymentArrangementTypeCancel.Enabled = false;
                        break;

                }

            }
            else
            {

                mnuPaymentArrangementTypeRemove.Enabled = false;
                mnuPaymentArrangementTypeRefresh.Enabled = false;
                mnuPaymentArrangementTypeSave.Enabled = false;
                mnuPaymentArrangementTypeCancel.Enabled = false;

            }

        }
        #endregion



        
        #region private bool CanChangeCurrentPaymentArrangementType()
        private bool CanChangeCurrentPaymentArrangementType()
        {
            bool rtnValue = true;

            if( bindingPaymentArrangementTypes.Current != null )
            {

                PaymentArrangementType paymentarrangementtype = (PaymentArrangementType)bindingPaymentArrangementTypes.Current;

                switch( paymentarrangementtype.MyState )
                {


                    case MyObjectState.New:
                    case MyObjectState.Modified:

                        switch( MyMessageBox.Show( this, "Payment Arrangement Type", MyDisplayMessage.SaveConfirm ) )
                        {

                            case DialogResult.Yes:
                                dgvPaymentArrangementTypes.EndEdit();
                                bindingPaymentArrangementTypes.EndEdit();
                                try
                                {
                                    paymentarrangementtype.Save( true );
                                    bindingPaymentArrangementTypes.ResetCurrentItem();
                                    rtnValue = true;
                                }
                                catch( MyException ex )
                                {
                                    MyMessageBox.Show( this, "Payment Arrangement Type", MyDisplayMessage.SaveError, ex );
                                    rtnValue = false;
                                }
                                break;

                            case DialogResult.No:
                                if( paymentarrangementtype.MyState == MyObjectState.New )
                                {
                                    bindingPaymentArrangementTypes.RemoveCurrent();
                                    bindingPaymentArrangementTypes.ResetBindings( false );
                                }
                                else
                                {
                                    paymentarrangementtype.Reset();
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

        #region private void ResetDataGridViewPaymentArrangementType( PaymentArrangementType paymentarrangementtype )
        private void ResetDataGridViewPaymentArrangementType( PaymentArrangementType paymentarrangementtype )
        {

            if( paymentarrangementtype != null )
            {
                int row = bindingPaymentArrangementTypes.IndexOf( paymentarrangementtype );
                if( row >= 0 )
                {
                    dgvPaymentArrangementTypes.BeginInvoke( (MethodInvoker)delegate()
                    {
                        dgvPaymentArrangementTypes.Rows[row].Selected = true;
                        dgvPaymentArrangementTypes.CurrentCell = dgvPaymentArrangementTypes[0, row];
                    } );
                }
            }

        }
        #endregion
        
        #region private void dgvPaymentArrangementTypes_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        /// <summary>
        /// This method catches a change in the datagridview selection and prompts the user
        /// to either save, disregard, or simply cancel the datagridviewchange if the state 
        /// of the current object is anything other than current. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvPaymentArrangementTypes_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        {

            if( (dgvPaymentArrangementTypes.Focused) && (_GridViewState != GridViewState.Adding && _GridViewState != GridViewState.Sorting) )
                if( !CanChangeCurrentPaymentArrangementType() )
                    e.Cancel = true;

        }
        #endregion
        
        #region private void dgvPaymentArrangementTypes_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        private void dgvPaymentArrangementTypes_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( e.RowIndex == -1 && dgvPaymentArrangementTypes.SelectedRows.Count > 0 )
            {
                _GridViewState = GridViewState.Sorting;
                _paymentArrangementTypeTemp = ((PaymentArrangementType)dgvPaymentArrangementTypes.SelectedRows[0].DataBoundItem);
            }
        }
        #endregion

        #region private void dgvPaymentArrangementTypes_Sorted( object sender, EventArgs e )
        private void dgvPaymentArrangementTypes_Sorted( object sender, EventArgs e )
        {


            if( _paymentArrangementTypeTemp != null )
            {
                int row = bindingPaymentArrangementTypes.IndexOf( _paymentArrangementTypeTemp );
                dgvPaymentArrangementTypes.BeginInvoke( (MethodInvoker)delegate()
                {
                    dgvPaymentArrangementTypes.Rows[row].Selected = true;
                    dgvPaymentArrangementTypes.CurrentCell = dgvPaymentArrangementTypes[0, row];
                } );

            }
            _paymentArrangementTypeTemp = null;
            _GridViewState = GridViewState.None;

        }
        #endregion



        #region private void btnClose_Click( object sender, EventArgs e )
        private void btnClose_Click( object sender, EventArgs e )
        {

            if( CanChangeCurrentPaymentArrangementType() )
            {
                this.Close();
            }
        }
        #endregion



        

    }
}
