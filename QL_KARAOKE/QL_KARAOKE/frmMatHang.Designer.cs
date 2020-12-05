namespace QL_KARAOKE
{
    partial class frmMatHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.txtTenMatHang = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMatHang = new System.Windows.Forms.DataGridView();
            this.txtDonGiaBan = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbDVT = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbMatHangGoc = new System.Windows.Forms.ComboBox();
            this.txtTiLe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rbtMatHang = new System.Windows.Forms.RadioButton();
            this.rbtDichVu = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Teal;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(246, 23);
            this.label2.TabIndex = 13;
            this.label2.Text = "Quản Lý Danh Sách Mặt Hàng";
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnXoa.Location = new System.Drawing.Point(886, 102);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 25);
            this.btnXoa.TabIndex = 12;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnSua.Location = new System.Drawing.Point(782, 102);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(82, 25);
            this.btnSua.TabIndex = 11;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThem.Location = new System.Drawing.Point(674, 102);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(82, 25);
            this.btnThem.TabIndex = 10;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // txtTenMatHang
            // 
            this.txtTenMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTenMatHang.Location = new System.Drawing.Point(129, 68);
            this.txtTenMatHang.Multiline = true;
            this.txtTenMatHang.Name = "txtTenMatHang";
            this.txtTenMatHang.Size = new System.Drawing.Size(244, 25);
            this.txtTenMatHang.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tên Mặt Hàng";
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
            this.dgvMatHang.Location = new System.Drawing.Point(12, 144);
            this.dgvMatHang.MultiSelect = false;
            this.dgvMatHang.Name = "dgvMatHang";
            this.dgvMatHang.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMatHang.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvMatHang.RowHeadersWidth = 51;
            this.dgvMatHang.RowTemplate.Height = 24;
            this.dgvMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMatHang.Size = new System.Drawing.Size(958, 413);
            this.dgvMatHang.TabIndex = 7;
            this.dgvMatHang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMatHang_CellClick);
            // 
            // txtDonGiaBan
            // 
            this.txtDonGiaBan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDonGiaBan.Location = new System.Drawing.Point(809, 68);
            this.txtDonGiaBan.Multiline = true;
            this.txtDonGiaBan.Name = "txtDonGiaBan";
            this.txtDonGiaBan.Size = new System.Drawing.Size(159, 25);
            this.txtDonGiaBan.TabIndex = 15;
            this.txtDonGiaBan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDonGiaBan_KeyPress);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(736, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 14;
            this.label3.Text = "Đơn Giá";
            // 
            // cbbDVT
            // 
            this.cbbDVT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbDVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbDVT.FormattingEnabled = true;
            this.cbbDVT.Location = new System.Drawing.Point(532, 71);
            this.cbbDVT.Name = "cbbDVT";
            this.cbbDVT.Size = new System.Drawing.Size(121, 24);
            this.cbbDVT.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(421, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "Đơn Vị Tính";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(9, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "Mặt Hàng Gốc";
            // 
            // cbbMatHangGoc
            // 
            this.cbbMatHangGoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbMatHangGoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.cbbMatHangGoc.FormattingEnabled = true;
            this.cbbMatHangGoc.Location = new System.Drawing.Point(129, 103);
            this.cbbMatHangGoc.Name = "cbbMatHangGoc";
            this.cbbMatHangGoc.Size = new System.Drawing.Size(244, 24);
            this.cbbMatHangGoc.TabIndex = 18;
            // 
            // txtTiLe
            // 
            this.txtTiLe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTiLe.Location = new System.Drawing.Point(532, 104);
            this.txtTiLe.Multiline = true;
            this.txtTiLe.Name = "txtTiLe";
            this.txtTiLe.Size = new System.Drawing.Size(121, 25);
            this.txtTiLe.TabIndex = 21;
            this.txtTiLe.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTiLe.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTiLe_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(404, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "Tỉ Lệ Quy Đổi";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.button1.Location = new System.Drawing.Point(886, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 25);
            this.button1.TabIndex = 22;
            this.button1.Text = "Làm Mới";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // rbtMatHang
            // 
            this.rbtMatHang.AutoSize = true;
            this.rbtMatHang.Checked = true;
            this.rbtMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtMatHang.ForeColor = System.Drawing.Color.White;
            this.rbtMatHang.Location = new System.Drawing.Point(635, 38);
            this.rbtMatHang.Name = "rbtMatHang";
            this.rbtMatHang.Size = new System.Drawing.Size(98, 21);
            this.rbtMatHang.TabIndex = 23;
            this.rbtMatHang.TabStop = true;
            this.rbtMatHang.Text = "Mặt Hàng";
            this.rbtMatHang.UseVisualStyleBackColor = true;
            this.rbtMatHang.CheckedChanged += new System.EventHandler(this.rbtMatHang_CheckedChanged);
            // 
            // rbtDichVu
            // 
            this.rbtDichVu.AutoSize = true;
            this.rbtDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtDichVu.ForeColor = System.Drawing.Color.White;
            this.rbtDichVu.Location = new System.Drawing.Point(739, 38);
            this.rbtDichVu.Name = "rbtDichVu";
            this.rbtDichVu.Size = new System.Drawing.Size(85, 21);
            this.rbtDichVu.TabIndex = 23;
            this.rbtDichVu.Text = "Dịch Vụ";
            this.rbtDichVu.UseVisualStyleBackColor = true;
            this.rbtDichVu.CheckedChanged += new System.EventHandler(this.rbtMatHang_CheckedChanged);
            // 
            // frmMatHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(982, 567);
            this.Controls.Add(this.rbtDichVu);
            this.Controls.Add(this.rbtMatHang);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTiLe);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbbMatHangGoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbbDVT);
            this.Controls.Add(this.txtDonGiaBan);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.txtTenMatHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMatHang);
            this.Name = "frmMatHang";
            this.Text = "frmMatHang";
            this.Load += new System.EventHandler(this.frmMatHang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMatHang)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTenMatHang;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMatHang;
        private System.Windows.Forms.TextBox txtDonGiaBan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbDVT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbbMatHangGoc;
        private System.Windows.Forms.TextBox txtTiLe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton rbtMatHang;
        private System.Windows.Forms.RadioButton rbtDichVu;
    }
}