using System;
using System.Text;
using System.Windows;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Net;


namespace SMessenger
{
    public class Network
    {
        private static int port = 8005;
        private static string address = "192.168.1.79";
        static public Socket socket;

        private async void XXX()
        {
            await Task.Run(() => Gett());
        }

        private void click_Click(object sender, RoutedEventArgs e)
        {
            //byte[] dat = Encoding.Unicode.GetBytes("(" + DateTime.Now.ToShortTimeString() + ") " + name.Text + ": " + t1.Text);
           // socket.Send(dat);
        }

        public void Gett()
        {
            while (true)
            {
                byte[] data = new byte[256];
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);

                MainWindow.main.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (ThreadStart)delegate
                {
                    //this.text1.Text += builder.ToString() + Environment.NewLine;
                });
            }
        }

        static void Start()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //private void Window_Closing(object sender, CancelEventArgs e)
        //{
        //    //socket.Shutdown(SocketShutdown.Both);
        //    //socket.Close();
        //}

        //private void t1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter)
        //    {
        //        click_Click(sender, e);
        //    }
        //}

        //private void name_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (name.Text != "" && name.Text != null)
        //        t1.IsEnabled = click.IsEnabled = true;
        //    else
        //        t1.IsEnabled = click.IsEnabled = false;
        //}
    }
}