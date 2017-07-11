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
using HttpTestTool.Controllers;
using HttpTestTool.Utilities;

namespace HttpTestTool
{
    /// <summary>
    /// Interaction logic for HttpClientPage.xaml
    /// </summary>
    public partial class HttpClientPage : Page
    {
        public HttpClientPage()
        {
            InitializeComponent();
        }

        private async void SendButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(RequestUrlTextBox.Text))
                {
                    MessageBoxUtility.ShowMessageBox("Empty Request URL", false);
                    return;
                }
                SendButton.Content = "Sending..";
                SendButton.IsEnabled = false;
                ResponseTextBox.Text = await SendDataAsync();
                MessageBoxUtility.ShowMessageBox("Successed!", true);
                SendButton.Content = "Send";
                SendButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                //MessageBoxUtility.ShowMessageBox(ex.Message, false);
                ResponseTextBox.Text = "Exception caused:\r\n" + ex.Message;
            }
        }

        private async Task<String> SendDataAsync()
        {
            var url = RequestUrlTextBox.Text.StartsWith("http") ? RequestUrlTextBox.Text : "http://" + RequestUrlTextBox.Text;
            var content = RequestTextBox.Text;
            var contentType = TypeComboBox.Text;
            var method = MethodComboBox.Text;
            if (method.ToLower() == "post")
            {
                return await Task.Run(() =>
                {
                    var httpClient = new HttpClientController(20000, contentType, contentType);
                    var result = httpClient.PostData(url, content);
                    return result;
                });
            }
            SendButton.IsEnabled = true;
            return "UnSupport Method";
        }
    }
}
