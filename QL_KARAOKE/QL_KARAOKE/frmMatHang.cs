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
    public partial class frmMatHang : Form
    {
        public frmMatHang(string nv)
        {
            this.nhanvien = nv;
            InitializeComponent();
        }

        private KARAOKE_DatabaseDataContext db;
        private string nhanvien;
        private DataGridViewRow r;
        private void frmMatHang_Load(object sender, EventArgs e)
        {

            db = new KARAOKE_DatabaseDataContext();//khởi tạo đối tượng db 

            cbbMatHangGoc.DataSource = db.MatHangs.Where(x => (x.idcha == null || x.idcha == -1) && x.isDichVu == 0 && x.isDelete ==0); //id cha bằng null hoặc -1 tức là không có mặt hàng nào là cha
            //ví dụ: thùng bia 333 sẽ có id cha là null vì đơn vị thùng là lớn nhất
            cbbMatHangGoc.DisplayMember = "TenMatHang";
            cbbMatHangGoc.ValueMember = "ID";
            cbbMatHangGoc.SelectedIndex = -1;

            ShowData();//hiển thị dữ liệu danh sách mặt hàng

            dgvMatHang.Columns["idcha"].Visible = false;
            dgvMatHang.Columns["tile"].Visible = false;

            //tinh chỉnh lại 1 số thuộc tính các cột của datagridview
            dgvMatHang.Columns["id"].Width = 100;//set bề rộng cố định cho mã mặt hàng
            dgvMatHang.Columns["tendvt"].Width = 100;//set bề rộng cố định cho đơn vị tính mặt hàng
            dgvMatHang.Columns["dongiaban"].Width = 100;//set bề rộng cố định cho đơn vị tính mặt hàng
            dgvMatHang.Columns["tenmathang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//tự động co giãn theo độ rộng của form

            //căn chỉnh vị trí
            dgvMatHang.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn giữa cho mã hàng
            dgvMatHang.Columns["tendvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter; //căn giữa cho đơn vị tính
            dgvMatHang.Columns["dongiaban"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; //căn phải cho đơn vị tính
            dgvMatHang.Columns["dongiaban"].DefaultCellStyle.Format = "N0";//phân cách phần nghìn

            //đặt lại tên cột
            dgvMatHang.Columns["id"].HeaderText = "Mã hàng";
            dgvMatHang.Columns["tendvt"].HeaderText = "ĐVT";
            dgvMatHang.Columns["dongiaban"].HeaderText = "Đơn giá";
            dgvMatHang.Columns["tenmathang"].HeaderText = "Tên mặt hàng";


            //đổ dữ liệu cho combobox cbbDVT
            cbbDVT.DataSource = db.DonViTinhs.Where(x=>x.isDelete==0);
            cbbDVT.DisplayMember = "TenDVT";//thuộc tính hiển thị
            cbbDVT.ValueMember = "ID";//thuộc tính giá trị ngầm chính là mã của đơn vị tính

            cbbDVT.SelectedIndex = -1;//không chọn đơn vị tính nào hết
        }

        private void ShowData()
        {
            var rs = from h in db.MatHangs.Where(x=>x.isDelete == 0)
                     join d in db.DonViTinhs.Where(x=>x.isDelete ==0) on h.DVT equals d.ID
                     select new
                     {
                         h.ID,
                         h.idcha,
                         h.Tile,
                         h.TenMatHang,
                         d.TenDVT,
                         h.DonGiaBan
                     };
            dgvMatHang.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMatHang.Text))//kiểm tra tính hợp lệ của tên mặt hàng không được để trống
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMatHang.Select();//set focus con trỏ chuột tại textbox này
                return;//dừng ngang đây, không thực hiện các câu lệnh phía dưới
            }
            if (cbbDVT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng ngang đây, không thực hiện các câu lệnh phía dưới
            }
            if (string.IsNullOrEmpty(txtDonGiaBan.Text))//kiểm tra tính hợp lệ của tên mặt hàng không được để trống
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Select();//set focus tại textbox này
                return;//dừng ngang đây, không thực hiện các câu lệnh phía dưới
            }

            int idCha = -1;
            int tile = 0;
            if (cbbMatHangGoc.SelectedIndex >= 0)//nếu chọn 1 mặt hàng làm cha thì có nghĩa phải tồn tại tỉ lệ quy đổi
            {
                idCha = int.Parse(cbbMatHangGoc.SelectedValue.ToString());
                //
                try
                {
                    tile = int.Parse(txtTiLe.Text);
                    if (tile <= 0)
                    {
                        MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTiLe.Select();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Tỉ lệ quy đổi không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiLe.Select();
                    return;
                }
            }
            var mh = new MatHang();//khởi tạo 1 đối tượng mới thuộc lớp MatHang
            mh.TenMatHang = txtTenMatHang.Text;
            mh.DVT = int.Parse(cbbDVT.SelectedValue.ToString());//vì giá trị nhận được từ combobox là string
            //trong khi iddvt trong csdl là kiểu int => convert string qua int
            mh.DonGiaBan = int.Parse(txtDonGiaBan.Text);//tương tự giá trị từ txtDonGiaBan nhận được là string -> convert qua int
            mh.idcha = idCha;
            mh.Tile = tile;
            mh.NgayTao = DateTime.Now;
            mh.NguoiTao = nhanvien;
            mh.isDelete = 0;
            mh.isDichVu = rbtDichVu.Checked ? (byte)1 : (byte)0;

            db.MatHangs.InsertOnSubmit(mh);//thêm mặt hàng mới vào csdl
            db.SubmitChanges();//lưu 

            ShowData();//sau khi thêm mới xong cập nhật lại danh sách hiển thị mặt hàng
            MessageBox.Show("Thêm mới mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //reset lại giá trị cho các component
            txtTenMatHang.Text = null;
            txtDonGiaBan.Text = "0";
            cbbDVT.SelectedIndex = -1;//không chọn đơn vị tính nào hết

            txtTenMatHang.Select();

        }

        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ cho phép nhập số tự nhiên vào textbox txtDonGiaBan
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần cập nhật", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //muốn cập nhật mặt hàng, ta cần phải xác định được mặt hàng nào cần được cập nhật
            //dựa vào sự kiện click trên datagridview dgvMatHang để lấy ra được hàng nào được click
            //dựa vào việc xác định hàng nào được click ta lấy đc các thông tin mặt hàng như mã, tên, dvt,đơn giá bán

            //tìm ra mặt hàng trong csdl cần được cập nhật dựa vào khóa chính là id của mặt hàng
            var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
            //vì mỗi mặt hàng chỉ tồn tại duy nhất 1 mã - khóa chính nên ta dùng hàm SingleOrDefault
            //r.Cells["id"].Value.ToString() trả về kiểu string trong khi id của mặt hàng là int
            //nên ta cần convert qua int


            //ràng buộc dữ liệu
            if (string.IsNullOrEmpty(txtTenMatHang.Text))//kiểm tra tính hợp lệ của tên mặt hàng không được để trống
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMatHang.Select();//set focus con trỏ chuột tại textbox này
                return;//dừng ngang đây, không thực hiện các câu lệnh phía dưới
            }
            if (cbbDVT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng ngang đây, không thực hiện các câu lệnh phía dưới
            }
            if (string.IsNullOrEmpty(txtDonGiaBan.Text))//kiểm tra tính hợp lệ của tên mặt hàng không được để trống
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Select();//set focus tại textbox này
                return;//dừng ngang đây, không thực hiện các câu lệnh phía dưới
            }

            int idCha = -1;
            int tile = 0;
            if (cbbMatHangGoc.SelectedIndex >= 0)//nếu chọn 1 mặt hàng làm cha thì có nghĩa phải tồn tại tỉ lệ quy đổi
            {
                idCha = int.Parse(cbbMatHangGoc.SelectedValue.ToString());
                //
                try
                {
                    tile = int.Parse(txtTiLe.Text);
                    if (tile <= 0)
                    {
                        MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTiLe.Select();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Tỉ lệ quy đổi không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiLe.Select();
                    return;
                }
            }

            //cập nhật lại các giá trị cho mặt hàng vừa được tìm thấy ở trên
            mh.TenMatHang = txtTenMatHang.Text;
            mh.DVT = int.Parse(cbbDVT.SelectedValue.ToString());
            mh.DonGiaBan = int.Parse(txtDonGiaBan.Text);
            mh.idcha = idCha;
            mh.Tile = tile;
            mh.isDichVu = rbtDichVu.Checked ? (byte)1 : (byte)0;
            mh.NgayCapNhat = DateTime.Now;
            mh.NguoiCapNhat = nhanvien;
            
            db.SubmitChanges();

            ShowData();//sau khi thêm mới xong cập nhật lại danh sách hiển thị mặt hàng
            MessageBox.Show("Cập nhật mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //reset lại giá trị cho các component
            txtTenMatHang.Text = null;
            txtDonGiaBan.Text = "0";
            cbbDVT.SelectedIndex = -1;//không chọn đơn vị tính nào hết

        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex];//xác định được 1 hàng vừa được click

                //set các giá trị cho các component
                txtTenMatHang.Text = r.Cells["tenmathang"].Value.ToString();
                txtDonGiaBan.Text = r.Cells["dongiaban"].Value.ToString();
                cbbDVT.Text = r.Cells["tendvt"].Value.ToString();
                txtTiLe.Text = r.Cells["tile"].Value == null ? "0" : r.Cells["tile"].Value.ToString();
                if (r.Cells["idcha"].Value == null || r.Cells["idcha"].Value.ToString() == "-1")
                {
                    cbbMatHangGoc.SelectedIndex = -1;
                }
                else
                {
                    var item = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["idcha"].Value.ToString()));
                    cbbMatHangGoc.Text = item.TenMatHang;
                }

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //tương tự cập nhật mặt hàng
            //việc xóa mặt hàng cũng phải dựa vào hàng được click trên datagridview
            //ta có thể sử dụng lại biến r như ở phần cập nhật ở trên
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng ngang đây, không thực hiện các câu lệnh phía dưới
            }

            if (
                MessageBox.Show(
                        "Bạn có muốn xóa mặt hàng: " + r.Cells["tenmathang"].Value.ToString() + "?",
                        "Xác nhận xóa mặt hàng",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    ) == DialogResult.Yes
                )
            {
                try
                {
                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["id"].Value.ToString()));
                    mh.isDelete = 1;
                    db.SubmitChanges();
                    MessageBox.Show("Xóa mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Xóa mặt hàng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

                ShowData();//sau khi xóa xong cập nhật lại danh sách hiển thị mặt hàng

                //reset lại giá trị cho các component
                txtTenMatHang.Text = null;
                txtDonGiaBan.Text = "0";
                cbbDVT.SelectedIndex = -1;//không chọn đơn vị tính nào hết
            }
        }

        private void txtTiLe_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ cho phép nhập số tự nhiên vào textbox txtDonGiaBan
            {
                e.Handled = true;
            }
        }

        private void rbtMatHang_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMatHang.Checked)
            {
                cbbMatHangGoc.Enabled = true;
                txtTiLe.Enabled = true;
            }
            else
            {
                cbbMatHangGoc.Enabled = false;
                cbbMatHangGoc.SelectedIndex = -1;
                txtTiLe.Text = "0";
                txtTiLe.Enabled = false;
            }
        }
    }
}
