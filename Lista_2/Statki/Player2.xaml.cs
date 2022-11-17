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
using System.Windows.Shapes;

namespace Statki
{
    /// <summary>
    /// Interaction logic for Player2.xaml
    /// </summary>
    public partial class Player2 : Window
    {
        public Player2()
        {
            InitializeComponent();
            CreatButtons();
        }

        private void G2_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            MainWindow.player2[Convert.ToInt16(button.Tag)] += 1;
        }
        private void G1_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            MainWindow.player1[Convert.ToInt16(button.Tag)] += 2;
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
                    btn.Click += new RoutedEventHandler(G2_Shoot);
                    this.p2_board.Children.Add(btn);
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
                    btn.Click += new RoutedEventHandler(G1_Shoot);
                    this.p2_board.Children.Add(btn);
                }
            }
        }

    }
}
