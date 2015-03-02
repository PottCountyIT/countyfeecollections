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
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace county.feecollections
{
 
    public class BaseObject : INotifyPropertyChanged, IRaiseItemChangedEvents
    {
        private MyObjectState _stateObject;
        private int _intID;
        private string _strUpdatedBy;
        private DateTime? _updatedDate;
        private bool _RaiseChangedEvents = true;

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged; 

        private void RaisePropertyChangedEvent( string propertyName )
        {
            if( PropertyChanged != null && _RaiseChangedEvents )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        } 

        /// <summary>
        /// Gets or sets the state of the object.  Setting the state of the object will raise the PropertyChanged event.
        /// </summary>
        public MyObjectState MyState
        {
            get { return _stateObject; }
            set
            {
                switch( value )
                {

                    case MyObjectState.New:
                        _stateObject = value;
                        RaisePropertyChangedEvent( this.GetType().ToString() );
                        break;

                    case MyObjectState.Current:
                        _stateObject = value;
                        RaisePropertyChangedEvent( this.GetType().ToString() );
                        break;

                    case MyObjectState.Modified:
                        if( !_stateObject.Equals( MyObjectState.New ) )
                        {
                            _stateObject = value;
                            RaisePropertyChangedEvent( this.GetType().ToString() );
                        }
                        break;

                    case MyObjectState.Removed:
                        _stateObject = value;
                        RaisePropertyChangedEvent( this.GetType().ToString() );
                        break;

                }

            }
        }

        /// <summary>
        /// Gets the Id of the base object; typically the, or part of the inheriting object's primary key.
        /// </summary>
        public int ID
        {
            get { return _intID; }
        }

        /// <summary>
        /// Gets the name used to audit db operations.  (It's also critical for db concurrency.)
        /// </summary>
        public string UpdatedBy
        {
            get { return _strUpdatedBy; }
        }

        /// <summary>
        /// Gets the date used to audit db operations.  (It's also critical for db concurrency.)
        /// </summary>
        public DateTime? UpdatedDate
        {
            get { return _updatedDate; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the PropertyChanged event is raised.
        /// </summary>
        public bool RaiseChangedEvents
        {
            get { return _RaiseChangedEvents; }
            set { _RaiseChangedEvents = value; }
        }

        bool IRaiseItemChangedEvents.RaisesItemChangedEvents
        {
            get { return true; }
        }

        public BaseObject()
        {
            InitializeProperties( MyObjectState.New );
        } 

        public BaseObject( int id )
        {
            InitializeProperties( MyObjectState.New );
            _intID = id;
        }

        public BaseObject( int id, string updatedBy, DateTime? updatedDate )
        {
            _intID = id;
            _strUpdatedBy = updatedBy;
            _updatedDate = updatedDate;
            _stateObject = MyObjectState.Current;
        }

        protected void Insert( SqlCommand cmd, DateTime updateDate )
        {

            cmd.CommandText += "SET @ident = SCOPE_IDENTITY(); ";

            cmd.Parameters.Add( "@updatedby", SqlDbType.VarChar ).Value = LocalUser.WindowsUserName;
            cmd.Parameters.Add( "@updateddate", SqlDbType.DateTime ).Value = updateDate;

            SqlParameter paramId = new SqlParameter( "@ident", SqlDbType.Int );
            paramId.Direction = ParameterDirection.Output;
            cmd.Parameters.Add( paramId );

            if( DBSettings.ExecuteNonQuery( this.GetType().Name, cmd ) > 0 )
            {
                if( !DBNull.Value.Equals( paramId.Value ) )
                    _intID = (int)paramId.Value;
            }
            else
            {
                throw new ArgumentNullException( this.GetType().Name + "Id", "The insert failed to return a unique identifier for the " + this.GetType().Name );
            }

        }

        /// <summary>
        /// This function executes the cmd paramenter by using ExecuteNonQuery.  In addition,
        /// this fuction sets the following SqlParameters:
        /// 
        /// @id - base object id
        /// @updatedby - Current windows username
        /// @updateddate - the update parameter
        /// 
        /// throws a MyErrorType.ConCurrentcyObjectUpdate exception if the update
        /// doesn't return a value > 0.
        /// </summary>
        /// <param name="cmd">A SqlCommand object with update statement.  (function will update @id, @updatedby, and @updateddate paramenters.)</param>
        /// <param name="updateDate">The date the @updateddate parameter should be updated to in the database</param>
        protected void Update( SqlCommand cmd, DateTime updateDate )
        {
            cmd.Parameters.Add( "@id", SqlDbType.Int).Value = _intID;
            cmd.Parameters.Add( "@updatedby", SqlDbType.VarChar ).Value = LocalUser.WindowsUserName;
            cmd.Parameters.Add( "@updateddate", SqlDbType.DateTime ).Value = updateDate;

            if (DBSettings.ExecuteNonQuery(this.GetType().Name, cmd) <= 0)
            {
                throw new MyException(this.GetType().Name, MyErrorType.ConcurrencyObjectUpdate, new Exception());
            }
        }

        protected void Delete( SqlCommand cmd )
        {
            cmd.Parameters.Add( "@id", SqlDbType.Int ).Value = _intID;
            cmd.Parameters.Add( "@updatedby", SqlDbType.VarChar ).Value = _strUpdatedBy;
            cmd.Parameters.Add( "@updateddate", SqlDbType.DateTime ).Value = _updatedDate;

            if( !(DBSettings.ExecuteNonQuery( this.GetType().Name, cmd ) > 0) )
            {
                throw new MyException( this.GetType().Name, MyErrorType.ConcurrencyObjectUpdate, new Exception() );
            }
        }

        /// <summary>
        /// Restores the state of the object to it's last last saved state by 
        /// reseting the MyState object.  
        /// </summary>
        protected void RestoreState()
        {

            switch( this.MyState )
            {

                case MyObjectState.New:
                    this.MyState = MyObjectState.New;
                    break;

                case MyObjectState.Modified:
                case MyObjectState.Current:
                case MyObjectState.Removed:
                    this.MyState = MyObjectState.Current;
                    break;
            }

        } 

        private void InitializeProperties( MyObjectState startState )
        {
            _intID = -1;
            _strUpdatedBy = "";
            _updatedDate = null;

            // initialize the state of the object without firing any change events.
            _stateObject = startState;

        }

        public void SetNewUpdateProperties( string updatedBy, DateTime updatedDate )
        {

            _strUpdatedBy = updatedBy;
            _updatedDate = updatedDate;

        } 

        public virtual void Remove( bool updateDatabase )
        {

            this.MyState = MyObjectState.Removed;

        }

        public virtual void Reset()
        {
            RestoreState();
        } 

        /// <summary>
        /// Refreshes all object values from the db.
        /// </summary>
        public virtual void Refresh()
        {

            this.MyState = MyObjectState.Current;

        }
    }
}
