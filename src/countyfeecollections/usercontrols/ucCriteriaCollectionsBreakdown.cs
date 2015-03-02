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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace county.feecollections
{
    public partial class ucCriteriaCollectionsBreakdown : UserControl
    {



        #region public DateTime FromDate
        public DateTime FromDate
        {
            get { return DateTime.Parse( dtpFrom.Value.ToShortDateString() ); }


        } 
        #endregion

        #region public DateTime ToDate
        public DateTime ToDate
        {
            get { return DateTime.Parse( dtpTo.Value.ToShortDateString() ).AddDays( 1 ).AddTicks( -1 ); }
        } 
        #endregion


        #region public ucCriteriaCollectionsBreakdown()
        public ucCriteriaCollectionsBreakdown()
        {
            InitializeComponent();
        } 
        #endregion


    }
}
