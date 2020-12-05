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
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
        }
        private KARAOKE_DatabaseDataContext db;

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();

            //set 2 giá trị cho 2 maskedtextbox
            mtbTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy 00:01");//đầu ngày hiện tại
            mtbToiNgay.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");//giờ hiện tại


            btnThongKe.PerformClick();//gọi sự kiện click khi form được load

            dgvThongKe.Columns["NgayGD"].HeaderText = "Ngày GD";
            dgvThongKe.Columns["MatHang"].HeaderText = "Mặt Hàng";
            dgvThongKe.Columns["ThanhTien"].HeaderText = "Thành Tiền";

            dgvThongKe.Columns["MaHang"].Visible = false;

            dgvThongKe.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dgvThongKe.Columns["DG"].DefaultCellStyle.Format = "N0";

            dgvThongKe.Columns["ThanhTien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvThongKe.Columns["DVT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvThongKe.Columns["DG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvThongKe.Columns["SL"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvThongKe.Columns["MatHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            LoadData();//đỗ dưa liệu khi form được hiển thị cho cbb

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            DateTime tuNgay, toiNgay;
            string tuKhoa = null;
            try
            {
                tuNgay = DateTime.ParseExact(mtbTuNgay.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                toiNgay = DateTime.ParseExact(mtbToiNgay.Text, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                if (toiNgay <= tuNgay)
                {
                    MessageBox.Show("Thời gian không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Thời gian không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //nếu cả 3 thèn con đều k check thì k có dkien để lọc thống kê
            if (!ckbPhong.Checked && !ckbMatHang.Checked && !ckbDichVu.Checked)
            {
                MessageBox.Show("Vui lòng chọn điểu kiện thống kê", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //Khởi tạo cấp phát bộ nhớ 1 list
            List<LineHang> result = new List<LineHang>();


            //nếu cbb được chọn thì gán giá trị cho từ khóa
            if (cbbItems.SelectedIndex >= 0)
            {
                tuKhoa = cbbItems.SelectedValue.ToString();
            }
            
            if (ckbPhong.Checked)
            {
                result.AddRange(ThongKePhong(tuNgay, toiNgay, tuKhoa));
            }
            if (ckbDichVu.Checked)
            {
                result.AddRange(ThongKeDV(tuNgay, toiNgay, tuKhoa));
            }
            if (ckbMatHang.Checked)
            {
                result.AddRange(ThongKeHang(tuNgay, toiNgay, tuKhoa));
            }

            var total = result.Sum(x => x.ThanhTien);
            lblTongTien.Text = string.Format("Tổng tiền : {0:N0} VNĐ", total);
            lblThanhChu.Text = string.Format("Thành Chữ : {0}", new SoThanhChu().ChuyenSoSangChuoi(total));
            dgvThongKe.DataSource = result.OrderBy(x => x.NgayGD).ToList();
            tuKhoa = null;
        }
        private List<LineHang> ThongKePhong(DateTime tuNgay, DateTime toiNgay, string tuKhoa)
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay)//lấy các hóa đơn đã kết thúc
                         join p in db.Phongs on hd.IDPhong equals p.ID
                         select new LineHang
                         {
                             NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             MaHang = Convert.ToString(p.ID),
                             MatHang = p.TenPhong,
                             DVT = "Giờ",
                             DG = (int)hd.DonGiaPhong,
                             SL = new LinePhong(((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau).TotalHours).ToString(),
                             ThanhTien = new LinePhong().ThanhTien(((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau).TotalHours, (int)hd.DonGiaPhong)
                         };
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                return result.ToList().Where(x => x.MaHang == tuKhoa).ToList();
            }
            return result.ToList();
        }
        private List<LineHang> ThongKeDV(DateTime tuNgay, DateTime toiNgay, string tuKhoa)
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKThuc != null)
                         join ct in db.ChiTietHoaDonBans on hd.IDHoaDon equals ct.IDHoaDon
                         join h in db.MatHangs.Where(x => x.isDichVu == 1) on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinhs on h.DVT equals dv.ID
                         select new LineHang
                         {
                             NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             MaHang = Convert.ToString(h.ID),
                             MatHang = h.TenMatHang,
                             DVT = dv.TenDVT,
                             SL = ct.SL.ToString(),
                             DG = (int)ct.DonGia,
                             ThanhTien = (int)(ct.SL * ct.DonGia)
                         };
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                return result.ToList().Where(x => x.MaHang == tuKhoa).ToList();
            }
            return result.ToList();
        }
        private List<LineHang> ThongKeHang(DateTime tuNgay, DateTime toiNgay, string tuKhoa)
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKThuc != null && x.ThoiGianBDau >= tuNgay && x.ThoiGianBDau <= toiNgay)
                         join ct in db.ChiTietHoaDonBans on hd.IDHoaDon equals ct.IDHoaDon
                         join h in db.MatHangs.Where(x => x.isDichVu == 0) on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinhs on h.DVT equals dv.ID
                         select new LineHang
                         {
                             NgayGD = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             MaHang = Convert.ToString(h.ID),
                             MatHang = h.TenMatHang,
                             DVT = dv.TenDVT,
                             SL = Convert.ToString(ct.SL),
                             DG = (int)ct.DonGia,
                             ThanhTien = (int)(ct.SL * ct.DonGia)
                         };
            if (!string.IsNullOrEmpty(tuKhoa))
            {
                return result.ToList().Where(x => x.MaHang == tuKhoa).ToList();
            }
            return result.ToList();
        }

        private void LoadData()
        {
            List<LineHang> source = new List<LineHang>();
            if (ckbDichVu.Checked)
            {
                var result = from h in db.MatHangs.Where(x => x.isDichVu == 1)
                             join d in db.DonViTinhs on h.DVT equals d.ID
                             select new LineHang
                             {
                                 MaHang = h.ID.ToString(),
                                 MatHang = h.TenMatHang + "-[" + d.TenDVT + "]"
                             };
                source.AddRange(result);
            }
            if (ckbMatHang.Checked)
            {
                var result = from h in db.MatHangs.Where(x => x.isDichVu == 0)
                             join d in db.DonViTinhs on h.DVT equals d.ID
                             select new LineHang
                             {
                                 MaHang = h.ID.ToString(),
                                 MatHang = h.TenMatHang + "-[" + d.TenDVT + "]"
                             };
                source.AddRange(result);
            }
            if (ckbPhong.Checked)
            {
                var result = from p in db.Phongs
                             select new LineHang
                             {
                                 MaHang = p.ID.ToString(),
                                 MatHang = p.TenPhong
                             };
                source.AddRange(result);
            }
            cbbItems.DataSource = source;
            cbbItems.DisplayMember = "MatHang";
            cbbItems.ValueMember = "MaHang";
            cbbItems.SelectedIndex = -1;
        }

        private void ckbTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTatCa.Checked)
            {
                ckbDichVu.Checked = ckbMatHang.Checked = ckbPhong.Checked = true;
            }
            if (!ckbTatCa.Checked && ckbPhong.Checked && ckbMatHang.Checked && ckbDichVu.Checked)
            {
                ckbDichVu.Checked = ckbMatHang.Checked = ckbPhong.Checked = false;
            }
        }

        private void ckbBaThangCon_CheckedChanged(object sender, EventArgs e)
        {
            //nếu cả 3 thằng con cùng check thì check luôn thằng tất cả
            if (ckbPhong.Checked && ckbMatHang.Checked && ckbDichVu.Checked)
            {
                ckbTatCa.Checked = true;
            }
            if (!ckbPhong.Checked || !ckbMatHang.Checked || !ckbDichVu.Checked)
            {
                ckbTatCa.Checked = false;
            }
            LoadData();
        }
    }
}
