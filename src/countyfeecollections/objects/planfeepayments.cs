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
using System.Data.SqlClient;
using System.Data;



namespace county.feecollections
{

    
    public class PlanFeePayments : BaseCollection<FeePayment>
    {

        private int _intPlanId;




        #region private PlanFeePayments() : base()
        private PlanFeePayments() : base()
        {
            
        }
        #endregion


        #region public PlanFeePayments( int planId, int defendnatId ) : base( defendnatId )
        public PlanFeePayments( int planId, int defendnatId ) : base( defendnatId )
        {

            _intPlanId = planId;

            this.IsLoading = true;
            BuildPlanFeePayments();            
            this.IsLoading = false;

        }
        #endregion


        #region protected override object AddNewCore()
        /// <summary>
        /// Overrides the base constructor which tries to create a new object based on a 
        /// parameterless constructor.  This object was not designed to exist by itself and
        /// only exposes constructors requiring key(s) that define the parent object.
        /// </summary>
        /// <returns>a new object added to the collection.</returns>
        protected override object AddNewCore()
        {

            int feeTypeId = ( Helper.FeeTypeList.Count > 0 ) ? Helper.FeeTypeList[0].ID : 0;

            FeePayment payment = new FeePayment( _intPlanId, ParentId, feeTypeId );
            this.Add( payment );

            return payment;

        }
        #endregion


        #region public void SavePlanFeePayments( SqlTransaction trx )
        public void SavePlanFeePayments( SqlTransaction trx )
        {

            if( ParentId > -1 )
            {
                base.UpdateDate = DateTime.Now;

                // synchronizing the new and removed items with the database
                foreach( FeePayment payment in base.RemovedObjects )
                    payment.Remove( trx );

                for( int i = 0; i < this.Items.Count; i++ )
                {
                    FeePayment payment = this.Items[i];

                    if( payment.MyState == MyObjectState.New || payment.MyState == MyObjectState.Modified )
                    {

                        if( payment.MyState == MyObjectState.New )
                        {
                            payment = FeePayment.UpdateFeePaymentIds( payment, _intPlanId, ParentId, payment.FeeTypeId );
                        }

                        payment.Save( trx, base.UpdateDate );
                    }

                }

            }

        }
        #endregion


        #region private void BuildPlanFeePayments()
        private void BuildPlanFeePayments()
        {

            const string sql = "SELECT feetypeid, receiveddate, amount, "
                + "updatedby, updateddate "
                + "FROM FeePayment "
                + "WHERE defendantid = @id "
                + "AND planid = @planid "
                + "ORDER BY receiveddate DESC; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = ParentId; 
                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId;
                
                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {
                    
                    while( dr.Read() )
                    {
                        FeePayment payment = FeePayment.CreateFeePayment( dr, _intPlanId, ParentId, (int)dr["feetypeid"] );
                        this.Add( payment );
                    }
                    dr.Close();

                }

            }

        }
        #endregion



        #region public PlanFeePayments Clone()
        public PlanFeePayments Clone()
        {

            PlanFeePayments payments = new PlanFeePayments();

            payments.IsLoading = true;
            foreach( FeePayment payment in this )
            {
                payments.Add( payment.Clone() );
            }
            payments.IsLoading = false;

            return payments;

        }
        #endregion


        #region public override void CleanCollection()
        public override void CleanCollection()
        {

            base.CleanCollection();

            foreach( FeePayment payment in this )
            {
                if( payment.MyState != MyObjectState.Current )
                {

                    payment.RaiseChangedEvents = false;

                    payment.Save();
                    payment.SetNewUpdateProperties( LocalUser.WindowsUserName, base.UpdateDate );

                    payment.RaiseChangedEvents = true;

                }
            }

        }
        #endregion


        #region public void UpdateParentIds( int planId, int defendantId )
        public void UpdateParentIds( int planId, int defendantId )
        {
            ParentId = defendantId;
            _intPlanId = planId;
        }
        #endregion


    }
}
