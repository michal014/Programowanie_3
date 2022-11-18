using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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
            if (((Game)p2_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] == 0)
                ((Game)p2_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())]++;
            else if (((Game)p2_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] == 1)
                ((Game)p2_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())]--;
        }
        private void G1_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (((Game)p2_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] == 0 || ((Game)p2_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] == 1)
                ((Game)p2_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] += 2;
        }

        private void CreatButtons()
        {
            GameValueToResourceConverter converter = new GameValueToResourceConverter();
            GameValueToResourceConverter2 converter2 = new GameValueToResourceConverter2();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button button = new Button();
                    {
                        Grid.SetRow(button, i + 1);
                        Grid.SetColumn(button, j);
                    };
                    button.Tag = ((i * 10) + j);
                    Binding binding = new Binding();
                    binding.Converter = converter;
                    binding.Mode = BindingMode.TwoWay;
                    binding.Path = new PropertyPath("Player2[" + ((i * 10) + j) + "]");
                    button.SetBinding(Button.BackgroundProperty, binding);
                    button.Click += new RoutedEventHandler(G2_Shoot);
                    this.p2_board.Children.Add(button);
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button button = new Button();
                    {
                        Grid.SetRow(button, i + 1);
                        Grid.SetColumn(button, j + 11);
                    };
                    button.Tag = ((i * 10) + j);
                    Binding binding = new Binding();
                    binding.Converter = converter2;
                    binding.Mode = BindingMode.TwoWay;
                    binding.Path = new PropertyPath("Player1[" + ((i * 10) + j) + "]");
                    button.SetBinding(Button.BackgroundProperty, binding);
                    button.Click += new RoutedEventHandler(G1_Shoot);
                    this.p2_board.Children.Add(button);
                }
            }
        }



    }
}
