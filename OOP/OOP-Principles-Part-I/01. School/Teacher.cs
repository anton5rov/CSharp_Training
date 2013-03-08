using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    public class Teacher : Person
    {
        private List<Discipline> disciplines;
        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            set 
            {
                foreach (var discipline in value)
                {
                    AddDiscipline(discipline);
                }
            }
        }
        public Teacher(string fName, string lName, byte age) : base(fName, lName, age)
        {
            this.disciplines = new List<Discipline>();
        }
        public void AddDiscipline(Discipline mDiscipline)
        {
            if (this.disciplines.IndexOf(mDiscipline) == -1) this.disciplines.Add(mDiscipline);
            if (mDiscipline.Teachers.IndexOf(this) == -1) mDiscipline.Teachers.Add(this);
        }
    }
}
