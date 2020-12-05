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
    public partial class frmChiTietHoaDonNhap : Form
    {
        public frmChiTietHoaDonNhap(long idHoaDon, byte danhapkho)//tham số này được truyền qua để lấy mã hóa đơn nhập
        {
            this.idHoaDon = idHoaDon;//phép gán
            this.danhapkho = danhapkho;

            InitializeComponent();
        }
        private long idHoaDon;//khai báo 1 biến để lấy mã hóa đơn được truyền qua
        private byte danhapkho;

        private KARAOKE_DatabaseDataContext db;
        private void frmChiTietHoaDonNhap_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();



            //khi form này được load lên, chugns ta sẽ kiểm tra xem trạng thái của đơn hàng đã nhập kho hay chưa
            //nếu chưa nhập kho thì cho thêm, xóa mặt hàng vào
            //còn nếu đã nhập kho rồi thì sẽ không cho chỉnh sửa đơn hàng nữa. tức là vô hiệu hóa 2 button thêm và xóa
            var hd = db.HoaDonNhaps.SingleOrDefault(x => x.ID == idHoaDon);
            if (hd.DaNhap == 1)
            {
                btnThem.Enabled = btnXoa.Enabled = false;
            }

            //đổ dữ liệu cho combobox cbbMatHang
            //như thế này khó phân biệt được các mặt hàng cùng tên nhưng đơn vị tính khác nhau
            //ví dụ bia 333 có cùng tên nhưng 2 đơn vị tính là lon,thùng
            //vì vậy để dễ nhận biết, chúng ta sẽ kết hợp tên mặt hàng cùng với đơn vị tính
            //bằng cách join 2 bảng mặt hàng và đơn vị tính với nhau
            //chỉ lấy các mặt hàng cha, tức là có idcha = -1 hoặc null
            var rs = from h in db.MatHangs.Where(x => (x.idcha == null || x.idcha <= 0) && x.isDichVu == 0)//chỉ xuất các mặt hàng cha
                     join d in db.DonViTinhs on h.DVT equals d.ID
                     select new
                     {
                         tenmathang = h.TenMatHang + " - " + d.TenDVT,
                         mahang = h.ID
                     };
            cbbMatHang.DataSource = rs;
            cbbMatHang.DisplayMember = "tenmathang";
            cbbMatHang.ValueMember = "mahang";
            cbbMatHang.SelectedIndex = -1;//mặc định sẽ không chọn mặt hàng nào cả      

            ShowData();


            //không cần thiết hiển thị cột mã hàng nên chúng ta sẽ ẩn nó đi
            dgvMatHang.Columns["idmathang"].Visible = false;
            //tùy chỉnh lại hiển thị trên datagridview
            dgvMatHang.Columns["mathang"].HeaderText = "Tên mặt hàng";
            dgvMatHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvMatHang.Columns["sl"].HeaderText = "SL";
            dgvMatHang.Columns["dg"].HeaderText = "Đơn giá";
            dgvMatHang.Columns["thanhtien"].HeaderText = "Thành tiền";

            dgvMatHang.Columns["dvt"].Width = 100;
            dgvMatHang.Columns["sl"].Width = 100;
            dgvMatHang.Columns["thanhtien"].Width = 100;
            dgvMatHang.Columns["dg"].Width = 100;
            dgvMatHang.Columns["mathang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //định dạng phần nghìn
            dgvMatHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvMatHang.Columns["thanhtien"].DefaultCellStyle.Format = "N0";

            //căn cho đẹp
            dgvMatHang.Columns["sl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvMatHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMatHang.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }
        private void ShowData()
        {
            //như thiết kế csdl, bảng chi tiết hóa đơn nhập chỉ lưu mã mặt hàng, mà không lưu tên mặt hàng --> quan hệ 1-n
            //nhưng khi hiển thị, chúng ta cần hiển thị tên mặt hàng 1 cách tường minh
            //vì vậy, chúng ta cần join 2 bảng chi tiết hóa đơn nhập và mặt hàng
            //cách làm như sau
            var rs = (from c in db.ChiTietHoaDonNhaps.Where(x => x.IDHoaDon == idHoaDon)//chỉ lấy các chi tiết hóa đơn nhập tương ứng với mã hóa đơn được truyền qua
                      join h in db.MatHangs
                      on c.IDMatHang equals h.ID
                      join d in db.DonViTinhs on h.DVT equals d.ID

                      select new
                      {
                          //cần hiển thị các thông tin như: 
                          //
                          //- tên mặt hàng lấy từ bảng mathang
                          // -- đơn vị tính lấy từ bảng donvitinh
                          // -- số lượng nhập, đơn giá nhập, thành tiền lấy từ bảng chitiethoadonnhap
                          idmathang = h.ID,
                          idcha = h.idcha,
                          mathang = h.TenMatHang,
                          dvt = d.TenDVT,
                          sl = c.SoLuong,
                          dg = c.DonGiaNhap,
                          thanhtien = c.SoLuong * c.DonGiaNhap
                      }).Where(x => x.idcha <= 0 || x.idcha == null);//những mặt hàng có idcha < 0 hoặc null là những mặt hàng không có đơn vị nào lớn hơn nữa. Như thiết lập trong phần quy đổi của mặt hàng

            dgvMatHang.DataSource = rs;
            lblTongTien.Text = string.Format("Tổng tiền: {0:N0} VNĐ", rs.Sum(x => x.thanhtien));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbMatHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần nhập", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ct = new ChiTietHoaDonNhap();
            ct.IDHoaDon = idHoaDon;//idHoaDon được truyền qua khi form đc gọi

            //các giá trị mã mặt hàng, số lượng, đơn giá đều là số nguyên int
            //nên chúng ta cần parse từ string qua int

            //trước khi thêm, chúng ta sẽ kiểm tra ứng với hoadown có id là idHoaDon và mặt hàng đang được chọn
            //đã tồn tại trong csdl chưa
            var item = db.ChiTietHoaDonNhaps.FirstOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(cbbMatHang.SelectedValue.ToString()));

            //nếu chưa thì item sẽ là null
            //ngược lại item sẽ khác null

            if (item == null)//nếu chưa có trong đơn nhập hàng
            {
                ct.IDMatHang = int.Parse(cbbMatHang.SelectedValue.ToString());
                ct.DonGiaNhap = int.Parse(txtDonGiaNhap.Text);
                ct.SoLuong = int.Parse(txtSL.Text);
                db.ChiTietHoaDonNhaps.InsertOnSubmit(ct);
                db.SubmitChanges();
            }
            else//nếu đã có, thì cập nhật lại số lượng <->update
            {
                item.SoLuong += int.Parse(txtSL.Text);
                db.SubmitChanges();
            }

            ShowData();
            //đã thêm thành công
            //tuy nhiên, theo thiết kế csdl ta có khóa chính của bảng chitiethoadonnhap gồm 2 trường idhoadon và id mặt hàng
            //nếu 1 mặt hàng nhập 2 lần sẽ phát sinh lỗi trùng dữ liệu duplicate
            //phương án giải quyết: không cho nhập hơn 1 lần hoặc nếu nhập hơn 1 lần thì số lượng mới sẽ bằng = sl cũ + sl nhập
        }

        #region
        //trong quá trình nhập hàng, nhiều lúc chúng ta sẽ nhập nhầm mặt hàng so với thực tế
        //vì vậy, chúng ta cần code thêm chức năng xóa mặt hàng khi nhập phiếu với điều kiện là phiếu chưa đc xác nhận nhập kho
        //muốn xóa được 1 mặt hàng trong bảng chitiethoadonnhap, chúng ta cần xác định được khóa chính của nó
        //khóa chính của nó gồm 2 trường: id hóa đơn nhập và id mặt hàng
        //chức năng xóa chúng ta sẽ code hoàn toàn tương tự như các module trước
        #endregion
        private DataGridViewRow r;
        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex];
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa khỏi phiếu nhập", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (

                MessageBox.Show("Bạn có chắc muốn xóa mặt hàng: " + r.Cells["mathang"].Value.ToString() + " ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes
                )
            {

                var item = db.ChiTietHoaDonNhaps.FirstOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["idmathang"].Value.ToString()));
                db.ChiTietHoaDonNhaps.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show("Xóa mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
            }
        }

        private void rbtNhapKho_Click(object sender, EventArgs e)
        {
            if (rbtYeuCau.Checked)//nếu ở chế độ yêu cầu 
            {
                txtTienThanhToan.Enabled = false;//thì chưa thanh toán, enable = fale là không cho nhập tiền
                txtTienThanhToan.Text = "0";//mặc định trường hợp này số tiền thanh toán sẽ là 0
            }
            else
            {
                txtTienThanhToan.Enabled = true;//ngược lại khi thực nhập, tức là mua hàng thực tế thì cần nhập số tiền đã thanh toán cho nhà cung cấp
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            //trước khi xác nhận đơn hàng, chúng ta cần kiểm tra xem đã có mặt hàng nào được thêm vào hóa đơn này chưa
            //tức là đếm số hàng của datagridiew
            //nếu là chưa có mặt hàng nào thì sẽ không cho xác nhận. Vì khi này đơn hàng này đang trống
            if (dgvMatHang.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập mặt hàng vào hóa đơn nhập trước khi tiếp tục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //khi xác click btnXacNhan sẽ cần làm 2 thao tác
            //1: update số tiền thanh toán 
            //2: update trạng thái của phiếu là dạng yêu cầu hay là đã nhập thực tế

            //bước 1: xác định hóa đơn đang thao tác là hóa đơn nào dựa vào idhoadon được truyền qua form
            var hd = db.HoaDonNhaps.SingleOrDefault(x => x.ID == idHoaDon);
            hd.TienThanhToan = int.Parse(txtTienThanhToan.Text);
            hd.DaNhap = rbtYeuCau.Checked ? (byte)0 : (byte)1;
            db.SubmitChanges();
            this.Dispose();//đóng form
        }
    }
}
