using QL_KARAOKE.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KARAOKE
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public NhanVien nv;
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }

            KARAOKE_DatabaseDataContext db = new KARAOKE_DatabaseDataContext();

            var tk = db.NhanViens.SingleOrDefault(x => x.Username == txtTaiKhoan.Text && x.Password == txtMatKhau.Text && x.isDelete ==0);
            if(tk != null)
            {
                //nếu tìm thấy thì gán nhân viên bằng tài  khoản đó
                nv = tk;
                this.Dispose();
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }
        }
    }
}
