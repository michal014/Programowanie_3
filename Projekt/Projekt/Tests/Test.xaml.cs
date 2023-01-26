using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Policy;
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
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using Projekt.Tests;

namespace Projekt
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        String sql;
        DBSelect sel;
        public Test()
        {
            InitializeComponent();
            sql = "Select * from content";
            sel = new DBSelect(ConnectionString.connectionString, sql);
            this.DataContext = sel;

        }

        

        private void Hello_World(object sender, RoutedEventArgs e)
        {
            //sql = "Select * from users";
            //DBSelect sel2 = new DBSelect(ConnectionString.connectionString, sql);
            //sel.SelectAccess = sel2.SelectAccess;

            //Image img = new Image();
            //BitmapImage bi = new BitmapImage();
            //bi.BeginInit();
            //bi.UriSource = new Uri("D:\\ni.png", UriKind.Absolute);
            //bi.EndInit();
            //img.Source = bi;

            //byte[] imageBytes = File.ReadAllBytes("D:\\thelordoftheringsthefellowshipofthering.png");
            //string base64String = Convert.ToBase64String(imageBytes);

            //SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            //connection.Open();
            //SqlDataAdapter adapter = new SqlDataAdapter();
            //sql = "Update content set picture='" + base64String + "' WHERE ID=1";
            //SqlCommand command = new SqlCommand(sql, connection);
            //adapter.UpdateCommand = command;
            //adapter.UpdateCommand.ExecuteNonQuery();
            //command.Dispose();
            //connection.Close();

            //SqlConnection connection = new SqlConnection(ConnectionString.connectionString);
            //connection.Open();
            //SqlDataReader reader;
            //sql = "select * from content WHERE ID=1";
            //SqlCommand command = new SqlCommand(sql, connection);
            //reader = command.ExecuteReader();
            //if (reader.Read())
            //{
            //    string zmien = (string)reader.GetValue(5);
            //    byte[] bit = Convert.FromBase64String(zmien);
            //    MemoryStream stream = new MemoryStream(bit);
            //    BitmapImage image = new BitmapImage();
            //    image.BeginInit();
            //    image.StreamSource = stream;
            //    image.EndInit();
            //    test_image.Source = image;
            //}
            ////test_image
            //reader.Close();
            //command.Dispose();
            //connection.Close();


        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Menu menu = new Menu();
            menu.Show();
        }
    }
}
