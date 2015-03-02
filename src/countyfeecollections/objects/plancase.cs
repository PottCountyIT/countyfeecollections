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

    public class PlanCase : BaseObject
    {        
        // public property backing variables
        private int _intDefendantId;
        private string _strCaseName;
        private int _intCountyId;
        private string _strCounty;
        private bool _Committed;
        private DateTime? _CommitDate;
        private DateTime? _CommitBaseDate;
        private double _dblCommitDaysTill;
        private bool _CAPP;

        // property backup variables
        private string _strCaseName_orig;
        private int _intCountyId_orig;
        private bool _Committed_orig;
        private DateTime? _CommitDate_orig;
        private DateTime? _CommitBaseDate_orig;
        private double _dblCommitDaysTill_orig;
        private bool _CAPP_orig;



        #region public bool HasChanged
        public bool HasChanged
        {
            get
            {

                if(_strCaseName_orig == _strCaseName
                    && _intCountyId_orig == _intCountyId
                    && _Committed_orig == _Committed
                    && _CommitDate_orig == _CommitDate
                    && _CommitBaseDate_orig == _CommitBaseDate
                    && _dblCommitDaysTill_orig == _dblCommitDaysTill
                    && _CAPP_orig == _CAPP )
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

        public int DefendantId
        {
            get { return _intDefendantId; }
        }

        public string CaseName
        {
            get { return _strCaseName; }
            set 
            {
                if( !_strCaseName.Equals( value ) )
                {
                    _strCaseName = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }

        public int CountyId
        {
            get { return _intCountyId; }
            set
            {
                if( !_intCountyId.Equals( value ) )
                {
                    _intCountyId = value;
                    _strCounty = Helper.GetIowaCountyByID( _intCountyId );
                    base.MyState = MyObjectState.Modified;
                }
            }
        }

        public string County
        {
            get { return _strCounty; }
        }

        public bool Committed
        {
            get { return _Committed; }
            set 
            {
                if( !_Committed.Equals( value ) )
                {
                    _Committed = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }

        public string CommitDate
        {
            get { return (_CommitDate.HasValue) ? Helper.FormatLongDateString( _CommitDate ) : ""; }
            set
            {

                DateTime? myValue = Helper.MaskedTextBoxDate( value );

                if( !_CommitDate.Equals( myValue ) )
                {
                    _CommitDate = myValue;
                    base.MyState = MyObjectState.Modified;
                }

            }
        }

        public string CommitBaseDate
        {
            get { return (_CommitBaseDate.HasValue) ? Helper.FormatLongDateString( _CommitBaseDate ) : ""; }
            set
            {

                DateTime? myValue = Helper.MaskedTextBoxDate( value );

                if( !_CommitBaseDate.Equals( myValue ) )
                {
                    _CommitBaseDate = myValue;
                    base.MyState = MyObjectState.Modified;
                }

            }
        }

        public double CommitDaysTill
        {
            get { return _dblCommitDaysTill; }
            set
            {
                if( !_dblCommitDaysTill.Equals( value ) )
                {
                    _dblCommitDaysTill = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }

        public bool CAPP
        {
            get { return _CAPP; }
            set 
            {
                if( !_CAPP.Equals( value ) )
                {
                    _CAPP = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }

        public PlanCase() : base ()
        {

            throw new NotImplementedException( "A plan case object requires a plan and defendant id." );

        }

        public PlanCase( int planId, int defendantId ) : base( planId )
        {

            _intDefendantId = defendantId;
            InitializeProperties();

        } 

        public PlanCase( int planId, int defendantId, string casename, string updatedBy, DateTime? updatedDate ) : base( planId, updatedBy, updatedDate )
        {
            
            
            InitializeProperties();
            _intDefendantId = defendantId;
            _strCaseName = casename;

        }

        private void Select()
        {

            if( base.ID > 0 )
            {

                const string sql = "SELECT casename, countyid, committed, commitdate, commitdaystill, commitbasedate, capp, updatedby, updateddate "
                    + "FROM PlanCase "
                    + "WHERE planid = @id "
                    + "AND defendantid = @defendantid "
                    + "AND casename = @casename; ";


                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID; 
                    cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                    cmd.Parameters.Add( "@casename", SqlDbType.VarChar ).Value = _strCaseName_orig;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {
                            InitializeProperties();
                            _strCaseName = dr["casename"].ToString();
                            if( !dr.IsDBNull( dr.GetOrdinal( "countyid" ) ) ) _intCountyId = Convert.ToInt32( dr["countyid"] );
                            _Committed = Convert.ToBoolean( dr["committed"].ToString() );
                            if( !dr.IsDBNull( dr.GetOrdinal( "commitdate" ) ) ) _CommitDate = (DateTime)dr["commitdate"];
                            if( !dr.IsDBNull( dr.GetOrdinal( "commitdaystill" ) ) ) _dblCommitDaysTill = Convert.ToDouble( dr["commitdaystill"] ); 
                            if( !dr.IsDBNull( dr.GetOrdinal( "commitbasedate" ) ) ) _CommitBaseDate = (DateTime)dr["commitbasedate"];
                            _CAPP = Convert.ToBoolean( dr["capp"].ToString() );
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

        private void Insert( SqlTransaction trx, DateTime updateDate )
        {

            const string sql = "INSERT INTO PlanCase ( "
                + "planid, defendantid, casename, countyid, committed, commitdate, commitdaystill, commitbasedate, capp, updatedby, updateddate "
                + ") VALUES ( "
                + "@id, @defendantid, @casename, @countyid, @committed, @commitdate, @commitdaystill, @commitbasedate, @capp, @updatedby, @updateddate "
                + "); ";


            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@casename", SqlDbType.VarChar ).Value = _strCaseName;
                cmd.Parameters.Add( "@countyid", SqlDbType.Int ).Value = _intCountyId;
                cmd.Parameters.Add( "@committed", SqlDbType.Bit ).Value = _Committed;

                if( _CommitDate == null )
                    cmd.Parameters.Add( "@commitdate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@commitdate", SqlDbType.DateTime ).Value = _CommitDate;

                cmd.Parameters.Add( "@commitdaystill", SqlDbType.Decimal ).Value = _dblCommitDaysTill;

                if( _CommitBaseDate == null )
                    cmd.Parameters.Add( "@commitbasedate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@commitbasedate", SqlDbType.DateTime ).Value = _CommitBaseDate;

                cmd.Parameters.Add( "@capp", SqlDbType.Bit ).Value = _CAPP;

                base.Insert( cmd, updateDate );

            }

        }

        private void Update( SqlTransaction trx, DateTime updateDate )
        {

            const string sql = "UPDATE PlanCase SET "
                + "casename = @casename, "
                + "countyid = @countyid, "
                + "committed = @committed, "
                + "commitdate = @commitdate, "
                + "commitbasedate = @commitbasedate, "
                + "commitdaystill = @commitdaystill, "
                + "capp = @capp, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE planid = @id "
                + "AND defendantid = @defendantid "
                + "AND casename = @casename_orig "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@casename", SqlDbType.VarChar ).Value = _strCaseName;
                cmd.Parameters.Add( "@countyid", SqlDbType.Int ).Value = _intCountyId;
                cmd.Parameters.Add( "@committed", SqlDbType.Bit ).Value = _Committed;

                if( _CommitDate == null )
                    cmd.Parameters.Add( "@commitdate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@commitdate", SqlDbType.DateTime ).Value = _CommitDate;


                if( _CommitBaseDate == null )
                    cmd.Parameters.Add( "@commitbasedate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@commitbasedate", SqlDbType.DateTime ).Value = _CommitBaseDate;

                cmd.Parameters.Add( "@commitdaystill", SqlDbType.Decimal ).Value =_dblCommitDaysTill;
                cmd.Parameters.Add( "@capp", SqlDbType.Bit ).Value = _CAPP;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@casename_orig", SqlDbType.VarChar ).Value = _strCaseName_orig;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );

            }

        }

        private void Delete( SqlTransaction trx )
        {

            const string sql = "DELETE FROM PlanCase "
                + "WHERE planid = @id "
                + "AND defendantid = @defendantid "
                + "AND casename = @casename "
                + "AND updatedby = @updatedby "
                + "AND updateddate = @updateddate; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@casename", SqlDbType.VarChar ).Value = _strCaseName_orig;

                base.Delete( cmd );
            }

        }

        public void Save( SqlTransaction trx, DateTime updateDate )
        {

            switch( base.MyState )
            {

                case MyObjectState.New:
                    Insert( trx, updateDate );
                    break;

                case MyObjectState.Modified:
                    Update( trx, updateDate );
                    break;

            }

        }

        public void Save()
        {

            SaveBackups();
            base.MyState = MyObjectState.Current;

        }

        /// <summary>
        /// throws NotImplementedException
        /// </summary>
        public new void Remove( bool updateDatabase )
        {
            throw new NotImplementedException();
        }

        public void Remove( SqlTransaction trx )
        {

            Delete( trx );
            Remove();

        }

        public void Remove()
        {

            base.Remove( false );

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
            Save();

        }

        public PlanCase Clone()
        {

            PlanCase tmpcase = new PlanCase( this.ID, this.DefendantId, this.CaseName, this.UpdatedBy, this.UpdatedDate );

            tmpcase.RaiseChangedEvents = false;

            tmpcase.CountyId = this.CountyId;
            tmpcase.Committed = this.Committed;
            tmpcase.CommitDate = this.CommitDate;
            tmpcase.CommitBaseDate = this.CommitBaseDate;
            tmpcase.CommitDaysTill = this.CommitDaysTill;
            tmpcase.CAPP = this.CAPP;
            tmpcase.Save();

            tmpcase.RaiseChangedEvents = true;

            return tmpcase;

        }

        private void InitializeProperties()
        {

            LocalUser usr = new LocalUser();
            

            _strCaseName_orig = _strCaseName = string.Empty;
            _intCountyId_orig = _intCountyId = usr.HomeCountyId;
            _Committed_orig = _Committed = true;
            _CommitDate_orig = _CommitDate = null;
            _CommitBaseDate_orig = _CommitBaseDate = null;
            _dblCommitDaysTill_orig = _dblCommitDaysTill = 0;
            _CAPP_orig = _CAPP = false;

        }

        private void SaveBackups()
        {

            _strCaseName_orig = _strCaseName;
            _intCountyId_orig = _intCountyId;
            _Committed_orig = _Committed;
            _CommitDate_orig = _CommitDate;
            _CommitBaseDate_orig = _CommitBaseDate;
            _dblCommitDaysTill_orig = _dblCommitDaysTill;
            _CAPP_orig = _CAPP;

        } 

        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// After restoring the variables it resets the state of the object.
        /// </summary>
        private void RestoreBackups()
        {

            _strCaseName = _strCaseName_orig;
            _intCountyId = _intCountyId_orig;
            _Committed = _Committed_orig;
            _CommitDate = _CommitDate_orig;
            _CommitBaseDate = _CommitBaseDate_orig;
            _dblCommitDaysTill = _dblCommitDaysTill_orig;
            _CAPP = _CAPP_orig;

        } 

        public static PlanCase CreateCase( SqlDataReader dr, int planId, int defendantId )
        {

            PlanCase tmpcase = null;

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                string casename = dr["casename"].ToString();
                string updatedby = dr["updatedby"].ToString();
                DateTime updateddate = (DateTime)dr["updateddate"];

                tmpcase = new PlanCase( planId, defendantId, casename, updatedby, updateddate );

                tmpcase.RaiseChangedEvents = false;

                tmpcase.CountyId = ( !dr.IsDBNull( dr.GetOrdinal( "countyid" ) ) ) ? Convert.ToInt32( dr["countyid"] ) : -1 ;
                tmpcase.Committed = Convert.ToBoolean( dr["committed"].ToString() );
                if( !dr.IsDBNull( dr.GetOrdinal( "commitdate" ) ) ) tmpcase.CommitDate = dr["commitdate"].ToString();
                if( !dr.IsDBNull( dr.GetOrdinal( "commitbasedate" ) ) ) tmpcase.CommitBaseDate = dr["commitbasedate"].ToString();
                tmpcase.CommitDaysTill = (!dr.IsDBNull( dr.GetOrdinal( "commitdaystill" ) )) ? Convert.ToDouble( dr["commitdaystill"] ) : 0;
                tmpcase.CAPP = Convert.ToBoolean( dr["capp"].ToString() );
                tmpcase.Save();

                tmpcase.RaiseChangedEvents = true;

            }

            return tmpcase;
        }

        public static PlanCase UpdateCaseIds( PlanCase planCase, int planId, int defendantId )
        {

            PlanCase tmpcase = null;

            // getting id that uniquely identifies the object               
            tmpcase = new PlanCase( planId, defendantId, planCase.CaseName, planCase.UpdatedBy, planCase.UpdatedDate );

            tmpcase.RaiseChangedEvents = false;

            tmpcase.CountyId = planCase.CountyId;
            tmpcase.Committed = planCase.Committed;
            tmpcase.CommitDate = planCase.CommitDate;
            tmpcase.CommitBaseDate = planCase.CommitBaseDate;
            tmpcase.CommitDaysTill = planCase.CommitDaysTill;
            tmpcase.CAPP = planCase.CAPP;
            tmpcase.Save();

            tmpcase.MyState = planCase.MyState;

            tmpcase.RaiseChangedEvents = true;

            return tmpcase;
        }   
    }
}
