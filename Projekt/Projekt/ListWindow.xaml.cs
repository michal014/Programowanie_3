using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        List<ListClass> listClasses = new List<ListClass>();
        public ListWindow()
        {
            InitializeComponent();

            this.DataContext = listClasses;

            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            try
            {
                listClasses.Clear();
                connection.Open();

                string sql = "EXEC ListShow";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    ListClass listClass = new ListClass(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), Convert.ToInt32(dataReader.GetValue(3)), dataReader.GetValue(4).ToString(), dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString());
                    listClasses.Add(listClass);

                }

                dataReader.Close();
                command.Dispose();
                connection.Close();

            }
            catch
            {
                MessageBox.Show("Błąd połączenia z bazą danych");
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }

        private void ListDataGrid_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GlobalClass.selectedItemList = (ListClass)ListDataGrid.SelectedItem;
            ShowListitemWindow siw = new ShowListitemWindow();
            siw.ShowDialog();
        }
    }
}
