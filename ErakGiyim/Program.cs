using System;
using System.Windows.Forms;

namespace ErakGiyim
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
            Session.CurrentUsername = PromptForUsername();
            Application.Run(new MainForm());
        }

        public static string PromptForUsername()
        {
            using (var prompt = new UsernamePromptForm())
            {
                if (prompt.ShowDialog() == DialogResult.OK)
                    return prompt.UsernameTextBox.Text;
                else
                    return "Unknown";
            }
        }
    }
    public static class Session
    {
        public static string CurrentUsername { get; set; }
    }
}