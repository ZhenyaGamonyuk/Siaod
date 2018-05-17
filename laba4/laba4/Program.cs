using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class Program
    {
        public static string Reverse(string s)
        {
            char[] charArray = s.ToCharArray();
            Array.Reverse(charArray);
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == '(')
                    charArray[i] = ')';
                else if (charArray[i] == ')')
                    charArray[i] = '(';
            }
            return new string(charArray);
        }

        public static string PrefixToPostfix(string expression)
        {
            string str = Reverse(expression);
            str = InfixToPostfix(str);          
            return Reverse(str);
        }

        public static string InfixToPostfix(string expression)
        {
            Stack<string> Stack = new Stack<string>();
            SimpleList Answer = new SimpleList();
            SimpleList List = new SimpleList();
            List.Add("*", 3);
            List.Add("/", 3);
            List.Add("-", 2);
            List.Add("+", 2);
            List.Add("(", 1);
            foreach (char c in expression)
            {
                string elem = c.ToString();
                if ("ABCDEFGHIGKLMNOPQRSTUVWXYZ".Contains(elem) || "0123456789".Contains(elem))
                {
                    Answer.Add(elem);
                }
                else if (elem == "(")
                {
                    Stack.Push(elem);
                }
                else if (elem == ")")
                {
                    string elemTemp = Stack.Pop();
                    while (elemTemp != "(")
                    {
                        Answer.Add(elemTemp);
                        elemTemp = Stack.Pop();
                    }
                }
                else
                {
                    while (!Stack.IsEmpty && List.Contains(Stack.Peek()) >= List.Contains(elem))
                    {
                        Answer.Add(Stack.Pop());
                    }
                    Stack.Push(elem);
                }
            }
            while (!Stack.IsEmpty)
            {
                Answer.Add(Stack.Pop());
            }
            return Answer.ToString();
        }

        static void Main(string[] args)
        {
            label1:
            Console.Write("Инфиксная форма: ");
            string str = Console.ReadLine();
            Console.Write("Постфиксная форма: ");
            Console.WriteLine(InfixToPostfix(str));
            Console.Write("Префиксная форма: ");
            Console.WriteLine(PrefixToPostfix(str));
            Console.ReadLine();
            goto label1;
        }
    }
}
