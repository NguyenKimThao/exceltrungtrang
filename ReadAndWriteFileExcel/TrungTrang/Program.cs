using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrungTrang
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string name = System.Windows.Forms.Application.ExecutablePath;
            RegisterURLProtocol("trungtrang", name);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginUser(args));
        }
        public static void RegisterURLProtocol(string protocolName, string applicationPath)
        {
            try
            {
                // Create new key for desired URL protocol

                var KeyTest = Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey("Classes", true);
                RegistryKey key = KeyTest.CreateSubKey(protocolName);
                key.SetValue("URL Protocol", protocolName);
                //key.CreateSubKey(@"shell\open\command").SetValue("", "\"" + applicationPath + "\"");
                key.CreateSubKey(@"shell\open\command").SetValue("", "\"" + applicationPath + "\" \"%1\"");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
        }
    }
}
