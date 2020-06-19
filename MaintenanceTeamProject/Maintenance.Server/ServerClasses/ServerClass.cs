using Maintenance.Client.Controllers.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Maintenance.Client.Database;


namespace Maintenance.Server.ServerClasses
{
    class ServerClass
    {
        // адрес для подключения
        public string Address { get; set; }

        // порт для прослушивания подключений
        public int Port { get; set; }

       

        // конструктора

        public ServerClass(): this ("127.0.0.1", 8888) { }

        public ServerClass(string address, int port)
        {
            Address = address;
            Port = port;
        }//ServerClass


        // метод для работы сервера
        public void ServerWork()
        {

            TcpListener server = null;

            try
            {
                // создание слушателя TCP - сервера
                IPAddress localAddr = IPAddress.Parse(Address);
                server = new TcpListener(localAddr, Port);

                // запуск слушателя TCP (запуск сервера)
                server.Start();

                Console.WriteLine("\n\t———TCP Сервер запущен———");
                Console.WriteLine($"\n\tIP {Address} port {Port}");
                Console.WriteLine("\n\tTCP Сервер ожидает запросы...");

                

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    
                        Console.WriteLine("Есть новое подключение");

                        // работа с сетевым текстовым потоком
                        NetworkStream network = client.GetStream();
                        

                    var br = new BinaryReader(network);
                    string request = br.ReadString();
                    
                    // получение команды
                    string req = request.Split('\r')[0];

                    try { 
                    
                            switch (req)
                            {
                                case "@@@daily_request":

                                    // название и размер
                                    
                                    var size1 = br.ReadInt32();
                                    
                                    // сам отчёт
                                    byte[] data = new byte[size1];
                                    int byte1 = br.Read(data, 0, size1);
                                    string requests = Encoding.UTF8.GetString(data, 0, byte1);


                                    //Console.WriteLine($"Сервис: {requests}");
                                    Console.WriteLine("Парсинг прошёл успешно\n");

                                    // пишем ответ сервера Сервису в сетевой поток
                                    byte[] data1 = new byte[1536];
                                    
                                    string responsess = $"Server: Данные успешно получены\n";
                                    data1 = Encoding.UTF8.GetBytes(responsess);
                                    network.Write(data1, 0, data1.Length);
                                    Console.WriteLine("Ответ сервису отправлен\n");

                                    network.Close();

                                break; 
                                        
                                
                                case "@@@stuff_request":
                                    // название и размер
                                    
                                    var sizes = br.ReadInt32();

                                    // сам отчёт
                                    byte[] datas = new byte[1536];
                                    int bytess = network.Read(datas, 0, 1536);
                                    string requestss = Encoding.UTF8.GetString(datas, 0, bytess);



                                    //List<Worker> _stuff = new List<Worker>();
                                    ////Worker st;
                                    //////using (MemoryStream ms = new MemoryStream())
                                    //////_stuff.Add(s => (Worker)new BinaryFormatter().Deserialize(br.BaseStream));
                                    //_stuff = (List<Worker>) new BinaryFormatter().Deserialize(br.BaseStream);


                                    //Console.WriteLine($"Сервис: {requestss}");
                                    Console.WriteLine("Парсинг прошёл успешно\n");


                                    // пишем ответ сервера Сервису в сетевой поток
                                    byte[] dat = new byte[1536];
                                    string responses = $"Server: Данные успешно получены\n";
                                    dat = Encoding.UTF8.GetBytes(responses);
                                    network.Write(dat, 0, dat.Length);
                                    Console.WriteLine("Ответ сервису отправлен\n");

                                    network.Close();
                                //Stuff _stuff;
                                //using (MemoryStream ms = new MemoryStream())
                                //_stuff = (Stuff) new BinaryFormatter().Deserialize(br.BaseStream);

                                break;

                                default:
                                    byte[] datad = new byte[1536];
                                    // пишем ответ сервера Сервису в сетевой поток
                                    string response = $"Server: Ошибка парсинга данных\n";
                                    datad = Encoding.UTF8.GetBytes(response);
                                    network.Write(datad, 0, datad.Length);
                                    Console.WriteLine("Ответ сервису отправлен\n");
                                    network.Close();
                                break;
                            }

                                
                    } // try

                    catch (Exception ex)
                    {
                        // сообщение клиенту
                        byte[] datad = new byte[1536];
                        // пишем ответ сервера Сервису в сетевой поток
                        string response = $"Server: не удалось получить данные\n";
                        datad = Encoding.UTF8.GetBytes(response);
                        network.Write(datad, 0, datad.Length);

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n\n{ex.Message}\n");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        network.Close();

                    } // catch


                    


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



    }//ServerWork

        
    
}
