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


    public class FeeTypes : BaseCollection<FeeType>
    {


        #region public FeeTypes() : base()
        public FeeTypes() : base()
        {

            BuildFeeTypeList();

        } 
        #endregion



        #region private void BuildFeeTypeList()
        private void BuildFeeTypeList()
        {

            const string sql = "SELECT feetypeid, feetype, paymentorder, billable, updatedby, updateddate "
                + "FROM FeeTypes "
                + "ORDER BY paymentorder ASC; ";

            using( SqlCommand cmd = new SqlCommand( sql ) )
            using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
            {

                while( dr.Read() )
                {
                    FeeType feetype = FeeType.CreateFeeType( dr );
                    this.Add( feetype );
                }
                dr.Close();

            }

        } 
        #endregion



    }
}
