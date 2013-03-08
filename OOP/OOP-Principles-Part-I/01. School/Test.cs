using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace School
{
    class Test
    {
        static void Main()
        {            
            Teacher mTeacher = new Teacher("Asan", "Asanov", 45);
            Discipline disciplineCSharp = new Discipline("C#");

            // add discipline C# through the AddDiscipline in the teacher's list once
            mTeacher.AddDiscipline(disciplineCSharp);
            // next try to add list of 3 times same discipline through the setter of the Discipline property
            List<Discipline> testListDisciplines = new List<Discipline>() { disciplineCSharp, disciplineCSharp, disciplineCSharp };
            mTeacher.Disciplines = testListDisciplines;

            // AddDiscipline method controls not to add same discipline more than once
            Console.Write("List of disciplines for teacher {0}:", mTeacher);
            foreach (var discipline in mTeacher.Disciplines)
            {
                Console.Write(" {0}", discipline.Name);                
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Add HTML discipline");

            Discipline disciplineHTML = new Discipline("HTML");
            testListDisciplines = new List<Discipline>() { disciplineHTML, disciplineHTML, disciplineCSharp};
            mTeacher.Disciplines = testListDisciplines;

            Console.Write("List of disciplines for teacher {0}:", mTeacher);
            foreach (var discipline in mTeacher.Disciplines)
            {
                Console.Write(" {0}", discipline.Name);
            }
            Console.WriteLine();
            Console.WriteLine();

            //Demonstration that method AddDiscipline adds 
            // the teacher in the discipline's list of teachers in the same time
            foreach (var discipline in mTeacher.Disciplines)            
               foreach (var teacher in discipline.Teachers)               
                  Console.WriteLine("List of teachers for discipline {0}: {1}", discipline.Name, teacher);
        }
    }
}
