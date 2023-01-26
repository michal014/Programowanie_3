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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        UserOperations uo = new UserOperations();
        public Login()
        {
            InitializeComponent();
            this.DataContext = uo;
        }

        private void LoginBtn(object sender, RoutedEventArgs e)
        {
            uo.password = passwordbox.Password;
            if (uo.login != string.Empty  && uo.password != string.Empty)
            {
                SqlConnection connection = new SqlConnection(GlobalClass.connectionString);
                try
                {
                    connection.Open();
                    string sql = "EXEC LoginCheck '"+ uo.login + "','"+ GlobalClass.Encrypt(uo.password, GlobalClass.encryptKey) + "';";
                    SqlCommand command = new SqlCommand(sql, connection);
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.Read())
                    {
                        GlobalClass.userid = dataReader.GetInt32(0);
                        GlobalClass.isAdmin = dataReader.GetBoolean(1);
                        Menu menu = new Menu();
                        menu.Show();
                        dataReader.Close();
                        command.Dispose();
                        connection.Close();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Błędny login lub hasło");
                        dataReader.Close();
                        command.Dispose();
                        connection.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Błąd połączenia z bazą danych");
                }
            }
        }

        private void RegisterBtn(object sender, RoutedEventArgs e)
        {
            Register reg = new Register();
            reg.Show();
            this.Close();
        }
    }
}
