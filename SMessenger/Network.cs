using System;
using System.Text;
using System.Windows;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Net;


namespace SMessenger
{
    public class Network
    {
        private static readonly int port = 8005;
        private static readonly string address = "10.7.180.113";
        static public Socket socket;

        public static void Start_Network()
        {
            Start();
            XXX();
        }

        private static async void XXX()
        {
            await Task.Run(() => Gett());
        }

        public static void Send()
        {
            byte[] dat = Encoding.Unicode.GetBytes(MainWindow.main.Tx_mess.Text);
            socket.Send(dat);
        }

        private static void Gett()
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
                    MainWindow.main.Create_Messege(builder.ToString());
                });
            }
        }

        private static void Start()
        {
            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}