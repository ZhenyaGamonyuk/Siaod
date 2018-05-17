using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba1._1
{
    public class Polynomial : ICloneable
    {
        private Element head = null;
        private Element tail = null;
        private int count;
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Add(int koeff, int pow)
        {
            Element elem = new Element(koeff, pow, null);
            if (head == null)
            {
                head = elem;
                tail = head;
            }
            else
            {
                tail.Next = elem;
                tail = tail.Next;
            }
            count++;
        }

        public bool Remove(int koeff, int pow)
        {
            Element current = head;
            Element previous = null;
            while (current != null)
            {
                if (current.Koeff.Equals(koeff) && current.Pow.Equals(pow))
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

        static public int Meaning(int x, Polynomial p)
        {
            int count = 0; 
            Element current = p.head;
            while (current != null)
            {
                count += current.Koeff*(int)Math.Pow(x, current.Pow);
                current = current.Next;
            }
            return count;
        }

        static public bool Comparison(Polynomial p, Polynomial q)
        {
            int x = 1;
            int count_p = 0, count_q = 0;
            Element current = p.head;
            while (current != null)
            {
                count_p += current.Koeff * (int)Math.Pow(x, current.Pow);
                current = current.Next;
            }
            current = q.head;
            while (current != null)
            {
                count_q += current.Koeff * (int)Math.Pow(x, current.Pow);
                current = current.Next;
            }
            if (count_q == count_p)
                return true;
            else
                return false;                 
        }

        public override string ToString()
        {
            Element elem = this.head;
            string str = "";
            if (this.Count == 1)          
                str = elem.Koeff.ToString() + "x^" + elem.Pow.ToString();       
            else
            {
                while (elem != null)
                {
                    if (elem.Koeff >= 0 && elem == this.head)
                    {
                        str += elem.Koeff.ToString() + "x^" + elem.Pow.ToString();
                        elem = elem.Next;
                    }
                    if (elem.Koeff >= 0)
                    {
                        str += " + " + elem.Koeff.ToString() + "x^" + elem.Pow.ToString();
                        elem = elem.Next;
                    }
                    else
                    {
                        str += elem.Koeff.ToString() + "x^" + elem.Pow.ToString();
                        elem = elem.Next;
                    }
                }
            }          
            return str;
        }

        static public Polynomial Order(Polynomial p)
        {
            Polynomial temp_poly = new Polynomial();
            List<int> powArray = new List<int>();
            Element current_p = p.head;
            while (current_p != null)
            {
                powArray.Add(current_p.Pow);
                current_p = current_p.Next;
            }
            current_p = p.head;
            powArray.Sort();
            powArray.Reverse();
            for (int i = 0; i < powArray.Count; i++)
            {
                while (current_p != null)
                {
                    if (current_p.Pow == powArray[i])
                    {
                        temp_poly.Add(current_p.Koeff, current_p.Pow);
                        current_p = current_p.Next;
                    }
                    else
                        current_p = current_p.Next;
                }
                current_p = p.head;
            }
            p = null;
            return p = temp_poly;
        }

        static public Polynomial Simplify(Polynomial p)
        {
            int count = 0;
            int temp_Koeff = 0;
            Polynomial new_poly = new Polynomial();
            Polynomial temp_poly = new Polynomial();
            temp_poly = (Polynomial)p.Clone();
            Element current_p = p.head;
            Element current_temp = temp_poly.head;
            bool consist = false;
            do
            {
                temp_Koeff = current_p.Koeff;
                current_temp = temp_poly.head;
                for (int i = 0; i < temp_poly.Count; i++)
                {
                    if (current_p.Pow == current_temp.Pow && count != i)
                    {
                        consist = true;
                        temp_Koeff += current_temp.Koeff;                      
                        temp_poly.Remove(current_temp.Koeff, current_p.Pow);
                        p.Remove(current_temp.Koeff, current_p.Pow);
                        current_temp = current_temp.Next;
                    }
                    else                  
                        current_temp = current_temp.Next;              
                }             
                if (!consist)
                {
                    new_poly.Add(current_p.Koeff, current_p.Pow);
                    current_p = current_p.Next;
                    count++;
                }
                else
                {
                    new_poly.Add(temp_Koeff, current_p.Pow);
                    current_p = current_p.Next;
                    count++;
                }                              
            } while (current_p != null);
            return new_poly;
        }

        static public Polynomial AddPolynom(Polynomial p, Polynomial q)
        {
            int temp_Koeff = 0;
            Polynomial new_poly = new Polynomial();
            Polynomial temp_poly_p = new Polynomial();
            Polynomial temp_poly_q = new Polynomial();
            temp_poly_p = (Polynomial)p.Clone();
            temp_poly_q = (Polynomial)q.Clone();
            Element current_p = temp_poly_p.head;
            Element current_q = temp_poly_q.head;
            bool consist = false;
            do
            {
                temp_Koeff = current_p.Koeff;
                current_q = temp_poly_q.head;
                for (int i = 0; i < temp_poly_q.Count; i++)
                {
                    if (current_p.Pow == current_q.Pow)
                    {
                        consist = true;
                        temp_Koeff += current_q.Koeff;
                        temp_poly_q.Remove(current_q.Koeff, current_p.Pow);
                        temp_poly_p.Remove(current_q.Koeff, current_p.Pow);
                        current_q = current_q.Next;
                    }
                    else
                        current_q = current_q.Next;
                }
                if (!consist)
                {
                    new_poly.Add(current_p.Koeff, current_p.Pow);
                    current_p = current_p.Next;
                }
                else
                {
                    new_poly.Add(temp_Koeff, current_p.Pow);
                    current_p = current_p.Next;
                }
            } while (current_p != null);          
            Polynomial temp_new_poly = new Polynomial();
            temp_new_poly = (Polynomial)new_poly.Clone();
            Element current_new_poly = temp_new_poly.head;
            current_q = q.head;
            do
            {
                consist = false;
                current_new_poly = temp_new_poly.head;
                for (int i = 0; i < temp_new_poly.Count; i++)
                {
                    if (current_new_poly.Pow == current_q.Pow)
                    {
                        consist = true;                     
                    }
                    current_new_poly = current_new_poly.Next;
                }
                if (!consist)
                {
                    new_poly.Add(current_q.Koeff, current_q.Pow);
                }
                current_q = current_q.Next;
            } while (current_q != null);
            return new_poly;
        }

        public object Clone()
        {
            Polynomial temp_poly = new Polynomial();
            Element temp_elem = this.head;
            while ( temp_elem != null)
            {
                temp_poly.Add(temp_elem.Koeff, temp_elem.Pow);
                temp_elem = temp_elem.Next;
            }
            return temp_poly;
        }
    }
}
