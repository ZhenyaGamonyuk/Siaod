using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba2
{
    class SimpleElement<T>
    {
        public SimpleElement(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public SimpleElement<T> Next { get; set; }
    }
}
