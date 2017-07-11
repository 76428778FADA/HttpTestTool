using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HttpTestTool
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {


        private readonly Timer _timer = new Timer(2000);
        public MessageWindow(String message)  
        {  
            InitializeComponent();
            MessageTextBlock.Text = message;
            _timer.Elapsed += timer_Elapsed;  
            _timer.Start();  
        }  
  
        void timer_Elapsed(object sender, ElapsedEventArgs e)  
        {  
            _timer.Stop();  
            Dispatcher.Invoke(DispatcherPriority.Normal, (Action)Hide);  
        }  
    }
}
