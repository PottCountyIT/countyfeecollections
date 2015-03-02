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

    public partial class ucPayments : UserControl, INotifyPropertyChanged
    {
        private double _dblTotalAmountPaid;

        public double TotalAmountPaid
        {
            get { return _dblTotalAmountPaid; }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChangedEvent( string propertyName )
        {
            if( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }

        public ucPayments()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

        } 

        public void SetBindingSource( ref BindingSource bindingPlans )
        {
            this.SuspendLayout();
            this.dgvPayments.SuspendLayout();

            this.bindingPayments.DataMember = "Payments";
            this.bindingPayments.DataSource = bindingPlans;

            this.dgvPayments.CellEndEdit += new DataGridViewCellEventHandler( dgvPayments_CreateTotalAmount );
            this.dgvPayments.DataBindingComplete += new DataGridViewBindingCompleteEventHandler( dgvPayments_DataBindingComplete );

            this.Focus();

            this.dgvPayments.ResumeLayout( false );
            this.ResumeLayout();
        }
       
        private void dgvPayments_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
        {
            if( e.ListChangedType != ListChangedType.ItemAdded )
                dgvPayments_CreateTotalAmount( this, new DataGridViewCellEventArgs( 2, 0 ) );
        }

        private void dgvPayments_CreateTotalAmount( object sender, DataGridViewCellEventArgs e )
        {
            if( dgvPayments.Columns[e.ColumnIndex].DataPropertyName == "Amount" )
            {
                _dblTotalAmountPaid = 0;
                foreach( DataGridViewRow dr in dgvPayments.Rows )
                {
                    if( dr != null && dr.Cells[e.ColumnIndex].Value != null )
                    {
                        _dblTotalAmountPaid += (double)dr.Cells[e.ColumnIndex].Value;
                    }
                }
                RaisePropertyChangedEvent( "TotalAmountPaid" );
            }
        }


        private void mnuPayments_Click( object sender, EventArgs e )
        {

            /********************************************************************************
            *   Add
            ********************************************************************************/
            if( sender.Equals( mnuPlanPaymentsAdd ) )
            {

                dgvPayments.EndEdit();

                frmPayment frm = new frmPayment( ref bindingPayments );

                if( !frm.IsDisposed )
                {
                    frm.ShowDialog( this );
                    dgvPayments_CreateTotalAmount( this, new DataGridViewCellEventArgs( 2, 0 ) );
                }
            }
            /********************************************************************************
            *   Remove
            ********************************************************************************/
            else if( sender.Equals( mnuPlanPaymentsRemove ) )
            {

                List<FeePayment> lstPlanPayments = new List<FeePayment>();

                foreach( DataGridViewRow dgr in dgvPayments.SelectedRows )
                {
                    lstPlanPayments.Add( (FeePayment)dgr.DataBoundItem );
                }


                dgvPayments.SuspendLayout();
                if( lstPlanPayments.Count > 0 )
                {

                    foreach( FeePayment planfee in lstPlanPayments )
                    {

                        try
                        {
                            bindingPayments.Remove( planfee );
                        }
                        catch( MyException ex )
                        {
                            MyMessageBox.Show( this, "Plan Payments", MyDisplayMessage.RemoveError, ex );
                        }

                    }

                }

                dgvPayments.ResumeLayout();
                lstPlanPayments.Clear();
                dgvPayments.ClearSelection();

            }

        }

        private void ucPayments_Leave( object sender, System.EventArgs e )
        {
            dgvPayments.EndEdit();
            dgvPayments.ClearSelection();
        } 

        public void Clear()
        {
            
            dgvPayments.SuspendLayout();
            bindingPayments.Clear();
            dgvPayments.ResumeLayout();

        }
    }
}
