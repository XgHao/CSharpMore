using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class HP_Print : IMultiPrint
    {
        private int hp_no;
        private string hp_name;

        private int cnt;

        public HP_Print(int _hpno,string _hpname)
        {
            hp_no = _hpno;
            hp_name = _hpname;
            cnt = 1;
        }

        public int NO { get => hp_no; set => value = hp_no; }
        public string Name { get => $"HP-{hp_name}"; set => value = $"{hp_name}-HP"; }

        public void Print()
        {
            Console.WriteLine($"hp_no:{hp_no}\thp_name:{hp_name}");
        }

        public int PrintCnt()
        {
            return cnt;
        }
    }
}
