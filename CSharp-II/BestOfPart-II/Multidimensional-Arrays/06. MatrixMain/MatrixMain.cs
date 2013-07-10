namespace Matrix
{
    using System;

    public class MatrixMain
    {
        public static void Main()
        {
            int[,] m = { { 1, 2, 3 }, { 4, 5, 6 } };

            // Show IClonaeable
            Matrix<int> newMatrix = new Matrix<int>(m);
            newMatrix[0, 0] = 5;
            Console.WriteLine("m[0,0,] is: {0}", m[0, 0]);
            Console.WriteLine("newMatrix[0,0] is: {0}", newMatrix[0, 0]);
            Console.WriteLine();

            // Show +
            Matrix<int> m1 = new Matrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Console.WriteLine("m1:");
            Console.WriteLine(m1);
            Matrix<int> m2 = new Matrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Console.WriteLine("m2:");
            Console.WriteLine(m2);
            Console.WriteLine();

            m1 = m1 + m2;
            Console.WriteLine("m1 = m1 + m2:");
            Console.WriteLine(m1);
            Console.WriteLine();

            // Show -
            m1 = m1 - m2;
            Console.WriteLine("m1 = m1 - m2:");
            Console.WriteLine(m1);
            Console.WriteLine();

            // Show *
            Matrix<int> m4 = new Matrix<int>(new int[,] { { 1 }, { 2 }, { 3 } });
            Matrix<int> m5 = new Matrix<int>(2, 1);
            Console.WriteLine("m4:");
            Console.WriteLine(m4);

            m5 = m1 * m4;
            Console.WriteLine("m5 = m1 * m4:");
            Console.WriteLine(m5);
            Console.WriteLine();

            // Show generic
            Console.WriteLine("Instances of Matrix<float> and + operator:");
            Matrix<float> f1 = new Matrix<float>(new float[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Console.WriteLine("f1:");
            Console.WriteLine(f1);
            Matrix<float> f2 = new Matrix<float>(new float[,] { { 1, 2, 3 }, { 4, 5, 6 } });
            Console.WriteLine("f2:");
            Console.WriteLine(f2);
            f1 = f1 + f2;
            Console.WriteLine("f1 = f1 + f2:");
            Console.WriteLine(f1);
        }
    }
}