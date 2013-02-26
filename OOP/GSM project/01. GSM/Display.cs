using System;

namespace GSM
{
    public class Display
    {
        //size integer in pixels
        private int width;
        private int height;
        private uint colors;

        public Display()// parameterless constructor
        {
        }
        public Display(int width, int height, uint colors) // all params constructor
        {
            this.Width = width;
            this.Height = height;
            this.Colors = colors;
        }
        public int Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (CheckExceptions.CheckPositive("Display.Width", value)) this.width = value;
            }
        }
        public int Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (CheckExceptions.CheckPositive("Display.Height", value)) this.height = value;
            }
        }
        public uint Colors
        {
            get
            {
                return this.colors;
            }
            set 
            {
                if (CheckExceptions.CheckPositive("Display.Colors", (int)value)) this.colors = value;
            }
        }
    }
}
