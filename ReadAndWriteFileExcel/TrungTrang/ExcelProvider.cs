using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrungTrang.DTO;

namespace TrungTrang
{
    public class ExcelProvider
    {
        public static double parseDouble(string val)
        {
            if (val == null || val == "")
                return 0;
            try
            {
                return Convert.ToDouble(val);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public static Workbook CreateWorbook(Application ExcelObj, string path, string name, string destinationFilePath)
        {
            try
            {
                string sourceFileName = name + ".xlsx"; //Source excel file
                string sourceFilePath = System.IO.Path.Combine(path, sourceFileName);
                System.IO.File.Copy(sourceFilePath, destinationFilePath, true);
                Workbook wbTarget = ExcelObj.Workbooks.Open(destinationFilePath);
                return wbTarget;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
        public static bool CreateSuaChua(Application ExcelObj, HoadonSuaChua hoadon, string folderPath, string fileDst)
        {
            Workbook wbTarget = null;
            Worksheet worksheet = null;
            string mahoadon = hoadon.mahoadon;
            bool res = false;
            try
            {
                int maxSize = 20;
                int sizeChitiet = hoadon.chitiet.Count;
                int sizeSheet = (sizeChitiet - 1) / maxSize;
                string sourceFileName = "phieusuachua"; //Source excel file
                wbTarget = CreateWorbook(ExcelObj, folderPath, sourceFileName, fileDst);
                if (wbTarget == null)
                {
                    return res;
                }
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                worksheet.Name = "Sheet1";

                Range excelRange = worksheet.UsedRange;

                excelRange.Cells.set_Item(8, "A", hoadon.tenkh);
                excelRange.Cells.set_Item(9, "D", hoadon.sodienthoai);
                excelRange.Cells.set_Item(11, "C", hoadon.biensoxe);
                excelRange.Cells.set_Item(10, "AD", hoadon.sokm);
                excelRange.Cells.set_Item(14, "A", hoadon.yeucaukhachhang);
                excelRange.Cells.set_Item(14, "S", hoadon.tuvansuachua);
                excelRange.Cells.set_Item(7, "AG", hoadon.ngayban);
                excelRange.Cells.set_Item(9, "AH", hoadon.ngaythanhtoan);


                excelRange.Cells.set_Item(9, "D", hoadon.sodienthoai);
                excelRange.Cells.set_Item(10, "C", hoadon.loaixe);
                excelRange.Cells.set_Item(8, "K", hoadon.diachi);
                excelRange.Cells.set_Item(10, "K", "Số khung: " + hoadon.sokhung);
                excelRange.Cells.set_Item(11, "K", "Số máy: " + hoadon.somay);

                //nvsuachua
                string tennvsuachua = hoadon.tennvsuachua != null ? hoadon.tennvsuachua : "";
                string[] arr = tennvsuachua.Split(' ');
                excelRange.Cells.set_Item(60, "AH", arr[arr.Length - 1]);
                worksheet.Range["AH60", "AH60"].Font.Size = 15;
                worksheet.Range["AH60", "AH60"].Font.Bold = true;
                worksheet.Range["AH60:AH60"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                worksheet.Range["AH60:AJ60"].MergeCells = true;
                worksheet.Range["AH60:AJ60"].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                ///
                if (sizeSheet == 0)
                {
                    worksheet.Name = "Sheet" + 1;
                    excelRange.Cells.set_Item(2, "AI", hoadon.mahoadon);
                }
                else
                {
                    for (int ix = 1; ix <= sizeSheet; ix++)
                        worksheet.Copy(worksheet);
                    for (int ix = sizeSheet + 1; ix >= 1; ix--)
                    {
                        worksheet = (Worksheet)wbTarget.Worksheets.get_Item(ix);
                        worksheet.Name = "Sheet" + ix;
                        excelRange = worksheet.UsedRange;
                        excelRange.Cells.set_Item(2, "AI", hoadon.mahoadon + " (" + ix + ")");
                    }
                }

                int i = 0;
                int indexName = 1;
                int index = 25;
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                excelRange = worksheet.UsedRange;
                foreach (ChiTietHoaDonSuaChua tb in hoadon.chitiet)
                {
                    Console.WriteLine("Write chitiethoadon i= " + (i + 1) + " /" + sizeChitiet);
                    excelRange.Cells.set_Item(index, "B", tb.tenphutungvacongviec);
                    excelRange.Cells.set_Item(index, "I", tb.maphutung);
                    excelRange.Cells.set_Item(index, "O", tb.dongia);
                    excelRange.Cells.set_Item(index, "T", tb.soluongphutung);
                    excelRange.Cells.set_Item(index, "V", parseDouble(tb.chietkhau) / 100);
                    excelRange.Cells.set_Item(index, "AF", tb.tiencong);
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
                res = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when wirte excel:" + ex.Message);
            }
            try
            {
                if (wbTarget != null)
                    wbTarget.Close(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error close file:" + ex.Message);
            }
            ExcelObj.Quit();
            return res;
        }

        public static bool getHoadDon(Dictionary<string, ChiTietThongKe> thongkes, List<HoadonSuaChua> hoadonSuachua)
        {
            try
            {
                foreach (HoadonSuaChua suaChua in hoadonSuachua)
                {
                    foreach (ChiTietHoaDonSuaChua ct in suaChua.chitiet)
                    {
                        string nhacungcap = ct.nhacungcap == null || ct.nhacungcap == "" ? "Trung Trang" : ct.nhacungcap;
                        string chietkhauStr = ct.chietkhau == null || ct.chietkhau == "" ? "0" : ct.chietkhau;
                        string key = ct.maphutung + "_" + ct.dongia + "_" + nhacungcap + "_" + chietkhauStr;
                        long dongia = long.Parse(ct.dongia);
                        int soluong = int.Parse(ct.soluongphutung);
                        int chietkhau = int.Parse(chietkhauStr);
                        if (!thongkes.ContainsKey(key))
                        {
                            ChiTietThongKe tk = new ChiTietThongKe();
                            tk.maphungtung = ct.maphutung;
                            tk.tenphungtung = ct.tenphutungvacongviec;
                            tk.nhacungcap = nhacungcap;
                            tk.dongia = dongia;
                            tk.soluong = 0;
                            tk.chietkhau = chietkhau;
                            thongkes.Add(key, tk);
                        }
                        ChiTietThongKe thongKe = (ChiTietThongKe)thongkes[key];
                        thongKe.soluong += soluong;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public static bool getHoadDon(Dictionary<string, ChiTietThongKe> thongkes, List<HoaDonBanLe> hoadonBanLe)
        {
            try
            {
                foreach (HoaDonBanLe banle in hoadonBanLe)
                {
                    foreach (ChiTietHoaDonBanLe ct in banle.chitiet)
                    {
                        string nhacungcap = ct.nhacungcap == null || ct.nhacungcap == "" ? "Trung Trang" : ct.nhacungcap;
                        string chietkhauStr = ct.chietkhau == null || ct.chietkhau == "" ? "0" : ct.chietkhau;
                        string key = ct.maphutung + "_" + ct.dongia + "_" + nhacungcap + "_" + chietkhauStr;
                        long dongia = long.Parse(ct.dongia);
                        int soluong = int.Parse(ct.soluong);
                        int chietkhau = int.Parse(chietkhauStr);
                        if (!thongkes.ContainsKey(key))
                        {
                            ChiTietThongKe tk = new ChiTietThongKe();
                            tk.maphungtung = ct.maphutung;
                            tk.tenphungtung = ct.tenphutung;
                            tk.nhacungcap = nhacungcap;
                            tk.dongia = dongia;
                            tk.chietkhau = chietkhau;
                            tk.soluong = 0;
                            thongkes.Add(key, tk);
                        }
                        ChiTietThongKe thongKe = (ChiTietThongKe)thongkes[key];
                        thongKe.soluong += soluong;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
            }
            return false;
        }

        public static bool CreateTheoDoi(Application ExcelObj, List<TheoDoi> theoDois, string folderPath, string fileDst)
        {
            bool res = false;
            Workbook wbTarget = null;
            Worksheet worksheet = null;
            try
            {
                string sourceFileName = "theodoi"; //Source excel file
                wbTarget = CreateWorbook(ExcelObj, folderPath, sourceFileName, fileDst);
                if (wbTarget == null)
                {
                    return res;
                }
                ////////////////////////////////////////////////////////////////////Tong ///////////////////////////////////////////
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                Range excelRange = worksheet.UsedRange;
                Dictionary<string, string> users = new Dictionary<string, string>();
                excelRange.Cells.set_Item(3, "A", "STT");
                excelRange.Cells.set_Item(3, "B", "Ngày");
                if (theoDois.Count > 0)
                {
                    string date = "Từ ngày " + theoDois[0].ngay + " đến hết ngày " + theoDois[theoDois.Count - 1].ngay;
                    excelRange.Cells.set_Item(2, "B", date);
                }

                foreach (TheoDoi td in theoDois)
                {
                    if (td.data == null)
                        continue;
                    foreach (ChiTietTheoDoi item in td.data)
                    {
                        if (item.ma == null || item.ma == "") continue;
                        if (!users.ContainsKey(item.ma))
                        {
                            char userIndex = (char)('A' + users.Count + 2);
                            users.Add(item.ma, userIndex.ToString());
                            excelRange.Cells.set_Item(3, userIndex.ToString(), item.ten);
                        }
                    }
                }
                string userNextIndex = ((char)('A' + users.Count + 1)).ToString();
                string userMaxIndex = ((char)('A' + users.Count + 2)).ToString();
                string colMaxIndex = userMaxIndex.ToString() + "3";
                excelRange.Cells.set_Item(3, userMaxIndex.ToString(), "Tổng");
                worksheet.Range[colMaxIndex, colMaxIndex].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";

                for (int i = 0; i < users.Count + 1; i++)
                {
                    for (int j = 0; j < theoDois.Count + 1; j++)
                    {
                        char userIndex = (char)('A' + i + 2);
                        int dateIndex = 4 + j;
                        string colIndex = userIndex.ToString() + dateIndex;
                        worksheet.Range[colIndex, colIndex].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                        excelRange.Cells.set_Item(dateIndex, userIndex.ToString(), 0);
                    }
                }
                int index = 4;
                int stt = 1;
                foreach (TheoDoi td in theoDois)
                {
                    if (td.data == null)
                        continue;
                    excelRange.Cells.set_Item(index, "A", stt);
                    excelRange.Cells.set_Item(index, "B", td.ngay);
                    worksheet.Range[userMaxIndex + index, userMaxIndex + index].Formula = "=SUM(C" + index + ":" + userNextIndex + index + ")";
                    foreach (ChiTietTheoDoi item in td.data)
                    {
                        if (item.ma == null || item.ma == "" || !users.ContainsKey(item.ma)) continue;
                        string userIndex = users[item.ma];
                        excelRange.Cells.set_Item(index, userIndex.ToString(), item.tiencong);
                    }
                    stt++;
                    index++;
                }
                excelRange.Cells.set_Item(index, "A", "Tổng");
                for (int i = 0; i < users.Count + 1; i++)
                {
                    char userIndex = (char)('A' + i + 2);
                    int dateIndex = index;
                    string colIndex = userIndex.ToString() + dateIndex;
                    excelRange.Cells.set_Item(dateIndex, userIndex.ToString(), 0);
                    worksheet.Range[colIndex, colIndex].Formula = "=SUM(" + userIndex + "4:" + userIndex + (index - 1) + ")";
                }

                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                worksheet.Activate();
                Console.WriteLine("Proccess finish");
                res = true;
            }
            catch (Exception ex)
            {

            }
            try
            {
                if (wbTarget != null)
                    wbTarget.Close(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error close file:" + ex.Message);
            }
            ExcelObj.Quit();
            return res;
        }

        public static bool CreateChamCong(Application ExcelObj, ChamCong chamCong, string folderPath, string fileDst)
        {
            bool res = false;
            Workbook wbTarget = null;
            Worksheet worksheet = null;
            try
            {
                string sourceFileName = "chamcong"; //Source excel file
                wbTarget = CreateWorbook(ExcelObj, folderPath, sourceFileName, fileDst);
                if (wbTarget == null)
                {
                    return res;
                }
                ////////////////////////////////////////////////////////////////////Tong ///////////////////////////////////////////
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                Range excelRange = worksheet.UsedRange;
                Dictionary<string, string> users = new Dictionary<string, string>();
                excelRange.Cells.set_Item(2, "A", chamCong.date);

                int index = 5;
                int stt = 1;
                foreach (ChiTietChamCong ctcc in chamCong.data)
                {
                    excelRange.Cells.set_Item(index, "A", stt);
                    excelRange.Cells.set_Item(index, "B", ctcc.ten);

                    worksheet.Range["C" + index, "C" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    worksheet.Range["D" + index, "D" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    worksheet.Range["E" + index, "E" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    excelRange.Cells.set_Item(index, "C", ctcc.tiencong);
                    excelRange.Cells.set_Item(index, "D", ctcc.vskp);
                    excelRange.Cells.set_Item(index, "E", ctcc.vsbd);
                    excelRange.Cells.set_Item(index, "F", ctcc.ghichu);
                    stt++;
                    index++;
                }
                excelRange.Cells.set_Item(index, "B", "TỔNG CỘNG");
                worksheet.Range["C" + index, "C" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                worksheet.Range["D" + index, "D" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                worksheet.Range["E" + index, "E" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                worksheet.Range["C" + index, "C" + index].Formula = "=SUM(C5:" + "C" + (index - 1) + ")";
                worksheet.Range["D" + index, "D" + index].Formula = "=SUM(D5:" + "D" + (index - 1) + ")";
                worksheet.Range["E" + index, "E" + index].Formula = "=SUM(E5:" + "E" + (index - 1) + ")";


                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                worksheet.Activate();
                Console.WriteLine("Proccess finish");
                res = true;
            }
            catch (Exception ex)
            {

            }
            try
            {
                if (wbTarget != null)
                    wbTarget.Close(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error close file:" + ex.Message);
            }
            ExcelObj.Quit();
            return res;
        }

        public static bool CreateThongKe(Application ExcelObj, List<HoadonSuaChua> hoadonSuachua, List<HoaDonBanLe> hoadonBanLe, string folderPath, string fileDst)
        {
            bool res = false;
            Workbook wbTarget = null;
            Worksheet worksheet = null;
            try
            {
                string sourceFileName = "thongkebill"; //Source excel file
                wbTarget = CreateWorbook(ExcelObj, folderPath, sourceFileName, fileDst);
                if (wbTarget == null)
                {
                    return res;
                }
                ////////////////////////////////////////////////////////////////////Tong ///////////////////////////////////////////
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                Range excelRange = worksheet.UsedRange;

                Dictionary<string, ChiTietThongKe> thongkes = new Dictionary<string, ChiTietThongKe>();
                if (!getHoadDon(thongkes, hoadonSuachua))
                {
                    return res;
                }
                if (!getHoadDon(thongkes, hoadonBanLe))
                {
                    return res;
                }

                int index = 7;
                int stt = 1;
                foreach (ChiTietThongKe ct in thongkes.Values)
                {
                    if (ct.maphungtung == "" || (ct.nhacungcap != "Trung Trang"))
                        continue;
                    worksheet.Range["B" + index, "B" + index].NumberFormat = "@";
                    worksheet.Range["C" + index, "C" + index].NumberFormat = "@";
                    worksheet.Range["F" + index, "F" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    worksheet.Range["I" + index, "I" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    worksheet.Range["G" + index, "G" + index].NumberFormat = @"0%";
                    worksheet.Range["H" + index, "H" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";

                    excelRange.Cells.set_Item(index, "A", stt);
                    excelRange.Cells.set_Item(index, "B", ct.maphungtung);
                    excelRange.Cells.set_Item(index, "C", ct.tenphungtung);
                    excelRange.Cells.set_Item(index, "D", ct.soluong);
                    excelRange.Cells.set_Item(index, "F", ct.dongia);
                    excelRange.Cells.set_Item(index, "G", ct.chietkhau / 100);
                    double giaban = 0;
                    if (ct.chietkhau > 0)
                    {
                        giaban = (float)(ct.dongia * (float)(1 - ct.chietkhau / 100));
                    }
                    excelRange.Cells.set_Item(index, "H", giaban);
                    worksheet.Range["H" + index, "H" + index].Formula = "=" + "F" + index + "*(1-" + "G" + index + ")";
                    excelRange.Cells.set_Item(index, "I", ct.soluong * giaban);
                    worksheet.Range["I" + index, "I" + index].Formula = "=" + "D" + index + "*" + "H" + index;
                    index++;
                    stt++;
                }
                excelRange.Cells.set_Item(index, "B", "Tổng");
                worksheet.Range["D" + index, "D" + index].Formula = "=SUM(D7:D" + (index - 1) + ")";
                worksheet.Range["F" + index, "F" + index].Formula = "=SUM(F7:F" + (index - 1) + ")";
                worksheet.Range["H" + index, "H" + index].Formula = "=SUM(H7:H" + (index - 1) + ")";
                worksheet.Range["I" + index, "I" + index].Formula = "=SUM(I7:I" + (index - 1) + ")";

                ////////////////////////////////////////////////////////////////////Le ///////////////////////////////////////////
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(2);
                excelRange = worksheet.UsedRange;

                Dictionary<string, ChiTietThongKe> thongkeLes = new Dictionary<string, ChiTietThongKe>();
                if (!getHoadDon(thongkeLes, hoadonBanLe))
                {
                    return res;
                }
                index = 7;
                stt = 1;
                foreach (ChiTietThongKe ct in thongkeLes.Values)
                {
                    if (ct.maphungtung == "" || (ct.nhacungcap != "Trung Trang"))
                        continue;
                    worksheet.Range["B" + index, "B" + index].NumberFormat = "@";
                    worksheet.Range["C" + index, "C" + index].NumberFormat = "@";
                    worksheet.Range["F" + index, "F" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    worksheet.Range["I" + index, "I" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    worksheet.Range["G" + index, "G" + index].NumberFormat = @"0%";
                    worksheet.Range["H" + index, "H" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";

                    excelRange.Cells.set_Item(index, "A", stt);
                    excelRange.Cells.set_Item(index, "B", ct.maphungtung);
                    excelRange.Cells.set_Item(index, "C", ct.tenphungtung);
                    excelRange.Cells.set_Item(index, "D", ct.soluong);
                    excelRange.Cells.set_Item(index, "F", ct.dongia);
                    excelRange.Cells.set_Item(index, "G", ct.chietkhau / 100);
                    double giaban = 0;
                    if (ct.chietkhau > 0)
                    {
                        giaban = (float)(ct.dongia * (float)(1 - ct.chietkhau / 100));
                    }
                    excelRange.Cells.set_Item(index, "H", giaban);
                    worksheet.Range["H" + index, "H" + index].Formula = "=" + "F" + index + "*(1-" + "G" + index + ")";
                    excelRange.Cells.set_Item(index, "I", ct.soluong * giaban);
                    worksheet.Range["I" + index, "I" + index].Formula = "=" + "D" + index + "*" + "H" + index;
                    index++;
                    stt++;
                }
                excelRange.Cells.set_Item(index, "B", "Tổng");
                worksheet.Range["D" + index, "D" + index].Formula = "=SUM(D7:D" + (index - 1) + ")";
                worksheet.Range["F" + index, "F" + index].Formula = "=SUM(F7:F" + (index - 1) + ")";
                worksheet.Range["H" + index, "H" + index].Formula = "=SUM(H7:H" + (index - 1) + ")";
                worksheet.Range["I" + index, "I" + index].Formula = "=SUM(I7:I" + (index - 1) + ")";

                ////////////////////////////////////////////////////////////////////Chan ///////////////////////////////////////////
                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(3);
                excelRange = worksheet.UsedRange;

                Dictionary<string, ChiTietThongKe> thongkeSuachuas = new Dictionary<string, ChiTietThongKe>();
                if (!getHoadDon(thongkeSuachuas, hoadonSuachua))
                {
                    return res;
                }
                index = 7;
                stt = 1;
                foreach (ChiTietThongKe ct in thongkeSuachuas.Values)
                {
                    if (ct.maphungtung == "" || (ct.nhacungcap != "Trung Trang"))
                        continue;
                    worksheet.Range["B" + index, "B" + index].NumberFormat = "@";
                    worksheet.Range["C" + index, "C" + index].NumberFormat = "@";
                    worksheet.Range["F" + index, "F" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    worksheet.Range["I" + index, "I" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";
                    worksheet.Range["G" + index, "G" + index].NumberFormat = @"0%";
                    worksheet.Range["H" + index, "H" + index].NumberFormat = @"_(* #,##0.00_);_(* (#,##0.00);_(* "" - ""??_);_(@_)";

                    excelRange.Cells.set_Item(index, "A", stt);
                    excelRange.Cells.set_Item(index, "B", ct.maphungtung);
                    excelRange.Cells.set_Item(index, "C", ct.tenphungtung);
                    excelRange.Cells.set_Item(index, "D", ct.soluong);
                    excelRange.Cells.set_Item(index, "F", ct.dongia);
                    excelRange.Cells.set_Item(index, "G", ct.chietkhau / 100);
                    double giaban = 0;
                    if (ct.chietkhau > 0)
                    {
                        giaban = (float)(ct.dongia * (float)(1 - ct.chietkhau / 100));
                    }
                    excelRange.Cells.set_Item(index, "H", giaban);
                    worksheet.Range["H" + index, "H" + index].Formula = "=" + "F" + index + "*(1-" + "G" + index + ")";
                    excelRange.Cells.set_Item(index, "I", ct.soluong * giaban);
                    worksheet.Range["I" + index, "I" + index].Formula = "=" + "D" + index + "*" + "H" + index;
                    index++;
                    stt++;
                }
                excelRange.Cells.set_Item(index, "B", "Tổng");
                worksheet.Range["D" + index, "D" + index].Formula = "=SUM(D7:D" + (index - 1) + ")";
                worksheet.Range["F" + index, "F" + index].Formula = "=SUM(F7:F" + (index - 1) + ")";
                worksheet.Range["H" + index, "H" + index].Formula = "=SUM(H7:H" + (index - 1) + ")";
                worksheet.Range["I" + index, "I" + index].Formula = "=SUM(I7:I" + (index - 1) + ")";

                worksheet = (Worksheet)wbTarget.Worksheets.get_Item(1);
                worksheet.Activate();
                Console.WriteLine("Proccess finish");
                res = true;
            }
            catch (Exception ex)
            {

            }
            try
            {
                if (wbTarget != null)
                    wbTarget.Close(true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error close file:" + ex.Message);
            }
            ExcelObj.Quit();
            return res;
        }
    }
}

