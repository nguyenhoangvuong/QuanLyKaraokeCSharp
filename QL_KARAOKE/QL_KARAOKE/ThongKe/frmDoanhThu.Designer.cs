namespace QL_KARAOKE
{
    partial class frmDoanhThu
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
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbTuNgay = new System.Windows.Forms.MaskedTextBox();
            this.mtbToiNgay = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbItems = new System.Windows.Forms.ComboBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.ckbTatCa = new System.Windows.Forms.CheckBox();
            this.ckbMatHang = new System.Windows.Forms.CheckBox();
            this.ckbDichVu = new System.Windows.Forms.CheckBox();
            this.ckbPhong = new System.Windows.Forms.CheckBox();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.lblThanhChu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(-6, 132);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 24;
            this.dgvThongKe.Size = new System.Drawing.Size(980, 392);
            this.dgvThongKe.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(741, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Thống Kê Doanh Thu";
            // 
            // mtbTuNgay
            // 
            this.mtbTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mtbTuNgay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbTuNgay.Location = new System.Drawing.Point(174, 34);
            this.mtbTuNgay.Mask = "00/00/0000 90:00";
            this.mtbTuNgay.Name = "mtbTuNgay";
            this.mtbTuNgay.Size = new System.Drawing.Size(160, 22);
            this.mtbTuNgay.TabIndex = 3;
            this.mtbTuNgay.ValidatingType = typeof(System.DateTime);
            // 
            // mtbToiNgay
            // 
            this.mtbToiNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbToiNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mtbToiNgay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbToiNgay.Location = new System.Drawing.Point(174, 86);
            this.mtbToiNgay.Mask = "00/00/0000 90:00";
            this.mtbToiNgay.Name = "mtbToiNgay";
            this.mtbToiNgay.Size = new System.Drawing.Size(160, 22);
            this.mtbToiNgay.TabIndex = 3;
            this.mtbToiNgay.ValidatingType = typeof(System.DateTime);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(91, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Từ ngày :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(91, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tới ngày :";
            // 
            // cbbItems
            // 
            this.cbbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbItems.FormattingEnabled = true;
            this.cbbItems.Location = new System.Drawing.Point(611, 89);
            this.cbbItems.Name = "cbbItems";
            this.cbbItems.Size = new System.Drawing.Size(211, 24);
            this.cbbItems.TabIndex = 6;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.CadetBlue;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(849, 83);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(109, 30);
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // ckbTatCa
            // 
            this.ckbTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbTatCa.AutoSize = true;
            this.ckbTatCa.Checked = true;
            this.ckbTatCa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbTatCa.ForeColor = System.Drawing.Color.White;
            this.ckbTatCa.Location = new System.Drawing.Point(390, 37);
            this.ckbTatCa.Name = "ckbTatCa";
            this.ckbTatCa.Size = new System.Drawing.Size(72, 21);
            this.ckbTatCa.TabIndex = 8;
            this.ckbTatCa.Text = "Tất Cả";
            this.ckbTatCa.UseVisualStyleBackColor = true;
            this.ckbTatCa.CheckedChanged += new System.EventHandler(this.ckbTatCa_CheckedChanged);
            // 
            // ckbMatHang
            // 
            this.ckbMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbMatHang.AutoSize = true;
            this.ckbMatHang.Checked = true;
            this.ckbMatHang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbMatHang.ForeColor = System.Drawing.Color.White;
            this.ckbMatHang.Location = new System.Drawing.Point(390, 87);
            this.ckbMatHang.Name = "ckbMatHang";
            this.ckbMatHang.Size = new System.Drawing.Size(91, 21);
            this.ckbMatHang.TabIndex = 8;
            this.ckbMatHang.Text = "Mặt Hàng";
            this.ckbMatHang.UseVisualStyleBackColor = true;
            this.ckbMatHang.CheckedChanged += new System.EventHandler(this.ckbBaThangCon_CheckedChanged);
            // 
            // ckbDichVu
            // 
            this.ckbDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbDichVu.AutoSize = true;
            this.ckbDichVu.Checked = true;
            this.ckbDichVu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbDichVu.ForeColor = System.Drawing.Color.White;
            this.ckbDichVu.Location = new System.Drawing.Point(510, 36);
            this.ckbDichVu.Name = "ckbDichVu";
            this.ckbDichVu.Size = new System.Drawing.Size(79, 21);
            this.ckbDichVu.TabIndex = 8;
            this.ckbDichVu.Text = "Dịch Vụ";
            this.ckbDichVu.UseVisualStyleBackColor = true;
            this.ckbDichVu.CheckedChanged += new System.EventHandler(this.ckbBaThangCon_CheckedChanged);
            // 
            // ckbPhong
            // 
            this.ckbPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ckbPhong.AutoSize = true;
            this.ckbPhong.Checked = true;
            this.ckbPhong.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbPhong.ForeColor = System.Drawing.Color.White;
            this.ckbPhong.Location = new System.Drawing.Point(510, 87);
            this.ckbPhong.Name = "ckbPhong";
            this.ckbPhong.Size = new System.Drawing.Size(71, 21);
            this.ckbPhong.TabIndex = 8;
            this.ckbPhong.Text = "Phòng";
            this.ckbPhong.UseVisualStyleBackColor = true;
            this.ckbPhong.CheckedChanged += new System.EventHandler(this.ckbBaThangCon_CheckedChanged);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTongTien.ForeColor = System.Drawing.Color.White;
            this.lblTongTien.Location = new System.Drawing.Point(12, 527);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(77, 17);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Từ ngày :";
            // 
            // lblThanhChu
            // 
            this.lblThanhChu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThanhChu.AutoSize = true;
            this.lblThanhChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblThanhChu.ForeColor = System.Drawing.Color.White;
            this.lblThanhChu.Location = new System.Drawing.Point(12, 555);
            this.lblThanhChu.Name = "lblThanhChu";
            this.lblThanhChu.Size = new System.Drawing.Size(77, 17);
            this.lblThanhChu.TabIndex = 5;
            this.lblThanhChu.Text = "Từ ngày :";
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(973, 581);
            this.Controls.Add(this.ckbPhong);
            this.Controls.Add(this.ckbDichVu);
            this.Controls.Add(this.ckbMatHang);
            this.Controls.Add(this.ckbTatCa);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.cbbItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblThanhChu);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mtbToiNgay);
            this.Controls.Add(this.mtbTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvThongKe);
            this.Name = "frmDoanhThu";
            this.Text = "DoanhThu";
            this.Load += new System.EventHandler(this.frmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbTuNgay;
        private System.Windows.Forms.MaskedTextBox mtbToiNgay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbItems;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.CheckBox ckbTatCa;
        private System.Windows.Forms.CheckBox ckbMatHang;
        private System.Windows.Forms.CheckBox ckbDichVu;
        private System.Windows.Forms.CheckBox ckbPhong;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label lblThanhChu;
    }
}