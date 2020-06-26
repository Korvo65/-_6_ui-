using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ClassForDataGrid//класс процент
    {
        public ClassForDataGrid(string _M, string _DS, string _DP, string _DD, string _Sp, string _S)
        {
            Month = _M;
            DepSum = _DS;
            DepPcnt = _DP;
            DepDay = _DD;
            Sp = _Sp;
            S = _S;
        }

        public string Month { get; set; }
        public string DepSum { get; set; }
        public string DepPcnt { get; set; }
        public string DepDay { get; set; }
        public string Sp { get; set; }
        public string S { get; set; }
    }
}
