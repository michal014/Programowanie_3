using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            if(GlobalClass.isAdmin)
            {
                BtnAddContent.Visibility = Visibility.Visible;
                BtnAddContent.IsEnabled = true;
            }
        }

        private void Items_List_Btn(object sender, RoutedEventArgs e)
        {
            ListWindow listwindow = new ListWindow();
            listwindow.Show();
            this.Close();
        }

        private void My_List_Btn(object sender, RoutedEventArgs e)
        {
            MyListWindow myListWindow= new MyListWindow();
            myListWindow.Show();
            this.Close();
        }

        private void Btn_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
