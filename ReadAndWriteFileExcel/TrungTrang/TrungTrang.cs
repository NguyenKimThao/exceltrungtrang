using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungTrang.DTO;

namespace TrungTrang
{
    public partial class TrungTrang : Form
    {
        private Microsoft.Office.Interop.Excel.Application ExcelObj = new Microsoft.Office.Interop.Excel.Application();
        private SaveFileDialog saveFileDialog = new SaveFileDialog();
        private Uri uri = null;
        public TrungTrang(string[] args)
        {
            InitializeComponent();
            this.tdDateStart.Controls.Remove(this.tabBanle);
            saveFileDialog.Title = "Chọn thư mực save file";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.Filter = "excel (*.xlsx)|*.xlsx|excel (*.xls)|*.xls|All files (*.*)|*.*";
            dateStart.Value = DateTime.Now;
            dateEnd.Value = DateTime.Now;
            dateTDStart.Value = DateTime.Now;
            dateTDEnd.Value = DateTime.Now;
            dateCCStart.Value = DateTime.Now;
            if (args.Length != 1 || !args[0].StartsWith("trungtrang://trungtrang.myddns.me/"))
                return;
            uri = new Uri(args[0]);
        }

        private void DisableButton()
        {
            btnXuatPDFSuaChua.Enabled = false;
            btnXuatExcelSuaChua.Enabled = false;
            btnXuatExcelThongKe.Enabled = false;
            btnCCXuatExcel.Enabled = false;
            btnTDXuatExcel.Enabled = false;
        }

        private void EnableButton()
        {
            btnXuatPDFSuaChua.Enabled = true;
            btnXuatExcelSuaChua.Enabled = true;
            btnXuatExcelThongKe.Enabled = true;
            btnCCXuatExcel.Enabled = true;
            btnTDXuatExcel.Enabled = true;
        }

        private bool checkReponseData(ReponseData data, string text, string title)
        {
            try
            {
                if (data == null || data.error == -1)
                {
                    MessageBox.Show("Vui lòng kiểm tra đường mạng", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (data.error == -404)
                {
                    MessageBox.Show("Phần mền chưa hỗ trợ chức năng này, vui lòng cập nhập lại version mới nhất", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                if (data.error == -400 || data.data == null)
                {
                    MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private void btnXuatExcelSuaChua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHoaDonSuaChua.Text == "")
                {
                    MessageBox.Show("Không để mã hóa đơn trống", "Xuất bill sữa chữa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string mahoadon = txtMaHoaDonSuaChua.Text;
                ReponseData data = HttpProvider.getChitietSuaChua(mahoadon);
                if (checkReponseData(data, "Không tìm thấy mã hóa đơn " + mahoadon, "Xuất bill sữa chữa") == false)
                {
                    return;
                }
                HoadonSuaChua hoadon = (HoadonSuaChua)data.data;
                saveFileDialog.FileName = mahoadon;
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                DisableButton();
                bool res = ExcelProvider.CreateSuaChua(ExcelObj, hoadon, Config.INSTANCE.folderPath, saveFileDialog.FileName);
                EnableButton();
                if (res == true)
                {
                    if (uri != null)
                        return;
                    DialogResult result = MessageBox.Show("Xuất excel " + mahoadon + " thành công\n Bạn muốn mở file lên!", "Xuất bill sữa chữa", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(saveFileDialog.FileName);
                    }
                }
                else
                {
                    MessageBox.Show("Xuất thất bại", "Xuất bill sữa chữa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi phát sinh \n" + ex.Message, "Xuất bill sữa chữa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatPDFSuaChua_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMaHoaDonSuaChua.Text == "")
                {
                    MessageBox.Show("Không để mã hóa đơn trống", "Xuất bill sữa chữa", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string mahoadon = txtMaHoaDonSuaChua.Text;
                Process.Start(Config.INSTANCE.host + "billsuachua/mahoadon/" + mahoadon + "/export");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi phát sinh \n" + ex.Message, "Xuất bill sữa chữa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXuatExcelThongKe_Click(object sender, EventArgs e)
        {
            string title = "Xuất bill thống kê";
            DateTime start = dateStart.Value;
            DateTime end = dateEnd.Value;
            if (start > end)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn kết thúc", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ReponseData resSuachua = HttpProvider.getChitietThongKeSuaChua(start.ToString("yyyy/MM/dd"), end.ToString("yyyy/MM/dd"));
            if (checkReponseData(resSuachua, "Không thể thống kê vui lòng xem lại ngày tháng", title) == false)
                return;
            ReponseData resBillLe = HttpProvider.getChitietThongKeLe(start.ToString("yyyy/MM/dd"), end.ToString("yyyy/MM/dd"));
            if (checkReponseData(resBillLe, "Không thể thống kê vui lòng xem lại ngày tháng", title) == false)
                return;
            List<HoadonSuaChua> hoadonSuachuas = (List<HoadonSuaChua>)resSuachua.data;
            List<HoaDonBanLe> hoadonBanles = (List<HoaDonBanLe>)resBillLe.data;

            saveFileDialog.FileName = "thongkebill";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DisableButton();
            bool res = ExcelProvider.CreateThongKe(ExcelObj, hoadonSuachuas, hoadonBanles, Config.INSTANCE.folderPath, saveFileDialog.FileName);
            EnableButton();
            if (res == true)
            {
                if (uri != null)
                    return;
                DialogResult result = MessageBox.Show("Xuất excel thống kê thành công\n Bạn muốn mở file lên!", title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("Xuất thất bại", "Xuất bill sữa chữa", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnTDXuatExcel_Click(object sender, EventArgs e)
        {
            string title = "Xuất bill theo dỗi";
            DateTime start = dateTDStart.Value;
            DateTime end = dateTDEnd.Value;
            if (start > end)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn kết thúc", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ReponseData resData = HttpProvider.getChitietTheoDoi(start.ToString("yyyy/MM/dd"), end.ToString("yyyy/MM/dd"));
            if (checkReponseData(resData, "Không thể " + title + " vui lòng xem lại ngày tháng", title) == false)
                return;
            List<TheoDoi> theoDois = (List<TheoDoi>)resData.data;

            saveFileDialog.FileName = "theodoi";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DisableButton();
            bool res = ExcelProvider.CreateTheoDoi(ExcelObj, theoDois, Config.INSTANCE.folderPath, saveFileDialog.FileName);
            EnableButton();
            if (res == true)
            {
                if (uri != null)
                    return;
                DialogResult result = MessageBox.Show(title + " thành công\n Bạn muốn mở file lên!", title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("Xuất thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCCXuatExcel_Click(object sender, EventArgs e)
        {
            string title = "Xuất bill chấm công";
            DateTime start = dateCCStart.Value;
            ReponseData resData = HttpProvider.getChitietChamCong(start.ToString("yyyy/MM/dd"));
            if (checkReponseData(resData, "Không thể " + title + " vui lòng xem lại ngày tháng", title) == false)
                return;
            ChamCong chamCong = new ChamCong();
            chamCong.date = start.ToString("yyyy/MM/dd");
            chamCong.data = (List<ChiTietChamCong>)resData.data;
            saveFileDialog.FileName = "chamcong_" + start.ToString("yyyy/MM/dd");
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            DisableButton();
            bool res = ExcelProvider.CreateChamCong(ExcelObj, chamCong, Config.INSTANCE.folderPath, saveFileDialog.FileName);
            EnableButton();
            if (res == true)
            {
                if (uri != null)
                    return;
                DialogResult result = MessageBox.Show(title + " thành công\n Bạn muốn mở file lên!", title, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (result == DialogResult.OK)
                {
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
                }
            }
            else
            {
                MessageBox.Show("Xuất thất bại", title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TrungTrang_Load(object sender, EventArgs e)
        {
            if (uri == null)
                return;
            string query = uri.Query;
            if (query.StartsWith("?"))
                query = query.Substring(1);
            Dictionary<string, string> paramUrl = new Dictionary<string, string>();
            string[] querystrings = query.Split('&');
            foreach (string item in querystrings)
            {
                string[] paramItem = item.Split('=');
                if (paramItem.Length == 2 && paramItem[0].Trim() != "")
                    paramUrl.Add(paramItem[0].Trim(), paramItem[1].Trim());
            }
            if (uri.LocalPath == "/exportsuachua")
            {
                txtMaHoaDonSuaChua.Text = paramUrl["mahoadon"];
                tdDateStart.SelectedIndex = 1;
                btnXuatExcelSuaChua_Click(null, null);
            }
            else if (uri.LocalPath == "/exportthongke")
            {
                string start = paramUrl["start"];
                string end = paramUrl["end"];
                if (start == "" || end == "")
                    return;
                dateStart.Value = (DateTime)Convert.ChangeType(start, typeof(DateTime));
                dateEnd.Value = (DateTime)Convert.ChangeType(end, typeof(DateTime));
                btnXuatExcelThongKe_Click(null, null);
            }
            else if (uri.LocalPath == "/exporttheodoi")
            {
                string start = paramUrl["start"];
                string end = paramUrl["end"];
                if (start == "" || end == "")
                    return;
                dateTDStart.Value = (DateTime)Convert.ChangeType(start, typeof(DateTime));
                dateTDEnd.Value = (DateTime)Convert.ChangeType(end, typeof(DateTime));
                btnTDXuatExcel_Click(null, null);
            }
            else if (uri.LocalPath == "/exportchamcong")
            {
                string start = paramUrl["start"];
                if (start == "")
                    return;
                dateCCStart.Value = (DateTime)Convert.ChangeType(start, typeof(DateTime));
                btnCCXuatExcel_Click(null, null);
            }
            else
            {
                MessageBox.Show("Phần mền chưa hỗ trợ chức năng này \n Vui lòng update phần mền");
            }
            this.Close();
        }


    }
}
