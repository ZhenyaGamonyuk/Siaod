using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4
{
    class SimpleElement
    {
        public SimpleElement(string data, int key)
        {
            Data = data;
            Key = key;
        }
        public SimpleElement(string data)
        {
            Data = data;
            Key = 1;
        }
        public string Data { get; set; }
        public int Key { get; set; }
        public SimpleElement Next { get; set; }
    }
}
