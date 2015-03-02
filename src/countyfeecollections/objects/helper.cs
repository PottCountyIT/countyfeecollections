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
using System.Data;
//using System.Data.Linq;
//using System.Linq;
using System.Data.SqlClient;
using System.Reflection;
using System.ComponentModel;
//using feecollectionData;

namespace county.feecollections
{


    #region enum GridViewState
    enum GridViewState
    {
        None,
        Adding,
        Sorting
    }; 
    #endregion

    #region public enum MyObjectState
    public enum MyObjectState
    {
        Current,
        New,
        Modified,
        Removed
    }; 
    #endregion

    #region public struct SingleFilterInfo
    public struct SingleFilterInfo
    {
        internal string PropName;
        internal PropertyDescriptor PropDesc;
        internal Object CompareValue;
        internal FilterOperator OperatorValue;
    }; 
    #endregion

    #region public enum FilterOperator
    public enum FilterOperator
    {
        EqualTo,
        LessThan,
        GreaterThan,
        Like,
        None
    }; 
    #endregion


    public static class Helper
    {
        private static FeeTypes _FeeTypes;

        public static FeeTypes FeeTypeList
        {
            get
            {
                if( _FeeTypes == null )
                {
                    _FeeTypes = new FeeTypes();
                }
                return _FeeTypes;
            }
        }

        public static string GetFeeTypeByID( int feeTypeId )
        {

            string feetypename = string.Empty;

            int idx = FeeTypeList.Find( "ID", feeTypeId );

            if( idx >= 0 )
            {
                feetypename = FeeTypeList[idx].FeeTypeName;
            }

            return feetypename;

        }

        private static PayPeriodTypes _PayPeriodTypes;

        public static PayPeriodTypes PayPeriodTypeList
        {
            get
            {
                if( _PayPeriodTypes == null )
                {
                    _PayPeriodTypes = new PayPeriodTypes();
                }
                return _PayPeriodTypes;
            }
        }

        private static PaymentArrangementTypes _PaymentArrangementTypes;

        public static PaymentArrangementTypes PaymentArrangementTypeList
        {
            get
            {
                if( _PaymentArrangementTypes == null )
                {
                    _PaymentArrangementTypes = new PaymentArrangementTypes();
                }
                return _PaymentArrangementTypes;
            }
        }

        public static string GetPayPeriodName( int payperiodTypeId )
        {
            if( _PayPeriodTypes != null )
            {
                return _PayPeriodTypes[_PayPeriodTypes.Find( "Id", payperiodTypeId )].PayPeriodTypeName.ToLower();
            }
            else
            {
                return "";
            }
        }

        private static RestrictedCasePrefixes _RestrictedCasePrefixes;

        public static RestrictedCasePrefixes RestrictedCasePrefixesList
        {
            get
            {
                if( _RestrictedCasePrefixes == null )
                {
                    _RestrictedCasePrefixes = new RestrictedCasePrefixes();
                }
                return _RestrictedCasePrefixes;
            }
        }
 
        public static bool HasRestrictedCasePrefix( string caseName )
        {

            bool rtnValue = false;

            foreach( RestrictedCasePrefix prefix in RestrictedCasePrefixesList )
            {
                if( caseName.ToUpper().StartsWith( prefix.CasePrefix.ToUpper() ) )
                {
                    rtnValue = true;
                    break;
                }

            }

            return rtnValue;

        } 

        private static DataTable _dtStates;

        public static DataTable StateList
        {
            get
            {
                if( _dtStates == null )
                    _dtStates = GetStates();
                return _dtStates;
            }
        }

        private static DataTable GetStates()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(LocalUser.DatabaseSettings.ConnectionString))
            {
                string sql = "SELECT stateid, abbreviation FROM states "
                    + "ORDER BY abbreviation ASC ";

                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.Fill(dt);
                }
            }

            DataRow dr = dt.NewRow();
            dr["stateid"] = -1;
            dr["abbreviation"] = "";
            dt.Rows.InsertAt(dr, 0);

            dt.AcceptChanges();

            return dt;
        } 

        public static string GetStateAbbreviationByID( int stateId )
        {

            string statename = string.Empty;

            DataRow[] states = StateList.Select( "stateid = " + stateId );

            if( states.Length == 1 )
                statename = states[0]["abbreviation"].ToString();


            return statename;

        } 

        private static DataTable _dtIowaCounties;

        public static DataTable IowaCountyList
        {
            get
            {
                if( _dtIowaCounties == null )
                    _dtIowaCounties = GetIowaCounties();
                return _dtIowaCounties;
            }
        }

        private static DataTable GetIowaCounties()
        {
            DataTable dt = new DataTable();

            using( SqlConnection con = new SqlConnection( LocalUser.DatabaseSettings.ConnectionString ) )
            {

                string sql = "SELECT countyid, county FROM IowaCounty ORDER BY county; ";

                using( SqlDataAdapter da = new SqlDataAdapter( sql, con ) )
                {

                    da.Fill( dt );
                }

            }

            DataRow dr = dt.NewRow();
            dr["countyid"] = -1;
            dr["county"] = "";
            dt.Rows.InsertAt( dr, 0 );

            dt.AcceptChanges();

            return dt;


        }

        public static string GetIowaCountyByID( int countyId )
        {

            string county = string.Empty;

            DataRow[] counties = IowaCountyList.Select( "countyid = " + countyId );

            if( counties.Length == 1 )
                county = counties[0]["county"].ToString();

            return county;

        }

        public static string IntToString( int id )
        {
            return id.ToString();
        } 

        public static DateTime? MaskedTextBoxDate( string text )
        {

            DateTime? myValue = null;

            if( !string.IsNullOrEmpty( text ) && text.Replace( "/", "" ).Trim().Length > 0 )
            {
                DateTime testdate;
                if( DateTime.TryParse( text, out testdate ) )
                    myValue = testdate;
            }

            return myValue;

        } 

        public static string FormatLongDateString( DateTime? date )
        {

            string rtnValue = string.Empty;

            if( date.HasValue )
            {

                rtnValue = date.Value.Month.ToString().Trim().PadLeft( 2, '0' ) + "/"
                    + date.Value.Day.ToString().Trim().PadLeft( 2, '0' ) + "/"
                    + date.Value.Year.ToString().Trim();

            }

            return rtnValue;
            
        } 
    }
}
