using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._2
{
    public class Circle
    {
        private Element head = null;
        private Element tail = null;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Add(int number)
        {
            if (head == null)
            {
                head = new Element(number, null);
                tail = head;
            }
            else
            {
                tail.Next = new Element(number, head);
                tail = tail.Next;
            }
            count++;
        }

        public bool Remove(int number)
        {
            Element current = head;
            Element previous = null;
            do
            {
                if (current.Number.Equals(number))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current == tail)
                            tail = previous;
                    }
                    else
                    {
                        if (count == 1)
                        {
                            head.Next = tail;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = head;
                        }
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            } while (current != head);
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public string DeleteNumber(int k)
        {
            Element elem = this.head;
            while (this.Count != 1)
            {
                for (int i = 1; i <= k; i++)
                {
                    if (i == k)
                    {
                        this.Remove(elem.Number);
                        elem = elem.Next;
                    }
                    else
                    {
                        elem = elem.Next;
                    }
                }       
            }
            return elem.Number.ToString(); 
        }

        public string ToStringKolvo(int x)
        {
            Element elem = this.head;
            string str = "";
            if (this.Count == 1)
                str = elem.Number.ToString();
            else
            {
                for (int i = 0; i < x; i++)
                {
                    str += elem.Number.ToString() + " ";
                    elem = elem.Next;
                }
            }
            return str;
        }

        public override string ToString()
        {

            Element elem = this.head;
            string str = "Круг элементов: ";
            if (this.Count == 1)
                str = elem.Number.ToString();
            else
            {
                for (int i = 0; i < this.Count; i++)
                {
                    str += elem.Number.ToString() + " ";
                    elem = elem.Next;
                }             
            }
            return str;
        }
    }
}
