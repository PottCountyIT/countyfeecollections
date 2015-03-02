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

    public class PaymentArrangementType : BaseObject
    {

        // public property backing variables
        private string _strPaymentArrangementType;


        // property backup variables
        private string _strPaymentArrangementType_orig;




        #region public string PaymentArrangementTypeName
        public string PaymentArrangementTypeName
        {
            get { return _strPaymentArrangementType; }
            set 
            {
                if( !_strPaymentArrangementType.Equals( value ) )
                {
                    _strPaymentArrangementType = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion



                
        #region public PaymentArrangementType(): base()
        public PaymentArrangementType(): base()
        {

            InitializeProperties();

        } 
        #endregion

        #region public PaymentArrangementType( int ID, string updatedBy, DateTime updatedDate ) : base( ID, updatedBy, updatedDate )
        public PaymentArrangementType( int ID, string updatedBy, DateTime? updatedDate ) : base( ID, updatedBy, updatedDate )
        {

            InitializeProperties();

        }
        #endregion




        #region private void Select()
        private void Select()
        {

            if( base.ID > 0 )
            {

                const string sql = "SELECT paymentarrangementtype, updatedby, updateddate "
                    + "FROM PaymentArrangementTypes "
                    + "WHERE paymentarrangementtypeid = @id; ";

                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {

                            InitializeProperties();
                            _strPaymentArrangementType = dr["paymentarrangementtype"].ToString();
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
        #endregion

        #region private void Insert( DateTime updateDate )
        private void Insert( DateTime updateDate )
        {

            const string sql = "INSERT INTO PaymentArrangementTypes ( "
                + "paymentarrangementtype, updatedby, updateddate "
                + ") VALUES ( "
                + "@paymentarrangementtype, @updatedby, @updateddate "
                + "); ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {

                cmd.Parameters.Add( "@paymentarrangementtype", SqlDbType.VarChar ).Value = _strPaymentArrangementType;

                base.Insert( cmd, updateDate );

            }

        }
        #endregion

        #region private void Update( DateTime updateDate )
        private void Update( DateTime updateDate )
        {

            const string sql = "UPDATE PaymentArrangementTypes SET "
                + "paymentarrangementtype = @paymentarrangementtype, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE paymentarrangementtypeid = @id "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {

                cmd.Parameters.Add( "@paymentarrangementtype", SqlDbType.VarChar ).Value = _strPaymentArrangementType;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );

            }

        }
        #endregion

        #region private void Delete()
        private void Delete()
        {

            const string sql = "DELETE FROM PaymentArrangementTypes "
                + "WHERE paymentarrangementtypeid = @id "
                + "AND updatedby = @updatedby "
                + "AND updateddate = @updateddate; ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                base.Delete( cmd );
            }

        }
        #endregion




        #region public void Save( bool updateDatabase )
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
        #endregion

        #region public override void Remove( bool updateDatabase )
        public override void Remove( bool updateDatabase )
        {

            if( updateDatabase )
                Delete();

            base.Remove( updateDatabase );

        }
        #endregion

        #region public override void Reset()
        /// <summary>
        /// Restores all properties to their last current or new state. 
        /// </summary>
        public override void Reset()
        {

            RestoreBackups();
            base.Reset();

        }
        #endregion

        #region public override void Refresh()
        /// <summary>
        /// Refreshes all object values from the db.
        /// </summary>
        public override void Refresh()
        {

            Select();
            SaveBackups();

            base.Refresh();

        }
        #endregion



        
        #region protected virtual void InitializeProperties()
        protected virtual void InitializeProperties()
        {

            _strPaymentArrangementType_orig = _strPaymentArrangementType = string.Empty;

        }
        #endregion

        #region protected virtual void SaveBackups()
        protected virtual void SaveBackups()
        {

            _strPaymentArrangementType_orig = _strPaymentArrangementType;

        } 
        #endregion

        #region protected virtual void RestoreBackups()
        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// </summary>
        protected virtual void RestoreBackups()
        {
            _strPaymentArrangementType = _strPaymentArrangementType_orig;

        } 
        #endregion




        #region public static PaymentArrangementType CreatePaymentArrangementType( SqlDataReader dr )
        public static PaymentArrangementType CreatePaymentArrangementType( SqlDataReader dr )
        {

            PaymentArrangementType payperiod = new PaymentArrangementType();

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                int id = Convert.ToInt32( dr["paymentarrangementtypeid"] );
                string updatedby = dr["updatedby"].ToString();
                DateTime? updateddate = Convert.ToDateTime( dr["updateddate"] );

                payperiod = new PaymentArrangementType( id, updatedby, updateddate );

                payperiod.RaiseChangedEvents = false;

                payperiod.PaymentArrangementTypeName = dr["paymentarrangementtype"].ToString();
                payperiod.Save( false );

                payperiod.RaiseChangedEvents = true;

            }

            return payperiod;
        }
        #endregion

    }
}




