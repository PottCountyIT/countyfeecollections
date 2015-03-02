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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace county.feecollections
{
    public partial class frmPlanNew : Form
    {


        #region MyRegionpublic string PlanName
        public string PlanName
        {
            get { return txtPlanName.Text.Trim(); }
            set { txtPlanName.Text = value; }
        } 
        #endregion

        #region public frmPlanNew()
        public frmPlanNew()
        {
            InitializeComponent();
        } 
        #endregion

        #region public frmPlanNew( int planCount )
        public frmPlanNew( int planCount )
        {
            InitializeComponent();
            lblMsg.Text = string.Format( lblMsg.Text, planCount.ToString() );
        }
        #endregion



    }
}
