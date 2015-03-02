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

    public class EmployerDefendant : Employer
    {

        // public property backing variables
        private int _intDefendantId;
        private DateTime? _SeparationDate;


        // property backups
        private DateTime? _SeparationDate_orig;




        #region public bool HasChanged
        public bool HasChanged
        {
            get
            {

                if( _SeparationDate_orig == _SeparationDate )
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }

        }
        #endregion

        #region public int DefendantId
        public int DefendantId
        {
            get { return _intDefendantId; }
        }
        #endregion

        #region public string SeparationDate
        public string SeparationDate
        {
            get { return (_SeparationDate.HasValue) ? Helper.FormatLongDateString( _SeparationDate ) : ""; }
            set
            {

                DateTime? myValue = Helper.MaskedTextBoxDate( value );

                if( !_SeparationDate.Equals( myValue ) )
                {
                    _SeparationDate = myValue;
                    base.MyState = MyObjectState.Modified;
                }

            }
        }
        #endregion
        



        #region public EmployerDefendant()
        public EmployerDefendant()
        {

            throw new NotImplementedException( "This object requires a defendantid." );

        }
        #endregion

        #region public EmployerDefendant( int defendantId ): base()
        public EmployerDefendant( int defendantId ): base()
        {

            _intDefendantId = defendantId;
            InitializeProperties();

        } 
        #endregion

        #region public EmployerDefendant( int defendantId, int employerId, string updatedBy, DateTime? updatedDate ) : base( employerId, updatedBy, updatedDate )
        public EmployerDefendant( int defendantId, int employerId, string updatedBy, DateTime? updatedDate ) : base( employerId, updatedBy, updatedDate )
        {
            
            _intDefendantId = defendantId;
            InitializeProperties();

        }
        #endregion




        #region private void Select()
        private void Select()
        {

            if( base.ID > 0 )
            {

                const string sql = "SELECT employername, street1, street2, city, stateid, zip, phone, "
                    + "separationdate, defendantemployers.updatedby, defendantemployers.updateddate "
                    + "FROM DefendantEmployers JOIN Employer ON defendantemployers.employerid = employer.employerid "
                    + "WHERE defendantid = @defendantid "
                    + "AND employerid = @id; ";
                

                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {
                            InitializeProperties();
                            this.RaiseChangedEvents = false;

                            EmployerName = dr["employername"].ToString();
                            Street1 = dr["street1"].ToString();
                            Street2 = dr["street2"].ToString();
                            City = dr["city"].ToString();
                            StateID = (dr.IsDBNull( dr.GetOrdinal( "stateid" ) )) ? -1 : Convert.ToInt32( dr["stateid"].ToString() );
                            Zip = dr["zip"].ToString();
                            Phone = dr["phone"].ToString();
                            if( !dr.IsDBNull( dr.GetOrdinal( "separationdate" ) ) ) _SeparationDate = (DateTime)dr["separationdate"];
                            base.SetNewUpdateProperties( dr["updatedby"].ToString(), (DateTime)dr["updateddate"] );
                            
                            this.RaiseChangedEvents = true;

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

        #region private void Insert( SqlTransaction trx, DateTime updateDate )
        private void Insert( SqlTransaction trx, DateTime updateDate )
        {

            const string sql = "INSERT INTO DefendantEmployers ( "
                + "defendantid, employerid, separationdate, updatedby, updateddate "
                + ") VALUES ( "
                + "@defendantid, @employerid, @separationdate, @updatedby, @updateddate "
                + "); ";

            
            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@employerid", SqlDbType.Int ).Value = this.ID;
                if( _SeparationDate == null )
                    cmd.Parameters.Add( "@separationdate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@separationdate", SqlDbType.DateTime ).Value = _SeparationDate;

                base.Insert( cmd, updateDate );

            }

        }
        #endregion

        #region private void Update( SqlTransaction trx, DateTime updateDate  )
        private void Update( SqlTransaction trx, DateTime updateDate )
        {

            const string sql = "UPDATE DefendantEmployers SET "
                + "separationdate = @separationdate, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE employerid = @id "
                + "AND defendantid = @defendantid "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                if( _SeparationDate == null )
                    cmd.Parameters.Add( "@separationdate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@separationdate", SqlDbType.DateTime ).Value = _SeparationDate;

                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );

            }

        }
        #endregion

        #region private void Delete( SqlTransaction trx )
        private void Delete( SqlTransaction trx )
        {

            const string sql = "DELETE FROM DefendantEmployers "
                + "WHERE employerid = @id "
                + "AND defendantid = @defendantid "
                + "AND updatedby = @updatedby "
                + "AND updateddate = @updateddate; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                base.Delete( cmd );
            }

        }
        #endregion

        #region public new void Save( bool updateDatabase )
        /// <summary>
        /// throws NotImplementedException
        /// </summary>
        public new void Save( bool updateDatabase )
        {
            throw new NotImplementedException();
        }
        #endregion

        #region public void Save( SqlTransaction trx, DateTime updateDate, int defendantId )
        public void Save( SqlTransaction trx, DateTime updateDate, int defendantId )
        {

            _intDefendantId = defendantId;

            switch( base.MyState )
            {

                case MyObjectState.New:
                    Insert( trx, updateDate  );
                    break;

                case MyObjectState.Modified:
                    Update( trx, updateDate );
                    break;

            }

        }
        #endregion

        #region public void Save()
        public void Save()
        {

            SaveBackups();
            base.MyState = MyObjectState.Current;

        }
        #endregion

        #region public new void Remove( bool updateDatabase )
        /// <summary>
        /// throws NotImplementedException
        /// </summary>
        /// <exception cref="throws NotEmplementedException"></exception>
        public new void Remove( bool updateDatabase )
        {
            throw new NotImplementedException();
        } 
        #endregion

        #region public void Remove( SqlTransaction trx )
        public void Remove( SqlTransaction trx )
        {

            Delete( trx );

            base.Remove( false );

        }
        #endregion
        
        #region public void Remove()
        public void Remove()
        {

            base.Remove( false );

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

        #region public void Refresh()
        /// <summary>
        /// Refreshes all object values from the db.
        /// </summary>
        public override void Refresh()
        {

            Select();
            SaveBackups();

            this.MyState = MyObjectState.Current;

        }
        #endregion

        #region public new EmployerDefendant Clone()
        public new EmployerDefendant Clone()
        {

            EmployerDefendant emp = EmployerDefendant.CreateEmployerDefendant( base.Clone(), this.DefendantId );

            emp.RaiseChangedEvents = false;

            emp.SeparationDate = this.SeparationDate;
            emp.Save();

            emp.RaiseChangedEvents = true;

            return emp;

        }
        #endregion

        #region protected override void InitializeProperties()
        protected override void InitializeProperties()
        {

            base.InitializeProperties();
            _SeparationDate_orig = _SeparationDate = null;

        }
        #endregion

        #region protected override void SaveBackups()
        protected override void SaveBackups()
        {

            base.SaveBackups();
            _SeparationDate_orig = _SeparationDate;

        }
        #endregion

        #region protected override void RestoreBackups()
        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// After restoring the variables it resets the state of the object.
        /// </summary>
        protected override void RestoreBackups()
        {

            _SeparationDate = _SeparationDate_orig;

        }
        #endregion

        #region public static EmployerDefendant CreateEmployerDefendant( SqlDataReader dr, int defendantId )
        public static EmployerDefendant CreateEmployerDefendant( SqlDataReader dr, int defendantId )
        {

            EmployerDefendant employer = null;

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                int id = Convert.ToInt32( dr["employerid"] );
                string updatedby = dr["updatedby"].ToString();
                DateTime? updateddate = (DateTime)dr["updateddate"];

                employer = new EmployerDefendant( defendantId, id, updatedby, updateddate );

                employer.RaiseChangedEvents = false;

                employer.EmployerName = dr["employername"].ToString();
                employer.Street1 = dr["street1"].ToString();
                employer.Street2 = dr["street2"].ToString();
                employer.City = dr["city"].ToString();
                employer.StateID = (dr.IsDBNull( dr.GetOrdinal( "stateid" ) )) ? -1 : Convert.ToInt32( dr["stateid"].ToString() );
                employer.Zip = dr["zip"].ToString();
                employer.Phone = dr["phone"].ToString();
                if( !dr.IsDBNull( dr.GetOrdinal( "separationdate" ) ) ) employer.SeparationDate = dr["separationdate"].ToString();
                employer.Save();

                employer.RaiseChangedEvents = true;

            }

            return employer;

        }
        #endregion

        #region public static EmployerDefendant CreateEmployerDefendant( Employer employer, int defendantId )
        public static EmployerDefendant CreateEmployerDefendant( Employer employer, int defendantId )
        {


            if( employer == null )
                return null;

            EmployerDefendant emp = new EmployerDefendant( defendantId, employer.ID, employer.UpdatedBy, employer.UpdatedDate );

            emp.RaiseChangedEvents = false;

            emp.EmployerName = employer.EmployerName;
            emp.Street1 = employer.Street1;
            emp.Street2 = employer.Street2;
            emp.City = employer.City;
            emp.StateID = employer.StateID;
            emp.Zip = employer.Zip;
            emp.Phone = employer.Phone;
            emp.Save();

            emp.RaiseChangedEvents = true;

            return emp;

        }
        #endregion
    }

}
