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
using System.ComponentModel;
using System.Data;


namespace county.feecollections
{

    
    public class Employer : BaseObject
    {

        
        // public property backing variables
        private string _strName;
        private string _strStreet1;
        private string _strStreet2;
        private string _strCity;
        private int _intStateId;
        private string _strStateName;
        private string _strZip;
        private string _strPhone;
        

        // public property backing objects
        private Defendants _Defendants;




        // property backup variables
        private string _strName_orig;
        private string _strStreet1_orig;
        private string _strStreet2_orig;
        private string _strCity_orig;
        private int _intStateId_orig;
        private string _strZip_orig;
        private string _strPhone_orig;
        


        
        #region public string EmployerName
        public string EmployerName
        {
            get { return _strName; }
            set 
            {
                if( !_strName.Equals( value ) )
                {
                    _strName = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public string Street1
        public string Street1
        {
            get { return _strStreet1; }
            set 
            {
                if( !_strStreet1.Equals( value ) )
                {
                    _strStreet1 = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public string Street2
        public string Street2
        {
            get { return _strStreet2; }
            set 
            {
                if( !_strStreet2.Equals( value ) )
                {
                    _strStreet2 = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public string City
        public string City
        {
            get { return _strCity; }
            set 
            {
                if( !_strCity.Equals( value ) )
                {
                    _strCity = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public int StateID
        public int StateID
        {
            get { return _intStateId; }
            set 
            {
                if( !_intStateId.Equals( value ) )
                {
                    _intStateId = value;
                    _strStateName = Helper.GetStateAbbreviationByID( _intStateId );
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public string StateName
        public string StateName
        {
            get { return _strStateName; }
        } 
        #endregion

        #region public string Zip
        public string Zip
        {
            get { return _strZip; }
            set 
            {
                if( !_strZip.Equals( value ) )
                {
                    _strZip = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public string Phone
        public string Phone
        {
            get { return _strPhone; }
            set
            {
                if( !_strPhone.Equals( value ) )
                {
                    _strPhone = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public Defendants Defendants
        public Defendants Defendants
        {
            get
            {

                if( _Defendants == null )
                    _Defendants = new Defendants( base.ID );

                return _Defendants;

            }
        }
        #endregion




        #region public Employer(): base()
        public Employer(): base()
        {

            InitializeProperties();

        } 
        #endregion

        #region public Employer( int ID, string updatedBy, DateTime? updatedDate ) : base( ID, updatedBy, updatedDate )
        public Employer( int ID, string updatedBy, DateTime? updatedDate ) : base( ID, updatedBy, updatedDate )
        {

            InitializeProperties();

        }
        #endregion




        #region private void Select()
        private void Select()
        {

            if( base.ID > 0 )
            {

                const string sql = "SELECT employername, street1, street2, city, stateid, zip, phone, updatedby, updateddate "
                    + "FROM Employer "
                    + "WHERE employerid = @id; ";

                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {
                            InitializeProperties();
                            _strName = dr["employername"].ToString();
                            _strStreet1 = dr["street1"].ToString();
                            _strStreet2 = dr["street2"].ToString();
                            _strCity = dr["city"].ToString();
                            _intStateId = (dr.IsDBNull( dr.GetOrdinal( "stateid" ) )) ? -1 : Convert.ToInt32( dr["stateid"].ToString() );
                            _strZip = dr["zip"].ToString();
                            _strPhone = dr["phone"].ToString();
                            base.SetNewUpdateProperties( dr["updatedby"].ToString(), (DateTime)dr["updateddate"] );

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

            const string sql = "INSERT INTO Employer ( " 
                + "employername, street1, street2, city, stateid, zip, phone, updatedby, updateddate "
                + ") VALUES ( " 
                + "@employername, @street1, @street2, @city, @stateid, @zip, @phone, @updatedby, @updateddate "
                + "); ";
                
            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {

                cmd.Parameters.Add( "@employername", SqlDbType.VarChar ).Value = _strName;
                cmd.Parameters.Add( "@street1", SqlDbType.VarChar ).Value = _strStreet1;
                cmd.Parameters.Add( "@street2", SqlDbType.VarChar ).Value = _strStreet2;
                cmd.Parameters.Add( "@city", SqlDbType.VarChar ).Value = _strCity;
                cmd.Parameters.Add( "@stateid", SqlDbType.Int ).Value = _intStateId;
                cmd.Parameters.Add( "@zip", SqlDbType.VarChar ).Value = _strZip;
                cmd.Parameters.Add( "@phone", SqlDbType.VarChar ).Value = _strPhone;

                base.Insert( cmd, updateDate );

            }

        }
        #endregion

        #region private void Update( DateTime updateDate )
        private void Update( DateTime updateDate )
        {

            const string sql = "UPDATE Employer SET " 
                + "employername = @employername, " 
                + "street1 = @street1, " 
                + "street2 = @street2, " 
                + "city = @city, " 
                + "stateid = @stateid, " 
                + "zip = @zip, "
                + "phone = @phone, "
                + "updatedby = @updatedby, " 
                + "updateddate = @updateddate " 
                + "WHERE employerid = @id " 
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {

                cmd.Parameters.Add( "@employername", SqlDbType.VarChar ).Value = _strName;
                cmd.Parameters.Add( "@street1", SqlDbType.VarChar ).Value = _strStreet1;
                cmd.Parameters.Add( "@street2", SqlDbType.VarChar ).Value = _strStreet2;
                cmd.Parameters.Add( "@city", SqlDbType.VarChar ).Value = _strCity;

                if( _intStateId < 0 )
                    cmd.Parameters.Add( "@stateid", SqlDbType.Int ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@stateid", SqlDbType.Int ).Value = _intStateId;

                cmd.Parameters.Add( "@zip", SqlDbType.VarChar ).Value = _strZip;
                cmd.Parameters.Add( "@phone", SqlDbType.VarChar ).Value = _strPhone;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );

            }

        }
        #endregion

        #region private void Delete()
        private void Delete()
        {

            const string sql = "DELETE FROM Employer " 
                + "WHERE employerid = @id " 
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

        #region public virtual Employer Clone()
        public virtual Employer Clone()
        {

            Employer emp = new Employer( this.ID, this.UpdatedBy, this.UpdatedDate );

            emp.RaiseChangedEvents = false;

            emp.EmployerName = this.EmployerName;
            emp.Street1 = this.Street1;
            emp.Street2 = this.Street2;
            emp.City = this.City;
            emp.StateID = this.StateID;
            emp.Zip = this.Zip;
            emp.Phone = this.Phone;
            emp.Save( false );

            emp.RaiseChangedEvents = true;

            return emp;

        }
        #endregion

        #region public override string ToString()
        public override string ToString()
        {
            return this.EmployerName;
        }
        #endregion




        #region protected virtual void InitializeProperties()
        protected virtual void InitializeProperties()
        {

            _strName_orig = _strName = string.Empty;
            _strStreet1_orig = _strStreet1 = string.Empty;
            _strStreet2_orig = _strStreet2 = string.Empty;
            _strCity_orig = _strCity = "Council Bluffs";
            _intStateId_orig = _intStateId = 12;
            _strStateName = "IA";
            _strZip_orig = _strZip = string.Empty;
            _strPhone_orig = _strPhone = string.Empty;

        }
        #endregion

        #region protected virtual void SaveBackups()
        protected virtual void SaveBackups()
        {

            _strName_orig = _strName;
            _strStreet1_orig = _strStreet1;
            _strStreet2_orig = _strStreet2;
            _strCity_orig = _strCity;
            _intStateId_orig = _intStateId;
            _strZip_orig = _strZip;
            _strPhone_orig = _strPhone;

        } 
        #endregion

        #region protected virtual void RestoreBackups()
        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// After restoring the variables it resets the state of the object.
        /// </summary>
        protected virtual void RestoreBackups()
        {

            _strName = _strName_orig;
            _strStreet1 = _strStreet1_orig;
            _strStreet2 = _strStreet2_orig;
            _strCity = _strCity_orig;
            StateID = _intStateId_orig;
            _strZip = _strZip_orig;
            _strPhone = _strPhone_orig;

        } 
        #endregion

                


        #region public static Employer CreateEmployer( SqlDataReader dr )
        public static Employer CreateEmployer( SqlDataReader dr )
        {

            Employer employer = new Employer();

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                int id = Convert.ToInt32( dr["employerid"] );
                string updatedby = dr["updatedby"].ToString();
                DateTime? updateddate = (DateTime)dr["updateddate"];

                employer = new Employer( id, updatedby, updateddate );

                employer.RaiseChangedEvents = false;

                employer.EmployerName = dr["employername"].ToString();
                employer.Street1 = dr["street1"].ToString();
                employer.Street2 = dr["street2"].ToString();
                employer.City = dr["city"].ToString();
                employer.StateID = (dr.IsDBNull( dr.GetOrdinal( "stateid" ) )) ? -1 : Convert.ToInt32( dr["stateid"].ToString() );
                employer.Zip = dr["zip"].ToString();
                employer.Phone = dr["phone"].ToString();
                employer.Save( false );

                employer.RaiseChangedEvents = true;

            }

            return employer;
        }
        #endregion


        


    }

}
