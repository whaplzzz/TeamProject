using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Server
{
    class Program
    {
      

        static void Main(string[] args)
        {
            
            Console.SetWindowSize(120, 50);
            //заголовок
            Console.Title = "Server автосервис";

            // экземпляр класса
            ServerClass server = new ServerClass("127.0.0.1",8888);
            //запуск сервера
            server.ServerWork();

    }
}
