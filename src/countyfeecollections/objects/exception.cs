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


namespace county.feecollections
{

    public enum MyErrorType : int
    {
        ConcurrencyObjectDelete = 547,      // number matches sql server 2005 error number
        ConcurrencyObjectUpdate = 100,
        ConcurrencyObjectNotExists = 120,
        ConcurrencyRelationshipUpdate = 200,
        ConcurrencyCollectionUpdate = 300,
        ConcurrencyCollectionInsert = 310,
        ConcurrencyCollectionDelete = 320,
        DatabaseObjectMissing = 208,        // number matches sql server 2005 error number
        DatabaseNoConnection = 2,           // number matches sql server 2005 error number
        DatabaseNoConnection1 = 53,         // number matches sql server 2005 error number
        DatabaseConnectionLost = 233,       // number matches sql server 2005 error number
        ConstraintUnique = 2627,            // number matches sql server 2005 error number
        MailMergeError = 4000,
        Unhandled = 700
    };


    public class MyException : Exception
    {

        private MyErrorType _typError;


        #region public MyErrorType ErrorType
        public MyErrorType ErrorType
        {
            get { return _typError; }
        } 
        #endregion

        #region public override string Message
        public override string Message
        {
            get
            {
                string str = "";

                switch( _typError )
                {
                    case MyErrorType.ConcurrencyObjectUpdate:
                        str = string.Format( "The {0} has been updated by another user.", base.Message );
                        break;

                    case MyErrorType.ConcurrencyObjectDelete:
                        str = string.Format( "The {0} is associated to an object that is preventing it from being removed.", base.Message );
                        break;

                    case MyErrorType.ConcurrencyObjectNotExists:
                        str = string.Format( "The {0} no longer exists in the database.", base.Message );
                        break;

                    case MyErrorType.ConcurrencyCollectionUpdate:
                        str = string.Format( "The collection of {0} has been updated by another user.", base.Message );
                        break;

                    case MyErrorType.ConcurrencyRelationshipUpdate:
                        str = string.Format( "The {0} relationship has been updated by another user.", base.Message );
                        break;

                    case MyErrorType.ConcurrencyCollectionInsert:
                        str = string.Format( "No {0} relationships where successfully made.", base.Message );
                        break;

                    case MyErrorType.ConcurrencyCollectionDelete:
                        str = string.Format( "Unable to remove {0} relationships.", base.Message );
                        break;

                    case MyErrorType.DatabaseObjectMissing:
                        str = string.Format( "An object named '{0}' is missing in the database.  This is a potential fatal error in the application.\n\n"
                            + "If you are seeing this, please contact your IT department to correct it.  A detailed error message will be logged in the Windows Event Viewer.", base.Message );
                        break;

                    case MyErrorType.DatabaseConnectionLost:
                        str = "The database server has lost its connection.  This is a potential fatal error in the application.\n\n"
                            + "If you are seeing this, please contact your IT department to correct it.  A detailed error message will be logged in the Windows Event Viewer.";
                        break;

                    case MyErrorType.DatabaseNoConnection:
                    case MyErrorType.DatabaseNoConnection1:
                        str = "The database server was not found or is not accessible.  This is a potential fatal error in the application.\n\n"
                            + "If you are seeing this, please contact your IT department to correct it.  A detailed error message will be logged in the Windows Event Viewer.";
                        break;

                    case MyErrorType.ConstraintUnique:
                        str = string.Format( "Cannot insert duplicate {0}.", base.Message );      
                        break;

                    case MyErrorType.Unhandled:
                        str = string.Format( "The {0} ran into an unhandled error.  This is a potential fatal error in the application.\n\n"
                            + "If you are seeing this, please contact your IT department to correct it.  A detailed error message will be "
                            + "logged in the Windows Event Viewer.", base.Message );
                        break;
                }

                return str;
            }
        } 
        #endregion

        #region public override string Source
        public override string Source
        {
            get
            {
                return base.InnerException.Source;
            }
        }
        #endregion

        #region public override string StackTrace
        public override string StackTrace
        {
            get
            {
                return base.InnerException.StackTrace;
            }
        }
        #endregion

        #region public MyException() : base()
        public MyException() : base()
        {

        } 
        #endregion

        #region public MyException( string message, Exception innerException ) : base( message, innerException )
        public MyException( string message, Exception innerException ) : base( message, innerException )
        {

            _typError = MyErrorType.Unhandled;


        } 
        #endregion
        
        #region public MyException( string message, MyErrorType errorType, Exception exception  ) : base( message, exception )
        public MyException( string message, MyErrorType errorType, Exception exception  ) : base( message, exception )
        {

            _typError = errorType;

        }
        #endregion

        #region public MyException( string message, SqlException sqlException ): base( message, sqlException )
        public MyException( string message, SqlException sqlException ): base( message, sqlException )
        {

            switch( sqlException.Number )
            {

                case (int)MyErrorType.ConcurrencyObjectDelete:
                    _typError = MyErrorType.ConcurrencyObjectDelete;
                    break;

                case (int)MyErrorType.DatabaseObjectMissing:
                    _typError = MyErrorType.DatabaseObjectMissing;
                    MyExceptionManager.Log( this );
                    break;

                case (int)MyErrorType.DatabaseNoConnection:
                case (int)MyErrorType.DatabaseNoConnection1:
                    _typError = MyErrorType.DatabaseNoConnection;
                    MyExceptionManager.Log( this );
                    break;

                case (int)MyErrorType.DatabaseConnectionLost:
                    _typError = MyErrorType.DatabaseConnectionLost;
                    MyExceptionManager.Log( this );
                    break;

                case (int)MyErrorType.ConstraintUnique:
                    _typError = MyErrorType.ConstraintUnique;
                    break;

                default:
                    _typError = MyErrorType.Unhandled;
                    MyExceptionManager.Log( this );
                    break;

            }
        }
        #endregion



    }

}
