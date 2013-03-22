using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Cat : Animal
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
                this.animalSex = value;
            }
        }
        public Cat(string name, byte age)
            : base(name, age)
        {         
        }
        public Cat(string name, byte age, Sex aSex)
            : base(name, age)
        {
            this.AnimalSex = aSex;
        }
        
        public override void Say()
        {
            Console.WriteLine("Miaaau");
        }
    }
}
