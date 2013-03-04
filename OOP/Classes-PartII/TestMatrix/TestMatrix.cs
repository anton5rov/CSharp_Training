using System;
using MatrixClass;

class TestMatrix
{
    static void Main()
    {
        Matrix<int> intMatrix1 = new Matrix<int>(2, 3);
        Matrix<int> intMatrix2 = new Matrix<int>(2, 3);

        intMatrix1[0, 0] = 10;
        intMatrix1[0, 1] = 10;
        intMatrix1[0, 2] = 10;
        intMatrix1[1, 0] = 10;
        intMatrix1[1, 1] = 10;
        intMatrix1[1, 2] = 10;

        intMatrix2[0, 0] = 0;
        intMatrix2[0, 1] = 1;
        intMatrix2[0, 2] = 2;
        intMatrix2[1, 0] = 3;
        intMatrix2[1, 1] = 4;
        intMatrix2[1, 2] = 5;

        Matrix<int> intMatrixResult;
        //check +
        try
        {
            intMatrixResult = intMatrix1 + intMatrix2;
            Console.WriteLine(intMatrixResult);
        }
        catch (RankException e)
        {
            Console.WriteLine(e.Message);
        }
        //check -
        try
        {
            intMatrixResult = intMatrix1 - intMatrix2;
            Console.WriteLine(intMatrixResult);
        }
        catch (RankException e)
        {
            Console.WriteLine(e.Message);
        }
        //check exception
        try
        {
            intMatrixResult = intMatrix1 * intMatrix2;
            Console.WriteLine(intMatrixResult);
        }
        catch (RankException e)
        {
            Console.WriteLine(e.Message);
            Console.WriteLine();
        }
        //try correct *
        Matrix<int> intMatrix3 = new Matrix<int>(3, 4);
        intMatrix3[0, 0] = 0;
        intMatrix3[0, 1] = 1;
        intMatrix3[1, 0] = 2;
        intMatrix3[1, 1] = 3;
        intMatrix3[2, 0] = 4;
        intMatrix3[2, 1] = 5;
        try
        {
            intMatrixResult = intMatrix1 * intMatrix3;
            Console.WriteLine(intMatrixResult);
        }
        catch (RankException e)
        {
            Console.WriteLine(e.Message);
        }

        //check true and false
        if (intMatrix1) Console.WriteLine("true");
        else Console.WriteLine("false");

        Matrix<int> intMatrix4 = new Matrix<int>(3, 4);

        if (intMatrix4) Console.WriteLine("true");
        else Console.WriteLine("false");        
    }
}
