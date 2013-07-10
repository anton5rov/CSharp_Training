// -----------------------------------------------------------------------
// <copyright file="Direction.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace LargestAreaInMatrix
{
    /// <summary>
    /// Struct to hold X and Y of the direction to move in the matrix
    /// </summary>
    public struct Direction
    {
        public sbyte X;
        public sbyte Y;

        public Direction(sbyte x, sbyte y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
