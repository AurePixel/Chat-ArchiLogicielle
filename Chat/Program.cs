using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            // Serveur
            try
            {
                Console.WriteLine("Serveur Chat");
                TcpListener server = new TcpListener(
                    IPAddress.Parse("0.0.0.0"), 9876
                );
                server.Start();

                while (true)
                {
                    using (TcpClient client = server.AcceptTcpClient())
                    {
                        using (StreamReader reader = new StreamReader(client.GetStream()))
                        {
                             string text = reader.ReadLine();
                             Console.WriteLine(text);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }
}
