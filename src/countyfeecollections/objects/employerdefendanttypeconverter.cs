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
using System.ComponentModel;
using System.Globalization;
using System.Drawing;

namespace county.feecollections
{

    class EmployerDefendantTypeConverter : TypeConverter
    {


        #region public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType )
        public override bool CanConvertFrom( ITypeDescriptorContext context, Type sourceType )
        {

            if( sourceType == typeof( string ) )
            {
                return true;
            }

            return base.CanConvertFrom( context, sourceType );

        } 
        #endregion


        #region public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value )
        public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value )
        {

            if( value is string )
            {
                Employer emp = new Employer();
                emp.EmployerName = value.ToString();

                return emp;
            }

            return base.ConvertFrom( context, culture, value );
        }
        
        #endregion


    }
}
