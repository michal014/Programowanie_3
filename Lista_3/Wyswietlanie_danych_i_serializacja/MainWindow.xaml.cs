using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Wyswietlanie_danych_i_serializacja
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
            dataGridPerson.ItemsSource = personsList;
        }


        
        private void Add(object sender, RoutedEventArgs e)
        {
            WindowAddPerson window1 = new WindowAddPerson();
            Person person = new Person();
            window1.DataContext = person;
            window1.ShowDialog();
            if (window1.shouldBeSaved)
            {
                personsList.Add(person);
                dataGridPerson.Items.Refresh();
            }
        }

        private void Edit(object sender, RoutedEventArgs e)
        {
            if (personsList.Count > 0 && dataGridPerson.SelectedItem != null)
            {
                WindowAddPerson window2 = new WindowAddPerson();
                Person person2 = new Person((Person)dataGridPerson.SelectedItem);
                window2.DataContext = person2;
                window2.ShowDialog();
                if (window2.shouldBeSaved)
                {
                    personsList[personsList.IndexOf((Person)dataGridPerson.SelectedItem)] = person2;
                    dataGridPerson.Items.Refresh();
                }
            }
        }

        private void Delete(object sender, RoutedEventArgs e)
        {
            if (personsList.Count > 0 && dataGridPerson.SelectedItem != null)
            {
                personsList.RemoveAt(personsList.IndexOf((Person)dataGridPerson.SelectedItem));
                dataGridPerson.Items.Refresh();
            }
        }

        private void Save(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Plik xml|*.xml";
            sfd.Title = "Podaj nazwę pliku do zapisu danych";
            sfd.ShowDialog();
            if (sfd.FileName != "")
            {
                try
                {
                    Serialization.SerializeToXml<List<Person>>(personsList, sfd.FileName);
                }
                catch
                {
                    MessageBox.Show("Nie udało się zapisać pliku");
                }
            }
        }

        private void Load(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Plik xml|*.xml";
            ofd.Title = "Podaj nazwę pliku do odczytu danych";
            ofd.ShowDialog();
            if (ofd.FileName != "")
            {
                try
                {
                    personsList = Serialization.DeserializeToObject<List<Person>>(ofd.FileName);
                }
                catch (InvalidOperationException)
                {
                    MessageBox.Show("Plik xml jest uszkodzony nie można przeprowadzić odczytu");
                }
                catch
                {
                    MessageBox.Show("Nie udało się otworzyć pliku");
                }
            }
            dataGridPerson.ItemsSource = personsList;
            dataGridPerson.Items.Refresh();
        }

        private void dataGridPerson_Loaded(object sender, RoutedEventArgs e)
        {
            dataGridPerson.Columns[0].Header = "Imię";
            dataGridPerson.Columns[1].Header = "Nazwisko";
            dataGridPerson.Columns[2].Header = "Płeć";
            dataGridPerson.Columns[3].Header = "PESEL";
        }
    }
}
