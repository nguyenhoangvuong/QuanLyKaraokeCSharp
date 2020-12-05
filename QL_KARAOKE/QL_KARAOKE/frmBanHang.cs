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
    public partial class frmBanHang : Form
    {
        public frmBanHang(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }

        private KARAOKE_DatabaseDataContext db;
        private ListView lv;
        private ImageList imgl;
        private string nhanvien;
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();
            var dsLoaiPhong = db.LoaiPhongs.Where(x=>x.isDelete==0);//lấy danh sách loại phòng
            foreach (var l in dsLoaiPhong)//duyệt danh sách loại phòng
            {
                TabPage tp = new TabPage(l.TenLoaiPhong);
                tp.Name = l.ID.ToString();
                tbcContent.Controls.Add(tp);
            }
            idLoaiPhong = db.LoaiPhongs.Min(x => x.ID);
            //mặc định sẽ load tabpage đầu tiên có tabindex là 0
            LoadPhong(idLoaiPhong, tabIndex);

            #region ds_mat_hang
            ShowMatHang();
            dgvDanhSachMatHang.Columns["mahang"].Visible = false;//ẩn cột mã hàng
            dgvDanhSachMatHang.Columns["isDichvu"].Visible = false;//ẩn luôn cột là dịch vụ hay mặt hàng
            dgvDanhSachMatHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvDanhSachMatHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvDanhSachMatHang.Columns["dg"].HeaderText = "Giá";
            dgvDanhSachMatHang.Columns["tonkho"].HeaderText = "Tồn";

            dgvDanhSachMatHang.Columns["dvt"].Width = 50;
            dgvDanhSachMatHang.Columns["dg"].Width = 70;
            dgvDanhSachMatHang.Columns["tonkho"].Width = 70;
            dgvDanhSachMatHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDanhSachMatHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhSachMatHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDanhSachMatHang.Columns["tonkho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDanhSachMatHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvDanhSachMatHang.Columns["tonkho"].DefaultCellStyle.Format = "N0";

            #endregion

            showLSGD();//gọi hàm lịch sử giao dịch khi form được load
            dgvLSGD.Columns["idHoaDon"].Visible = false;//ẩn cột
            dgvLSGD.Columns["phong"].HeaderText = "Phòng";
            dgvLSGD.Columns["tgBatDau"].HeaderText = "Bắt đầu";
            dgvLSGD.Columns["tgKetThuc"].HeaderText = "Kết thúc";
            dgvLSGD.Columns["soTien"].HeaderText = "Số tiền";
            dgvLSGD.Columns["sotien"].DefaultCellStyle.Format = "N0";
            dgvLSGD.Columns["sotien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLSGD.Columns["sotien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


        private void LoadPhong(int loaiphong, int tabIndex)
        {
            tbcContent.TabPages[tabIndex].Controls.Clear();
            lv = new ListView();//khai báo 1 listview
            lv.Dock = DockStyle.Fill; //set dockstyle là fill để listview lấp đầy tabpage            
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            imgl = new ImageList();//khai báo 1 imagelist
            imgl.ImageSize = new Size(256, 128);//set size cho image


            //add 2 ảnh đại diện cho 2 trạng thái phòng trống và phòng đang có khách
            imgl.Images.Add(Properties.Resources.freeroom);//index 0
            imgl.Images.Add(Properties.Resources.haveroom);//index 1

            //set imagelist cho listview được khai báo ở trên
            lv.LargeImageList = imgl;

            //lấy danh sách phòng theo loại phòng dựa vào idloaiphong

            var dsPhong = db.Phongs.Where(x => x.IDLoaiPhong == loaiphong && x.isDelete==0);
            //duyệt danh sách phòng tìm được
            foreach (var p in dsPhong)
            {
                //add item lên listview
                if (p.TrangThai == 1)//đang được sử dụng
                {
                    lv.Items.Add(new ListViewItem { ImageIndex = 1, Text = p.TenPhong, Name = p.ID.ToString(), Tag = true });//tag - true dùng để đánh dấu phòng đang có khách
                }
                else
                {
                    lv.Items.Add(new ListViewItem { ImageIndex = 0, Text = p.TenPhong, Name = p.ID.ToString(), Tag = false });//tag = false để đánh dấu phòng đang trống
                }
            }

            //add listview lên tabpage
            tbcContent.TabPages[tabIndex].Controls.Add(lv);

        }
        int idLoaiPhong = 0;
        private string tenphong;
        private long idHoaDon = 0;
        private int idPhong = 0;
        private int tabIndex = 0;
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lv.SelectedIndices;
            if (idx.Count > 0)
            {
                idPhong = int.Parse(lv.SelectedItems[0].Name);
                tenphong = lv.SelectedItems[0].Text.ToUpper();
                lblPhongDangChon.Text = tenphong;
                if ((bool)lv.SelectedItems[0].Tag)//nếu bàn đang có khách
                {
                    btnBatDau.Enabled = false;
                    btnKetThuc.Enabled = true;
                    //khi click vào item trên listview <-> click vào phòng đang có khách
                    //lấy thông tin hóa đơn bán hàng dựa vào id phòng
                    //lấy  hóa đơn có id lớn nhất có mã bàn đang được chọn
                    var hd = db.HoaDonBanHangs.FirstOrDefault(x => x.IDHoaDon == db.HoaDonBanHangs.Where(y => y.IDPhong == idPhong).Max(z => z.IDHoaDon));
                    idHoaDon = hd.IDHoaDon;
                    //khi phòng đang có khách -> thời gian bắt đầu được tính trong hóa đơn

                    mtbKetThuc.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");//giờ kết thúc bằng giờ hiện tại 
                    mtbBatDau.Text = ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm");

                    ShowChiTietHoaDon();
                }
                else
                {
                    //nếu phòng chưa có khách thì cho timer chạy để lấy giờ hiện tại làm giờ bắt đầu sử dụng phòng

                    dgvChiTietBanHang.DataSource = null;
                    mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");//giờ bắt đầu bằng giờ hiện tại 
                    btnBatDau.Enabled = true;
                    btnKetThuc.Enabled = false;

                }

            }

        }

        private void ShowMatHang()
        {
            #region ton_kho_cha
            // -------> I. TÍNH TỒN KHO MẶT HÀNG CHA NHẬP VÀO
            //VÍ DỤ: TÍNH TỔNG SỐ THÙNG BIA NHẬP VÀO. CÁI NÀY THÌ ĐƠN GIẢN. CHÚNG TA CODE NHƯ SAU
            //chúng ta cần lưu ý, chỉ lấy những chi tiết hóa đơn nhập từ những hóa đơn nhập có trạng thái danhap = 1, tức là đã nhập kho trên thực tế
            var details = from ct in db.ChiTietHoaDonNhaps
                          join hd in db.HoaDonNhaps.Where(x => x.DaNhap == 1)//chỉ lấy các hóa đơn có trạng thái đã nhập là 1
                          on ct.IDHoaDon equals hd.ID
                          select new
                          {
                              mahang = ct.IDMatHang,
                              sl = ct.SoLuong
                          };
            //bắt đầu tính tồn kho của thằng cha.
            //tức là chỉ lấy tổng số lượng của các mặt hàng k là con của mặt hàng khác: idCha = null hoặc idCha <=0
            //muốn tính tổng số lượng theo từng mặt hàng, chúng ta cần group by theo mã hàng <- kiến thức SQL nhé
            var nhapCha = from ct in details.GroupBy(x => x.mahang)
                          join h in db.MatHangs.Where(x => (x.idcha == null || x.idcha <= 0) && x.isDelete ==0) on ct.First().mahang equals h.ID
                          join d in db.DonViTinhs on h.DVT equals d.ID

                          select new
                          {
                              mahang = ct.First().mahang,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              soluong = ct.Sum(x => x.sl) //lấy tổng số lượng
                          };
            // -------> II. TÍNH SỐ MẶT HÀNG CHA BÁN RA: BÁN RA NGUYÊN THÙNG + SỐ LON(MẶT HÀNG CON) QUY RA SL CHA
            //II.1 Tính số lượng mặt hàng cha bán ra nguyên đơn vị. Tức là nhập vào thùng, bán ra cũng là thùng
            var xuatCha = from p in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.idcha == null || x.idcha <= 0 && x.isDichVu == 0 && x.isDelete ==0)////tức là chỉ lấy tổng số lượng của các mặt hàng k là con của mặt hàng khác: idCha = null hoặc idCha <=0
                          on p.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = p.Sum(x => x.SL)
                          };
            //II.2 Tính số lượng mặt hàng cha bán ra được quy ra từ số lượng mặt hàng con bán
            //ví dụ: bán 24 lon bia 333 -> quy ra được là 1 thùng
            var xuatQuyRaCha = from ct in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                               join h in db.MatHangs.Where(x => x.idcha > 0 && x.isDelete ==0)//chỉ lấy các mặt hàng con
                               on ct.First().IDMatHang equals h.ID
                               select new
                               {
                                   mahang = (int)h.idcha,
                                   soluong = ct.Sum(x => x.SL) % h.Tile == 0 ? ct.Sum(x => x.SL) / h.Tile : ct.Sum(x => x.SL) / h.Tile + 1
                               };


            //II.3 tính tổng toàn bộ mặt hàng cha đã bán ra dựa vào kết quả thu được từ II.1 và II.2
            var tongXuatCha = from xc in xuatCha.Union(xuatQuyRaCha).GroupBy(x => x.mahang)
                              select new
                              {
                                  mahang = xc.First().mahang,
                                  soluong = xc.Sum(x => x.soluong)
                              };
            // -------> III. TÍNH TỒN KHO CỦA MẶT HÀNG CHA TỪ I VÀ II
            //TỒN = NHẬP - XUẤT. ĐƠN GIẢN THÔI
            //cái này cần left join nhé. vì có thể nhập vào rồi mà chưa bán ra được
            var tonKhoCha = from p in nhapCha
                            join q in tongXuatCha on p.mahang equals q.mahang into tmp
                            from t in tmp.DefaultIfEmpty()
                            select new
                            {
                                mahang = p.mahang,
                                tenhang = p.tenhang,
                                isDichvu = 0,
                                dvt = p.dvt,
                                dg = p.dg,
                                tonkho = (int)(p.soluong - (t == null ? 0 : t.soluong)) //nhập - xuất
                            };


            #endregion

            #region ton_kho_con
            // -------> IV. TÍNH TỒN KHO CỦA MẶT HÀNG CON
            //IV.1 TÍNH TỔNG SỐ LƯỢNG NHẬP VÀO CỦA MẶT HÀNG CON
            //Tổng nhập của mặt hàng con thì đơn giản là lấy số lượng mặt hàng cha nhập vào x tỉ lệ quy đổi thôi
            //mà danh sách mặt hàng cha nhập vào chúng ta đã tính được ở I
            var nhapCon = from ct in nhapCha
                          join h in db.MatHangs.Where(x=>x.isDelete ==0)
                          on ct.mahang equals h.idcha //đây là inner join -> chỉ lấy các mặt hàng có idCha = mahang trong ds nhapCha
                          join d in db.DonViTinhs.Where(x=>x.isDelete==0)
                          on h.DVT equals d.ID
                          select new
                          {
                              mahang = h.ID,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              soluong = ct.soluong * h.Tile
                          };
            //IV.2 TÍNH TỔNG SỐ MẶT HÀNG CON BÁN RA
            //TỔNG MẶT HÀNG CON BÁN RA = TỔNG MẶT HÀNG CHA BÁN RA x TỈ LỆ QUY ĐỔI + SỐ MẶT HÀNG HÀNG CON BÁN RA
            //VÍ DỤ: Bia 333 bán ra 3 thùng chẵn và 15 lon lẻ
            //tổng số lon bán ra = 3x24 +15 = 72+15 = 87 lon
            //IV.2.a tính tổng con bán ra được quy ra từ cha bằng cách lấy xuatCha đã tính ở II rồi x tỉ lệ quy đổi thôi
            var xuatConQuyTuCha = from xc in xuatCha
                                  join h in db.MatHangs.Where(x => x.idcha > 0 && x.isDelete ==0 )//chỉ lấy các mặt hàng là con của mặt hàng khác
                                  on xc.mahang equals h.idcha//lưu ý điều kiện join nhé các bạn. h.idCha, k phải h.ID
                                  select new
                                  {
                                      mahang = h.ID,
                                      soluong = xc.soluong * h.Tile
                                  };

            //IV.2.b tính tổng mặt hàng con bán ra. tức là bán ra theo lon
            var xuatCon = from ct in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.idcha > 0 && x.isDichVu == 0 && x.isDelete ==0)//chỉ lấy các mặt hàng là con của mặt hàng khác
                          on ct.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = ct.Sum(x => x.SL)
                          };

            //IV.2.c tổng mặt hàng con bán ra bằng tổng kết qua từ IV.2.a và IV.2.b

            var tongConXuat = from ct in xuatConQuyTuCha.Union(xuatCon).GroupBy(x => x.mahang)
                              select new
                              {
                                  mahang = ct.First().mahang,
                                  slXuat = ct.Sum(x => x.soluong)
                              };

            //IV.3 tính tồn kho mặt hàng con =tổng con nhập vào - tổng con bán ra
            //đoạn này tương tự ở trên, chúng ta cũng dùng left join
            var tonKhoCon = from nc in nhapCon
                            join xc in tongConXuat on nc.mahang equals xc.mahang into tmp
                            from x in tmp.DefaultIfEmpty()
                            select new
                            {
                                mahang = nc.mahang,
                                tenhang = nc.tenhang,
                                isDichvu = 0,
                                dvt = nc.dvt,
                                dg = nc.dg,
                                tonkho = (int)(nc.soluong - (x == null ? 0 : x.slXuat))
                            };


            #endregion


            //V. danh sách tồn kho của mặt hàng cha và mặt hàng con
            var tonkhoHang = tonKhoCha.Concat(tonKhoCon).OrderBy(x => x.tenhang);//sắp xếp tăng dần theo tên mặt hàng
            var dichvu = from h in db.MatHangs.Where(x => x.isDichVu == 1 && x.isDelete == 0)//lấy các mặt hàng là dịch vụ
                         join d in db.DonViTinhs.Where(x=>x.isDelete ==0) 
                         on h.DVT equals d.ID
                         select new
                         {
                             mahang = h.ID,
                             tenhang = h.TenMatHang,
                             isDichvu = 1,
                             dvt = d.TenDVT,
                             dg = h.DonGiaBan,
                             tonkho = 0//kinh doanh dịch vụ nên k có tồn kho
                         };

            dgvDanhSachMatHang.DataSource = tonkhoHang.Concat(dichvu).OrderBy(x => x.tenhang).OrderBy(x => x.isDichvu);//sắp xếp tăng theo thứ tự mặt hàng trước, dịch vụ sau. rồi sắp xếp tăng dần theo tên mặt hàng & dịch vụ
        }



        private void dgvDanhSachMatHang_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (idPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng để tiếp tục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.RowIndex < 0)
            {
                return;
            }

            //chỉ hiển thị form frmOrder khi phòng đang ở trạng thái có khách
            var phong = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
            if (phong.TrangThai == 1)
            {
                var r = dgvDanhSachMatHang.Rows[e.RowIndex];
                new frmOrder(idHoaDon, tenphong, r).ShowDialog();
                ShowMatHang();//sau khi form frmOrder đóng lại gọi lại hàm hiển thị thông tin mặt hàng để cập nhật lại tồn kho
                ShowChiTietHoaDon();
            }




        }

        private void tbcContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            idLoaiPhong = int.Parse(tbcContent.SelectedTab.Name);//lấy id loại phòng đã được gán ở trên
            tabIndex = tbcContent.SelectedIndex;
            LoadPhong(idLoaiPhong, tabIndex);


        }

        private void ShowChiTietHoaDon()
        {
            //lấy chi tiết hóa đơn bán hàng liên quan tới hóa đơn được lấy ở trên
            //vì trong bảng chitiethoadonban chỉ lưu mã hàng
            //trong khi chúng ta cần lấy thông tin tường minh là tên mặt hàng
            //nên cần join 2 bảng chitiethoadoban và mathang dựa vào idmathang
            var rs = from ct in db.ChiTietHoaDonBans.Where(x => x.IDHoaDon == idHoaDon)
                     join h in db.MatHangs on ct.IDMatHang equals h.ID
                     join d in db.DonViTinhs on h.DVT equals d.ID
                     select new
                     {
                         mahang = h.ID,
                         tenhang = h.TenMatHang,
                         dvt = d.TenDVT,
                         sl = ct.SL,
                         dg = ct.DonGia,
                         thanhtien = ct.SL * ct.DonGia
                     };
            dgvChiTietBanHang.DataSource = rs;
            dgvChiTietBanHang.Columns["mahang"].Visible = false;
            dgvChiTietBanHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvChiTietBanHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvChiTietBanHang.Columns["sl"].HeaderText = "SL";
            dgvChiTietBanHang.Columns["dg"].HeaderText = "Đơn giá";
            dgvChiTietBanHang.Columns["thanhtien"].HeaderText = "Thành tiền";

            dgvChiTietBanHang.Columns["sl"].Width = 30;
            dgvChiTietBanHang.Columns["dvt"].Width = 70;
            dgvChiTietBanHang.Columns["dg"].Width = 70;
            dgvChiTietBanHang.Columns["thanhtien"].Width = 100;
            dgvChiTietBanHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvChiTietBanHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietBanHang.Columns["sl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietBanHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTietBanHang.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvChiTietBanHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvChiTietBanHang.Columns["thanhtien"].DefaultCellStyle.Format = "N0";
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            try
            {
                //tạo đơn hàng xong cần cập nhật lại trạng thái phòng
                var p = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
                //lấy ra loại phòng tương ứng với phòng được chọn
                var lp = db.LoaiPhongs.SingleOrDefault(x => x.ID == p.IDLoaiPhong);

                var od = new HoaDonBanHang();
                od.IDPhong = idPhong;
                od.NguoiBan = nhanvien;
                od.ThoiGianBDau = DateTime.ParseExact(mtbBatDau.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                od.NgayTao = DateTime.Now;
                od.NguoiTao = nhanvien;
                od.DonGiaPhong = lp.DonGia;

                db.HoaDonBanHangs.InsertOnSubmit(od);
                db.SubmitChanges();


                p.TrangThai = 1;
                db.SubmitChanges();

                LoadPhong(idLoaiPhong, tabIndex);
                btnBatDau.Enabled = false;
                btnKetThuc.Enabled = true;
                MessageBox.Show("Gọi phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Gọi phòng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            try
            {

                //cap nhat trang thai thoi gian ket thuc cho hoa don ban hang
                var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);
                hd.ThoiGianKThuc = DateTime.ParseExact(mtbKetThuc.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                db.SubmitChanges();

                //cap nhat trang thai lai cho phong tu co khach -> khoong co khach
                var p = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
                p.TrangThai = 0;
                db.SubmitChanges();

                //loa lai danh sach phong
                LoadPhong(idLoaiPhong, tabIndex);

                //reset lai cac component
                mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                btnBatDau.Enabled = true;
                btnKetThuc.Enabled = false;
                MessageBox.Show("Thanh toán phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showLSGD();

                idHoaDon = hd.IDHoaDon;
                InHoaDon();//gọi tới hàm in hóa đơn khi kết thúc sử dụng phòng
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thanh toán phòng thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void showLSGD()
        {
            var result = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGianKThuc != null)
                         join p in db.Phongs on hd.IDPhong equals p.ID
                         join ct in db.ChiTietHoaDonBans.GroupBy(t => t.IDHoaDon)
                         on hd.IDHoaDon equals ct.First().IDHoaDon
                         select new
                         {
                             idHoaDon = hd.IDHoaDon,
                             phong = p.TenPhong,
                             tgBatDau = DateTime.Parse(hd.ThoiGianBDau.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             tgKetThuc = DateTime.Parse(hd.ThoiGianKThuc.ToString()).ToString("dd/MM/yyyy HH:mm"),
                             soTien = ((TimeSpan)((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau)).TotalHours * hd.DonGiaPhong // tiền phòng
                                         + ct.Sum(x => x.SL * x.DonGia) //tổng tiền hàng
                         };
            dgvLSGD.DataSource = result;
        }



        private void dgvLSGD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idHoaDon = long.Parse(dgvLSGD.Rows[e.RowIndex].Cells["idHoaDon"].Value.ToString());
                InHoaDon();
            }
        }

        //hàm xử lý in hóa đơn
        private void InHoaDon()
        {
            pddHoaDon.Document = pdHoaDon;
            pddHoaDon.ShowDialog();
        }

        private void pdHoaDon_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //lấy thông tin từ bảng cấu hình
            var tencuahang = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "tencuahang").giatri;
            var diachi = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "diachi").giatri;
            var phone = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "phone").giatri;

            //lấy hóa đơn dựa vào idhoadon
            var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);

            //lấy bề rộng của giấy in
            var w = pdHoaDon.DefaultPageSettings.PaperSize.Width;
            #region header
            //vẽ header của bill
            //1. tên cửa hàng (quán karaoke)
            e.Graphics.DrawString(
                            tencuahang.ToUpper(),
                            new Font("Courier New", 12, FontStyle.Bold),
                            Brushes.Black, new Point(100, 20)
                            );

            //mã hóa đơn
            e.Graphics.DrawString(
                String.Format("HD{0}", hd.IDHoaDon),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(w / 2 + 200, 20)
                );

            //2. địa chỉ và số điện thoại
            e.Graphics.DrawString(
                string.Format("{0} - {1}", diachi, phone),
                new Font("Courier New", 8, FontStyle.Bold),
                Brushes.Black,
                new Point(100, 45)
                );

            //ngày giờ xuất hóa đơn
            e.Graphics.DrawString(
                String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(w / 2 + 200, 45)
                );



            //định dạng bút vẽ
            Pen blackPen = new Pen(Color.Black, 1);

            //tọa độ theo chiều dọc
            var y = 70;

            //định nghĩa 2 điểm để vẽ đường thẳng
            //cách lề trái 10, lề phải 10
            Point p1 = new Point(10, y);
            Point p2 = new Point(w - 10, y);
            //kẻ đường thẳng thứ nhất
            e.Graphics.DrawLine(blackPen, p1, p2);


            y += 10;
            e.Graphics.DrawString(
                String.Format("Giờ bắt đầu: {0}", ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm")),
                new Font("Courier New", 10, FontStyle.Bold),
                Brushes.Black, new Point(10, y)
                );
            e.Graphics.DrawString(
                String.Format("Giờ kết thúc: {0}", ((DateTime)hd.ThoiGianKThuc).ToString("dd/MM/yyyy HH:mm")),
                new Font("Courier New", 10, FontStyle.Bold),
                Brushes.Black,
                new Point(w / 2, y)
                );

            y += 20;
            //tổng tiền --- tổng thiệt hại = tiền phòng + tiền hàng/dịch vụ
            int sum = 0;
            //tính thời gian sử dụng phòng => ?h:?p
            var tgsd = ((DateTime)hd.ThoiGianKThuc - (DateTime)hd.ThoiGianBDau).TotalMinutes;

            var gio = (int)(tgsd / 60);
            var phut = tgsd % 60;

            //tiền sử dụng phòng
            var tienphong = (int)Math.Round((double)(tgsd / 60 * hd.DonGiaPhong) / 1000, 3) * 1000;
            sum += tienphong;

            //hiển thị thời gian sử dụng phòng
            e.Graphics.DrawString(String.Format("Thời gian sử dụng: {0}:{1}", gio, phut), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));

            //hiển thị tiền phòng
            e.Graphics.DrawString(String.Format("Thành tiền: {0:N0} VNĐ", tienphong), new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));

            //set lại tọa độ cho 2 điểm để vẽ đường thẳng thứ 2
            y += 20;
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);
            #endregion

            #region body
            y += 10;
            e.Graphics.DrawString("STT", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Mặt hàng/dịch vụ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("SL", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            ////lấy dữ liệu hóa đơn dựa vào idhoadon
            var result = from ct in db.ChiTietHoaDonBans.Where(x => x.IDHoaDon == idHoaDon)
                         join h in db.MatHangs on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinhs on h.DVT equals dv.ID
                         select new
                         {
                             TenMatHang = h.TenMatHang,
                             DVT = dv.TenDVT,
                             SL = (int)ct.SL,
                             DG = (int)ct.DonGia,
                             ThanhTien = ct.SL * ct.DonGia
                         };
            ////lặp các phần tử của mảng
            ////mỗi phần tử tương ứng 1 hàng trên bill
            int i = 1;
            y += 20;
            foreach (var l in result)
            {
                sum += l.SL * l.DG;
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(l.TenMatHang, new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.SL), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.DG), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 + 100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.ThanhTien), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));
                y += 20;
            }
            #endregion

            #region footer
            y += 40;
            //set lại tọa độ cho 2 điểm để vẽ đường thẳng thứ 3
            p1 = new Point(10, y);
            p2 = new Point(w - 10, y);
            e.Graphics.DrawLine(blackPen, p1, p2);

            //tổng tiền thanh toán
            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền: {0:N0} VNĐ", sum), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w - 200, y));

            //đọc số thành chữ
            y += 30;
            e.Graphics.DrawString(string.Format("Thành chữ: {0}", new SoThanhChu().ChuyenSoSangChuoi(sum)), new Font("Courier New", 8, FontStyle.Italic), Brushes.Black, new Point(10, y));

            y += 40;
            e.Graphics.DrawString("Xin chân thành cảm ơn sự ủng hộ của quý khách!", new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 150, y));
            y += 20;
            e.Graphics.DrawString("Hẹn Gặp Lại!", new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(w / 2 - 15, y));
            #endregion

        }
    }
}
