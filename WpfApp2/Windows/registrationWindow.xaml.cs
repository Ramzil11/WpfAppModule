using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using WpfApp2.Model;

namespace WpfApp2.Windows
{
    /// <summary>
    /// Логика взаимодействия для registrationWindow.xaml
    /// </summary>
    public partial class registrationWindow : Window
    {
        public registrationWindow()
        {
            InitializeComponent();
        }

        private async Task Window_InitializedAsync(object sender, EventArgs e)
        {
            
        }
        private class ApiResponse
        {
            public required int response { get; set; }
            public required String message { get; set; }
            public List<Client>? clients { get; set; }
        }

        private async Task Window_Initialized(object sender, EventArgs e)
        {
            
        }

        private async void Grid_Initialized(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000");

            var response = await client.GetAsync("/clients/get");
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ApiResponse? apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                if (apiResponse.clients != null)
                {
                    listViewClients.ItemsSource = apiResponse.clients;
                }
            }
            else
            {
                MessageBox.Show("Erorr");
            }
        }
    }
}
