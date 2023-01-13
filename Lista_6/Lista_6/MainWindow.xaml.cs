using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lista_6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Person> personsList = new List<Person>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void dataGridPerson_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridPerson.ItemsSource = personsList;
            dataGridPerson.Columns[0].Header = "ID";
            dataGridPerson.Columns[1].Header = "Imię";
            dataGridPerson.Columns[2].Header = "Nazwisko";
            dataGridPerson.Columns[3].Header = "Płeć";
            dataGridPerson.Columns[4].Header = "PESEL";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DBSelect();
        }

        private void DBSelectButton(object sender, RoutedEventArgs e)
        {
            DBSelect();
        }

        private void DBInsertButton(object sender, RoutedEventArgs e)
        {
            DataWindow window = new DataWindow();
            window.ShowDialog();
            if (window.shouldBeUse)
            {
                string connetionString;
                SqlConnection cnn;
                connetionString = @"Data Source=LAPTOP-SI4R27P1\MB_LOCAL;Initial Catalog=lista_6;User ID=sa;Password=zaq1@WSX;encrypt=false";
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();

                    SqlCommand command;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    string sql = "";

                    sql = "Insert into Persons (FirstName,lastName,Gender,PESEL) values('" + window.FirstName + "','" + window.LastName + "','" + window.Gender + "','" + window.PESEL + "')";

                    command = new SqlCommand(sql, cnn);

                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();

                    DBSelect();

                    command.Dispose();
                    cnn.Close();
                }
                catch
                {
                    MessageBox.Show("Error durning database connect");
                }
            }
        }

        private void DBUpdateButton(object sender, RoutedEventArgs e)
        {
            if (personsList.Count > 0 && dataGridPerson.SelectedItem != null && dataGridPerson.SelectedIndex != dataGridPerson.Columns.Count - 1)
            {
                DataWindow window = new DataWindow();
                Person person = new Person((Person)dataGridPerson.SelectedItem);
                window.TBFirstName.Text = person.FirstName;
                window.TBLastName.Text = person.LastName;
                window.CBGender.Text = person.Gender;
                window.TBPesel.Text = person.PESEL;
                window.ShowDialog();
                if (window.shouldBeUse)
                {
                    string connetionString;
                    SqlConnection cnn;
                    connetionString = @"Data Source=LAPTOP-SI4R27P1\MB_LOCAL;Initial Catalog=lista_6;User ID=sa;Password=zaq1@WSX;encrypt=false";
                    cnn = new SqlConnection(connetionString);
                    try
                    {
                        cnn.Open();

                        SqlCommand command;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        string sql = "";

                        sql = "Update Persons set FirstName='" + window.FirstName + "', LastName='" + window.LastName + "', Gender='" + window.Gender + "', PESEL='" + window.PESEL + "' WHERE ID=" + person.Id + ";";

                        command = new SqlCommand(sql, cnn);

                        adapter.UpdateCommand = command;
                        adapter.UpdateCommand.ExecuteNonQuery();

                        DBSelect();

                        command.Dispose();
                        cnn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Error durning database connect");
                    }
                }
            }
        }

        private void DBDeleteButton(object sender, RoutedEventArgs e)
        {
            if (personsList.Count > 0 && dataGridPerson.SelectedItem != null && dataGridPerson.SelectedIndex != dataGridPerson.Columns.Count-1)
            {
                Person person = new Person((Person)dataGridPerson.SelectedItem);
                ConfirmWindow cw = new ConfirmWindow();
                cw.ShowDialog();
                if (cw.shouldBeConfirmed)
                {
                    string connetionString;
                    SqlConnection cnn;
                    connetionString = @"Data Source=LAPTOP-SI4R27P1\MB_LOCAL;Initial Catalog=lista_6;User ID=sa;Password=zaq1@WSX;encrypt=false";
                    cnn = new SqlConnection(connetionString);
                    try
                    {
                        cnn.Open();

                        SqlCommand command;
                        SqlDataAdapter adapter = new SqlDataAdapter();
                        string sql = "";

                        sql = "Delete Persons where Id=" + person.Id + ";";

                        command = new SqlCommand(sql, cnn);

                        adapter.DeleteCommand = command;
                        adapter.DeleteCommand.ExecuteNonQuery();

                        DBSelect();

                        command.Dispose();
                        cnn.Close();
                    }
                    catch
                    {
                        MessageBox.Show("Error durning database connect");
                    }
                }
            }
        }

        public void DBSelect()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-SI4R27P1\MB_LOCAL;Initial Catalog=lista_6;User ID=sa;Password=zaq1@WSX;encrypt=false";
            cnn = new SqlConnection(connetionString);
            try
            {
                personsList.Clear();
                cnn.Open();

                SqlCommand command;
                SqlDataReader dataReader;
                string sql = "";

                sql = "Select ID,FirstName,lastName,Gender,PESEL from Persons";

                command = new SqlCommand(sql, cnn);

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Person person = new Person(Convert.ToInt32(dataReader.GetValue(0)), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString(), dataReader.GetValue(3).ToString(), dataReader.GetValue(4).ToString());
                    personsList.Add(person);
                }

                dataReader.Close();
                command.Dispose();
                cnn.Close();
                dataGridPerson.ItemsSource = personsList;
                dataGridPerson.Items.Refresh();
            }
            catch
            {
                MessageBox.Show("Error durning database connect");
            }
        }
    }
}
