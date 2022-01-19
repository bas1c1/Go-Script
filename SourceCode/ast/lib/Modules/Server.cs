using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OwnLang.ast.lib
{
    class ServerClass
    {

        private int LocalPort;
        private Thread ServThread; // экземпляр потока
        TcpListener Listener; // листенер
        private string message_from_client;
        public bool stop;

        public void Create(int port)
        {
            LocalPort = port;
            ServThread = new Thread(new ThreadStart(ServStart));
            ServThread.Start(); // запустили поток. Стартовая функция – 
                                // ServStart, как видно выше
        }

        public void Close() // Закрыть серв?
        {
            Listener.Stop();
            ServThread.Abort();
            return;
        }

        private void ServStart()
        {
            Socket ClientSock; // сокет для обмена данными.
            string data;
            byte[] cldata = new byte[1024]; // буфер данных
            Listener = new TcpListener(LocalPort);
            Listener.Start(); // начали слушать
            Console.WriteLine("Waiting connections [" + Convert.ToString(LocalPort) + "]...");
            try
            {
                ClientSock = Listener.AcceptSocket(); // пробуем принять 
                                                      // клиента
            }
            catch
            {
                ServThread.Abort(); // нет – жаль(
                return;
            }
            int i = 0;

            if (ClientSock.Connected)
            {
                while (true)
                {
                    try
                    {
                        i = ClientSock.Receive(cldata); // попытка чтения 
                                                        // данных
                    }
                    catch { }
                    try
                    {
                        if (i > 0)
                        {

                            data = Encoding.ASCII.GetString(cldata).Trim();
                            Console.WriteLine(data);
                            message_from_client = data;
                            if (stop) // если CLOSE – 
                                      // вырубимся
                            {
                                ClientSock.Send(Encoding.ASCII.GetBytes("Closing the server..."));
                                ClientSock.Close();
                                Listener.Stop();
                                Console.WriteLine("Server closed. Reason: client wish! Type EXIT to quit the application.");
                                ServThread.Abort();
                                return;
                            }
                        }
                    }
                    catch
                    {
                        ClientSock.Close(); // ну эт если какая хрень..
                        Listener.Stop();
                        Console.WriteLine("Server closing. Reason: client offline. Type EXIT to quit the application.");
                        ServThread.Abort();
                    }
                }
            }
        }
        public string getRcvdMessage()
        {
            return message_from_client;
        }
    }



    public partial class ClientForm
    {
        //private string tcp_adr;
        private int port_number;
        //ServerClass Serv = new ServerClass();
        //bool stop;

        public ClientForm()
        {

        }
        public static void StartServer(int port)
        {
            int port_number = System.Convert.ToInt32(port);
            ServerClass Serv = new ServerClass();
            Serv.Create(port_number);
            Console.WriteLine(Serv.getRcvdMessage());
        }

        private void StopServer_Click(object sender, EventArgs e)
        {
            // Serv.stop = !Serv.stop;
        }
    }
}
