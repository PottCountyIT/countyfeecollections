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

    public class PlanFee : BaseObject
    {

        
        // public property backing variables
        private int _intDefendantId;
        private int _intFeeTypeId;
        private double _dblAmount;
        private FeeType _FeeType;

        // public property backing objects
        private FeePayments _Payments;


        // property backup variables
        private int _intFeeTypeId_orig;
        private double _dblAmount_orig;
        private FeePayments _Payments_orig;


        #region public bool HasChanged
        public bool HasChanged
        {
            get
            {

                if( _intFeeTypeId_orig == _intFeeTypeId
                    && _dblAmount_orig == _dblAmount )
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

        #region public int FeeTypeId
        public int FeeTypeId
        {
            get { return _intFeeTypeId; }
            set 
            {
                if( !_intFeeTypeId.Equals( value ) )
                {
                    _intFeeTypeId = value;

                    _FeeType = Helper.FeeTypeList[Helper.FeeTypeList.Find( "ID", _intFeeTypeId )];

                    base.MyState = MyObjectState.Modified;
                }
            }

        }
        #endregion

        #region public string FeeTypeName
        public string FeeTypeName
        {
            get { return _FeeType.FeeTypeName; }
        }
        #endregion

        #region public bool Billable
        public bool Billable
        {
            get { return _FeeType.Billable; }
        }
        #endregion
        
        #region public int PaymentOrder
        public int PaymentOrder
        {
            get { return _FeeType.PaymentOrder; }
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

        #region public double Balance
        public double Balance
        {
            get 
            {

                if( this.Payments != null )
                {
                    double paid = 0;
                    foreach( FeePayment payment in this.Payments )
                    {
                        if( payment.FeeTypeId == _intFeeTypeId )
                            paid += payment.Amount;
                    }

                    return _dblAmount - paid;

                }
                else
                {
                    return _dblAmount; 
                }
            }
        }
        #endregion
        



        #region public FeePayments Payments
        public FeePayments Payments
        {

            get
            {
                //	Don't create object until explicitly accessed:
                if( _Payments == null )
                {
                    _Payments = new FeePayments( ID, _intDefendantId, _intFeeTypeId_orig );
                    _Payments.ListChanged += new ListChangedEventHandler( child_Changed );
                }
                return _Payments;
            }

            set
            {
                if( value != null && (( _Payments == null ) || (_Payments != null && !_Payments.Equals( value ) ) ) )
                {
                    _Payments = value.Clone();
                }
            }

        }
        #endregion



                
        #region public PlanFee() : base ()
        public PlanFee() : base ()
        {

            throw new NotImplementedException( "A plan fee object requires a plan and defendant id." );

        }
        #endregion

        #region public PlanFee( int planId, int defendantId ): base( planId )
        public PlanFee( int planId, int defendantId ) : base( planId )
        {

            _intDefendantId = defendantId;
            InitializeProperties();

        } 
        #endregion

        #region public PlanFee( int planId, int defendantId, int feeTypeId, string updatedBy, DateTime? updatedDate ) : base( planId, updatedBy, updatedDate )
        public PlanFee( int planId, int defendantId, int feeTypeId, string updatedBy, DateTime? updatedDate ) : base( planId, updatedBy, updatedDate )
        {
            
            
            InitializeProperties();
            _intDefendantId = defendantId;
            FeeTypeId = feeTypeId;

        }
        #endregion



        
        #region private void Select()
        private void Select()
        {

            if( base.ID > 0 )
            {

                const string sql = "SELECT feetypeid, amount, updatedby, updateddate "
                    + "FROM PlanFee "
                    + "WHERE planid = @id "
                    + "AND defendantid = @defendantid "
                    + "AND feetypeid = @feetypeid; ";


                using( SqlCommand cmd = new SqlCommand( sql ) )
                {

                    cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID; 
                    cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                    cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId_orig;

                    using( SqlDataReader dr = DBSettings.ExecuteReader( this.GetType().Name, cmd ) )
                    {

                        if( dr.Read() )
                        {
                            InitializeProperties();
                            if (!dr.IsDBNull( dr.GetOrdinal( "feetypeid" ) )) _intFeeTypeId = Convert.ToInt32( dr["feetypeid"] );
                            if (!dr.IsDBNull( dr.GetOrdinal( "amount" ) )) _dblAmount = Convert.ToDouble( dr["amount"] ); 
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

            const string sql = "INSERT INTO PlanFee ( "
                + "planid, defendantid, feetypeid, amount, updatedby, updateddate "
                + ") VALUES ( "
                + "@id, @defendantid, @feetypeid, @amount, @updatedby, @updateddate "
                + "); ";


            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = base.ID;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId;
                cmd.Parameters.Add( "@amount", SqlDbType.Decimal ).Value = _dblAmount;

                base.Insert( cmd, updateDate );

            }

        }
        #endregion

        #region private void Update( SqlTransaction trx, DateTime updateDate )
        private void Update( SqlTransaction trx, DateTime updateDate )
        {

            const string sql = "UPDATE PlanFee SET "
                + "feetypeid = @feetypeid, "
                + "amount = @amount, "
                + "updatedby = @updatedby, "
                + "updateddate = @updateddate "
                + "WHERE planid = @id "
                + "AND defendantid = @defendantid "
                + "AND feetypeid = @feetypeid_orig "
                + "AND updatedby = @updatedby_orig "
                + "AND updateddate = @updateddate_orig; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId;
                cmd.Parameters.Add( "@amount", SqlDbType.Decimal ).Value = _dblAmount;
                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@feetypeid_orig", SqlDbType.Int ).Value = _intFeeTypeId_orig;
                cmd.Parameters.Add( "@updatedby_orig", SqlDbType.VarChar ).Value = base.UpdatedBy;
                cmd.Parameters.Add( "@updateddate_orig", SqlDbType.DateTime ).Value = base.UpdatedDate;

                base.Update( cmd, updateDate );

            }

        }
        #endregion

        #region private void Delete( SqlTransaction trx )
        private void Delete( SqlTransaction trx )
        {

            const string sql = "DELETE FROM PlanFee "
                + "WHERE planid = @id "
                + "AND defendantid = @defendantid "
                + "AND feetypeid = @feetypeid "
                + "AND updatedby = @updatedby "
                + "AND updateddate = @updateddate; ";

            using( SqlCommand cmd = new SqlCommand( sql, trx.Connection, trx ) )
            {

                cmd.Parameters.Add( "@defendantid", SqlDbType.Int ).Value = _intDefendantId;
                cmd.Parameters.Add( "@feetypeid", SqlDbType.Int ).Value = _intFeeTypeId_orig;

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

                    if( _Payments != null )
                    {
                        // need to update planid, and feetypeid here.
                        _Payments.ParentId = this.ID;
                        _Payments.FeeTypeId = this.FeeTypeId;
                    }
                    break;

                case MyObjectState.Modified:
                    
                    if( HasChanged )
                        Update( trx, updateDate );

                    if( _Payments != null )
                    {
                        _Payments.SaveFeePayments( trx );
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

        #region public PlanFee Clone()
        public PlanFee Clone()
        {

            PlanFee planfee = new PlanFee( this.ID, this.DefendantId, this.FeeTypeId, this.UpdatedBy, this.UpdatedDate );

            planfee.RaiseChangedEvents = false;

            planfee.Amount = this.Amount;

            // cloning object collections
            planfee.Payments = (_Payments == null) ? null : _Payments.Clone();

            planfee.Save();

            planfee.RaiseChangedEvents = true;

            return planfee;

        }
        #endregion
        



        #region protected virtual void InitializeProperties()
        protected virtual void InitializeProperties()
        {
            
            if( Helper.FeeTypeList.Count > 0 )
                _intFeeTypeId_orig = FeeTypeId = Helper.FeeTypeList[0].ID;
            else
                _intFeeTypeId_orig = _intFeeTypeId = 0;

            _dblAmount_orig = _dblAmount = 0;

            _Payments_orig = null;
            _Payments = null;


        }
        #endregion

        #region protected virtual void SaveBackups()
        protected virtual void SaveBackups()
        {

            _intFeeTypeId_orig = _intFeeTypeId;
            _dblAmount_orig = _dblAmount;

            _Payments_orig = (_Payments == null) ? null : _Payments.Clone();

        } 
        #endregion

        #region protected virtual void RestoreBackups()
        /// <summary>
        /// Restores all of the properties to their last saved state.  
        /// After restoring the variables it resets the state of the object.
        /// </summary>
        protected virtual void RestoreBackups()
        {

            FeeTypeId = _intFeeTypeId_orig;
            _dblAmount = _dblAmount_orig;

            _Payments = (_Payments_orig == null) ? null : _Payments_orig.Clone();

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




        #region public static PlanFee CreateFee( SqlDataReader dr, int planId, int defendantId )
        public static PlanFee CreateFee( SqlDataReader dr, int planId, int defendantId )
        {

            PlanFee tmpfee = null;

            if( !dr.IsClosed && dr.HasRows )
            {

                // getting id that uniquely identifies the object
                int feeTypeId = Convert.ToInt32( dr["feetypeid"] );
                string updatedby = dr["updatedby"].ToString();
                DateTime? updateddate = (DateTime)dr["updateddate"];

                tmpfee = new PlanFee( planId, defendantId, feeTypeId, updatedby, updateddate );

                tmpfee.RaiseChangedEvents = false;

                tmpfee.Amount = (!dr.IsDBNull( dr.GetOrdinal( "amount" ) )) ? Convert.ToDouble( dr["amount"] ) : 0; 
                tmpfee.Save();

                tmpfee.RaiseChangedEvents = true;

            }

            return tmpfee;
        }
        #endregion

        #region public static PlanFee UpdateFeeIds( PlanFee planFee, int planId, int defendantId )
        public static PlanFee UpdateFeeIds( PlanFee planFee, int planId, int defendantId )
        {

            PlanFee tmpfee = null;

            // getting id that uniquely identifies the object               
            tmpfee = new PlanFee( planId, defendantId, planFee.FeeTypeId, planFee.UpdatedBy, planFee.UpdatedDate );

            tmpfee.RaiseChangedEvents = false;

            tmpfee.Amount = planFee.Amount;
            tmpfee.Save();

            tmpfee.MyState = planFee.MyState;

            tmpfee.RaiseChangedEvents = true;

            return tmpfee;

        }
        #endregion

    



    }

}
