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

    public partial class frmMain : Form
    {      
        private int _intPanelHeight;
        private int _intRowIndex;
        private Defendant _defendantTemp;
        private GridViewState _GridViewState = GridViewState.None;
        private string _strFilter;
        private LocalUser _usr;

        private frmNotes frmNotes;

        #region public frmMain()
        public frmMain()
        {
            while( !TestConnection() )
            {
                if( MessageBox.Show( "Do you wish to exit?", "Confirm exit", MessageBoxButtons.YesNo ) == DialogResult.Yes )
                {
                    Environment.Exit( 0 );
                }
            }

            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

            _usr = new LocalUser();
            this.Text = String.Format( "Fee Collections - {0} County", _usr.HomeCountyName );

            InitializeStatusBar();
            InitializeHelperObjects();
        } 
        #endregion

        private bool TestConnection()
        {
            while (true)
            {
                //try
                //{
                if (DBSettings.TestConnection())
                {
                    return true;
                }
                else
                //{
                //}
                //catch (MyException myex)
                {
                    try
                    {
                        if (DialogResult.No == MessageBox.Show("A connection could not be made to the database.  Please check your connection information.  Click \"Yes\" to try again or \"No\" to exit.", "Database Error", MessageBoxButtons.YesNo))
                        {
                            Environment.Exit(0);
                        }

                        frmOptions frm = new frmOptions();
                        frm.ShowInTaskbar = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = Application.CompanyName + " " + Application.ProductName + " Database Connection";
                        frm.ShowDialog();

                        if (frm.IsEmpty())
                        {
                            return false;
                        }
                    }
                    catch (ArgumentException)
                    {
                        frmOptions frm = new frmOptions();
                        frm.ShowInTaskbar = true;
                        frm.StartPosition = FormStartPosition.CenterScreen;
                        frm.Text = Application.CompanyName + " " + Application.ProductName + " Database Connection";
                        frm.ShowDialog();

                        if (frm.IsEmpty())
                        {
                            return false;
                        }
                    }
                }
            }
        }

        #region private void InitializeStatusBar()
        private void InitializeStatusBar()
        {
            mnuStatusWindowsUserName.Text = LocalUser.WindowsUserName;
            mnuStatusVersion.Text = "Version: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }  
        #endregion

        #region private void InitializeHelperObjects()
        private void InitializeHelperObjects()
        {
            // Filter Fields
            MyFilterField field;
            List<MyFilterField> fields = new List<MyFilterField>();

            field = new MyFilterField();
            field.FieldValue = "LastName";
            field.FieldName = "Last Name";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "FirstName";
            field.FieldName = "First Name";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "Employers";
            field.FieldName = "Employer";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "MiddleName";
            field.FieldName = "Middle Name";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "Aka";
            field.FieldName = "AKA";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "SSN";
            field.FieldName = "SSN";
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
            field.FieldName = "State";
            field.FieldType = typeof( string );
            fields.Add( field );

            field = new MyFilterField();
            field.FieldValue = "Zip";
            field.FieldName = "Zip";
            field.FieldType = typeof( string );
            fields.Add( field );

            ucFilter.Filters = fields;
            ucFilter.OnFilterChanged += new ucFilter.FilterValueChanged( ucFilter_OnFilterChanged );

        } 
        #endregion 

        #region private void frmMain_Load( object sender, EventArgs e )
        private void frmMain_Load( object sender, EventArgs e )
        {

            this.SuspendLayout();
            dgvDefendants.SuspendLayout();
            this.ucDefendant.SuspendLayout();
            this.ucPlans.SuspendLayout();
            this.ucFilter.SuspendLayout();

            // setting event handlers
            ucDefendant.txtFirstName.TextChanged += new EventHandler( defendant_NameChanged );
            ucDefendant.txtLastName.TextChanged += new EventHandler( defendant_NameChanged );

            dgvDefendants.CellMouseDown += new DataGridViewCellMouseEventHandler( dgvDefendants_CellMouseDown );
            dgvDefendants.Sorted += new EventHandler( dgvDefendants_Sorted );
            bindingDefendants.CurrentItemChanged += new System.EventHandler( this.UpdateGUIState );

            ucDefendant.SetBindingSource( ref bindingDefendants );
            ucPlans.SetBindingSource( ref bindingDefendants );

            _intPanelHeight = this.splitContainerDefendant.SplitterDistance;

            BindData();

            this.ucDefendant.ResumeLayout( false );
            this.ucPlans.ResumeLayout( false );
            this.ucFilter.ResumeLayout( false );
            dgvDefendants.ResumeLayout( false );
            this.ResumeLayout( false );

            ucFilter.Focus();
        } 
        #endregion



        #region private void BindData()
        private void BindData()
        {
            // creating and attaching base binding source that will be ref'd everywhere in this app
            bindingDefendants.RaiseListChangedEvents = false;
            bindingDefendants.DataSource = new Defendants();
            bindingDefendants.RaiseListChangedEvents = true;
            bindingDefendants.ResetBindings( false );

            UpdateGUIState( null, null );

            // setting up environmnent for initial display.
            bindingDefendants.Sort = "LastName ASC, FirstName ASC";
        } 
        #endregion

        #region private void mnuMain_Click( object sender, EventArgs e )
        private void mnuMain_Click( object sender, EventArgs e )
        {
            if( CanChangeCurrentDefendant() )
            {
                if( sender.Equals( mnuMainFileExit ) )
                {
                    Environment.Exit( 0 );
                }
                else if( sender.Equals( mnuMainToolsOptions ) )
                {
                    frmOptions frm = new frmOptions();
                    frm.FormClosed += new FormClosedEventHandler( frm_FormClosed );
                    frm.ShowDialog( this );

                    BindData();
                }
                else if( sender.Equals( mnuMainListsEmployers ) )
                {
                    frmEmployers frm = new frmEmployers();

                    if( !frm.IsDisposed )
                    {
                        frm.ShowDialog( this );
                        BindData();
                    }
                }
                else if( sender.Equals( mnuMainListsFeeTypes ) )
                {
                    frmFeeTypes frm = new frmFeeTypes();
                    if( !frm.IsDisposed )
                    {
                        frm.ShowDialog( this );
                        BindData();
                    }
                }
                else if( sender.Equals( mnuMainListsPaymentArrangementTypes ) )
                {
                    frmPaymentArrangementTypes frm = new frmPaymentArrangementTypes();
                    if( !frm.IsDisposed )
                    {
                        frm.ShowDialog( this );
                        BindData();
                    }
                }
                else if( sender.Equals( mnuMainListsRestrictedCasePrefixes ) )
                {
                    frmRestrictedCasePrefixes frm = new frmRestrictedCasePrefixes();
                    if( !frm.IsDisposed )
                    {
                        frm.ShowDialog( this );
                        BindData();
                    }
                }
                else if( sender.Equals( mnuMainReportsMailMerge ) )
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmMailMerge frm = new frmMailMerge();
                    if( !frm.IsDisposed )
                    {
                        // open, but don't try to own
                        frm.Show();
                    }

                    Application.DoEvents();
                    this.Cursor = Cursors.Default;
                }
                else if( sender.Equals( mnuMainReportsSSRS ) )
                {
                    this.Cursor = Cursors.WaitCursor;

                    frmSSRS frm = new frmSSRS();
                    if( !frm.IsDisposed )
                    {
                        // open, but don't try to own
                        frm.Show();
                    }

                    Application.DoEvents();

                    this.Cursor = Cursors.Default;
                }
                else if( sender.Equals( mnuMainToolsOptionsPrintDelinquentLetters ) )
                {
                    PrintDialog diag = new PrintDialog();

                    if( diag.ShowDialog() == DialogResult.OK )
                    {
                        PrintDelinquent print = new PrintDelinquent();
                        print.PrintDocuments( diag.PrinterSettings.PrinterName, DateTime.Now );
                    }
                }

            }
        } 
        #endregion

        #region void frm_FormClosed( object sender, FormClosedEventArgs e )
        void frm_FormClosed( object sender, FormClosedEventArgs e )
        {
            this.Text = String.Format( "Fee Collections - {0} County", _usr.HomeCountyName );
        } 
        #endregion

        #region private void mnuDefendant_Click( object sender, EventArgs e )
        private void mnuDefendant_Click( object sender, EventArgs e )
        {
            Defendant defendant = (Defendant)bindingDefendants.Current;

            /********************************************************************************
            *   New
            ********************************************************************************/
            if( sender.Equals( mnuDefendantNew ) )
            {
                if( CanChangeCurrentDefendant() )
                {

                    this.SuspendLayout();

                    if( ucFilter.FilterValue.Length > 0 )
                    {
                        bindingDefendants.Filter = "";
                        ucFilter.FilterValue = "";
                    }

                    _GridViewState = GridViewState.Adding;
                    bindingDefendants.AddNew();
                    _GridViewState = GridViewState.None;

                    bindingDefendants.ResetCurrentItem();

                    this.ResumeLayout( false );

                    ucDefendant.Focus();
                }
            }
            /********************************************************************************
            *   Remove
            *********************************************************************************
            else if( sender.Equals( mnuDefendantRemove ) )
            {
                if( DialogResult.OK == MyMessageBox.Show( this, "Defendant", MyDisplayMessage.RemoveConfirm ) )
                {
                    this.SuspendLayout();

                    try
                    {
                        bindingDefendants.RemoveCurrent();
                        bindingDefendants.ResetBindings( false );
                        this.ucFilter.Focus();
                    }
                    catch( MyException ex )
                    {
                        MyMessageBox.Show( this, "Defendant", MyDisplayMessage.RemoveError, ex );
                    }

                    bindingDefendants.ResetCurrentItem();

                    this.ResumeLayout( false );
                }

            }*/
            /********************************************************************************
            *   Refresh
            ********************************************************************************/
            else if( sender.Equals( mnuDefendantRefresh ) )
            {
                if( !defendant.MyState.Equals( MyObjectState.Current ) )
                {
                    if( DialogResult.Cancel == MyMessageBox.Show( this, "Defendant", MyDisplayMessage.RefreshConfirm ) )
                    {
                        return;
                    }
                }

                this.Cursor = Cursors.WaitCursor;
                this.SuspendLayout();
                ucDefendant.SuspendLayout();

                try
                {
                    defendant.Refresh();
                    bindingDefendants.ResetBindings( false );
                    ucDefendant.Update();
                    ucDefendant.Focus();
                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Defendant", MyDisplayMessage.RefreshError, ex );
                }

                ucDefendant.ResumeLayout( false );
                this.ResumeLayout( false );
                this.Cursor = Cursors.Default;
            }
            /********************************************************************************
            *   Save
            ********************************************************************************/
            else if( sender.Equals( mnuDefendantSave ) )
            {

                ucDefendant.Select();
                bindingDefendants.EndEdit();

                this.Cursor = Cursors.WaitCursor;
                this.SuspendLayout();

                try
                {

                    defendant.Save( true );
                    bindingDefendants.Sort = "";

                    // setting sort 
                    string strSort = string.Empty;
                    string strSortOrder = (dgvDefendants.SortOrder == SortOrder.Descending) ? "DESC" : "ASC";
                    if( dgvDefendants.SortedColumn.DataPropertyName.ToLower() == "lastname" )
                    {
                        strSort = "LastName " + strSortOrder + ", FirstName " + strSortOrder;
                    }
                    else
                    {
                        strSort = "FirstName " + strSortOrder + ", LastName " + strSortOrder;
                    }
                    bindingDefendants.Sort = strSort;

                    ResetDataGridViewDefendant( defendant );

                }
                catch( MyException ex )
                {
                    MyMessageBox.Show( this, "Defendant", MyDisplayMessage.SaveError, ex );
                }
                catch( ArgumentOutOfRangeException )
                {
                    MyMessageBox.Show( this, "Payment Arrangement", MyDisplayMessage.PaymentArrangementOverlapping );
                }

                this.ResumeLayout( false );
                this.Cursor = Cursors.Default;

            }
            /********************************************************************************
            *   Cancel
            ********************************************************************************/
            else if( sender.Equals( mnuDefendantCancel ) )
            {
                this.SuspendLayout();
                if( defendant.MyState == MyObjectState.New )
                {
                    bindingDefendants.RemoveCurrent();
                    if( bindingDefendants.Count > 0 )
                    {
                        bindingDefendants.Position = 0;
                        ucDefendant.Focus();
                    }
                    else
                    {
                        this.ucFilter.Focus();
                    }
                }
                else
                {
                    defendant.Reset();
                    bindingDefendants.ResetCurrentItem();
                }
                this.ResumeLayout( false );
            }
            /********************************************************************************
            *   Notes
            ********************************************************************************/
            else if( sender.Equals( mnuDefendantNotes ) )
            {

                if( frmNotes == null )
                {
                    frmNotes = new frmNotes();

                    frmNotes.DataBindings.Add( "Notes", bindingDefendants, "Notes", true, DataSourceUpdateMode.OnPropertyChanged );
                    frmNotes.FormClosed += new FormClosedEventHandler( frmNotes_FormClosed );
                }

                if( !frmNotes.Visible )
                    frmNotes.Show( this );
                else
                    frmNotes.Focus();

            }
            /********************************************************************************
            *   Mail Merge
            ********************************************************************************/
            else if( sender.Equals( mnuDefendantMailMerge ) )
            {


                if( !MailMerge.StoreDirectoryConfigured() && !MailMerge.StoreDirectoryExists() )
                {
                    MyMessageBox.Show( this, "MS Word Mail Merge", MyDisplayMessage.MailMergeDirectoryError );
                    return;
                }

                frmMailMergeTemplates frm = new frmMailMergeTemplates();
                if( DialogResult.Cancel == frm.ShowDialog( this ) || string.IsNullOrEmpty( frm.SelectedMailMergeTemplatePath ) )
                {
                    return;
                }


                this.Cursor = Cursors.WaitCursor;

                int defendantid = ((Defendant)bindingDefendants.Current).ID;
                int planid = ucPlans.PlanId;
                string templatePath = frm.SelectedMailMergeTemplatePath;

                try
                {
                    MailMerge.PerformMailMerge( defendantid, planid, templatePath );
                }
                catch( Exception ex )
                {
                    MyMessageBox.Show( this, "Mail Merge", MyDisplayMessage.MailMergeDocumentMergeError, new MyException( ex.Message.ToString(), MyErrorType.MailMergeError, ex ) );
                }

                this.Cursor = Cursors.Default;

            }
            /********************************************************************************
            *   Make Payment
            ********************************************************************************/
            else if( sender.Equals( mnuDefendantPayment ) )
            {
                BindingSource bindingPayments = new BindingSource( new BindingSource( bindingDefendants, "Plans" ), "Payments" );

                frmPayment frm = new frmPayment( ref bindingPayments );

                if( !frm.IsDisposed )
                {
                    frm.ShowDialog( this );
                    bindingDefendants.ResetCurrentItem();
                }
            }
            /********************************************************************************
            *   Remove/Archive - doesn't delete from the database
            ********************************************************************************/
            else if( sender.Equals( mnuDefendantRemove ) )
            {
                if( DialogResult.OK == MyMessageBox.Show( this, "Remove Defendant", MyDisplayMessage.Archive ) )
                {
                    this.SuspendLayout();

                    defendant.Reset();

                    defendant.RaiseChangedEvents = false;
                    defendant.Active = false;
                    defendant.Save( true );

                    // set state to new to fake out the collection into removing it but not removing it from the db.
                    //defendant.MyState = MyObjectState.New;
                    defendant.RaiseChangedEvents = true;

                    try
                    {
                        bindingDefendants.Remove( defendant );
                        bindingDefendants.ResetBindings( true );
                        this.ucFilter.Focus();
                    }
                    catch( MyException ex )
                    {
                        MyMessageBox.Show( this, "Defendant", MyDisplayMessage.RemoveError, ex );
                    }

                    this.ResumeLayout();

                }
            }


        } 
        #endregion

        #region private void defendant_NameChanged( object sender, EventArgs e )
        private void defendant_NameChanged( object sender, EventArgs e )
        {
            this.SuspendLayout();
            this.lblTitleBar.SuspendLayout();

            lblTitleBar.Text = "     " + ucDefendant.txtLastName.Text.Trim();

            if( !string.IsNullOrEmpty( ucDefendant.txtFirstName.Text.Trim() ) && !string.IsNullOrEmpty( ucDefendant.txtFirstName.Text.Trim() ) )
                lblTitleBar.Text += ", ";

            lblTitleBar.Text += ucDefendant.txtFirstName.Text.Trim();

            this.lblTitleBar.ResumeLayout( false );
            this.ResumeLayout( false );

        } 
        #endregion

        #region private void UpdateGUIState( object sender, System.EventArgs e )
        private void UpdateGUIState( object sender, System.EventArgs e )
        {
            this.SuspendLayout();
            this.ucDefendant.SuspendLayout();
            this.ucPlans.SuspendLayout();
            this.mnuDefendant.SuspendLayout();

            if( bindingDefendants.Current != null )
            {
                ucDefendant.Enabled = true;
                ucPlans.Enabled = true;

                switch( ((Defendant)bindingDefendants.Current).MyState )
                {
                    case MyObjectState.Modified:
                        mnuDefendantRemove.Enabled = true;
                        mnuDefendantRefresh.Enabled = true;
                        mnuDefendantSave.Enabled = true;
                        mnuDefendantCancel.Enabled = true;
                        mnuDefendantNotes.Enabled = true;
                        mnuDefendantMailMerge.Enabled = true;
                        mnuDefendantPayment.Enabled = true;
                        mnuDefendantArchive.Enabled = true;
                        break;

                    case MyObjectState.New:
                        mnuDefendantRemove.Enabled = true;
                        mnuDefendantRefresh.Enabled = false;
                        mnuDefendantSave.Enabled = true;
                        mnuDefendantCancel.Enabled = true;
                        mnuDefendantNotes.Enabled = true;
                        mnuDefendantMailMerge.Enabled = false;
                        mnuDefendantPayment.Enabled = false;
                        mnuDefendantArchive.Enabled = false;
                        break;

                    case MyObjectState.Current:
                        mnuDefendantRemove.Enabled = true;
                        mnuDefendantRefresh.Enabled = true;
                        mnuDefendantSave.Enabled = false;
                        mnuDefendantCancel.Enabled = false;
                        mnuDefendantNotes.Enabled = true;
                        mnuDefendantMailMerge.Enabled = true;
                        mnuDefendantPayment.Enabled = true;
                        mnuDefendantArchive.Enabled = true;
                        break;

                    default:
                        mnuDefendantRemove.Enabled = false;
                        mnuDefendantRefresh.Enabled = false;
                        mnuDefendantSave.Enabled = false;
                        mnuDefendantCancel.Enabled = false;
                        mnuDefendantNotes.Enabled = false;
                        mnuDefendantMailMerge.Enabled = false;
                        mnuDefendantPayment.Enabled = false;
                        mnuDefendantArchive.Enabled = false;
                        break;
                }
            }
            else
            {

                ucDefendant.Enabled = false;
                ucPlans.Enabled = false;

                mnuDefendantRemove.Enabled = false;
                mnuDefendantRefresh.Enabled = false;
                mnuDefendantSave.Enabled = false;
                mnuDefendantCancel.Enabled = false;
                mnuDefendantNotes.Enabled = false;
                mnuDefendantMailMerge.Enabled = false;
                mnuDefendantPayment.Enabled = false;
                mnuDefendantArchive.Enabled = false;

            }

            this.mnuDefendant.ResumeLayout( false );
            this.ucPlans.ResumeLayout( false );
            this.ucDefendant.ResumeLayout( false );
            this.ResumeLayout( false );

        } 
        #endregion

        #region private void dgvDefendants_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        /// <summary>
        /// This method catches a change in the selection of a defendant in the 
        /// datagridview and forces a check on state of the currently selected object.
        /// (It basically allows the user to cancel out of a change in 
        /// the datagridview if the current defendant is not in a "current" state.)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDefendants_RowValidating( object sender, DataGridViewCellCancelEventArgs e )
        {
            if( (dgvDefendants.Focused) && (_GridViewState != GridViewState.Adding && _GridViewState != GridViewState.Sorting) )
            {
                if( !CanChangeCurrentDefendant() )
                {
                    e.Cancel = true;
                }
            }
        } 
        #endregion

        #region private void dgvDefendants_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        /// <summary>
        /// Catching a column header click on the defendant datagridview.  It saves the 
        /// currently selected defendnant so it can try and restore after a sort operation.
        /// </summary>
        /// <param name="sender">not used</param>
        /// <param name="e">mouse event arguments for cellmousedown event in the defendant datagridview.</param>
        private void dgvDefendants_CellMouseDown( object sender, DataGridViewCellMouseEventArgs e )
        {
            if( e.RowIndex == -1 && dgvDefendants.SelectedRows.Count > 0 )
            {
                _defendantTemp = ((Defendant)dgvDefendants.SelectedRows[0].DataBoundItem);
            }
        } 
        #endregion

        #region private void dgvDefendants_Sorted( object sender, EventArgs e )
        /// <summary>
        /// The defendant datagridview has been sorted.  Reselecting the defendant
        /// that was selected before the sort.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvDefendants_Sorted( object sender, EventArgs e )
        {
            ResetDataGridViewDefendant( _defendantTemp );
            _defendantTemp = null;
        } 
        #endregion

        #region private void ucFilter_OnFilterChanged( object sender, string filterString )
        private void ucFilter_OnFilterChanged( object sender, string filterString )
        {
            if( CanChangeCurrentDefendant() )
            {
                // can change the defendant, so save the currently selected, so I can try and reselct it after the filter
                if( bindingDefendants.Current != null )
                    _defendantTemp = ((Defendant)dgvDefendants.SelectedRows[0].DataBoundItem);


                this.SuspendLayout();
                this.dgvDefendants.SuspendLayout();

                // set the filter
                if( !string.IsNullOrEmpty( filterString ) )
                {
                    bindingDefendants.Filter = filterString;
                    _strFilter = ((ucFilter)sender).FilterValue;
                }
                else
                {
                    bindingDefendants.Filter = null;
                    bindingDefendants.ResetBindings( false );
                }

                if( _defendantTemp != null )
                {
                    ResetDataGridViewDefendant( _defendantTemp );
                    _defendantTemp = null;
                }

                this.dgvDefendants.ResumeLayout( false );
                this.ResumeLayout( false );
            }
            else
            {
                // set the filter back to the previous value
                ((ucFilter)sender).FilterValue = _strFilter;
            }
        } 
        #endregion

        #region private bool CanChangeCurrentDefendant()
        private bool CanChangeCurrentDefendant()
        {
            bool rtnValue = true;

            if( bindingDefendants.Current != null )
            {
                Defendant defendant = (Defendant)bindingDefendants.Current;

                switch( defendant.MyState )
                {
                    case MyObjectState.New:
                    case MyObjectState.Modified:

                        switch( MyMessageBox.Show( this, "Defendant", MyDisplayMessage.SaveConfirm ) )
                        {
                            case DialogResult.Yes:
                                try
                                {
                                    defendant.Save( true );
                                    bindingDefendants.ResetCurrentItem();
                                    rtnValue = true;
                                }
                                catch( MyException ex )
                                {
                                    MyMessageBox.Show( this, "Defendant", MyDisplayMessage.SaveError, ex );
                                    rtnValue = false;
                                }
                                break;

                            case DialogResult.No:
                                if( defendant.MyState == MyObjectState.New )
                                {
                                    bindingDefendants.RemoveCurrent();
                                    bindingDefendants.ResetBindings( false );
                                    ucDefendant.Focus();
                                }
                                else
                                {
                                    defendant.Reset();
                                }
                                rtnValue = true;
                                break;

                            case DialogResult.Cancel:
                                rtnValue = false;
                                break;
                        }
                        break;
                }
            }
            return rtnValue;
        } 
        #endregion

        #region private void ResetDataGridViewDefendant( Defendant defendant )
        /// <summary>
        /// Highlights the defendant object argument in the defendant datagridview.  
        /// Helps to specify behavior of highligted defendant after sorts, inserts,
        /// and delete operations.
        /// </summary>
        /// <param name="defendant">The defendnat object to be highlighted.</param>
        private void ResetDataGridViewDefendant( Defendant defendant )
        {
            if( defendant != null )
            {
                int row = bindingDefendants.IndexOf( defendant );
                if( row >= 0 )
                {
                    dgvDefendants.BeginInvoke( (MethodInvoker)delegate()
                    {
                        this.SuspendLayout();
                        dgvDefendants.Rows[row].Selected = true;
                        dgvDefendants.CurrentCell = dgvDefendants[0, row];
                        this.ResumeLayout();
                    } );
                }
            }
        } 
        #endregion





        #region private void lblTitleBar_Click( object sender, EventArgs e )
        private void lblTitleBar_Click( object sender, EventArgs e )
        {
            this.SuspendLayout();
            this.splitContainerDefendant.SuspendLayout();
            this.lblTitleBar.SuspendLayout();

            lblTitleBar.Image = (splitContainerDefendant.Panel1Collapsed) ? Properties.Resources.collapsed : Properties.Resources.expanded;
            splitContainerDefendant.Panel1Collapsed = !splitContainerDefendant.Panel1Collapsed;

            this.lblTitleBar.ResumeLayout( false );
            this.splitContainerDefendant.ResumeLayout( false );
            this.ResumeLayout( false );
        } 
        #endregion


        #region private void splitContainerDefendant_Resize( object sender, EventArgs e )
        private void splitContainerDefendant_Resize( object sender, EventArgs e )
        {
            if( pnlScroll.Height > splitContainerDefendant.Height )
            {
                this.splitContainerDefendant.SuspendLayout();
                splitContainerDefendant.Size = pnlScroll.Size;
                this.splitContainerDefendant.ResumeLayout( false );
            }
        } 
        #endregion

        #region private void frmNotes_FormClosed( object sender, FormClosedEventArgs e )
        private void frmNotes_FormClosed( object sender, FormClosedEventArgs e )
        {
            frmNotes.Dispose();
            frmNotes = null;
        } 
        #endregion

        #region protected override void OnKeyDown( KeyEventArgs e )
        protected override void OnKeyDown( KeyEventArgs e )
        {
            if( e.KeyCode == Keys.S && e.Modifiers == Keys.Control )
            {
                this.mnuDefendant_Click( mnuDefendantSave, null );
            }

            base.OnKeyDown( e );
        } 
        #endregion




    }
}
