// task 3 - static class and static method Distance
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Points3D
{
    public static class PointsDistance
    {
        public static double Distance(Point3D a, Point3D b)
        {
            double distance;
            distance = Math.Sqrt((a.X-b.X) * (a.X-b.X) + (a.Y-b.Y) * (a.Y-b.Y) + (a.Z-b.Z) * (a.Z-b.Z));
            return distance; 
        }
    }
}
