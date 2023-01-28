using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for ShowMyListitemWindow.xaml
    /// </summary>
    public partial class ShowMyListitemWindow : Window
    {
        List<ShowItemClass> showItems = new List<ShowItemClass>();
        public ShowMyListitemWindow()
        {
            InitializeComponent();

            this.DataContext = showItems;

            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            try
            {
                connection.Open();
                string sql = "EXEC ShowMyList @content_id='" + GlobalClass.selectedItemMyList.id + "',@user_id='" + GlobalClass.userid + "';";
                SqlCommand command = new SqlCommand(sql, connection);
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
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
                    sql = "EXEC ShowList @content_id='" + GlobalClass.selectedItemMyList.id + "';";
                    command = new SqlCommand(sql, connection);
                    dataReader = command.ExecuteReader();
                    if (dataReader.Read())
                    {
                        ShowItemClass showItem = new ShowItemClass(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), Convert.ToInt32(dataReader.GetValue(3)), Convert.ToInt32(dataReader.GetValue(4)), 0, 0, dataReader.GetValue(5).ToString(), dataReader.GetValue(6).ToString(), false, dataReader.GetValue(7).ToString());
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
            string sql = "EXEC AddContentToUser " + GlobalClass.selectedItemMyList.id + "," + GlobalClass.userid + ";";
            SqlCommand command = new SqlCommand(sql, connection);
            adapter.InsertCommand = command;
            adapter.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            ShowMyListitemWindow smliw = new ShowMyListitemWindow();
            smliw.Show();
            this.Close();
        }
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "EXEC UpdateContentToUser " + showItems[0].score + "," + showItems[0].episodeProgress + "," + GlobalClass.selectedItemMyList.id + "," + GlobalClass.userid + ";";
            SqlCommand command = new SqlCommand(sql, connection);
            adapter.UpdateCommand = command;
            adapter.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            ShowMyListitemWindow smliw = new ShowMyListitemWindow();
            smliw.Show();
            this.Close();
        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "EXEC RemoveContentFromUser " + GlobalClass.selectedItemMyList.id + "," + GlobalClass.userid + ";";
            SqlCommand command = new SqlCommand(sql, connection);
            adapter.DeleteCommand = command;
            adapter.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            connection.Close();
            ShowMyListitemWindow smliw = new ShowMyListitemWindow();
            smliw.Show();
            this.Close();
        }
    }
}
