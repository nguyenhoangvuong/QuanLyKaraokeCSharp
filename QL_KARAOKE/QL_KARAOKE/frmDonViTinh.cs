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
    public partial class frmDonViTinh : Form
    {
        public frmDonViTinh(string nv)
        {
            this.nhanvien = nv;
            InitializeComponent();
        }

        private KARAOKE_DatabaseDataContext db;
        private string nhanvien;
        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext(); //khoi tao doi tuong datacontext
            ShowData();
            dgvDVT.Columns["ID"].HeaderText = "Mã ĐVT";
            dgvDVT.Columns["ID"].Width = 100;
            dgvDVT.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//Căng giữa ô
            dgvDVT.Columns["TenDVT"].HeaderText = "Tên ĐVT";
            dgvDVT.Columns["TenDVT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//tự động co giãn full
        }
        private void ShowData()
        {
            var rs = (from d in db.DonViTinhs.Where(x=>x.isDelete == 0)
                      select new
                      {
                          d.ID,
                          d.TenDVT
                      }).ToList();
            dgvDVT.DataSource = rs; // dua du lieu len datagridview(xuất theo cột mk tùy thích)
            //dgvDVT.DataSource = db.DonViTinhs.ToList(); // dua du lieu len datagridview(xuat het tất cả các cột)
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDVT.Text))//neu txtDVT khong null
            {
                DonViTinh dvt = new DonViTinh();//khai báo 1 đối tượng thuộc class DonViTinh
                dvt.TenDVT = txtDVT.Text;//gán tên đvt          
                dvt.NguoiTao = nhanvien;//gán nhân viên tạo
                dvt.NgayTao = DateTime.Now;//gán ngày tạo
                dvt.isDelete = 0;
                db.DonViTinhs.InsertOnSubmit(dvt);//lưu vào csdl
                db.SubmitChanges();
                MessageBox.Show("Thêm mới đơn vị tính thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();//cập nhật lại data
                txtDVT.Text = null;//sau khi thêm thành công thì se resest lại thành rỗng
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            txtDVT.Select();
        }

        private DataGridViewRow r;
        private void dgvDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());//e.Rowindex lấy chỉ số của hàng
            //lấy giá trị khi click chuột
            r = dgvDVT.Rows[e.RowIndex];
            //MessageBox.Show(r.Cells["id"].Value.ToString());//lấy mã đơn vị tính

            txtDVT.Text = r.Cells["TenDVT"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần cập nhật", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng lệnh để không chạy lệnh dưới
            }
            if (!string.IsNullOrEmpty(txtDVT.Text))
            {
                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));// ep kieu
                //xác định được dvt cần được cập nhật
                dvt.TenDVT = txtDVT.Text;
                dvt.NgayCapNhat = DateTime.Now;
                dvt.NguoiCapNhat = nhanvien;
                db.SubmitChanges();//lưu vào csdl
                MessageBox.Show("Cập nhật đơn vị thành công !", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
                txtDVT.Text = null;
                r = null;//không hàng nào được chọn trên datagridview
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên đơn vị tính", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn thực sự muốn xóa đơn vị tính " + r.Cells["TenDVT"].Value.ToString() + "?",
                "Xác nhận xóa", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                dvt.isDelete = 1;
                db.SubmitChanges();
                MessageBox.Show("Xóa đơn vị tính thành công!", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
                r = null;
            }
        }
    }
}
