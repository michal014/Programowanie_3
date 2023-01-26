using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for MyListWindow.xaml
    /// </summary>
    public partial class MyListWindow : Window
    {
        List<MyListClass> myListClasses= new List<MyListClass>();
        public MyListWindow()
        {
            InitializeComponent();

            this.DataContext = myListClasses;

            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            try
            {
                myListClasses.Clear();
                connection.Open();

                string sql = "EXEC MyListShow @user_id ='"+ GlobalClass.userid + "';";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    MyListClass mylistClass = new MyListClass(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), Convert.ToInt32(dataReader.GetValue(4)), dataReader.GetValue(5).ToString());
                    myListClasses.Add(mylistClass);

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

        private void MyListDataGrid_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            GlobalClass.selectedItemMyList = (MyListClass)MyListDataGrid.SelectedItem;
            ShowMyListitemWindow siw = new ShowMyListitemWindow();
            siw.ShowDialog();
        }
    }
}
