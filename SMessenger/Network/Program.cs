using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Network
{
    class Program
    {
        private static readonly int port = 8005;
        private static List<Socket> Sockets;

        static void Main(string[] args)
        {
            Sockets = new List<Socket>();
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listenSocket.Bind(ipPoint);
                listenSocket.Listen(10);
                Console.WriteLine("Start server...");
                while (true)
                {
                    Socket handler = listenSocket.Accept();
                    Sockets.Add(handler);
                    DDD(handler);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static async void DDD(Socket t)
        {
            await Task.Run(() => Gett(t));
        }

        private static void Per(string message)
        {
            try
            {
                for (int i = 0; i < Sockets.Count; ++i)
                {
                    try
                    {
                        byte[] dat = new byte[256];
                        dat = Encoding.Unicode.GetBytes(message);
                        Sockets[i].Send(dat);
                    }
                    catch (Exception ex)
                    {
                        Sockets.RemoveAt(i--);
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Gett(Socket t)
        {
            while (true)
            {
                try
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];
                    do
                    {
                        bytes = t.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (t.Available > 0);
                    //Console.WriteLine(builder.ToString());
                    Per(builder.ToString());

                }
                catch (Exception ex)
                {
                    Sockets.Remove(t);
                    Console.WriteLine(Sockets.Count);
                    Console.WriteLine(ex.Message);
                    break;
                }
            }

        }
    }
}