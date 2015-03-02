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

    public class FeePayment : BaseObject
    {

        
        // public property backing variables
        private int _intPlanId;
        private int _intFeeTypeId;
        private DateTime _ReceivedDate;
        private double _dblAmount;


        // property backup variables
        private int _intPlanId_orig;
        private int _intFeeTypeId_orig;
        private DateTime _ReceivedDate_orig;
        private double _dblAmount_orig;



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

        #region public int FeeTypeId
        public int FeeTypeId
        {
            get { return _intFeeTypeId; }
            set 
            {
                if( !_intFeeTypeId.Equals( value ) )
                {
                    _intFeeTypeId = value;
                    base.MyState = MyObjectState.Modified;
                }
            }

        }
        #endregion

        #region public string FeeTypeName
        public string FeeTypeName
        {
            get { return Helper.GetFeeTypeByID( _intFeeTypeId ); }
        } 
        #endregion

        #region public DateTime ReceivedDate
        public DateTime ReceivedDate
        {
            get { return _ReceivedDate; }
            set
            {
                if( !_ReceivedDate.Equals( value ) )
                {
                    _ReceivedDate = value;
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



        
        #region public FeePayment() : base ()
        public FeePayment() : base()
        {

            throw new NotImplementedException( "A fee payment object requires a plan, defendant, and feetype id." );

        }
        #endregion

        #region public FeePayment( int planId, int defendantId, int feeTypeId ): base( defendantId )
        public FeePayment( int planId, int defendantId, int feeTypeId ) : base( defendantId )
        {

            InitializeProperties();

            _intPlanId = planId;
            _intFeeTypeId = feeTypeId;

        } 
        #endregion

        #region public FeePayment( int planId, int defendantId, int feeTypeId, DateTime receivedDate, string updatedBy, DateTime? updatedDate ) : base( defendantId, updatedBy, updatedDate )
        public FeePayment( int planId, int defendantId, int feeTypeId, DateTime receivedDate, string updatedBy, DateTime? updatedDate ) : base( defendantId, updatedBy, updatedDate )
        {
            
            InitializeProperties();

            _intPlanId = planId;
            _intFeeTypeId = feeTypeId;
            ReceivedDate = receivedDate;

        }
        #endregion



        
        #region private void Select()
        private void Select()
        {

            if( base.ID > 0 )
            {

                const string sql = "SELECT feetypeid, receiveddate, amount, updatedby, updateddate "
                    + "FROM FeePayment "
                    + "WHERE defendantid = @id "
                    + "AND planid = @planid "
                    + "AND feetypeid = @feetypeid "
                    + "AND receiveddate = @receiveddate; ";


                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;
                    cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId_orig;
                    cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId_orig;
                    cmd.Parameters.Add( "@receiveddate", SqlDbType.DateTime ).Value = _ReceivedDate_orig;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {
                            InitializeProperties();
                            if( !dr.IsDBNull( dr.GetOrdinal( "feetypeid" ) ) ) _intFeeTypeId = Convert.ToInt32( dr["feetypeid"] );
                            if( !dr.IsDBNull( dr.GetOrdinal( "receiveddate" ) ) ) _ReceivedDate = Convert.ToDateTime( dr["receiveddate"] ); 
                            if( !dr.IsDBNull( dr.GetOrdinal( "amount" ) ) ) _dblAmount = Convert.ToDouble( dr["amount"] );
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

            const string sql = "INSERT INTO FeePayment ( "
                + "planid, defendantid, feetypeid, receiveddate, amount, updatedby, updateddate "
                + ") VALUES ( "
                + "@planid, @id, @feetypeid, @receiveddate, @amount, @updatedby, @updateddate "
                + "); ";


            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId;
                cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;
                cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId;
                cmd.Parameters.Add( "@receiveddate", SqlDbType.DateTime ).Value = _ReceivedDate;
                cmd.Parameters.Add( "@amount", SqlDbType.Decimal ).Value = _dblAmount;

                base.Insert( cmd, updateDate );

            }

        }
        #endregion

        #region private void Update( SqlTransaction trx, DateTime updateDate )
        private void Update( SqlTransaction trx, DateTime updateDate )
        {

            const string sql = "UPDATE FeePayment SET "
                + "planid = @planid, "
                + "feetypeid = @feetypeid, "
                + "receiveddate = @receiveddate, "
                + "amount = @amount, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE defendantid = @id "
                + "AND planid = @planid_orig "
                + "AND feetypeid = @feetypeid_orig "
                + "AND receiveddate = @receiveddate_orig "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId;
                cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId;
                cmd.Parameters.Add( "@receiveddate", SqlDbType.DateTime ).Value = _ReceivedDate;
                cmd.Parameters.Add( "@amount", SqlDbType.Decimal ).Value = _dblAmount;
                cmd.Parameters.Add( "@planid_orig", SqlDbType.Int ).Value = _intPlanId_orig;
                cmd.Parameters.Add( "@feetypeid_orig", SqlDbType.Int ).Value = _intFeeTypeId_orig;
                cmd.Parameters.Add( "@receiveddate_orig", SqlDbType.DateTime ).Value = _ReceivedDate_orig;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );

            }

        }
        #endregion

        #region private void Delete( SqlTransaction trx )
        private void Delete( SqlTransaction trx )
        {

            const string sql = "DELETE FROM FeePayment "
                + "WHERE defendantid = @id "
                + "AND planid = @planid "
                + "AND feetypeid = @feetypeid "
                + "AND receiveddate = @receiveddate "
                + "AND updatedby = @updatedby "
                + "AND updateddate = @updateddate; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@planid", SqlDbType.Int ).Value = _intPlanId_orig;
                cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId_orig;
                cmd.Parameters.Add( "@receiveddate", SqlDbType.DateTime ).Value = _ReceivedDate;

                base.Delete( cmd );
            }

        }
        #endregion




        #region public void Save( SqlTransaction trx, DateTime updateDate )
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

        #region public FeePayment Clone()
        public FeePayment Clone()
        {

            FeePayment feepayment = new FeePayment( this.PlanId, this.ID, this.FeeTypeId, this.ReceivedDate, this.UpdatedBy, this.UpdatedDate );

            feepayment.RaiseChangedEvents = false;

            feepayment.Amount = this.Amount;
            feepayment.Save();

            feepayment.RaiseChangedEvents = true;

            return feepayment;

        }
        #endregion
        



        #region protected virtual void InitializeProperties()
        protected virtual void InitializeProperties()
        {

            _intPlanId_orig = _intPlanId = -1;

            if( Helper.FeeTypeList.Count > 0 )
                _intFeeTypeId_orig = _intFeeTypeId = Helper.FeeTypeList[0].ID;
            else
                _intFeeTypeId_orig = _intFeeTypeId = 0;
            
            _ReceivedDate_orig = _ReceivedDate = DateTime.Now;
            _dblAmount_orig = _dblAmount = 0;
        }
        #endregion

        #region protected virtual void SaveBackups()
        protected virtual void SaveBackups()
        {

            _intPlanId_orig = _intPlanId;
            _intFeeTypeId_orig = _intFeeTypeId;
            _ReceivedDate_orig = _ReceivedDate; 
            _dblAmount_orig = _dblAmount;

        } 
        #endregion

        #region protected virtual void RestoreBackups()
        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// After restoring the variables it resets the state of the object.
        /// </summary>
        protected virtual void RestoreBackups()
        {

            _intPlanId = _intPlanId_orig;
            _intFeeTypeId = _intFeeTypeId_orig;
            _ReceivedDate = _ReceivedDate_orig;
            _dblAmount = _dblAmount_orig;

        } 
        #endregion




        #region public static FeePayment CreateFeePayment( SqlDataReader dr, int planId, int defendantId, int feeTypeId )
        public static FeePayment CreateFeePayment( SqlDataReader dr, int planId, int defendantId, int feeTypeId )
        {

            FeePayment payment = null;

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                DateTime receivedDate = (DateTime)dr["receiveddate"];
                string updatedby = dr["updatedby"].ToString();
                DateTime? updateddate = (DateTime)dr["updateddate"];

                payment = new FeePayment( planId, defendantId, feeTypeId, receivedDate, updatedby, updateddate );

                payment.RaiseChangedEvents = false;

                if (!dr.IsDBNull( dr.GetOrdinal( "amount" ) )) payment.Amount = Convert.ToDouble( dr["amount"] );
                payment.Save();

                payment.RaiseChangedEvents = true;

            }

            return payment;
        }
        #endregion

        #region public static FeePayment UpdateFeePaymentIds( FeePayment feePayment, int planId, int defendantId, int feeTypeId )
        public static FeePayment UpdateFeePaymentIds( FeePayment feePayment, int planId, int defendantId, int feeTypeId )
        {

            FeePayment payment = null;

            // getting id that uniquely identifies the object               
            payment = new FeePayment( planId, defendantId, feeTypeId, feePayment.ReceivedDate, feePayment.UpdatedBy, feePayment.UpdatedDate );

            payment.RaiseChangedEvents = false;

            payment.Amount = feePayment.Amount;
            payment.Save();

            payment.MyState = feePayment.MyState;

            payment.RaiseChangedEvents = true;

            return payment;

        }
        #endregion

    



    }

}
