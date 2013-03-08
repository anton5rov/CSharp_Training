using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Student : Person
    {
        public uint ID { get; set; }
        public Student(string fName, string lName, byte age) : base(fName, lName, age) { }
    }
}
