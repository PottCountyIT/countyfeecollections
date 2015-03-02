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

    
    public class Employers : BaseCollection<Employer>
    {


        #region public Employers() : base()
        public Employers() : base()
        {

            BuildEmployerList();

        } 
        #endregion

        #region public Employers( List<int> employerIdsToExclude )
        public Employers( List<int> employerIdsToExclude )
        {

            if( employerIdsToExclude.Count > 0 )
            {
                BuildUnrelatedEmployerList( String.Join( ",", (string[])employerIdsToExclude.ConvertAll( new Converter<int, string>( Helper.IntToString ) ).ToArray() ) );
            }
            else
            {
                BuildEmployerList();
            }

        }
        #endregion




        #region private void BuildEmployerList()
        private void BuildEmployerList()
        {

            const string sql = "SELECT employerid, employername, street1, street2, city, stateid, zip, phone, updatedby, updateddate "
                + "FROM Employer "
                + "ORDER BY employername DESC; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {

                    while( dr.Read() )
                    {
                        Employer employer = Employer.CreateEmployer( dr );
                        this.Add( employer );
                    }
                    dr.Close();

                }
                
            }

        }
        #endregion

        #region private void BuildUnrelatedEmployerList( string employerIdsCsv )
        private void BuildUnrelatedEmployerList( string employerIdsCsv )
        {

            string sql = string.Format( "SELECT employerid, employername, street1, street2, city, stateid, zip, phone, updatedby, updateddate "
                + "FROM Employer WHERE employerid NOT IN ( {0} ); ", employerIdsCsv );

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {

                    while( dr.Read() )
                    {
                        Employer employer = Employer.CreateEmployer( dr );
                        this.Add( employer );
                    }
                    dr.Close();

                }

            }
            
        }
        #endregion




    }
}
