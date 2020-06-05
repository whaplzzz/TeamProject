using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maintenance.Client.Library;

namespace Maintenance.Client.Controllers
{
    public class App {
        // переменная для работы с сервером
        public ClientClass Client { get; set; }

        // переменная для эмуляции БД
        // TODO:: тут поставить stub для получения данных из сервера

        // переменная для работы с формой
        public MainForm Form { get; private set; }

        // конструктор
        public App(MainForm form) {
            Client = new ClientClass();
            Form = form;
        } // App

        /// <summary>
        /// отправить дневной отчет
        /// </summary>
        public void SendDailyRequest() {
            // получение данных от БД, передача в конвертер и отправка на сервер
            // TODO:: заменить на нормальные данные
            Client.SendMessage(RequestClass.CreateDailyRequest("daily"));

            // TODO:: передача данных на контроль отображения ответа

        } // SendDailyRequest

        /// <summary>
        /// оправка отчета о рабочем составе
        /// </summary>
        public void SendStuffRequest() {
            // получение данных от БД, передача в конвертер и отправка на сервер
            // TODO:: заменить на нормальные данные
            Client.SendMessage(RequestClass.CreateStuffRequest("stuff_data"));

            // TODO:: передача данных на контроль отображения ответа

        } // SendStuffRequest

        /// <summary>
        /// отправка данных на текст бокс для отображения
        /// </summary>
        /// <param name="tb">текст бокс для работы с данными</param>
        /// <param name="data">данные которые будут передаваться в текст бокс</param>
        private void SendAnswerOnUi(TextBox tb, string data) {
            if (tb.InvokeRequired)
                Form.BeginInvoke((Action) (() => tb.Text = "\r\n" + data));
        } // SendAnswerOnUi
    } // App
}
