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

namespace Projekt
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Items_List_Btn(object sender, RoutedEventArgs e)
        {
            ListWindow listwindow = new ListWindow();
            listwindow.Show();
            this.Close();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Test window = new Test();
            window.Show();
            this.Close();
        }

        private void Btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
