 using System.Diagnostics;
using System.Globalization;

namespace OpusTool
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
            if(string.IsNullOrEmpty(Properties.Settings.Default.CultureInfo))
            {
                if(CultureInfo.InstalledUICulture.Name.Substring(0, 2)!= "es" && CultureInfo.InstalledUICulture.Name.Substring(2, 2)!= "ca")
                {
                    Properties.Settings.Default.CultureInfo = "en";
                    Properties.Settings.Default.Save();
                } else
                {
                    Properties.Settings.Default.CultureInfo = "es";
                    Properties.Settings.Default.Save();

                }
            }
           Application.Run(new Form1());
        }

    }
}