using System;
using System.Windows.Forms;

namespace PubCompanyWinCore
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Add handler to handle the exception raised by main threads
            Application.ThreadException +=
                new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            // Add handler to handle the exception raised by additional threads
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            var startup = new Startup();

            // Stop the application and all the threads in suspended state.
            Environment.Exit(-1);
        }
        static void Application_ThreadException
            (object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // All exceptions thrown by the main thread are handled over this method

            ShowExceptionDetails(e.Exception);
        }

        static void CurrentDomain_UnhandledException
            (object sender, UnhandledExceptionEventArgs e)
        {
            // All exceptions thrown by additional threads are handled in this method

            ShowExceptionDetails(e.ExceptionObject as Exception);
        }

        static void ShowExceptionDetails(Exception Ex)
        {
            // Do logging of exception details
            MessageBox.Show(Ex.Message, Ex.TargetSite.ToString(),
                MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Stop the application and all the threads in suspended state.
            Environment.Exit(-1);
        }
    }
}


