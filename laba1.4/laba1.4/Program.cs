using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество вводимых номеров:");
            int count = Int32.Parse(Console.ReadLine());
            DoubleList Spisok = new DoubleList();
            for (int i = 0; i < count; i++)
            {
                label:
                Console.WriteLine("Введите номер:");
                int tempNumber = Int32.Parse(Console.ReadLine());
                int digitCount = (int)Math.Log10(tempNumber) + 1;
                if (digitCount == 3 || digitCount == 7)
                    Spisok.AddLast(tempNumber);
                else
                {
                    Console.WriteLine("Cемизначные – абонентские; трехзначные – спецслужбы!");
                    goto label;
                }              
            }
            Console.WriteLine(Spisok.ReverseString());
            MyList List = Spisok.AbonentToList();
            Console.WriteLine(List.ToString());
            Console.ReadLine();
        }
    }
}
