using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<string> MyQueue = new Queue<string>();
            label1:
            Console.WriteLine("Добавить(0) Удалить(1) Выход(2)");
            switch (Int32.Parse(Console.ReadLine()))
            {
                case 0:
                    Console.WriteLine("Добавляйте элементы (для прекращения введите 0):");
                    bool temp = true;
                    while (temp)
                    {
                        string str = Console.ReadLine();
                        if (str == "0")
                            temp = false;
                        else
                            MyQueue.AddToQueue(str);
                    }
                    Console.WriteLine("Очередь: " + MyQueue.ToString());
                    break;
                case 1:
                    Console.WriteLine("Элемент {0} удален", MyQueue.RemoveFromQueue());
                    Console.WriteLine("Очередь:" + MyQueue.ToString());
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Введите 0, 1 или 2");
                    break;
            };
            goto label1;
        }
    }
}
