using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class NhanVien : ConNguoi
    {
        string maNV;
        double luong;
        public NhanVien() { }
        public NhanVien(string ten, int tuoi, string maNV, double luong) : base(ten, tuoi)
        {
            this.MaNV = maNV;
            this.Luong = luong;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public double Luong { get => luong; set => luong = value; }

        public double  mucDongGop() {
            return 0.1 * Luong; //cho vay di
        }
    }
}
