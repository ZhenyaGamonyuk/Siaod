using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первый многочлен");
            Console.Write("Количество членов: ");
            Polynomial mnoch1 = new Polynomial();
            int count = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int a = 0, b = 0;
                Console.Write("Степень {0}-го члена: ", i + 1);
                a = Int32.Parse(Console.ReadLine());
                Console.Write("Коэффициент {0}-го члена: ", i + 1);
                b = Int32.Parse(Console.ReadLine());
                mnoch1.Add(b, a);
            }
            Console.WriteLine("Введите второй многочлен");
            Console.Write("Количество членов: ");
            Polynomial mnoch2 = new Polynomial();
            count = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int a = 0, b = 0;
                Console.Write("Степень {0}-го члена: ", i + 1);
                a = Int32.Parse(Console.ReadLine());
                Console.Write("Коэффициент {0}-го члена: ", i + 1);
                b = Int32.Parse(Console.ReadLine());
                mnoch2.Add(b, a);
            }
            mnoch1 = Polynomial.Simplify(mnoch1);
            mnoch2 = Polynomial.Simplify(mnoch2);
            mnoch1 = Polynomial.Order(mnoch1);
            mnoch2 = Polynomial.Order(mnoch2);
            Console.WriteLine("Первый многочлен: " + mnoch1.ToString());
            Console.WriteLine("Второй многочлен: " + mnoch2.ToString());
            label1:
            Console.WriteLine("Вычислить(0) Сравнить(1) Суммировать(2) Выход(3)");
            switch (Console.ReadLine())
            {
                case "0":
                    Console.Write("Вычислить многочлены при Х = ");
                    int x = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Результат первого многочлена: {0}",Polynomial.Meaning(x, mnoch1));
                    Console.WriteLine("Результат второго многочлена: {0}", Polynomial.Meaning(x, mnoch2));
                    break;
                case "1":                   
                    if (Polynomial.Comparison(mnoch1, mnoch2))
                        Console.WriteLine("Многочлены равны");
                    else
                        Console.WriteLine("Многочлены неравны");
                    break;
                case "2":
                    Console.Write("Результат суммирования многочленов:");
                    Polynomial otvet = new Polynomial();
                    otvet = Polynomial.AddPolynom(mnoch1, mnoch2);
                    otvet = Polynomial.Order(otvet);
                    Console.WriteLine(otvet.ToString());
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Введите число");
                    break;
            }
            goto label1;
        }
    }
}
