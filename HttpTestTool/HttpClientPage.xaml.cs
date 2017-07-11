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

        private void PostButton_Click(object sender, RoutedEventArgs e)
        {
            var messageWindow = new MessageWindow("Empty Request URL");
            messageWindow.Show();
        }
    }
}
