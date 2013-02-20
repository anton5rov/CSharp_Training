// Write a program that reads a positive integer number N (N < 20) from console 
//and outputs in the console the numbers 1 ... N numbers arranged as a spiral.

using System;
class Spiral
{
    struct position
    {
        public int row;
        public int col;
    }
    static void Main()
    {
        position here;
        here.row = 0;
        here.col = 0;
        Console.WriteLine("Input side of the matrix N: ");
        int matrixSize = int.Parse(Console.ReadLine());
        int subMatrixSize = matrixSize;
        int[,] Matrix = new int[matrixSize, matrixSize];
        int direction = 0;
        int countNumbers = 0;
        while (countNumbers < matrixSize * matrixSize)        
        {            
            countNumbers++; 
            Matrix[here.row, here.col] = countNumbers;            
            if ((here.col >= subMatrixSize - 1) && ((here.row == matrixSize - subMatrixSize) || (here.row >= subMatrixSize - 1))) direction++;
            if ((here.col <= matrixSize - subMatrixSize) && (here.row == subMatrixSize - 1)) direction++; 
            if ((here.col <= matrixSize - subMatrixSize) && (here.row == matrixSize - subMatrixSize + 1)) { direction++; subMatrixSize--;}
            here.row += (int)Math.Sin((Math.PI / 2) * direction);
            here.col += (int)Math.Cos((Math.PI / 2) * direction);                  
        }
        for (int i = 0; i < matrixSize; i++)
        {
            for (int j = 0; j < matrixSize; j++)
            {
                Console.Write("{0,4}", Matrix[i,j]);                
            }
            Console.WriteLine();            
        }
    }
}