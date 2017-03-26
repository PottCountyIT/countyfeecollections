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
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;


namespace county.feecollections
{
    public partial class frmSSRS : Form
    {
        private DateTime _startTime;
        private DataSet _ds;

        private ucCriteriaCollectionsBreakdown ucCriteriaCollectionsBreakdown;
        private ucCriteriaAccountStatus ucCriteriaAccountStatus;
        private ucCriteriaSubReportCases ucCriteriaSubReportCases;



        #region public frmSSRS()
        public frmSSRS()
        {
            InitializeComponent();

            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer, true );

            InitializeReportDropDown();

// for debugging
#if DEBUG

            this.cmbReports.SelectedIndex = 7;
            btnRender_Click( this, null );

#endif


        } 
        #endregion




        #region private void InitializeReportDropDown()
        private void InitializeReportDropDown()
        {

            this.cmbReports.Items.AddRange( new string[] { 
                "Commit Date Status",
                "Account Status",
                "Collections Breakdown", 
                "Probation",
                "Jail Room and Board",
                "Balance Less Than $100",
                "Restitution",
                "Noncompliance"
                } );

            this.cmbReports.SelectedIndex = 0;
        } 
        #endregion

        #region private void cmbReports_SelectedIndexChanged( object sender, EventArgs e )
        private void cmbReports_SelectedIndexChanged( object sender, EventArgs e )
        {

            this.grpReportParameters.Controls.Clear();

            switch( cmbReports.SelectedIndex )
            {
                case 1: //Account Status
                case 4: //Jail Room and Board
                    this.ucCriteriaAccountStatus = new ucCriteriaAccountStatus();
                    this.ucCriteriaAccountStatus.Dock = DockStyle.Fill;
                    this.ucCriteriaAccountStatus.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular );
                    this.grpReportParameters.Controls.Add( this.ucCriteriaAccountStatus );
                    break;

                case 2: //Collections Breakdown
                    this.ucCriteriaCollectionsBreakdown = new ucCriteriaCollectionsBreakdown();
                    this.ucCriteriaCollectionsBreakdown.Dock = DockStyle.Fill;
                    this.ucCriteriaCollectionsBreakdown.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular );
                    this.grpReportParameters.Controls.Add( this.ucCriteriaCollectionsBreakdown );
                    break;

                case 3: //Probation
                    this.ucCriteriaSubReportCases = new ucCriteriaSubReportCases();
                    this.ucCriteriaSubReportCases.Dock = DockStyle.Fill;
                    this.ucCriteriaSubReportCases.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular );
                    this.grpReportParameters.Controls.Add( this.ucCriteriaSubReportCases );
                    break;

                default:
                    // case 5: //Balance Less Than $100
                    // case 6: //Restitution
                    // case 7: //Non Compliance
                    this.lblNoReportParameters.Dock = DockStyle.Fill;
                    this.grpReportParameters.Controls.Add( this.lblNoReportParameters );
                    break;
            }

        } 
        #endregion

        #region private void btnRender_Click( object sender, EventArgs e )
        private void btnRender_Click( object sender, EventArgs e )
        {
            _startTime = DateTime.Now;

            if( cmbReports.SelectedIndex >= 0 )
            {
                lblReportNameValue.Text = cmbReports.SelectedItem.ToString();
                lblGeneratedValue.Text = DateTime.Now.ToString( "g" );
                lblRenderTimeValue.Text = "";
            }

            this.reportViewer.Reset();
            this.reportViewer.RenderingComplete += new RenderingCompleteEventHandler( reportViewer_RenderingComplete );
            this.reportViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler( LocalReport_SubreportProcessing );

            switch( cmbReports.SelectedIndex )
            {

                case 0: //Commit Date Status
                    LoadCommitDateStatusReport();
                    break;

                case 1: //Account Status
                    LoadAccountStatusReport();
                    break;

                case 2: //Collections Breakdown
                    LoadCollectionsBreakdownReport();
                    break;

                case 3: //Probation
                    LoadProbationReport();
                    break;

                case 4: //Jail Room and Board
                    LoadJailRoomAndBoard();
                    break;

                case 5: //Balance Less than $100
                    LoadBalanceLess100Report();
                    break;

                case 6: //Restitution
                    LoadRestitutionReport();
                    break;

                case 7: //Noncompliance
                    LoadNoncomplianceReport();
                    break;

                default:
                    MessageBox.Show( this, "This report has not been implemented yet", "SSRS Reports", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    return;
            }
            this.reportViewer.SetDisplayMode( DisplayMode.PrintLayout );
            this.reportViewer.ZoomMode = ZoomMode.PageWidth;
        } 
        #endregion

        #region private void reportViewer_RenderingComplete( object sender, RenderingCompleteEventArgs e )
        private void reportViewer_RenderingComplete( object sender, RenderingCompleteEventArgs e )
        {

            lblRenderTimeValue.Text = (DateTime.Now - _startTime).TotalSeconds.ToString() + " sec";

        } 
        #endregion




        #region private void LoadNoncomplianceReport()
        private void LoadNoncomplianceReport()
        {

            DataTable dt = new DataTable();

            const string sql = "Report_Noncompliance";

            using( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
            }

            dt.TableName = "CaseTable";
            _ds = new DataSet();
            _ds.Tables.Add( dt );
            _ds.AcceptChanges();

            BindingSource binding = new BindingSource( _ds, "CaseTable" );

            this.reportViewer.LocalReport.ReportEmbeddedResource = "county.feecollections.reports.rptNonCompliance.rdlc";
            this.reportViewer.LocalReport.DataSources.Add( new ReportDataSource( "DataSet_vw_AccntStatus", binding ) );

        }
        #endregion

        #region private void LoadRestitutionReport()
        private void LoadRestitutionReport()
        {

            DataTable dt = new DataTable();

            const string sql = "Report_Restitution";

            using( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
            }

            dt.TableName = "CaseTable";
            _ds = new DataSet();
            _ds.Tables.Add( dt );
            _ds.AcceptChanges();

            BindingSource binding = new BindingSource( _ds, "CaseTable" );

            this.reportViewer.LocalReport.ReportEmbeddedResource = "county.feecollections.reports.rptRestitution.rdlc";
            this.reportViewer.LocalReport.DataSources.Add( new ReportDataSource( "DataSet_vw_AccntStatus", binding ) );

        }
        #endregion

        #region private void LoadCommitDateStatusReport()
        private void LoadCommitDateStatusReport()
        {

            DataTable dt = new DataTable();

            const string sql = "Report_CommitDateStatus";

            using( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
            }

            dt.TableName = "CaseTable";
            _ds = new DataSet();
            _ds.Tables.Add( dt );
            _ds.AcceptChanges();

            BindingSource binding = new BindingSource( _ds, "CaseTable" );

            this.reportViewer.LocalReport.ReportEmbeddedResource = "county.feecollections.reports.rptCommitDateStatus.rdlc";
            this.reportViewer.LocalReport.DataSources.Add( new ReportDataSource( "DataSet_vw_AccntStatus", binding ) );
        } 
        #endregion

        #region private void LoadAccountStatusReport()
        private void LoadAccountStatusReport()
        {
            
            DataTable dt = new DataTable();
            LocalUser user = new LocalUser();

            string sql = (user.LenientBilling) ? "Report_AccountStatusLenientBilling" : "Report_AccountStatus";

            using ( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add( "@input_DateTime", SqlDbType.DateTime ).Value = this.ucCriteriaAccountStatus.InputDate;

                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
            }

            dt.TableName = "AccountStatusTable";
            _ds = new DataSet();
            _ds.Tables.Add( dt );
            _ds.AcceptChanges();

            BindingSource binding = new BindingSource( _ds, "AccountStatusTable" );
            ReportParameter[] parameters = new ReportParameter[] { new ReportParameter( "SnapShotDate", ucCriteriaAccountStatus.InputDate.ToShortDateString() ) };

            this.reportViewer.LocalReport.ReportEmbeddedResource = "county.feecollections.reports.rptAccountStatus.rdlc";
            this.reportViewer.LocalReport.DataSources.Add( new ReportDataSource( "DataSet_sp_account_status_data", binding ) );
            this.reportViewer.LocalReport.SetParameters( parameters );

        } 
        #endregion

        #region private void LoadProbationReport()
        private void LoadProbationReport()
        {
            _ds = GetProbationReportData();
            BindingSource binding = new BindingSource( _ds, "DefendantTable" );

            this.reportViewer.LocalReport.ReportEmbeddedResource = "county.feecollections.reports.rptProbation.rdlc";
            this.reportViewer.LocalReport.DataSources.Add( new ReportDataSource( "DataSet_Defendant", binding ) );

            ReportParameter[] parameters = new ReportParameter[] { new ReportParameter( "CAPPIncluded", this.ucCriteriaSubReportCases.IncludeCAPPCases.ToString() ), new ReportParameter( "NonCAPPIncluded", this.ucCriteriaSubReportCases.IncludeNonCAPPCases.ToString() ) };
            this.reportViewer.LocalReport.SetParameters( parameters );
        } 
        #endregion

        #region private DataSet GetProbationReportData()
        private DataSet GetProbationReportData()
        {

            DataSet dsDefendantsCases = new DataSet();
            dsDefendantsCases.DataSetName = "ProbationReport";
            DataTable dt = new DataTable();

            using( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( "", con ) )
            {

                cmd.Parameters.Add( "@capp", SqlDbType.Bit ).Value = ucCriteriaSubReportCases.IncludeCAPPCases;
                cmd.Parameters.Add( "@noncapp", SqlDbType.Bit ).Value = ucCriteriaSubReportCases.IncludeNonCAPPCases;

                cmd.CommandText = "SELECT DISTINCT a.defendantid as defendantid, a.firstname + ' ' + a.middlename as firstname, a.lastname as lastname, "
                                    + "a.probationofficer as probationofficer, b.receiveddate as receiveddate, dp.noncompliancenotice, "
                                    + "CASE "
                                    + "WHEN DateDiff(Day, b.receiveddate, getdate()) > 30 THEN 'Yes' "
                                    + "WHEN DateDiff(Day, b.receiveddate, getdate()) <= 30 THEN 'No' "
                                    + "WHEN DateDiff(Day, c.startdate, getdate()) > 30 THEN 'Yes' "
                                    + "WHEN DateDiff(Day, c.startdate, getdate()) <= 30 THEN 'No' "
                                    + "END as deliquentstatus, ISNULL(z.amount ,0) AS amount "
                                    + "FROM Defendant as a "
                                    + "LEFT OUTER JOIN (select defendantid, MAX(receiveddate) as receiveddate from FeePayment group by defendantid) as b on a.defendantid = b.defendantid "
                                    + "LEFT OUTER JOIN (select defendantid, amount, receiveddate from FeePayment) as z on a.defendantid = z.defendantid AND b.receiveddate = z.receiveddate "
                                    + "INNER JOIN PlanPaymentArrangement AS c ON a.defendantid = c.defendantid "
                                    + "INNER JOIN DefendantPlans dp on a.defendantid = dp.defendantid "
                                    + "WHERE active = 1 AND hasprobationofficer = 1 "
                                    + "ORDER BY probationofficer, lastname, firstname ";


                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
                dt.TableName = "DefendantTable";
                dsDefendantsCases.Tables.Add( dt.Copy() );


                cmd.CommandText = "SELECT Defendant.defendantid, ISNULL(casename, 'null_casename') as casename, ISNULL(PlanCase.capp, '' ) as capp FROM Defendant "
                    + "LEFT OUTER JOIN PlanCase ON PlanCase.defendantid = Defendant.defendantid "
                    + "WHERE active = 1 AND hasprobationofficer = 1 "
                    + "AND (PlanCase.capp = @capp OR PlanCase.capp = @noncapp ) "
                    + "AND ((@capp = 1 AND @noncapp <> 1) OR (@capp <> 1 AND @noncapp = 1) OR (@capp = 1 AND @noncapp = 1)) "
                    + "ORDER BY Defendant.defendantid; ";

                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
                dt.TableName = "CaseTable";
                dsDefendantsCases.Tables.Add( dt.Copy() );


                foreach( DataRow dr in dsDefendantsCases.Tables["DefendantTable"].Rows )
                {
                    
                    // does the defendant table have a record.
                    DataRow[] drs = dsDefendantsCases.Tables["CaseTable"].Select( "defendantid = " + dr["defendantid"] );

                    if( drs.Length == 1 )
                    {

                        // add a couple of records to even out the rdlc columns
                        DataRow newDr;

                        newDr = dsDefendantsCases.Tables["CaseTable"].NewRow();
                        newDr["defendantid"] = dr["defendantid"];
                        newDr["casename"] = "";

                        dsDefendantsCases.Tables["CaseTable"].Rows.Add( newDr );

                    }

                    if( drs.Length <= 0 )
                    {
                        // add a couple of records to even out the rdlc columns
                        DataRow newDr;
                        
                        newDr = dsDefendantsCases.Tables["CaseTable"].NewRow();
                        newDr["defendantid"] = dr["defendantid"];
                        newDr["casename"] = "";
                        dsDefendantsCases.Tables["CaseTable"].Rows.Add( newDr );

                        newDr = dsDefendantsCases.Tables["CaseTable"].NewRow();
                        newDr["defendantid"] = dr["defendantid"];
                        newDr["casename"] = "";

                        dsDefendantsCases.Tables["CaseTable"].Rows.Add( newDr );

                    }

                }

            }

            return dsDefendantsCases;

        } 
        #endregion

        #region private void LoadJailRoomAndBoard()
        private void LoadJailRoomAndBoard()
        {

            DataTable dt = new DataTable();

            const string sql = "Report_JailRoomBoard";

            using( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add( "@input_DateTime", SqlDbType.DateTime ).Value = this.ucCriteriaAccountStatus.InputDate;

                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
            }

            dt.TableName = "JailRoomAndBoardTable";
            _ds = new DataSet();
            _ds.Tables.Add( dt );
            _ds.AcceptChanges();

            BindingSource binding = new BindingSource( _ds, "JailRoomAndBoardTable" );
            ReportParameter[] parameters = new ReportParameter[] { new ReportParameter( "SnapShotDate", ucCriteriaAccountStatus.InputDate.ToShortDateString() ) };

            this.reportViewer.LocalReport.ReportEmbeddedResource = "county.feecollections.reports.rptJailReport.rdlc";
            this.reportViewer.LocalReport.DataSources.Add( new ReportDataSource( "DataSet_sp_prison_room_and_board_data", binding ) );
            this.reportViewer.LocalReport.SetParameters( parameters );

        }
        #endregion

        #region private void LoadBalanceLess100Report()
        private void LoadBalanceLess100Report()
        {

            DataTable dt = new DataTable();

            const string sql = "Report_BalanceLess100";

            using( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
            }

            dt.TableName = "CaseTable";
            _ds = new DataSet();
            _ds.Tables.Add( dt );
            _ds.AcceptChanges();
            
            BindingSource binding = new BindingSource( _ds, "CaseTable" );

            this.reportViewer.LocalReport.ReportEmbeddedResource = "county.feecollections.reports.rptBalanceLess100.rdlc";
            this.reportViewer.LocalReport.DataSources.Add( new ReportDataSource( "DataSet_vw_AccntStatus", binding ) );

        }
        #endregion

        #region private void LoadCollectionsBreakdownReport()
        private void LoadCollectionsBreakdownReport()
        {

            // check report parameters
            if( DateTime.Parse( ucCriteriaCollectionsBreakdown.FromDate.ToShortDateString() ) > DateTime.Parse( ucCriteriaCollectionsBreakdown.ToDate.ToShortDateString() ) )
            {
                MessageBox.Show( this, "From Date can not be greater than the To Date.", "Probation Report", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            DataTable dt = new DataTable();

            const string sql = "Report_CollectionsBreakdown";

            using( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( sql, con ) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add( "@fromdate", SqlDbType.DateTime ).Value = ucCriteriaCollectionsBreakdown.FromDate;
                cmd.Parameters.Add( "@todate", SqlDbType.DateTime ).Value = ucCriteriaCollectionsBreakdown.ToDate;

                dt = DBSettings.ExecuteDataAdapter( this.GetType().ToString(), cmd );
            }

            dt.TableName = "PaymentsTable";
            _ds = new DataSet();
            _ds.Tables.Add( dt );
            _ds.AcceptChanges();

            BindingSource binding = new BindingSource( _ds, "PaymentsTable" );
            ReportParameter[] parameters = new ReportParameter[] { new ReportParameter( "FromDate", ucCriteriaCollectionsBreakdown.FromDate.ToString( "d" ) ), new ReportParameter( "ToDate", ucCriteriaCollectionsBreakdown.ToDate.ToString( "d" ) ) };

            this.reportViewer.LocalReport.ReportEmbeddedResource = "county.feecollections.reports.rptCollectionsBreakdown.rdlc";
            this.reportViewer.LocalReport.DataSources.Add( new ReportDataSource( "DataSet_AllPayments", binding ) );
            this.reportViewer.LocalReport.SetParameters( parameters );

        } 
        #endregion

        #region private void CollectionsBreakdownReport_SubReportProcessing( object sender, SubreportProcessingEventArgs e )
        private void CollectionsBreakdownReport_SubReportProcessing( object sender, SubreportProcessingEventArgs e )
        {

            System.Data.DataSet ds = new System.Data.DataSet();
            BindingSource binding = new BindingSource();

            if( e.ReportPath.Equals( "rptCollectionsBreakdownPlans" ) )
            {

                ds.Tables.Add( _ds.Tables["PlanTable"].Clone() );

                // retreiving cases related to current defendant
                int defendantId = Int32.Parse( e.Parameters["defendantId"].Values[0] );
                DataRow[] drs = _ds.Tables["PlanTable"].Select( "defendantid = " + defendantId.ToString() );
                if( drs.Length > 0 )
                {
                    for( int i = 0; i < drs.Length; i++ )
                        ds.Tables["PlanTable"].Rows.Add( drs[i].ItemArray );
                }

                binding.DataMember = "PlanTable";
                binding.DataSource = ds;
                e.DataSources.Add( new ReportDataSource( "DataSet_DefendantPlans", binding ) );

            }
            else if( e.ReportPath.Equals( "rptCollectionsBreakdownPayments" ) )
            {

                ds.Tables.Add( _ds.Tables["PaymentsTable"].Clone() );

                // retreiving cases related to current defendant
                int defendantId = Int32.Parse( e.Parameters["defendantId"].Values[0] );
                int planId = Int32.Parse( e.Parameters["planId"].Values[0] );

                DataRow[] drs = _ds.Tables["PaymentsTable"].Select( "defendantid = " + defendantId.ToString() + " AND planid = " + planId.ToString() );
                if( drs.Length > 0 )
                {
                    for( int i = 0; i < drs.Length; i++ )
                        ds.Tables["PaymentsTable"].Rows.Add( drs[i].ItemArray );
                }

                binding.DataMember = "PaymentsTable";
                binding.DataSource = ds;
                e.DataSources.Add( new ReportDataSource( "DataSet_DefendantPayments", binding ) );

            }

        } 
        #endregion




        #region private void caseClms_SubReportProcessing( object sender, SubreportProcessingEventArgs e )
        private void caseClms_SubReportProcessing( object sender, SubreportProcessingEventArgs e )
        {

            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Tables.Add( _ds.Tables["CaseTable"].Clone() );

            // getting report paramenter
            int defendantId = Int32.Parse( e.Parameters["defendantId"].Values[0] );

            // retreiving cases related to current defendant
            DataRow[] drs = _ds.Tables["CaseTable"].Select( "defendantid = " + defendantId.ToString() );

            if( drs.Length > 0 )
            {

                // splitting cases into two columns
                int splitidx = (int)Math.Round( (drs.Length / 2.0), MidpointRounding.AwayFromZero );
                if( e.ReportPath.Equals( "rptCaseClm1" ) )
                {
                    for( int i = 0; i < drs.Length; i++ )
                        if( i < splitidx )
                            ds.Tables["CaseTable"].Rows.Add( drs[i].ItemArray );
                }
                else if( e.ReportPath.Equals( "rptCaseClm2" ) )
                {
                    for( int i = 0; i < drs.Length; i++ )
                        if( i >= splitidx )
                            ds.Tables["CaseTable"].Rows.Add( drs[i].ItemArray );
                }

            }

            BindingSource caseclm = new BindingSource();
            caseclm.DataMember = "CaseTable";
            caseclm.DataSource = ds;

            e.DataSources.Add( new ReportDataSource( "DataSet_PlanCase", caseclm ) );

        } 
        #endregion

        #region private void LocalReport_SubreportProcessing( object sender, SubreportProcessingEventArgs e )
        private void LocalReport_SubreportProcessing( object sender, SubreportProcessingEventArgs e )
        {

            if( ((LocalReport)sender).ReportEmbeddedResource == "county.feecollections.reports.rptProbation.rdlc" )
            {
                if( e.ReportPath.Equals( "rptCaseClm1" ) || e.ReportPath.Equals( "rptCaseClm2" ) )
                {
                    caseClms_SubReportProcessing( sender, e );
                }

            }
            else if( ((LocalReport)sender).ReportEmbeddedResource == "county.feecollections.reports.rptCollectionsBreakdown.rdlc" )
            {

                if( e.ReportPath.Equals( "rptCollectionsBreakdownPlans" ) || e.ReportPath.Equals( "rptCollectionsBreakdownPayments" ) )
                {
                    CollectionsBreakdownReport_SubReportProcessing( sender, e );
                }

            }

        }  
        #endregion




    }
}
