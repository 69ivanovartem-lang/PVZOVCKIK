using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Windows;
using System.Windows.Controls;

namespace PVZOV
{
    public partial class MainWindow : Window
    {
        private static readonly HttpClient client = new HttpClient();

        public MainWindow()
        {
            InitializeComponent();
            LoadDataFromServer();
        }

        private async void LoadDataFromServer()
        {
            try
            {
                string url = "http://127.0.0.1:8000/orders";
                var orders = await client.GetFromJsonAsync<List<Order>>(url);

                if (orders != null)
                {
                    OrdersDataGrid.ItemsSource = orders;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка подключения к серверу: {ex.Message}", "Внимание");
            }
        }

        // Новая логика: кнопка "Обновить"
        private void RefreshBtn_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем данные из базы
            LoadDataFromServer();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Место для будущей фильтрации
        }
    }

    public class Order
    {
        public string pzv_number { get; set; }
        public string order_number { get; set; }
        public string client_name { get; set; }
        public string phone_number { get; set; }
        public string status { get; set; }
    }
}