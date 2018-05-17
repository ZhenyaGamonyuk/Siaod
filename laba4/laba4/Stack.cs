using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class Stack<T>
    {
        StackElement<T> head;
        StackElement<T> tail;
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void Push(T data)
        {
            StackElement<T> element = new StackElement<T>(data);
            element.Next = head;
            head = element;
            count++;
        }
        
        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст!");
            StackElement<T> element = head;
            head = head.Next;
            count--;
            return element.Data;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст!");
            return head.Data;
        }

        public override string ToString()
        {
            StackElement<T> element = head;
            string str = "";
            if (count == 0)
            {
                return "Очередь пуста!";
            }
            else if(count == 1)
            {
                return str = element.Data.ToString();
            }
            else
            {
                str = element.Data.ToString();
                element = element.Next;
                while (element != null)
                {
                    str += "<-" + element.Data.ToString();
                    element = element.Next;
                }
                return str;
            }       
        }
    }
}
