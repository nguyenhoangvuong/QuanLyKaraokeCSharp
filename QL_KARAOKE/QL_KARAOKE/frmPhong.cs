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
    public partial class frmPhong : Form
    {
        public frmPhong(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }


        private KARAOKE_DatabaseDataContext db;
        private string nhanvien;
        private void frmPhong_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();
            ShowData();

            //đỗ dữ liệu cho cbb
            cbbLoaiPhong.DataSource = db.LoaiPhongs.Where(x=>x.isDelete==0);
            cbbLoaiPhong.DisplayMember = "TenLoaiPhong";
            cbbLoaiPhong.ValueMember = "ID";
            cbbLoaiPhong.SelectedIndex = -1;

            //căn chỉnh gridview
            dgvPhong.Columns["ID"].Width = 100;
            dgvPhong.Columns["TenLoaiPhong"].Width = 200;
            dgvPhong.Columns["TenPhong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvPhong.Columns["DonGia"].Width = 100;
            dgvPhong.Columns["SucChua"].Width = 80;

            dgvPhong.Columns["SucChua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvPhong.Columns["ID"].HeaderText = "Mã Phòng";
            dgvPhong.Columns["TenLoaiPhong"].HeaderText = "Loại Phòng";
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên Phòng";
            dgvPhong.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvPhong.Columns["SucChua"].HeaderText = "Sức Chứa";

            dgvPhong.Columns["DonGia"].DefaultCellStyle.Format = "N0";
        }
        private void ShowData()
        {
            var rs = from p in db.Phongs.Where(x=>x.isDelete == 0)//chỉ lấy các phòng chưa bị xóa
                     join l in db.LoaiPhongs.Where(x=>x.isDelete == 0) on p.IDLoaiPhong equals l.ID
                     select new
                     {
                         p.ID,
                         l.TenLoaiPhong,
                         p.TenPhong,
                         l.DonGia,
                         p.SucChua
                     };
            dgvPhong.DataSource = rs.ToList();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng","Ràng buộc dữ liệu",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }

            if(cbbLoaiPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtSucChua.Text) || int.Parse(txtSucChua.Text)<=0)
            {
                MessageBox.Show("Sứa chứa của phòng phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }

            var p = new Phong();
            p.TenPhong = txtTenPhong.Text;
            p.IDLoaiPhong = int.Parse(cbbLoaiPhong.SelectedValue.ToString());
            p.SucChua = int.Parse(txtSucChua.Text);
            p.isDelete = 0;

            p.NgayTao = DateTime.Now;
            p.NguoiCapNhat = nhanvien;

            db.Phongs.InsertOnSubmit(p);
            db.SubmitChanges();
            MessageBox.Show("Thêm phòng mới thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //reset ô text
            txtTenPhong.Text = null;
            txtSucChua.Text = null;
            cbbLoaiPhong.SelectedIndex = -1;

            txtTenPhong.Select();
        }

        private void txtSucChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private DataGridViewRow r;
        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                r = dgvPhong.Rows[e.RowIndex];
                txtTenPhong.Text = r.Cells["TenPhong"].Value.ToString();
                txtSucChua.Text = r.Cells["SucChua"].Value.ToString();
                cbbLoaiPhong.Text = r.Cells["TenLoaiPhong"].Value.ToString();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần sửa", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(cbbLoaiPhong.SelectedIndex< 0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(string.IsNullOrEmpty(txtSucChua.Text) || int.Parse(txtSucChua.Text) <= 0){
                MessageBox.Show("Vui lòng nhập sức chứa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var p = db.Phongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));

            p.TenPhong = txtTenPhong.Text;
            p.SucChua = int.Parse(txtSucChua.Text);
            p.IDLoaiPhong = int.Parse(cbbLoaiPhong.SelectedValue.ToString());
            p.NgayCapNhat = DateTime.Now;
            p.NguoiCapNhat = nhanvien;

            db.SubmitChanges();
            ShowData();
            MessageBox.Show("Cập nhật thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtTenPhong.Text = null;
            txtSucChua.Text = null;
            cbbLoaiPhong.SelectedIndex = -1;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng chọn phòng để xóa", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            if (MessageBox.Show("Bạn có muốn xóa phòng "+ r.Cells["TenPhong"].Value.ToString()+"?",
                "Xác nhận xóa",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes
                )
            {
                try
                {
                    var p = db.Phongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                    p.isDelete = 1; // =1 đã được xóa
                    db.SubmitChanges();
                    ShowData();
                    MessageBox.Show("Xóa thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    txtTenPhong.Text = null;
                    txtSucChua.Text = null;
                    cbbLoaiPhong.SelectedIndex = -1;
                    r = null;
                }
                catch
                {
                    MessageBox.Show("Xóa thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
