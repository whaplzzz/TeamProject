using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Client.Controllers
{
    public static class RequestClass {
        /// <summary>
        /// получение запроса для передачи на сервер дневного отчета
        /// </summary>
        /// <param name="data">данные за день</param>
        /// <returns>запрос который должен отправится на сервер</returns>
        public static string CreateDailyRequest(string data) =>
            $"@@@daily_request\r\n" +
            $"{Encoding.UTF8.GetBytes(data).Length}\r\n" +
            $"{data}";

        /// <summary>
        /// получение запроса передачи на сервер отчета по работникам станции
        /// </summary>
        /// <param name="data">персонал</param>
        /// <returns>запрос который должен отправится на сервер</returns>
        public static string CreateStuffRequest(string data) =>
            $"@@@stuff_request\r\n" +
            $"{Encoding.UTF8.GetBytes(data).Length}\r\n" +
            $"{data}";
    } // RequestClass
}
