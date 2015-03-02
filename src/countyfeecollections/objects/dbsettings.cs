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


    public class DBSettings
    {
        private bool _isDirty;

        public bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        public string UserName
        {
            get { return Properties.Settings.Default.DBUsername; }
            set 
            {
                if( !Properties.Settings.Default.DBUsername.Equals( value ) )
                {
                    Properties.Settings.Default.DBUsername = value;
                    _isDirty = true;
                }
            }
        }

        public string Password
        {
            get { return Properties.Settings.Default.DBPassword; }
            set 
            {
                if( !Properties.Settings.Default.DBPassword.Equals( value ) )
                {
                    Properties.Settings.Default.DBPassword = value;
                    _isDirty = true;
                }
            }
        }

        public string ServerName
        {
            get { return Properties.Settings.Default.DBServerName; }
            set 
            {
                if( !Properties.Settings.Default.DBServerName.Equals( value ) )
                {
                    Properties.Settings.Default.DBServerName = value;
                    _isDirty = true;
                }
            }
        }

        public string DatabaseName
        {
            get { return Properties.Settings.Default.DBName; }
            set 
            {
                if( !Properties.Settings.Default.DBName.Equals( value ) )
                {
                    Properties.Settings.Default.DBName = value;
                    _isDirty = true;
                }
            }
        }

        public bool UseIntegratedSecurity
        {
            get { return Properties.Settings.Default.DBIntegratedSecurity; }
            set 
            {
                if( !Properties.Settings.Default.DBIntegratedSecurity.Equals( value ) )
                {
                    Properties.Settings.Default.DBIntegratedSecurity = value;
                    _isDirty = true;
                }
            }
        }

        public string ConnectionString
        {
            get 
            { 
                if( ServerName.Length > 0 && DatabaseName.Length > 0 )
                    return buildConnectionString( ServerName, DatabaseName, UserName, Password, UseIntegratedSecurity ); 
                else
                    return "";
            }
        } 

        public DBSettings()
        {

        } 

        public DBSettings( string server, string database, string username, string password, bool integratedsecurity )
        {
            ServerName = server;
            DatabaseName = database;
            UserName = username;
            Password = password;
            UseIntegratedSecurity = integratedsecurity;
        }

        public void SaveSettings()
        {
            if( _isDirty )
            {
                Properties.Settings.Default.Save();
                _isDirty = false;
            }

        }

        /// <summary>
        /// Creates a connection string based on exisiting class variables.
        /// </summary>
        /// <returns>A fully qualified sql connection string</returns>
        private static string buildConnectionString( string server, string database, string username, string password, bool integratedsecurity )
        {

            string strConn = "Data Source=" + server + ";Initial Catalog=" + database + ";";

            if( integratedsecurity )
            {
                strConn += "Integrated Security=SSPI;";
            }
            else
            {
                strConn += "User ID=" + username + ";Password=" + password + ";";
            }
            strConn += "Connection Timeout=2";

            return strConn;

        }
        
        public static bool TestConnection( string server, string database, string username, string password, bool integratedsecurity )
        {
            return TestConnection( buildConnectionString( server, database, username, password, integratedsecurity ) );
        }

        public static bool TestConnection( string connectionString )
        {
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentException("Connection string is null or empty.", "connectionString");
            }

            using( SqlConnection con = new SqlConnection( connectionString ) )
            {
                try
                {
                    con.Open();
                    con.Close();
                    return true;
                }
                catch//( SqlException sqlex )
                {
                    return false;
                    //throw new MyException( "Database Error", sqlex );
                }
            }
        }

        public static bool TestConnection()
        {
            return TestConnection(LocalUser.DatabaseSettings.ConnectionString);
        }
        
        public static SqlConnection NewSqlConnectionClosed
        {
            get 
            {
                if( string.IsNullOrEmpty( LocalUser.DatabaseSettings.ConnectionString ) )
                {
                    throw new ArgumentNullException( "ConnectionString", "The Connection string is not configured." );
                }

                return new SqlConnection( LocalUser.DatabaseSettings.ConnectionString );
            }
        } 

        public static SqlConnection NewSqlConnectionOpen
        {
            get
            {
                SqlConnection con = DBSettings.NewSqlConnectionClosed;
                try
                {
                    con.Open();
                    return con;
                }
                catch( SqlException sqlex )
                {
                    throw new MyException( "Database Error", sqlex );
                }                      
            }
        }

        public static SqlTransaction NewSqlTransaction( string name, SqlConnection connection )
        {   
            try
            {
                return connection.BeginTransaction( IsolationLevel.RepeatableRead, name );
            }
            catch( SqlException sqlex )
            {
                throw new MyException( name, sqlex );
            }
        }

        public static int ExecuteNonQuery( string name, SqlCommand command )
        {
            try
            {
                return command.ExecuteNonQuery();
            }
            catch( SqlException sqlex )
            {
                throw new MyException( name, sqlex );
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name">the name of the calling object.</param>
        /// <param name="command">The Sql command object to execute.</param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader( string name, SqlCommand command )
        {
            command.Connection = DBSettings.NewSqlConnectionClosed;
            try
            {
                command.Connection.Open();
                return command.ExecuteReader( CommandBehavior.CloseConnection );
            }
            catch( SqlException sqlex )
            {
                throw new MyException( name, sqlex );
            }
        }

        public static DataTable ExecuteDataAdapter( string name, SqlCommand cmd  )
        {
            DataTable dt = new DataTable();
                        
            using( SqlDataAdapter da = new SqlDataAdapter( cmd ) )
            {
                da.AcceptChangesDuringFill = true;
                try
                {
                    da.Fill( dt );
                }
                catch( SqlException sqlex )
                {
                    throw new MyException( name, sqlex );
                }
            }

            return dt;
        }

        public static DataSet ExecuteDataAdapter( string name, string sql )
        {
            DataSet ds = new DataSet();

            using( SqlConnection con = DBSettings.NewSqlConnectionOpen )
            using( SqlDataAdapter da = new SqlDataAdapter( sql, con ) )
            {
                da.AcceptChangesDuringFill = true;
                try
                {
                    da.Fill( ds );
                }
                catch( SqlException sqlex )
                {
                    throw new MyException( name, sqlex );
                }
            }

            return ds;
        }
    }
}
