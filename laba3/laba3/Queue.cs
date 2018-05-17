using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class Queue<T>
    {
        QueueElement<T> head;
        QueueElement<T> tail;
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddToQueue(T data)
        {
            QueueElement<T> element = new QueueElement<T>(data);
            QueueElement<T> temp_element = tail;
            tail = element;
            if (count == 0)
                head = tail;
            else
                temp_element.Next = tail;
            count++;
        }
        
        public T RemoveFromQueue()
        {
            if (count == 0)
                throw new InvalidOperationException("Очередь пуста!");
            T output = head.Data;
            head = head.Next;
            count--;
            return output;
        }

        public override string ToString()
        {
            QueueElement<T> element = head;
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
