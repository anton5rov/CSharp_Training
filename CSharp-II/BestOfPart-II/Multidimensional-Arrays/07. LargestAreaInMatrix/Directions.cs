// -----------------------------------------------------------------------
// <copyright file="Directions.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace LargestAreaInMatrix
{
    /// <summary>
    /// Class defining possible move directions for this
    /// specififc task.
    /// Implemented with array, holding 4 directions.
    /// "0" - right,
    /// "1" - down, 
    /// "2" - left, 
    /// "3" - up.
    /// </summary>
    public class Directions
    {
        private Direction[] directionsArray = new Direction[4];

        public Directions()
        {
            this.directionsArray[0] = new Direction(1, 0);
            this.directionsArray[1] = new Direction(0, 1);
            this.directionsArray[2] = new Direction(-1, 0);
            this.directionsArray[3] = new Direction(0, -1);
        }

        public Direction[] DirectionsArray
        {
            get
            {
                return this.directionsArray;
            }
        }
    }
}
