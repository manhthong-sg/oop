using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai2
{
    class NguoiDung
    {
        //fields
        string userName;
        string passWord;
        string security_Q;
        string security_A;
        List<NguoiDung> lstUser = new List<NguoiDung>();
        //constructor
        public NguoiDung()
        {
        }

        public NguoiDung(string userName, string passWord, string security_Q, string security_A)
        {
            this.UserName = userName;
            this.PassWord = passWord;
            this.Security_Q = security_Q;
            this.Security_A = security_A;
        }
        // properties
        public string UserName { get => userName; set => userName = value; }
        public string PassWord { get => passWord; set => passWord = value; }
        public string Security_Q { get => security_Q; set => security_Q = value; }
        public string Security_A { get => security_A; set => security_A = value; }
        //methods
        public bool checkTK(string username, string password)
        {
            foreach (var user in lstUser)
            {
                if (user.userName== username && user.passWord==passWord)
                {
                    return true;
                }
                if (user.userName == username)
                {
                    Console.WriteLine("Co ve nhu ban quen mat khau nhi? \nNeu tra loi dung cau hoi bao mat ban co the thay doi password: ");
                    Console.WriteLine(security_Q +":");
                    string a = Console.ReadLine();
                    if (user.security_A==a)
                    {
                        Console.Write("Dung roi! Ban co the thay doi password \nVui long nhap password moi: ");
                        user.passWord = Console.ReadLine();
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("Ban chua phai la thanh vien");
                        Console.WriteLine("Ban co muon dang ky TK moi khong? Y/N?");
                        string y_n = Console.ReadLine();
                        if (y_n=="y")
                        {
                            Console.WriteLine("Okie vao form dang ky!!!");
                        }
                        else
                        {
                            Console.WriteLine("Out out ");
                        }
                        
                    }
                }
         
            }
            return false;
        }
    }
}
