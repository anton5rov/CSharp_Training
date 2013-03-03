
using System;
using Points3D;


    class TestPoints
    {
        static void Main(string[] args)
        {
            Point3D a = new Point3D(1.1, 2, 3);
            Point3D b = new Point3D(4, 5, 6);
            Point3D c = new Point3D(7.1, 8.25, 9);

            //Check Distance method
            Console.WriteLine("Distance from {0} to {1}: {2}\r\n", a, b, PointsDistance.Distance(a, b));
            
            //Check ToString method
            Path path = new Path();
            path.PointsList.Add(a);
            path.PointsList.Add(b);
            path.PointsList.Add(c);
            Console.WriteLine(path.ToString());
            
            // use of static Save  method
            PathStorage.Save(path);
            Console.WriteLine("Path saved!" + "\r\n");


            //use of static Load  method
            Path newPath = new Path();
            string fileName = @"..\..\PointsList.txt";
            try
            {
                newPath = PathStorage.Load(fileName);
                Console.WriteLine("Path readed from file:");
                Console.WriteLine(newPath.ToString());
                // Check Distance method for newPath points
                Point3D point1 = newPath.PointsList[1];
                Point3D point2 = newPath.PointsList[2];
                Console.WriteLine("Distance from {0} to {1}: {2}\r\n", point1, point2, PointsDistance.Distance(point1, point2));
            }
            catch // If trying to read from non-existing file
            {
                Console.WriteLine("File not found or can not read the file!");
            }
        }
    }

