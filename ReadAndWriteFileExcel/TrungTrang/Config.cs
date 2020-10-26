using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Forms;

namespace TrungTrang
{
    public class Config
    {
        public string folderPath = ".";
        public string host = "";
        public static Config INSTANCE = new Config();
        private Config()
        {
            try
            {
                folderPath =Application.StartupPath+ @"\excel\";
                host = ConfigurationSettings.AppSettings["host"];
            }
            catch (Exception ex)
            {

            }
        }
    }
}
