// -----------------------------------------------------------------------
// <copyright file="Matrix.cs" company="Telerik">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Matrix
{
    using System;
    using System.Text;

    /// <summary>
    /// Generic class Matrix<T>, where T must 
    /// support arithmetic operators +, - and *.
    /// </summary>
    public class Matrix<T> : ICloneable
    {
        private T[,] matrix;

        public Matrix(uint rows, uint columns)
        {
            this.Rows = rows;
            this.Columns = columns;
            this.matrix = new T[rows, columns];
        }

        public Matrix(T[,] array)
            : this((uint)array.GetLength(0), (uint)array.GetLength(1))
        {
            this.matrix = (T[,])array.Clone();
        }

        public uint Rows { get; private set; }

        public uint Columns { get; private set; }

        // Indexer
        public T this[uint row, uint col]
        {
            get
            {
                return this.matrix[row, col];
            }

            set
            {
                this.matrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if (!(m1.Rows == m2.Rows && m1.Columns == m2.Columns))
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Columns);
            for (uint i = 0; i < m1.Rows; i++)
            {
                for (uint j = 0; j < m1.Columns; j++)
                {
                    result[i, j] = (dynamic)m1[i, j] + m2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator -(Matrix<T> m1, Matrix<T> m2)
        {
            if (!(m1.Rows == m2.Rows && m1.Columns == m2.Columns))
            {
                throw new ArgumentException("Matrices must have the same dimensions");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m1.Columns);
            for (uint i = 0; i < m1.Rows; i++)
            {
                for (uint j = 0; j < m1.Columns; j++)
                {
                    result[i, j] = (dynamic)m1[i, j] - m2[i, j];
                }
            }

            return result;
        }

        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (!(m1.Columns == m2.Rows))
            {
                throw new ArgumentException("First matrix columns must be equal to the second matrix rows!");
            }

            Matrix<T> result = new Matrix<T>(m1.Rows, m2.Columns);
            for (uint i = 0; i < m1.Rows; i++)
            {
                for (uint j = 0; j < m2.Columns; j++)
                {
                    result[i, j] = CalcMultiplyValue(m1, m2, i, j);
                }
            }

            return result;
        }

        public object Clone()
        {
            T[,] clone = new T[this.Rows, this.Columns];
            for (int i = 0; i < this.Rows; i++)
            {
                for (int j = 0; j < this.Columns; j++)
                {
                    clone[i, j] = this.matrix[i, j];
                }
            }

            return clone;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (uint row = 0; row < this.Rows; row++)
            {
                for (uint col = 0; col < this.Columns; col++)
                {
                    sb.AppendFormat("{0} ", this.matrix[row, col]);
                }

                sb.Append(Environment.NewLine);
            }

            return sb.ToString().Trim();
        }

        private static T CalcMultiplyValue(Matrix<T> m1, Matrix<T> m2, uint row, uint col)
        {
            T value = default(T);

            for (uint i = 0; i < m1.Columns; i++)
            {
                value += (dynamic)m1[row, i] * m2[i, col];
            }

            return value;
        }
    }
}
