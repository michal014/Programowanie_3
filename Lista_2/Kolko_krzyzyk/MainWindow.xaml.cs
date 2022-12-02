using System;
using System.Collections.Generic;
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

namespace Kolko_krzyzyk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool player = true;
        private short[] board = new short[9];
        public MainWindow()
        {
            InitializeComponent();
            StartMethod();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;

            if (player)
            {
                b.Content = "X";
                b.IsEnabled = false;
                board[Convert.ToInt16(b.Tag)] = 1;
                player = false;
            }
            else if(!player)
            {
                b.Content = "O";
                b.IsEnabled = false;
                board[Convert.ToInt16(b.Tag)] = -1;
                player = true;
            }

            CheckBorder();

            
        }
        private void StartMethod()
        {
            for (int i = 0; i < 9; i++)
            {
                board[i] = 0;
            }
            player = true;

            bt0.Content = null;
            bt0.IsEnabled = true;

            bt1.Content = null;
            bt1.IsEnabled = true;

            bt2.Content = null;
            bt2.IsEnabled = true;

            bt3.Content = null;
            bt3.IsEnabled = true;

            bt4.Content = null;
            bt4.IsEnabled = true;

            bt5.Content = null;
            bt5.IsEnabled = true;

            bt6.Content = null;
            bt6.IsEnabled = true;

            bt7.Content = null;
            bt7.IsEnabled = true;

            bt8.Content = null;
            bt8.IsEnabled = true;
        }

        private void CheckBorder()
        {
            if ((board[0] == 1 && board[1] == 1 && board[2] == 1) || 
                (board[3] == 1 && board[4] == 1 && board[5] == 1) || 
                (board[6] == 1 && board[7] == 1 && board[8] == 1) || 
                (board[0] == 1 && board[3] == 1 && board[6] == 1) || 
                (board[1] == 1 && board[4] == 1 && board[7] == 1) || 
                (board[2] == 1 && board[5] == 1 && board[8] == 1) || 
                (board[0] == 1 && board[4] == 1 && board[8] == 1) || 
                (board[2] == 1 && board[4] == 1 && board[6] == 1))
            {
                MessageBox.Show("Wygrał Gracz 1");
                StartMethod();
            }

            else if((board[0] == -1 && board[1] == -1 && board[2] == -1) ||
                (board[3] == -1 && board[4] == -1 && board[5] == -1) ||
                (board[6] == -1 && board[7] == -1 && board[8] == -1) ||
                (board[0] == -1 && board[3] == -1 && board[6] == -1) ||
                (board[1] == -1 && board[4] == -1 && board[7] == -1) ||
                (board[2] == -1 && board[5] == -1 && board[8] == -1) ||
                (board[0] == -1 && board[4] == -1 && board[8] == -1) ||
                (board[2] == -1 && board[4] == -1 && board[6] == -1))
            {
                MessageBox.Show("Wygrał Gracz 2");
                StartMethod();
            }
        }
    }
}
