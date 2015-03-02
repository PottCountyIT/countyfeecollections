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
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;


namespace county.feecollections
{

    public class Plans : BaseCollection<Plan>
    {


        #region private Plans() : base()
        private Plans() : base()
        {
            
        }
        #endregion


        #region public Plans( int defendantId ) : base( defendantId )
        public Plans( int defendantId ) : base( defendantId )
        {

            this.IsLoading = true;
            BuildDefendantPlansList();
            this.IsLoading = false;

        }
        #endregion


        #region public void SaveDefendantPlans( SqlTransaction trx )
        public void SaveDefendantPlans( SqlTransaction trx )
        {

            if( ParentId > -1 )
            {
                base.UpdateDate = DateTime.Now;

                // synchronizing the new and removed itmes with the database
                foreach( Plan plan in base.RemovedObjects )
                    plan.Remove( trx );

                foreach( Plan plan in this.Items )
                    if( plan.MyState == MyObjectState.New || plan.MyState == MyObjectState.Modified )
                        plan.Save( trx, base.UpdateDate, ParentId );

            }

        }
        #endregion


        #region public Plans Clone()
        public Plans Clone()
        {

            Plans plans = new Plans();

            plans.IsLoading = true;
            foreach( Plan plan in this )
            {
                plans.Add( plan.Clone() );
            }
            plans.IsLoading = false;

            return plans;

        }
        #endregion



        #region public override void CleanCollection()
        public override void CleanCollection()
        {

            base.CleanCollection();

            foreach( Plan plan in this )
            {
                if( plan.MyState != MyObjectState.Current )
                {

                    plan.RaiseChangedEvents = false;

                    if( plan.HasChanged )
                        plan.SetNewUpdateProperties( LocalUser.WindowsUserName, base.UpdateDate );
                    
                    plan.Save();

                    plan.RaiseChangedEvents = true;

                    plan.Cases.CleanCollection();
                    plan.Fees.CleanCollection();
                    plan.PaymentArrangements.CleanCollection();

                }
            }

        }
        #endregion

        #region private void BuildDefendantPlansList()
        private void BuildDefendantPlansList()
        {

            const string sql = "SELECT planid, planname, capp, noncapp, isfiled, hasinsurance, "
                + "incontempt, noncompliancenotice, fileddate, updatedby, updateddate "
                + "FROM DefendantPlans "
                + "WHERE defendantid = @defendantid "
                + "ORDER BY planname ASC; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = ParentId;

                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {

                    while( dr.Read() )
                    {
                        Plan plan = Plan.CreateCurrentPlan( dr, ParentId );
                        this.Add( plan );
                    }
                    dr.Close();

                }

            }

        }
        #endregion


    }

}
