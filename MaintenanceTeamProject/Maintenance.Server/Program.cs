using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Server
{
    class Program
    {
       // порт для прослушивания подключений
        private static int port = 8888;

        static void Main(string[] args)
        {


            TcpListener server = null;
            Console.Title = "TCP";
            
            try
            {
                // создание слушателя TCP - сервера
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);

                // запуск слушателя TCP - т.е. запуск сервера
                server.Start();
                while (true)
                {
                    Console.WriteLine("\n\t\tTCP Сервер запущен");
                    Console.WriteLine("\n\tIP 127.0.0.1 port 8888");
                    Console.WriteLine("\n\tTCP Сервер ожидает запросы...");

                    // блокирующий вызов, до соединения с клиентом
                    using (TcpClient client = server.AcceptTcpClient())
                    {
                        Console.WriteLine("Есть новое подключение");

                        // получить сетевой поток, читаем запрос клиента
                        NetworkStream network = client.GetStream();
                        byte[] data = new byte[1536];
                        int bytes = network.Read(data, 0, 1536);
                        string request = Encoding.UTF8.GetString(data, 0, bytes);
                        Console.WriteLine($"Клиент: {request}");

                        if (request == "download")
                            Upload(network);
                        else
                        {
                            // пишем ответ сервера Клиенту в сетевой поток
                            string response = $"Привет, Клиент. Ты прислал \"{request}\"";
                            data = Encoding.UTF8.GetBytes(response);
                            network.Write(data, 0, data.Length);
                        }

                        Console.WriteLine("Ответ клиенту отправлен");
                        network.Close();
                    } // using -- вызов Close() для клиента  
                } // while
            } // try

            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n\n{ex.Message}\n");
                Console.ForegroundColor = ConsoleColor.Gray;
            } // catch

            finally
            {
                server?.Stop();
            } // finally
        }

        private static void Upload(NetworkStream network)
        {
            using (BinaryReader brd = new BinaryReader(File.OpenRead("file.dat")))
            {

                var data = new byte[1536];
                while (true)
                {
                    // чтение очередной порции данных
                    int bytes = brd.Read(data, 0, data.Length);

                    // если данных нет - все прочитано, выход
                    if (bytes == 0) break;

                    // запись в сетевой поток
                    network.Write(data, 0, bytes);
                } // while

            } // using BinaryWriter
        } // Upload
    }
}
