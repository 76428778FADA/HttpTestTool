using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HttpTestTool.Utilities
{
    class MessageBoxUtility
    {
        internal static void ShowMessageBox(String message,Boolean isSuccess)
        {
            var left = Application.Current.MainWindow.Left;
            var width = Application.Current.MainWindow.Width;
            var top = Application.Current.MainWindow.Top;
            int delay = isSuccess ? 1000 : 3000;
            var messageWindow = new Pages.MessageWindow(message, !isSuccess, delay)
            {
                WindowStartupLocation = WindowStartupLocation.Manual,
                Left = left + (width - 450 + 250) / 2,
                Top = top+30
            };
            //messageWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            //messageWindow.Owner = Application.Current.MainWindow;
            messageWindow.Show();
        }
    }
}
