using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

class StudentsWithLinq
{
    public class Student
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public Student(string fName, string lName, int age)
        {
            this.FirstName = fName;
            this.LastName = lName;
            this.Age = age;
        }

        public Student(string fName, string lName) : this (fName, lName, 20)
        {
        }
        public override string ToString()
        {
            StringBuilder fullName = new StringBuilder();
            return (fullName.AppendFormat("{0} {1}, {2} years old", this.FirstName, this.LastName, this.Age).ToString());
        }
    }
    static void Main()
    {
        Student[] students = 
        {
            new Student("Antonio", "Banderas", 50), 
            new Student("Zoro", "Georgiev"), 
            new Student("Baba", "Qga", 142),
            new Student("Baba", "Marta", 1038) 
        };

        var studentList =
            from myStudent in students
            where myStudent.FirstName.CompareTo(myStudent.LastName) < 0
            select myStudent;
        PrintList(studentList);
        
        // task 4: select first and last name of students with age between 18 and 24
        var studentList1 =
            from myStudent in students
            where 18 <= myStudent.Age && myStudent.Age <= 24
            select new {myStudent.FirstName, myStudent.LastName };
        PrintList(studentList1);

        //task 5: sort by first and last name descending
        studentList = students.OrderByDescending(x => x.FirstName).
                               ThenByDescending(x => x.LastName);
        PrintList(studentList);
        
        studentList =
            from myStudent in students
            orderby myStudent.LastName  descending
            orderby myStudent.FirstName descending
            select myStudent;
        PrintList(studentList);
    }

    private static void PrintList<T>(IEnumerable<T> studentList)        
    {
        foreach (var item in studentList)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();
    }
}