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

                string sql = "SELECT content.id as 'id',\r\n\t   content.name AS 'name',\r\n       contenttype.name AS 'type',\r\n       content.numberofepisodes AS 'episodes',\r\n       table1.producers AS 'producer',\r\n       table2.genres AS 'genre',\r\n       content.picture AS 'picture'\r\nFROM content\r\nJOIN contenttype\r\nON content.type = contenttype.id\r\nJOIN (SELECT producerrelation.contentid, \r\n             STRING_AGG(producer.name, '; ') AS 'producers'\r\n      FROM producerrelation\r\n      JOIN producer\r\n      ON producerrelation.producerid = producer.id\r\n      GROUP BY producerrelation.contentid) AS table1\r\nON table1.contentID = content.id\r\nJOIN (SELECT genrerelation.contentid,\r\n             STRING_AGG(genres.name, '; ') AS 'genres'\r\n      FROM genrerelation\r\n      JOIN genres\r\n      ON genrerelation.genreid = genres.id\r\n      GROUP BY genrerelation.contentid) AS table2\r\nON table2.contentID = content.id\r\nORDER BY content.name ASC;\r\n";
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
