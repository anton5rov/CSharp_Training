namespace Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    
    public class Program
    {
        public static void Main()
        {
            CoursesInfo courseDB = new CoursesInfo();

            using (StreamReader streamReader = new StreamReader("../../students.txt"))
            {
                while (!streamReader.EndOfStream)
                {
                    string inputLine = streamReader.ReadLine();
                    string[] courseNamePair = ParseString(inputLine);
                    string course = courseNamePair[0];
                    string name = courseNamePair[1];
                    courseDB.AddCourseEntry(course, name);
                }
            }

            Console.WriteLine(courseDB);
        }

        private static string[] ParseString(string inputLine)
        {
            string[] split = inputLine.Split(new char[] { '|' });
            
            string[] result = new string[2];
            result[0] = split[2].Trim();
            result[1] = split[0].Trim() + " " + split[1].Trim();

            return result;
        }
    }
}
