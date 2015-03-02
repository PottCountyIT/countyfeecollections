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
using System.Text;
using System.ComponentModel;
using System.Data;



namespace county.feecollections
{


    public class DefendantFeePayments : BaseCollection<FeePayment>
    {

       
        private int _intInitialPlanId;
        private Plans _Plans;




        #region private DefendantFeePayments() : base()
        private DefendantFeePayments() : base()
        {
            
        }
        #endregion

        #region public DefendantFeePayments( Plans plans, int defendantId, int planId ) : base( defendantId )
        public DefendantFeePayments( Plans plans, int defendantId, int planId ) : base( defendantId )
        {

            _Plans = plans;
            _intInitialPlanId = planId;

        }
        #endregion
        



        #region protected override object AddNewCore()
        /// <summary>
        /// Overrides the base constructor which tries to create a new object based on a 
        /// parameterless constructor. 
        /// </summary>
        /// <returns>a new object added to the collection.</returns>
        protected override object AddNewCore()
        {


            int planId = _intInitialPlanId;
            int feeTypeId = -1;


            // does the current plan have a fee with a balance
            int idx = _Plans.Find("ID", _intInitialPlanId);
            _Plans[idx].Fees.ApplySort( "PaymentOrder", ListSortDirection.Ascending );
            foreach( PlanFee fee in _Plans[idx].Fees )
            {
                if( fee.Balance > 0 )
                {
                    feeTypeId = fee.FeeTypeId;
                    break;
                }
            }

            // if the current plan has no balance find the first plan that does
            if( feeTypeId <= -1 )
            {
                foreach( Plan plan in _Plans )
                {

                    if( plan.ID != _intInitialPlanId )
                    {

                        plan.Fees.ApplySort( "PaymentOrder", ListSortDirection.Ascending );

                        foreach( PlanFee fee in plan.Fees )
                        {
                            if( fee.Balance > 0 )
                            {
                                planId = plan.ID;
                                feeTypeId = fee.FeeTypeId;
                                break;
                            }
                        }

                    }

                }

            }

            FeePayment payment = new FeePayment( planId, ParentId, feeTypeId );
            this.Add( payment );

            return payment;

        }
        #endregion

        #region protected override void RemoveItem( int index )
        protected override void RemoveItem( int index )
        {

            base.RemoveItem( index );

        }
        #endregion
        



    }
}
