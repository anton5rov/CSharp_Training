using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Counter : GameObject
    {
        private int value = 0;

        public Counter(MatrixCoords topLeft)
            : base(topLeft, new char[1, 5])
        {
            this.body = ValueAsCharArray();
        }

        public override void Update()
        {
            this.body = ValueAsCharArray();
        }

        public void UpdateValue(int value)
        {
            if (value < 0 || 99999 < value)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.value = value;
        }

        private char[,] ValueAsCharArray()
        {
            char[,] chArr = new char[1, 5];
            string valueString = value.ToString().PadLeft(5, '0');
            for (int i = 0; i < 5; i++)
            {
                chArr[0, i] = valueString[i];
            }

            return chArr;
        }
    }
}