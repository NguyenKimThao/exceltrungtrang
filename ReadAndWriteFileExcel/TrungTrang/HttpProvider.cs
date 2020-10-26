using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TrungTrang.DTO;

namespace TrungTrang
{
    public class HttpProvider
    {
        public static String host = @"http://localhost:8080/";
        public static string getJson(string uri)
        {
            string url = Config.INSTANCE.host + uri;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string content = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return content;
        }

        public static ReponseData getChitietSuaChua(string mahoadon)
        {
            ReponseData reponse = new ReponseData();
            try
            {
                string url = Config.INSTANCE.host + "billsuachua/mahoadon/" + mahoadon + "/chitiet";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string jsonResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
                HoadonSuaChua hoadon = JsonConvert.DeserializeObject<HoadonSuaChua>(jsonResponse);
                reponse.data = hoadon;
                reponse.error = 0;
            }
            catch (Exception ex)
            {
                if (ex.Message == "The remote server returned an error: (400) Bad Request.")
                {
                    reponse.error = -400;
                }
                if (ex.Message == "The remote server returned an error: (404) Not Found.")
                {
                    reponse.error = -404;
                }
            }
            return reponse;
        }

        public static ReponseData getChitietThongKeSuaChua(string start, string end)
        {
            ReponseData reponse = new ReponseData();
            try
            {
                string url = Config.INSTANCE.host + "statistic/bill/chitiet?end=" + end + "&start=" + start + "&trangthai=1&loaihoadon=0";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string jsonResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
                List<HoadonSuaChua> hoadons = JsonConvert.DeserializeObject<List<HoadonSuaChua>>(jsonResponse);
                reponse.data = hoadons;
                reponse.error = 0;
            }
            catch (Exception ex)
            {
                if (ex.Message == "The remote server returned an error: (400) Bad Request.")
                {
                    reponse.error = -400;
                }
                if (ex.Message == "The remote server returned an error: (404) Not Found.")
                {
                    reponse.error = -404;
                }
            }
            return reponse;
        }
        public static ReponseData getChitietThongKeLe(string start, string end)
        {
            ReponseData reponse = new ReponseData();
            try
            {
                string url = Config.INSTANCE.host + "statistic/bill/chitiet?end=" + end + "&start=" + start + "&trangthai=1&loaihoadon=1";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string jsonResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
                List<HoaDonBanLe> hoadons = JsonConvert.DeserializeObject<List<HoaDonBanLe>>(jsonResponse);
                reponse.data = hoadons;
                reponse.error = 0;
            }
            catch (Exception ex)
            {
                if (ex.Message == "The remote server returned an error: (400) Bad Request.")
                {
                    reponse.error = -400;
                }
                if (ex.Message == "The remote server returned an error: (404) Not Found.")
                {
                    reponse.error = -404;
                }
            }
            return reponse;
        }
        public static ReponseData getReponseData<T>(string uri)
        {
            ReponseData reponse = new ReponseData();
            try
            {
                string url = Config.INSTANCE.host + uri;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                string jsonResponse = new StreamReader(response.GetResponseStream()).ReadToEnd();
                List<T> theoDois = JsonConvert.DeserializeObject<List<T>>(jsonResponse);
                reponse.data = theoDois;
                reponse.error = 0;
            }
            catch (Exception ex)
            {
                if (ex.Message == "The remote server returned an error: (400) Bad Request.")
                {
                    reponse.error = -400;
                }
                if (ex.Message == "The remote server returned an error: (404) Not Found.")
                {
                    reponse.error = -404;
                }
            }
            return reponse;
        }

        public static ReponseData getChitietTheoDoi(string start, string end)
        {
            string url = "statistic/chamcong/employee?end=" + end + "&start=" + start;
            return getReponseData<TheoDoi>(url);
        }
        public static ReponseData getChitietChamCong(string start)
        {
            string url = "chamcong/theongay/ngay/" + start;
            return getReponseData<ChiTietChamCong>(url);
        }
    }
}
