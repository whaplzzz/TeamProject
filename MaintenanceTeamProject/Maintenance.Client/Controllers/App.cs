using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maintenance.Client.Database;
using Maintenance.Client.Library;

namespace Maintenance.Client.Controllers
{
    public class App {
        // переменная для работы с сервером
        public ClientClass Client { get; set; }

        // переменная для эмуляции БД
        public Stub Stub { get; set; }

        // переменная для работы с формой
        public MainForm Form { get; private set; }

        // конструктор
        public App(MainForm form) {
            Client = new ClientClass();
            Stub = new Stub();
            Form = form;
        } // App
        
        /// <summary>
        /// отправить дневной отчет
        /// </summary>
        public void SendDailyRequest() {
            // получение данных от БД, передача в конвертер и отправка на сервер
            string reply = Client.SendMessage(RequestClass.CreateDailyRequest(Stub.DailyReport()));

            // вывод ответа сервера в текстбокс
            Form.txbMessage.Text += reply;
        } // SendDailyRequest

        /// <summary>
        /// оправка отчета о рабочем составе
        /// </summary>
        public void SendStuffRequest() {
            // получение данных от БД, передача в конвертер и отправка на сервер
            string reply = Client.SendMessage(RequestClass.CreateStuffRequest(Stub.WorkersReport()));

            // вывод ответа сервера в текстбокс
            Form.txbMessage.Text += reply;
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
