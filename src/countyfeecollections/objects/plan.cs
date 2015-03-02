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
using System.ComponentModel;


namespace county.feecollections
{

    public class Plan : BaseObject
    {

        // public property backing variables
        private int _intDefendantId;
        private string _strPlanName;
        private bool _bolCAPP;
        private bool _bolNonCAPP;
        private bool _bolIsFiled;
        private bool _bolNonComplianceNotice;
        private bool _bolHasInsurance;
        private bool _bolInContempt;
        private DateTime? _FiledDate;
        private PlanCases _PlanCases;
        private PlanFees _PlanFees;
        private PlanPaymentArrangements _PlanPaymentArrangements;
        private PlanFeePayments _PlanPayments;         


        // property backups
        private string _strPlanName_orig;
        private bool _bolCAPP_orig;
        private bool _bolNonCAPP_orig;
        private bool _bolIsFiled_orig;
        private bool _bolNonComplianceNotice_orig;
        private bool _bolHasInsurance_orig;
        private bool _bolInContempt_orig;
        private DateTime? _FiledDate_orig;
        private PlanCases _PlanCases_orig;
        private PlanFees _PlanFees_orig;
        private PlanPaymentArrangements _PlanPaymentArrangements_orig;
        private PlanFeePayments _PlanPayments_orig;



        #region public bool HasChanged
        public bool HasChanged
        {
            get
            {

                if( _strPlanName_orig == _strPlanName &&
                    _bolCAPP_orig == _bolCAPP &&
                    _bolNonCAPP_orig == _bolNonCAPP &&
                    _bolIsFiled_orig == _bolIsFiled &&
                    _bolNonComplianceNotice_orig == _bolNonComplianceNotice &&
                    _bolHasInsurance_orig == _bolHasInsurance &&
                    _bolInContempt_orig == _bolInContempt &&
                    _FiledDate_orig == _FiledDate )
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

        #region public string PlanName
        public string PlanName
        {
            get { return _strPlanName; }
            set
            {
                if( !_strPlanName.Equals( value ) )
                {
                    _strPlanName = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public bool CAPP
        public bool CAPP
        {
            get { return _bolCAPP; }
            set
            {
                if( !_bolCAPP.Equals( value ) )
                {
                    _bolCAPP = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public bool NonCAPP
        public bool NonCAPP
        {
            get { return _bolNonCAPP; }
            set
            {
                if( !_bolNonCAPP.Equals( value ) )
                {
                    _bolNonCAPP = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public bool IsFiled
        public bool IsFiled
        {
            get { return _bolIsFiled; }
            set
            {
                if( !_bolIsFiled.Equals( value ) )
                {
                    _bolIsFiled = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public bool NonComplianceNotice
        public bool NonComplianceNotice
        {
            get { return _bolNonComplianceNotice; }
            set
            {
                if( !_bolNonComplianceNotice.Equals( value ) )
                {
                    _bolNonComplianceNotice = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public bool HasInsurance
        public bool HasInsurance
        {
            get { return _bolHasInsurance; }
            set
            {
                if( !_bolHasInsurance.Equals( value ) )
                {
                    _bolHasInsurance = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public bool InContempt
        public bool InContempt
        {
            get { return _bolInContempt; }
            set
            {
                if( !_bolInContempt.Equals( value ) )
                {
                    _bolInContempt = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public DateTime? FiledDate
        public DateTime? FiledDate
        {
            get { return _FiledDate; }
            set
            {
                if( !_FiledDate.Equals( value ) )
                {
                    _FiledDate = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        }
        #endregion

        #region public int FeeCount
        public int FeeCount
        {
            get { return (Fees == null) ? 0 : Fees.Count; }
        } 
        #endregion

        #region public PlanCases Cases
        public PlanCases Cases
        {
            
            get
            {
                //	Don't create object until explicitly accessed:
                if( _PlanCases == null )
                {
                    _PlanCases = new PlanCases( ID, _intDefendantId );
                    _PlanCases.ListChanged += new ListChangedEventHandler( child_Changed );
                }
                return _PlanCases;
            }

            set
            {
                if( (_PlanCases == null && value != null ) || ( _PlanCases != null && !_PlanCases.Equals( value ) && value != null ) )
                {
                    _PlanCases = value.Clone();
                }
            }

        }
        #endregion

        #region public PlanFees Fees
        public PlanFees Fees
        {

            get
            {
                //	Don't create object until explicitly accessed:
                if( _PlanFees == null )
                {
                    _PlanFees = new PlanFees( ID, _intDefendantId );
                    _PlanFees.ListChanged += new ListChangedEventHandler( child_Changed );
                }
                return _PlanFees;
            }

            set
            {
                if( (_PlanFees == null && value != null) || ( _PlanFees!= null && !_PlanFees.Equals( value ) && value != null ) )
                {
                    _PlanFees = value.Clone();
                }
            }

        }
        #endregion

        #region public PlanPaymentArrangements PaymentArrangements
        public PlanPaymentArrangements PaymentArrangements
        {

            get
            {
                //	Don't create object until explicitly accessed:
                if( _PlanPaymentArrangements == null )
                {
                    _PlanPaymentArrangements = new PlanPaymentArrangements( ID, _intDefendantId );
                    _PlanPaymentArrangements.ListChanged += new ListChangedEventHandler( child_Changed );
                }
                return _PlanPaymentArrangements;
            }

            set
            {
                if( (_PlanPaymentArrangements == null && value != null) || (_PlanPaymentArrangements != null && !_PlanPaymentArrangements.Equals( value ) && value != null) )
                {
                    _PlanPaymentArrangements = value.Clone();
                }
            }

        }
        #endregion

        #region public PlanFeePayments Payments
        public PlanFeePayments Payments
        {

            get
            {
                //	Don't create object until explicitly accessed:
                if( _PlanPayments == null )
                {
                    _PlanPayments = new PlanFeePayments( ID, _intDefendantId );
                    _PlanPayments.ListChanged += new ListChangedEventHandler( child_Changed );
                }
                return _PlanPayments;
            }

            set
            {
                if( (_PlanPayments == null && value != null) || (_PlanPayments != null && !_PlanPayments.Equals( value ) && value != null) )
                {
                    _PlanPayments = value.Clone();
                }
            }

        }
        #endregion




        #region public Plan()
        public Plan() 
        {
            throw new NotImplementedException( "A plan requires a defendant id." );
        }
        #endregion

        #region public Plan( int defendantId ) : base()
        public Plan( int defendantId ) : base()
        {

            _intDefendantId = defendantId;
            InitializeProperties();

        } 
        #endregion

        #region public Plan( int defendantId, int planId, string updatedBy, DateTime? updatedDate ) : base( planId, updatedBy, updatedDate )
        public Plan( int defendantId, int planId, string updatedBy, DateTime? updatedDate ) : base( planId, updatedBy, updatedDate )
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

                const string sql = "SELECT planname, capp, noncapp, isfiled, hasinsurance, "
                    + "incontempt, noncompliancenotice, fileddate, updatedby, updateddate "
                    + "FROM DefendantPlans "
                    + "WHERE planid = @id AND defendantid = @defendantid; ";

                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;
                    cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {

                            InitializeProperties();
                            _strPlanName = dr["planname"].ToString();
                            _bolCAPP = (dr.IsDBNull( dr.GetOrdinal( "capp" ) )) ? false : Convert.ToBoolean( dr["capp"].ToString() );
                            _bolNonCAPP = (dr.IsDBNull( dr.GetOrdinal( "noncapp" ) )) ? false : Convert.ToBoolean( dr["noncapp"].ToString() );
                            _bolIsFiled = (dr.IsDBNull( dr.GetOrdinal( "isfiled" ) )) ? false : Convert.ToBoolean( dr["isfiled"].ToString() );
                            _bolNonComplianceNotice = (dr.IsDBNull( dr.GetOrdinal( "noncompliancenotice" ) )) ? false : Convert.ToBoolean( dr["noncompliancenotice"].ToString() );
                            _bolHasInsurance = (dr.IsDBNull( dr.GetOrdinal( "hasinsurance" ) )) ? false : Convert.ToBoolean( dr["hasinsurance"].ToString() );
                            _bolInContempt = (dr.IsDBNull( dr.GetOrdinal( "incontempt" ) )) ? false : Convert.ToBoolean( dr["incontempt"].ToString() );
                            
                            if( !dr.IsDBNull( dr.GetOrdinal( "fileddate" ) ) )
                                _FiledDate = dr.GetDateTime( dr.GetOrdinal("fileddate") );

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

            const string sql = "INSERT INTO DefendantPlans ( "
                + "defendantid, planname, capp, noncapp, isfiled, hasinsurance, "
                + "incontempt, noncompliancenotice, fileddate, updatedby, updateddate "
                + ") VALUES ( "
                + "@defendantid, @planname, @capp, @noncapp, @isfiled, @hasinsurance, "
                + "@incontempt, @noncompliancenotice, @fileddate, @updatedby, @updateddate "
                + "); ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@planname", SqlDbType.VarChar ).Value = _strPlanName;
                cmd.Parameters.Add( "@capp", SqlDbType.Bit ).Value = _bolCAPP;
                cmd.Parameters.Add( "@noncapp", SqlDbType.Bit ).Value = _bolNonCAPP;
                cmd.Parameters.Add( "@isfiled", SqlDbType.Bit ).Value = _bolIsFiled;
                cmd.Parameters.Add( "@noncompliancenotice", SqlDbType.Bit ).Value = _bolNonComplianceNotice;
                cmd.Parameters.Add( "@hasinsurance", SqlDbType.Bit ).Value = _bolHasInsurance;
                cmd.Parameters.Add( "@incontempt", SqlDbType.Bit ).Value = _bolInContempt;

                if( _FiledDate == null )
                    cmd.Parameters.Add( "@fileddate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@fileddate", SqlDbType.DateTime ).Value = _FiledDate;

                base.Insert( cmd, updateDate );

            }

        }
        #endregion

        #region private void Update( SqlTransaction trx, DateTime updateDate )
        private void Update( SqlTransaction trx, DateTime updateDate )
        {
            const string sql = "UPDATE DefendantPlans SET "
                + "planname = @planname, "
                + "capp = @capp, "
                + "noncapp = @noncapp, "
                + "isfiled = @isfiled, "
                + "noncompliancenotice = @noncompliancenotice, "
                + "hasinsurance = @hasinsurance, "
                + "incontempt = @incontempt, "
                + "fileddate = @fileddate, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE planid = @id "
                + "AND defendantid = @defendantid "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@planname", SqlDbType.VarChar ).Value = _strPlanName;
                cmd.Parameters.Add( "@capp", SqlDbType.Bit ).Value = _bolCAPP;
                cmd.Parameters.Add( "@noncapp", SqlDbType.Bit ).Value = _bolNonCAPP;
                cmd.Parameters.Add( "@isfiled", SqlDbType.Bit ).Value = _bolIsFiled;
                cmd.Parameters.Add( "@noncompliancenotice", SqlDbType.Bit ).Value = _bolNonComplianceNotice;
                cmd.Parameters.Add( "@hasinsurance", SqlDbType.Bit ).Value = _bolHasInsurance;
                cmd.Parameters.Add( "@incontempt", SqlDbType.Bit ).Value = _bolInContempt;
                
                if( _FiledDate == null )
                    cmd.Parameters.Add( "@fileddate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@fileddate", SqlDbType.DateTime ).Value = _FiledDate;

                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );
            }
        }
        #endregion

        #region private void Delete( SqlTransaction trx )
        /// <summary>
        /// Deletes a defendant from the database.  
        /// 
        /// The method relies on the database cascading the necessesary deletes from the 
        /// defendant table to ensure data integrity.
        /// </summary>
        private void Delete( SqlTransaction trx )
        {

            const string sql = "DELETE FROM DefendantPlans "
                + "WHERE planid = @id "
                + "AND updatedby = @updatedby "
                + "AND updateddate = @updateddate; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {
                base.Delete( cmd );
            }

        }
        #endregion

        #region public void Save( SqlTransaction trx, DateTime updateDate, int defendantId )
        public void Save( SqlTransaction trx, DateTime updateDate, int defendantId )
        {
            _intDefendantId = defendantId;

            switch( base.MyState )
            {
                case MyObjectState.New:
                    Insert( trx, updateDate );

                    // After an insert, plan child collections must have their parentid 
                    // updated with the new defendantid and planid or they will get orphaned.
                    if( _PlanCases != null )
                    {
                        _PlanCases.UpdateParentIds( this.ID, this.DefendantId );
                        _PlanCases.SavePlanCases( trx );
                    }

                    if( _PlanFees != null )
                    {
                        _PlanFees.UpdateParentIds( this.ID, this.DefendantId );
                        _PlanFees.SavePlanFees( trx );
                    }

                    if( _PlanPaymentArrangements != null )
                    {
                        _PlanPaymentArrangements.UpdateParentIds( this.ID, this.DefendantId );
                        _PlanPaymentArrangements.SavePlanPaymentArrangements( trx );
                    }

                    if( _PlanPayments != null )
                    {
                        _PlanPayments.UpdateParentIds( this.ID, this.DefendantId );
                        _PlanPayments.SavePlanFeePayments( trx );
                    }

                    break;

                case MyObjectState.Modified:

                    if( HasChanged )
                        Update( trx, updateDate );

                    if( _PlanCases != null )
                    {
                        _PlanCases.SavePlanCases( trx );
                    }

                    if( _PlanFees != null )
                    {
                        _PlanFees.SavePlanFees( trx );
                    }

                    if( _PlanPaymentArrangements != null )
                    {
                        _PlanPaymentArrangements.SavePlanPaymentArrangements( trx );
                    }

                    if( _PlanPayments != null )
                    {
                        _PlanPayments.SavePlanFeePayments( trx );
                    }

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
        public new void Remove( bool updateDatabase )
        {
            throw new NotImplementedException();
        }
        #endregion

        #region public void Remove( SqlTransaction trx )
        public void Remove( SqlTransaction trx )
        {

            Delete( trx );
            Remove();

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
            Save();
            
        }
        #endregion

        #region public Plan Clone()
        public Plan Clone()
        {

            Plan plan = new Plan( _intDefendantId, this.ID, this.UpdatedBy, this.UpdatedDate );

            plan.RaiseChangedEvents = false;

            plan.PlanName = this.PlanName;
            plan.CAPP = this.CAPP;
            plan.NonCAPP = this.NonCAPP;
            plan.IsFiled = this.IsFiled;
            plan.NonComplianceNotice = this.NonComplianceNotice;
            plan.HasInsurance = this.HasInsurance;
            plan.InContempt = this.InContempt;
            plan.FiledDate = this.FiledDate;

            // cloning object collections
            plan.Cases = (_PlanCases == null) ? null : _PlanCases.Clone();
            plan.Fees = (_PlanFees == null) ? null : _PlanFees.Clone();
            plan.PaymentArrangements = (_PlanPaymentArrangements == null) ? null : _PlanPaymentArrangements.Clone();
            plan.Payments = (_PlanPayments == null) ? null : _PlanPayments.Clone();

            plan.Save();

            plan.RaiseChangedEvents = true;

            return plan;

        }
        #endregion




        #region private void InitializeProperties()
        private void InitializeProperties()
        {

            _strPlanName_orig = _strPlanName = string.Empty;
            _bolCAPP_orig = _bolCAPP = false;
            _bolNonCAPP_orig = _bolNonCAPP = false;
            _bolIsFiled_orig = _bolIsFiled = false;
            _bolNonComplianceNotice_orig = _bolNonComplianceNotice = false;
            _bolHasInsurance_orig = _bolHasInsurance = false;
            _bolInContempt_orig = _bolInContempt = false;
            _FiledDate_orig = _FiledDate = null;
            _PlanCases_orig = null;
            _PlanCases = null;
            _PlanFees_orig = null;
            _PlanFees = null;
            _PlanPaymentArrangements_orig = null;
            _PlanPaymentArrangements = null;
            _PlanPayments_orig = null;
            _PlanPayments = null;

        }
        #endregion

        #region private void SaveBackups()
        private void SaveBackups()
        {

            _strPlanName_orig = _strPlanName;
            _bolCAPP_orig = _bolCAPP;
            _bolNonCAPP_orig = _bolNonCAPP;
            _bolIsFiled_orig = _bolIsFiled;
            _bolNonComplianceNotice_orig = _bolNonComplianceNotice;
            _bolHasInsurance_orig = _bolHasInsurance;
            _bolInContempt_orig = _bolInContempt;
            _FiledDate_orig = _FiledDate;
            
            // force payment collection to refresh itself.
            _PlanPayments = null;

            _PlanCases_orig = (_PlanCases == null) ? null : _PlanCases.Clone();
            _PlanFees_orig = (_PlanFees == null) ? null : _PlanFees.Clone();
            _PlanPaymentArrangements_orig = (_PlanPaymentArrangements == null) ? null : _PlanPaymentArrangements.Clone();
            _PlanPayments_orig = (_PlanPayments == null) ? null : _PlanPayments.Clone();

        }
        #endregion

        #region private void RestoreBackups()
        private void RestoreBackups()
        {

            _strPlanName = _strPlanName_orig;
            _bolCAPP = _bolCAPP_orig;
            _bolNonCAPP = _bolNonCAPP_orig;
            _bolIsFiled = _bolIsFiled_orig;
            _bolNonComplianceNotice = _bolNonComplianceNotice_orig;
            _bolHasInsurance = _bolHasInsurance_orig;
            _bolInContempt = _bolInContempt_orig;
            _FiledDate = _FiledDate_orig;

            _PlanCases = (_PlanCases_orig == null) ? null : _PlanCases_orig.Clone();
            _PlanFees = (_PlanFees_orig == null) ? null : _PlanFees_orig.Clone();
            _PlanPaymentArrangements = (_PlanPaymentArrangements_orig == null) ? null : _PlanPaymentArrangements_orig.Clone();
            _PlanPayments = (_PlanPayments_orig == null) ? null : _PlanPayments_orig.Clone();

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



        #region public static Plan CreateCurrentPlan( SqlDataReader dr, int defendantId )
        public static Plan CreateCurrentPlan( SqlDataReader dr, int defendantId )
        {

            Plan plan = new Plan( defendantId );

            int id;
            string updatedby;
            DateTime? updateddate;

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                id = Convert.ToInt32( dr["planid"] );
                updatedby = dr["updatedby"].ToString();
                updateddate = (DateTime)dr["updateddate"];

                plan = new Plan( defendantId, id, updatedby, updateddate );

                plan.RaiseChangedEvents = false;
                plan.PlanName = dr["planname"].ToString();
                plan.CAPP = (dr.IsDBNull( dr.GetOrdinal( "capp" ) )) ? false : Convert.ToBoolean( dr["capp"].ToString() );
                plan.NonCAPP = (dr.IsDBNull( dr.GetOrdinal( "noncapp" ) )) ? false : Convert.ToBoolean( dr["noncapp"].ToString() );
                plan.IsFiled = (dr.IsDBNull( dr.GetOrdinal( "isfiled" ) )) ? false : Convert.ToBoolean( dr["isfiled"].ToString() );
                plan.NonComplianceNotice = (dr.IsDBNull( dr.GetOrdinal( "noncompliancenotice" ) )) ? false : Convert.ToBoolean( dr["noncompliancenotice"].ToString() );
                plan.HasInsurance = (dr.IsDBNull( dr.GetOrdinal( "hasinsurance" ) )) ? false : Convert.ToBoolean( dr["hasinsurance"].ToString() );
                plan.InContempt = (dr.IsDBNull( dr.GetOrdinal( "incontempt" ) )) ? false : Convert.ToBoolean( dr["incontempt"].ToString() );

                if( !dr.IsDBNull( dr.GetOrdinal( "fileddate" ) ) )
                    plan.FiledDate = dr.GetDateTime( dr.GetOrdinal( "fileddate" ) );

                plan.Save();

                plan.RaiseChangedEvents = true;

            }

            return plan;
        }
        #endregion



    }

}
