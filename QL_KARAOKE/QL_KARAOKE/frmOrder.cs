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
    public partial class frmOrder : Form
    {
        public frmOrder(long idHoaDon, string tenphong, DataGridViewRow r)
        {
            this.idHoaDon = idHoaDon;
            this.r = r;
            this.tenphong = tenphong;
            InitializeComponent();
        }
        private long idHoaDon;
        private DataGridViewRow r;
        private string tenphong;

        private KARAOKE_DatabaseDataContext db;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            this.lblTenMatHang.Text = "Mặt hàng yêu cầu: " + r.Cells["tenhang"].Value.ToString() + " - [" + r.Cells["dvt"].Value.ToString() + "]";
            this.lblPhong.Text = string.Format("Phòng phục vụ: {0}", tenphong);
            txtSL.Select();//set focus cho textbox txtSL ngay khi form đc load
            db = new KARAOKE_DatabaseDataContext();

        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ được nhập số tự nhiên
            {
                e.Handled = true;
            }
            if (e.KeyChar == (char)13)
            {
                btnSubmit.PerformClick();//gọi tới sự kiện click của button khi enter
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int sl = 0;
                try
                {
                    sl = int.Parse(txtSL.Text);
                    if (sl == 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSL.Select();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Số lượng không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSL.Select();
                    return;
                }

                //trước khi thêm, cần kiểm tra đã tồn tại chưa mặt hàng này trong hóa đơn được chọn hay chưa
                var item = db.ChiTietHoaDonBans.SingleOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["mahang"].Value.ToString()));
                if (item != null)//tức đã gọi trước đó rồi
                {
                    //nếu đã tồn tại, chỉ việc cập nhật lại sl yêu cầu
                    item.SL += sl;//cộng dồn
                    db.SubmitChanges();

                }
                else
                {
                    var ct = new ChiTietHoaDonBan();
                    ct.IDHoaDon = idHoaDon;//mã hóa đơn được truyền từ form frmBanHang qua
                    ct.IDMatHang = int.Parse(r.Cells["mahang"].Value.ToString());//ra là dòng dữ liệu được chọn từ datagridview dgvDanhSachMatHang trong form frmBanHang truyền qua 
                    ct.SL = sl;
                    //trong csdl, còn có cột dongia
                    //đơn giá được lấy từ cột giaban trong bảng mathang
                    //muốn lấy được ta cần tìm ra mặt hàng có mã id = int.Parse(r.Cells["mahang"].Value.ToString()); chính là mã hàng được truyền qua từ form frmBanHang
                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["mahang"].Value.ToString()));

                    ct.DonGia = mh.DonGiaBan;

                    db.ChiTietHoaDonBans.InsertOnSubmit(ct);
                    db.SubmitChanges();

                }
                MessageBox.Show("Thêm mặt hàng vào phòng: " + tenphong + " thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Dispose();//đóng form frmOrder sau khi gọi món thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Yêu cầu phục vụ thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
