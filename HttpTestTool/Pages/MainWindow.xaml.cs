using System;
using System.Windows;
using System.Windows.Input;

namespace HttpTestTool.Pages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AboutLink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/AboutPage.xaml", UriKind.Relative));
        }

        private void ClientLink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/HttpCLientPage.xaml", UriKind.Relative));
        }

        private void ServerLink_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MainFrame.Navigate(new Uri("Pages/HttpServerPage.xaml", UriKind.Relative));
        }

        private void MetroWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
            //Environment.Exit(0);
        }
    }

}
