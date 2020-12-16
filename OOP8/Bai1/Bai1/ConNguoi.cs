using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai1
{
    class ConNguoi
    {
        string ten;
        int tuoi;

        public ConNguoi()
        {
        }

        public ConNguoi(string ten, int tuoi)
        {
            this.Ten = ten;
            this.Tuoi = tuoi;
        }

        public string Ten { get => ten; set => ten = value; }
        public int Tuoi { get => tuoi; set => tuoi = value; }

    }
}
