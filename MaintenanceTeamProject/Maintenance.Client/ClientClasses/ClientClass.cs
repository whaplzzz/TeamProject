using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Maintenance.Client.Library
{
    public class ClientClass {
        // даннные подключения к серверу TCP
        // порт для подключения
        public int Port { get; set; }
        // адрес для подключения
        public string Address { get; set; }

        // констркутор базовый
        public ClientClass() : this("127.0.0.1", 8888) { }
        // констркутор с параметрами
        public ClientClass(string address, int port) {
            Address = address;
            Port = port;
        } // ClientClass

        /// <summary>
        /// Функция для отправки сообщения серверу
        /// </summary>
        /// <param name="message">сообщение которое отправляется на сервер</param>
        /// <returns>возвращается ответ от сервера</returns>
        public string SendMessage(string message) {
            string response;
            try {
                response = ClientTcp(message);
            } // try
            catch (SocketException ex) {
                response = $"SocketException: {ex.Message}";
            } // catch SocketException
            catch (Exception ex) {
                response = $"Exception: {ex.Message}";
            } // catch Exception

            return response;
        } // SendMessage

        /// <summary>
        /// работа с сервером
        /// </summary>
        /// <param name="request">запрос для передачи его серверу</param>
        /// <returns>ответ сервера</returns>
        private string ClientTcp(string request) {
            // ответ сервера
            string response;

            // соеденение с сервером
            using (TcpClient client = new TcpClient()) {
                // соединение с сервером
                client.Connect(Address, Port);

                // получение потока ввода/вывода для работы с сетью
                using (NetworkStream networkStream = client.GetStream()) {

                    // запись запроса в сетевой поток при помощи бинарного потока
                    using (BinaryWriter bwr = new BinaryWriter(networkStream)) {

                        string[] buf = request.Split('\n'); // разбиение запроса на строки
                        string name = buf[0]; // получение названия запроса
                        string size = buf[1]; // получение размера отчета

                        // вырезать из запроса строки name и size,
                        // тем самым оставив голый отчет
                        request = request.Substring(name.Length + 1);
                        request = request.Substring(size.Length + 1);

                        bwr.Write(name);
                        bwr.Write(size);
                        bwr.Write(request);

                        // чтение ответа от сервера
                        using (BinaryReader brd = new BinaryReader(networkStream))
                            response = brd.ReadString();

                    }//BinaryWriter
                }// NetworkStream
            } // TcpClient

            return response;
        } // ClientTcp
    } // ClientClass
}
