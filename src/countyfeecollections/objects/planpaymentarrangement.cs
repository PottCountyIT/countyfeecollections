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

    public class PlanPaymentArrangement : BaseObject
    {    
        // public property backing variables
        private int _intPlanId;
        private int _intDefendantId;
        private int _intPayPeriodTypeId;
        private int _intPaymentArrangementTypeId;
        private double _dblAmount;
        private DateTime? _StartDate;
        private DateTime? _EndDate;

        // property backup variables
        private int _intPlanId_orig;
        private int _intPayPeriodTypeId_orig;
        private int _intPaymentArrangementTypeId_orig;
        private double _dblAmount_orig;
        private DateTime? _StartDate_orig;
        private DateTime? _EndDate_orig;


        #region public bool HasChanged
        public bool HasChanged
        {
            get
            {

                if( _intPlanId_orig == _intPlanId
                    && _intPayPeriodTypeId_orig == _intPayPeriodTypeId
                    && _intPaymentArrangementTypeId_orig == _intPaymentArrangementTypeId
                    && _dblAmount_orig == _dblAmount
                    && _StartDate_orig == _StartDate
                    && _EndDate_orig == _EndDate )
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

        #region public int PlanId
        public int PlanId
        {
            get { return _intPlanId; }
            set
            {
                if( !_intPlanId.Equals( value ) )
                {
                    _intPlanId = value;
                    base.MyState = MyObjectState.Modified;
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

        #region public int PayPeriodTypeId
        public int PayPeriodTypeId
        {
            get { return _intPayPeriodTypeId; }
            set
            {
                if( !_intPayPeriodTypeId.Equals( value ) )
                {
                    _intPayPeriodTypeId = value;
                    base.MyState = MyObjectState.Modified;
                }
            }

        } 
        #endregion

        #region public int PaymentArrangementTypeId
        public int PaymentArrangementTypeId
        {
            get { return _intPaymentArrangementTypeId; }
            set
            {
                if( !_intPaymentArrangementTypeId.Equals( value ) )
                {
                    _intPaymentArrangementTypeId = value;
                    base.MyState = MyObjectState.Modified;
                }
            }

        } 
        #endregion

        #region public double Amount
        public double Amount
        {
            get { return _dblAmount; }
            set
            {
                if( !_dblAmount.Equals( value ) )
                {
                    _dblAmount = value;
                    base.MyState = MyObjectState.Modified;
                }
            }
        } 
        #endregion

        #region public string StartDate
        public string StartDate
        {
            get { return (_StartDate.HasValue) ? Helper.FormatLongDateString( _StartDate ) : ""; }
            set
            {

                DateTime? myValue = Helper.MaskedTextBoxDate( value );

                if( !_StartDate.Equals( myValue ) )
                {
                    _StartDate = myValue;
                    base.MyState = MyObjectState.Modified;
                }

            }
        } 
        #endregion

        #region public string EndDate
        public string EndDate
        {
            get { return (_EndDate.HasValue) ? Helper.FormatLongDateString( _EndDate ) : ""; }
            set
            {

                DateTime? myValue = Helper.MaskedTextBoxDate( value );

                if( !_EndDate.Equals( myValue ) )
                {
                    _EndDate = myValue;
                    base.MyState = MyObjectState.Modified;
                }

            }
        } 
        #endregion



        public PlanPaymentArrangement() : base ()
        {

            throw new NotImplementedException( "A plan payment arrangement object requires a plan and defendant id." );

        }

        public PlanPaymentArrangement( int planId, int defendantId ) : base()
        {

            _intPlanId = planId;
            _intDefendantId = defendantId;
            InitializeProperties();

        } 

        public PlanPaymentArrangement( int planId, int defendantId, int planPaymentArrangementId, string updatedBy, DateTime? updatedDate ) : base( planPaymentArrangementId, updatedBy, updatedDate )
        {            
            InitializeProperties();
            _intPlanId = planId;
            _intDefendantId = defendantId;
        }




        private void Select()
        {
            if( base.ID > 0 )
            {
                const string sql = "SELECT payperiodtypeid, paymentarrangementtypeid, amount, startdate, enddate, updatedby, updateddate "
                    + "FROM PlanPaymentArrangement "
                    + "WHERE paymentarrangementid = @id "
                    + "AND planid = @planid "
                    + "AND defendantid = @defendantid; ";

                using( SqlCommand cmd = new SqlCommand( sql ) )
                {
                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;
                    cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId;
                    cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                    
                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {
                        if( dr.Read() )
                        {
                            InitializeProperties();
                            if( !dr.IsDBNull( dr.GetOrdinal( "payperiodtypeid" ) ) ) _intPayPeriodTypeId = Convert.ToInt32( dr["payperiodtypeid"] );
                            if( !dr.IsDBNull( dr.GetOrdinal( "paymentarrangementtypeid" ) ) ) _intPaymentArrangementTypeId = Convert.ToInt32( dr["paymentarrangementtypeid"] );
                            if (!dr.IsDBNull( dr.GetOrdinal( "amount" ) )) _dblAmount = Convert.ToDouble( dr["amount"] );
                            if( !dr.IsDBNull( dr.GetOrdinal( "startdate" ) ) ) _StartDate = (DateTime)dr["startdate"];
                            if( !dr.IsDBNull( dr.GetOrdinal( "enddate" ) ) ) _EndDate = (DateTime)dr["enddate"];
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
            const string sql = "INSERT INTO PlanPaymentArrangement ( "
                + "planid, defendantid, payperiodtypeid, paymentarrangementtypeid, amount, startdate, enddate, updatedby, updateddate "
                + ") VALUES ( "
                + "@planid, @defendantid, @payperiodtypeid, @paymentarrangementtypeid, @amount, @startdate, @enddate, @updatedby, @updateddate "
                + "); ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {
                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@payperiodtypeid", SqlDbType.Int ).Value = _intPayPeriodTypeId;
                cmd.Parameters.Add( "@paymentarrangementtypeid", SqlDbType.Int ).Value = _intPaymentArrangementTypeId;
                cmd.Parameters.Add( "@amount", SqlDbType.Decimal ).Value = _dblAmount;

                if( _StartDate == null )
                    cmd.Parameters.Add( "@startdate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@startdate", SqlDbType.DateTime ).Value = _StartDate;

                if( _EndDate == null )
                    cmd.Parameters.Add( "@enddate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@enddate", SqlDbType.DateTime ).Value = _EndDate;

                base.Insert( cmd, updateDate );
            }
        }

        private void Update( SqlTransaction trx, DateTime updateDate )
        {
            const string sql = "UPDATE PlanPaymentArrangement SET "
                + "payperiodtypeid = @payperiodtypeid, "
                + "paymentarrangementtypeid = @paymentarrangementtypeid, "
                + "amount = @amount, "
                + "startdate = @startdate, "
                + "enddate = @enddate, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE paymentarrangementid = @id "
                + "AND planid = @planid "
                + "AND defendantid = @defendantid "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {
                cmd.Parameters.Add( "@payperiodtypeid", SqlDbType.Int ).Value = _intPayPeriodTypeId;
                cmd.Parameters.Add( "@paymentarrangementtypeid", SqlDbType.Int ).Value = _intPaymentArrangementTypeId;
                cmd.Parameters.Add( "@amount", SqlDbType.Decimal ).Value = _dblAmount;
                if( _StartDate == null )
                    cmd.Parameters.Add( "@startdate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@startdate", SqlDbType.DateTime ).Value = _StartDate;

                if( _EndDate == null )
                    cmd.Parameters.Add( "@enddate", SqlDbType.DateTime ).Value = DBNull.Value;
                else
                    cmd.Parameters.Add( "@enddate", SqlDbType.DateTime ).Value = _EndDate;

                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;
                
                base.Update( cmd, updateDate );
            }
        }

        private void Delete( SqlTransaction trx )
        {

            const string sql = "DELETE FROM PlanPaymentArrangement "
                + "WHERE paymentarrangementid = @id "
                + "AND planid = @planid " 
                + "AND defendantid = @defendantid "
                + "AND updatedby = @updatedby "
                + "AND updateddate = @updateddate; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;

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

        public PlanPaymentArrangement Clone()
        {

            PlanPaymentArrangement planPaymentArrangement = new PlanPaymentArrangement(this.PlanId, this.DefendantId, this.ID, this.UpdatedBy, this.UpdatedDate );

            planPaymentArrangement.RaiseChangedEvents = false;


            planPaymentArrangement.PayPeriodTypeId = this.PayPeriodTypeId;
            planPaymentArrangement.PaymentArrangementTypeId = this.PaymentArrangementTypeId;
            planPaymentArrangement.Amount = this.Amount;
            planPaymentArrangement.StartDate = this.StartDate;
            planPaymentArrangement.EndDate = this.EndDate;
            planPaymentArrangement.Save();

            planPaymentArrangement.RaiseChangedEvents = true;

            return planPaymentArrangement;

        }

        protected virtual void InitializeProperties()
        {

            _intPlanId_orig = _intPlanId = -1;

            if( Helper.PayPeriodTypeList.Count > 0 )
                _intPayPeriodTypeId_orig = _intPayPeriodTypeId = Helper.PayPeriodTypeList[0].ID;
            else
                _intPayPeriodTypeId_orig = _intPayPeriodTypeId = 0;

            if( Helper.PaymentArrangementTypeList.Count > 0 )
                _intPaymentArrangementTypeId_orig = _intPaymentArrangementTypeId = Helper.PaymentArrangementTypeList[0].ID;
            else
                _intPaymentArrangementTypeId_orig = _intPaymentArrangementTypeId = 0;

            _dblAmount_orig = _dblAmount = 0;

            _StartDate_orig = _StartDate = null;
            _EndDate_orig = _EndDate = null;

        }

        protected virtual void SaveBackups()
        {
            _intPlanId_orig = _intPlanId;
            _intPayPeriodTypeId_orig = _intPayPeriodTypeId;
            _intPaymentArrangementTypeId_orig = _intPaymentArrangementTypeId;
            _dblAmount_orig = _dblAmount;
            _StartDate_orig = _StartDate;
            _EndDate_orig = _EndDate;
        }

        #region protected virtual void RestoreBackups()
        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// After restoring the variables it resets the state of the object.
        /// </summary>
        protected virtual void RestoreBackups()
        {
            _intPlanId = _intPlanId_orig;
            _intPayPeriodTypeId = _intPayPeriodTypeId_orig;
            _intPaymentArrangementTypeId = _intPaymentArrangementTypeId_orig;
            _dblAmount = _dblAmount_orig;
            _StartDate = _StartDate_orig;
            _EndDate = _EndDate_orig;

        } 
        #endregion



        #region public static PlanPaymentArrangement CreatePlanPaymentArrangement( SqlDataReader dr, int planId, int defendantId )
        public static PlanPaymentArrangement CreatePlanPaymentArrangement( SqlDataReader dr, int planId, int defendantId )
        {
            PlanPaymentArrangement tmpPaymentArrangement = null;

            if( !dr.IsClosed && dr.HasRows )
            {
                // getting id that uniquely identifies the object
                int planPaymentArrangementId = Convert.ToInt32( dr["paymentarrangementid"] );
                string updatedby = dr["updatedby"].ToString();
                DateTime? updateddate = (DateTime)dr["updateddate"];

                tmpPaymentArrangement = new PlanPaymentArrangement( planId, defendantId, planPaymentArrangementId, updatedby, updateddate );

                tmpPaymentArrangement.RaiseChangedEvents = false;

                if( !dr.IsDBNull( dr.GetOrdinal( "payperiodtypeid" ) ) ) tmpPaymentArrangement.PayPeriodTypeId = Convert.ToInt32( dr["payperiodtypeid"] );
                if( !dr.IsDBNull( dr.GetOrdinal( "paymentarrangementtypeid" ) ) ) tmpPaymentArrangement.PaymentArrangementTypeId = Convert.ToInt32( dr["paymentarrangementtypeid"] );
                tmpPaymentArrangement.Amount = (!dr.IsDBNull( dr.GetOrdinal( "amount" ) )) ? Convert.ToDouble( dr["amount"] ) : 0;
                if( !dr.IsDBNull( dr.GetOrdinal( "startdate" ) ) ) tmpPaymentArrangement.StartDate = dr["startdate"].ToString();
                if( !dr.IsDBNull( dr.GetOrdinal( "enddate" ) ) ) tmpPaymentArrangement.EndDate = dr["enddate"].ToString();

                tmpPaymentArrangement.Save();
                tmpPaymentArrangement.RaiseChangedEvents = true;
            }
            return tmpPaymentArrangement;
        } 
        #endregion


        #region public static PlanPaymentArrangement UpdatePaymentArrangementIds( PlanPaymentArrangement planPaymentArrangement, int planId, int defendantId )
        public static PlanPaymentArrangement UpdatePaymentArrangementIds( PlanPaymentArrangement planPaymentArrangement, int planId, int defendantId )
        {

            PlanPaymentArrangement tmpPaymentArrangement = null;

            // getting id that uniquely identifies the object               
            tmpPaymentArrangement = new PlanPaymentArrangement( planId, defendantId, planPaymentArrangement.ID, planPaymentArrangement.UpdatedBy, planPaymentArrangement.UpdatedDate );

            tmpPaymentArrangement.RaiseChangedEvents = false;

            tmpPaymentArrangement.PayPeriodTypeId = planPaymentArrangement.PayPeriodTypeId;
            tmpPaymentArrangement.PaymentArrangementTypeId = planPaymentArrangement.PaymentArrangementTypeId;
            tmpPaymentArrangement.Amount = planPaymentArrangement.Amount;
            tmpPaymentArrangement.StartDate = planPaymentArrangement.StartDate;
            tmpPaymentArrangement.EndDate = planPaymentArrangement.EndDate;

            tmpPaymentArrangement.Save();

            tmpPaymentArrangement.MyState = planPaymentArrangement.MyState;

            tmpPaymentArrangement.RaiseChangedEvents = true;

            return tmpPaymentArrangement;
        } 
        #endregion


    }

}

