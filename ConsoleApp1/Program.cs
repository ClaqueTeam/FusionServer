using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string localhost = "127.0.0.1";
            int port1 = 8000;
            int port2 = 8001;

            Client c1 = new Client(port1);
            Client c2 = new Client(port2);

            c1.connect(localhost, port2);
            c2.connect(localhost, port1);

            c1.send("client 1 message...");
            c2.send("client 2 message...");

            Console.WriteLine("client 1 received: " + c1.receive());
            Console.WriteLine("client 2 received: " + c2.receive());

            while (true) ;
        }
    }
}
