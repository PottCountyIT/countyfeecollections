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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Printing;
using System.Drawing;
using System.Management;
using Microsoft.Office.Interop.Word;

namespace county.feecollections
{
    public class PrintDelinquent
    {
        private DataSet getData(DateTime date)
        {
            DataSet ds = new DataSet();
            System.Data.DataTable dt = new System.Data.DataTable();

            string sql = "Print_DelinquentNotices";

            using (SqlConnection con = DBSettings.NewSqlConnectionClosed)
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@input_DateTime", SqlDbType.DateTime).Value = date;

                dt = DBSettings.ExecuteDataAdapter(this.GetType().ToString(), cmd);

                dt.TableName = "AccountStatusTable";
                ds.Tables.Add(dt);
            }

            return ds;
        }

        private void PrintDocs(System.Data.DataTable dt, string printer)
        {
            object fileName = Properties.Settings.Default["DocDirectory"].ToString() + @"\Delinquent.docx";
            object oMissing = Type.Missing;
            object oTrue = true;
            object oFalse = false;
            object ochanges = WdSaveOptions.wdDoNotSaveChanges;

            object copies = "1";
            object pages = "";
            object range = WdPrintOutRange.wdPrintAllDocument;
            object items = WdPrintOutItem.wdPrintDocumentContent;
            object pageType = WdPrintOutPages.wdPrintAllPages;

            ApplicationClass app = new ApplicationClass();
            //Application app = ac.Application;

            app.UserName = Environment.UserName;
            
            app.DisplayAlerts = WdAlertLevel.wdAlertsNone;
            app.ActivePrinter = printer;
            
            Document doc = new Document();

            try
            {
                //open document
                doc = app.Documents.Open(ref fileName, ref oMissing, ref oFalse, ref oMissing, ref oMissing,
                                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                        ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                //System.Threading.Thread.Sleep(250);

                foreach (DataRow row in dt.Rows)
                {
                    //System.Threading.Thread.Sleep(200);
                    string name = row["firstname"].ToString() + " " + row["lastname"].ToString() + Environment.NewLine;
                    string address = row["street1"].ToString() + Environment.NewLine;
                    string address2 = row["city"].ToString() + ", " + row["stateAbbr"].ToString() + " " + row["zip"].ToString();

                    if (row["street2"] != null && row["street2"].ToString().Trim() != "")
                        address = address + Environment.NewLine + row["street2"].ToString();

                    string information = "   " + name + address + address2;
                    FindAndReplace(app, "<<information>>", information);

                    doc.PrintOut(
                        ref oFalse, ref oFalse, ref range, ref oMissing, ref oMissing, ref oMissing,
                        ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue,
                        ref oMissing, ref oFalse, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                    //It is entirely possible that the problems we're encountering are due to the speed of the respective machines...
                    //lets try adding more sleeps
                    System.Threading.Thread.Sleep(100);

                    FindAndReplace(app, information, "<<information>>");

                    //This should keep the number of documents in the printing queue down to 50 at a time.
                    //This will also drastically increase the amount of time it takes to perform this operation, but if the target printer can't handle it
                    //then there's nothing for it.
                    while (GetPrintJobCount(printer) >= 50)
                    {
                        System.Threading.Thread.Sleep(100);
                    }
                }
                //close document
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            finally
            {
                //doc.Close(ochanges, oMissing, oMissing);
                //doc.Application.Quit(ochanges, oMissing, oMissing);
                app.Quit(ochanges, oMissing, oMissing);
            }
        }

        public void PrintDocuments(string printername, DateTime date)
        {
            DataSet ds = getData(date);
            System.Data.DataTable dt = ds.Tables["AccountStatusTable"];
            
            PrintDocs(dt, printername);
        }

        private void FindAndReplace(ApplicationClass app, string find, string replace)
        {
            object replaceAll = WdReplace.wdReplaceAll;
            object oMissing = Type.Missing;
            object ofind = find;
            object oreplace = replace;

            app.Selection.Find.ClearFormatting();
            //app.Selection.Find.Text = "find me";

            app.Selection.Find.Replacement.ClearFormatting();
            //app.Selection.Find.Replacement.Text = "Found";

            app.Selection.Find.Execute(ref ofind, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oreplace, ref replaceAll,
                                        ref oMissing, ref oMissing, ref oMissing, ref oMissing);
        }


        public int GetPrintJobCount(string printerName)
        {
            List<string> printJobCollection = new List<string>();
            
            string searchQuery = "SELECT * FROM Win32_PrintJob";

            /*searchQuery can also be mentioned with where Attribute,
                but this is not working in Windows 2000 / ME / 98 machines 
                and throws Invalid query error*/
            ManagementObjectSearcher searchPrintJobs =
                      new ManagementObjectSearcher(searchQuery);
            ManagementObjectCollection prntJobCollection = searchPrintJobs.Get();
            foreach (ManagementObject prntJob in prntJobCollection)
            {
                System.String jobName = prntJob.Properties["Name"].Value.ToString();

                //Job name would be of the format [Printer name], [Job ID]

                char[] splitArr = new char[1];
                splitArr[0] = Convert.ToChar(",");
                string prnterName = jobName.Split(splitArr)[0];
                string documentName = prntJob.Properties["Document"].Value.ToString();
                if (String.Compare(prnterName, printerName, true) == 0)
                {
                    printJobCollection.Add(documentName);
                }
            }
            return printJobCollection.Count;
        }
    }
}
