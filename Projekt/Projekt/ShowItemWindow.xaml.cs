using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for ShowItemWindow.xaml
    /// </summary>
    public partial class ShowItemWindow : Window
    {
        List<ShowItemClass> showItems = new List<ShowItemClass>();
        public ShowItemWindow()
        {
            InitializeComponent();
            int i = SelectedItem.selectedItem.id;

            this.DataContext = showItems;

            SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
                showItems.Clear();
                connection.Open();

                string sql = "SELECT content.id AS 'id',\r\n\tcontent.name AS 'name',\r\n\tcontent.description AS 'description',\r\n\ttable1.allscore AS 'allscore',\r\n\tcontent.numberofepisodes AS 'numberOfEpisodes',\r\n\tcontentrelation.progress AS 'episodeProgress',\r\n\tcontentrelation.rate AS 'score',\r\n\ttable2.genres AS 'genre',\r\n\ttable3.producers AS 'producer',\r\n\tcontentrelation.status AS 'idAdded',\r\n\tcontent.picture AS 'picture'\r\nFROM content\r\nJOIN contentrelation\r\nON content.id = contentrelation.contentid\r\nJOIN users\r\nON users.ID = contentrelation.userid\r\nJOIN (SELECT contentrelation.contentid AS 'id', AVG(contentrelation.rate) AS 'allscore' \r\n\t\tFROM contentrelation\r\n\t\tGROUP BY contentrelation.contentid) AS table1\r\nON table1.id = content.id\r\nJOIN (SELECT genrerelation.contentid,\r\n             STRING_AGG(genres.name, '; ') AS 'genres'\r\n      FROM genrerelation\r\n      JOIN genres\r\n      ON genrerelation.genreid = genres.id\r\n      GROUP BY genrerelation.contentid) AS table2\r\nON table2.contentID = content.id\r\nJOIN (SELECT producerrelation.contentid, \r\n             STRING_AGG(producer.name, '; ') AS 'producers'\r\n      FROM producerrelation\r\n      JOIN producer\r\n      ON producerrelation.producerid = producer.id\r\n      GROUP BY producerrelation.contentid) AS table3\r\nON table3.contentID = content.id\r\n WHERE content.id='"+ SelectedItem.selectedItem.id+ "' AND users.id=1 ORDER BY content.name ASC";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    ShowItemClass showItemClass = new ShowItemClass(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), Convert.ToInt32(dataReader.GetValue(3)), Convert.ToInt32(dataReader.GetValue(4)), Convert.ToInt32(dataReader.GetValue(5)), Convert.ToInt32(dataReader.GetValue(6)), dataReader.GetValue(7).ToString(), dataReader.GetValue(8).ToString(), Convert.ToBoolean(Convert.ToInt32(dataReader.GetValue(9))), dataReader.GetValue(10).ToString());
                    showItems.Add(showItemClass);

                }

                dataReader.Close();
                command.Dispose();
                connection.Close();
        }
    }
}
