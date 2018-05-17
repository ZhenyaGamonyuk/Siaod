using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._4
{
    public class DoubleList
    {
        private DoubleElement head = null;
        private DoubleElement tail = null;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void AddLast(int number)
        {
            DoubleElement elem = new DoubleElement(number);
            if (head == null)
                head = elem;
            else
            {
                tail.Next = elem;
                elem.Previous = tail;
            }
            tail = elem;
            count++;
        }

        public void AddFirst(int number)
        {
            DoubleElement elem = new DoubleElement(number);
            DoubleElement temp = head;
            elem.Next = temp;
            head = elem;
            if (count == 0)
                tail = head;
            else
                temp.Previous = elem;
            count++;
        }

        public MyList AbonentToList()
        {
            DoubleElement current = this.tail;
            MyList ListOfAbonents = new MyList();
            while (current != null)
            {
                int digitCount = (int)Math.Log10(current.Number) + 1;
                if (digitCount == 7)
                {
                    ListOfAbonents.Add(current.Number);
                    MyList.Sort(ListOfAbonents);
                }
                current = current.Previous;
            }
            return ListOfAbonents;
        }

        public bool Remove(int number)
        {
            DoubleElement current = head;
            while (current != null)
            {
                if (current.Number.Equals(number))
                    break;
                current = current.Next;
            }
            if (current != null)
            {
                if (current.Next != null)
                    current.Next.Previous = current.Previous;
                else
                    tail = current.Previous;

                if (current.Previous != null)
                    current.Previous.Next = current.Next;
                else
                    head = current.Next;
                count--;
                return true;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public string ReverseString()
        {
            DoubleElement elem = this.tail;
            string str = "";
            while (elem != null)
            {
                str += elem.Number.ToString() + "\n";
                elem = elem.Previous;
            }
            if (str.Length == 0)
                return "Список пуст!";
            else
                return "\nСписок всех номеро:\n" + str;
        }

        public override string ToString()
        {
            DoubleElement elem = this.head;
            string str = "";
            while (elem != null)
            {
                str += elem.Number.ToString() + "\n";
                elem = elem.Next;
            }
            if (str.Length == 0)
                return "Список пуст!";
            else
                return "\nСписок всех номеро:\n" + str;
        }
    }
}
