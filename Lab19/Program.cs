using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Computer
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string CPU { get; set; }
        public double Speed { get; set; }
        public int RAM { get; set; }
        public int HDD { get; set; }
        public int GPU { get; set; }
        public double Price { get; set; }
        public int Number { get; set; }

    }
    static class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
                new Computer() { Id=1, Model="Apple", CPU="M1", Speed = 1.3, RAM = 16, HDD = 500, GPU = 6, Price = 1200.99, Number=5 },
                new Computer() { Id=2, Model="Acer", CPU="AMD", Speed = 3.1, RAM = 8, HDD = 2000, GPU = 4, Price = 999.99, Number=6 },
                new Computer() { Id=3, Model="Asus", CPU="Intel", Speed = 4.0, RAM = 6, HDD = 1000, GPU = 2, Price = 1500.00, Number=22 },
                new Computer() { Id=4, Model="MSI", CPU="Intel", Speed = 1.7, RAM = 2, HDD = 250, GPU = 8, Price = 500.22, Number=175 },
                new Computer() { Id=5, Model="Apple", CPU="Intel", Speed = 3.4, RAM = 32, HDD = 1000, GPU = 10, Price = 1000.99, Number=43 },
                new Computer() { Id=6, Model="Apple", CPU="M1", Speed = 1.6, RAM = 8, HDD = 500, GPU = 4, Price = 1105.43, Number=13 },
                new Computer() { Id=7, Model="MSI", CPU="AMD", Speed = 1.5, RAM = 16, HDD = 500, GPU = 8, Price = 1105.33, Number=172 }

            };
            Console.Write("Введите модель процессора: ");
            string cpu = Console.ReadLine();
            List<Computer> pc = (from c in listComputer
                                     where c.CPU == cpu
                           select c).ToList();

            foreach (Computer i in pc)
            {
                Console.WriteLine($"{i.Id} {i.Model} {i.CPU} {i.Speed} {i.RAM} {i.HDD} {i.GPU} {i.Price} {i.Number}");
            }
            Console.WriteLine("---------------------");
            Console.Write("Введите объем ОЗУ: ");
            int ram = Convert.ToInt32(Console.ReadLine());
            List<Computer> pc2 = (from c in listComputer
                                 where c.RAM >= ram
                                 select c).ToList();

            foreach (Computer i in pc2)
            {
                Console.WriteLine($"{i.Id} {i.Model} {i.CPU} {i.Speed} {i.RAM} {i.HDD} {i.GPU} {i.Price} {i.Number}");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Список, отсортированный по увеличению стоимости:");
            List<Computer> pc3 = (from c in listComputer
                                  orderby c.Price
                                  select c).ToList();

            foreach (Computer i in pc3)
            {
                Console.WriteLine($"{i.Id} {i.Model} {i.CPU} {i.Speed} {i.RAM} {i.HDD} {i.GPU} {i.Price} {i.Number}");
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Cписок, сгруппированный по типу процессора:");
            var pc4 = from c in listComputer
                      group c by c.Model;

            foreach (IGrouping<string, Computer> c in pc4)
            {
                Console.WriteLine(c.Key);
                foreach (var i in c)
                    {
                    Console.WriteLine($"{i.Id} {i.Model} {i.CPU} {i.Speed} {i.RAM} {i.HDD} {i.GPU} {i.Price} {i.Number}");
                }
            }
            Console.WriteLine("---------------------");
            Console.WriteLine("Самый дорогой:");
            double max = listComputer.Max(n => n.Price);
            List<Computer> pc5 = (from c in listComputer
                       where c.Price == max
                       select c).ToList();

            foreach (Computer i in pc5)
            {
                Console.WriteLine($"{i.Id} {i.Model} {i.CPU} {i.Speed} {i.RAM} {i.HDD} {i.GPU} {i.Price} {i.Number}");
            }

            Console.WriteLine("Самый дешевый:");
            double min = listComputer.Min(n => n.Price);
            List<Computer> pc6 = (from c in listComputer
                                  where c.Price == min
                                  select c).ToList();

            foreach (Computer i in pc6)
            {
                Console.WriteLine($"{i.Id} {i.Model} {i.CPU} {i.Speed} {i.RAM} {i.HDD} {i.GPU} {i.Price} {i.Number}");
            }

            Console.WriteLine("---------------------");
            int countPc = listComputer.Count(n => n.Number >= 30);
            Console.WriteLine($"В списке {countPc} моделей компьютеров в количестве больше 30.");
            
            Console.ReadKey();
        }
    }
}
