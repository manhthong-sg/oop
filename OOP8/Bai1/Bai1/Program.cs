using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class Program
    {
        static void Main(string[] args)
        {
            CongTy ManhThong_Group = new CongTy("Manh Thong Group", 1000000, 800000000, 1000000, 100000000);
            NhanVien TuHa = new NhanVien("Tu Ha", 20, "0001", 10000000);
            NhanVien HuuLoc = new NhanVien("Huu Loc", 20, "0002", 6000000);
            NhanVien ThienThanh = new NhanVien("Thien Thanh", 20, "0003", 12000000);
            NhanVien TienHuy = new NhanVien("Tien Huy", 20, "0004", 9500000);
            NhanVien Long = new NhanVien("Long", 20, "0002", 6000000);

            ManhThong_Group.TuyenDung(TuHa);
            ManhThong_Group.TuyenDung(HuuLoc);
            ManhThong_Group.TuyenDung(ThienThanh);
            ManhThong_Group.TuyenDung(TienHuy);

            ManhThong_Group.SaThai();
            ManhThong_Group.VonDieuLe();
            Console.ReadKey();
        }
    }
}
