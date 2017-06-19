using JTorrent;
using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class ServerListener
    {
        // Declare and initialize the IP address
        //static IPAddress ipAd = Dns.Resolve(Dns.GetHostName()).AddressList[0];
        static IPAddress ipAd = IPAddress.Any;

        // Declare and initialize the port number;
        static int portNumber = 8888;

        static int MAX_CLIENTS = 10;

        /* Initializes the Listener */
        TcpListener tcpListener = new TcpListener(ipAd, portNumber);

        Action<string> DelegateTeste_ModifyText;

        public ServerListener()
        {
            Thread ThreadingServer = new Thread(StartServer);
            ThreadingServer.Start();
        }

        private void THREAD_MOD(string teste)
        {
            Console.WriteLine(teste);
        }

        private string getRelevantData(string command)
        {
            string separators = "\r\n ";
            string[] words = command.Split(separators.ToCharArray());
            string dataToFind = "";

            for (int i = 1; i < words.Length; ++i)
                dataToFind += words[i] + " ";

            return dataToFind.TrimEnd();
        }

        private void StartServer()
        {
            DbManager.Update(); 
            tcpListener.Start();
            DelegateTeste_ModifyText = THREAD_MOD;

            DelegateTeste_ModifyText.Invoke("Server waiting connections!");

            for (int i = 0; i < MAX_CLIENTS; i++)
            {
                Thread newThread = new Thread(new ThreadStart(Listeners));
                newThread.Start();
            }
        }

        private void Listeners()
        {
            TcpClient clientSocket = default(TcpClient);
            clientSocket = tcpListener.AcceptTcpClient();
            DelegateTeste_ModifyText.Invoke("Client:" + clientSocket.Client.RemoteEndPoint + " now connected to server.");

            while (true)
            {
                try
                {
                    NetworkStream stream = clientSocket.GetStream();
                    byte[] encodedCommand = new byte[1024];
                    stream.Read(encodedCommand, 0, 1024);
                    string command = System.Text.Encoding.ASCII.GetString(encodedCommand);
                    command = command.Substring(0, command.IndexOf("$"));
                    DelegateTeste_ModifyText.Invoke(command);

                    string response = "";
                    string data = "";

                    if (command.Contains("search"))
                    {
                        data = getRelevantData(command);
                        ArrayList result = DbManager.filterFilesFromDb(data);

                        if (result == null || result.Count == 0)
                            response = "File doesn't exist...\r\n";
                        else
                            response = string.Join("\r\n", result.ToArray());
                    }
                    else if (command.Contains("download"))
                    {
                        string separators = "\r\n ";
                        string[] words = command.Split(separators.ToCharArray());
                        string path = words[2];

                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                        BinaryReader r = new BinaryReader(fs);
                                                
                        while (r.BaseStream.Position != r.BaseStream.Length)
                        {
                            byte[] array = r.ReadBytes(1024);

                            stream.Write(array, 0, array.Length);
                            stream.Flush();
                        }

                        continue;
                    }
                    else if (command.Contains("login"))
                    {
                        string separators = "\r\n ";
                        string[] words = command.Split(separators.ToCharArray());
                        string username = words[1];
                        string password = words[2];
                        response = "NOT_OK\r\n";

                        foreach (DbUser user in DbManager.users)
                        {
                            if (user.UserName == username && user.Password == password)
                            {
                                response = "OK\r\n";
                                break;
                            }
                        }
                    }
                    else if (command.Contains("register"))
                    {
                        string separators = "\r\n ";
                        string[] words = command.Split(separators.ToCharArray());
                        string username = words[1];
                        string password = words[2];
                        response = "OK\r\n";

                        foreach (DbUser user in DbManager.users)
                        {
                            if (user.UserName == username)
                            {
                                response = "NOT_OK\r\n";
                                break;
                            }
                        }
                        if (response == "OK\r\n")
                        {
                            DbManager.createUser(username, password);
                        }
                        DbManager.Update();
                    }
                    else if (command.Contains("upload"))
                    {
                        string separators = "\r\n ";
                        string[] words = command.Split(separators.ToCharArray());
                        string filename = words[1];
                        long size = Convert.ToInt64(words[2]);
                        string username = words[3];
                        response = "OK\r\n";
                        foreach (DbFile file in DbManager.files)
                        {
                            if (file.Filename == filename && file.Username == username)
                            {
                                response = "NOT_OK\r\n";
                                break;
                            }
                        }
                        if (response == "OK\r\n")
                        {
                            DbManager.uploadFile(filename, size, username);
                        }
                        DbManager.Update();
                    }

                    Byte[] encodedResponse = Encoding.ASCII.GetBytes(response);
                    stream.Write(encodedResponse, 0, encodedResponse.Length);
                    stream.Flush();
                }
                catch
                {
                    tcpListener.Stop();
                    tcpListener.Start();
                    DelegateTeste_ModifyText.Invoke("Server waiting connections!");
                    clientSocket = tcpListener.AcceptTcpClient();
                    DelegateTeste_ModifyText.Invoke("Server ready!");
                }
            }
        }
    }
}

