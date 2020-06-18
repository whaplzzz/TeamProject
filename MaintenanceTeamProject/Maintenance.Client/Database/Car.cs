using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Client.Database {

    // Статус готовности автомобиля - Сломан/Отремонтирован
   public enum CarStatus { Broken, Renovated }

    // автомобиль
    public class Car {

        public string Model { get; private set; }
        public string RegNumber { get; private set; } // регистрационный номер
        public CarStatus Status { get; private set; } // статус - Сломан/Отремонтирован 
        public DateTime RepairAcceptanceDate { get; private set; } // дата приема в ремонт
        public DateTime RepairCompletionDate { get; private set; } // дата завершения ремонта

        public Car(string model, string regNumber, CarStatus status, DateTime repairAcceptanceDate, DateTime repairCompletionDate = default) {

            Model = model;
            RegNumber = regNumber;
            Status = status;
            RepairAcceptanceDate = repairAcceptanceDate;
            RepairCompletionDate = RepairAcceptanceDate.AddDays(Init.rand.Next(0, 7));
        }

        public override string ToString() {

            StringBuilder info = new StringBuilder();

            info.Append(
                $"{Model} - {RegNumber} - {(Status == CarStatus.Broken ? "в ремонте" : "отремонтирован")}\r\n" +
                $"принят в ремонт: {RepairAcceptanceDate.Date}\r\n");

            // если машина уже отремонтирована, добавляем дату завершения ремонта
            if (Status == CarStatus.Renovated)
                info.Append($"отремонтирован: {RepairCompletionDate.Date}\r\n\r\n");

            return info.ToString();
        }

    }//Car

}
