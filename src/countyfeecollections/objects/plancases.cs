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

    
    public class PlanCases : BaseCollection<PlanCase>
    {

        private int _intDefendantId;



        #region private PlanCases() : base()
        private PlanCases() : base()
        {
            
        }
        #endregion


        #region public PlanCases( int planId, int defendnatId ) : base( planId )
        public PlanCases( int planId, int defendnatId ) : base( planId )
        {

            _intDefendantId = defendnatId;

            this.IsLoading = true;
            BuildPlanCases();            
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

            PlanCase plancase = new PlanCase( ParentId, _intDefendantId );
            this.Add( plancase );

            return plancase;

        } 
        #endregion


        #region public void SavePlanCases( SqlTransaction trx )
        public void SavePlanCases( SqlTransaction trx )
        {

            if( ParentId > -1 )
            {
                base.UpdateDate = DateTime.Now;

                // synchronizing the new and removed items with the database
                foreach( PlanCase plancase in base.RemovedObjects )
                    plancase.Remove( trx );

                for( int i = 0; i < this.Items.Count; i++ )
                {
                    PlanCase plancase = this.Items[i];

                    if( plancase.MyState == MyObjectState.New || plancase.MyState == MyObjectState.Modified )
                    {

                        if( plancase.MyState == MyObjectState.New )
                        {
                            plancase = PlanCase.UpdateCaseIds( plancase, ParentId, _intDefendantId );
                        }

                        plancase.Save( trx, base.UpdateDate );
                    }

                }

            }

        }
        #endregion




        #region private void BuildPlanCases()
        private void BuildPlanCases()
        {

            const string sql = "SELECT casename, countyid, committed, commitdate, commitbasedate, commitdaystill, capp, "
                + "updatedby, updateddate "
                + "FROM PlanCase "
                + "WHERE planid = @planid "
                + "AND defendantid = @defendantid "
                + "ORDER BY updateddate; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = ParentId;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                
                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {
                    
                    while( dr.Read() )
                    {
                        PlanCase plancase = PlanCase.CreateCase( dr, ParentId, _intDefendantId );
                        this.Add( plancase );
                    }
                    dr.Close();

                }

            }

        }
        #endregion


        #region public PlanCases Clone()
        public PlanCases Clone()
        {

            PlanCases plancases = new PlanCases();

            plancases.IsLoading = true;
            foreach( PlanCase plancase in this )
            {
                plancases.Add( plancase.Clone() );
            }
            plancases.IsLoading = false;

            return plancases;

        }
        #endregion


        #region public override void CleanCollection()
        public override void CleanCollection()
        {
            base.CleanCollection();

            foreach( PlanCase plancase in this )
            {
                if( plancase.MyState != MyObjectState.Current )
                {

                    plancase.RaiseChangedEvents = false;

                    if( plancase.HasChanged )
                        plancase.SetNewUpdateProperties( LocalUser.WindowsUserName, base.UpdateDate );

                    plancase.Save();

                    plancase.RaiseChangedEvents = true;

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
