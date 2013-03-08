using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class SchoolClass: INotable
    {
        private List<Teacher> teachers = new List<Teacher>();
        private List<Student> students = new List<Student>();
        
        public List<Teacher> Teachers
        { 
            get 
            { 
                return this.teachers; 
            } 
            private set 
            {
                this.teachers = value; 
            } 
        }
        public List<Student> Students
        {
            get 
            {
                return this.students; 
            } 
            private set 
            {
                this.students = value; 
            } 
        }
        public string ClassName { get; set; }
        public string Notes { get; set; }

        public SchoolClass(List<Teacher> teachers, List<Student> students)
        {
            this.Teachers = teachers;
            this.Students = students;
        }
        public SchoolClass(string name) : this(null, null)
        {
            this.ClassName = name;
        }
        
        
    }
}