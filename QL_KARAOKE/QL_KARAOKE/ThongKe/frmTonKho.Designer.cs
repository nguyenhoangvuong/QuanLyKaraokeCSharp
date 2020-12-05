namespace QL_KARAOKE
{
    partial class frmTonKho
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
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtTatCa = new System.Windows.Forms.RadioButton();
            this.rbtGanHet = new System.Windows.Forms.RadioButton();
            this.rbtDaHet = new System.Windows.Forms.RadioButton();
            this.btnThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            this.dgvTonKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKho.Location = new System.Drawing.Point(2, 126);
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.RowHeadersWidth = 51;
            this.dgvTonKho.RowTemplate.Height = 24;
            this.dgvTonKho.Size = new System.Drawing.Size(914, 407);
            this.dgvTonKho.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(709, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Thống Kê Tồn Kho";
            // 
            // rbtTatCa
            // 
            this.rbtTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtTatCa.AutoSize = true;
            this.rbtTatCa.BackColor = System.Drawing.Color.CadetBlue;
            this.rbtTatCa.Checked = true;
            this.rbtTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtTatCa.ForeColor = System.Drawing.Color.White;
            this.rbtTatCa.Location = new System.Drawing.Point(373, 77);
            this.rbtTatCa.Name = "rbtTatCa";
            this.rbtTatCa.Size = new System.Drawing.Size(147, 21);
            this.rbtTatCa.TabIndex = 2;
            this.rbtTatCa.TabStop = true;
            this.rbtTatCa.Text = "Tất cả mặt hàng";
            this.rbtTatCa.UseVisualStyleBackColor = false;
            // 
            // rbtGanHet
            // 
            this.rbtGanHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtGanHet.AutoSize = true;
            this.rbtGanHet.BackColor = System.Drawing.Color.CadetBlue;
            this.rbtGanHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtGanHet.ForeColor = System.Drawing.Color.White;
            this.rbtGanHet.Location = new System.Drawing.Point(543, 77);
            this.rbtGanHet.Name = "rbtGanHet";
            this.rbtGanHet.Size = new System.Drawing.Size(87, 21);
            this.rbtGanHet.TabIndex = 2;
            this.rbtGanHet.Text = "Gần hết";
            this.rbtGanHet.UseVisualStyleBackColor = false;
            // 
            // rbtDaHet
            // 
            this.rbtDaHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtDaHet.AutoSize = true;
            this.rbtDaHet.BackColor = System.Drawing.Color.CadetBlue;
            this.rbtDaHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtDaHet.ForeColor = System.Drawing.Color.White;
            this.rbtDaHet.Location = new System.Drawing.Point(650, 77);
            this.rbtDaHet.Name = "rbtDaHet";
            this.rbtDaHet.Size = new System.Drawing.Size(77, 21);
            this.rbtDaHet.TabIndex = 2;
            this.rbtDaHet.Text = "Đã hết";
            this.rbtDaHet.UseVisualStyleBackColor = false;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.CadetBlue;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(741, 70);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(164, 34);
            this.btnThongKe.TabIndex = 3;
            this.btnThongKe.Text = "Thống Kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(917, 533);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.rbtDaHet);
            this.Controls.Add(this.rbtGanHet);
            this.Controls.Add(this.rbtTatCa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTonKho);
            this.Name = "frmTonKho";
            this.Text = "TonKho";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtTatCa;
        private System.Windows.Forms.RadioButton rbtGanHet;
        private System.Windows.Forms.RadioButton rbtDaHet;
        private System.Windows.Forms.Button btnThongKe;
    }
}