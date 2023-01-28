using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
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
    /// Interaction logic for AddContentWindow.xaml
    /// </summary>
    public partial class AddContentWindow : Window
    {
        AddContentClass acc = new AddContentClass();
        public AddContentWindow()
        {
            InitializeComponent();
            this.DataContext= acc;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
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
            if (!int.TryParse(((TextBox)sender).Text, out value) || value == Int32.MaxValue )
            {
                ((TextBox)sender).Text = "";
            }
        }

        private void Btn_Click_Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Plik Obrazu (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            ofd.Title = "Podaj nazwę pliku obrazu";
            ofd.ShowDialog();
            if(ofd.FileName != "")
            {
                try
                {
                    acc.picture_location = ofd.FileName;
                }
                catch 
                {
                    MessageBox.Show("Błąd odczytu pliku");
                }
            }

        }

        private void Btn_Click_Save(object sender, RoutedEventArgs e)
        {
            if (acc.name != String.Empty && acc.type != String.Empty && acc.description != String.Empty && acc.genres != String.Empty && acc.producers != String.Empty)
            {
                byte[] imageBytes;
                string base64String;
                if (acc.picture_location == string.Empty)
                {
                    acc.picture_location = "Resources/np.png";
                    imageBytes = File.ReadAllBytes(acc.picture_location);
                    base64String = Convert.ToBase64String(imageBytes);
                    acc.picture_location = string.Empty;
                }
                else
                {
                    imageBytes = File.ReadAllBytes(acc.picture_location);
                    base64String = Convert.ToBase64String(imageBytes);
                }

                bool Exist = false;
                int sqlint = 0;
                int contentid = 0;
                SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
                string sql;
                SqlCommand command;
                SqlDataReader datareader;
                SqlDataAdapter adapter = new SqlDataAdapter();
                try
                {
                    connection.Open();
                    sql = "EXEC GetContentTypeIDByName'" + acc.type + "'";
                    command = new SqlCommand(sql, connection);
                    datareader = command.ExecuteReader();

                    if (datareader.Read())
                    {
                        Exist = true;
                        acc.type = datareader.GetInt32(0).ToString();
                    }

                    datareader.Close();
                    command.Dispose();

                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Błąd połączenia z bazą danych");
                }
                if (!Exist)
                {
                    try
                    {
                        connection.Open();
                        sql = "EXEC InsertContenttypeName '" + acc.type + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();

                        sql = "EXEC Get1idfromcontenttypebyDesc";
                        command = new SqlCommand(sql, connection);
                        datareader = command.ExecuteReader();
                        if (datareader.Read())
                        {
                            sqlint = datareader.GetInt32(0);
                        }
                        datareader.Close();
                        command.Dispose();

                        sql = "EXEC InsertContent '" + acc.name + "','" + sqlint + "','" + acc.numberofepisodes + "','" + acc.description + "','" + base64String + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Błąd połączenia z bazą danych");
                    }

                }
                else
                {
                    try
                    {
                        connection.Open();

                        sql = "EXEC InsertContent '" + acc.name + "','" + Convert.ToInt32(acc.type) + "','" + acc.numberofepisodes + "','" + acc.description + "','" + base64String + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();
                        connection.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Błąd połączenia z bazą danych");
                    }
                }
                try
                {
                    connection.Open();
                    sql = "EXEC Get1contentidbyDesc";
                    command = new SqlCommand(sql, connection);
                    datareader = command.ExecuteReader();
                    if (datareader.Read())
                        contentid = datareader.GetInt32(0);
                    datareader.Close();
                    command.Dispose();
                    connection.Close();
                }
                catch
                {
                    MessageBox.Show("Błąd połączenia z bazą danych");
                }

                List<string> strings = new List<string>();
                if (acc.separator != string.Empty)
                {
                    string[] stringss = acc.genres.Split(acc.separator);
                    foreach (string s in stringss)
                    {
                        strings.Add(s);
                    }
                }
                else
                {
                    strings.Add(acc.genres);
                }

                connection.Open();
                foreach (string s in strings)
                {
                    Exist = false;
                    sqlint = 0;
                    sql = "EXEC GetGenreIdByName'" + s + "'";
                    command = new SqlCommand(sql, connection);
                    datareader = command.ExecuteReader();

                    if (datareader.Read())
                    {
                        Exist = true;
                        sqlint = datareader.GetInt32(0);
                    }

                    datareader.Close();
                    command.Dispose();

                    if (!Exist)
                    {
                        sql = "EXEC InsertGenre '" + s + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();

                        sql = "EXEC GetGenreIdByName'" + s + "'";
                        command = new SqlCommand(sql, connection);
                        datareader = command.ExecuteReader();

                        if (datareader.Read())
                        {
                            sqlint = datareader.GetInt32(0);
                        }

                        datareader.Close();
                        command.Dispose();

                        sql = "EXEC InsertGenrerelation '" + contentid + "','" + sqlint + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();
                    }
                    else
                    {
                        sql = "EXEC InsertGenrerelation '" + contentid + "','" + sqlint + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();
                    }
                }
                List<string> strings2 = new List<string>();
                if (acc.separator != string.Empty)
                {
                    string[] stringss2 = acc.producers.Split(acc.separator);
                    foreach (string s in stringss2)
                    {
                        strings2.Add(s);
                    }
                }
                else
                {
                    strings2.Add(acc.producers);
                }
                foreach (string s in strings2)
                {
                    Exist = false;
                    sqlint = 0;
                    sql = "EXEC GetProducerIDByName'" + s + "'";
                    command = new SqlCommand(sql, connection);
                    datareader = command.ExecuteReader();

                    if (datareader.Read())
                    {
                        Exist = true;
                        sqlint = datareader.GetInt32(0);
                    }

                    datareader.Close();
                    command.Dispose();

                    if (!Exist)
                    {
                        sql = "EXEC InsertProducer '" + s + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();

                        sql = "EXEC GetProducerIDByName'" + s + "'";
                        command = new SqlCommand(sql, connection);
                        datareader = command.ExecuteReader();

                        if (datareader.Read())
                        {
                            sqlint = datareader.GetInt32(0);
                        }

                        datareader.Close();
                        command.Dispose();

                        sql = "EXEC InsertProducerrelation'" + contentid + "','" + sqlint + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();
                    }
                    else
                    {
                        sql = "EXEC InsertProducerrelation'" + contentid + "','" + sqlint + "';";
                        command = new SqlCommand(sql, connection);
                        adapter.InsertCommand = command;
                        adapter.InsertCommand.ExecuteNonQuery();

                        command.Dispose();
                    }
                }
                connection.Close();
                this.Close();
            }
            else
            {
                MessageBox.Show("Jedno lub więcej pole puste");
            }
        }
    }
}
