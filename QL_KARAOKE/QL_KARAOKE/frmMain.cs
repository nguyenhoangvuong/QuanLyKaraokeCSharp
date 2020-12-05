using QL_KARAOKE.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KARAOKE
{
    public partial class frmMain : Form
    {
        //để kéo panel đi tùy ý
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public frmMain()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private Boolean isMaximize = false;
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (!isMaximize)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
            isMaximize = !isMaximize;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }


        private KARAOKE_DatabaseDataContext db;
        private NhanVien nv;
        private void frmMain_Load(object sender, EventArgs e)
        {
            var f = new frmDangNhap();
            f.ShowDialog();
            nv = f.nv;
            if (nv != null)
            {
                lblNhanVien.Text = String.Format("Nhân Viên : {0}", nv.HoVaTen);

                db = new KARAOKE_DatabaseDataContext();
                var tencuahang = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "tencuahang").giatri;
                var diachi = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "diachi").giatri;
                var phone = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "phone").giatri;
                lblTitle.Text = String.Format("{0} - {1} - {2}", tencuahang, diachi, phone);

                if(nv.isAdmin == 0)//nếu k là admin
                {
                    nhanvienToolStripMenuItem.Visible = false;
                    PhongToolStripMenuItem.Visible = false;
                    nhapHangToolStripMenuItem.Visible = false;
                }
            }
            else
            {
                Application.Exit();
            }

        }


        #region menu item
        private void loaiPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmLoaiPhong(nv.Username);
            addForm(f);
        }

        //add form vào grb
        private void addForm(Form f)
        {
            f.FormBorderStyle = FormBorderStyle.None;//bỏ viền form
            f.Dock = DockStyle.Fill;//tự động co dãn
            f.TopLevel = false;
            f.TopMost = true;
            grbContent.Controls.Clear();//xóa các item đang có trên grb
            grbContent.Controls.Add(f);
            f.Show();
        }

        private void PhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmPhong(nv.Username);
            addForm(f);
        }

        private void matHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmMatHang(nv.Username);
            addForm(f);
        }

        private void dvtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDonViTinh(nv.Username);
            addForm(f);
        }

        private void nccToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhaCungCap(nv.Username);
            addForm(f);
        }

        private void nhanvienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhanVien(nv.Username);
            addForm(f);
        }

        private void nhapHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhapHang(nv.Username);
            addForm(f);
        }

        private void banHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmBanHang(nv.Username);
            addForm(f);
        }

        //khi click lên panel top thì gọi sự kiện  click của pictureBox3_Click maximize
        private void pnlTop_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            pictureBox3_Click(null, null);
        }

        private void tonKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmTonKho();
            addForm(f);
        }

        private void congNoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmCongNo();
            addForm(f);
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDoanhThu();
            addForm(f);
        }
        #endregion

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void doiMatKhauToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDoiMatKhau(nv).ShowDialog();
        }

        private int i = 4;
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTitle.Left += i;
            if(lblTitle.Left >= 385 || lblTitle.Left <= 10)
            {
                i = -i;
            }
        }
    }
}
