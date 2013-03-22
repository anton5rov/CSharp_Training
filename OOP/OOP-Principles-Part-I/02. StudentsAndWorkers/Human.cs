using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsAndWorkers
{
    public abstract class Human
    {
        private string firstName;
        private string lastName;          

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

        protected Human(string fName, string lName)
        {
            this.FirstName = fName;
            this.LastName = lName;            
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0} {1}", this.FirstName, this.LastName);
            return sb.ToString();
        }        
    }
}
