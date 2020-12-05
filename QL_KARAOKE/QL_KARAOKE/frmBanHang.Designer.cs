namespace QL_KARAOKE
{
    partial class frmBanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanHang));
            this.pnlControl = new System.Windows.Forms.Panel();
            this.dgvDanhSachMatHang = new System.Windows.Forms.DataGridView();
            this.lblPhongDangChon = new System.Windows.Forms.Label();
            this.panelOrder = new System.Windows.Forms.Panel();
            this.dgvChiTietBanHang = new System.Windows.Forms.DataGridView();
            this.pnlThoiGian = new System.Windows.Forms.Panel();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.mtbKetThuc = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.mtbBatDau = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblChiTietPhong = new System.Windows.Forms.Label();
            this.tbcBanHang = new System.Windows.Forms.TabControl();
            this.tbBanHang = new System.Windows.Forms.TabPage();
            this.tbcContent = new System.Windows.Forms.TabControl();
            this.tbLSBH = new System.Windows.Forms.TabPage();
            this.dgvLSGD = new System.Windows.Forms.DataGridView();
            this.pdHoaDon = new System.Drawing.Printing.PrintDocument();
            this.pddHoaDon = new System.Windows.Forms.PrintPreviewDialog();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMatHang)).BeginInit();
            this.panelOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBanHang)).BeginInit();
            this.pnlThoiGian.SuspendLayout();
            this.tbcBanHang.SuspendLayout();
            this.tbBanHang.SuspendLayout();
            this.tbLSBH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.dgvDanhSachMatHang);
            this.pnlControl.Controls.Add(this.lblPhongDangChon);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(868, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(387, 589);
            this.pnlControl.TabIndex = 1;
            // 
            // dgvDanhSachMatHang
            // 
            this.dgvDanhSachMatHang.AllowUserToAddRows = false;
            this.dgvDanhSachMatHang.AllowUserToDeleteRows = false;
            this.dgvDanhSachMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachMatHang.Location = new System.Drawing.Point(3, 37);
            this.dgvDanhSachMatHang.MultiSelect = false;
            this.dgvDanhSachMatHang.Name = "dgvDanhSachMatHang";
            this.dgvDanhSachMatHang.ReadOnly = true;
            this.dgvDanhSachMatHang.RowHeadersWidth = 51;
            this.dgvDanhSachMatHang.RowTemplate.Height = 24;
            this.dgvDanhSachMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachMatHang.Size = new System.Drawing.Size(384, 552);
            this.dgvDanhSachMatHang.TabIndex = 4;
            this.dgvDanhSachMatHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachMatHang_CellDoubleClick);
            // 
            // lblPhongDangChon
            // 
            this.lblPhongDangChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPhongDangChon.ForeColor = System.Drawing.Color.Red;
            this.lblPhongDangChon.Location = new System.Drawing.Point(3, 0);
            this.lblPhongDangChon.Name = "lblPhongDangChon";
            this.lblPhongDangChon.Size = new System.Drawing.Size(384, 34);
            this.lblPhongDangChon.TabIndex = 0;
            this.lblPhongDangChon.Text = "Tên Phòng";
            this.lblPhongDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panelOrder
            // 
            this.panelOrder.Controls.Add(this.dgvChiTietBanHang);
            this.panelOrder.Controls.Add(this.pnlThoiGian);
            this.panelOrder.Controls.Add(this.lblChiTietPhong);
            this.panelOrder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOrder.Location = new System.Drawing.Point(0, 398);
            this.panelOrder.Name = "panelOrder";
            this.panelOrder.Size = new System.Drawing.Size(868, 191);
            this.panelOrder.TabIndex = 2;
            // 
            // dgvChiTietBanHang
            // 
            this.dgvChiTietBanHang.AllowUserToAddRows = false;
            this.dgvChiTietBanHang.AllowUserToDeleteRows = false;
            this.dgvChiTietBanHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietBanHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietBanHang.Location = new System.Drawing.Point(272, 49);
            this.dgvChiTietBanHang.MultiSelect = false;
            this.dgvChiTietBanHang.Name = "dgvChiTietBanHang";
            this.dgvChiTietBanHang.ReadOnly = true;
            this.dgvChiTietBanHang.RowHeadersWidth = 51;
            this.dgvChiTietBanHang.RowTemplate.Height = 24;
            this.dgvChiTietBanHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietBanHang.Size = new System.Drawing.Size(596, 142);
            this.dgvChiTietBanHang.TabIndex = 5;
            // 
            // pnlThoiGian
            // 
            this.pnlThoiGian.Controls.Add(this.btnBatDau);
            this.pnlThoiGian.Controls.Add(this.btnKetThuc);
            this.pnlThoiGian.Controls.Add(this.mtbKetThuc);
            this.pnlThoiGian.Controls.Add(this.label4);
            this.pnlThoiGian.Controls.Add(this.mtbBatDau);
            this.pnlThoiGian.Controls.Add(this.label3);
            this.pnlThoiGian.Location = new System.Drawing.Point(7, 49);
            this.pnlThoiGian.Name = "pnlThoiGian";
            this.pnlThoiGian.Size = new System.Drawing.Size(259, 139);
            this.pnlThoiGian.TabIndex = 3;
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.CadetBlue;
            this.btnBatDau.Enabled = false;
            this.btnBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(3, 102);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(123, 33);
            this.btnBatDau.TabIndex = 10;
            this.btnBatDau.Text = "Bắt Đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.BackColor = System.Drawing.Color.CadetBlue;
            this.btnKetThuc.Enabled = false;
            this.btnKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKetThuc.ForeColor = System.Drawing.Color.White;
            this.btnKetThuc.Location = new System.Drawing.Point(133, 102);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(123, 33);
            this.btnKetThuc.TabIndex = 9;
            this.btnKetThuc.Text = "Kết Thúc";
            this.btnKetThuc.UseVisualStyleBackColor = false;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // mtbKetThuc
            // 
            this.mtbKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mtbKetThuc.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbKetThuc.Location = new System.Drawing.Point(77, 70);
            this.mtbKetThuc.Mask = "00/00/0000 90:00";
            this.mtbKetThuc.Name = "mtbKetThuc";
            this.mtbKetThuc.Size = new System.Drawing.Size(153, 22);
            this.mtbKetThuc.TabIndex = 8;
            this.mtbKetThuc.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kết Thúc";
            // 
            // mtbBatDau
            // 
            this.mtbBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mtbBatDau.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbBatDau.Location = new System.Drawing.Point(77, 22);
            this.mtbBatDau.Mask = "00/00/0000 90:00";
            this.mtbBatDau.Name = "mtbBatDau";
            this.mtbBatDau.Size = new System.Drawing.Size(153, 22);
            this.mtbBatDau.TabIndex = 5;
            this.mtbBatDau.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bắt Đầu";
            // 
            // lblChiTietPhong
            // 
            this.lblChiTietPhong.AutoSize = true;
            this.lblChiTietPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblChiTietPhong.ForeColor = System.Drawing.Color.White;
            this.lblChiTietPhong.Location = new System.Drawing.Point(7, 16);
            this.lblChiTietPhong.Name = "lblChiTietPhong";
            this.lblChiTietPhong.Size = new System.Drawing.Size(315, 18);
            this.lblChiTietPhong.TabIndex = 1;
            this.lblChiTietPhong.Text = "Danh Sách Mặt Hàng Phòng Đã Sử Dụng";
            // 
            // tbcBanHang
            // 
            this.tbcBanHang.Controls.Add(this.tbBanHang);
            this.tbcBanHang.Controls.Add(this.tbLSBH);
            this.tbcBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcBanHang.Location = new System.Drawing.Point(0, 0);
            this.tbcBanHang.Name = "tbcBanHang";
            this.tbcBanHang.SelectedIndex = 0;
            this.tbcBanHang.Size = new System.Drawing.Size(868, 398);
            this.tbcBanHang.TabIndex = 3;
            // 
            // tbBanHang
            // 
            this.tbBanHang.Controls.Add(this.tbcContent);
            this.tbBanHang.Location = new System.Drawing.Point(4, 25);
            this.tbBanHang.Name = "tbBanHang";
            this.tbBanHang.Padding = new System.Windows.Forms.Padding(3);
            this.tbBanHang.Size = new System.Drawing.Size(860, 369);
            this.tbBanHang.TabIndex = 0;
            this.tbBanHang.Text = "Bán Hàng";
            this.tbBanHang.UseVisualStyleBackColor = true;
            // 
            // tbcContent
            // 
            this.tbcContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbcContent.Location = new System.Drawing.Point(-2, 0);
            this.tbcContent.Name = "tbcContent";
            this.tbcContent.SelectedIndex = 0;
            this.tbcContent.Size = new System.Drawing.Size(865, 384);
            this.tbcContent.TabIndex = 1;
            this.tbcContent.SelectedIndexChanged += new System.EventHandler(this.tbcContent_SelectedIndexChanged);
            // 
            // tbLSBH
            // 
            this.tbLSBH.Controls.Add(this.dgvLSGD);
            this.tbLSBH.Location = new System.Drawing.Point(4, 25);
            this.tbLSBH.Name = "tbLSBH";
            this.tbLSBH.Padding = new System.Windows.Forms.Padding(3);
            this.tbLSBH.Size = new System.Drawing.Size(860, 369);
            this.tbLSBH.TabIndex = 1;
            this.tbLSBH.Text = "Lịch Sử Giao Dịch";
            this.tbLSBH.UseVisualStyleBackColor = true;
            // 
            // dgvLSGD
            // 
            this.dgvLSGD.AllowUserToAddRows = false;
            this.dgvLSGD.AllowUserToDeleteRows = false;
            this.dgvLSGD.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLSGD.BackgroundColor = System.Drawing.Color.White;
            this.dgvLSGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLSGD.Location = new System.Drawing.Point(3, 0);
            this.dgvLSGD.Name = "dgvLSGD";
            this.dgvLSGD.ReadOnly = true;
            this.dgvLSGD.RowHeadersWidth = 51;
            this.dgvLSGD.RowTemplate.Height = 24;
            this.dgvLSGD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLSGD.Size = new System.Drawing.Size(861, 373);
            this.dgvLSGD.TabIndex = 0;
            this.dgvLSGD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLSGD_CellDoubleClick);
            // 
            // pdHoaDon
            // 
            this.pdHoaDon.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.pdHoaDon_PrintPage);
            // 
            // pddHoaDon
            // 
            this.pddHoaDon.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.pddHoaDon.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.pddHoaDon.ClientSize = new System.Drawing.Size(400, 300);
            this.pddHoaDon.Enabled = true;
            this.pddHoaDon.Icon = ((System.Drawing.Icon)(resources.GetObject("pddHoaDon.Icon")));
            this.pddHoaDon.Name = "pddHoaDon";
            this.pddHoaDon.Visible = false;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1255, 589);
            this.Controls.Add(this.tbcBanHang);
            this.Controls.Add(this.panelOrder);
            this.Controls.Add(this.pnlControl);
            this.Name = "frmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBanHang";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMatHang)).EndInit();
            this.panelOrder.ResumeLayout(false);
            this.panelOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBanHang)).EndInit();
            this.pnlThoiGian.ResumeLayout(false);
            this.pnlThoiGian.PerformLayout();
            this.tbcBanHang.ResumeLayout(false);
            this.tbBanHang.ResumeLayout(false);
            this.tbLSBH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.DataGridView dgvDanhSachMatHang;
        private System.Windows.Forms.Label lblPhongDangChon;
        private System.Windows.Forms.Panel panelOrder;
        private System.Windows.Forms.Panel pnlThoiGian;
        private System.Windows.Forms.MaskedTextBox mtbBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblChiTietPhong;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.MaskedTextBox mtbKetThuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvChiTietBanHang;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.TabControl tbcBanHang;
        private System.Windows.Forms.TabPage tbBanHang;
        private System.Windows.Forms.TabControl tbcContent;
        private System.Windows.Forms.TabPage tbLSBH;
        private System.Windows.Forms.DataGridView dgvLSGD;
        private System.Drawing.Printing.PrintDocument pdHoaDon;
        private System.Windows.Forms.PrintPreviewDialog pddHoaDon;
    }
}