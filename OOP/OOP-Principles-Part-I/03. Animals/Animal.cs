using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public abstract class Animal : ISound
    {
        public enum Sex {male, female};        
            
        public byte Age{get; private set;}
        public string Name{get; private set;}
        public abstract Sex AnimalSex { get; set; }
        
        protected Animal(string name, byte age)
        {
            this.Name = name;
            this.Age = age;            
        }

        public abstract void Say();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}, {1} year(s), {2} {3}", this.Name, this.Age, this.AnimalSex, this.GetType().Name);
            return sb.ToString();
        }
        public static double AverageAge(List<Animal> list)
        {
            double result = list.Average(s=>s.Age);
            return result;
        }
    }
}
