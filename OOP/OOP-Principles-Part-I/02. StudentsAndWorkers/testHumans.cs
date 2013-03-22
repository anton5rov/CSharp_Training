//Define abstract class Human with first name and last name. Define new class Student
//which is derived from Human and has new field – grade. Define class Worker derived
//from Human with new property WeekSalary and WorkHoursPerDay and method MoneyPerHour()
//that returns money earned by hour by the worker. Define the proper constructors and
//properties for this hierarchy. Initialize a list of 10 students and sort them by grade
//in ascending order (use LINQ or OrderBy() extension method). Initialize a list of 10 workers
//and sort them by money per hour in descending order. Merge the lists and sort them by first
//name and last name.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsAndWorkers
{
    class testHumans
    {
        static void Main()
        {
            List<Student> students = new List<Student>(10);
            for (byte i = 0; i < 10; i++)
            {
                students.Add(new Student("StudentFisrstName" + i, "StudentLastName" + i, 5-i/2));
            }
            Console.WriteLine("Students:");
            PrintList(students);
            //sort with lambda
            IEnumerable<Student> sortedStudents = students.OrderBy(student => student.Grade);
            Console.WriteLine("Students sorted list:");
            PrintList(sortedStudents);
            
            Console.WriteLine();
            Console.WriteLine("Workers:");
            List<Worker> workers = new List<Worker>(10);
            for (byte i = 0; i < 10; i++)
            {
                workers.Add(new Worker("WorkerFisrstName" + i, "WorkerLastName" + i, (400 + i * 100), 8));
            }
            PrintList(workers);
            //sort with LINQ
            var sortedWorkers =
                from w in workers
                orderby w.MoneyPerHour descending
                select w;
            Console.WriteLine("Workers sorted list:");
            PrintList(sortedWorkers);
            Console.WriteLine();

            //merged list
            List<Human> mergedList = new List<Human>();
            mergedList = sortedStudents.Concat<Human>(sortedWorkers).ToList();
            Console.WriteLine("Merged list:");
            PrintList(mergedList);
            var sortedMergedList =
                from mergedElement in mergedList
                orderby mergedElement.FirstName
                orderby mergedElement.LastName
                select mergedElement;
            Console.WriteLine("Merged sorted list:");
            PrintList(sortedMergedList);
        }

        public static void PrintList<T>(IEnumerable<T> list)
        {
            foreach (var element in list)
            {
                Console.WriteLine(element);
            }
        }
    }
}