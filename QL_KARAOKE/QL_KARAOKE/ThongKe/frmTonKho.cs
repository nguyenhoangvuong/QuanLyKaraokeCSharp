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
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        private KARAOKE_DatabaseDataContext db;
        private void frmTonKho_Load(object sender, EventArgs e)
        {
            db = new KARAOKE_DatabaseDataContext();
            btnThongKe.PerformClick();//goi sự kiện click btnThongKe khi form được load
            dgvTonKho.Columns["mahang"].HeaderText = "Mã Hàng";
            dgvTonKho.Columns["tenhang"].HeaderText = "Mặt Hàng";
            dgvTonKho.Columns["dvt"].HeaderText = "ĐVT";
            dgvTonKho.Columns["tonkho"].HeaderText = "Tồn Kho";

            dgvTonKho.Columns["isDichVu"].Visible = false;
            dgvTonKho.Columns["dg"].Visible = false;

            dgvTonKho.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (rbtDaHet.Checked)
            {
                ThongKe(0);
                return;
            }
            if(rbtGanHet.Checked)
            {
                ThongKe(-1);
                return;
            }
            if(rbtTatCa.Checked)
            {
                ThongKe(1);
                return;
            }
        }
        private void ThongKe(int dieukien)
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
                          join h in db.MatHangs.Where(x => x.idcha == null || x.idcha <= 0) on ct.First().mahang equals h.ID
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
                          join h in db.MatHangs.Where(x => x.idcha == null || x.idcha <= 0 && x.isDichVu == 0)////tức là chỉ lấy tổng số lượng của các mặt hàng k là con của mặt hàng khác: idCha = null hoặc idCha <=0
                          on p.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = p.Sum(x => x.SL)
                          };
            //II.2 Tính số lượng mặt hàng cha bán ra được quy ra từ số lượng mặt hàng con bán
            //ví dụ: bán 24 lon bia 333 -> quy ra được là 1 thùng
            var xuatQuyRaCha = from ct in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                               join h in db.MatHangs.Where(x => x.idcha > 0)//chỉ lấy các mặt hàng con
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
                          join h in db.MatHangs on ct.mahang equals h.idcha //đây là inner join -> chỉ lấy các mặt hàng có idCha = mahang trong ds nhapCha
                          join d in db.DonViTinhs on h.DVT equals d.ID
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
                                  join h in db.MatHangs.Where(x => x.idcha > 0)//chỉ lấy các mặt hàng là con của mặt hàng khác
                                  on xc.mahang equals h.idcha//lưu ý điều kiện join nhé các bạn. h.idCha, k phải h.ID
                                  select new
                                  {
                                      mahang = h.ID,
                                      soluong = xc.soluong * h.Tile
                                  };

            //IV.2.b tính tổng mặt hàng con bán ra. tức là bán ra theo lon
            var xuatCon = from ct in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.idcha > 0 && x.isDichVu == 0)//chỉ lấy các mặt hàng là con của mặt hàng khác
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
            if(dieukien == 0)//lấy số lượng đã hết
            {
                var result = tonkhoHang.Where(x => x.tonkho == 0);
                dgvTonKho.DataSource = result;
                return;
            }

            if(dieukien == 1)//tất cả các mặt hàng
            {
                dgvTonKho.DataSource = tonkhoHang;
                return;
            }

            if(dieukien == -1)//các mặt hàng gần hết
            {
                var ganhet = int.Parse(db.CauHinhs.SingleOrDefault(x => x.tukhoa == "ganhet").giatri);
                var result = tonkhoHang.Where(x => x.tonkho < ganhet);
                dgvTonKho.DataSource = result;
                return;
            }
        }

    }
}
