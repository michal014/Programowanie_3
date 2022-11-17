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

namespace Statki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int[] player1 = new int[100];
        public static int[] player2 = new int[100];

        public MainWindow()
        {
            InitializeComponent();
            CreatButtons();
            ClearArrays();
            Player2 window = new Player2();
            window.Show();
        }

        private void G1_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            player1[Convert.ToInt16(button.Tag)] += 1;
        }

        private void G2_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            player1[Convert.ToInt16(button.Tag)] += 2;
        }

        private void ClearArrays()
        {
            for (int i = 0; i < 100; i++)
            {
                player1[i] = 0;
                player2[i] = 0;
            }
        }

        private void CreatButtons()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    {
                        Tag = ((i * 10) + j);
                        Grid.SetRow(btn, i + 1);
                        Grid.SetColumn(btn, j);
                    };
                    btn.Click += new RoutedEventHandler(G1_Shoot);
                    this.p1_board.Children.Add(btn);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button btn = new Button();
                    {
                        Tag = ((i * 10) + j);
                        Grid.SetRow(btn, i + 1);
                        Grid.SetColumn(btn, j + 11);
                    };
                    btn.Click += new RoutedEventHandler(G2_Shoot);
                    this.p1_board.Children.Add(btn);
                }
            }
        }
    }
}
