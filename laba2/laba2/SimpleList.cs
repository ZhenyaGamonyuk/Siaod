using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class SimpleList<T>
    {
        SimpleElement<T> head;
        SimpleElement<T> tail;
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Add(T data)
        {
            SimpleElement<T> node = new SimpleElement<T>(data);
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            count++;
        }

        public bool Remove(T data)
        {
            SimpleElement<T> current = head;
            SimpleElement<T> previous = null;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.Next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.Next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            SimpleElement<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public override string ToString()
        {
            string str = "";
            SimpleElement<T> current = head;
            while (current != null)
            {
                str += " " + current.Data;
                current = current.Next;
            }
            return str;
        }

        public void AppendFirst(T data)
        {
            SimpleElement<T> node = new SimpleElement<T>(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
    }
}
