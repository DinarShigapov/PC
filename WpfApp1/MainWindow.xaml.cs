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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Refresh();
        }

        private void Refresh()
        {

            IEnumerable<Pc> filterCase = App.DB.Pc.ToList();

            foreach (var child in Checksum_Collection.Children)
            {
                var check = child as CheckBox;
                if (check.IsChecked == true)
                {
                    foreach (Pc pc in filterCase)
                    {
                        filterCase = filterCase.Where(x =>
                        x.E_ATX && CbEatx.IsChecked == true ||
                        x.Flex_ATX && CbFlex.IsChecked == true ||
                        x.Micro_ATX && CbMicro.IsChecked == true ||
                        x.Mini_DTX && CbMiniDtx.IsChecked == true ||
                        x.Mini_ITX && CbMiniItx.IsChecked == true ||
                        x.SSI_CEB && CbSsiCeb.IsChecked == true ||
                        x.SSI_EEB && CbSsiEeb.IsChecked == true ||
                        x.Standart_ATX && CbStandart.IsChecked == true ||
                        x.Thin_Mini_ITX && CbThin.IsChecked == true ||
                        x.Xl_ATX && CbXl.IsChecked == true).ToList();
                    }
                }           
            }

            LVPc.ItemsSource = filterCase.ToList();
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void Unchecked_Click(object sender, RoutedEventArgs e)
        {
            foreach (var child in Checksum_Collection.Children)
            {
                var check = child as CheckBox;
                check.IsChecked = false;
            }
        }
    }
}
