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

namespace county.feecollections
{

    public enum MyDisplayMessage
    {
        Archive,
        FatalError,
        FormOpenError,
        FormUpdateError,
        MailMergeDirectoryError,
        MailMergeDocumentCloseWarning,
        MailMergeDocumentMergeError,
        MailMergeDocumentSaveWarning, 
        MailMergeDocumentStoredOpenError,
        OverWriteConfirm,
        PaymentMoreThanOwed,
        PaymentArrangementOverlapping,
        RefreshConfirm,
        RefreshError,
        RemoveConfirm,
        RemoveError,
        SaveConfirm,
        SaveError,
        SaveSuccess,
        TestConfirmRetest,
        TestError,
        TestSuccess,
        Unhandled
    };

    public static class MyMessageBox
    {
        private static string CreateMessage( MyDisplayMessage typMsg, string caption, string error )
        {
            switch( typMsg )
            {
                case MyDisplayMessage.Archive:
                    return "Removing will:\n\n-remove any changes that have not been saved.\n" +
                        "-set the defendant to inactive in the database.\n" +
                        "-remove the defendant from the display.\n" +
                        "\nRemove this Defendant?";

                case MyDisplayMessage.FatalError:
                    return string.Format( "{0}\n\nThe application must be shut down.  Please check the event viewer for information that might have caused this error.", caption );

                case MyDisplayMessage.FormOpenError:
                    return string.Format( "{0}\n\nUnable to open the {1}.", error, caption.ToLower() );

                case MyDisplayMessage.FormUpdateError:
                    return string.Format( "{0}\n\nThe {1} will now close.", error, caption.ToLower() );

                case MyDisplayMessage.MailMergeDirectoryError:
                    return "The Mail Merge Report directory has not been set or is not accessible.  Please refer to Tools > Options and select the Reporting Tab.";

                case MyDisplayMessage.MailMergeDocumentCloseWarning:
                    return "This document is being managed by the " + Application.CompanyName + " " + Application.ProductName + " application."
                        + "\n\nClosing it using MS Word's close command will detach it from the application."
                        + "In order to keep it attached to the application, please use the always on top 'MS Word Mail Merge' window."
                        + "\n\nAre you sure you want to close?";

                case MyDisplayMessage.MailMergeDocumentMergeError:
                    return string.Format( "Error performing mail merge:\n\n {0}.", error );

                case MyDisplayMessage.MailMergeDocumentSaveWarning:
                    return "This document is being managed by the " + Application.CompanyName + " " + Application.ProductName + " application."
                        + "\n\nExecuting the save command in MS Word will save the document locally. "
                        + "In order to save it for use in the application please use the always on top 'MS Word Mail Merge' window "
                        + "'Store Template' button.";
                        
                case MyDisplayMessage.MailMergeDocumentStoredOpenError:
                    return "Unable to open the template.\n\n"
                        + "This usually has to do with permission problems on the network or your local machine.  "
                        + "Please try again later or contact an administrator to help troubleshoot this error.";
                    
                case MyDisplayMessage.OverWriteConfirm:
                    return "There is already a file with the same name in this location.\n\nOverwrite this file?";

                case MyDisplayMessage.PaymentMoreThanOwed:
                    return "Payment made is greater than what the defendant owes.";

                case MyDisplayMessage.PaymentArrangementOverlapping:
                    return "Overlapping payment arrangements are not allowed.";

                case MyDisplayMessage.RefreshConfirm:
                    return string.Format( "Refreshing will clear any changes you have made to the {0}.\n\nRefresh this {0}?", caption.ToLower() );

                case MyDisplayMessage.RefreshError:
                    return string.Format( "{0}\n\nUnable to refresh {1}.", error, caption.ToLower() );
                
                case MyDisplayMessage.RemoveConfirm:
                    return string.Format( "Remove {0}?", caption.ToLower() );

                case MyDisplayMessage.RemoveError:
                    return string.Format( "{0}\n\nUnable to remove {1}.", error, caption.ToLower() );

                case MyDisplayMessage.SaveConfirm:
                    return string.Format( "Save Changes to {0}?", caption.ToLower() );

                case MyDisplayMessage.SaveError:
                    return string.Format( "{0}\n\nUnable to save {1}.", error, caption.ToLower() );

                case MyDisplayMessage.SaveSuccess:
                    return string.Format( "{0} Saved Successfully.", caption );

                case MyDisplayMessage.TestConfirmRetest:
                    return string.Format( "{0}\n\nPress 'Yes' to try again and 'No' to exit the application.", error );

                case MyDisplayMessage.TestError:
                    return string.Format( "{0}\n\nTest Unsuccessfull.", error );

                case MyDisplayMessage.TestSuccess:
                    return string.Format( "{0} Test Successfull.", caption );

                default:
                    return "";
            }
        } 

        public static DialogResult Show( IWin32Window owner, string caption, MyDisplayMessage displayMessageType )
        {
            switch( displayMessageType )
            {
                case MyDisplayMessage.FatalError:
                case MyDisplayMessage.MailMergeDirectoryError:
                case MyDisplayMessage.MailMergeDocumentMergeError:
                case MyDisplayMessage.MailMergeDocumentStoredOpenError:
                case MyDisplayMessage.PaymentMoreThanOwed:
                case MyDisplayMessage.PaymentArrangementOverlapping:
                    return MessageBox.Show( owner, CreateMessage( displayMessageType, caption, "" ), caption, MessageBoxButtons.OK, MessageBoxIcon.Error );
                
                case MyDisplayMessage.MailMergeDocumentCloseWarning:
                case MyDisplayMessage.OverWriteConfirm:
                    return MessageBox.Show( owner, CreateMessage( displayMessageType, caption, "" ), caption, MessageBoxButtons.YesNo, MessageBoxIcon.Information );

                case MyDisplayMessage.Archive:
                case MyDisplayMessage.RefreshConfirm:
                case MyDisplayMessage.RemoveConfirm:
                    return MessageBox.Show( owner, CreateMessage( displayMessageType, caption, "" ), caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Question );
                    
                case MyDisplayMessage.SaveConfirm:
                    return MessageBox.Show( owner, CreateMessage( displayMessageType, caption, "" ), caption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question );

                case MyDisplayMessage.MailMergeDocumentSaveWarning:
                case MyDisplayMessage.SaveSuccess:
                case MyDisplayMessage.TestSuccess:
                    return MessageBox.Show( owner, CreateMessage( displayMessageType, caption, "" ), caption, MessageBoxButtons.OK, MessageBoxIcon.Information );

                default:
                    return DialogResult.Ignore;

            }

        } 
        
        public static DialogResult Show( IWin32Window owner, string caption, MyDisplayMessage displayMessageType, MyException myException )
        {
            switch( displayMessageType )
            {
                case MyDisplayMessage.FormOpenError:
                case MyDisplayMessage.FormUpdateError:
                case MyDisplayMessage.RefreshError:
                case MyDisplayMessage.RemoveError:
                case MyDisplayMessage.SaveError:
                case MyDisplayMessage.TestError:
                case MyDisplayMessage.TestConfirmRetest:
                case MyDisplayMessage.MailMergeDocumentMergeError:
                    return MessageBox.Show( owner, CreateMessage( displayMessageType, caption, myException.Message ), caption, MessageBoxButtons.YesNo, MessageBoxIcon.Error );

                default:
                    return DialogResult.Ignore;
            }

        } 

         
    }






}
