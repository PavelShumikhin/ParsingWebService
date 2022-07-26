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
using System.Windows.Shapes;

namespace ParsingWebService.Class.Команды
{
    /// <summary>
    /// Логика взаимодействия для WindowInputDate.xaml
    /// </summary>
    public partial class WindowInputDate : Window
    {
        public WindowInputDate()
        {
            InitializeComponent();
            fillCBDay();
            fillCBMonth();
            DataContext = new ApplicationViewNumber();
        }

        void fillCBDay()
        {
            for (int i = 1; i < 32; i++)
            {
                cbDay.Items.Add(i.ToString());
            }
        }
        void fillCBMonth()
        {
            for (int i = 1; i < 13; i++)
            {
                cbMonth.Items.Add(i.ToString());
            }
        }
        public void cancelDateWindow()
        {
            this.Close();
        }
        public void showDateWindow()
        {
            this.Show();
        }
    }
}
