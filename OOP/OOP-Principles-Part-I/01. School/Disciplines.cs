using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Discipline:INotable
    {
        public string Name {get; set; }
        public byte Lectures { get; set; }
        public byte Exercises { get; set; }
        public string Notes { get; set; }
        public List<Teacher> Teachers { get; set; }

        public Discipline(string name, byte lectures, byte exercises)
        {
            this.Name = name;
            this.Lectures = lectures;
            this.Exercises = exercises; 
            this.Teachers = new List<Teacher>();
        }

        public Discipline(string name) : this(name, 0, 0) { }
        
    }
}
