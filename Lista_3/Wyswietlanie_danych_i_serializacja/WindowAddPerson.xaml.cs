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

namespace Wyswietlanie_danych_i_serializacja
{
    /// <summary>
    /// Interaction logic for WindowAddPerson.xaml
    /// </summary>
    public partial class WindowAddPerson : Window
    {
        public bool shouldBeSaved { get; set; }
        public WindowAddPerson()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            shouldBeSaved= true;
            this.Close();
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            shouldBeSaved = false;
            this.Close();
        }
    }
}
