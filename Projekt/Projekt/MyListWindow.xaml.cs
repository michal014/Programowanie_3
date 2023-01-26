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

                string sql = "SELECT\tcontent.id AS 'id',\r\n\t\tcontent.name AS 'name',\r\n\t\tcontenttype.name AS 'type',\r\n\t\ttable1.progress AS 'progress',\r\n\t\tcontentrelation.rate AS 'score',\r\n\t\tcontent.picture AS 'picture'\r\nFROM content\r\nJOIN contenttype\r\nON content.type = contenttype.id\r\nJOIN contentrelation\r\nON content.id = contentrelation.contentid\r\nJOIN users\r\nON contentrelation.userid=users.id\r\nJOIN(SELECT content.id AS 'id',users.id AS 'uid',CONCAT(contentrelation.progress,'/',content.numberofepisodes) AS 'progress'\r\n\t\tFROM content\r\n\t\tJOIN contentrelation\r\n\t\tON content.id = contentrelation.contentid\r\n\t\tJOIN users\r\n\t\tON users.ID = contentrelation.userid) AS table1\r\nON table1.id = contentrelation.contentid AND table1.uid = contentrelation.userid WHERE users.ID=" + GlobalClass.userid+";";
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
