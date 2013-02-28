using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Points3D
{
    public class Path 
    {
        public List<Point3D> PointsList { get; set; }//property
        public Path() //constructor
        {
            PointsList = new List<Point3D>();
        }
        public override string ToString() // override ToString method
        {
            int index = 1;
            StringBuilder result = new StringBuilder();
            foreach (Point3D point in PointsList)
            {
                result.Append(index++ + ". "+ point.ToString() + "\r\n");
            }            
            //result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}
