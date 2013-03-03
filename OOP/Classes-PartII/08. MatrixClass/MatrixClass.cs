using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixClass
{
    public class Matrix<T>
        where T: struct, IComparable, IComparable<T>, IFormattable, IConvertible, IEquatable<T>
    {
        private T[,] matrix;
        public int Rows { get; set; }
        public int Cols { get; set; }

        public Matrix(int row, int col)//constructor
        {
            this.matrix = new T[row, col];
            this.Rows = row;
            this.Cols = col;
        }

        public Matrix():this(0,0)// parameterless constructor
        {
        }

        // Task 9: Indexer
        public T this[int row, int col]
        {
            get 
            {
                CheckIndex(row, col);
                return this.matrix[row, col];
            }
            set 
            {
                CheckIndex(row, col);
                this.matrix[row, col] = value; 
            }
        }

        // Task 10: +, - , * ant True operators

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            CheckRanks(m1, m2);
            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);
            for (int row = 0; row < m1.Rows; row++)
			{
                for (int col = 0; col < m1.Cols; col++)
                {
                    result[row, col] = (dynamic)m1[row, col] + (dynamic)m2[row, col];
                }			 
			}
            return result;
        }
        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            CheckRanks(m1, m2);
            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Cols);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    result[row, col] = (dynamic)m1[row, col] - (dynamic)m2[row, col];
                }
            }
            return result;
        }
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (!(m1.Cols == m2.Rows))
                throw new RankException("Ranks don't match");
            Matrix<T> result = new Matrix<T>(m1.Rows, m2.Cols);
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m2.Cols; col++)
                {
                    for (int m1Cols = 0; m1Cols < m1.Cols; m1Cols++)
                    {
                        result[row, col] += (dynamic)m1[row, m1Cols] * (dynamic)m2[m1Cols, col];
                    }                    
                }                
            }
            return result; 
        }
        public static bool operator true(Matrix<T> m1)
        {
            if (CheckTrueFalse(m1) == 1) return true;
            return false;
        }
        public static bool operator false(Matrix<T> m1)
        {
            if (CheckTrueFalse(m1) == 0) return true;
            return false;
        }
        private static int CheckTrueFalse(Matrix<T> m1)
        {
            //assuming true, when at least one non-zero element found
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    if (Convert.ToBoolean(m1[row, col]) == true) return 1;
                }
            }
            return 0; 
        }
                
        public override string ToString()
        {
            StringBuilder strB = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    strB.AppendFormat("{0} ", this[row, col].ToString());
                }
                strB.Append("\r\n");
            }
            return strB.ToString();
        }

        //error handling
        private void CheckIndex(int row, int col)
        {
            if (row < 0 || this.Rows <= row || col < 0 || this.Cols <= col)
            {
                throw new IndexOutOfRangeException();
            }
        }
        private static void CheckRanks(Matrix<T> m1, Matrix<T> m2)
        {
            if ((m1.Rows != m2.Rows) || (m1.Cols != m2.Cols))
                throw new RankException("Ranks don't match");
        }
    }
}
