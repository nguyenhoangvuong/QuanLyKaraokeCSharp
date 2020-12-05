namespace QL_KARAOKE
{
    partial class frmChiTietHoaDonNhap
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
            this.dgvMatHang = new System.Windows.Forms.DataGridView();
            this.cbbMatHang = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDonGiaNhap = new System.Windows.Forms.TextBox();
            this.txtSL = new System.Windows.Forms.TextBox();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.rbtYeuCau = new System.Windows.Forms.RadioButton();
            this.rbtNhapKho = new System.Windows.Forms.RadioButton();
            this.txtTienThanhToan = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.lblTongTien = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMatHang
            // 
            this.dgvMatHang.AllowUserToAddRows = false;
            this.dgvMatHang.AllowUserToDeleteRows = false;
            this.dgvMatHang.AllowUserToOrderColumns = true;
            this.dgvMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMatHang.Location = new System.Drawing.Point(12, 102);
            this.dgvMatHang.MultiSelect = false;
            this.dgvMatHang.Name = "dgvMatHang";
            this.dgvMatHang.ReadOnly = true;
            this.dgvMatHang.RowHeadersWidth = 51;
            this.dgvMatHang.RowTemplate.Height = 24;
            this.dgvMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatHang.Size = new System.Drawing.Size(1084, 464);
            this.dgvMatHang.TabIndex = 55;
            this.dgvMatHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatHang_CellClick);
            // 
            // cbbMatHang
            // 
            this.cbbMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbMatHang.FormattingEnabled = true;
            this.cbbMatHang.Location = new System.Drawing.Point(326, 30);
            this.cbbMatHang.Name = "cbbMatHang";
            this.cbbMatHang.Size = new System.Drawing.Size(318, 24);
            this.cbbMatHang.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(243, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 64;
            this.label1.Text = "Mặt Hàng";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(690, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 17);
            this.label2.TabIndex = 66;
            this.label2.Text = "Đơn Giá";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(963, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 17);
            this.label3.TabIndex = 67;
            this.label3.Text = "SL";
            // 
            // txtDonGiaNhap
            // 
            this.txtDonGiaNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDonGiaNhap.Location = new System.Drawing.Point(773, 30);
            this.txtDonGiaNhap.Name = "txtDonGiaNhap";
            this.txtDonGiaNhap.Size = new System.Drawing.Size(147, 22);
            this.txtDonGiaNhap.TabIndex = 68;
            // 
            // txtSL
            // 
            this.txtSL.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSL.Location = new System.Drawing.Point(996, 30);
            this.txtSL.Name = "txtSL";
            this.txtSL.Size = new System.Drawing.Size(100, 22);
            this.txtSL.TabIndex = 69;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.Location = new System.Drawing.Point(1014, 71);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 25);
            this.btnXoa.TabIndex = 73;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Location = new System.Drawing.Point(926, 71);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 25);
            this.btnThem.TabIndex = 71;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // rbtYeuCau
            // 
            this.rbtYeuCau.AutoSize = true;
            this.rbtYeuCau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtYeuCau.ForeColor = System.Drawing.Color.White;
            this.rbtYeuCau.Location = new System.Drawing.Point(380, 589);
            this.rbtYeuCau.Name = "rbtYeuCau";
            this.rbtYeuCau.Size = new System.Drawing.Size(90, 21);
            this.rbtYeuCau.TabIndex = 74;
            this.rbtYeuCau.TabStop = true;
            this.rbtYeuCau.Text = "Yêu Cầu";
            this.rbtYeuCau.UseVisualStyleBackColor = true;
            this.rbtYeuCau.Click += new System.EventHandler(this.rbtNhapKho_Click);
            // 
            // rbtNhapKho
            // 
            this.rbtNhapKho.AutoSize = true;
            this.rbtNhapKho.Checked = true;
            this.rbtNhapKho.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtNhapKho.ForeColor = System.Drawing.Color.White;
            this.rbtNhapKho.Location = new System.Drawing.Point(518, 589);
            this.rbtNhapKho.Name = "rbtNhapKho";
            this.rbtNhapKho.Size = new System.Drawing.Size(100, 21);
            this.rbtNhapKho.TabIndex = 75;
            this.rbtNhapKho.TabStop = true;
            this.rbtNhapKho.Text = "Nhập Kho";
            this.rbtNhapKho.UseVisualStyleBackColor = true;
            this.rbtNhapKho.Click += new System.EventHandler(this.rbtNhapKho_Click);
            // 
            // txtTienThanhToan
            // 
            this.txtTienThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTienThanhToan.Location = new System.Drawing.Point(749, 588);
            this.txtTienThanhToan.Name = "txtTienThanhToan";
            this.txtTienThanhToan.Size = new System.Drawing.Size(211, 22);
            this.txtTienThanhToan.TabIndex = 77;
            this.txtTienThanhToan.Text = "0";
            this.txtTienThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(647, 591);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 17);
            this.label4.TabIndex = 76;
            this.label4.Text = "Thanh Toán";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXacNhan.Location = new System.Drawing.Point(966, 585);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(130, 25);
            this.btnXacNhan.TabIndex = 78;
            this.btnXacNhan.Text = "Xác Nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Transparent;
            this.lblTongTien.Location = new System.Drawing.Point(9, 569);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(96, 17);
            this.lblTongTien.TabIndex = 79;
            this.lblTongTien.Text = "Thanh Toán";
            // 
            // frmChiTietHoaDonNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1108, 622);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtTienThanhToan);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rbtNhapKho);
            this.Controls.Add(this.rbtYeuCau);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtSL);
            this.Controls.Add(this.txtDonGiaNhap);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbMatHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMatHang);
            this.Name = "frmChiTietHoaDonNhap";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi Tiết Hóa Đơn Nhập";
            this.Load += new System.EventHandler(this.frmChiTietHoaDonNhap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMatHang;
        private System.Windows.Forms.ComboBox cbbMatHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.TextBox txtSL;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.RadioButton rbtYeuCau;
        private System.Windows.Forms.RadioButton rbtNhapKho;
        private System.Windows.Forms.TextBox txtTienThanhToan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Label lblTongTien;
    }
}