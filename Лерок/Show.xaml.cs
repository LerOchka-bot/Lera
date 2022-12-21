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
namespace Лерок
{
    /// <summary>
    /// Логика взаимодействия для Show.xaml
    /// </summary>
    public partial class Show : Window
    {
        private SqlConnection sqlConnection = null;
        public Show()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
            DataTable dt = new DataTable("Base");
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }

        private void update_Click(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["baza"].ConnectionString);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From Base", sqlConnection);
            DataTable dt = new DataTable("Base");
            adapter.Fill(dt);
            dataGrid.ItemsSource = dt.DefaultView;
        }
    }
}
