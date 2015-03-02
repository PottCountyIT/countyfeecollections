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

    public partial class ucFees : UserControl, INotifyPropertyChanged
    {

        private double _dblTotalAmountDue;
        public double TotalAmountDue
        {
            get { return _dblTotalAmountDue; }
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

		public ucFees()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );
        }

        private void RaisePropertyChangedEvent(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public void SetBindingSource( ref BindingSource bindingPlans )
        {
            this.SuspendLayout();

            dgvFeesClmFeeTypes.DataSource = Helper.FeeTypeList;
            dgvFeesClmFeeTypes.ValueMember = "ID";
            dgvFeesClmFeeTypes.DisplayMember = "FeeTypeName";

            this.bindingFees.DataMember = "Fees";
            this.bindingFees.DataSource = bindingPlans;
          
            this.dgvFees.CellEndEdit += new DataGridViewCellEventHandler( dgvFees_CreateTotalAmount );
            this.dgvFees.DataBindingComplete += new DataGridViewBindingCompleteEventHandler( dgvFees_DataBindingComplete );

            this.Focus();
            this.ResumeLayout( false );
        }

        private void dgvFees_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
        {
            if( e.ListChangedType != ListChangedType.ItemAdded )
                dgvFees_CreateTotalAmount( this, new DataGridViewCellEventArgs( 1, 0 ) );
        } 

        private void dgvFees_CreateTotalAmount( object sender, DataGridViewCellEventArgs e )
        {
            if( dgvFees.Columns[e.ColumnIndex].DataPropertyName == "Amount" )
            {
                _dblTotalAmountDue = 0;

                foreach( DataGridViewRow dr in dgvFees.Rows )
                {
                    if( dr != null && dr.Cells[0].Value != null && Helper.FeeTypeList[Helper.FeeTypeList.Find( "ID", dr.Cells[0].Value )].Billable )
                    {
                        _dblTotalAmountDue += (double)dr.Cells[1].Value;
                    }
                }                
                RaisePropertyChangedEvent( "TotalAmountDue" );
            }
        }

        private void mnuPlanFee_Click( object sender, EventArgs e )
        {
            dgvFees.EndEdit();
            /********************************************************************************
            *   Add
            ********************************************************************************/
            if( sender.Equals( mnuPlanFeeAdd ) )
            {
                bindingFees.AddNew();

                dgvFees.CurrentCell = dgvFees.CurrentRow.Cells[0];
                dgvFees.CurrentCell.Selected = true;
                dgvFees.BeginEdit( true );

            }
            /********************************************************************************
            *   Remove
            ********************************************************************************/
            else if( sender.Equals( mnuPlanFeeRemove ) )
            {
                List<PlanFee> lstPlanFees = new List<PlanFee>();

                foreach( DataGridViewRow dgr in dgvFees.SelectedRows )
                {
                    lstPlanFees.Add( (PlanFee)dgr.DataBoundItem );
                }

                dgvFees.SuspendLayout();
                if( lstPlanFees.Count > 0 )
                {
                    foreach( PlanFee planfee in lstPlanFees )
                    {
                        try
                        {
                            bindingFees.Remove( planfee );
                        }
                        catch( MyException ex )
                        {
                            MyMessageBox.Show( this, "Plan Fee", MyDisplayMessage.RemoveError, ex );
                        }
                    }
                }
                dgvFees.ResumeLayout();
                lstPlanFees.Clear();
                dgvFees.ClearSelection();
            }
        }

        private void ucFees_Leave( object sender, EventArgs e )
        {
            dgvFees.EndEdit();
            dgvFees.ClearSelection();
        }

        public void Clear()
        {
            dgvFees.SuspendLayout();
            bindingFees.Clear();
            dgvFees.ResumeLayout();
        }
    }
}
