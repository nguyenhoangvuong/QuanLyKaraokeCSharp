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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private string nhanvien;
        private KARAOKE_DatabaseDataContext db;
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();
            ShowData();

            dgvNhanVien.Columns["Username"].Width = 100;
            dgvNhanVien.Columns["Password"].Visible = false;
            dgvNhanVien.Columns["HoVaTen"].Width = 180;
            dgvNhanVien.Columns["DienThoai"].Width = 120;
            dgvNhanVien.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvNhanVien.Columns["Username"].HeaderText = "Tài Khoản";
            dgvNhanVien.Columns["HoVaTen"].HeaderText = "Họ Và Tên";
            dgvNhanVien.Columns["DienThoai"].HeaderText = "Điện Thoại";
            dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa Chỉ";
        }

        private void ShowData()
        {
            dgvNhanVien.DataSource = from nv in db.NhanViens.Where(x=>x.isDelete == 0)
                                     select new
                                     {
                                         nv.Username,
                                         nv.Password,
                                         nv.HoVaTen,
                                         nv.DienThoai,
                                         nv.DiaChi
                                     };
        }

        private DataGridViewRow r;

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Tài Khoản", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật Khẩu", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên nhân viên", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Select();
                return;
            }

            //kiểm tra tên tài khoản có trùng k
            var c = db.NhanViens.Where(x => x.Username.Trim().ToLower() == txtTaiKhoan.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show("Tài Khoản này đã tồn tại", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }

            var nv = new NhanVien();
            nv.Username = txtTaiKhoan.Text.Trim().ToLower();
            nv.Password = txtMatKhau.Text;
            nv.HoVaTen = txtHoVaTen.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.NguoiTao = nhanvien;
            nv.NgayTao = DateTime.Now;
            nv.isDelete = 0;
            nv.isAdmin = 0;

            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            ShowData();
            MessageBox.Show("Thêm mới nhân viên thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDiaChi.Text = txtDienThoai.Text = txtHoVaTen.Text = txtTaiKhoan.Text = txtMatKhau.Text = null;

        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvNhanVien.Rows[e.RowIndex];
                txtTaiKhoan.Text = r.Cells["Username"].Value.ToString();
                txtMatKhau.Text = r.Cells["Password"].Value.ToString();
                txtHoVaTen.Text = r.Cells["HoVaTen"].Value.ToString();
                txtDienThoai.Text = r.Cells["DienThoai"].Value.ToString();
                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = txtDienThoai.Text = txtHoVaTen.Text = txtTaiKhoan.Text = txtMatKhau.Text = null;
            r = null;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Nhân Viên cần sửa", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtTaiKhoan.Text))
            {
                MessageBox.Show("Vui lòng nhập tên Tài Khoản", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập Mật Khẩu", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtHoVaTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ Tên nhân viên", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoVaTen.Select();
                return;
            }

            var nv = db.NhanViens.SingleOrDefault(x => x.Username == r.Cells["Username"].Value.ToString());
            nv.Username = txtTaiKhoan.Text.Trim().ToLower();
            nv.Password = txtMatKhau.Text;
            nv.HoVaTen = txtHoVaTen.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.NguoiCapNhat = nhanvien;
            nv.NgayCapNhat = DateTime.Now;
            nv.isDelete = 0;

            db.SubmitChanges();
            ShowData();
            MessageBox.Show("Cập nhật nhân viên thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDiaChi.Text = txtDienThoai.Text = txtHoVaTen.Text = txtTaiKhoan.Text = txtMatKhau.Text = null;
            r = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Nhân Viên cần xóa", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có muốn xóa nhân viên có tài khoản : " + r.Cells["Username"].Value.ToString() + "?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                try
                {
                    var nv = db.NhanViens.SingleOrDefault(x => x.Username == r.Cells["Username"].Value.ToString());
                    nv.isDelete = 1;
                    db.SubmitChanges();
                    MessageBox.Show("Xóa nhân viên thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa nhân viên thất bại", "Failđ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    ShowData();
                    txtDiaChi.Text = txtDienThoai.Text = txtHoVaTen.Text = txtTaiKhoan.Text = txtMatKhau.Text = null;
                    r = null;
                }
            }
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
