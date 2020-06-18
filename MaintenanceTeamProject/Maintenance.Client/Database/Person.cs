using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Client.Database {

    // персона
    public class Person {

        // ФИО
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public Person(string surnameNP = "Иванов", string name = "Иван", string patronymic = "Иванович") {

            Surname = surnameNP;
            Name = name;
            Patronymic = patronymic;
        }

        public override string ToString() {
            return $"{Surname} {Name} {Patronymic}";
        }

    }//Person

}
