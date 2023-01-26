using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ShowListitemWindow.xaml
    /// </summary>
    public partial class ShowListitemWindow : Window
    {
        List<ShowItemClass> showItems = new List<ShowItemClass>();
        public ShowListitemWindow()
        {
            InitializeComponent(); 
            
            this.DataContext = showItems;

            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            try
            {
                connection.Open();

                string sql = "SELECT content.id AS 'id',\r\n\tcontent.name AS 'name',\r\n\tcontent.description AS 'description',\r\n\ttable1.allscore AS 'allscore',\r\n\tcontent.numberofepisodes AS 'numberOfEpisodes',\r\n\tcontentrelation.progress AS 'episodeProgress',\r\n\tcontentrelation.rate AS 'score',\r\n\ttable2.genres AS 'genre',\r\n\ttable3.producers AS 'producer',\r\n\tcontentrelation.status AS 'idAdded',\r\n\tcontent.picture AS 'picture'\r\nFROM content\r\nJOIN (SELECT content.id AS 'id', AVG(ISNULL(contentrelation.rate, 0)) AS 'allscore'\r\n\t\tFROM content\r\n\t\tLEFT JOIN contentrelation ON content.id = contentrelation.contentid\r\n\t\tGROUP BY content.id) AS table1\r\nON table1.id = content.id\r\nJOIN (SELECT genrerelation.contentid,\r\n             STRING_AGG(genres.name, '; ') AS 'genres'\r\n      FROM genrerelation\r\n      JOIN genres\r\n      ON genrerelation.genreid = genres.id\r\n      GROUP BY genrerelation.contentid) AS table2\r\nON table2.contentID = content.id\r\nJOIN (SELECT producerrelation.contentid, \r\n             STRING_AGG(producer.name, '; ') AS 'producers'\r\n      FROM producerrelation\r\n      JOIN producer\r\n      ON producerrelation.producerid = producer.id\r\n      GROUP BY producerrelation.contentid) AS table3\r\nON table3.contentID = content.id\r\nJOIN contentrelation\r\nON contentrelation.contentid=content.id\r\nJOIN users\r\nON users.ID=contentrelation.userid\r\nWHERE content.id='"+GlobalClass.selectedItemList.id+"' AND users.ID='"+ GlobalClass.userid +"'\r\nORDER BY content.name ASC;";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dataReader = command.ExecuteReader();
                
                if(dataReader.Read())
                {
                    ShowItemClass showItem = new ShowItemClass(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), (float)Convert.ToDouble(dataReader.GetValue(3)), Convert.ToInt32(dataReader.GetValue(4)), Convert.ToInt32(dataReader.GetValue(5)), Convert.ToInt32(dataReader.GetValue(6)), dataReader.GetValue(7).ToString(), dataReader.GetValue(8).ToString(), Convert.ToBoolean(Convert.ToInt32(dataReader.GetValue(9))), dataReader.GetValue(10).ToString());
                    showItems.Add(showItem);
                    BtnAdd.Visibility = Visibility.Hidden;
                    BtnAdd.IsEnabled = false;
                }
                else
                {
                    dataReader.Close();
                    command.Dispose();
                    sql = "SELECT content.id AS 'id',\r\n\tcontent.name AS 'name',\r\n\tcontent.description AS 'description',\r\n\ttable1.allscore AS 'allscore',\r\n\tcontent.numberofepisodes AS 'numberOfEpisodes',\r\n\ttable2.genres AS 'genre',\r\n\ttable3.producers AS 'producer',\r\n\tcontent.picture AS 'picture'\r\nFROM content\r\nJOIN (SELECT content.id AS 'id', AVG(ISNULL(contentrelation.rate, 0)) AS 'allscore'\r\n\t\tFROM content\r\n\t\tLEFT JOIN contentrelation ON content.id = contentrelation.contentid\r\n\t\tGROUP BY content.id) AS table1\r\nON table1.id = content.id\r\nJOIN (SELECT genrerelation.contentid,\r\n             STRING_AGG(genres.name, '; ') AS 'genres'\r\n      FROM genrerelation\r\n      JOIN genres\r\n      ON genrerelation.genreid = genres.id\r\n      GROUP BY genrerelation.contentid) AS table2\r\nON table2.contentID = content.id\r\nJOIN (SELECT producerrelation.contentid, \r\n             STRING_AGG(producer.name, '; ') AS 'producers'\r\n      FROM producerrelation\r\n      JOIN producer\r\n      ON producerrelation.producerid = producer.id\r\n      GROUP BY producerrelation.contentid) AS table3\r\nON table3.contentID = content.id\r\nWHERE content.id='"+ GlobalClass.selectedItemList.id + "';";
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        ShowItemClass showItem = new ShowItemClass(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), Convert.ToInt32(dataReader.GetValue(3)),Convert.ToInt32(dataReader.GetValue(4)),0, 0, dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString(), false, dataReader.GetValue(7).ToString());
                        showItems.Add(showItem);
                    }
                    LableYourScore.Visibility = Visibility.Hidden;
                    TBepisodeProgress.Visibility = Visibility.Hidden;
                    TBScore.Visibility = Visibility.Hidden;
                    TBSlesh.Visibility = Visibility.Hidden;
                    BtnEdit.Visibility = Visibility.Hidden;
                    BtnDel.Visibility = Visibility.Hidden;
                    TBepisodeProgress.IsEnabled = false;
                    TBScore.IsEnabled = false;
                    TBSlesh.IsEnabled = false;
                    BtnDel.IsEnabled = false;
                    BtnDel.IsEnabled = false;
                    BtnAdd.Visibility = Visibility.Visible;
                    BtnAdd.IsEnabled = true;
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private void TextValidationTextBox(object sender, TextChangedEventArgs e)
        {
            int value;
            if (!int.TryParse(((TextBox)sender).Text, out value) || value > showItems[0].numberOfEpisodes)
            {
                ((TextBox)sender).Text = "";
            }
        }

        private void TextValidationTextBox2(object sender, TextChangedEventArgs e)
        {
            int value;
            if (!int.TryParse(((TextBox)sender).Text, out value) || value > 10)
            {
                ((TextBox)sender).Text = "";
            }
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "INSERT INTO contentrelation (contentid,userid) values('" + GlobalClass.selectedItemList.id + "','" + GlobalClass.userid + "');";
            SqlCommand command= new SqlCommand(sql, connection);
            adapter.InsertCommand= command;
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            ShowListitemWindow sliw = new ShowListitemWindow();
            sliw.Show();
            this.Close();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "UPDATE contentrelation SET rate='" + showItems[0].score + "', progress='" + showItems[0].episodeProgress + "' WHERE contentid='"+ GlobalClass.selectedItemList.id + "' AND userid='"+ GlobalClass.userid + "';";
            SqlCommand command = new SqlCommand(sql, connection);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            ShowListitemWindow sliw = new ShowListitemWindow();
            sliw.Show();
            this.Close();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "DELETE contentrelation WHERE contentid='" + GlobalClass.selectedItemList.id + "' AND userid='" + GlobalClass.userid + "';";
            SqlCommand command = new SqlCommand(sql, connection);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            ShowListitemWindow sliw = new ShowListitemWindow();
            sliw.Show();
            this.Close();
        }
    }
}
