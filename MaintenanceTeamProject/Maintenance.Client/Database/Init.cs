using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maintenance.Client.Database {

    // данные для инициализации БД 
    static class Init {

        public static Random rand = new Random(); // для генерации случайных значений

        // работники
        public static List<Worker> InitWorkers() {

            List<Worker> workers = new List<Worker> {

                // новые работники, приняты на станцию сегодня
                new Worker(new Person("Маслов", "Арнольд", "Агафонович"), "Слесарь", WorkerStatus.Hired, DateTime.Today),
                new Worker(new Person("Зиновьев", "Нелли", "Альбертович"), "Электрик", WorkerStatus.Hired, DateTime.Today),
                new Worker(new Person("Анисимов", "Панкрат", "Мэлорович"), "Слесарь", WorkerStatus.Hired, DateTime.Today),
                new Worker(new Person("Авдеев", "Николай", "Федорович"), "Шиномонтажник", WorkerStatus.Hired, DateTime.Today),
                new Worker(new Person("Фомичёв", "Петр", "Мэлсович"), "Маляр", WorkerStatus.Hired, DateTime.Today),

                // работники, уволенные сегодня
                new Worker(new Person("Сафонов", "Валерий", "Викторович"), "Моторист", WorkerStatus.Fired, new DateTime(2010, 03, 28), DateTime.Today),
                new Worker(new Person("Баранов", "Тихон", "Рубенович"), "Электрогазосварщик", WorkerStatus.Fired, new DateTime(2010, 07, 13), DateTime.Today),
                new Worker(new Person("Логинов", "Осип", "Антонович"), "Шиномонтажник", WorkerStatus.Fired, new DateTime(2010, 11, 02), DateTime.Today),
                new Worker(new Person("Герасимов", "Платон", "Антонинович"), "Электрик", WorkerStatus.Fired, new DateTime(2010, 12, 15), DateTime.Today),
                new Worker(new Person("Маслов", "Юстин", "Данилович"), "Слесарь", WorkerStatus.Fired, new DateTime(2010, 12, 15), DateTime.Today),

                // олды
                new Worker(new Person("Лаврентьев", "Кассиан", "Эдуардович"), "Диспетчер", WorkerStatus.Hired, new DateTime(2010, 01, 19)),
                new Worker(new Person("Силин", "Терентий", "Вениаминович"), "Электрогазосварщик", WorkerStatus.Hired, new DateTime(2010, 01, 19)),
                new Worker(new Person("Мышкин", "Май", "Улебович"), "Токарь-расточник", WorkerStatus.Hired, new DateTime(2010, 01, 19)),
                new Worker(new Person("Михеев", "Эрик", "Федотович"), "Фрезеровщик", WorkerStatus.Hired, new DateTime(2010, 01, 19)),
                new Worker(new Person("Шубин", "Аристарх", "Леонидович"), "Моторист", WorkerStatus.Hired, new DateTime(2010, 01, 19))
            };

            return workers;
        }//InitWorkers

        // автомобили
        public static List<Car> InitCars() {

            List<Car> workers = new List<Car> {

                // новые автомобили, приняты на станцию сегодня
                // дата завершения ремонта генерируется в конструкторе
                new Car("Ваз-2101", "А 546 ТС", CarStatus.Broken, DateTime.Today),
                new Car("Ваз-2102", "А 984 НС", CarStatus.Broken, DateTime.Today),
                new Car("Ваз-2103", "А 265 ОН", CarStatus.Broken, DateTime.Today),
                new Car("Ваз-2104", "А 754 ВА", CarStatus.Broken, DateTime.Today),
                new Car("Ваз-2105", "А 269 ВА", CarStatus.Broken, DateTime.Today),
                new Car("Ваз-2106", "А 485 ТС", CarStatus.Broken, DateTime.Today),
                new Car("Ваз-2107", "А 345 АХ", CarStatus.Broken, DateTime.Today),

                // отремонтированные автомобили
                // дата завершения ремонта генерируется в конструкторе
                new Car("Ваз-2101", "А 346 ОН", CarStatus.Broken, new DateTime(2020, 05, 11)),
                new Car("Ваз-2102", "А 751 АТ", CarStatus.Broken, new DateTime(2020, 05, 23)),
                new Car("Ваз-2103", "А 491 ВА", CarStatus.Broken, new DateTime(2020, 05, 04)),
                new Car("Ваз-2104", "А 721 НА", CarStatus.Broken, new DateTime(2020, 05, 14)),
                new Car("Ваз-2105", "А 534 ОС", CarStatus.Broken, new DateTime(2020, 05, 14)),
                new Car("Ваз-2106", "А 194 НА", CarStatus.Broken, new DateTime(2020, 05, 23)),
                new Car("Ваз-2107", "А 565 НТ", CarStatus.Broken, new DateTime(2020, 05, 05)),
            };

            return workers;
        }

    }//StubInit
}
