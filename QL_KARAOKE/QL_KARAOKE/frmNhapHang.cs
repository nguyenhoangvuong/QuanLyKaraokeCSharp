using QL_KARAOKE.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_KARAOKE
{
    public partial class frmNhapHang : Form
    {
        public frmNhapHang(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }
        private KARAOKE_DatabaseDataContext db;
        private string nhanvien;
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();
            mtbNgayNhap.Text = DateTime.Now.ToString("dd/MM/yyyy");

            cbbNhanVienNhap.DataSource = db.NhanViens.Where(x=>x.isDelete ==0);
            cbbNhanVienNhap.DisplayMember = "hovaten";
            cbbNhanVienNhap.ValueMember = "username";
            cbbNhanVienNhap.SelectedIndex = -1;

            cbbNCC.DataSource = db.NhaCungCaps.Where(x=>x.isDelete==0);
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "ID";
            cbbNCC.SelectedIndex = -1;
            ShowData();
            dgvHoaDonNhap.Columns["danhap"].Visible = false;

            dgvHoaDonNhap.Columns["id"].HeaderText = "ID Phiếu";
            dgvHoaDonNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            dgvHoaDonNhap.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
            dgvHoaDonNhap.Columns["trangthai"].HeaderText = "Trạng thái";
            dgvHoaDonNhap.Columns["tongtien"].HeaderText = "Tổng tiền";
            dgvHoaDonNhap.Columns["dathanhtoan"].HeaderText = "Đã thanh toán";

            dgvHoaDonNhap.Columns["id"].Width = 100;
            dgvHoaDonNhap.Columns["NgayNhap"].Width = 100;
            dgvHoaDonNhap.Columns["trangthai"].Width = 100;
            dgvHoaDonNhap.Columns["tongtien"].Width = 100;
            dgvHoaDonNhap.Columns["dathanhtoan"].Width = 100;
            dgvHoaDonNhap.Columns["tenncc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvHoaDonNhap.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonNhap.Columns["trangthai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonNhap.Columns["tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDonNhap.Columns["dathanhtoan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvHoaDonNhap.Columns["tongtien"].DefaultCellStyle.Format = "N0";
            dgvHoaDonNhap.Columns["dathanhtoan"].DefaultCellStyle.Format = "N0";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime ngaynhap;
            try
            {
                ngaynhap = DateTime.ParseExact(mtbNgayNhap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch
            {
                MessageBox.Show("Ngày nhập không hợp lệ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            //nhân viên nhập hàng được hiểu là người phụ trách kiểm kê hàng hóa khi nhập vào kho
            if (cbbNhanVienNhap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên nhập hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbbNCC.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var od = new HoaDonNhap();
                od.NhanVienNhap = cbbNhanVienNhap.SelectedValue.ToString();
                od.IDNhaCC = int.Parse(cbbNCC.SelectedValue.ToString());
                od.NgayNhap = ngaynhap;

                od.NgayTao = DateTime.Now;
                od.NguoiTao = nhanvien;

                db.HoaDonNhaps.InsertOnSubmit(od);
                db.SubmitChanges();


                //MessageBox.Show("Tạo mới hóa đơn nhập thành công "+idHDNhap, "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //theo thiết kế csdl thì hóa đơn nhập và chi tiết hóa đơn nhập có mối quan hệ 1-n
                //trong đó, chi tiết hóa đơn nhập có khóa ngoại là idhoadon trỏ tới khóa chính id của bảng hóa đơn nhập
                //sau khi tạo xong hóa đơn, chúng ta cần nhập mặt hàng vào hóa đơn này đúng không
                //như mẫu hóa đơn mua hàng này, chúng ta phần phía trên chính là thông tin được lưu ở bảng hoadonnhap
                //còn phần phía dưới chính là phần chi tiết của hóa đơn nhập hàng, được lưu ở bảng chitiethoadonnhap
                //=>sau khi tạo xong hóa đơn nhập, cần cho người dùng nhập các mặt hàng tương ứng với hóa đơn vừa tạo
                //cần tạo thêm 1 form chi tiết hóa đơn nhập và truyền id của hóa đơn nhập qua để hệ thống hiểu rằng bạn đang nhập hàng cho hóa đơn nào
                var idHDNhap = db.HoaDonNhaps.Max(x => x.ID);
                //với hóa đơn nhập mới, trạng thái nhập kho sẽ là false = đang yêu cầu nhập hàng
                new frmChiTietHoaDonNhap(idHDNhap, 0).ShowDialog();//truyền mã hóa đơn qua
                ShowData();//gọi lại hàm hiển thị sau khi phiếu nhập đc thêm.xóa mặt hàng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Tạo hóa đơn nhập hàng thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowData()//hàm hiển thị danh sách các hóa đơn nhập hàng
        {
            //như chúng ta thấy, trong bảng hoadonnhap chỉ lưu username của nhân viên
            //và id của nhà cung cấp
            //nhưng khi hiển thị lên form, chúng ta cần lấy thông tin tường minh
            //họ và tên nhân viên nhập và thông tin tên nhà cung cấp
            //muốn làm được điều này, chúng ta cần join các bảng lại dựa vào khóa ngoại
            var rs = from o in db.HoaDonNhaps
                     join n in db.NhaCungCaps on o.IDNhaCC equals n.ID
                     join c in db.NhanViens on o.NhanVienNhap equals c.Username

                     select new
                     {
                         id = o.ID,
                         NgayNhap = o.NgayNhap,
                         TenNCC = n.TenNCC,
                         danhap = o.DaNhap,
                         trangthai = o.DaNhap == 1 ? "Đã nhập" : "Yêu cầu",
                         tongtien = db.ChiTietHoaDonNhaps.Where(x => x.IDHoaDon == o.ID).Sum(y => y.SoLuong * y.DonGiaNhap),//tổng tiền được tính dựa vào tổng các mặt hàng: sl*dg tương ứng với hóa đơn, 
                         //không bao gồm thành tiền của các mặt hàng quy đổi
                         dathanhtoan = o.TienThanhToan
                     };

            dgvHoaDonNhap.DataSource = rs;
        }

        #region
        //ý tưởng: khi double click vào 1 dòng trên datagridview dgvHoaDonNhap, chúng ta sẽ:
        //1: xem được thông tin chi tiết của phiếu nhập hàng
        //2: sửa,xóa các mặt hàng có trong phiếu nhập hàng này nếu trạng thái của phiếu nhập chưa xác thực vào kho
        //=> Muốn làm đc 2 yêu cầu trên, chúng ta cần có 2 thông tin: 1 id phiếu, 2 trạng thái của phiếu
        //chúng ta sẽ dùng form frmChiTietHoaDonNhap để vừa thêm mới mặt hàng vào đơn nhập
        //vừa dùng để chỉnh sửa hóa đơn nhập khi trạng thai DaNhap = false hoặc null
        #endregion

        private DataGridViewRow r;
        private void dgvHoaDonNhap_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvHoaDonNhap.Rows[e.RowIndex];

                //khi double click vào hàng của datagridview -> lấy được hóa đơn nhập tương ứng
                //từ đó truyền qua 2 giá trị: mã đơn nhập và trạng thái đơn nhập
                //vì r.Cells["id"].Value.ToString() trả về string. trong khi mã đơn nhập là bigint,long nên cần convert qua kiểu long
                //tương tự cho giá trị r.Cells["danhap"].Value.ToString() cần convert qua byte tức là 0 hoặc 1
                //mình sẽ khai báo ngoài cho dễ nhìn

                byte danhapkho = r.Cells["danhap"].Value == null ? (byte)0 : byte.Parse(r.Cells["danhap"].Value.ToString());
                //nguyên cái đoạn lệnh trên có nghĩa là
                //nếu cột danhap của hàng được chọn r là null thì cho giá trị là 0
                //ngược lại nếu khác null -> thì lấy giá trị 0 hoặc 1 rồi convert qua kiểu byte
                //hơi khó hiểu chút nhưng đây chỉ là phép tính 3 ngôi - dạng rút gọn của if..else

                new frmChiTietHoaDonNhap(long.Parse(r.Cells["id"].Value.ToString()), danhapkho).ShowDialog();//truyền  2 tham số vào frmChiTietHoaDonNhap rồi show lên
                ShowData();//gọi lại hàm hiển thị sau khi phiếu nhập đc thêm.xóa mặt hàng
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(r == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //if(MessageBox.Show("Bạn thực sự muốn xóa đơn vị tính " + r.Cells["IDPhieu"].Value.ToString() + "?",
            //    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    var ph = db.HoaDonNhaps.SingleOrDefault(x=>x.ID == idHDnhap)
            //}
        }
    }
}
