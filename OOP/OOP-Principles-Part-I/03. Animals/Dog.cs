using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Animals
{
    public class Dog : Animal
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
        public Dog(string name, byte age, Sex aSex)
            : base(name, age)
        {
            this.AnimalSex = aSex;
        }
        public override void Say()
        {
            Console.WriteLine("Bau djaff?");
        }
    }

    
}
