using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{

    class Program
    {
        public static int GetHash(string str, int b)
        {
            int temp = 0, hash = 0;
            foreach (char c in str)
            {
                temp += c;
            }
            return hash = temp % b;
        }

        static void Main(string[] args)
        {
            int b = 10, hash = 0;
            string str = "";
            SimpleList<string>[] HashArray = new SimpleList<string>[b];
            for (int i = 0; i < HashArray.Length; i++)
            {
                HashArray[i] = new SimpleList<string>();
            }
            label1:
            Console.WriteLine("Добавить(0) Вывести таблицу(1) Удалить(2) Поиск(3) Выход(4) Введите цифру:");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case 0:
                    Console.WriteLine("Добавляйте любое количество строк (для прекращения введите 0):");
                    bool temp = true;
                    while (temp)
                    {
                        str = Console.ReadLine();
                        if (str == "0")
                            temp = false;
                        else
                        {
                            hash = GetHash(str, b);
                            HashArray[hash].Add(str);
                        }
                    }              
                    break;
                case 1:
                    Console.WriteLine("Хеш таблица:\n");
                    for (int i = 0; i < HashArray.Length; i++)
                    {
                        Console.WriteLine(i + ":" + HashArray[i].ToString());
                    }
                    Console.WriteLine("\n");
                    break;
                case 2:
                    Console.Write("Удалить: ");
                    str = Console.ReadLine();
                    hash = GetHash(str, b);
                    if (HashArray[hash].Contains(str))
                    {
                        HashArray[hash].Remove(str);
                        Console.WriteLine("Элемент '{0}' удален!", str);
                    }
                    else
                    {
                        Console.WriteLine("Элемент '{0}' отсутствует в словаре", str);
                    }
                    break;
                case 3:
                    Console.Write("Найти: ");
                    str = Console.ReadLine();
                    hash = GetHash(str, b);
                    if (HashArray[hash].Contains(str))
                    {
                        Console.WriteLine("Элемент '{0}' находится в словаре!", str);
                    }
                    else
                    {
                        Console.WriteLine("Элемент '{0}' отсутствует в словаре", str);
                    }
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Попробуйте еще раз!");
                    break;
            }
            goto label1;
        }
    }
}
