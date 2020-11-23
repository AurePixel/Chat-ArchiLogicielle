using System;
using System.IO;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static bool reconnexion = true;
        static void Main(string[] args)
        {

            Console.WriteLine("Ton nom !?");
            string name = Console.ReadLine();
            while (true)
            {
                TcpClient client = new TcpClient();
                Console.WriteLine("Ecrie ton texte !");
                try
                {
                    client.Connect("127.0.0.1", 9876);

                    if (client.Connected)
                    {
                        NetworkStream stream = client.GetStream();
                        StreamWriter writer = new StreamWriter(stream);
                        string saisie = Console.ReadLine();
                        writer.WriteLine(name + ": " + saisie);
                        writer.Flush();
                        writer.Dispose();

                        //Console.ReadKey();
                        client.Close();
                    }
                    else
                    {
                        throw new InvalidOperationException("Erreur de connexion au serveur.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    if (!reconnexion) break;
                    Console.ReadKey();
                }
            }
        }
    }
}
