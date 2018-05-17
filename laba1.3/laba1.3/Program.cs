using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList list = new MyList();
            label1:
            Console.WriteLine("Просмотреть список(1) Добавить запись(2) Выход(3) Поиск по фамилии(4) Поиск по номеру(5)\nВыберите:");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine(list.ToString()); 
                    break;
                case 2:
                    Console.WriteLine("Введите фамилию и номер:");
                    list.Add(Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                    MyList.Sort(list);
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                case 4:
                    Console.WriteLine("Введите фамилию:");             
                    Console.WriteLine(list.FindByFIO(Console.ReadLine()));
                    break;
                case 5:
                    Console.WriteLine("Введите номер:");
                    Console.WriteLine(list.FindByNumber(Convert.ToInt32(Console.ReadLine())));
                    break;
            }
            goto label1;
        }
    }
}
