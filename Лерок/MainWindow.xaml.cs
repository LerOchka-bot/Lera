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

namespace Лерок
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void insert_Click(object sender, RoutedEventArgs e)
        {
            Insert window = new Insert();
            window.Show();
        }

        private void show_Click(object sender, RoutedEventArgs e)
        {
            Show window = new Show();
            window.Show();
        }

        private void payment_Click(object sender, RoutedEventArgs e)
        {
            Payment window = new Payment();
            window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();

            window.Show();
        }
    }
}
