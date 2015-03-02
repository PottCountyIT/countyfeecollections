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
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace county.feecollections
{

    public partial class ucEmployer : UserControl
    {


        private int _intRowIndex = -1;
                
        

                
        #region public ucEmployer()
        public ucEmployer()
        {

            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

        }
        #endregion




        #region public void SetBindingSource( ref BindingSource bindingDefendants )
        public void SetBindingSource( ref BindingSource bindingDefendants )
        {
            this.SuspendLayout();

            this.bindingEmployers.DataMember = "Employers";
            this.bindingEmployers.DataSource = bindingDefendants;

            dgvEmployers.CellMouseMove += new DataGridViewCellMouseEventHandler( ShowPopup );
            dgvEmployers.CellEnter += new DataGridViewCellEventHandler( ShowPopup );
            dgvEmployers.CellMouseLeave += new DataGridViewCellEventHandler( HidePopup );
            dgvEmployers.Leave += new EventHandler( HidePopup );

            this.ResumeLayout( false );

        }
        #endregion
        
        #region private void dgvEmployers_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
        private void dgvEmployers_DataBindingComplete( object sender, DataGridViewBindingCompleteEventArgs e )
        {

            dgvEmployers.ClearSelection();
            this.toolTip.Hide( this.dgvEmployers );
            
        } 
        #endregion 

        #region private void mnuDefendantEmployer_Click( object sender, EventArgs e )
        private void mnuDefendantEmployer_Click( object sender, EventArgs e )
        {


            if( sender.Equals( mnuDefendantEmployerAdd ) )
            {

                frmDefendantEmployers frm = new frmDefendantEmployers( bindingEmployers, ((Defendant)((BindingSource)bindingEmployers.DataSource).Current).ID );

                if( !frm.IsDisposed && DialogResult.OK == frm.ShowDialog() )
                {
                    if( frm.SelectedEmployer != null )
                    {
                        
                        ((EmployerDefendant)bindingEmployers[bindingEmployers.Add( frm.SelectedEmployer )]).MyState = MyObjectState.New;

                    }

                    dgvEmployers.ClearSelection();

                }


            }
            else if( sender.Equals( mnuDefendantEmployerRemove ) )
            {
                if( bindingEmployers.Current != null )
                {
                    bindingEmployers.RemoveCurrent();
                }

            }

        } 
        #endregion
        
        #region private void ShowPopup( object sender, DataGridViewCellEventArgs e )
        private void ShowPopup( object sender, DataGridViewCellEventArgs e )
        {

            DataGridViewCellMouseEventArgs et = new DataGridViewCellMouseEventArgs( e.ColumnIndex, e.RowIndex, MousePosition.X, MousePosition.Y, new MouseEventArgs( MouseButtons.Left, 0, MousePosition.X, MousePosition.Y, 0 ) );
            ShowPopup( sender, et );

        }
        #endregion

        #region private void ShowPopup( object sender, DataGridViewCellMouseEventArgs e )
        private void ShowPopup( object sender, DataGridViewCellMouseEventArgs e )
        {

            if( e.RowIndex != _intRowIndex )
            {

                _intRowIndex = e.RowIndex;

                if( _intRowIndex >= 0 )
                {

                    Employer emp = (Employer)dgvEmployers.Rows[e.RowIndex].DataBoundItem;
                    StringBuilder tip = new StringBuilder();

                    toolTip.ToolTipTitle = emp.EmployerName;
                    
                    tip.Append( "\n" );
                    if( !string.IsNullOrEmpty( emp.Street1 ) )
                        tip.Append( emp.Street1 + "\n" );

                    if( !string.IsNullOrEmpty( emp.Street2 ) )
                        tip.Append( emp.Street2 + "\n" );

                    if( !string.IsNullOrEmpty( emp.City ) )
                        tip.Append( emp.City );

                    if( !string.IsNullOrEmpty( emp.City ) && !string.IsNullOrEmpty( emp.StateName ) )
                        tip.Append( ", " );

                    if( !string.IsNullOrEmpty( emp.StateName ) )
                        tip.Append( emp.StateName + " " );

                    if( !string.IsNullOrEmpty( emp.Zip ) )
                        tip.Append( emp.Zip );

                    if( !string.IsNullOrEmpty( emp.City ) || !string.IsNullOrEmpty( emp.StateName ) || !string.IsNullOrEmpty( emp.Zip ) )
                        tip.Append( "\n" );

                    if( !string.IsNullOrEmpty( emp.Phone ) )
                        tip.Append( emp.Phone + "\n" );

                    tip.Append( " " );
                    this.toolTip.Show( tip.ToString(), this.dgvEmployers, this.Width, 0, 30000 );

                }

            }

        } 
        #endregion

        #region private void HidePopup( object sender, EventArgs e )
        private void HidePopup( object sender, EventArgs e )
        {

            this.toolTip.Hide( this.dgvEmployers );
            _intRowIndex = -1;

        } 
        #endregion




    }

}
