using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle Cir1 = new Circle();
            Console.WriteLine("Количество элементов:");
            int count1 = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count1; i++)
            {
                Cir1.Add(i + 1);
            }
            Console.WriteLine("\n");
            Console.WriteLine(Cir1.ToString());
            Console.WriteLine("\n");
            Console.WriteLine("Удаляем каждый: ");
            int count2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            Console.WriteLine("Остался: {0}", Cir1.DeleteNumber(count2));
            Console.ReadLine();
        }
    }
}
