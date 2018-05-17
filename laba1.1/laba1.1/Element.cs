using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._1
{
    public class Element
    {
        public Element(int koeff, int pow, Element next)
        {
            Koeff = koeff;
            Pow = pow;
            Next = Next;
        }
        public int Koeff { get; set; }
        public int Pow { get; set; }
        public Element Next { get; set; }
    }
}
