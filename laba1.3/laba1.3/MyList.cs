using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._3
{
    public class MyList : ICloneable
    {
        private Element head = null;
        private Element tail = null;
        private int count;

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Add(string fio, int number)
        {
            if (head == null)
            {
                head = new Element(fio, number, null);
                tail = head;
            }
            else
            {
                tail.Next = new Element(fio, number, null);
                tail = tail.Next;
            }
            count++;
        }

        public bool Remove(string fio, int number)
        {
            Element current = head;
            Element previous = null;

            while (current != null)
            {
                if (current.FIO.Equals(fio) && current.Number.Equals(number))
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

        public string FindByFIO(string findStr)
        {
            string resultNum = "";
            for (Element temp_elem = this.head; temp_elem != null; temp_elem = temp_elem.Next)
            {
                string[] substrings = temp_elem.FIO.Split(' ');
                if (substrings[0] == findStr)
                {
                    resultNum += temp_elem.Number + "\n";
                }
            }
            if (resultNum == "")
            {
                return "Не найдено";
            }
            else
                return "Найдены номера:\n" + resultNum;
        }

        public string FindByNumber(int findNum)
        {
            string resultFio = "";
            for (Element temp_elem = this.head; temp_elem != null; temp_elem = temp_elem.Next)
            {             
                if (temp_elem.Number == findNum)
                {
                    string[] substrings = temp_elem.FIO.Split(' ');
                    resultFio += substrings[0] + "\n";
                }
            }
            if (resultFio == "")
            {
                return "Не найдено";
            }
            else
                return "Найдены фамилии:\n" + resultFio;
        }

        public override string ToString()
        {
            Element elem = this.head;
            string str = "";
            if (this.Count == 1)          
                str = "ФИО:" + elem.FIO + "; Номер телефона: " + elem.Number.ToString();       
            else
            {
                while (elem != null)
                {
                    str += "ФИО:" + elem.FIO + "; Номер телефона: " + elem.Number.ToString() + "\n";
                    elem = elem.Next;
                }
            }          
            return str;
        }
       
        public object Clone()
        {
            MyList temp_poly = new MyList();
            Element temp_elem = this.head;
            while ( temp_elem != null)
            {
                temp_poly.Add(temp_elem.FIO, temp_elem.Number);
                temp_elem = temp_elem.Next;
            }
            return temp_poly;
        }



        public static void Sort(MyList list)
        {
            if (list.Count > 1)
            {
                for (Element temp_elem1 = list.head; temp_elem1 != null; temp_elem1 = temp_elem1.Next)
                    for (Element temp_elem2 = list.head; temp_elem2 != null; temp_elem2 = temp_elem2.Next)
                        if (temp_elem2.Next != null && String.Compare(temp_elem2.FIO, temp_elem2.Next.FIO, true) > 0)
                            Swap(temp_elem2, temp_elem2.Next);
            }                
        }

        private static void Swap(Element elem, Element next)
        {
            string tempFio = next.FIO;
            int tempNum = next.Number;
            next.FIO = elem.FIO;
            next.Number = elem.Number;
            elem.FIO = tempFio;
            elem.Number = tempNum;
        }
    }
}
