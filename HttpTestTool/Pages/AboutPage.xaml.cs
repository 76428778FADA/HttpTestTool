using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Input;

namespace HttpTestTool.Pages
{
    /// <summary>
    /// Interaction logic for AboutPage.xaml
    /// </summary>
    public partial class AboutPage : Page
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Help_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Process.Start("https://github.com/abcdevhub/httptesttool#readme");
        }
    }
}
