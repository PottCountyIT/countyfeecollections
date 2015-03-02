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

    public partial class frmNotes : Form, INotifyPropertyChanged
    {


        #region public string Notes
        public string Notes
        {
            get { return txtNotes.Text.Trim(); }
            set { txtNotes.Text = value; }
        } 
        #endregion

        #region public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion


        
        
        #region public frmNotes()
        public frmNotes()
        {

            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

            this.txtNotes.MaxLength = Int32.MaxValue;
            
        } 
        #endregion




        #region private void RaisePropertyChangedEvent( string propertyName )
        private void RaisePropertyChangedEvent( string propertyName )
        {
            if( PropertyChanged != null )
            {
                PropertyChanged( this, new PropertyChangedEventArgs( propertyName ) );
            }
        }
        #endregion

        #region private void txtNotes_TextChanged( object sender, EventArgs e )
        private void txtNotes_TextChanged( object sender, EventArgs e )
        {
            RaisePropertyChangedEvent( "Notes" );

        } 
        #endregion


    }
}
