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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using WpfApp2.Model;
using Newtonsoft.Json;
using WpfApp2.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void authButton_Click(object sender, RoutedEventArgs e)
        {
            var client =new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000");
            string data = JsonConvert.SerializeObject(new { login = loginTextBox.Text, password = passwordTextBox.Text});
            var parameters = new Dictionary<string, string>
            {
                { "login", loginTextBox.Text },
                { "password", passwordTextBox.Text }
            };
            // Кодирование параметров в строку запроса
            var content = new FormUrlEncodedContent(parameters);
           // StringContent content = new StringContent(data, Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = await client.PostAsync("/auth", content);
            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                ApiResponse? apiResponse=JsonConvert.DeserializeObject<ApiResponse>(responseContent);
                if (apiResponse.stuff != null)
                {
                    registrationWindow registrationWindow=new registrationWindow();
                    registrationWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Не верный логин или пароль");
                }
            }
            else
            {
                MessageBox.Show("Erorr");
            }
        }
       private class ApiResponse
        {
            public required int response { get; set; }
            public required String message { get; set; }
            public Stuff? stuff { get; set; }
        }
    }
}
