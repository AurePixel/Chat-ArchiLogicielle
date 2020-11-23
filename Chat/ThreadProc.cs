using System.Net.Sockets;

namespace Chat
{
    internal class ThreadProc
    {
        private TcpListener server;

        public ThreadProc(TcpListener server)
        {
            this.server = server;
        }
    }
}