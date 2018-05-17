using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class StackElement<T>
    {
        public StackElement(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public StackElement<T> Next { get; set; }
    }
}
