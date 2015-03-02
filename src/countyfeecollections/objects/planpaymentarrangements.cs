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

    
    public class PlanPaymentArrangements : BaseCollection<PlanPaymentArrangement>
    {

        private int _intDefendantId;



        #region private PlanPaymentArrangements() : base()
        private PlanPaymentArrangements() : base()
        {
            
        }
        #endregion


        #region public PlanPaymentArrangements( int planId, int defendnatId ) : base( planId )
        public PlanPaymentArrangements( int planId, int defendnatId ) : base( planId )
        {

            _intDefendantId = defendnatId;

            this.IsLoading = true;
            BuildPlanPaymentArrangements();            
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

            PlanPaymentArrangement planPaymentArrangement = new PlanPaymentArrangement( ParentId, _intDefendantId );
            this.Add( planPaymentArrangement );

            return planPaymentArrangement;

        } 
        #endregion


        #region public void SavePlanPaymentArrangements( SqlTransaction trx )
        public void SavePlanPaymentArrangements( SqlTransaction trx )
        {

            if( ParentId > -1 )
            {

                OverlappingPaymentArrangements();

                base.UpdateDate = DateTime.Now;

                // synchronizing the new and removed items with the database
                foreach( PlanPaymentArrangement planPaymentArrangement in base.RemovedObjects )
                    planPaymentArrangement.Remove( trx );

                for( int i = 0; i < this.Items.Count; i++ )
                {
                    PlanPaymentArrangement planPaymentArrangement = this.Items[i];

                    if( planPaymentArrangement.MyState == MyObjectState.New || planPaymentArrangement.MyState == MyObjectState.Modified )
                    {

                        if( planPaymentArrangement.MyState == MyObjectState.New )
                        {
                            planPaymentArrangement = PlanPaymentArrangement.UpdatePaymentArrangementIds( planPaymentArrangement, ParentId, _intDefendantId );
                        }

                        planPaymentArrangement.Save( trx, base.UpdateDate );
                        
                    }


                }

            }

        }
        #endregion


        #region private void OverlappingPaymentArrangements()
        private void OverlappingPaymentArrangements()
        {
            bool overlapping = false;
            string paramName = "";

            List<PlanPaymentArrangement> paymentArrangements = new List<PlanPaymentArrangement>();

            foreach( PlanPaymentArrangement paymentArrangement in this )
            {
                paymentArrangements.Add( paymentArrangement );
            }

            foreach( PlanPaymentArrangement paymentArrangement in paymentArrangements )
            {

                if( paymentArrangement.MyState != MyObjectState.Removed )
                {


                    foreach( PlanPaymentArrangement checkArrangement in this )
                    {

                        if( checkArrangement == paymentArrangement )
                            continue;

                        DateTime startDateToCheck;
                        DateTime endDateToCheck;

                        if( !DateTime.TryParse( checkArrangement.StartDate, out startDateToCheck ) || !DateTime.TryParse( checkArrangement.EndDate, out endDateToCheck ) )
                        {
                            overlapping = true;
                            paramName = "StartDate";
                            break;
                        }

                        if( startDateToCheck > DateTime.Parse( paymentArrangement.StartDate ) && startDateToCheck < DateTime.Parse( paymentArrangement.EndDate ) )
                        {
                            overlapping = true;
                            paramName = "StartDate";
                            break;
                        }

                        if( endDateToCheck > DateTime.Parse( paymentArrangement.StartDate ) && endDateToCheck < DateTime.Parse( paymentArrangement.EndDate ) )
                        {
                            overlapping = true;
                            paramName = "EndDate";
                            break;
                        }


                    }

                    if( overlapping )
                        throw new ArgumentOutOfRangeException( paramName, "Overlapping payment arrangements not allowed." );

                }

            }



        } 
        #endregion


        #region private void BuildPlanPaymentArrangements()
        private void BuildPlanPaymentArrangements()
        {

            const string sql = "SELECT paymentarrangementid, payperiodtypeid, paymentarrangementtypeid, amount, startdate, enddate, "
                + "updatedby, updateddate "
                + "FROM PlanPaymentArrangement "
                + "WHERE planid = @planid "
                + "AND defendantid = @defendantid; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = ParentId;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                
                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {
                    
                    while( dr.Read() )
                    {
                        PlanPaymentArrangement planPaymentArrangement = PlanPaymentArrangement.CreatePlanPaymentArrangement( dr, ParentId, _intDefendantId );
                        this.Add( planPaymentArrangement );
                    }
                    dr.Close();

                }

            }

        }
        #endregion


        #region public PlanPaymentArrangements Clone()
        public PlanPaymentArrangements Clone()
        {

            PlanPaymentArrangements planPaymentArrangements = new PlanPaymentArrangements();

            planPaymentArrangements.IsLoading = true;
            foreach( PlanPaymentArrangement planPaymentArrangement in this )
            {
                planPaymentArrangements.Add( planPaymentArrangement.Clone() );
            }
            planPaymentArrangements.IsLoading = false;

            return planPaymentArrangements;

        }
        #endregion


        #region public override void CleanCollection()
        public override void CleanCollection()
        {

            base.CleanCollection();

            foreach( PlanPaymentArrangement planPaymentArrangement in this )
            {
                if( planPaymentArrangement.MyState != MyObjectState.Current )
                {

                    planPaymentArrangement.RaiseChangedEvents = false;

                    if( planPaymentArrangement.HasChanged )
                        planPaymentArrangement.SetNewUpdateProperties( LocalUser.WindowsUserName, base.UpdateDate );

                    planPaymentArrangement.Save();

                    planPaymentArrangement.RaiseChangedEvents = true;

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
