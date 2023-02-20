global using Microsoft.Data.SqlClient;
global using System.Configuration;
global using System.Data;

namespace _2_DetailedView
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new DetailedView());
        }
    }
}