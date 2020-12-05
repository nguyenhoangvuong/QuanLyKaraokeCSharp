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
    public partial class frmNhaCungCap : Form
    {
        public frmNhaCungCap(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }

        private KARAOKE_DatabaseDataContext db;
        private string nhanvien;
        private void frmNhaCungCap_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();
            ShowData();
        }
        private void ShowData()
        {
            var rs = from n in db.NhaCungCaps.Where(x=>x.isDelete == 0)
                     select new
                     {
                         n.ID,
                         n.TenNCC,
                         n.DienThoai,
                         n.Email,
                         n.DiaChi
                     };
            dgvNhaCungCap.DataSource = rs.ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Vui lòng nhập Tên Nhà Cung Cấp", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNCC.Select();
                return;
            }
            //if (string.IsNullOrEmpty(txtDienThoai.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập Điện Thoại nhà cung cấp", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtDienThoai.Select();
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtDiaChi.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập Địa Chỉ nhà cung cấp", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtDiaChi.Select();
            //    return;
            //}
            //if (string.IsNullOrEmpty(txtEmail.Text))
            //{
            //    MessageBox.Show("Vui lòng nhập Email nhà cung cấp", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtEmail.Select();
            //    return;
            //}

            var n = new NhaCungCap();
            n.TenNCC = txtTenNCC.Text;
            n.DienThoai = txtDienThoai.Text;
            n.Email = txtEmail.Text;
            n.DiaChi = txtDiaChi.Text;
            n.isDelete = 0;

            n.NgayTao = DateTime.Now;
            n.NguoiTao = nhanvien;

            db.NhaCungCaps.InsertOnSubmit(n);
            db.SubmitChanges();
            ShowData();
            MessageBox.Show("Thêm mới thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenNCC.Text = null;
            txtTenNCC.Select();
        }

        private DataGridViewRow r;
        private void dgvNhaCungCap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                r = dgvNhaCungCap.Rows[e.RowIndex];
                txtTenNCC.Text = r.Cells["TenNCC"].Value.ToString();
                txtDienThoai.Text = r.Cells["DienThoai"].Value.ToString();
                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();
                txtEmail.Text = r.Cells["Email"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng chọn Nhà Cung Cấp cần cập nhật", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var n = db.NhaCungCaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
            n.TenNCC = txtTenNCC.Text;
            n.DienThoai = txtDienThoai.Text;
            n.DiaChi = txtDiaChi.Text;
            n.Email = txtEmail.Text;
            n.NgayCapNhat = DateTime.Now;
            n.NguoiCapNhat = nhanvien;

            db.SubmitChanges();
            ShowData();
            MessageBox.Show("Cập nhật thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenNCC.Text = null;
            r = null;
            txtTenNCC.Select();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn Nhà Cung Cấp cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có chắc muốn xóa " + r.Cells["TenNCC"].Value.ToString() + "?",
                "Xác nhận xóa",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes
                ) 
            {
                try
                {
                    var n = db.NhaCungCaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                    n.isDelete = 1;
                    db.SubmitChanges();
                    ShowData();
                    MessageBox.Show("Xóa thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại!", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenNCC.Text = null;
                r = null;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtDiaChi.Text = txtDienThoai.Text = txtEmail.Text = txtTenNCC.Text = null;
            r = null;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
