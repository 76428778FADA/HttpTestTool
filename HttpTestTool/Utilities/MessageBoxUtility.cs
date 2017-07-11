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
        internal static void ShowMessageBox(String message)
        {
            var left = Application.Current.MainWindow.Left;
            var width = Application.Current.MainWindow.Width;
            var top = Application.Current.MainWindow.Top;
            var messageWindow = new MessageWindow(message)
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
