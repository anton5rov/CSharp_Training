using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Tomcat : Cat
    {
        private Sex animalSex = Sex.male;
        public override Sex AnimalSex
        {
            get
            {
                return this.animalSex;
            }
            set
            {
                if (value == Sex.female) throw new ArgumentException("Sex must be male!");                
            }
        }
        
        public Tomcat(string name, byte age)
            : base(name, age)
        {  
        }        
    }
}
