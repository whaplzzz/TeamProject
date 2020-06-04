using System;
using System.Collections.Generic;
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
                    // формирование байтов для запроса на сервер
                    byte[] data = Encoding.UTF8.GetBytes(request);
                    // передача запроса серверу
                    networkStream.Write(data, 0, data.Length);

                    // чтение ответа от сервера
                    data = new byte[1536];
                    int bytes = networkStream.Read(data, 0, data.Length);
                    response = Encoding.UTF8.GetString(data, 0, bytes);
                } // NetworkStream
            } // TcpClient

            return response;
        } // ClientTcp
    } // ClientClass
}
