using Microsoft.Data.SqlClient;
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

namespace Stationery_company2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Data Source=MIPC\SQLEXPRESS01;Initial Catalog=Stationery_company;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
        string connectionString = @"Data Source=MIPC\SQLEXPRESS01;Initial Catalog=Stationery_company;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        SqlConnection connection;
        StationeryViewModel stationeryViewModel;

        public MainWindow()
        {
            connection = new SqlConnection(connectionString);
            stationeryViewModel = new StationeryViewModel();
            InitializeComponent();
        }

        private async void HomeLoad(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.OpenAsync();
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    MessageBox.Show("Connection is open", "Connection", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Connection is closed", "Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SqlException: {ex.Message}", "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"System Exception: {ex.Message}", "System Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void CloseConnection_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await connection.CloseAsync();
                if (connection.State == System.Data.ConnectionState.Closed)
                {
                    MessageBox.Show("Connection is closed", "Connection", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SqlException: {ex.Message}", "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"System Exception: {ex.Message}", "System Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TakeInfo_Click(object sender, RoutedEventArgs e)
        {
            string content = "";
            content += "Connection string: " + connection.ConnectionString + "\n";
            content += "Database: " + connection.Database + "\n";
            content += "DataSource: " + connection.DataSource + "\n";
            content += "ServerVersion: " + connection.ServerVersion + "\n";
            content += "State: " + connection.State + "\n";
            content += "WorkstationId: " + connection.WorkstationId + "\n";
            try
            {
                MessageBox.Show(content, "Connection Informayion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SqlException: {ex.Message}", "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"System Exception: {ex.Message}", "System Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void Run_Click(object sender, RoutedEventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = QueryText.Text;
            sqlCommand.Connection = connection;
            try
            {
                SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();
                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        int id = Convert.ToInt32(sqlDataReader.GetValue(0));
                        string name = sqlDataReader.GetValue(1).ToString();
                        string type = sqlDataReader.GetValue(2).ToString();
                        int count = Convert.ToInt32(sqlDataReader.GetValue(3));
                        string selers_menager = sqlDataReader.GetValue(4).ToString();
                        int cost = Convert.ToInt32(sqlDataReader.GetValue(5));
                        string name_buyers_company = sqlDataReader.GetValue(6).ToString();
                        string menager_made_the_sale = sqlDataReader.GetValue(7).ToString();
                        int number_sold = Convert.ToInt32(sqlDataReader.GetValue(8));
                        decimal price = Convert.ToDecimal(sqlDataReader.GetValue(9));
                        string date = sqlDataReader.GetValue(10).ToString();
                        stationeryViewModel.AddStationery(new Stationery(id, name,type, count, selers_menager, cost, name_buyers_company, menager_made_the_sale, number_sold, price, date));

                    }
                    DataTable.ItemsSource = stationeryViewModel.Stationery;
                }
                else
                {
                    MessageBox.Show("No rows", "Data", MessageBoxButton.OK, MessageBoxImage.Information);
                }


            }
            catch (SqlException ex)
            {
                MessageBox.Show($"SqlException: {ex.Message}", "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"System Exception: {ex.Message}", "System Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
