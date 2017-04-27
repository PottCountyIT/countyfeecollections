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
using System.Security.Principal;

namespace county.feecollections
{

    public class LocalUser
    {

        private static DBSettings _DBSettings;
        private bool _isDirty;
        
        public bool IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }

        #region public string MailMergeDirectory
        public string MailMergeDirectory
        {
            get { return Properties.Settings.Default.MailMergeDirectory; }
            set
            {
                Properties.Settings.Default.MailMergeDirectory = value;
                _isDirty = true;
            }
        } 
        #endregion

        #region public bool LenientBilling
        public bool LenientBilling
        {
            get { return Properties.Settings.Default.LenientBilling; }
            set
            {
                Properties.Settings.Default.LenientBilling = value;
                _isDirty = true;
            }
        }
        #endregion

        #region public bool JailMode
        public bool JailMode
        {
            get { return Properties.Settings.Default.JailMode; }
            set
            {
                Properties.Settings.Default.JailMode = value;
                _isDirty = true;
            }
        }
        #endregion

        #region public int HomeCountyId
        public int HomeCountyId
        {
            get { return Properties.Settings.Default.HomeCounty; }
            set
            {
                Properties.Settings.Default.HomeCounty = value;
                _isDirty = true;
            }
        } 
        #endregion

        #region public string HomeCountyName
        public string HomeCountyName
        {
            get { return Properties.Settings.Default.HomeCountyName; }
            set
            {
                Properties.Settings.Default.HomeCountyName = value;
                _isDirty = true;
            }
        }  
        #endregion



        #region public static string WindowsUserName
        /// <summary>
        /// Gets the user's Windows logon name.
        /// </summary>
        public static string WindowsUserName
        {
            get { return WindowsIdentity.GetCurrent().Name; }
        }

        public static DBSettings DatabaseSettings
        {
            get
            {
                //	Don't create object until explicitly accessed
                if( _DBSettings == null )
                {
                    _DBSettings = new DBSettings();
                }
                return _DBSettings;

            }
        } 
        #endregion

        #region public LocalUser()
        public LocalUser()
        {

        }  
        #endregion

        public void SaveSettings()
        {
            if( _isDirty )
            {

                Properties.Settings.Default.Save();
                _isDirty = false;

            }

        }
    } 

} 
