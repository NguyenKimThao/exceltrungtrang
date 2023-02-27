using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrungTrang.DTO
{
    public class HostConfig
    {
        public string key;
        public string name { get; set; }
        public string host;
        public string diaChi;

        public HostConfig()
        {

        }

        public HostConfig(string key, string name, string host, string diaChi)
        {
            this.key = key;
            this.name = name;
            this.host = host;
            this.diaChi = diaChi;
        }
    }
}
