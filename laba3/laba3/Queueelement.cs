using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3
{
    class QueueElement<T>
    {
        public QueueElement(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public QueueElement<T> Next { get; set; }
    }
}
