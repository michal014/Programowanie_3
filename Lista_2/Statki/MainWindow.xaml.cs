using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        

        public MainWindow()
        {
            InitializeComponent();
            CreatButtons();
            int[] border1 = new int[100];
            int[] border2 = new int[100];
            Game gra = new Game(border1,border2);
            GameValueToResourceConverter gameValueToResourceConverter = new GameValueToResourceConverter();
            GameValueToResourceConverter2 gameValueToResourceConverter2 = new GameValueToResourceConverter2();
            p1_board.DataContext = gra;
            Player2 window = new Player2();
            window.DataContext = gra;
            window.Show();
        }

        private void G1_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (((Game)p1_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] == 0)
                ((Game)p1_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())]++;
            else if (((Game)p1_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())] == 1)
                ((Game)p1_board.DataContext).Player1[Convert.ToInt32(button.Tag.ToString())]--;
        }

        private void G2_Shoot(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (((Game)p1_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] == 0 || ((Game)p1_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] == 1)
                ((Game)p1_board.DataContext).Player2[Convert.ToInt32(button.Tag.ToString())] += 2;
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
                    binding.Path = new PropertyPath("Player1[" + ((i * 10) + j) + "]");
                    button.SetBinding(Button.BackgroundProperty, binding);
                    button.Click += new RoutedEventHandler(G1_Shoot);
                    this.p1_board.Children.Add(button);
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
                    binding.Path = new PropertyPath("Player2[" + ((i * 10) + j) + "]");
                    button.SetBinding(Button.BackgroundProperty, binding);
                    button.Click += new RoutedEventHandler(G2_Shoot);
                    this.p1_board.Children.Add(button);
                }
            }
        }
    }

    

}
