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

namespace Fuel_Pump_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainWindowViewModel viewModel = new MainWindowViewModel();
            this.DataContext = viewModel;
        }

        /*
        private void Keypad_Press(object sender, RoutedEventArgs e)
        {
            var keypad_button = sender as Button;
            switch(keypad_button.Content.ToString())
            {
                case "0":
                    break;

                case "1":
                    break;

                case "2":
                    break;

                case "3":
                    break;

                case "4":
                    break;

                case "5":
                    break;

                case "6":
                    break;

                case "7":
                    break;

                case "8":
                    break;

                case "9":
                    break;

                case "Clear":
                    break;

                case "Enter":
                    if (MainDisplay.Children[0].GetType() == typeof(UC1_Welcome))
                    {
                        UC2_Rewards rewards = new UC2_Rewards();
                        MainDisplay.Children.Clear();
                        MainDisplay.Children.Add(rewards);
                    }
                    break;

                default:
                    break;
            }
        }
        */
    }
}
