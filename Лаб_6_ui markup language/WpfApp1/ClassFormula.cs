using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class ClassFormula
    {
        // Основные переменые
       private int month, days, j, n;
       private double P, I, Sp, S;

       public struct ForDataGrid//основы
        {
            public string Month;
            public string DepSum;
            public string DepPercent;
            public string days;
            public string Sp;
            public string S;
        }
       public List<ForDataGrid> List_ForMonths;

        public ClassFormula()
        {
            month = 0; days = 0; j = 0; n = 0 ;
            P = I = Sp = S = 0;

            List_ForMonths = new List<ForDataGrid>();
        }


        public ClassFormula(int _days, double _P, double _I)//класс вычислений начало
        {           
            days = _days;
            P = _P;
            I = _I;

            Sp = S = 0;
            month = 0;

            List_ForMonths = new List<ForDataGrid>();
        }

        public void Month_and_JN_Calc()//конвертер
        {
            double TempM;
            TempM = days / 30;
            if ((TempM > 0)&&(TempM<32))
            {
                month = Convert.ToInt32(Math.Round(TempM));
                n = month;
                j = days / n;
            }
            else
            {
                month = 0;
                n = 1;
                j = days;
            }       
        }        
        
        public ClassFormula Calculate()
        {
            bool ok = true;
            int TempJ = 0;
            ClassFormula NewF = this;
            n = 0;
            NewF.S = NewF.P;

            while (ok is true)
            {              
                if ((days - 30) > 0)
                {
                    j = TempJ = 30;
                    n = n+1;
                    ok = true;

                    NewF.S = NewF.S * (1 + ((NewF.I * NewF.j) / (365 * 100)));
                    NewF.Sp = NewF.S - NewF.P;

                    ForDataGrid fdg = new ForDataGrid();
                    fdg.Month = n.ToString();
                    fdg.DepSum = P.ToString();
                    fdg.DepPercent = I.ToString();
                    fdg.days = j.ToString();
                    fdg.Sp = Sp.ToString();
                    fdg.S = S.ToString();

                    List_ForMonths.Add(fdg);
                    days = days - 30;
                }
                else
                {
                    j = days;
                    n = n + 1;
                    ok = false;

                    NewF.S = NewF.S * (1 + ((NewF.I * NewF.j) / (365 * 100)));
                    NewF.Sp = NewF.S - NewF.P;

                    ForDataGrid fdg = new ForDataGrid();
                    fdg.Month = n.ToString();
                    fdg.DepSum = P.ToString();
                    fdg.DepPercent = I.ToString();
                    fdg.days = j.ToString();
                    fdg.Sp = Sp.ToString();
                    fdg.S = S.ToString();

                    List_ForMonths.Add(fdg);
                }
            }
            if (TempJ != 0)
            {
                days = TempJ;
            }

            return NewF;


            //недоделаные допы......................
            /*
            ClassFormula NewF = this;
            
            NewF.S = NewF.P * (1 + ((NewF.I * NewF.j) / (365 * 100)));
            NewF.Sp = NewF.S - NewF.P;

            ForDataGrid fdg = new ForDataGrid();
            fdg.Month = "1";
            fdg.DepSum = P.ToString();
            fdg.DepPercent = I.ToString();
            fdg.days = j.ToString();
            fdg.Sp = Sp.ToString();
            fdg.S = S.ToString();

            List_ForMonths.Add(fdg);

            ForDataGrid fdgN = new ForDataGrid();
            for (int i = 1; i < n; i++)
            {
                NewF.S = NewF.S * (1 + ((NewF.I * NewF.j) / (365 * 100)));                
                NewF.Sp = NewF.S - NewF.P;
                
                fdgN.Month = (i+1).ToString();
                fdgN.DepSum = P.ToString();
                fdgN.DepPercent = I.ToString();
                fdgN.days = j.ToString();
                fdgN.Sp = Sp.ToString();
                fdgN.S = S.ToString();

                List_ForMonths.Add(fdgN);             
            }

            return NewF;
            */
        }

        /*private ForDataGrid (int _n, double _P, double _I, int _j, double _Sp, double _S)
        {
            ForDataGrid fdg = new ForDataGrid();
            fdg.Month = _n.ToString();
            fdg.DepSum = _P.ToString();
            fdg.DepPercent = _I.ToString();
            fdg.days = _j.ToString();
            fdg.Sp = _Sp.ToString();
            fdg.S = _S.ToString();

            return fdg;
        }*/
        /*
            ClassFormula NewF = this;
            
            NewF.S = NewF.P * (1 + ((NewF.I * NewF.j) / (365 * 100)));
            NewF.Sp = NewF.S - NewF.P;

            ForDataGrid fdg = new ForDataGrid();
            fdg.Month = "1";
            fdg.DepSum = P.ToString();
            fdg.DepPercent = I.ToString();
            fdg.days = j.ToString();
            fdg.Sp = Sp.ToString();
            fdg.S = S.ToString();

            List_ForMonths.Add(fdg);

            ForDataGrid fdgN = new ForDataGrid();
            for (int i = 1; i < n; i++)
            {
                NewF.S = NewF.S * (1 + ((NewF.I * NewF.j) / (365 * 100)));                
                NewF.Sp = NewF.S - NewF.P;
                
                fdgN.Month = (i+1).ToString();
                fdgN.DepSum = P.ToString();
                fdgN.DepPercent = I.ToString();
                fdgN.days = j.ToString();
                fdgN.Sp = Sp.ToString();
                fdgN.S = S.ToString();

                List_ForMonths.Add(fdgN);             
            }

            return NewF;
            */
    }

    /*private ForDataGrid (int _n, double _P, double _I, int _j, double _Sp, double _S)
    {
        ForDataGrid fdg = new ForDataGrid();
        fdg.Month = _n.ToString();
        fdg.DepSum = _P.ToString();
        fdg.DepPercent = _I.ToString();
        fdg.days = _j.ToString();
        fdg.Sp = _Sp.ToString();
        fdg.S = _S.ToString();

        return fdg;
    }*/


   

    /*private ForDataGrid (int _n, double _P, double _I, int _j, double _Sp, double _S)
    {
        ForDataGrid fdg = new ForDataGrid();
        fdg.Month = _n.ToString();
        fdg.DepSum = _P.ToString();
        fdg.DepPercent = _I.ToString();
        fdg.days = _j.ToString();
        fdg.Sp = _Sp.ToString();
        fdg.S = _S.ToString();

        return fdg;
    }*/
}    

