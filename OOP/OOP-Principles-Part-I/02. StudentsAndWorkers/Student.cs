using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsAndWorkers
{
    public class Student : Human
    {
        public float Grade { get; set; }
        public Student(string fName, string lName) : base(fName, lName) { }
        public Student(string fName, string lName, float grade) : this(fName, lName)
        {
            this.Grade = grade;
        }
        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();
            strB.AppendFormat("{0} " + "{1} " + "grade: {2}", this.FirstName, this.LastName, this.Grade);
            return strB.ToString();
        }
    }
}
