using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class SimpleList
    {
        SimpleElement head;
        SimpleElement tail;
        int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Add(string data, int key)
        {
            SimpleElement node = new SimpleElement(data, key);
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            count++;
        }

        public void Add(string data)
        {
            SimpleElement node = new SimpleElement(data);
            if (head == null)
                head = node;
            else
                tail.Next = node;
            tail = node;
            count++;
        }

        public bool Remove(string data)
        {
            SimpleElement current = head;
            SimpleElement previous = null;
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

        public override string ToString()
        {
            string str = "";
            SimpleElement current = this.head;
            while (current != null)
            {
                str += current.Data;
                current = current.Next;
            }
            return str;
        }

        public int Contains(string data)
        {
            SimpleElement current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return current.Key;
                current = current.Next;
            }
            return 0;
        }

        public void AppendFirst(string data)
        {
            SimpleElement node = new SimpleElement(data);
            node.Next = head;
            head = node;
            if (count == 0)
                tail = head;
            count++;
        }
    }
}
