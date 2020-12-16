using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
     class CongTy
    {
        string tenCTy;
        double mucDongGopChuan;
        double nganSach_ht;
        double nguonThu_thang;
        double nguonChi_thang;
        public static List<NhanVien> lstNV= new List<NhanVien>();
       
        public CongTy()
        {
        }

        public CongTy(string tenCTy, double mucDongGopChuan, double nganSach_ht, double nguonThu_thang, double nguonChi_thang)
        {
            this.TenCTy = tenCTy;
            this.MucDongGopChuan = mucDongGopChuan;
            this.NganSach_ht = nganSach_ht;
            this.NguonThu_thang = nguonThu_thang;
            this.NguonChi_thang = nguonChi_thang;
        }

        public string TenCTy { get => tenCTy; set => tenCTy = value; }
        public double MucDongGopChuan { get => mucDongGopChuan; set => mucDongGopChuan = value; }
        public double NganSach_ht { get => nganSach_ht; set => nganSach_ht = value; }
        public double NguonThu_thang { get => nguonThu_thang; set => nguonThu_thang = value; }
        public double NguonChi_thang { get => nguonChi_thang; set => nguonChi_thang = value; }
        public void TuyenDung(NhanVien nhanVien)
        {
            lstNV.Add(nhanVien);          
            Console.WriteLine("Da tuyen nhan vien thanh cong!");
        }
        public void SaThai()
        {
            List<NhanVien> lstNV_temp=new List<NhanVien>();
            foreach (NhanVien nv in lstNV)
            {
                lstNV_temp.Add(nv);
            }
            foreach (NhanVien nv in lstNV_temp)
            {
                if (nv.mucDongGop()<mucDongGopChuan)
                {
                    lstNV.Remove(nv);
                    Console.WriteLine("Da sa thai nhan vien {0} thanh cong!", nv.Ten);
                }
                               
            }
        }
        public void VonDieuLe()
        {
            double vondieule;
            double tongMucDongGopNV=0;
            double tongLuongNV=0;
            foreach (var nv in lstNV)
            {
                tongMucDongGopNV += nv.mucDongGop();
                tongLuongNV += nv.Luong;
            }
            vondieule = nganSach_ht + tongMucDongGopNV - tongLuongNV;
            if (vondieule<0)
            {
                Console.WriteLine("Cong ty pha san ruiiiii!!!!!!!!!!!!!!!");
            }
            else
            {
                Console.WriteLine("Von dieu le cong ty van con du!");
            }
        }
    }
}
