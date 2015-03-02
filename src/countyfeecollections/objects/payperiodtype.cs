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

    public class PayPeriodType : BaseObject
    {

        // public property backing variables
        private string _strPayPeriodType;
        

        // property backup variables
        private string _strPayPeriodType_orig;




        #region public string PayPeriodTypeName
        public string PayPeriodTypeName
        {
            get { return _strPayPeriodType; }
            set 
            {
                if( !_strPayPeriodType.Equals( value ) )
                {
                    _strPayPeriodType = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        




        
        #region public PayPeriodType(): base()
        public PayPeriodType(): base()
        {

            InitializeProperties();

        } 
        #endregion

        #region public PayPeriodType( int ID, string updatedBy, DateTime updatedDate ) : base( ID, updatedBy, updatedDate )
        public PayPeriodType( int ID, string updatedBy, DateTime? updatedDate ) : base( ID, updatedBy, updatedDate )
        {

            InitializeProperties();

        }
        #endregion




        #region private void Select()
        private void Select()
        {

            if( base.ID > 0 )
            {

                const string sql = "SELECT payperiodtype, updatedby, updateddate "
                    + "FROM PayPeriodTypes "
                    + "WHERE payperiodtypeid = @id; ";

                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {

                            InitializeProperties();
                            _strPayPeriodType = dr["payperiodtype"].ToString();
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

            const string sql = "INSERT INTO PayPeriodTypes ( "
                + "payperiodtype, updatedby, updateddate "
                + ") VALUES ( "
                + "@payperiodtype, @updatedby, @updateddate "
                + "); ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {

                cmd.Parameters.Add( "@payperiodtype", SqlDbType.VarChar ).Value = _strPayPeriodType;

                base.Insert( cmd, updateDate );

            }

        }
        #endregion

        #region private void Update( DateTime updateDate )
        private void Update( DateTime updateDate )
        {

            const string sql = "UPDATE PayPeriodTypes SET "
                + "payperiodtype = @payperiodtype, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE payperiodtypeid = @id "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {

                cmd.Parameters.Add( "@payperiodtype", SqlDbType.VarChar ).Value = _strPayPeriodType;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );

            }

        }
        #endregion

        #region private void Delete()
        private void Delete()
        {

            const string sql = "DELETE FROM PayPeriodTypes "
                + "WHERE payperiodtypeid = @id "
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

            _strPayPeriodType_orig = _strPayPeriodType = string.Empty;

        }
        #endregion

        #region protected virtual void SaveBackups()
        protected virtual void SaveBackups()
        {
            
            _strPayPeriodType_orig = _strPayPeriodType;

        } 
        #endregion

        #region protected virtual void RestoreBackups()
        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// </summary>
        protected virtual void RestoreBackups()
        {

            _strPayPeriodType = _strPayPeriodType_orig;

        } 
        #endregion




        #region public static PayPeriodType CreatePayPeriodType( SqlDataReader dr )
        public static PayPeriodType CreatePayPeriodType( SqlDataReader dr )
        {

            PayPeriodType payperiod = new PayPeriodType();

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                int id = Convert.ToInt32( dr["payperiodtypeid"] );
                string updatedby = dr["updatedby"].ToString();
                DateTime? updateddate = Convert.ToDateTime( dr["updateddate"] );

                payperiod = new PayPeriodType( id, updatedby, updateddate );

                payperiod.RaiseChangedEvents = false;

                payperiod.PayPeriodTypeName = dr["payperiodtype"].ToString();
                payperiod.Save( false );

                payperiod.RaiseChangedEvents = true;

            }

            return payperiod;
        }
        #endregion

    }
}




