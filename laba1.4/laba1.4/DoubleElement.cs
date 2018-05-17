using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._4
{
    public class DoubleElement
    {
        public DoubleElement(int number)
        {
            Number = number;
        }
        public int Number { get; set; }
        public DoubleElement Next { get; set; }
        public DoubleElement Previous { get; set; }
    }
}
