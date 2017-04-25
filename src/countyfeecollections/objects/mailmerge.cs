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
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.Office.Interop.Word;

namespace county.feecollections
{

    public class MailMerge
    {
        private static object _objMissing = System.Reflection.Missing.Value;
        private static object _objTrue = true;
        private static object _objFalse = false;

        public static void CreateMergeFieldsTreeView( ref TreeView trv )
        {
            TreeNode planNode;
            TreeNode feeNode;
            TreeNode node;

            trv.Nodes.Clear();

            // node defendant
            trv.Nodes.Add( "Full Name" );
            trv.Nodes.Add( "First Name" );
            trv.Nodes.Add( "Middle Name" );
            trv.Nodes.Add( "Last Name" );
            trv.Nodes.Add( "AKA" );
            trv.Nodes.Add( "SSN" );
            trv.Nodes.Add( "Birth Date" );
            trv.Nodes.Add( "Driver License" );
            trv.Nodes.Add( "Full Address" );
            trv.Nodes.Add( "Street1" );
            trv.Nodes.Add( "Street2" );
            trv.Nodes.Add( "City" );
            trv.Nodes.Add( "State" );
            trv.Nodes.Add( "Zip" );
            trv.Nodes.Add( "Home Phone" );
            trv.Nodes.Add( "Mobile Phone" );
            trv.Nodes.Add( "Probation Officer" );
            trv.Nodes.Add("Days In Jail");
            trv.Nodes.Add("Booking Number");
            //trv.Nodes.Add("Has Judgment Filed");
            trv.Nodes.Add("Date Of Judgment");
            trv.Nodes.Add("Judgment Filed Date");
            //trv.Nodes.Add("In Bankruptcy");
            trv.Nodes.Add("Bankruptcy Date Filed");
            trv.Nodes.Add("Bankruptcy End Date");

            // node current employer
            node = new TreeNode( "Current Employer" );
            node.Nodes.Add( "Employer Name" );
            node.Nodes.Add( "Employer Street1" );
            node.Nodes.Add( "Employer Street2" );
            node.Nodes.Add( "Employer City" );
            node.Nodes.Add( "Employer State" );
            node.Nodes.Add( "Employer Zip" );
            // node.Nodes.Add( "Employer Phone" ); <-- commented out to make from for Jail Admin cost and Jail Medical, see also CAPP
            trv.Nodes.Add( node );
            
            // node plan
            planNode = new TreeNode( "Plan" );
            planNode.Nodes.Add( "Plan Name" );
            planNode.Nodes.Add( "Plan Remaining Balance" );

            // node payment arrangements
            node = new TreeNode( "Payment Arrangements" );
            node.Nodes.Add( "Payment Arrangement Pay Period" );
            node.Nodes.Add( "Payment Arrangement Type" );
            node.Nodes.Add( "Payment Arrangement Amount" );
            node.Nodes.Add( "Payment Arrangement Start Date" );
            node.Nodes.Add( "Payment Arrangement End Date" );
            planNode.Nodes.Add( node );
            
            // node cases
            node = new TreeNode( "Cases" );
            node.Nodes.Add( "Case Name" );
            node.Nodes.Add( "Case County" );
            node.Nodes.Add( "Case CAPP" );
            node.Nodes.Add( "Case Committed" );
            planNode.Nodes.Add( node );

            // node cases
            node = new TreeNode( "CAPP Cases" );
            node.Nodes.Add( "CAPP Case Name" );
            node.Nodes.Add( "CAPP Case County" );
            node.Nodes.Add( "CAPP Case CAPP" );
            // node.Nodes.Add( "CAPP Case Committed" ); commented out to make room for "Jail Admin cost" and "Jail Medical"
            planNode.Nodes.Add( node );

            // node cases
            node = new TreeNode( "NonCAPP Cases" );
            node.Nodes.Add( "NonCAPP Case Name" );
            node.Nodes.Add( "NonCAPP Case County" );
            node.Nodes.Add( "NonCAPP Case CAPP" );
            node.Nodes.Add( "NonCAPP Case Committed" );
            planNode.Nodes.Add( node );

            // node fees
            feeNode = new TreeNode( "Fees" );
            feeNode.Nodes.Add( "Fees Total Due" );
            feeNode.Nodes.Add("Civil Penalties");
            feeNode.Nodes.Add("Restitution");
            feeNode.Nodes.Add("Court Fines");
            feeNode.Nodes.Add("Jail Room And Board");
            feeNode.Nodes.Add("Jail Admin cost");
            feeNode.Nodes.Add("Jail Medical");

            // node fee type
            node = new TreeNode( "Fee Type" );
            node.Nodes.Add( "Fee Type Amount" );
            feeNode.Nodes.Add( node );

            planNode.Nodes.Add( feeNode );
            trv.Nodes.Add( planNode );
        }

        /// <summary>
        /// Gets a DataTable of templates in the user's store directory.
        /// </summary>
        public static System.Data.DataTable MailMergeTemplates
        {
            get
            {
                System.Data.DataTable dt = new System.Data.DataTable( "MailMerge" );
                dt.Columns.Add( "TemplateName" );
                dt.Columns.Add( "TemplatePath" );
                dt.Columns.Add( "LastWrittenTo" );

                LocalUser user = new LocalUser();

                if( StoreDirectoryConfigured() && StoreDirectoryExists() )
                {

                    DirectoryInfo dir = new DirectoryInfo( user.MailMergeDirectory );
                    FileInfo[] wrdFiles = dir.GetFiles( "*.doc" );

                    foreach( FileInfo file in wrdFiles )
                    {
                        DataRow dr = dt.NewRow();
                        dr["TemplateName"] = file.Name;
                        dr["TemplatePath"] = file.FullName;
                        dr["LastWrittenTo"] = file.LastWriteTime;
                        dt.Rows.Add( dr );
                    }

                    dt.AcceptChanges();
                }
                return dt;
            }
        }

        /// <summary>
        /// Copies a stored template to the user's temp path using a random file name.
        /// </summary>
        /// <param name="templatePath">The full path of a stored template file.</param>
        /// <returns>
        /// if the store directory is initialized, a FileInfo object bound to a template in the user's temp directory;
        /// otherwise null.
        /// </returns>
        public static FileInfo CopyTempStoredMailMergeFile( string storedTemplatePath )
        {
            FileInfo tempFileFullPath = null;

            if( StoreDirectoryConfigured() && StoreDirectoryExists() )
            {
                FileInfo storedTemplate = new FileInfo( storedTemplatePath );
                
                // copying template with the temp directory
                    tempFileFullPath = storedTemplate.CopyTo( Path.Combine( Path.GetTempPath(), storedTemplate.Name ), true );
            }
            return tempFileFullPath;
        }

        /// <summary>
        /// Stores the specified template with the specified name.
        /// </summary>
        /// <param name="newTemplateName">A unique template file name (without an extension).</param>
        /// <param name="templatePath">The full path of a template file.</param>
        public static void StoreTemplate( string newTemplateName, string templatePath )
        {
            if( StoreDirectoryConfigured() && StoreDirectoryExists() )
            {
                FileInfo template = new FileInfo( templatePath );
                FileInfo newTemplate = template.CopyTo( Path.Combine( (new LocalUser()).MailMergeDirectory, newTemplateName ) + template.Extension, true );
            }
        }

        /// <summary>
        /// Gets a value indicating whether a file exists.
        /// </summary>
        /// <param name="templateName">A template file name (without an extension).</param>
        /// <returns>true if the template exists; otherwise false.</returns>
        public static bool TemplateExists( string templateName )
        {
            bool rtnValue = false;

            if( StoreDirectoryConfigured() && StoreDirectoryExists() )
            {
                DirectoryInfo di = new DirectoryInfo( (new LocalUser()).MailMergeDirectory );
                FileInfo[] templates = di.GetFiles( "*.doc" );

                foreach( FileInfo template in templates )
                {
                    if( template.Name.Remove( template.Name.LastIndexOf( '.' ) ) == templateName )
                    {
                        rtnValue = true;
                        break;
                    }
                }
            }
            return rtnValue;
        }

        /// <summary>
        /// Gets a value indicating whether the user's stored directory path has been configured.
        /// </summary>
        /// <returns>true if the stored directory has been configured; otherwise false.</returns>
        public static bool StoreDirectoryConfigured()
        {
            return !string.IsNullOrEmpty( (new LocalUser()).MailMergeDirectory );
        }

        /// <summary>
        /// Gets a value indicating whether the user's stored directory path exists.
        /// </summary>
        /// <returns>true if the stored directory exists; otherwise false.</returns>
        public static bool StoreDirectoryExists()
        {
            return Directory.Exists( (new LocalUser()).MailMergeDirectory );
        }

        /// <summary>
        /// Permanently deletes a stored template.
        /// </summary>
        /// <param name="templatePath">The full path of a stored template file.</param>
        /// <returns>true if the template was deleted; otherwise false.</returns>
        public static bool DeleteTemplate( string templatePath )
        {
            bool rtnValue = false;

            if( File.Exists( templatePath ) )
            {
                try
                {
                    File.Delete( templatePath );
                    rtnValue = true;
                }
                catch( Exception ex )
                {
                    MyExceptionManager.Log( ex );
                    return false;
                }
            }

            return rtnValue;
        }

        public static void PerformMailMerge( int defendantId, int planId, string templatePath )
        {
            Document wrdDoc;
            Document wrdDataSource;

            // create copy of template in temp dir
            object tempTemplatePath = CopyTempStoredMailMergeFile( templatePath ).FullName;

            // opening ms word
            Microsoft.Office.Interop.Word.Application wrdApp = new Microsoft.Office.Interop.Word.Application();

            // Create a MailMerge Data file.     
            wrdDataSource = CreateMailMergeDataFile( wrdApp );
            wrdDataSource.Activate();
            wrdDataSource.Select();

            // fill the table of fields with data.
            FillDataSource( CreateDataSource( wrdDataSource, wrdApp.Selection ), defendantId, planId );
            wrdDataSource.Save();

            string strDataSourcePath = wrdDataSource.FullName;
            ((_Document)wrdDataSource).Close( ref _objFalse, ref _objMissing, ref _objMissing );

            //opening up original doc
            wrdDoc = wrdApp.Documents.Open( ref tempTemplatePath, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                 ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objFalse,
                 ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );

            wrdDoc.MailMerge.OpenDataSource( strDataSourcePath, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );

            // Perform mail merge
            wrdDoc.MailMerge.Destination = WdMailMergeDestination.wdSendToNewDocument;
            wrdDoc.MailMerge.Execute( ref _objFalse );

            wrdDoc.Saved = true;

            ((_Document)wrdDoc).Close( ref _objFalse, ref _objMissing, ref _objMissing );

            wrdDoc = null;

            // still need to kill the temp file created for the datasource
            if( File.Exists( tempTemplatePath.ToString() ) )
                File.Delete( tempTemplatePath.ToString() );

            wrdApp.Visible = true;
        } 

        public static void PreviewMailMerge( Microsoft.Office.Interop.Word.Application wrdApp )
        {
            Document wrdDoc = wrdApp.ActiveDocument;
            Document wrdDataSource;

            object strOriginalTemplatePath = wrdApp.ActiveDocument.FullName;
            object strTempTemplatePath = Path.Combine( Path.GetTempPath(), Path.GetRandomFileName() );

            // making sure document to be previewed has been saved.
            try
            {
                wrdDoc.Save();
            }
            catch
            {
                return;
            }

            // closing doc and making a copy 
            ((_Document)wrdDoc).Close( ref _objFalse, ref _objMissing, ref _objMissing );
            FileInfo file = new FileInfo( strOriginalTemplatePath.ToString() );
            file.CopyTo( strTempTemplatePath.ToString() );

            // opening original file and temp file
            wrdDoc = wrdApp.Documents.Open( ref strOriginalTemplatePath, ref _objMissing, ref _objMissing, ref _objMissing,
                ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                ref _objMissing, ref _objTrue, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );

            wrdDoc = wrdApp.Documents.Open( ref strTempTemplatePath, ref _objMissing, ref _objMissing, ref _objMissing,
                ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                ref _objMissing, ref _objFalse, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );

            wrdDoc.Activate();

            // Create a MailMerge Data file.     
            wrdDataSource = CreateMailMergeDataFile( wrdApp );
            wrdDataSource.Activate();
            wrdDataSource.Select();

            // fill the table of fields with data.
            FillPreviewSource( CreateDataSource( wrdDataSource, wrdApp.Selection ) );

            wrdDataSource.Save();
            strTempTemplatePath = wrdDataSource.FullName;
            ((_Document)wrdDataSource).Close( ref _objFalse, ref _objMissing, ref _objMissing );

            wrdDoc.MailMerge.OpenDataSource( strTempTemplatePath.ToString(), ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                    ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                    ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );

            // Perform mail merge
            wrdDoc.MailMerge.Destination = WdMailMergeDestination.wdSendToNewDocument;
            wrdDoc.MailMerge.Execute( ref _objFalse );

            wrdDoc.Saved = true;

            ((_Document)wrdDoc).Close( ref _objFalse, ref _objMissing, ref _objMissing );

            wrdDoc = null;

            // still need to kill the temp file created for the datasource
            if( File.Exists( strTempTemplatePath.ToString() ) )
                File.Delete( strTempTemplatePath.ToString() );
        }

        private static Document CreateMailMergeDataFile( Microsoft.Office.Interop.Word.Application wrdApp )
        {
            // open a new document with Documents.Add
            Document wrdDoc = wrdApp.Documents.Add( ref _objMissing, ref _objMissing, ref _objMissing, ref _objFalse );
            wrdDoc.Select();
            Selection wrdSelection = wrdApp.Selection;

            object tempFilePath = Path.Combine( Path.GetTempPath(), Path.GetRandomFileName() );
            wrdDoc.SaveAs( ref tempFilePath, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                    ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing,
                    ref _objMissing, ref _objMissing, ref _objMissing, ref _objMissing );

            return wrdDoc;
        }

        private static Table CreateDataSource( Document wordDoc, Selection wordSel )
        {
            // creating table to store merge field data.
            Table wrdTable = wordDoc.Tables.Add( wordSel.Range, 2, 63, ref _objMissing, ref _objMissing );

            wrdTable.Cell( 1, 1 ).Range.InsertAfter( "First_Name" );
            wrdTable.Cell( 1, 2 ).Range.InsertAfter( "Middle_Name" );
            wrdTable.Cell( 1, 3 ).Range.InsertAfter( "Last_Name" );
            wrdTable.Cell( 1, 4 ).Range.InsertAfter( "AKA" );
            wrdTable.Cell( 1, 5 ).Range.InsertAfter( "SSN" );
            wrdTable.Cell( 1, 6 ).Range.InsertAfter( "Birth_Date" );
            wrdTable.Cell( 1, 7 ).Range.InsertAfter( "Driver_License" );
            wrdTable.Cell( 1, 8 ).Range.InsertAfter( "Street1" );
            wrdTable.Cell( 1, 9 ).Range.InsertAfter( "Street2" );
            wrdTable.Cell( 1, 10 ).Range.InsertAfter( "City" );
            wrdTable.Cell( 1, 11 ).Range.InsertAfter( "State" );
            wrdTable.Cell( 1, 12 ).Range.InsertAfter( "Zip" );
            wrdTable.Cell( 1, 13 ).Range.InsertAfter( "Home_Phone" );
            wrdTable.Cell( 1, 14 ).Range.InsertAfter( "Mobile_Phone" );
            wrdTable.Cell( 1, 15 ).Range.InsertAfter( "Probation_Officer" );
            wrdTable.Cell( 1, 16 ).Range.InsertAfter( "Current_Employer" );
            wrdTable.Cell( 1, 17 ).Range.InsertAfter( "Employer_Name" );
            wrdTable.Cell( 1, 18 ).Range.InsertAfter( "Employer_Street1" );
            wrdTable.Cell( 1, 19 ).Range.InsertAfter( "Employer_Street2" );
            wrdTable.Cell( 1, 20 ).Range.InsertAfter( "Employer_City" );
            wrdTable.Cell( 1, 21 ).Range.InsertAfter( "Employer_State" );
            wrdTable.Cell( 1, 22 ).Range.InsertAfter( "Employer_Zip" );
            wrdTable.Cell( 1, 23 ).Range.InsertAfter( "Employer_Phone" );
            wrdTable.Cell( 1, 24 ).Range.InsertAfter( "Plan" );
            wrdTable.Cell( 1, 25 ).Range.InsertAfter( "Plan_Name" );
            wrdTable.Cell( 1, 26 ).Range.InsertAfter( "Plan_Remaining_Balance" );
            wrdTable.Cell( 1, 27 ).Range.InsertAfter( "Payment_Arrangements" );
            wrdTable.Cell( 1, 28 ).Range.InsertAfter( "Payment_Arrangement_Pay_Period" );
            wrdTable.Cell( 1, 29 ).Range.InsertAfter( "Payment_Arrangement_Type" );
            wrdTable.Cell( 1, 30 ).Range.InsertAfter( "Payment_Arrangement_Amount" );
            wrdTable.Cell( 1, 31 ).Range.InsertAfter( "Payment_Arrangement_Start_Date" );
            wrdTable.Cell( 1, 32 ).Range.InsertAfter( "Payment_Arrangement_End_Date" );
            wrdTable.Cell( 1, 33 ).Range.InsertAfter( "Cases" );
            wrdTable.Cell( 1, 34 ).Range.InsertAfter( "Case_Name" );
            wrdTable.Cell( 1, 35 ).Range.InsertAfter( "Case_County" );
            wrdTable.Cell( 1, 36 ).Range.InsertAfter( "Case_CAPP" );
            wrdTable.Cell( 1, 37 ).Range.InsertAfter( "Case_Committed" );
            wrdTable.Cell( 1, 38 ).Range.InsertAfter( "Fees" );
            wrdTable.Cell( 1, 39 ).Range.InsertAfter( "Fees_Total_Due" );
            wrdTable.Cell( 1, 40 ).Range.InsertAfter( "Fee_Type" );
            wrdTable.Cell( 1, 41 ).Range.InsertAfter( "Fee_Type_Amount" );
            wrdTable.Cell( 1, 42 ).Range.InsertAfter( "Full_Name" );
            wrdTable.Cell( 1, 43 ).Range.InsertAfter( "Full_Address" );

            wrdTable.Cell( 1, 44 ).Range.InsertAfter( "CAPP_Cases" );
            wrdTable.Cell( 1, 45 ).Range.InsertAfter( "CAPP_Case_Name" );
            wrdTable.Cell( 1, 46 ).Range.InsertAfter( "CAPP_Case_County" );
            wrdTable.Cell( 1, 47 ).Range.InsertAfter( "CAPP_Case_CAPP" );
            wrdTable.Cell( 1, 48 ).Range.InsertAfter( "CAPP_Case_Committed" );

            wrdTable.Cell( 1, 49 ).Range.InsertAfter( "NonCAPP_Cases" );
            wrdTable.Cell( 1, 50 ).Range.InsertAfter( "NonCAPP_Case_Name" );
            wrdTable.Cell( 1, 51 ).Range.InsertAfter( "NonCAPP_Case_County" );
            wrdTable.Cell( 1, 52 ).Range.InsertAfter( "NonCAPP_Case_CAPP" );
            wrdTable.Cell( 1, 53 ).Range.InsertAfter( "NonCAPP_Case_Committed" );
            wrdTable.Cell(1, 54).Range.InsertAfter("Court_Fines");
            wrdTable.Cell(1, 55).Range.InsertAfter("Restitution");
            wrdTable.Cell(1, 56).Range.InsertAfter("Civil_Penalties");
            wrdTable.Cell(1, 57).Range.InsertAfter("Jail_Room_And_Board");

            wrdTable.Cell(1, 58).Range.InsertAfter("Days_In_Jail");
            wrdTable.Cell(1, 59).Range.InsertAfter("Booking_Number");
            //wrdTable.Cell(1, 60).Range.InsertAfter("Has_Judgment_Filed");
            wrdTable.Cell(1, 60).Range.InsertAfter("Date_Of_Judgment");
            wrdTable.Cell(1, 61).Range.InsertAfter("Judgment_Filed_Date");
            //wrdTable.Cell(1, 63).Range.InsertAfter("In_Bankruptcy");
            wrdTable.Cell(1, 62).Range.InsertAfter("Bankruptcy_Date_Filed");
            wrdTable.Cell(1, 63).Range.InsertAfter("Bankruptcy_End_Date");

            wordDoc.Save();
            return wrdTable;
        }

        private static void FillDataSource( Table wrdTable, int defendantId, int planId )
        {
            string sql0 =
  "        SELECT  TOP 1 firstname, middlename, lastname, aka, ssn, birthdate, driverslicense,  "
+ "		           Defendant.street1, Defendant.street2, Defendant.city, a.abbreviation AS [state], Defendant.zip, phonehome, phonemobile, probationofficer, "
+ "		           Employer.employername, Employer.Street1 AS employer_street1, Employer.Street2 AS employer_street2, Employer.City AS employer_city, "
+ "		           b.abbreviation AS employer_state, Employer.Zip AS employer_zip, Employer.Phone AS employer_phone, "
+ "		           planname, "
+ "				   ( "
+ "           SELECT SUM(total) AS balance "
+ "		        FROM  "
+ "			         ( "
+ "	           SELECT SUM(amount) AS total "
+ "			     FROM PlanFee "
+ "   LEFT OUTER JOIN FeeTypes ON PlanFee.feetypeid = FeeTypes.feetypeid "
+ "             WHERE FeeTypes.billable = 1 "
+ "                   AND PlanFee.defendantid = @defendantId "
+ "	                  AND PlanFee.planid = @planId "
+ "			    UNION "
+ "			   SELECT -SUM(amount) AS total "
+ "		         FROM FeePayment "
+ "   LEFT OUTER JOIN FeeTypes ON FeePayment.feetypeid = FeeTypes.feetypeid "
+ "             WHERE FeeTypes.billable = 1 "
+ "  					AND FeePayment.defendantid = @defendantId "
+ "  					AND FeePayment.planid = @planId "
+ "  				 ) AS TransactionTotals "

+ "	  			   ) AS plan_remaining_balance, "
+ "                payperiodtype, paymentarrangementtype, PlanPaymentArrangement.amount as payment_arrangement_amount, "
+ "                startdate, enddate, daysinjail, bookingnumber, judgmentdate, judgmentfileddate, bankruptcydatefiled, bankruptcyenddate "
+ "           FROM Defendant "
+ "LEFT OUTER JOIN States a ON Defendant.stateid = a.stateid "
+ "LEFT OUTER JOIN DefendantEmployers ON Defendant.defendantid = DefendantEmployers.defendantid AND SeparationDate IS NULL "
+ "LEFT OUTER JOIN Employer ON DefendantEmployers.employerid = Employer.employerid "
+ "LEFT OUTER JOIN States b ON Employer.stateid = b.stateid "
+ "LEFT OUTER JOIN DefendantPlans ON Defendant.defendantid = DefendantPlans.defendantid "
+ "LEFT OUTER JOIN PlanPaymentArrangement ON Defendant.defendantid = PlanPaymentArrangement.defendantid AND DefendantPlans.planid = PlanPaymentArrangement.planid "
+ "LEFT OUTER JOIN PayPeriodTypes ON PlanPaymentArrangement.payperiodtypeid = PayPeriodTypes.payperiodtypeid "
+ "LEFT OUTER JOIN PaymentArrangementTypes ON PlanPaymentArrangement.paymentarrangementtypeid = PaymentArrangementTypes.paymentarrangementtypeid "
+ " 		 WHERE Defendant.defendantid = @defendantId "
+ "				   AND DefendantPlans.planid = @planId "
+ "       ORDER BY enddate DESC;";

            string sql1 = "SELECT casename, county, "
		        + "CASE capp "
			    + "WHEN 1 THEN 'yes' ELSE 'no' "
		        + "END as capp, "
		        + "CASE [Committed] "
			    + "WHEN 1 THEN 'yes' ELSE 'no' "
		        + "END as [committed] "
                + "FROM PlanCase "
                + "LEFT OUTER JOIN IowaCounty ON PlanCase.countyid = IowaCounty.countyid "
                + "WHERE defendantid = @defendantId "
                + "AND planid = @planId";

            string sql2 = "SELECT feetype, amount AS fee_type_amount "
                + "FROM PlanFee "
                + "LEFT OUTER JOIN FeeTypes ON PlanFee.feetypeid = FeeTypes.feetypeid "
                + "WHERE defendantid = @defendantId  "
                + "AND planid = @planId; ";

            string sql3 = "SELECT SUM(CourtFines) AS CourtFines, SUM(Restitution) AS Restitution, "
                    + "SUM(CivilPenalties) AS CivilPenalties, SUM(JailRoomAndBoard) AS JailRoomAndBoard FROM "
                    + "(SELECT "
	                + "CASE feetypeid "
		            + "WHEN 19 THEN amount "
		            + "ELSE 0.00 "
                    + "END AS CourtFines, "
	                + "Case feetypeid "
		            + "WHEN 20 THEN amount "
		            + "ELSE 0.00 "
	                + "END AS Restitution, "
	                + "Case feetypeid "
		            + "WHEN 21 THEN amount "
		            + "ELSE 0.00 "
	                + "END AS CivilPenalties, "
	                + "Case feetypeid "
		            + "WHEN 22 THEN amount "
		            + "ELSE 0.00 "
	                + "END AS JailRoomAndBoard "
                    + "FROM PlanFee WHERE defendantid = @defendantId AND planid = @planId) AS FeeBreakDown";


            DataSet ds = new DataSet();

            DateTime tempDate;
            string tempStr;
            
            using( SqlConnection con = DBSettings.NewSqlConnectionClosed )
            using( SqlCommand cmd = new SqlCommand( sql0, con ) )
            {
                System.Data.DataTable dt = new System.Data.DataTable();

                cmd.Parameters.Add( "@defendantId", SqlDbType.Int ).Value = defendantId;
                cmd.Parameters.Add( "@planId", SqlDbType.Int ).Value = planId;

                // general defendant
                dt = DBSettings.ExecuteDataAdapter( "MailMerge", cmd );
                dt.TableName = "General";
                ds.Tables.Add( dt.Copy() );

                // cases
                cmd.CommandText = sql1;
                dt = DBSettings.ExecuteDataAdapter( "MailMerge", cmd );
                dt.TableName = "Cases";
                ds.Tables.Add( dt.Copy() );

                // fees
                cmd.CommandText = sql2;
                dt = DBSettings.ExecuteDataAdapter( "MailMerge", cmd );
                dt.TableName = "Fees";
                ds.Tables.Add( dt.Copy() );

                // test
                cmd.CommandText = sql3;
                dt = DBSettings.ExecuteDataAdapter("MailMerge", cmd);
                dt.TableName = "FeeBreakDown";
                ds.Tables.Add(dt.Copy());

                dt.Dispose();
            }

            wrdTable.Cell( 2, 1 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["firstname"].ToString() );
            wrdTable.Cell( 2, 2 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["middlename"].ToString() );
            wrdTable.Cell( 2, 3 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["lastname"].ToString() );
            wrdTable.Cell( 2, 4 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["aka"].ToString() );
            wrdTable.Cell( 2, 5 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["ssn"].ToString() );
            if( DateTime.TryParse(ds.Tables["General"].Rows[0]["birthdate"].ToString(), out tempDate ) )
            {
                wrdTable.Cell( 2, 6 ).Range.InsertAfter( tempDate.ToString( "d" ) );
            }
            wrdTable.Cell( 2, 7 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["driverslicense"].ToString() );
            wrdTable.Cell( 2, 8 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["street1"].ToString() );
            wrdTable.Cell( 2, 9 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["street2"].ToString() );
            wrdTable.Cell( 2, 10 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["city"].ToString() );
            wrdTable.Cell( 2, 11 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["state"].ToString() );
            wrdTable.Cell( 2, 12 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["zip"].ToString() );
            wrdTable.Cell( 2, 13 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["phonehome"].ToString() );
            wrdTable.Cell( 2, 14 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["phonemobile"].ToString() );
            wrdTable.Cell( 2, 15 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["probationofficer"].ToString() );

            // creating employer full address field
            tempStr = "";

            if( !string.IsNullOrEmpty(ds.Tables["General"].Rows[0]["employername"].ToString() ) )
            {
                tempStr += ds.Tables["General"].Rows[0]["employername"].ToString() + "\n";
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["employer_street1"].ToString() ) )
            {
                tempStr += ds.Tables["General"].Rows[0]["employer_street1"].ToString() + "\n";
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["employer_street2"].ToString() ) )
            {
                tempStr += ds.Tables["General"].Rows[0]["employer_street2"].ToString() + "\n";
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["employer_city"].ToString() ) )
            {
                tempStr += ds.Tables["General"].Rows[0]["employer_city"].ToString();
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["employer_city"].ToString() ) && !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["employer_state"].ToString() ) )
            {
                tempStr += ",";
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["employer_state"].ToString() ) )
            {
                tempStr += ds.Tables["General"].Rows[0]["employer_state"].ToString();
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["employer_zip"].ToString() ) )
            {
                tempStr += ds.Tables["General"].Rows[0]["employer_zip"].ToString();
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["employer_phone"].ToString() ) )
            {
                tempStr += "\n" + ds.Tables["General"].Rows[0]["employer_phone"].ToString();
            }

            wrdTable.Cell( 2, 16 ).Range.InsertAfter( tempStr );
            wrdTable.Cell( 2, 17 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["employername"].ToString() );
            wrdTable.Cell( 2, 18 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["employer_street1"].ToString() );
            wrdTable.Cell( 2, 19 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["employer_street2"].ToString() );
            wrdTable.Cell( 2, 20 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["employer_city"].ToString() );
            wrdTable.Cell( 2, 21 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["employer_state"].ToString() );
            wrdTable.Cell( 2, 22 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["employer_zip"].ToString() );
            wrdTable.Cell( 2, 23 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["employer_phone"].ToString() );

            tempStr = "";
            tempStr += ds.Tables["General"].Rows[0]["planname"].ToString();

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["plan_remaining_balance"].ToString() ) )
            {
                tempStr += "\t\t" + Convert.ToDouble( ds.Tables["General"].Rows[0]["plan_remaining_balance"]).ToString( "c2" );
                wrdTable.Cell( 2, 26 ).Range.InsertAfter( Convert.ToDouble( ds.Tables["General"].Rows[0]["plan_remaining_balance"] ).ToString( "c2" ) );
            }
            
            wrdTable.Cell( 2, 24 ).Range.InsertAfter(  tempStr );
            wrdTable.Cell( 2, 25 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["planname"].ToString() );

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["plan_remaining_balance"].ToString() ) )
            {
                tempStr += "\t\t" + Convert.ToDouble( ds.Tables["General"].Rows[0]["plan_remaining_balance"] ).ToString( "c2" );
            }

            // enter pay periods
            if (!string.IsNullOrEmpty(ds.Tables["General"].Rows[0]["payperiodtype"].ToString()) &&
                !string.IsNullOrEmpty(ds.Tables["General"].Rows[0]["paymentarrangementtype"].ToString()) &&
                !string.IsNullOrEmpty(ds.Tables["General"].Rows[0]["payment_arrangement_amount"].ToString()))
            {
                tempStr = ds.Tables["General"].Rows[0]["payperiodtype"].ToString()
                    + "\t" + ds.Tables["General"].Rows[0]["paymentarrangementtype"].ToString()
                    + "\t" + Convert.ToDouble( ds.Tables["General"].Rows[0]["payment_arrangement_amount"] ).ToString( "c2" );
                wrdTable.Cell(2, 28).Range.InsertAfter(ds.Tables["General"].Rows[0]["payperiodtype"].ToString());
                wrdTable.Cell(2, 29).Range.InsertAfter(ds.Tables["General"].Rows[0]["paymentarrangementtype"].ToString());
                wrdTable.Cell(2, 30).Range.InsertAfter(Convert.ToDouble(ds.Tables["General"].Rows[0]["payment_arrangement_amount"]).ToString("c2"));
            }
            
            if( DateTime.TryParse( ds.Tables["General"].Rows[0]["startdate"].ToString(), out tempDate ) )
            {
                wrdTable.Cell( 2, 31 ).Range.InsertAfter( tempDate.ToString( "d" ) );
                tempStr += "\t" + tempDate.ToString( "d" ) ;
            }
            if( DateTime.TryParse( ds.Tables["General"].Rows[0]["enddate"].ToString(), out tempDate ) )
            {
                wrdTable.Cell( 2, 32 ).Range.InsertAfter( tempDate.ToString( "d" ) );
                tempStr += "\t" + tempDate.ToString( "d" );
            }
            wrdTable.Cell( 2, 27 ).Range.InsertAfter( tempStr );

            // building string for all defendant cases; also buidling strings separated by CAPP and NonCAPP case types
            StringBuilder strPlanCasesDetail = new StringBuilder();
            StringBuilder strPlanCases = new StringBuilder();
            StringBuilder strCaseCounties = new StringBuilder();
            StringBuilder strCaseCAPP = new StringBuilder();
            StringBuilder strCaseCommitted = new StringBuilder();
            StringBuilder strCaseNotCommitted = new StringBuilder();
            //StringBuilder strCaseAll = new StringBuilder();

            StringBuilder strCAPP_PlanCasesDetail = new StringBuilder();
            StringBuilder strCAPP_PlanCases = new StringBuilder();
            StringBuilder strCAPP_CaseCounties = new StringBuilder();
            StringBuilder strCAPP_CaseCAPP = new StringBuilder();
            StringBuilder strCAPP_CaseCommitted = new StringBuilder();
            StringBuilder strCAPP_CaseNotCommitted = new StringBuilder();

            StringBuilder strNonCAPP_PlanCasesDetail = new StringBuilder();
            StringBuilder strNonCAPP_PlanCases = new StringBuilder();
            StringBuilder strNonCAPP_CaseCounties = new StringBuilder();
            StringBuilder strNonCAPP_CaseCAPP = new StringBuilder();
            StringBuilder strNonCAPP_CaseCommitted = new StringBuilder();
            StringBuilder strNonCAPP_CaseNotCommitted = new StringBuilder();

            foreach( DataRow dr in ds.Tables["Cases"].Rows )
            {
                strPlanCases.Append( dr["casename"].ToString() + "\n" );
                strCaseCounties.Append( dr["county"].ToString() + "\n" );
                strCaseCAPP.Append( dr["capp"].ToString() + "\n" );
                strCaseCommitted.Append( dr["committed"].ToString() + "\n" );

                strPlanCasesDetail.Append( dr["casename"].ToString() + "\t" );
                strPlanCasesDetail.Append( dr["county"].ToString() + "\t" );
                strPlanCasesDetail.Append( dr["capp"].ToString() + "\t" );
                strPlanCasesDetail.Append( dr["committed"].ToString() + "\n" );

                if( dr["capp"].ToString().ToLower() == "yes" )
                {
                    strCAPP_PlanCases.Append( dr["casename"].ToString() + "\n" );
                    strCAPP_CaseCounties.Append( dr["county"].ToString() + "\n" );
                    strCAPP_CaseCAPP.Append( dr["capp"].ToString() + "\n" );
                    strCAPP_CaseCommitted.Append( dr["committed"].ToString() + "\n" );

                    strCAPP_PlanCasesDetail.Append( dr["casename"].ToString() + "\t" );
                    strCAPP_PlanCasesDetail.Append( dr["county"].ToString() + "\t" );
                    strCAPP_PlanCasesDetail.Append( dr["capp"].ToString() + "\t" );
                    strCAPP_PlanCasesDetail.Append( dr["committed"].ToString() + "\n" );
                }
                else if( dr["capp"].ToString().ToLower() == "no" )
                {
                    strNonCAPP_PlanCases.Append( dr["casename"].ToString() + "\n" );
                    strNonCAPP_CaseCounties.Append( dr["county"].ToString() + "\n" );
                    strNonCAPP_CaseCAPP.Append( dr["capp"].ToString() + "\n" );
                    strNonCAPP_CaseCommitted.Append( dr["committed"].ToString() + "\n" );

                    strNonCAPP_PlanCasesDetail.Append( dr["casename"].ToString() + "\t" );
                    strNonCAPP_PlanCasesDetail.Append( dr["county"].ToString() + "\t" );
                    strNonCAPP_PlanCasesDetail.Append( dr["capp"].ToString() + "\t" );
                    strNonCAPP_PlanCasesDetail.Append( dr["committed"].ToString() + "\n" );
                }
            }

            wrdTable.Cell( 2, 33 ).Range.InsertAfter( strPlanCasesDetail.ToString() );
            wrdTable.Cell( 2, 34 ).Range.InsertAfter( strPlanCases.ToString() );
            wrdTable.Cell( 2, 35 ).Range.InsertAfter( strCaseCounties.ToString() );
            wrdTable.Cell( 2, 36 ).Range.InsertAfter( strCaseCAPP.ToString() );
            wrdTable.Cell( 2, 37 ).Range.InsertAfter( strCaseCommitted.ToString() );

            wrdTable.Cell( 2, 44 ).Range.InsertAfter( strCAPP_PlanCasesDetail.ToString() );
            wrdTable.Cell( 2, 45 ).Range.InsertAfter( strCAPP_PlanCases.ToString() );
            wrdTable.Cell( 2, 46 ).Range.InsertAfter( strCAPP_CaseCounties.ToString() );
            wrdTable.Cell( 2, 47 ).Range.InsertAfter( strCAPP_CaseCAPP.ToString() );
            wrdTable.Cell( 2, 48 ).Range.InsertAfter( strCAPP_CaseCommitted.ToString() );

            wrdTable.Cell( 2, 49 ).Range.InsertAfter( strNonCAPP_PlanCasesDetail.ToString() );
            wrdTable.Cell( 2, 50 ).Range.InsertAfter( strNonCAPP_PlanCases.ToString() );
            wrdTable.Cell( 2, 51 ).Range.InsertAfter( strNonCAPP_CaseCounties.ToString() );
            wrdTable.Cell( 2, 52 ).Range.InsertAfter( strNonCAPP_CaseCAPP.ToString() );
            wrdTable.Cell( 2, 53 ).Range.InsertAfter( strNonCAPP_CaseCommitted.ToString() );
            wrdTable.Cell(2, 54).Range.InsertAfter("$" + ds.Tables["FeeBreakDown"].Rows[0]["CourtFines"].ToString());
            wrdTable.Cell(2, 55).Range.InsertAfter("$" + ds.Tables["FeeBreakDown"].Rows[0]["Restitution"].ToString());
            wrdTable.Cell(2, 56).Range.InsertAfter("$" + ds.Tables["FeeBreakDown"].Rows[0]["CivilPenalties"].ToString());
            wrdTable.Cell(2, 57).Range.InsertAfter("$" + ds.Tables["FeeBreakDown"].Rows[0]["JailRoomAndBoard"].ToString());

            wrdTable.Cell(2, 58).Range.InsertAfter(ds.Tables["General"].Rows[0]["daysinjail"].ToString());
            wrdTable.Cell(2, 59).Range.InsertAfter(ds.Tables["General"].Rows[0]["bookingnumber"].ToString());
            if (DateTime.TryParse(ds.Tables["General"].Rows[0]["judgmentdate"].ToString(), out tempDate))
            {
                wrdTable.Cell(2, 60).Range.InsertAfter(tempDate.ToString("d"));
            }
            //wrdTable.Cell(2, 61).Range.InsertAfter(ds.Tables["General"].Rows[0]["hasjudgmentfiled"].ToString());
            if (DateTime.TryParse(ds.Tables["General"].Rows[0]["judgmentfileddate"].ToString(), out tempDate))
            {
                wrdTable.Cell(2, 61).Range.InsertAfter(tempDate.ToString("d"));
            }
            //wrdTable.Cell(2, 63).Range.InsertAfter(ds.Tables["General"].Rows[0]["inbankruptcy"].ToString());
            if (DateTime.TryParse(ds.Tables["General"].Rows[0]["bankruptcydatefiled"].ToString(), out tempDate))
            {
                wrdTable.Cell(2, 62).Range.InsertAfter(tempDate.ToString("d"));
            }
            if (DateTime.TryParse(ds.Tables["General"].Rows[0]["bankruptcyenddate"].ToString(), out tempDate))
            {
                wrdTable.Cell(2, 63).Range.InsertAfter(tempDate.ToString("d"));
            }


            // entering fee types
            tempStr = "";
            string strFeeType = "";
            string strFeeTypeAmount = "";
            double dblTemp = 0;
            double dblFeesTotal = 0;

            foreach( DataRow dr in ds.Tables["Fees"].Rows )
            {
                strFeeType += dr["feetype"].ToString() + "\n";
                if( Double.TryParse( dr["fee_type_amount"].ToString(), out dblTemp ) )
                {
                    strFeeTypeAmount += dblTemp.ToString( "C2" ) + "\n";
                    dblFeesTotal += dblTemp;
                }
                
                tempStr += dr["feetype"].ToString() + "\t" + dblTemp.ToString( "C2" ) + "\n";
            }

            tempStr += "Total Fees\t" + dblFeesTotal.ToString( "C2" );

            wrdTable.Cell( 2, 38 ).Range.InsertAfter( tempStr );
            wrdTable.Cell( 2, 39 ).Range.InsertAfter( dblFeesTotal.ToString( "C2" ) );
            wrdTable.Cell( 2, 40 ).Range.InsertAfter( strFeeType );
            wrdTable.Cell( 2, 41 ).Range.InsertAfter( strFeeTypeAmount );

            // creating field for firstname lastname
            wrdTable.Cell( 2, 42 ).Range.InsertAfter( ds.Tables["General"].Rows[0]["firstname"].ToString() + " " + ds.Tables["General"].Rows[0]["lastname"].ToString() );
            
            // creating full address field
            tempStr = "";
            tempStr += ds.Tables["General"].Rows[0]["street1"].ToString() + "\n";

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["street2"].ToString() ) )
            {
                tempStr += ds.Tables["General"].Rows[0]["street2"].ToString() + "\n";
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["city"].ToString() ) )
            {
                tempStr += ds.Tables["General"].Rows[0]["city"].ToString();
            }

            if( !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["city"].ToString() ) && !string.IsNullOrEmpty( ds.Tables["General"].Rows[0]["state"].ToString() ) )
            {
                tempStr += ",";
            }

            tempStr += " " + ds.Tables["General"].Rows[0]["state"].ToString()
                + " " + ds.Tables["General"].Rows[0]["zip"].ToString();

            wrdTable.Cell( 2, 43 ).Range.InsertAfter( tempStr );
        }

        private static void FillPreviewSource( Table wrdTable )
        {
            wrdTable.Cell( 2, 1 ).Range.InsertAfter( "First_Name" );
            wrdTable.Cell( 2, 2 ).Range.InsertAfter( "Middle_Name" );
            wrdTable.Cell( 2, 3 ).Range.InsertAfter( "Last_Name" );
            wrdTable.Cell( 2, 4 ).Range.InsertAfter( "AKA" );
            wrdTable.Cell( 2, 5 ).Range.InsertAfter( "SSN" );
            wrdTable.Cell( 2, 6 ).Range.InsertAfter( "Birth_Date" );
            wrdTable.Cell( 2, 7 ).Range.InsertAfter( "Driver_License" );
            wrdTable.Cell( 2, 8 ).Range.InsertAfter( "Street1" );
            wrdTable.Cell( 2, 9 ).Range.InsertAfter( "Street2" );
            wrdTable.Cell( 2, 10 ).Range.InsertAfter( "City" );
            wrdTable.Cell( 2, 11 ).Range.InsertAfter( "State" );
            wrdTable.Cell( 2, 12 ).Range.InsertAfter( "Zip" );
            wrdTable.Cell( 2, 13 ).Range.InsertAfter( "Home_Phone" );
            wrdTable.Cell( 2, 14 ).Range.InsertAfter( "Mobile_Phone" );
            wrdTable.Cell( 2, 15 ).Range.InsertAfter( "Probation_Officer" );
            wrdTable.Cell( 2, 16 ).Range.InsertAfter( "Employer_Name" + "\n"
                    + "Employer_Street1" + "\n"
                    + "Employer_Street2" + "\n"
                    + "Employer_City" + ", " + "Employer_State" + " "
                    + "Employer_Zip" + "\n"
                    + "Employer_Phone" );

            wrdTable.Cell( 2, 17 ).Range.InsertAfter( "Employer_Name" );
            wrdTable.Cell( 2, 18 ).Range.InsertAfter( "Employer_Street1" );
            wrdTable.Cell( 2, 19 ).Range.InsertAfter( "Employer_Street2" );
            wrdTable.Cell( 2, 20 ).Range.InsertAfter( "Employer_City" );
            wrdTable.Cell( 2, 21 ).Range.InsertAfter( "Employer_State" );
            wrdTable.Cell( 2, 22 ).Range.InsertAfter( "Employer_Zip" );
            wrdTable.Cell( 2, 23 ).Range.InsertAfter( "Employer_Phone" );
            wrdTable.Cell( 2, 24 ).Range.InsertAfter( "Plan_Name\t\tPlan_Remaining_Balance" );
            wrdTable.Cell( 2, 25 ).Range.InsertAfter( "Plan_Name" );
            wrdTable.Cell( 2, 26 ).Range.InsertAfter( "Plan_Remaining_Balance" );
            wrdTable.Cell( 2, 27 ).Range.InsertAfter( "Payment_Arrangement_Pay_Period\tPayment_Arrangement_Type\tPayment_Arrangement_Amount\tPayment_Arrangement_Start_Date\tPayment_Arrangement_End_Date" );
            wrdTable.Cell( 2, 28 ).Range.InsertAfter( "Payment_Arrangement_Pay_Period" );
            wrdTable.Cell( 2, 29 ).Range.InsertAfter( "Payment_Arrangement_Type" );
            wrdTable.Cell( 2, 30 ).Range.InsertAfter( "Payment_Arrangement_Amount" );
            wrdTable.Cell( 2, 31 ).Range.InsertAfter( "Payment_Arrangement_Start_Date" );
            wrdTable.Cell( 2, 32 ).Range.InsertAfter( "Payment_Arrangement_End_Date" );
            wrdTable.Cell( 2, 33 ).Range.InsertAfter( "Case_Name\tCase_County\tCase_CAPP\tCase_Committed\n" );
            wrdTable.Cell( 2, 34 ).Range.InsertAfter( "Case_Name" );
            wrdTable.Cell( 2, 35 ).Range.InsertAfter( "Case_County" );
            wrdTable.Cell( 2, 36 ).Range.InsertAfter( "Case_CAPP" );
            wrdTable.Cell( 2, 37 ).Range.InsertAfter( "Case_Committed" );
            wrdTable.Cell( 2, 38 ).Range.InsertAfter( "Fee_Type\tFee_Type_Amount\nTotal Fees\tFees_Total_Due" );
            wrdTable.Cell( 2, 39 ).Range.InsertAfter( "Fees_Total_Due" );
            wrdTable.Cell( 2, 40 ).Range.InsertAfter( "Fee Type" );
            wrdTable.Cell( 2, 41 ).Range.InsertAfter( "Fee_Type_Amount" );
            wrdTable.Cell( 2, 42 ).Range.InsertAfter( "First_Name Last_Name" );
            wrdTable.Cell( 2, 43 ).Range.InsertAfter( "Street1\nStreet2\nCity, State, Zip" );

            wrdTable.Cell( 2, 44 ).Range.InsertAfter( "CAPP_Case_Name\tCAPP_Case_County\tCAPP_Case_CAPP\tCAPP_Case_Committed" );
            wrdTable.Cell( 2, 45 ).Range.InsertAfter( "CAPP_Case_Name" );
            wrdTable.Cell( 2, 46 ).Range.InsertAfter( "CAPP_Case_County" );
            wrdTable.Cell( 2, 47 ).Range.InsertAfter( "CAPP_Case_CAPP" );
            wrdTable.Cell( 2, 48 ).Range.InsertAfter( "CAPP_Case_Committed" );

            wrdTable.Cell( 2, 49 ).Range.InsertAfter( "NonCAPP_Case_Name\tNonCAPP_Case_County\tNonCAPP_Case_CAPP\tNonCAPP_Case_Committed" );
            wrdTable.Cell( 2, 50 ).Range.InsertAfter( "NonCAPP_Case_Name" );
            wrdTable.Cell( 2, 51 ).Range.InsertAfter( "NonCAPP_Case_County" );
            wrdTable.Cell( 2, 52 ).Range.InsertAfter( "NonCAPP_Case_CAPP" );
            wrdTable.Cell( 2, 53 ).Range.InsertAfter( "NonCAPP_Case_Committed" );
            wrdTable.Cell( 2, 54).Range.InsertAfter("Court_Fines");
            wrdTable.Cell( 2, 55).Range.InsertAfter("Restitution");
            wrdTable.Cell( 2, 56).Range.InsertAfter("Civil_Penalties");
            wrdTable.Cell( 2, 57).Range.InsertAfter("Jail_Room_And_Board");

            wrdTable.Cell(2, 58).Range.InsertAfter("Days_In_Jail");
            wrdTable.Cell(2, 59).Range.InsertAfter("Booking_Number");
            //wrdTable.Cell(2, 60).Range.InsertAfter("Has_Judgment_Filed");
            wrdTable.Cell(2, 60).Range.InsertAfter("Date_Of_Judgment");
            wrdTable.Cell(2, 61).Range.InsertAfter("Judgment_Filed_Date");
            //wrdTable.Cell(2, 63).Range.InsertAfter("In_Bankruptcy");
            wrdTable.Cell(2, 62).Range.InsertAfter("Bankruptcy_Date_Filed");
            wrdTable.Cell(2, 63).Range.InsertAfter("Bankruptcy_End_Date");

        }
    }
}
