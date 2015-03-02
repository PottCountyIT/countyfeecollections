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


namespace county.feecollections
{

    public class FeeType : BaseObject
    {
        // public property backing variables
        private string _strFeeTypeName;
        private int _intPaymentOrder;
        private bool _Billable;

        // property backup variables
        private string _strFeeTypeName_orig;
        private int _intPaymentOrder_orig;
        private bool _Billable_orig;

        public string FeeTypeName
        {
            get { return _strFeeTypeName; }
            set 
            {
                if( !_strFeeTypeName.Equals( value ) )
                {
                    _strFeeTypeName = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }

        public int PaymentOrder
        {
            get { return _intPaymentOrder; }
            set
            {
                if( !_intPaymentOrder.Equals( value ) )
                {
                    _intPaymentOrder = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }

        public bool Billable
        {
            get { return _Billable; }
            set
            {
                if( !_Billable.Equals( value ) )
                {
                    _Billable = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
       
        public FeeType(): base()
        {
            InitializeProperties();
        } 

        public FeeType( int ID, string updatedBy, DateTime? updatedDate ) : base( ID, updatedBy, updatedDate )
        {
            InitializeProperties();
        }

        private void Select()
        {
            if( base.ID > 0 )
            {
                const string sql = "SELECT feetype, paymentorder, billable, updatedby, updateddate "
                    + "FROM FeeTypes "
                    + "WHERE feetypeid = @id; ";
                using( SqlCommand cmd = new SqlCommand( sql ) )
                {
                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;
                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {
                        if( dr.Read() )
                        {
                            InitializeProperties();
                            _strFeeTypeName = dr["feetype"].ToString();
                            if( !dr.IsDBNull( dr.GetOrdinal( "paymentorder" ) ) ) _intPaymentOrder = Convert.ToInt32( dr["paymentorder"].ToString() );
                            _Billable= Convert.ToBoolean( dr["billable"].ToString() );
                            base.SetNewUpdateProperties( dr["updatedby"].ToString(), Convert.ToDateTime( dr["updateddate"] ) );
                        }
                        else
                        {
                            dr.Close();
                            throw new MyException( this.GetType().Name, MyErrorType.ConcurrencyObjectNotExists, new Exception() );
                        }
                        dr.Close();
                    }
                }
            }
        }

        private void Insert( DateTime updateDate )
        {

            const string sql = "INSERT INTO FeeTypes ( "
                + "feetype, paymentorder, billable, updatedby, updateddate "
                + ") VALUES ( "
                + "@feetype, @paymentorder, @billable, @updatedby, @updateddate "
                + "); ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {

                cmd.Parameters.Add( "@feetype", SqlDbType.VarChar ).Value = _strFeeTypeName;

                if( _intPaymentOrder <= 0 )
                    cmd.Parameters.Add( "@paymentorder", SqlDbType.Int ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@paymentorder", SqlDbType.Int ).Value = _intPaymentOrder;

                cmd.Parameters.Add( "@billable", SqlDbType.Bit ).Value = _Billable;

                base.Insert( cmd, updateDate );

            }

        }

        private void Update( DateTime updateDate )
        {

            const string sql = "UPDATE FeeTypes SET "
                + "feetype = @feetype, "
                + "paymentorder = @paymentorder, "
                + "billable = @billable, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE feetypeid = @id "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                cmd.Parameters.Add( "@feetype", SqlDbType.VarChar ).Value = _strFeeTypeName;

                if( _intPaymentOrder <= 0 )
                    cmd.Parameters.Add( "@paymentorder", SqlDbType.Int ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@paymentorder", SqlDbType.Int ).Value = _intPaymentOrder;

                cmd.Parameters.Add( "@billable", SqlDbType.Bit ).Value = _Billable;

                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );
            }

        }

        private void Delete()
        {

            const string sql = "DELETE FROM FeeTypes "
                + "WHERE feetypeid = @id "
                + "AND updatedby = @updatedby "
                + "AND updateddate = @updateddate; ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                base.Delete( cmd );
            }

        }

        public void Save( bool updateDatabase )
        {

            if( updateDatabase )
            {
                DateTime updateDate = DateTime.Now;

                switch( base.MyState )
                {
                    case MyObjectState.New:
                        Insert( updateDate );
                        this.SetNewUpdateProperties( LocalUser.WindowsUserName, updateDate );
                        break;
                    case MyObjectState.Modified:
                        Update( updateDate );
                        this.SetNewUpdateProperties( LocalUser.WindowsUserName, updateDate );
                        break;
                }
            }

            SaveBackups();
            base.MyState = MyObjectState.Current;

        }

        public override void Remove( bool updateDatabase )
        {

            if( updateDatabase )
                Delete();

            base.Remove( updateDatabase );

        }

        /// <summary>
        /// Restores all properties to their last current or new state. 
        /// </summary>
        public override void Reset()
        {

            RestoreBackups();
            base.Reset();

        }

        /// <summary>
        /// Refreshes all object values from the db.
        /// </summary>
        public override void Refresh()
        {

            Select();
            SaveBackups();

            base.Refresh();

        }

        protected virtual void InitializeProperties()
        {
            _strFeeTypeName_orig = _strFeeTypeName = string.Empty;
            _intPaymentOrder_orig = _intPaymentOrder = -1;
            _Billable_orig = _Billable = true;
        }

        protected virtual void SaveBackups()
        {
            _strFeeTypeName_orig = _strFeeTypeName;
            _intPaymentOrder_orig = _intPaymentOrder;
            _Billable_orig = _Billable;
        } 

        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// </summary>
        protected virtual void RestoreBackups()
        {
            _strFeeTypeName = _strFeeTypeName_orig;
            _intPaymentOrder = _intPaymentOrder_orig;
            _Billable = _Billable_orig;
        } 

        public static FeeType CreateFeeType( SqlDataReader dr )
        {
            FeeType fee = new FeeType();

            if( !dr.IsClosed && dr.HasRows )
            {
                // getting id that uniquely identifies the object
                int id = Convert.ToInt32( dr["feetypeid"] );
                string updatedby = dr["updatedby"].ToString();
                DateTime? updateddate = Convert.ToDateTime( dr["updateddate"] );

                fee = new FeeType( id, updatedby, updateddate );

                fee.RaiseChangedEvents = false;

                fee.FeeTypeName = dr["feetype"].ToString();
                if( !dr.IsDBNull( dr.GetOrdinal( "paymentorder" ) ) ) fee.PaymentOrder = Convert.ToInt32( dr["paymentorder"].ToString() );
                fee.Billable = Convert.ToBoolean( dr["billable"].ToString() );
                fee.Save( false );

                fee.RaiseChangedEvents = true;
            }
            return fee;
        }
    }
}




