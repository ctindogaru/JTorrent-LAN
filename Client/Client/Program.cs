using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Client
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            TcpClient tcpclnt = new TcpClient();

            // Declare and initialize the IP address
           // IPAddress ipAd = Dns.Resolve(Dns.GetHostName()).AddressList[0]
            IPAddress ipAd = IPAddress.Parse("192.168.1.48");

            // Declare and initialize the port number;
            int portNumber = 8888;

            DbProvider dbProvider = new DbProvider(tcpclnt);

            Console.WriteLine("Connecting...");
            try
            {
                tcpclnt.Connect(ipAd, portNumber);
                Console.WriteLine("Connected");
            }
            catch
            {
                Console.WriteLine("Couldn't connect");
            }

            Application.EnableVisualStyles();
            Application.Run(new frmLogin(dbProvider));
        }
    }
}
