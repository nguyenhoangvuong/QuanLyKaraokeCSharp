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
    public partial class frmCongNo : Form
    {
        public frmCongNo()
        {
            InitializeComponent();
        }

        private KARAOKE_DatabaseDataContext db;
        private void frmCongNo_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();

            cbbNhaCungCap.DataSource = db.NhaCungCaps;
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "ID";
            cbbNhaCungCap.SelectedIndex = -1;

            btnThongKe.PerformClick();

            dgvThongKe.Columns["NhaCC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvThongKe.Columns["NgayGD"].HeaderText = "Ngày GD";
            dgvThongKe.Columns["NhaCC"].HeaderText = "Nhà Cung Cấp";
            dgvThongKe.Columns["TongTien"].HeaderText = "Tổng Tiền";
            dgvThongKe.Columns["DaThanhToan"].HeaderText = "Đã Thanh Toán";
            dgvThongKe.Columns["conLai"].HeaderText = "Số Tiền Nợ";

            dgvThongKe.Columns["DaThanhToan"].Width = 120;
            dgvThongKe.Columns["TongTien"].Width = 120;
            dgvThongKe.Columns["conLai"].Width = 120;

            dgvThongKe.Columns["TongTien"].DefaultCellStyle.Format = "N0";
            dgvThongKe.Columns["DaThanhToan"].DefaultCellStyle.Format = "N0";
            dgvThongKe.Columns["conLai"].DefaultCellStyle.Format = "N0";
            dgvThongKe.Columns["IDNCC"].Visible = false;

            dgvThongKe.Columns["conLai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns["TongTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns["DaThanhToan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            var result = from hd in db.HoaDonNhaps.Where
                            (x => x.DaNhap == 1 && x.TienThanhToan < (db.ChiTietHoaDonNhaps.Where(t => t.IDHoaDon == x.ID).Sum(t => t.DonGiaNhap)))
                         join ncc in db.NhaCungCaps on hd.IDNhaCC equals ncc.ID
                         join ct in db.ChiTietHoaDonNhaps.GroupBy(x=>x.IDHoaDon) on hd.ID equals ct.First().IDHoaDon
                         select new
                         {
                             NgayGD = DateTime.Parse(hd.NgayNhap.ToString()).ToString("dd/MM/yyyy"),
                             IDNCC = ncc.ID,
                             NhaCC = ncc.TenNCC,
                             TongTien = ct.Sum(x=>x.SoLuong * x.DonGiaNhap),
                             DaThanhToan = hd.TienThanhToan,
                             conLai = ct.Sum(x => x.SoLuong * x.DonGiaNhap) - hd.TienThanhToan
                         };
            if(cbbNhaCungCap.SelectedIndex >= 0)
            {
                result = result.Where(x => x.IDNCC == int.Parse(cbbNhaCungCap.SelectedValue.ToString()));
            }
            dgvThongKe.DataSource = result;

            var total = 0;
            if(result.Count() > 0)
            {
                total = (int)result.Sum(x => x.conLai);
            }
            lblTongTien.Text = string.Format("Tổng tiền : {0:N0} VNĐ", total);
            lblThanhChu.Text = string.Format("Thành Chữ : {0}", new SoThanhChu().ChuyenSoSangChuoi(total));
        }
    }
}
