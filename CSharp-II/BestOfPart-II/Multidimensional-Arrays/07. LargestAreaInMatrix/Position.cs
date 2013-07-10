// -----------------------------------------------------------------------
// <copyright file="Position.cs" company="Telerik">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace LargestAreaInMatrix
{
    /// <summary>
    /// Struct to hold positions in matrix 255x255 max.
    /// </summary>
    public struct Position
    {
        public byte X;
        public byte Y;

        public Position(byte x, byte y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
