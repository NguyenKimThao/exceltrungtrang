using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Excel;

namespace ReadAndWriteFileExcel
{
    class Program
    {
        public class HoadonSuaChua
        {
            public Hashtable header = new Hashtable();
            public Hashtable khachhang = new Hashtable();
            public List<Hashtable> chitiet = new List<Hashtable>();
            public string getKH(string name)
            {
                try
                {
                    return khachhang[name].ToString();
                }
                catch (Exception ex)
                {

                }
                return "";
            }
            public string getValueDate(string name)
            {
                try
                {
                    return ((DateTime)header[name]).ToString("yyyy-MM-dd hh:mm:ss");
                }
                catch (Exception ex)
                {

                }
                return "";
            }
            public string getValue(string name)
            {
                try
                {
                    return header[name].ToString();
                }
                catch (Exception ex)
                {

                }
                return "";
            }
            public string getValueChitiet(int index, string name)
            {
                try
                {
                    return chitiet[index][name].ToString();
                }
                catch (Exception ex)
                {

                }
                return "";
            }
        }

        public static HoadonSuaChua getChitietSuaChua(string mahoadon)
        {
            try
            {
                HoadonSuaChua hoadon = new HoadonSuaChua();
                hoadon.header = DataProvider.ExecuteQuery("select * from hoadon where mahoadon=@mahoadon", "mahoadon", mahoadon);
                hoadon.chitiet = DataProvider.ExecuteQueryMutil("select * from chitiethoadonsuachua where  mahoadon=@mahoadon", "mahoadon", mahoadon);
                try
                {
                    if (hoadon.getValue("makh") != "")
                        hoadon.khachhang = DataProvider.ExecuteQuery("select * from khachhang where  ma=@ma", "ma", hoadon.getValue("makh"));
                }
                catch (Exception ex)
                {

                }
                return hoadon;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        public static void CreateSuaChua(string mahoadon, string folderPath)
        {
            Application ExcelObj = new Application();
            Workbook wbTarget = null;
            Worksheet worksheet = null;
            try
            {
                HoadonSuaChua hoadon = getChitietSuaChua(mahoadon);
                if (hoadon == null)
                {
                    Console.WriteLine("Not found bill " + mahoadon);
                    return;
                }
                else
                {
                    Console.WriteLine("Process bill suachua: " + mahoadon);
                }
                int maxSize = 20;
                int sizeChitiet = hoadon.chitiet.Count;
                int sizeSheet = (sizeChitiet - 1) / maxSize;
                string sourceFileName = "mausuachua"; //Source excel file
                wbTarget = CreateWorbook(ExcelObj, folderPath, sourceFileName, mahoadon);
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                worksheet.Name = "Sheet1";

                Range excelRange = worksheet.UsedRange;

                excelRange.Cells.set_Item(8, "A", hoadon.getValue("tenkh"));
                excelRange.Cells.set_Item(9, "D", hoadon.getValue("sodienthoai"));
                excelRange.Cells.set_Item(11, "C", hoadon.getValue("biensoxe"));
                excelRange.Cells.set_Item(10, "AD", hoadon.getValue("sokm"));
                excelRange.Cells.set_Item(14, "A", hoadon.getValue("yeucaukhachhang"));
                excelRange.Cells.set_Item(14, "S", hoadon.getValue("tuvansuachua"));
                excelRange.Cells.set_Item(7, "AG", hoadon.getValueDate("ngayban"));
                excelRange.Cells.set_Item(9, "AH", hoadon.getValueDate("ngaythanhtoan"));


                excelRange.Cells.set_Item(9, "D", hoadon.getKH("sodienthoai"));
                excelRange.Cells.set_Item(10, "C", hoadon.getKH("loaixe"));
                excelRange.Cells.set_Item(8, "K", hoadon.getKH("diachi"));
                excelRange.Cells.set_Item(10, "K", "Số khung: " + hoadon.getKH("sokhung"));
                excelRange.Cells.set_Item(11, "K", "Số máy: " + hoadon.getKH("somay"));

                if (sizeSheet == 0)
                {
                    worksheet.Name = "Sheet" + 1;
                    excelRange.Cells.set_Item(2, "AI", hoadon.getValue("mahoadon"));
                }
                else
                {

                    for (int ix = 1; ix <= sizeSheet; ix++)
                    {
                        worksheet.Copy(worksheet);
                    }
                    for (int ix = sizeSheet + 1; ix >= 1; ix--)
                    {
                        worksheet = (Worksheet)wbTarget.Worksheets.get_Item(ix);
                        worksheet.Name = "Sheet" + ix;
                        excelRange = worksheet.UsedRange;
                        excelRange.Cells.set_Item(2, "AI", hoadon.getValue("mahoadon") + " (" + ix + ")");
                    }


                }

                int i = 0;
                int indexName = 1;
                int index = 25;
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                excelRange = worksheet.UsedRange;
                foreach (Hashtable tb in hoadon.chitiet)
                {
                    Console.WriteLine("Write chitiethoadon i= " + (i+1) + " /" + sizeChitiet);
                    excelRange.Cells.set_Item(index, "B", tb["tenphutungvacongviec"]);
                    excelRange.Cells.set_Item(index, "I", tb["maphutung"]);
                    excelRange.Cells.set_Item(index, "O", tb["dongia"]);
                    excelRange.Cells.set_Item(index, "U", tb["soluongphutung"]);
                    excelRange.Cells.set_Item(index, "AE", tb["tiencong"]);
                    index++;
                    i++;
                    if (i % maxSize == 0)
                    {
                        if (indexName == sizeSheet + 1)
                            break;
                        index = 25;
                        indexName++;
                        worksheet = (Worksheet)wbTarget.Worksheets.get_Item(indexName);
                        excelRange = worksheet.UsedRange;
                    }
                }
                Console.WriteLine("Write finish");
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                worksheet.Activate();
                Console.WriteLine("Proccess finish");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when wirte excel:" + ex.Message);
            }
            try
            {
                wbTarget.Close(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error close file:" + ex.Message);
            }
            ExcelObj.Quit();
        }

        public static Workbook CreateWorbook(Application ExcelObj, string path, string name,string mahoadon)
        {
            try
            {
                string sourceFileName = name + ".xlsx"; //Source excel file
                string tempFileName = name + mahoadon + ".xlsx";
                string folderPath = path;
                string sourceFilePath = System.IO.Path.Combine(folderPath, sourceFileName);
                string destinationFilePath = System.IO.Path.Combine(folderPath, tempFileName);
                System.IO.File.Copy(sourceFilePath, destinationFilePath, true);


                Workbook wbTarget = ExcelObj.Workbooks.Open(destinationFilePath);
                return wbTarget;
            }
            catch (Exception ex)
            {
            }
            return null;
        }

        static void Main(string[] args)
        {
            Config.LoadConfig();
            if (args.Length == 0)
            {
                string mahoadon = "DV-416117";
                CreateSuaChua(mahoadon, Config.folderPath);
                return;
            }
            if (args.Length != 3)
                return;
            string action = args[0];
            switch (action)
            {
                case "suachua":
                    {
                        string mahoadon = args[1];
                        string folderPath = args[2];
                        CreateSuaChua(mahoadon, folderPath);
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
