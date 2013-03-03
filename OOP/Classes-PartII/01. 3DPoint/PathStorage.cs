using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Points3D
{
    public static class PathStorage
    {
        
        public static void Save(Path path)
        {
            // making text file in the same directory as the calling class
            StreamWriter sw = new StreamWriter(@"..\..\PointsList.txt"); 
            using (sw)
            {
                sw.WriteLine(path.ToString());
            }
        }


        public static Path Load(string fileName)
        {
            // No matter of the text, if a line has at least one number, it's considered as a point
            // e.g. "Some text (1.2)" is a point (1.2, 0, 0)
            try
            {
                StreamReader sr = new StreamReader(fileName);
                using (sr)
                {
                    // assuming that numbers are [digit(s).digit(s)] OR [digit(s)]
                    // as so, "1." is not considered as a number
                    string pattern = @"\d{1,}\.\d{1,}|\d(?!\.)";
                    Path tempPath = new Path();                
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {                        
                        Point3D point = new Point3D();
                        if (Regex.IsMatch(line, pattern)) // if there is at least one match in the line
                        {
                            byte count = (byte)Regex.Matches(line, pattern).Count;
                            
                            // if not enough matches in the line, leave absents to 0
                            if (count > 0) point.X = double.Parse(Regex.Matches(line, pattern)[0].ToString());
                            if (count > 1) point.Y = double.Parse(Regex.Matches(line, pattern)[1].ToString());
                            if (count > 2) point.Z = double.Parse(Regex.Matches(line, pattern)[2].ToString());
                            tempPath.PointsList.Add(point);
                        }
                    }
                    return tempPath;
                }
            }
                
            catch 
            {
                throw; 
            }
        }
    }
}

