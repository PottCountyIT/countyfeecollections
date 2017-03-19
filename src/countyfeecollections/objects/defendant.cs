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


    public class Defendant : BaseObject
    {
        // public property backing variables
        private string _strFirstName;
        private string _strMiddleName;
        private string _strLastName;
        private string _strAKA;
        private string _strSSN;
        private DateTime? _birthDate;
        private string _strDriversLicense;
        private string _strStreet1;
        private string _strStreet2;
        private string _strCity;
        private int _intStateId;
        private string _strStateName;
        private string _strZip;
        private string _strPhoneHome;
        private string _strPhoneMobile;
        private bool _HasProbationOfficer;
        private string _strProbationOfficer;
        private DateTime? _BarredUntilDate;
        private string _strNotes;
        private bool _IsActive;
        private int _intDaysInJail;
        private string _strBookingNumber;
        private DateTime? _dtJudgmentDate;

        // public property backing objects
        private EmployersDefendant _Employers;
        private Plans _Plans;

        // property backups
        private string _strFirstName_orig;
        private string _strMiddleName_orig;
        private string _strLastName_orig;
        private string _strAKA_orig;
        private string _strSSN_orig;
        private DateTime? _birthDate_orig;
        private string _strDriversLicense_orig;
        private string _strStreet1_orig;
        private string _strStreet2_orig;
        private string _strCity_orig;
        private int _intStateId_orig;
        private string _strZip_orig;
        private string _strPhoneHome_orig;
        private string _strPhoneMobile_orig;
        private bool _HasProbationOfficer_orig;
        private string _strProbationOfficer_orig;
        private DateTime? _BarredUntilDate_orig;
        private string _strNotes_orig;
        private bool _IsActive_orig;
        private int _intDaysInJail_orig;
        private string _strBookingNumber_orig;
        private DateTime? _dtJudgmentDate_orig;

        private EmployersDefendant _Employers_orig;
        private Plans _Plans_orig;

        #region private bool HasChanged
        private bool HasChanged
        {
            get
            {
                if( _strFirstName_orig == _strFirstName &&
                    _strMiddleName_orig == _strMiddleName &&
                    _strLastName_orig == _strLastName &&
                    _strAKA_orig == _strAKA &&
                    _strSSN_orig == _strSSN &&
                    _birthDate_orig == _birthDate &&
                    _strDriversLicense_orig == _strDriversLicense &&
                    _strStreet1_orig == _strStreet1 &&
                    _strStreet2_orig == _strStreet2 &&
                    _strCity_orig == _strCity &&
                    _intStateId_orig == _intStateId &&
                    _strZip_orig == _strZip &&
                    _strPhoneHome_orig == _strPhoneHome &&
                    _strPhoneMobile_orig == _strPhoneMobile &&
                    _HasProbationOfficer_orig == _HasProbationOfficer &&
                    _strProbationOfficer_orig == _strProbationOfficer &&
                    _BarredUntilDate_orig == _BarredUntilDate &&
                    _strNotes_orig == _strNotes &&
                    _IsActive_orig == _IsActive &&
                    _intDaysInJail_orig == _intDaysInJail &&
                    _strBookingNumber_orig == _strBookingNumber &&
                    _dtJudgmentDate_orig == _dtJudgmentDate)
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

        #region public string FirstName
        public string FirstName
        {
            get { return _strFirstName; }
            set
            {
                if( !_strFirstName.Equals( value ) )
                {
                    _strFirstName = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string MiddleName
        public string MiddleName
        {
            get { return _strMiddleName; }
            set
            {
                if( !_strMiddleName.Equals( value ) )
                {
                    _strMiddleName = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string LastName
        public string LastName
        {
            get { return _strLastName; }
            set
            {
                if( !_strLastName.Equals( value ) )
                {
                    _strLastName = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string Aka
        public string Aka
        {
            get { return _strAKA; }
            set
            {
                if( !_strAKA.Equals( value ) )
                {
                    _strAKA = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string SSN
        public string SSN
        {
            get { return _strSSN; }
            set
            {
                if( !_strSSN.Equals( value ) )
                {
                    _strSSN = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string BirthDate
        public string BirthDate
        {
            get { return (_birthDate.HasValue) ? Helper.FormatLongDateString( _birthDate ) : ""; }
            set
            {

                DateTime? myValue = Helper.MaskedTextBoxDate( value );

                if( !_birthDate.Equals( myValue ) )
                {
                    _birthDate = myValue;
                    base.MyState = MyObjectState.Modified;
                }

            }
        } 
        #endregion

        #region public string DriversLicense
        public string DriversLicense
        {
            get { return _strDriversLicense; }
            set
            {
                if( !_strDriversLicense.Equals( value ) )
                {
                    _strDriversLicense = value;
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

        #region public string HomePhone
        public string HomePhone
        {
            get { return _strPhoneHome; }
            set
            {
                if( !_strPhoneHome.Equals( value ) )
                {
                    _strPhoneHome = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string MobilePhone
        public string MobilePhone
        {
            get { return _strPhoneMobile; }
            set
            {
                if( !_strPhoneMobile.Equals( value ) )
                {
                    _strPhoneMobile = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public bool HasProbationOfficer
        public bool HasProbationOfficer
        {
            get { return _HasProbationOfficer; }
            set
            {
                if( !_HasProbationOfficer.Equals( value ) )
                {
                    _HasProbationOfficer = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string ProbationOfficer
        public string ProbationOfficer
        {
            get { return _strProbationOfficer; }
            set
            {
                if( !_strProbationOfficer.Equals( value ) )
                {
                    _strProbationOfficer = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string BarredUntil
        public string BarredUntil
        {
            get { return (_BarredUntilDate.HasValue) ? Helper.FormatLongDateString( _BarredUntilDate ) : ""; }
            set
            {

                DateTime? myValue = Helper.MaskedTextBoxDate( value );

                if( !_BarredUntilDate.Equals( myValue ) )
                {
                    _BarredUntilDate = myValue;
                    base.MyState = MyObjectState.Modified;
                }

            }
        } 
        #endregion

        #region public string Notes
        public string Notes
        {
            get { return _strNotes; }
            set
            {
                if( !_strNotes.Equals( value ) )
                {
                    _strNotes = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public bool Active
        public bool Active
        {
            get { return _IsActive; }
            set
            {
                if( !_IsActive.Equals( value ) )
                {
                    _IsActive = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public EmployersDefendant Employers
        public EmployersDefendant Employers
        {
            get
            {

                //	Don't create object until explicitly accessed:
                if( _Employers == null )
                {

                    _Employers = new EmployersDefendant( ID );
                    _Employers.ListChanged += new ListChangedEventHandler( child_Changed );
                }
                return _Employers;

            }
        } 
        #endregion

        #region public Plans Plans
        public Plans Plans
        {
            get
            {

                //	Don't create object until explicitly accessed:
                if( _Plans == null )
                {
                    _Plans = new Plans( ID );
                    _Plans.ListChanged += new ListChangedEventHandler( child_Changed );
                }
                return _Plans;

            }
        }
        #endregion

        #region DaysInJail
        public int DaysInJail
        {
            get { return _intDaysInJail; }
            set
            {
                if (_intDaysInJail==value)
                {
                    _intDaysInJail = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region BookingNumber
        public string BookingNumber
        {
            get { return _strBookingNumber; }
            set
            {
                if (_strBookingNumber == value)
                {
                    _strBookingNumber = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public string JudgmentDate
        public string JudgmentDate
        {
            get { return (_dtJudgmentDate.HasValue) ? Helper.FormatLongDateString(_dtJudgmentDate) : ""; }
            set
            {

                DateTime? myValue = Helper.MaskedTextBoxDate(value);

                if (!_dtJudgmentDate.Equals(myValue))
                {
                    _dtJudgmentDate = myValue;
                    base.MyState = MyObjectState.Modified;
                }

            }
        }
        #endregion


        #region public Defendant() : base()
        public Defendant() : base()
        {

            InitializeProperties();

        }  
        #endregion

        #region public Defendant( int id, string updatedBy, DateTime? updatedDate ) : base( id, updatedBy, updatedDate )
        public Defendant( int id, string updatedBy, DateTime? updatedDate ) : base( id, updatedBy, updatedDate )
        {

            InitializeProperties();

        } 
        #endregion




        #region private void Select()
        private void Select()
        {

            if( base.ID > 0 )
            {

                const string sql = "SELECT firstname, middlename, lastname, aka, ssn, birthdate, driverslicense, "
                    + "street1, street2, city, stateid, zip, phonehome, phonemobile, "
                    + "hasprobationofficer, probationofficer, "
                    + "barreduntil, notes, active, updatedby, updateddate, daysinjail, bookingnumber, judgmentdate "
                    + "FROM Defendant "
                    + "WHERE defendantid = @id; ";

                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {
                            InitializeProperties();
                            _strFirstName = dr["firstname"].ToString();
                            _strMiddleName = dr["middlename"].ToString();
                            _strLastName = dr["lastname"].ToString();
                            _strAKA = dr["aka"].ToString();
                            _strSSN = dr["ssn"].ToString();
                            if( !dr.IsDBNull( dr.GetOrdinal( "birthdate" ) ) ) _birthDate = (DateTime)dr["birthdate"];
                            _strDriversLicense = dr["driverslicense"].ToString();
                            _strStreet1 = dr["street1"].ToString();
                            _strStreet2 = dr["street2"].ToString();
                            _strCity = dr["city"].ToString();
                            _intStateId = (dr.IsDBNull( dr.GetOrdinal( "stateid" ) )) ? -1 : Convert.ToInt32( dr["stateid"].ToString() );
                            _strZip = dr["zip"].ToString();
                            _strPhoneHome = dr["phonehome"].ToString();
                            _strPhoneMobile = dr["phonemobile"].ToString();
                            _HasProbationOfficer = (dr.IsDBNull( dr.GetOrdinal( "hasprobationofficer" ) )) ? false : Convert.ToBoolean( dr["hasprobationofficer"].ToString() );
                            _strProbationOfficer = dr["probationofficer"].ToString();
                            if( !dr.IsDBNull( dr.GetOrdinal( "barreduntil" ) ) ) _BarredUntilDate = (DateTime)dr["barreduntil"];
                            _strNotes = dr["notes"].ToString();
                            if( !dr.IsDBNull( dr.GetOrdinal( "active" ) ) ) _IsActive = Convert.ToBoolean( dr["active"].ToString() );
                            _intDaysInJail = (dr.IsDBNull(dr.GetOrdinal("daysinjail"))) ? -1 : Convert.ToInt32(dr["daysinjail"].ToString());
                            _strBookingNumber = dr["bookingnumber"].ToString();
                            if (!dr.IsDBNull(dr.GetOrdinal("judgmentdate"))) _BarredUntilDate = (DateTime)dr["judgmentdate"];
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

        #region private void Insert( SqlTransaction trx, DateTime updateDate )
        private void Insert( SqlTransaction trx, DateTime updateDate )
        {

            const string sql = "INSERT INTO Defendant ( "
                + "firstname, middlename, lastname, aka, ssn, birthdate, driverslicense, "
                + "street1, street2, city, stateid, zip, phonehome, phonemobile, "
                + "hasprobationofficer, probationofficer, "
                + "barreduntil, notes, active, "
                + "daysinjail, bookingnumber, judgmentdate, "
                + "updatedby, updateddate "
                + ") VALUES ( "
                + "@firstname, @middlename, @lastname, @aka, @ssn, @birthdate, @driverslicense, "
                + "@street1, @street2, @city, @stateid, @zip, @phonehome, @phonemobile, "
                + "@hasprobationofficer, @probationofficer, "
                + "@barreduntil, @notes, 1, "
                + "@daysinjail, @bookingnumber, @judgmentdate,"
                + "@updatedby, @updateddate "
                + "); ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@firstname", SqlDbType.VarChar ).Value = _strFirstName;
                cmd.Parameters.Add( "@middlename", SqlDbType.VarChar ).Value = _strMiddleName;
                cmd.Parameters.Add( "@lastname", SqlDbType.VarChar ).Value = _strLastName;
                cmd.Parameters.Add( "@aka", SqlDbType.VarChar ).Value = _strAKA;
                cmd.Parameters.Add( "@ssn", SqlDbType.VarChar ).Value = _strSSN;

                if( _birthDate == null )
                    cmd.Parameters.Add( "@birthdate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@birthdate", SqlDbType.DateTime ).Value = _birthDate;

                cmd.Parameters.Add( "@driverslicense", SqlDbType.VarChar ).Value = _strDriversLicense;
                cmd.Parameters.Add( "@street1", SqlDbType.VarChar ).Value = _strStreet1;
                cmd.Parameters.Add( "@street2", SqlDbType.VarChar ).Value = _strStreet2;
                cmd.Parameters.Add( "@city", SqlDbType.VarChar ).Value = _strCity;

                if( _intStateId < 0 )
                    cmd.Parameters.Add( "@stateid", SqlDbType.Int ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@stateid", SqlDbType.Int ).Value = _intStateId;

                cmd.Parameters.Add( "@zip", SqlDbType.VarChar ).Value = _strZip;
                cmd.Parameters.Add( "@phonehome", SqlDbType.VarChar ).Value = _strPhoneHome;
                cmd.Parameters.Add( "@phonemobile", SqlDbType.VarChar ).Value = _strPhoneMobile;
                cmd.Parameters.Add( "@hasprobationofficer", SqlDbType.Bit ).Value = _HasProbationOfficer;
                cmd.Parameters.Add( "@probationofficer", SqlDbType.VarChar ).Value = _strProbationOfficer;

                if( _BarredUntilDate == null )
                    cmd.Parameters.Add( "@barreduntil", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@barreduntil", SqlDbType.DateTime ).Value = _BarredUntilDate;

                cmd.Parameters.Add( "@notes", SqlDbType.VarChar ).Value = _strNotes;

                if (_intDaysInJail < 0)
                    cmd.Parameters.Add("@daysinjail", SqlDbType.Int).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@daysinjail", SqlDbType.Int).Value = _intDaysInJail;
                cmd.Parameters.Add("@bookingnumber", SqlDbType.VarChar).Value = _strBookingNumber;
                if (_dtJudgmentDate == null)
                    cmd.Parameters.Add("@judgmentdate", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@judgmentdate", SqlDbType.DateTime).Value = _dtJudgmentDate;

                base.Insert( cmd, updateDate );
            }

        }  
        #endregion

        #region private void Update( SqlTransaction trx, DateTime updateDate )
        private void Update( SqlTransaction trx, DateTime updateDate )
        {

            const string sql = "UPDATE Defendant SET "
                + "firstname = @firstname, "
                + "middlename = @middlename, "
                + "lastname = @lastname, "
                + "aka = @aka, "
                + "ssn = @ssn, "
                + "birthdate = @birthdate, "
                + "driverslicense = @driverslicense, "
                + "street1 = @street1, "
                + "street2 = @street2, "
                + "city = @city, "
                + "stateid = @stateid, "
                + "zip = @zip, "
                + "phonehome = @phonehome, "
                + "phonemobile = @phonemobile, "
                + "hasprobationofficer = @hasprobationofficer, "
                + "probationofficer = @probationofficer, "
                + "barreduntil = @barreduntil, "
                + "notes = @notes, "
                + "daysinjail = @daysinjail,"
                + "bookingnumber = @bookingnumber,"
                + "judgmentdate = @judgmentdate,"
                + "active = @active, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE defendantid = @id "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@firstname", SqlDbType.VarChar ).Value = _strFirstName;
                cmd.Parameters.Add( "@middlename", SqlDbType.VarChar ).Value = _strMiddleName;
                cmd.Parameters.Add( "@lastname", SqlDbType.VarChar ).Value = _strLastName;
                cmd.Parameters.Add( "@aka", SqlDbType.VarChar ).Value = _strAKA;
                cmd.Parameters.Add( "@ssn", SqlDbType.VarChar ).Value = _strSSN;

                if( _birthDate == null )
                    cmd.Parameters.Add( "@birthdate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@birthdate", SqlDbType.DateTime ).Value = _birthDate;

                cmd.Parameters.Add( "@driverslicense", SqlDbType.VarChar ).Value = _strDriversLicense;
                cmd.Parameters.Add( "@street1", SqlDbType.VarChar ).Value = _strStreet1;
                cmd.Parameters.Add( "@street2", SqlDbType.VarChar ).Value = _strStreet2;
                cmd.Parameters.Add( "@city", SqlDbType.VarChar ).Value = _strCity;

                if( _intStateId < 0 )
                    cmd.Parameters.Add( "@stateid", SqlDbType.Int ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@stateid", SqlDbType.Int ).Value = _intStateId;

                cmd.Parameters.Add( "@zip", SqlDbType.VarChar ).Value = _strZip;
                cmd.Parameters.Add( "@phonehome", SqlDbType.VarChar ).Value = _strPhoneHome;
                cmd.Parameters.Add( "@phonemobile", SqlDbType.VarChar ).Value = _strPhoneMobile;
                cmd.Parameters.Add( "@hasprobationofficer", SqlDbType.Bit ).Value = _HasProbationOfficer;
                cmd.Parameters.Add( "@probationofficer", SqlDbType.VarChar ).Value = _strProbationOfficer;

                if( _BarredUntilDate == null )
                    cmd.Parameters.Add( "@barreduntil", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@barreduntil", SqlDbType.DateTime ).Value = _BarredUntilDate;

                cmd.Parameters.Add( "@notes", SqlDbType.VarChar ).Value = _strNotes;
                cmd.Parameters.Add( "@active", SqlDbType.Bit ).Value = _IsActive;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;


                cmd.Parameters.Add("@daysinjail", SqlDbType.Int).Value = _intDaysInJail;
                cmd.Parameters.Add("@bookingnumber", SqlDbType.VarChar).Value = _strBookingNumber;
                if (_dtJudgmentDate == null)
                    cmd.Parameters.Add("@judgmentdate", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@judgmentdate", SqlDbType.DateTime).Value = _dtJudgmentDate;

                base.Update( cmd, updateDate );

            }

        }  
        #endregion




        #region private void Delete()
        /// <summary>
        /// Deletes a defendant from the database.  
        /// 
        /// The method relies on the database cascading the necessesary deletes from the 
        /// defendant table to ensure data integrity.
        /// </summary>
        private void Delete()
        {

            //const string sql = "DELETE FROM Defendant "
            //    + "WHERE defendantid = @id "
            //    + "AND updatedby = @updatedby "
            //    + "AND updateddate = @updateddate; ";

            //using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            //using( SqlCommand cmd = new SqlCommand( sql, con ) )
            //{
            //    base.Delete( cmd );
            //}

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
                        using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
                        using( SqlTransaction trx = DBSettings.NewSqlTransaction( "DefendantInsert", con ) )
                        {

                            try
                            {

                                Insert( trx, updateDate );

                                //After an insert, defendant child collections must have their the parentid 
                                //updated with the new defendantid or they will get orphaned.

                                if( _Employers != null )
                                {
                                    _Employers.ParentId = this.ID;
                                    _Employers.SaveDefendantEmployers( trx );
                                }

                                if( _Plans != null )
                                {
                                    _Plans.ParentId = this.ID;
                                    _Plans.SaveDefendantPlans( trx );
                                }

                                trx.Commit();

                            }
                            catch
                            {
                                // rolling back the transaction and rethrowing base error.
                                trx.Rollback();
                                throw;
                            }

                        }
                        break;


                    case MyObjectState.Modified:
                        using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
                        using( SqlTransaction trx = DBSettings.NewSqlTransaction( "DefendantUpdate", con ) )
                        {
                            try
                            {
                                if( HasChanged )
                                    Update( trx, updateDate );

                                if( _Employers != null )
                                {
                                    _Employers.SaveDefendantEmployers( trx );
                                }

                                if( _Plans != null )
                                {
                                    _Plans.SaveDefendantPlans( trx );
                                }

                                trx.Commit();

                            }
                            catch
                            {
                                // rolling back the transaction and rethrowing base error.
                                trx.Rollback();
                                throw;
                            }
                        }
                        break;

                }

                // updating audit variables in child collections
                if( HasChanged )
                    this.SetNewUpdateProperties( LocalUser.WindowsUserName, updateDate );

                _Employers.CleanCollection();
                _Plans.CleanCollection();

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
        /*
         * The select will initialize the object and therefore cause the child objects to reset themselves
         * without explicitly having to refresh them.
         */
        public override void Refresh()
        {

            Select();
            SaveBackups();

            base.Refresh();

        } 
        #endregion

        #region private void InitializeProperties()
        private void InitializeProperties()
        {

            _strFirstName_orig = _strFirstName = string.Empty;
            _strMiddleName_orig = _strMiddleName = string.Empty;
            _strLastName_orig = _strLastName = string.Empty;
            _strAKA_orig = _strAKA = string.Empty;
            _strSSN_orig = _strSSN = string.Empty;
            _birthDate_orig = _birthDate = null;
            _strDriversLicense_orig = _strDriversLicense = string.Empty;
            _strStreet1_orig = _strStreet1 = string.Empty;
            _strStreet2_orig = _strStreet2 = string.Empty;
            _strCity_orig = _strCity = "Council Bluffs";
            _intStateId_orig = _intStateId = 12;
            _strStateName = "IA";
            _strZip_orig = _strZip = string.Empty;
            _strPhoneHome_orig = _strPhoneHome = string.Empty;
            _strPhoneMobile_orig = _strPhoneMobile = string.Empty;
            _HasProbationOfficer_orig = _HasProbationOfficer = false;
            _strProbationOfficer_orig = _strProbationOfficer = string.Empty;
            _BarredUntilDate_orig = _BarredUntilDate = null;
            _strNotes_orig = _strNotes = string.Empty;
            _IsActive_orig = _IsActive = true;

            _Employers_orig = null;
            _Employers = null;

            _Plans_orig = null;
            _Plans = null;

            _intDaysInJail_orig = _intDaysInJail = 0;
            _strBookingNumber_orig = _strBookingNumber = string.Empty;
            _dtJudgmentDate_orig = _dtJudgmentDate = null;

        } 
        #endregion
        
        #region private void SaveBackups()
        private void SaveBackups()
        {

            _strFirstName_orig = _strFirstName;
            _strMiddleName_orig = _strMiddleName;
            _strLastName_orig = _strLastName;
            _strAKA_orig = _strAKA;
            _strSSN_orig = _strSSN;
            _birthDate_orig = _birthDate;
            _strDriversLicense_orig = _strDriversLicense;
            _strStreet1_orig = _strStreet1;
            _strStreet2_orig = _strStreet2;
            _strCity_orig = _strCity;
            _intStateId_orig = _intStateId;
            _strZip_orig = _strZip;
            _strPhoneHome_orig = _strPhoneHome;
            _strPhoneMobile_orig = _strPhoneMobile;
            _HasProbationOfficer_orig = _HasProbationOfficer;
            _strProbationOfficer_orig = _strProbationOfficer;
            _BarredUntilDate_orig = _BarredUntilDate;
            _strNotes_orig = _strNotes;
            _IsActive_orig = _IsActive;

            _Employers_orig = (_Employers == null) ? null : _Employers.Clone();
            _Plans_orig = (_Plans == null) ? null : _Plans.Clone();

            _intDaysInJail_orig = _intDaysInJail;
            _strBookingNumber_orig = _strBookingNumber;
            _dtJudgmentDate_orig = _dtJudgmentDate;
        }  
        #endregion

        #region private void RestoreBackups()
        private void RestoreBackups()
        {

            _strFirstName = _strFirstName_orig;
            _strMiddleName = _strMiddleName_orig;
            _strLastName = _strLastName_orig;
            _strAKA = _strAKA_orig;
            _strSSN = _strSSN_orig;
            _birthDate = _birthDate_orig;
            _strDriversLicense = _strDriversLicense_orig;
            _strStreet1 = _strStreet1_orig;
            _strStreet2 = _strStreet2_orig;
            _strCity = _strCity_orig;
            StateID = _intStateId_orig;
            _strZip = _strZip_orig;
            _strPhoneHome = _strPhoneHome_orig;
            _strPhoneMobile = _strPhoneMobile_orig;
            _HasProbationOfficer = _HasProbationOfficer_orig;
            _strProbationOfficer = _strProbationOfficer_orig;
            _BarredUntilDate = _BarredUntilDate_orig;
            _strNotes = _strNotes_orig;
            _IsActive = _IsActive_orig;

            _Employers = (_Employers_orig == null) ? null : _Employers_orig.Clone();
            _Plans = (_Plans_orig == null) ? null : _Plans_orig.Clone();

            _intDaysInJail = _intDaysInJail_orig;
            _strBookingNumber = _strBookingNumber_orig;
            _dtJudgmentDate = _dtJudgmentDate_orig;
        }  
        #endregion

        #region private void child_Changed( object sender, ListChangedEventArgs e )
        private void child_Changed( object sender, ListChangedEventArgs e )
        {

            // updating the state of the defendant object if one of the child objects is updated.
            switch( e.ListChangedType )
            {

                case ListChangedType.ItemChanged:
                case ListChangedType.ItemAdded:
                case ListChangedType.ItemDeleted:
                    base.MyState = MyObjectState.Modified;
                    break;
            }

        } 
        #endregion

        #region public static Defendant CreateCurrentDefendant( SqlDataReader dr )
        public static Defendant CreateCurrentDefendant( SqlDataReader dr )
        {

            Defendant defendant = new Defendant();

            int id;
            string updatedby;
            DateTime? updateddate;

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                id = Convert.ToInt32( dr["defendantid"] );
                updatedby = dr["updatedby"].ToString();
                updateddate = (DateTime?)dr["updateddate"];

                defendant = new Defendant( id, updatedby, updateddate );

                defendant.RaiseChangedEvents = false;

                defendant.FirstName = dr["firstname"].ToString();
                defendant.MiddleName = dr["middlename"].ToString();
                defendant.LastName = dr["lastname"].ToString();
                defendant.Aka = dr["aka"].ToString();
                defendant.SSN = dr["ssn"].ToString();
                if( !dr.IsDBNull( dr.GetOrdinal( "birthdate" ) ) ) defendant.BirthDate = dr["birthdate"].ToString();
                defendant.DriversLicense = dr["driverslicense"].ToString();
                defendant.Street1 = dr["street1"].ToString();
                defendant.Street2 = dr["street2"].ToString();
                defendant.City = dr["city"].ToString();
                defendant.StateID = (dr.IsDBNull( dr.GetOrdinal( "stateid" ) )) ? -1 : Convert.ToInt32( dr["stateid"].ToString() );
                defendant.Zip = dr["zip"].ToString();
                defendant.HomePhone = dr["phonehome"].ToString();
                defendant.MobilePhone = dr["phonemobile"].ToString();
                defendant.HasProbationOfficer = (dr.IsDBNull( dr.GetOrdinal( "hasprobationofficer" ) )) ? false : Convert.ToBoolean( dr["hasprobationofficer"].ToString() );
                defendant.ProbationOfficer = dr["probationofficer"].ToString();
                if( !dr.IsDBNull( dr.GetOrdinal( "barreduntil" ) ) ) defendant.BarredUntil = dr["barreduntil"].ToString();
                defendant.Notes = dr["notes"].ToString();
                if( !dr.IsDBNull( dr.GetOrdinal( "active" ) ) ) defendant.Active = Convert.ToBoolean( dr["active"].ToString() );

                defendant.DaysInJail = (dr.IsDBNull(dr.GetOrdinal("daysinjail"))) ? -1 : Convert.ToInt32(dr["daysinjail"].ToString());
                defendant.BookingNumber = dr["bookingnumber"].ToString();
                if (!dr.IsDBNull(dr.GetOrdinal("judgmentdate"))) defendant.JudgmentDate = dr["judgmentdate"].ToString();
                defendant.Save( false );

                defendant.RaiseChangedEvents = true;

            }

            return defendant;
        }  
        #endregion

        
    }

}
