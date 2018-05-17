using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._4
{
    public class MyList
    {
        private MyElement head = null;
        private MyElement tail = null;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Add(int number)
        {
            MyElement elem = new MyElement(number);
            if (head == null)
                head = elem;
            else
                tail.Next = elem;
            tail = elem;
            count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }   

        public override string ToString()
        {
            MyElement elem = this.head;
            string str = "Абоненты:\n";      
            while (elem != null)
            {
                str += elem.Number + "\n";
                elem = elem.Next;
            }
            if (str == "Абоненты:\n")
                return "Список абонентов пуст!";
            else
                return str;
        }

        public static void Sort(MyList list)
        {
            if (list.Count > 1)
            {
                for (MyElement temp_elem1 = list.head; temp_elem1 != null; temp_elem1 = temp_elem1.Next)
                    for (MyElement temp_elem2 = list.head; temp_elem2 != null; temp_elem2 = temp_elem2.Next)
                        if (temp_elem2.Next != null && temp_elem2.Number > temp_elem2.Next.Number)
                            Swap(temp_elem2, temp_elem2.Next);
            }                
        }

        private static void Swap(MyElement elem, MyElement next)
        {
            int tempNum = next.Number;
            next.Number = elem.Number;
            elem.Number = tempNum;
        }
    }
}
