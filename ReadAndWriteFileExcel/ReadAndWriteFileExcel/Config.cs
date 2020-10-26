using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;

namespace ReadAndWriteFileExcel
{
    public class Config
    {
        public static string folderPath = ".";
        public static string host = "";
        public static int port = 0;
        public static string database = "";
        public static string username = "";
        public static string password = "";

        public static void LoadConfig()
        {
            try
            {
                folderPath = ConfigurationManager.AppSettings.Get("folderPath");
                host = ConfigurationManager.AppSettings.Get("host");
                database = ConfigurationManager.AppSettings.Get("database");
                username = ConfigurationManager.AppSettings.Get("username");
                password = ConfigurationManager.AppSettings.Get("password");
                port = Int32.Parse(ConfigurationManager.AppSettings.Get("port"));
            }
            catch (Exception ex)
            {

            }
        }
    }
}
