using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._3
{
    public class Element
    {
        public Element(string fio, int number, Element next)
        {
            FIO = fio;
            Number = number;
            Next = next;
        }
        public string FIO { get; set; }
        public int Number { get; set; }
        public Element Next { get; set; }
    }
}
