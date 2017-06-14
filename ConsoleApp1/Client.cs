using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ConsoleApp1
{
    class Client
    {
        private IPEndPoint PersonalEndPoint;
        private IPEndPoint RemoteEndPoint;
        private UdpClient connection;

        public Client(int port)
        {
            this.PersonalEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            this.connection = new UdpClient(this.PersonalEndPoint);
        }

        public void connect(string ip, int port)
        {
            this.RemoteEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            this.connection.Connect(this.RemoteEndPoint);
        }

        public void send(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);
            this.connection.Send(data, data.Length);
        }

        public string receive()
        {
            return Encoding.UTF8.GetString(this.connection.Receive(ref this.RemoteEndPoint));
        }
    }
}
