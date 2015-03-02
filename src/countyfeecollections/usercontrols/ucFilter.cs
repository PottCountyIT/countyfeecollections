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
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;


namespace county.feecollections
{


    public partial class ucFilter : UserControl
    {

        private bool _alreadyFocused;
        private List<MyFilterField>  _lstFilters;




        #region public delegate void FilterValueChanged( object sender, string filterString );
        public delegate void FilterValueChanged( object sender, string filterString ); 
        #endregion

        #region public event FilterValueChanged OnFilterChanged;
        public event FilterValueChanged OnFilterChanged; 
        #endregion

        #region public string FilterString
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public string FilterString
        {
            get { return BuildFilterString(); }
        } 
        #endregion

        #region public string FilterValue
        /// <summary>
        /// Current value to look for.  (Setting this property will not fire the TextChanged event handler.)
        /// </summary>
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public string FilterValue
        {
            get { return txtLookFor.Text; }
            set 
            {
                txtLookFor.TextChanged -= new EventHandler( ucFilter_FilterValueChanged );
                txtLookFor.Text = value;
                txtLookFor.Select( txtLookFor.TextLength, 0 );
                txtLookFor.TextChanged += new EventHandler( ucFilter_FilterValueChanged );
            }
        }
        #endregion

        #region public List<MyFilterField> Filters
        [DesignerSerializationVisibility( DesignerSerializationVisibility.Hidden )]
        public List<MyFilterField> Filters
        {
            get
            {
                return _lstFilters;
            }
            set
            {
                if( value != null )
                {
                    _lstFilters = value;

                    cmbFilteredBy.DisplayMember = "FieldName";
                    cmbFilteredBy.ValueMember = "FieldValue";
                    cmbFilteredBy.DataSource = _lstFilters;


                    cmbFilteredBy.SelectedValueChanged += new EventHandler( ucFilter_FilterValueChanged );
                    txtLookFor.TextChanged += new EventHandler( ucFilter_FilterValueChanged );
                }
            }
        } 
        #endregion



        
        #region public ucFilter()
        public ucFilter()
        {
            
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

            _lstFilters = new List<MyFilterField>();
            
        }
        #endregion



        
        #region protected virtual void RaiseFilterValueChangedEvent()
        protected virtual void RaiseFilterValueChangedEvent()
        {

            if( OnFilterChanged != null )
            {
                OnFilterChanged( this, this.FilterString );
            }

        }
        #endregion

        #region private void ucFilter_FilterValueChanged( object sender, EventArgs e )
        private void ucFilter_FilterValueChanged( object sender, EventArgs e )
        {
            RaiseFilterValueChangedEvent();
        } 
        #endregion
        
        #region private string BuildFilterString()
        private string BuildFilterString()
        {

            string strFilter = "";

            if( cmbFilteredBy.SelectedIndex > -1 && txtLookFor.Text.Trim().Length > 0 )
            {
                strFilter += cmbFilteredBy.SelectedValue + " Like '" + txtLookFor.Text.Trim() + "'";
            }

            return strFilter;

        } 
        #endregion




        #region private void txtLookFor_Enter( object sender, EventArgs e )
        private void txtLookFor_Enter( object sender, EventArgs e )
        {

            if( MouseButtons == MouseButtons.None )
            {
                this.txtLookFor.SelectAll();
                _alreadyFocused = true;
            }

        } 
        #endregion

        #region private void txtLookFor_MouseUp( object sender, MouseEventArgs e )
        private void txtLookFor_MouseUp( object sender, MouseEventArgs e )
        {
            if( !_alreadyFocused && this.txtLookFor.SelectionLength == 0 )
            {
                _alreadyFocused = true;
                this.txtLookFor.SelectAll();
            }

        } 
        #endregion

        #region private void txtLookFor_Leave( object sender, EventArgs e )
        private void txtLookFor_Leave( object sender, EventArgs e )
        {
            _alreadyFocused = false;
        } 
        #endregion


    }
}
