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

    
    public class PlanFees : BaseCollection<PlanFee>
    {

        private int _intDefendantId;


        #region private PlanFees() : base()
        private PlanFees() : base()
        {
            
        }
        #endregion


        #region public PlanFees( int planId, int defendnatId ) : base( planId )
        public PlanFees( int planId, int defendnatId ) : base( planId )
        {

            _intDefendantId = defendnatId;

            this.IsLoading = true;
            BuildPlanFees();            
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

            PlanFee planfee = new PlanFee( ParentId, _intDefendantId );
            this.Add( planfee );

            return planfee;

        } 
        #endregion


        #region public void SavePlanFees( SqlTransaction trx )
        public void SavePlanFees( SqlTransaction trx )
        {

            if( ParentId > -1 )
            {
                base.UpdateDate = DateTime.Now;

                // synchronizing the new and removed items with the database
                foreach( PlanFee planfee in base.RemovedObjects )
                    planfee.Remove( trx );

                for( int i = 0; i < this.Items.Count; i++ )
                {
                    PlanFee planfee = this.Items[i];

                    if( planfee.MyState == MyObjectState.New || planfee.MyState == MyObjectState.Modified )
                    {

                        if( planfee.MyState == MyObjectState.New )
                        {
                            planfee = PlanFee.UpdateFeeIds( planfee, ParentId, _intDefendantId );
                        }

                        planfee.Save( trx, base.UpdateDate );
                    }


                }

            }

        }
        #endregion


        #region private void BuildPlanFees()
        private void BuildPlanFees()
        {

            const string sql = "SELECT FeeTypes.feetypeid, PlanFee.amount, "
                + "PlanFee.updatedby, PlanFee.updateddate "
                + "FROM PlanFee "
                + "LEFT OUTER JOIN FeeTypes ON PlanFee.feetypeid = FeeTypes.feetypeid "
                + "WHERE planid = @planid "
                + "AND defendantid = @defendantid "
                + "ORDER BY paymentorder ASC; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = ParentId;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                
                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {
                    
                    while( dr.Read() )
                    {
                        PlanFee planfee = PlanFee.CreateFee( dr, ParentId, _intDefendantId );
                        this.Add( planfee );
                    }
                    dr.Close();

                }

            }

        }
        #endregion


        #region public PlanFees Clone()
        public PlanFees Clone()
        {

            PlanFees planfees = new PlanFees();

            planfees.IsLoading = true;
            foreach( PlanFee planfee in this )
            {
                planfees.Add( planfee.Clone() );
            }
            planfees.IsLoading = false;

            return planfees;

        }
        #endregion


        #region public override void CleanCollection()
        public override void CleanCollection()
        {

            base.CleanCollection();

            foreach( PlanFee planfee in this )
            {
                if( planfee.MyState != MyObjectState.Current )
                {

                    planfee.RaiseChangedEvents = false;

                    if( planfee.HasChanged )
                        planfee.SetNewUpdateProperties( LocalUser.WindowsUserName, base.UpdateDate );

                    planfee.Save();

                    planfee.RaiseChangedEvents = true;

                }
            }

        }
        #endregion



        #region public void UpdateParentIds( int planId, int defendantId )
        public void UpdateParentIds( int planId, int defendantId )
        {
            ParentId = planId;
            _intDefendantId = defendantId;
        } 
        #endregion


    }
}
