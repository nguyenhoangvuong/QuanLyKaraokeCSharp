using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_KARAOKE
{
    class LinePhong
    {
        public int Gio { get; set; }
        public int Phut { get; set; }
        public LinePhong()
        {

        }
        public LinePhong(double thoiGian)
        {
            var tg = LayGio(thoiGian);
            Gio = (int)tg;//ví dụ 7.513 --> 8
            Phut = (int)((tg - Math.Truncate(tg)) * 60);//0.5 * 60 được 30p
        }
        public double LayGio(double thoiGian)
        {
            //làm tròn sau dấu fay 1 chữ số
            return Math.Round(thoiGian, 1);
        }
        public override string ToString()
        {
            return string.Format("{0}:{1}", Gio, Phut);
        }

        public int ThanhTien(double thoiGian,int donGia)
        {
            return (int)(LayGio(thoiGian) * donGia);
        }
    }
}
