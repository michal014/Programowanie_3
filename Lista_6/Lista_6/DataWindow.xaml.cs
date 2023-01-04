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
    /// Interaction logic for Insert.xaml
    /// </summary>
    public partial class DataWindow : Window
    {
        public bool shouldBeUse { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PESEL { get; set; }
        public DataWindow()
        {
            InitializeComponent();
        }

        private void DBInsert(object sender, RoutedEventArgs e)
        {
            ConfirmWindow cw = new ConfirmWindow();
            cw.ShowDialog();
            if (cw.shouldBeConfirmed)
            {
                shouldBeUse = true;
                FirstName = TBFirstName.Text;
                LastName = TBLastName.Text;
                Gender = CBGender.Text;
                PESEL = TBPesel.Text;
                this.Close();
            }
        }

        private void DBInsertCancel(object sender, RoutedEventArgs e)
        {
            shouldBeUse = false;
            this.Close();
        }
    }
}
