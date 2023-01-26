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
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        UserOperations uo = new UserOperations();
        bool Exist = false;
        public Register()
        {
            InitializeComponent();
            this.DataContext = uo;
        }

        private void RegisterBtn(object sender, RoutedEventArgs e)
        {
            uo.password = passwordbox.Password;
            if (uo.login != string.Empty && uo.password != string.Empty)
            {
                SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
                try
                {
                    connection.Open();

                    string sql = "EXEC LoginCheck '" + uo.login + "','" + GlobalClass.Encrypt(uo.password, GlobalClass.encryptKey) + "';";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        Exist = true;
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
            if (!Exist)
            {
                SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
                try
                {
                    connection.Open();
                    string sql = "EXEC InsertUser '"+uo.login+"','" + GlobalClass.Encrypt(uo.password, GlobalClass.encryptKey) + "'";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter();

                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();

                    command.Dispose();
                    connection.Close();
                    MessageBox.Show("Pomyślnie zarejestrowano");
                    Login login = new Login();
                    login.Show();
                    this.Close();

                }
                catch
                {
                    MessageBox.Show("Błąd połączenia z bazą danych");
                }
            }
            else
            {
                MessageBox.Show("użytkownik o podanym loginie już istnieje");
            }
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            Login log = new Login();
            log.Show();
            this.Close();
        }
    }
}
