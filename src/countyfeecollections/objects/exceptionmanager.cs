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
using System.Security.Principal;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;


namespace county.feecollections
{

	public class MyExceptionManager
    {
        /// <summary>
        /// 
        /// This method is the event handler for any unhandled exceptions in the application.
        /// If it catches any of these errors, it will display the error, log it, and then exit.
        /// It is hooked in Main.
        /// 
        /// </summary>
        /// <param name="sender" type="object">not used.</param>
        /// <param name="t" type="ThreadExceptionEventArgs">the exception thrown.</param>
        public static void HandleApplicationException( object sender, ThreadExceptionEventArgs t )
        {

            try
            {
                
                frmError frm = new frmError( MyExceptionManager.Log( t.Exception ) );

                if( frm.ShowDialog() == DialogResult.Cancel )
                {
                    Environment.Exit( 0 );
                }

            }
            catch
            {
                try
                {
                    MyMessageBox.Show( null, "Fatal Error", MyDisplayMessage.FatalError );
                }
                finally
                {
                    Environment.Exit(0);
                }
            }

        }        
		
		/// <summary>
		/// 
		/// This method logs a message based on the Exception object read in.
		/// If compiling in debug mode, this method will just display a message.
		/// 
		/// </summary>
		/// <param name="ex" type="Exception">The exception object to be logged.</param>
		public static string Log( Exception ex )
		{

            string strMsg = ExtractExceptionInfo( ex );

            #if !DEBUG 
                EventLog.WriteEntry( Application.ProductName, strMsg, EventLogEntryType.Error );
            #else
                frmError frm = new frmError( "IN RELEASE MODE THIS WOULD BE LOGGED TO THE EVENT VIEWER" + Environment.NewLine + Environment.NewLine + strMsg );
                frm.ShowInTaskbar = true;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            #endif

            return strMsg;

		}

        /// <summary>
		/// 
		/// This method builds an error string with application, machine, process,
        /// and exception information based on the exception read in.  
		/// 
		/// </summary>
		/// <param name="ex" type="Exception">The exception to gather information from.</param>
		/// <returns type="string">A string with application, machine, process, and exception information.</returns>
		private static string ExtractExceptionInfo( Exception ex )
		{
			string str = "";
	
            try 
            {

           		Process proc = System.Diagnostics.Process.GetCurrentProcess();

                str = Application.CompanyName + " " + Application.ProductName + " Error Information" + Environment.NewLine + Environment.NewLine
                    + "Event Message:  " + ex.Message + Environment.NewLine
                    + "Event Time:  " + DateTime.Now.ToString() + Environment.NewLine + Environment.NewLine

                    + "APPLICATION INFORMATION" + Environment.NewLine
                    + "Path:  " + Application.ExecutablePath + Environment.NewLine
                    + "Startup Path:  " + Application.StartupPath + Environment.NewLine
                    + "Version:  " + Application.ProductVersion + Environment.NewLine + Environment.NewLine

                    + "MACHINE INFORMATION" + Environment.NewLine
                    + "Machine Name:  " + Environment.MachineName + Environment.NewLine
                    + ".NET CLR Version:  " + Environment.Version + Environment.NewLine
                    + "Domain UserName:  " + Environment.UserDomainName + Environment.NewLine
                    + "Windows UserName:  " + Environment.UserName + Environment.NewLine + Environment.NewLine

                    + "PROCESS INFORMATION" + Environment.NewLine
                    + "Process ID:  " + proc.Id + Environment.NewLine
                    + "Process Name:  " + proc.ProcessName + Environment.NewLine + Environment.NewLine

                    + "EXCEPTION INFORMATION" + Environment.NewLine
                    + "Type:  " + ex.GetType().ToString() + Environment.NewLine
                    + "Message:  " + ex.Message + Environment.NewLine
                    + "Source:  " + ex.Source + Environment.NewLine;
                    if( ex.InnerException != null )
                    {
                        str += "Inner Exception Message:  " + ex.InnerException.Message + Environment.NewLine
                            + "Inner Exception Source:  " + ex.InnerException.Source + Environment.NewLine;
                    }
                    str += "Stack Trace:" + Environment.NewLine + ex.StackTrace + Environment.NewLine;

			}
            catch
            {

				str = "Error retreiving error information." + Environment.NewLine;

			}

			return str;

		}
	} // end public class ExceptionManager
}
