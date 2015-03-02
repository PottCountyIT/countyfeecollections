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

    [TypeConverter( typeof( EmployerDefendantTypeConverter ) )]
    public class EmployersDefendant : BaseCollection<EmployerDefendant>, IComparable
    {


        #region private EmployersDefendant() : base()
        private EmployersDefendant() : base()
        {

        }
        #endregion


        #region public EmployersDefendant( int defendantId ) : base( defendantId )
        public EmployersDefendant( int defendantId ) : base( defendantId )
        {
            
            base.IsLoading = true;
            BuildDefendantEmployersList();
            base.IsLoading = false;

        }
        #endregion


        #region public void SaveDefendantEmployers( SqlTransaction trx )
        public void SaveDefendantEmployers( SqlTransaction trx )
        {

            if( ParentId > -1 )
            {

                base.UpdateDate = DateTime.Now;

                // synchronizing items with the database
                foreach( EmployerDefendant employer in base.RemovedObjects )
                    employer.Remove( trx );

                foreach( EmployerDefendant employer in this.Items )
                    if( employer.MyState == MyObjectState.New || employer.MyState == MyObjectState.Modified )
                    {
                        employer.Save( trx, base.UpdateDate, ParentId );
                    }

            }

        }
        #endregion


        #region private void BuildDefendantEmployersList()
        private void BuildDefendantEmployersList()
        {

            const string sql = "SELECT employer.employerid, employername, street1, street2, city, stateid, zip, phone, "
                + "separationdate, defendantemployers.updatedby, defendantemployers.updateddate "
                + "FROM DefendantEmployers JOIN Employer ON defendantemployers.employerid = employer.employerid "
                + "WHERE defendantid = @defendantid "
                + "ORDER BY employername DESC; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                cmd.Parameters.Add( "@defendantid", SqlDbType.VarChar ).Value = ParentId;
                
                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {
                    
                    while( dr.Read() )
                    {
                        EmployerDefendant defendant = EmployerDefendant.CreateEmployerDefendant( dr, ParentId );
                        this.Add( defendant );
                    }
                    dr.Close();

                }

            }

        }
        #endregion
        

        #region public EmployersDefendant Clone()
        public EmployersDefendant Clone()
        {

            EmployersDefendant emps = new EmployersDefendant();

            emps.IsLoading = true;
            foreach( EmployerDefendant emp in this )
            {
                emps.Add( emp.Clone() );
            }
            emps.IsLoading = false;

            return emps;

        }
        #endregion


        #region public override void CleanCollection()
        public override void CleanCollection()
        {

            base.CleanCollection();

            foreach( EmployerDefendant employer in this )
            {
                if( employer.MyState != MyObjectState.Current )
                {

                    employer.RaiseChangedEvents = false;

                    if( employer.HasChanged || employer.MyState == MyObjectState.New )
                        employer.SetNewUpdateProperties( LocalUser.WindowsUserName, base.UpdateDate );

                    employer.Save();

                    employer.RaiseChangedEvents = true;

                }
            }

        }
        #endregion


        #region public int CompareTo( object obj )
        public int CompareTo( object obj )
        {

            Employer emp = obj as Employer;
            if( emp != null )
            {
                return this.Find( "EmployerName", emp.EmployerName );
            }
            else
            {
                throw new ArgumentException( "object is not an Employer" );
            }
        } 
        #endregion




    }
}
