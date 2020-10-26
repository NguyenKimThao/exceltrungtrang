namespace TrungTrang
{
    partial class TrungTrang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrungTrang));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tdDateStart = new System.Windows.Forms.TabControl();
            this.tabThongKeBill = new System.Windows.Forms.TabPage();
            this.btnXuatExcelThongKe = new System.Windows.Forms.Button();
            this.dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dateStart = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabSuachua = new System.Windows.Forms.TabPage();
            this.btnXuatPDFSuaChua = new System.Windows.Forms.Button();
            this.btnXuatExcelSuaChua = new System.Windows.Forms.Button();
            this.txtMaHoaDonSuaChua = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabBanle = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnTDXuatExcel = new System.Windows.Forms.Button();
            this.dateTDEnd = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTDStart = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCCXuatExcel = new System.Windows.Forms.Button();
            this.dateCCStart = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tdDateStart.SuspendLayout();
            this.tabThongKeBill.SuspendLayout();
            this.tabSuachua.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 342);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // tdDateStart
            // 
            this.tdDateStart.AllowDrop = true;
            this.tdDateStart.Controls.Add(this.tabThongKeBill);
            this.tdDateStart.Controls.Add(this.tabSuachua);
            this.tdDateStart.Controls.Add(this.tabBanle);
            this.tdDateStart.Controls.Add(this.tabPage1);
            this.tdDateStart.Controls.Add(this.tabPage2);
            this.tdDateStart.Location = new System.Drawing.Point(0, 0);
            this.tdDateStart.Name = "tdDateStart";
            this.tdDateStart.SelectedIndex = 0;
            this.tdDateStart.Size = new System.Drawing.Size(650, 342);
            this.tdDateStart.TabIndex = 1;
            // 
            // tabThongKeBill
            // 
            this.tabThongKeBill.Controls.Add(this.btnXuatExcelThongKe);
            this.tabThongKeBill.Controls.Add(this.dateEnd);
            this.tabThongKeBill.Controls.Add(this.label5);
            this.tabThongKeBill.Controls.Add(this.dateStart);
            this.tabThongKeBill.Controls.Add(this.label4);
            this.tabThongKeBill.Controls.Add(this.label3);
            this.tabThongKeBill.Location = new System.Drawing.Point(4, 22);
            this.tabThongKeBill.Name = "tabThongKeBill";
            this.tabThongKeBill.Padding = new System.Windows.Forms.Padding(3);
            this.tabThongKeBill.Size = new System.Drawing.Size(642, 316);
            this.tabThongKeBill.TabIndex = 2;
            this.tabThongKeBill.Text = "Thống Kê Bill";
            this.tabThongKeBill.UseVisualStyleBackColor = true;
            // 
            // btnXuatExcelThongKe
            // 
            this.btnXuatExcelThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelThongKe.Location = new System.Drawing.Point(238, 223);
            this.btnXuatExcelThongKe.Name = "btnXuatExcelThongKe";
            this.btnXuatExcelThongKe.Size = new System.Drawing.Size(139, 38);
            this.btnXuatExcelThongKe.TabIndex = 6;
            this.btnXuatExcelThongKe.Text = "Xuất Excel";
            this.btnXuatExcelThongKe.UseVisualStyleBackColor = true;
            this.btnXuatExcelThongKe.Click += new System.EventHandler(this.btnXuatExcelThongKe_Click);
            // 
            // dateEnd
            // 
            this.dateEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEnd.CustomFormat = "dd/MM/yyyy";
            this.dateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEnd.Location = new System.Drawing.Point(454, 123);
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.Size = new System.Drawing.Size(154, 31);
            this.dateEnd.TabIndex = 5;
            this.dateEnd.Value = new System.DateTime(2020, 8, 11, 13, 22, 50, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(357, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kết thúc";
            // 
            // dateStart
            // 
            this.dateStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateStart.CustomFormat = "dd/MM/yyyy";
            this.dateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateStart.Location = new System.Drawing.Point(111, 124);
            this.dateStart.Name = "dateStart";
            this.dateStart.Size = new System.Drawing.Size(154, 31);
            this.dateStart.TabIndex = 3;
            this.dateStart.Value = new System.DateTime(2020, 8, 11, 13, 22, 50, 0);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Bất đầu";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(123, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(412, 55);
            this.label3.TabIndex = 1;
            this.label3.Text = "Xuất Bill Thống kê";
            // 
            // tabSuachua
            // 
            this.tabSuachua.Controls.Add(this.btnXuatPDFSuaChua);
            this.tabSuachua.Controls.Add(this.btnXuatExcelSuaChua);
            this.tabSuachua.Controls.Add(this.txtMaHoaDonSuaChua);
            this.tabSuachua.Controls.Add(this.label2);
            this.tabSuachua.Controls.Add(this.label1);
            this.tabSuachua.Location = new System.Drawing.Point(4, 22);
            this.tabSuachua.Name = "tabSuachua";
            this.tabSuachua.Padding = new System.Windows.Forms.Padding(3);
            this.tabSuachua.Size = new System.Drawing.Size(642, 316);
            this.tabSuachua.TabIndex = 0;
            this.tabSuachua.Text = "Bill Sữa Chữa";
            this.tabSuachua.UseVisualStyleBackColor = true;
            // 
            // btnXuatPDFSuaChua
            // 
            this.btnXuatPDFSuaChua.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatPDFSuaChua.Location = new System.Drawing.Point(72, 227);
            this.btnXuatPDFSuaChua.Name = "btnXuatPDFSuaChua";
            this.btnXuatPDFSuaChua.Size = new System.Drawing.Size(139, 38);
            this.btnXuatPDFSuaChua.TabIndex = 4;
            this.btnXuatPDFSuaChua.Text = "Xuất PDF";
            this.btnXuatPDFSuaChua.UseVisualStyleBackColor = true;
            this.btnXuatPDFSuaChua.Click += new System.EventHandler(this.btnXuatPDFSuaChua_Click);
            // 
            // btnXuatExcelSuaChua
            // 
            this.btnXuatExcelSuaChua.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuatExcelSuaChua.Location = new System.Drawing.Point(354, 227);
            this.btnXuatExcelSuaChua.Name = "btnXuatExcelSuaChua";
            this.btnXuatExcelSuaChua.Size = new System.Drawing.Size(139, 38);
            this.btnXuatExcelSuaChua.TabIndex = 3;
            this.btnXuatExcelSuaChua.Text = "Xuất Excel";
            this.btnXuatExcelSuaChua.UseVisualStyleBackColor = true;
            this.btnXuatExcelSuaChua.Click += new System.EventHandler(this.btnXuatExcelSuaChua_Click);
            // 
            // txtMaHoaDonSuaChua
            // 
            this.txtMaHoaDonSuaChua.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMaHoaDonSuaChua.Location = new System.Drawing.Point(238, 136);
            this.txtMaHoaDonSuaChua.Name = "txtMaHoaDonSuaChua";
            this.txtMaHoaDonSuaChua.Size = new System.Drawing.Size(335, 31);
            this.txtMaHoaDonSuaChua.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập Mã Hóa Đơn";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Xuất Bill Sữa Chữa";
            // 
            // tabBanle
            // 
            this.tabBanle.Location = new System.Drawing.Point(4, 22);
            this.tabBanle.Name = "tabBanle";
            this.tabBanle.Padding = new System.Windows.Forms.Padding(3);
            this.tabBanle.Size = new System.Drawing.Size(642, 316);
            this.tabBanle.TabIndex = 1;
            this.tabBanle.Text = "Bill Bán lẻ";
            this.tabBanle.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCCXuatExcel);
            this.tabPage1.Controls.Add(this.dateCCStart);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(642, 316);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Chấm công";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnTDXuatExcel);
            this.tabPage2.Controls.Add(this.dateTDEnd);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.dateTDStart);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(642, 316);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Text = "Theo dỗi";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnTDXuatExcel
            // 
            this.btnTDXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTDXuatExcel.Location = new System.Drawing.Point(254, 241);
            this.btnTDXuatExcel.Name = "btnTDXuatExcel";
            this.btnTDXuatExcel.Size = new System.Drawing.Size(139, 38);
            this.btnTDXuatExcel.TabIndex = 12;
            this.btnTDXuatExcel.Text = "Xuất Excel";
            this.btnTDXuatExcel.UseVisualStyleBackColor = true;
            this.btnTDXuatExcel.Click += new System.EventHandler(this.btnTDXuatExcel_Click);
            // 
            // dateTDEnd
            // 
            this.dateTDEnd.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTDEnd.CustomFormat = "dd/MM/yyyy";
            this.dateTDEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTDEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTDEnd.Location = new System.Drawing.Point(470, 141);
            this.dateTDEnd.Name = "dateTDEnd";
            this.dateTDEnd.Size = new System.Drawing.Size(154, 31);
            this.dateTDEnd.TabIndex = 11;
            this.dateTDEnd.Value = new System.DateTime(2020, 8, 11, 13, 22, 50, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(373, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 25);
            this.label6.TabIndex = 10;
            this.label6.Text = "Kết thúc";
            // 
            // dateTDStart
            // 
            this.dateTDStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTDStart.CustomFormat = "dd/MM/yyyy";
            this.dateTDStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTDStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTDStart.Location = new System.Drawing.Point(127, 142);
            this.dateTDStart.Name = "dateTDStart";
            this.dateTDStart.Size = new System.Drawing.Size(154, 31);
            this.dateTDStart.TabIndex = 9;
            this.dateTDStart.Value = new System.DateTime(2020, 8, 11, 13, 22, 50, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(35, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 25);
            this.label7.TabIndex = 8;
            this.label7.Text = "Bất đầu";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(117, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(398, 55);
            this.label8.TabIndex = 7;
            this.label8.Text = "Xuất Bill Theo dỗi";
            // 
            // btnCCXuatExcel
            // 
            this.btnCCXuatExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCCXuatExcel.Location = new System.Drawing.Point(243, 247);
            this.btnCCXuatExcel.Name = "btnCCXuatExcel";
            this.btnCCXuatExcel.Size = new System.Drawing.Size(139, 38);
            this.btnCCXuatExcel.TabIndex = 16;
            this.btnCCXuatExcel.Text = "Xuất Excel";
            this.btnCCXuatExcel.UseVisualStyleBackColor = true;
            this.btnCCXuatExcel.Click += new System.EventHandler(this.btnCCXuatExcel_Click);
            // 
            // dateCCStart
            // 
            this.dateCCStart.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCCStart.CustomFormat = "dd/MM/yyyy";
            this.dateCCStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCCStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateCCStart.Location = new System.Drawing.Point(338, 135);
            this.dateCCStart.Name = "dateCCStart";
            this.dateCCStart.Size = new System.Drawing.Size(179, 31);
            this.dateCCStart.TabIndex = 15;
            this.dateCCStart.Value = new System.DateTime(2020, 8, 11, 13, 22, 50, 0);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(176, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 25);
            this.label9.TabIndex = 14;
            this.label9.Text = "Chọn Ngày";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(133, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(469, 55);
            this.label10.TabIndex = 13;
            this.label10.Text = "Xuất Bill Chấm Công";
            // 
            // TrungTrang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 342);
            this.Controls.Add(this.tdDateStart);
            this.Controls.Add(this.splitter1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "TrungTrang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TrungTrang";
            this.Load += new System.EventHandler(this.TrungTrang_Load);
            this.tdDateStart.ResumeLayout(false);
            this.tabThongKeBill.ResumeLayout(false);
            this.tabThongKeBill.PerformLayout();
            this.tabSuachua.ResumeLayout(false);
            this.tabSuachua.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tdDateStart;
        private System.Windows.Forms.TabPage tabSuachua;
        private System.Windows.Forms.TabPage tabBanle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXuatExcelSuaChua;
        private System.Windows.Forms.TextBox txtMaHoaDonSuaChua;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXuatPDFSuaChua;
        private System.Windows.Forms.TabPage tabThongKeBill;
        private System.Windows.Forms.DateTimePicker dateStart;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnXuatExcelThongKe;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnTDXuatExcel;
        private System.Windows.Forms.DateTimePicker dateTDEnd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dateTDStart;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnCCXuatExcel;
        private System.Windows.Forms.DateTimePicker dateCCStart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}