﻿using System;
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
            IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse("10.7.180.105"), port);
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
                    byte[] dat = new byte[256];
                    dat = Encoding.Unicode.GetBytes(message);
                    Sockets[i].Send(dat);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Gett(Socket t)
        {
            try
            {
                while (true)
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
                    Console.WriteLine(DateTime.Now.ToShortTimeString() + ": " + builder.ToString());
                    Per(builder.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}