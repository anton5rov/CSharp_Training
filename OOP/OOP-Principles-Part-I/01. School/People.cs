using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace School
{    
    public class Person: INotable
    {
        private string firstName;
        private string lastName;
        private byte age;        

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                if (value.Length > 50) throw new ArgumentException();
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                if (value.Length > 50) throw new ArgumentException();
                this.lastName = value;
            }
        }
        public byte Age
        {
            get { return this.age; }
            private set 
            {
                if (value < 0 && value > 150) throw new ArgumentException();
                this.age = (byte)value;
            }
        }
        public string Notes { get; set; }

        public Person(string fName, string lName, byte age)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {1}, age {2}", this.FirstName, this.LastName, this.Age);
            return sb.ToString();
        }
        
    }
}
