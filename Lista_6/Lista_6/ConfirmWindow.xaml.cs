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

namespace Lista_6
{
    /// <summary>
    /// Interaction logic for ConfirmWindow.xaml
    /// </summary>
    public partial class ConfirmWindow : Window
    {
        public bool shouldBeConfirmed { get; set; }
        public ConfirmWindow()
        {
            InitializeComponent();
        }

        private void ButtonYes(object sender, RoutedEventArgs e)
        {
            shouldBeConfirmed = true;
            this.Close();
        }

        private void ButtonNo(object sender, RoutedEventArgs e)
        {
            shouldBeConfirmed = false;
            this.Close();
        }
    }
}
