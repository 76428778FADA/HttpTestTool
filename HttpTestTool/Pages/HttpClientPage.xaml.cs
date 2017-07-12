using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using HttpTestTool.Controllers;
using HttpTestTool.Utilities;

namespace HttpTestTool.Pages
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
            }
            catch (Exception ex)
            {
                MessageBoxUtility.ShowMessageBox("Failed!", false);
                //MessageBoxUtility.ShowMessageBox(ex.Message, false);
                ResponseTextBox.Text = "Exception caused:\r\n" + ex.Message;
            }
            SendButton.Content = "Send";
            SendButton.IsEnabled = true;
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
