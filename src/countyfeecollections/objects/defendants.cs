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


    public class Defendants : BaseCollection<Defendant>
    {


        #region public Defendants() : base()
        public Defendants() : base()
        {

            BuildDefendantList();

        } 
        #endregion

        #region public Defendants( int parentId ) : base( parentId )
        public Defendants( int parentId ) : base( parentId )
        {

            BuildEmployerDefendantsList();

        }
        #endregion




        #region private void BuildDefendantList()
        private void BuildDefendantList()
        {

            const string sql = "SELECT defendantid, firstname, middlename, lastname, aka, ssn, birthdate, driverslicense, "
                    + "street1, street2, city, stateid, zip, phonehome, phonemobile, "
                    + "hasprobationofficer, probationofficer, "
                    + "barreduntil, notes, active, daysinjail, bookingnumber, judgmentdate, updatedby, updateddate, "
                    + "hasjudgmentfiled, judgmentfileddate, inbankruptcy, bankruptcydatefiled, bankruptcyenddate "
                    + "FROM Defendant "
                    + "WHERE active = 1 "
                    + "ORDER BY lastname, firstname; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {

                    while( dr.Read() )
                    {
                        Defendant defendant = Defendant.CreateCurrentDefendant( dr );
                        this.Add( defendant );
                    }
                    dr.Close();

                }

            }

        }
        #endregion

        #region private void BuildEmployerDefendantsList()
        private void BuildEmployerDefendantsList()
        {

            const string sql = "SELECT defendant.defendantid, defendant.firstname, defendant.middlename, defendant.lastname, "
                + "defendant.aka, defendant.ssn, defendant.birthdate, defendant.driverslicense, "
                + "defendant.street1, defendant.street2, defendant.city, defendant.stateid, defendant.zip, "
                + "defendant.phonehome, defendant.phonemobile, "
                + "defendant.hasprobationofficer, defendant.probationofficer, "
                + "defendant.barreduntil, defendant.notes, defendant.active, "
                + "defendant.daysinjail, defendant.bookingnumber, defendant.judgmentdate,"
                + "defendant.hasjudgmentfiled, defendant.judgmentfileddate, defendant.inbankruptcy, defendant.bankruptcydatefiled, defendant.bankruptcyenddate, "
                + "defendantemployers.updatedby, defendantemployers.updateddate "
                + "FROM Employer "
                + "LEFT OUTER JOIN DefendantEmployers ON employer.employerid = defendantemployers.employerid "
                + "INNER JOIN Defendant ON defendantemployers.defendantid = defendant.defendantid "
                + "WHERE employer.employerid = @employerid "
                + "ORDER BY lastname, firstname DESC; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            {

                cmd.Parameters.Add( "@employerid", SqlDbType.Int ).Value = ParentId;

                using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                {

                    while( dr.Read() )
                    {
                        Defendant defendant = Defendant.CreateCurrentDefendant( dr );
                        this.Add( defendant );
                    }
                    dr.Close();

                }

            }

        }
        #endregion


    }
}
