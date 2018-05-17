using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._2
{
    public class Element
    {
        public Element(int number, Element next)
        {
            Number = number;
            Next = next;
        }
        public int Number { get; set; }
        public Element Next { get; set; }
    }
}
