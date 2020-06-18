using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Client.Database {

    // Статус работников - Уволен с работы/Принят на работу
    public enum WorkerStatus { Fired, Hired }

    // работник
    public class Worker {

        public Person Person { get; private set; } // данные о персоне
        public string Specialty { get; private set; } // специальность
        public WorkerStatus Status { get; private set; } // статус Уволен/Принят
        public DateTime DateOfEmployment { get; set; } // дата трудоустройства
        public DateTime DateOfDismissal { get; set; } // дата увольнения

        // при создании объекта подразумевается, что нанят новый работник, =>
        // дата увольнения устанавливается в дефолтное значение
        public Worker(Person person, string specialty, WorkerStatus status, DateTime dateOfEmployment, DateTime dateOfDismissal = default)
        {
            Person = person;
            Specialty = specialty;
            Status = status;
            DateOfEmployment = dateOfEmployment;
            DateOfDismissal = dateOfDismissal;
        }

        public override string ToString() {

            StringBuilder info = new StringBuilder();

            info.Append(
                $"{Person} - {Specialty} - {(Status == WorkerStatus.Fired ? "уволен" : "работает")}\r\n" +
                $"\tпринят: {DateOfEmployment.ToShortDateString()}\r\n");

            // если работник уже уволен, добавляем дату увольнения
            if (Status == WorkerStatus.Fired)
                info.Append($"\tуволен: {DateOfDismissal.ToShortDateString()}\r\n");

            return info.ToString();
        }

    }//Worker
}
