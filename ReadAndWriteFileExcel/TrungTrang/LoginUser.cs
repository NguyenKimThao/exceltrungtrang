using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrungTrang.DTO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TrungTrang
{
    public partial class LoginUser : Form
    {
        private string[] args;
        private bool isLogin = false;
        public LoginUser(string[] args)
        {
            this.args = args;
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.username = txtTaiKhoan.Text;

            HostConfig host = (HostConfig)cbbChiNhanh.SelectedValue;
            if (host == null)
            {
                MessageBox.Show("Không tìm thấy chi nhánh", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool isLogin = txtMatKhau.Text.Length > 0;
            if (isLogin)
            {
                Properties.Settings.Default.token = txtMatKhau.Text;
                Properties.Settings.Default.host = host.key;
                Properties.Settings.Default.Save();
                showTrungTrang();
            }
        }

        private void LoginUser_Load(object sender, EventArgs e)
        {
            string username = Properties.Settings.Default.username;
            if (username != null && username.Length > 0)
            {
                txtTaiKhoan.Text = username;
            }
            txtMatKhau.Text = Config.INSTANCE.hostConfig.host;
            cbbChiNhanh.DataSource = Config.INSTANCE.hostConfigs;
            cbbChiNhanh.DisplayMember = "name";

            cbbChiNhanh.SelectedItem = Config.INSTANCE.hostConfig;
        }

        private void LoginUser_Shown(object sender, EventArgs e)
        {
            string token = Properties.Settings.Default.token;
            bool isLogin = token != null && token.Length != 0;
            if (isLogin && false)
            {
                showTrungTrang();
            }
        }

        public void showTrungTrang()
        {
            this.Opacity = 0.0f;
            this.ShowInTaskbar = false;
            this.Hide();
            TrungTrang trungTrang = new TrungTrang(this.args);
            trungTrang.Closed += (s, args) => this.Close();
            trungTrang.Show();
        }
    }
}
