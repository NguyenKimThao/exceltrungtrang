using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Windows.Forms;
using TrungTrang.DTO;
using Newtonsoft.Json;

namespace TrungTrang
{
    public class Config
    {
        public string folderPath = ".";
        public HostConfig hostConfig = null;
        public List<HostConfig> hostConfigs = new List<HostConfig>();
        public static Config INSTANCE = new Config();

        private Config()
        {
            try
            {
                folderPath = Application.StartupPath + @"\excel\";
                hostConfigs.Add(new HostConfig("bk", "Bình Khánh", "http://bk.trungtrang.com:8080/", "613A/31 Trần Hưng Đạo, Bình Khánh, LX, AG"));
                hostConfigs.Add(new HostConfig("mx", "Mỹ Xuyên", "http://mx.trungtrang.com:8081/", "HTLO, Khóm Đông An 5, Mỹ Xuyên, PX, AG"));
                //hostConfigs.Add(new HostConfig("localhost", "LocalHost", "http://localhost:8080/", "HTLO, Khóm Đông An 5, Mỹ Xuyên, PX, AG"));

                if (Properties.Settings.Default.host != null && Properties.Settings.Default.host.Length > 0)
                {
                    foreach (HostConfig item in hostConfigs)
                    {
                        if (item.key == Properties.Settings.Default.host)
                        {
                            hostConfig = item;
                            break;
                        }
                    }
                }
                if (hostConfig == null)
                {
                    hostConfig = hostConfigs[0];
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
