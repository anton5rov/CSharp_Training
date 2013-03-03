//Points in 3D space, defined by integer or floating point coordinates only
//e.g. (1, 2, 3) or (1.5, 2, 3.456789) are points

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Points3D
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
                
        public Point3D(double x, double y, double z) : this() //3 parameters constructor
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public override string ToString()// override ToString method
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("Point: ({0}, {1}, {2})", this.X , this.Y, this.Z);
            return str.ToString();
        }

        // task 2 - O point
        private static readonly Point3D o = new Point3D(0, 0, 0);
        public static Point3D O
        {
            get { return o; }
        }
    }
}
