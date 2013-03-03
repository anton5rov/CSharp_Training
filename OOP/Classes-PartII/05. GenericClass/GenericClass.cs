using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericClass
{
    public class GenericList<T>        
    {
        private T[] List;
        public int Capacity{get; private set; }        
        public int Count { get; private set;}

        public GenericList(int capacity)// constructor
        {
            List = new T[capacity];
            this.Capacity = capacity;
            this.Count = 0;            
        }

        public void Add(T element)
        {
            if (!CheckCapacity())
            {
                ExtendCapacity();
            }
            this.List[Count] = element;
            this.Count++;
        }
        public T this[int index] // indexer
        {
            get 
            {
                CheckIndex(index);
                return this.List[index];
            }
            set
            {
                CheckIndex(index);
                this.List[index] = value;
            }
        }
        public void Remove(int index)
        {
            CheckIndex(index);
            T[] newList = new T[this.Capacity];
            Array.Copy(this.List, newList, index);
            Array.Copy(this.List, index+1, newList, index, this.Count - index - 1);
            this.List = newList;
            this.Count--;            
        }
        public void Insert(T element, int index)
        {
            if (!CheckCapacity())
            {
                ExtendCapacity();
            }
            for (int i = this.Count; i > index; i--)
            {
                this.List[i] = this.List[i - 1]; 
            }
            this.List[index] = element;
            this.Count++;
        }
        public void Clear()
        {
            this.List = new T[this.Capacity];
        }
        public int Find(T element)
        {
            int index = 0;
            index = Array.IndexOf<T>(this.List, element);
            return index;
            
        }
        public override string ToString() // override ToString method
        {
            StringBuilder strB = new StringBuilder();
            for (int index = 0; index < this.Count - 1; index++)
            {
                strB.Append(this.List[index].ToString() + "\r\n");
            }
            strB.Append(this.List[Count - 1].ToString());
            return strB.ToString();            
        }

        // task 7 - add Min<T> and Max<T>
        public static T Min<T>(T firstElement, T secondElement)
            where T: IComparable<T>
        {
            if (firstElement.CompareTo(secondElement) <= 0)
                return firstElement;
            else return secondElement; 
        }
        public static T Max<T>(T firstElement, T secondElement)
            where T : IComparable<T>
        {
            if (firstElement.CompareTo(secondElement) >= 0)
                return firstElement;
            else return secondElement;
        }
        
        private bool CheckCapacity()
        {
            if (this.Count + 1 > this.Capacity) return false;// not enough capacity
            return true;// capacity ok
        }
        private void CheckIndex(int index)
        {
            if (index < 0 || this.Count <= index)
            {
                throw new IndexOutOfRangeException(); 
            }             
        }

        // task 6 - Auto-grow
        private void ExtendCapacity()
        {
            int newCapacity = this.Capacity * 2;
            T[] newList = new T[newCapacity];
            Array.Copy(this.List, newList, this.Count);
            this.List = newList;
            this.Capacity = newCapacity;
        }        
    }
}