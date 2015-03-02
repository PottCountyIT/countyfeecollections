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

    public partial class frmDefendantEmployers : Form
    {

        private List<int> _lstEmployerIds = new List<int>();
        private Employers _employers;
        private int _intDefendantId;




        #region public EmployerDefendant SelectedEmployer
        public EmployerDefendant SelectedEmployer
        {
            get
            {

                if( dgvEmployers.SelectedRows.Count == 1 )
                {
                    EmployerDefendant emp = EmployerDefendant.CreateEmployerDefendant( (Employer)dgvEmployers.SelectedRows[0].DataBoundItem, _intDefendantId );
                    emp.SeparationDate = mskSeparationDate.Text;
                    return emp;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion




        #region public frmDefendantEmployers()
        public frmDefendantEmployers()
        {

            throw new NotSupportedException();

        } 
        #endregion

        #region public frmDefendantEmployers( BindingSource bindingEmployers, int defendantId )
        public frmDefendantEmployers( BindingSource bindingEmployers, int defendantId )
        {

            _intDefendantId = defendantId;

            // creating list of employer ids already bound to the defendant
            foreach( Employer employer in bindingEmployers )
                _lstEmployerIds.Add( employer.ID );

            try
            {
                _employers = new Employers( _lstEmployerIds );
            }
            catch( MyException myex )
            {
                MyMessageBox.Show( this, "Employer List", MyDisplayMessage.FormOpenError, myex );
                this.Close();
                return;
            }

            
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

            InitializeFilter();
            
        }
        #endregion




        #region private void InitializeFilter()
        private void InitializeFilter()
        {

            MyFilterField field;
            List<MyFilterField> fields = new List<MyFilterField>();

            field = new MyFilterField();
            field.FieldValue = "EmployerName";
            field.FieldName = "Employer Name";
            field.FieldType = typeof( string );
            fields.Add( field );


            field = new MyFilterField();
            field.FieldValue = "Street1";
            field.FieldName = "Street1";
            field.FieldType = typeof( string );
            fields.Add( field );


            field = new MyFilterField();
            field.FieldValue = "Street2";
            field.FieldName = "Street2";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "City";
            field.FieldName = "City";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "StateName";
            field.FieldName = "StateName";
            field.FieldType = typeof( string );
            fields.Add( field );

            ucFilter.Filters = fields;

            ucFilter.OnFilterChanged += new ucFilter.FilterValueChanged( ucFilter_OnFilterChanged );


        } 
        #endregion

        #region private void frmEmployers_Load( object sender, EventArgs e )
        private void frmEmployers_Load( object sender, EventArgs e )
        {

            BindData();

            ucFilter.Focus();

        }
        #endregion



        #region private void BindData()
        private void BindData()
        {

            bindingEmployers.RaiseListChangedEvents = false;
            bindingEmployers.DataSource = _employers;
            bindingEmployers.RaiseListChangedEvents = true;

            bindingEmployers.Sort = "EmployerName ASC";
            bindingEmployers.ResetBindings( false );

        } 
        #endregion

        #region private void ucFilter_OnFilterChanged( object sender, string filterString )
        private void ucFilter_OnFilterChanged( object sender, string filterString )
        {

            bindingEmployers.Filter = filterString;

        }
        #endregion


        #region private void btnEmployerMasterList_Click( object sender, EventArgs e )
        private void btnEmployerMasterList_Click( object sender, EventArgs e )
        {

            frmEmployers frm = new frmEmployers();

            if( !frm.IsDisposed )
            {
                frm.ShowDialog();

                // reload master employer list minus related employers
                try
                {
                    _employers = new Employers( _lstEmployerIds );
                }
                catch( MyException myex )
                {
                    MyMessageBox.Show( this, "Defendant Employers", MyDisplayMessage.FormUpdateError, myex );
                    this.Close();
                    return;
                }

                BindData();
            
            }

        }
        #endregion


        #region private void btnAdd_Click( object sender, EventArgs e )
        private void btnAdd_Click( object sender, EventArgs e )
        {

            this.Close();

        } 
        #endregion



    }
}
