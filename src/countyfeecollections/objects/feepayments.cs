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
    public class FeePayments : BaseCollection<FeePayment>
    {
        private int _intPlanId;
        private int _intFeeTypeId;

        public int FeeTypeId
        {
            get { return _intFeeTypeId; }
            set { _intFeeTypeId = value; }
        } 

        private FeePayments() : base()
        {
            
        }

        public FeePayments( int planId, int defendnatId, int feetypeid ) : base( defendnatId )
        {

            _intPlanId = planId;
            _intFeeTypeId = feetypeid;

            this.IsLoading = true;
            BuildFeePayments();            
            this.IsLoading = false;

        }

        /// <summary>
        /// Overrides the base constructor which tries to create a new object based on a 
        /// parameterless constructor.  This object was not designed to exist by itself and
        /// only exposes constructors requiring key(s) that define the parent object.
        /// </summary>
        /// <returns>a new object added to the collection.</returns>
        protected override object AddNewCore()
        {

            FeePayment payment = new FeePayment( _intPlanId, ParentId, _intFeeTypeId );
            this.Add( payment );

            return payment;

        } 

        public void SaveFeePayments( SqlTransaction trx )
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
                            payment = FeePayment.UpdateFeePaymentIds( payment, _intPlanId, payment.PlanId, _intFeeTypeId );
                        }

                        payment.Save( trx, base.UpdateDate );
                    }

                }

            }

        }

        private void BuildFeePayments()
        {
            const string sql = "SELECT receiveddate, amount, "
                + "updatedby, updateddate "
                + "FROM FeePayment "
                + "WHERE defendantid = @id "
                + "AND planid = @planid "
                + "AND feetypeid = @feetypeid "
                + "ORDER BY receiveddate DESC; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {
                cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = ParentId;
                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId;
                cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId;
                
                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {                   
                    while( dr.Read() )
                    {
                        FeePayment payment = FeePayment.CreateFeePayment( dr, _intPlanId, ParentId, _intFeeTypeId );
                        this.Add( payment );
                    }
                    dr.Close();
                }
            }
        }

        public FeePayments Clone()
        {

            FeePayments payments = new FeePayments();

            payments.IsLoading = true;
            foreach( FeePayment payment in this )
            {
                payments.Add( payment.Clone() );
            }
            payments.IsLoading = false;

            return payments;

        }

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
    }
}
