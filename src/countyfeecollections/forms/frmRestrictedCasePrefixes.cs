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


    public partial class frmRestrictedCasePrefixes : Form
    {


        
        private RestrictedCasePrefix _RestrictedCasePrefixTemp;
        private RestrictedCasePrefixes _RestrictedCasePrefixes;        
        private GridViewState _GridViewState = GridViewState.None;
        


        #region public frmRestrictedCasePrefixes()
        public frmRestrictedCasePrefixes()
        {

            try
            {
                _RestrictedCasePrefixes = Helper.RestrictedCasePrefixesList;

            }
            catch( MyException myex )
            {
                MyMessageBox.Show( this, "Restricted Case Prefixes Master List", MyDisplayMessage.FormOpenError, myex );
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




        #region private void frmRestrictedCasePrefixes_Load( object sender, EventArgs e )
        private void frmRestrictedCasePrefixes_Load( object sender, EventArgs e )
        {


            bindingRestrictedCasePrefixes.RaiseListChangedEvents = false;
            bindingRestrictedCasePrefixes.DataSource = _RestrictedCasePrefixes;
            bindingRestrictedCasePrefixes.RaiseListChangedEvents = true;

            bindingRestrictedCasePrefixes.Sort = "CasePrefix ASC";

            bindingRestrictedCasePrefixes.ResetBindings( false );
            UpdateRestrictedCasePrefixesMenu( null, null );

            bindingRestrictedCasePrefixes.CurrentItemChanged += new System.EventHandler( this.UpdateRestrictedCasePrefixesMenu );


            dgvRestrictedCasePrefixes.CellMouseDown += new DataGridViewCellMouseEventHandler( dgvRestrictedCasePrefixes_CellMouseDown );
            dgvRestrictedCasePrefixes.Sorted += new EventHandler( dgvRestrictedCasePrefixes_Sorted );
            
        }
        #endregion

        #region private void mnuRestrictedCasePrefixes_Click( object sender, EventArgs e )
        private void mnuRestrictedCasePrefixes_Click( object sender, EventArgs e )
        {

            RestrictedCasePrefix restrictedcaseprefix = (RestrictedCasePrefix)bindingRestrictedCasePrefixes.Current;

            /********************************************************************************
            *   New
            ********************************************************************************/
            if( sender.Equals( mnuRestrictedCasePrefixesNew ) )
            {
                if( CanChangeCurrentRestrictedCasePrefix() )
                {

                    _GridViewState = GridViewState.Adding;
                    bindingRestrictedCasePrefixes.AddNew();
                    _GridViewState = GridViewState.None;

                }

            }
            /********************************************************************************
            *   Remove
            ********************************************************************************/
            else if( sender.Equals( mnuRestrictedCasePrefixesRemove ) )
            {
                if( DialogResult.OK == MyMessageBox.Show( this, "Restricted Case Prefixes", MyDisplayMessage.RemoveConfirm ) )
                {
                    try
                    {
                        bindingRestrictedCasePrefixes.RemoveCurrent();
                        bindingRestrictedCasePrefixes.ResetBindings( false );
                    }
                    catch( MyException ex )
                    {
                        MyMessageBox.Show( this, "Restricted Case Prefixes", MyDisplayMessage.RemoveError, ex );
                    }

                }
            }
            /********************************************************************************
            *   Refresh
            ********************************************************************************/
            else if( sender.Equals( mnuRestrictedCasePrefixesRefresh ) )
            {
                if( !restrictedcaseprefix.MyState.Equals( MyObjectState.Current ) )
                {
                    if( DialogResult.Cancel == MyMessageBox.Show( this, "Restricted Case Prefixes", MyDisplayMessage.RefreshConfirm ) )
                    {
                        return;
                    }
                }

                try
                {
                    restrictedcaseprefix.Refresh();
                    bindingRestrictedCasePrefixes.ResetBindings( false );
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Restricted Case Prefixes", MyDisplayMessage.RefreshError, ex );
                }

            }
            /********************************************************************************
            *   Save
            ********************************************************************************/
            else if( sender.Equals( mnuRestrictedCasePrefixesSave ) )
            {
                dgvRestrictedCasePrefixes.EndEdit();
                bindingRestrictedCasePrefixes.EndEdit();
                try
                {
                    restrictedcaseprefix.Save( true );
                    bindingRestrictedCasePrefixes.ResetBindings( false );


                    bindingRestrictedCasePrefixes.Sort = "";
                    if( dgvRestrictedCasePrefixes.SortOrder == SortOrder.Descending )
                    {
                        bindingRestrictedCasePrefixes.Sort = dgvRestrictedCasePrefixes.SortedColumn.DataPropertyName + " DESC";
                    }
                    else
                    {
                        bindingRestrictedCasePrefixes.Sort = dgvRestrictedCasePrefixes.SortedColumn.DataPropertyName + " ASC";
                    }

                    ResetDataGridViewRestrictedCasePrefixes( restrictedcaseprefix );
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Restricted Case Prefixes", MyDisplayMessage.SaveError, ex );
                }

            }
            /********************************************************************************
            *   Cancel
            ********************************************************************************/
            else if( sender.Equals( mnuRestrictedCasePrefixesCancel ) )
            {
                if( restrictedcaseprefix.MyState == MyObjectState.New )
                {

                    bindingRestrictedCasePrefixes.RemoveCurrent();

                }
                else
                {
                    restrictedcaseprefix.Reset();
                    bindingRestrictedCasePrefixes.ResetCurrentItem();
                }
            }

        }
        #endregion

        #region private void UpdateRestrictedCasePrefixesMenu( object sender, System.EventArgs e )
        private void UpdateRestrictedCasePrefixesMenu( object sender, System.EventArgs e )
        {

            if( bindingRestrictedCasePrefixes.Current != null )
            {

                switch( ((RestrictedCasePrefix)bindingRestrictedCasePrefixes.Current).MyState )
                {

                    case MyObjectState.Modified:
                        
                        mnuRestrictedCasePrefixesRemove.Enabled = true;
                        mnuRestrictedCasePrefixesRefresh.Enabled = true;
                        mnuRestrictedCasePrefixesSave.Enabled = true;
                        mnuRestrictedCasePrefixesCancel.Enabled = true;
                        break;

                    case MyObjectState.New:
                        mnuRestrictedCasePrefixesRemove.Enabled = true;
                        mnuRestrictedCasePrefixesRefresh.Enabled = false;
                        mnuRestrictedCasePrefixesSave.Enabled = true;
                        mnuRestrictedCasePrefixesCancel.Enabled = true;
                        break;

                    case MyObjectState.Current:
                        mnuRestrictedCasePrefixesRemove.Enabled = true;
                        mnuRestrictedCasePrefixesRefresh.Enabled = true;
                        mnuRestrictedCasePrefixesSave.Enabled = false;
                        mnuRestrictedCasePrefixesCancel.Enabled = false;
                        break;

                    default:
                        mnuRestrictedCasePrefixesRemove.Enabled = false;
                        mnuRestrictedCasePrefixesRefresh.Enabled = false;
                        mnuRestrictedCasePrefixesSave.Enabled = false;
                        mnuRestrictedCasePrefixesCancel.Enabled = false;
                        break;

                }

            }
            else
            {

                mnuRestrictedCasePrefixesRemove.Enabled = false;
                mnuRestrictedCasePrefixesRefresh.Enabled = false;
                mnuRestrictedCasePrefixesSave.Enabled = false;
                mnuRestrictedCasePrefixesCancel.Enabled = false;

            }

        }
        #endregion




        #region private bool CanChangeCurrentRestrictedCasePrefix()
        private bool CanChangeCurrentRestrictedCasePrefix()
        {
            bool rtnValue = true;

            if( bindingRestrictedCasePrefixes.Current != null )
            {

                RestrictedCasePrefix restrictedcaseprefix = (RestrictedCasePrefix)bindingRestrictedCasePrefixes.Current;

                switch( restrictedcaseprefix.MyState )
                {


                    case MyObjectState.New:
                    case MyObjectState.Modified:

                        switch( MyMessageBox.Show( this, "Restricted Case Prefixes", MyDisplayMessage.SaveConfirm ) )
                        {

                            case DialogResult.Yes:
                                dgvRestrictedCasePrefixes.EndEdit();
                                bindingRestrictedCasePrefixes.EndEdit();
                                try
                                {
                                    restrictedcaseprefix.Save( true );
                                    bindingRestrictedCasePrefixes.ResetCurrentItem();
                                    rtnValue = true;
                                }
                                catch( MyException ex )
                                {
                                    MyMessageBox.Show( this, "Restricted Case Prefixes", MyDisplayMessage.SaveError, ex );
                                    rtnValue = false;
                                }
                                break;

                            case DialogResult.No:
                                if( restrictedcaseprefix.MyState == MyObjectState.New )
                                {
                                    bindingRestrictedCasePrefixes.RemoveCurrent();
                                    bindingRestrictedCasePrefixes.ResetBindings( false );
                                }
                                else
                                {
                                    restrictedcaseprefix.Reset();
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

        #region private void ResetDataGridViewRestrictedCasePrefixes( RestrictedCasePrefix restrictedcaseprefix )
        private void ResetDataGridViewRestrictedCasePrefixes( RestrictedCasePrefix restrictedcaseprefix )
        {

            if( restrictedcaseprefix != null )
            {
                int row = bindingRestrictedCasePrefixes.IndexOf( restrictedcaseprefix );
                if( row >= 0 )
                {
                    dgvRestrictedCasePrefixes.BeginInvoke( (MethodInvoker)delegate()
                    {
                        dgvRestrictedCasePrefixes.Rows[row].Selected = true;
                        dgvRestrictedCasePrefixes.CurrentCell = dgvRestrictedCasePrefixes[0, row];
                    } );
                }
            }

        }
        #endregion

        #region private void dgvRestrictedCasePrefixes_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        /// <summary>
        /// This method catches a change in the datagridview selection and prompts the user
        /// to either save, disregard, or simply cancel the datagridviewchange if the state 
        /// of the current object is anything other than current. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRestrictedCasePrefixes_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        {

            if( (dgvRestrictedCasePrefixes.Focused) && (_GridViewState != GridViewState.Adding && _GridViewState != GridViewState.Sorting) )
                if( !CanChangeCurrentRestrictedCasePrefix() )
                    e.Cancel = true;

        }
        #endregion

        #region private void dgvRestrictedCasePrefixes_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        private void dgvRestrictedCasePrefixes_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( e.RowIndex == -1 && dgvRestrictedCasePrefixes.SelectedRows.Count > 0 )
            {
                _GridViewState = GridViewState.Sorting;
                _RestrictedCasePrefixTemp = ((RestrictedCasePrefix)dgvRestrictedCasePrefixes.SelectedRows[0].DataBoundItem);
            }
        }
        #endregion

        #region private void dgvRestrictedCasePrefixes_Sorted( object sender, EventArgs e )
        private void dgvRestrictedCasePrefixes_Sorted( object sender, EventArgs e )
        {


            if( _RestrictedCasePrefixTemp != null )
            {
                int row = bindingRestrictedCasePrefixes.IndexOf( _RestrictedCasePrefixTemp );
                dgvRestrictedCasePrefixes.BeginInvoke( (MethodInvoker)delegate()
                {
                    dgvRestrictedCasePrefixes.Rows[row].Selected = true;
                    dgvRestrictedCasePrefixes.CurrentCell = dgvRestrictedCasePrefixes[0, row];
                } );

            }
            _RestrictedCasePrefixTemp = null;
            _GridViewState = GridViewState.None;

        }
        #endregion



        #region private void btnClose_Click( object sender, EventArgs e )
        private void btnClose_Click( object sender, EventArgs e )
        {

            if( CanChangeCurrentRestrictedCasePrefix() )
            {
                this.Close();
            }
        }
        #endregion

     





    }
}
