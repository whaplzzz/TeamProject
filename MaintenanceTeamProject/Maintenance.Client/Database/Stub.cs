using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maintenance.Client.Database {

    // имитация БД для проверки функциональности
    public class Stub {

        public List<Worker> Workers { get; set; } // коллекция работников
        public List<Car> Cars { get; set; } // коллекция автомобилей
        public double DayliIncome { get; set; } // доход за день
        public int AmountDayliRepairs { get; set; } // кол-во ремонтов за день
        public int AmountNewCars { get; set; } // кол-во новых авто на сервисе
        public int AmountNewClients { get; set; } // кол-во новых клиентов на сервисе
        public int AmountNewWorkers { get; set; }  // кол-во новых работников
        public int AmountFiredWorkers { get; set; } // кол-во уволенных работников

        public Stub() {

            Workers = Init.InitWorkers();
            Cars = Init.InitCars();

            DayliIncome = 10000d + Init.rand.NextDouble() * (50000d - 10000d);
            AmountDayliRepairs = Cars.Count(car => car.RepairCompletionDate == DateTime.Today); ;
            AmountNewCars = Cars.Count(car => car.RepairAcceptanceDate == DateTime.Today);
            AmountNewClients = Init.rand.Next(0, AmountNewCars);
            AmountNewWorkers = Workers.Count(w => w.DateOfEmployment == DateTime.Today);
            AmountFiredWorkers = Workers.Count(w => w.DateOfDismissal == DateTime.Today);
        }

        // дневной отчет
        public string DailyReport() {

            StringBuilder data = new StringBuilder(
                "Дневной отчет\r\n" +
                "——————————————————————————————\r\n"
                );

            data.Append($"доход за день: {DayliIncome:f2}\r\n");
            data.Append($"кол-во ремонтов за день: {AmountDayliRepairs}\r\n");
            data.Append($"кол-во новых авто на сервисе: {AmountNewCars}\r\n");
            data.Append($"кол-во новых клиентов на сервисе: {AmountNewClients}\r\n");
            data.Append($"кол-во новых работников: {AmountNewWorkers}\r\n");
            data.Append($"кол-во уволенных работников: {AmountFiredWorkers}\r\n");

            data.Append("——————————————————————————————\r\n");
            return data.ToString();
        }

        // данные о рабочем составе
        public string WorkersReport() {

            StringBuilder data = new StringBuilder(
                "Данные о рабочем составе\r\n" +
                "—————————————————————————————————————\r\n"
                );

            for (int i = 0; i < Workers.Count; ++i) {

                data.Append($"{Workers[i]}");

                if (i != Workers.Count - 1)
                    data.Append("\r\n");
            }

            data.Append("—————————————————————————————————————\r\n");
            return data.ToString();
        }

    }//Stub

}
