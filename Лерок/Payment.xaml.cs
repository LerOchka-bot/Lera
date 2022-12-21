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
    /// Логика взаимодействия для Payment.xaml
    /// </summary>
    public partial class Payment : Window
    {
        private SqlConnection sqlConnection = null;
        public Payment()
        {
            InitializeComponent();
        }

        private void Poisk_FIO_Click(object sender, RoutedEventArgs e)
        {
            txtFio.Visibility = Visibility.Visible;
            Poisk.Visibility = Visibility.Visible;
        }
        private void Poisk_Number_Click(object sender, RoutedEventArgs e)
        {
            txtNumber.Visibility = Visibility.Visible;
            Poisk.Visibility = Visibility.Visible;
        }

        private void Poisk_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.Visibility = Visibility.Visible;
            if (txtFio.Text.Equals(""))
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"Select * From Base where Number= N'" + txtNumber.Text + "'", sqlConnection);
                DataTable dt = new DataTable("Base");
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }
            if (txtNumber.Text.Equals(""))
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                sqlConnection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter($"Select * From Base  where [FIO]= N'" + txtFio.Text + "'", sqlConnection);
                DataTable dt = new DataTable("Base");
                adapter.Fill(dt);
                dataGrid.ItemsSource = dt.DefaultView;
            }
            Poisk.Visibility = Visibility.Hidden;
            Vibor.Visibility = Visibility.Visible;
        }
        private void Vibor_Click(object sender, RoutedEventArgs e)
        {
            l1.Visibility = Visibility.Visible;
            Vibor.Visibility = Visibility.Hidden;
            Pay.Visibility = Visibility.Visible;
            txtSumma.Text = ((DataRowView)dataGrid.SelectedItem).Row[5].ToString();
            txtSumma.Visibility = Visibility.Visible;
        }

        private void Pay_Click(object sender, RoutedEventArgs e)
        {
            
            
            if (txtFio.Text.Equals(""))
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM  [Base] where [Id]= N'"+((DataRowView)dataGrid.SelectedItem).Row[0].ToString() + "'", sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Штраф оплачен");
            }
            else
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
                sqlConnection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM  [Base] where [Id]= N'" + ((DataRowView)dataGrid.SelectedItem).Row[0].ToString() + "'", sqlConnection);
                command.ExecuteNonQuery();
                sqlConnection.Close();
                MessageBox.Show("Штраф оплачен");
            }
            Close();
            

        }

        
    }
}
