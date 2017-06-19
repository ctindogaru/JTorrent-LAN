using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;

namespace Client
{
    public class DbProvider
    {
        TcpClient tcpclnt;
        public string currentUser;

        public DbProvider(TcpClient tcpclnt)
        {
            this.tcpclnt = tcpclnt;
            this.currentUser = "";
        }

        public string sendAndGetMessage(string message)
        {
            NetworkStream stream = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();
            
            byte[] encodedCommand = asen.GetBytes(message);
            stream.Write(encodedCommand, 0, encodedCommand.Length);

            byte[] encodedResponse = new byte[1024];
            stream.Read(encodedResponse, 0, 1024);
            string response = Encoding.ASCII.GetString(encodedResponse);

            return response.TrimEnd();
        }

        public void sendMessage(string message)
        {
            NetworkStream stream = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();

            byte[] encodedCommand = asen.GetBytes(message);
            stream.Write(encodedCommand, 0, encodedCommand.Length);
        }

        public byte[] getBytesFromStream(int nb)
        {
            NetworkStream stream = tcpclnt.GetStream();
            ASCIIEncoding asen = new ASCIIEncoding();

            byte[] encodedResponse = new byte[nb];
            int nbytes_read = stream.Read(encodedResponse, 0, nb);
            
            return encodedResponse;
        }
    }
}
