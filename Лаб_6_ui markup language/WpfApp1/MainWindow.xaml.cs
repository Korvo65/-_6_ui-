using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public struct ForDataGrid
        {
            public string Month;
            public string DepSum;
            public string DepPercent;
            public string days;
            public string Sp;
            public string S;
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        DataTable myTable = new DataTable();

        private void Btn_Res_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string s = TBx_DepositSum.Text;
                double DepositSum = Convert.ToDouble(s);

                s = TBx_DepositDays.Text;
                int DepositDays = Convert.ToInt32(s);

                s = TBx_DepositPercents.Text;
                double DepositPercents = Convert.ToDouble(s);

                ClassFormula f = new ClassFormula(DepositDays, DepositSum, DepositPercents);
               // f.Month_and_JN_Calc();
                f = f.Calculate();

                TBx_CapitalOpeationCount.Text = f.List_ForMonths[f.List_ForMonths.Count - 1].Month;
                TBx_CapitalDaysCount.Text = f.List_ForMonths[0].days;

                List<ClassForDataGrid> tst = new List<ClassForDataGrid>(f.List_ForMonths.Count);

                for (int i = 0; i < f.List_ForMonths.Count; i++)
                {
                    ClassForDataGrid cfdg = new ClassForDataGrid("0", "0", "0", "0", "0", "0")
                    {
                        Month = f.List_ForMonths[i].Month,
                        DepSum = f.List_ForMonths[i].DepSum,
                        DepPcnt = f.List_ForMonths[i].DepPercent,
                        DepDay = f.List_ForMonths[i].days,
                        Sp = f.List_ForMonths[i].Sp,
                        S = f.List_ForMonths[i].S
                    };
                    tst.Add(cfdg);
                }
                Percents.ItemsSource = tst;
            }
            catch(Exception ex)
            {                
                
            }
        }

        private void Btn_Test_Click(object sender, RoutedEventArgs e)
        {
            TBx_DepositSum.Text = "50000";
            TBx_DepositDays.Text = "90";
            TBx_DepositPercents.Text = "10,5";
        }

        private void MySuperWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_Clr_Click(object sender, RoutedEventArgs e)
        {
            TBx_CapitalDaysCount.Text = TBx_CapitalOpeationCount.Text = TBx_DepositDays.Text = TBx_DepositPercents.Text = TBx_DepositSum.Text = "0";
            Percents.ItemsSource = "";
        }
    }
}
