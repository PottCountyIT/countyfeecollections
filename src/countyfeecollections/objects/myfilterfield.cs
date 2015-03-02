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

namespace county.feecollections
{

    public class MyFilterField
    {
        private string _strFieldValue;
        private string _strFieldName;
        private Type _typFieldType;

        #region public MyFilterField()
        public MyFilterField()
        {

            _strFieldValue = "";
            _strFieldName = "";
            _typFieldType = null;
        } 
        #endregion


        #region public string FieldValue
        public string FieldValue
        {
            get { return _strFieldValue; }
            set { _strFieldValue = value; }
        }
        #endregion

        #region public string FieldName
        public string FieldName
        {
            get { return _strFieldName; }
            set { _strFieldName = value; }
        }
        #endregion

        #region public Type FieldType
        public Type FieldType
        {
            get { return _typFieldType; }
            set { _typFieldType = value; }
        }
        #endregion


    }
}
