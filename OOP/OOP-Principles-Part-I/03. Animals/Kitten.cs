using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Kitten : Cat
    {
        private Sex animalSex = Sex.female;
        public override Sex AnimalSex
        {
            get
            {
                return this.animalSex;
            }
            set
            {
                if (value == Sex.male) throw new ArgumentException("Sex must be female!");                
            }
        }
        
        public Kitten(string name, byte age)
            : base(name, age)
        {            
        }
    }
}
