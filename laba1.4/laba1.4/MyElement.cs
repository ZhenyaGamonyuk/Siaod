using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._4
{
    public class MyElement
    {
        public MyElement(int number)
        {
            Number = number;
        }
        public int Number { get; set; }
        public MyElement Next { get; set; }
    }
}
