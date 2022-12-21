using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
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
using System.Text.RegularExpressions;


namespace Лерок
{
    /// <summary>
    /// Логика взаимодействия для Insert.xaml
    /// </summary>
    public partial class Insert : Window
    {
        private SqlConnection sqlConnection = null;

        public Insert()
        {
            InitializeComponent();
            txtNumber.MaxLength = 8;
        }

        private void txt_Bid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (txtBid.SelectedIndex == 0)
            {
                txtSumma.Text = "500";
            }
            if (txtBid.SelectedIndex == 1)
            {
                txtSumma.Text = "1000";
            }
            if (txtBid.SelectedIndex == 2)
            {
                txtSumma.Text = "2000";
            }
            if (txtBid.SelectedIndex == 3)
            {
                txtSumma.Text = "5000";
            }
            if (txtBid.SelectedIndex == 4)
            {
                txtSumma.Text = "5000";
            }
            if (txtBid.SelectedIndex == 5)
            {
                txtSumma.Text = "1500";
            }
            if (txtBid.SelectedIndex == 6)
            {
                txtSumma.Text = "5000";
            }
            if (txtBid.SelectedIndex == 7)
            {
                txtSumma.Text = "15000";
            }
            if (txtBid.SelectedIndex == 8)
            {
                txtSumma.Text = "30000";
            }
        }


        private void Insert_Click(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex("^[a-zA-Zа-яА-Я ]+$");
            if (!regex.IsMatch(txtFio.Text) || regex.IsMatch(txtDate.Text) || regex.IsMatch(txtSumma.Text))
            {

                MessageBox.Show("Введите корректные данные");
            }
            else
            {
                if (((string.IsNullOrEmpty(txtFio.Text))) || ((string.IsNullOrEmpty(txtDate.Text))) || ((string.IsNullOrEmpty(txtNumber.Text))) || ((string.IsNullOrEmpty(txtBid.Text))) || ((string.IsNullOrEmpty(txtSumma.Text)))) MessageBox.Show("Данные не введены");
                else
                {
                    sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                    sqlConnection.Open();
                    SqlCommand command = new SqlCommand($"Insert into [Base]([FIO], [Date],[Number], [Bid],[Summa]) Values (@FIO, @Date,@Number, @Bid, @Summa)", sqlConnection);
                    command.Parameters.AddWithValue("FIO", txtFio.Text);
                    command.Parameters.AddWithValue("Date", txtDate.Text);
                    command.Parameters.AddWithValue("Number", txtNumber.Text);
                    command.Parameters.AddWithValue("Bid", txtBid.Text);
                    command.Parameters.AddWithValue("Summa", txtSumma.Text);
                    int a = command.ExecuteNonQuery();
                    if (a > 0)
                    {
                        MessageBox.Show("Данные записаны");
                    }
                    txtFio.Clear(); txtDate.Text = null; ; txtNumber.Clear(); txtBid.Items.Clear(); txtSumma.Clear();
                    Close();
                }
            }
        }

        private void txtFio_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[а-яА-Я ]+$");
            if (!regex.IsMatch(e.Text))
            {

                txtFio.BorderBrush = Brushes.Red;
            }
        }
        private void txtSumma_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[0-9 ]+$");
            if (!regex.IsMatch(e.Text))
            {
                txtSumma.BorderBrush = Brushes.Red;
            }
        }

    }
}
