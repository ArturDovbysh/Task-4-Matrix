using System;

namespace Task_4_ArturDovbysh.Matrix
{
    /// <summary>
    /// Represents rectangular numeric matrix.
    /// </summary>
    public class MyMatrix : IComparable
    {
        private int[,] _matrix;

        /// <summary>
        /// Returns count of rows in the matrix.
        /// </summary>
        public int Rows { get; }

        /// <summary>
        /// Returns count of columns in the matrix.
        /// </summary>
        public int Columns { get; }

        /// <summary>
        /// Returns total number of elements.
        /// </summary>
        public int Length { get; }

        /// <summary>
        /// Indexer to index the matrix.
        /// </summary>
        /// <param name="rowI">Rows indexer.</param>
        /// <param name="columnI">Columns indexer.</param>
        /// <returns></returns>
        public int this[int rowI, int columnI]
        {
            get
            {
                if (rowI < 0 || rowI >= Rows || columnI < 0 || columnI >= Columns)
                    throw new IndexOutOfRangeException();

                return _matrix[rowI, columnI];

            }

            set
            {
                if (rowI < 0 || rowI >= Rows || columnI < 0 || columnI >= Columns)
                    throw new IndexOutOfRangeException();

                _matrix[rowI, columnI] = value;
            }
        }

        /// <summary>
        /// Returns a new matrix as submatrix of current matrix.
        /// </summary>
        /// <param name="rows">Number of rows in submatrix.</param>
        /// <param name="columns">Number of columns in submatrix.</param>
        /// <returns></returns>
        public MyMatrix GetSubMatrix(int rows, int columns)
        {
            if (rows > Rows || columns > Columns || rows < 0 || columns < 0)
                throw new ArgumentException();

            MyMatrix result = new MyMatrix(rows, columns);
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                    result[i, j] = _matrix[i, j];

            return result;
        }

        /// <summary>
        /// Returns a new square matrix as current transposed matrix.
        /// </summary>
        /// <returns>New matrix object.</returns>
        public MyMatrix Transpose()
        {
            //Matrix MUST be square. For more information -> google.com -> definition of transposed matrix.
            if (Rows != Columns)
                throw new InvalidOperationException("We cant transpose rectangular matrix - only square matrix.");

            MyMatrix result = new MyMatrix(Rows,Columns);
            int tmp;

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < Columns; j++)
                    result[i, j] = _matrix[i, j];
            

            for (int i = 0; i < Rows; i++)
                for (int j = 0; j < i; j++)
                {
                    tmp = result[i, j];
                    result[i, j] = result[j, i];
                    result[j, i] = tmp;
                }


            return result;
        }

        /// <summary>
        /// Compares this instance to a specified object and returns a value that indicates whether of their relative values.
        /// </summary>
        /// <param name="obj">An object to compare, or a null value.</param>
        /// <returns>
        ///A signed number indicating the relative values of this instance and parameter value.
        /// Description of the return value:
        /// is less than zero -> than this instance is less than the value;
        /// is zero -> than this instance and value are equal;
        /// is more than zero -> than this instance is greater than value;
        /// or the value is null.
        /// </returns>
        public int CompareTo(object obj)
        {
            if(obj is MyMatrix)
            {
                if (this.Equals(obj))
                    return 0;

                MyMatrix matrix = (MyMatrix)obj;

                if (matrix.Length == 0 || Rows != matrix.Rows || Columns!=matrix.Columns)
                    throw new ArgumentException();

                bool flag = true; //isGrater
                for(int i = 0; i < matrix.Rows; i++)
                    for(int j = 0; j < matrix.Columns; j++)
                    {
                        if(_matrix[i,j] < matrix[i,j])
                        {
                            flag = false;
                            break;
                        }
                    }

                if (flag)
                    return 1;

                flag = true; //isSmaller
                for (int i = 0; i < matrix.Rows; i++)
                    for (int j = 0; j < matrix.Columns; j++)
                    {
                        if (_matrix[i, j] > matrix[i, j])
                        {
                            flag = false;
                            break;
                        }
                    }

                if (flag)
                    return -1;


            }
            else throw new ArgumentException();

            return 0;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>True if the specified object is equal to the current object; otherwise - false.</returns>
        public override bool Equals(object obj)
        {
            if (obj is MyMatrix)
            {

                MyMatrix matrix = (MyMatrix)obj;

                if (matrix.Length == 0 || Rows != matrix.Rows || Columns != matrix.Columns)
                    return false;

                for(int i = 0; i < Rows; i++)
                    for(int j = 0; j < Columns; j++)
                    {
                        if (_matrix[i, j] != matrix[i, j])
                            return false;
                    }

                return true;
                
            }
            else return false;
        }

        #region Operators

        /// <summary>
        /// Adds two matrixes.
        /// </summary>
        /// <param name="m1">First matrix to add.</param>
        /// <param name="m2">Second matrix to add.</param>
        /// <returns>New matrix.</returns>
        public static MyMatrix operator+(MyMatrix m1, MyMatrix m2)
        {
            if (m1 is null || m2 is null)
                throw new ArgumentNullException();

            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns || m2.Length == 0 || m1.Length == 0)
                throw new ArgumentException();

            MyMatrix result = new MyMatrix(m1.Rows, m1.Columns);
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                    result[i, j] = m1[i, j] + m2[i, j];

            return result;
        }

        /// <summary>
        /// Subtracts two matrixes.
        /// </summary>
        /// <param name="m1">First matrix to subtract.</param>
        /// <param name="m2">Second matrix to subtract.</param>
        /// <returns>New matrix.</returns>
        public static MyMatrix operator -(MyMatrix m1, MyMatrix m2)
        {
            if (m1 is null || m2 is null)
                throw new ArgumentNullException();

            if (m1.Rows != m2.Rows || m1.Columns != m2.Columns || m2.Length == 0 || m1.Length == 0)
                throw new ArgumentException();

            MyMatrix result = new MyMatrix(m1.Rows, m1.Columns);
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                    result[i, j] = m1[i, j] - m2[i, j];

            return result;
        }

        /// <summary>
        /// Multiplies two matrixes.
        /// </summary>
        /// <param name="m1">First matrix to multiply.</param>
        /// <param name="m2">Second matrix to multiply.</param>
        /// <returns>New matrix.</returns>
        public static MyMatrix operator *(MyMatrix m1, MyMatrix m2)
        {
            if (m1 is null || m2 is null)
                throw new ArgumentNullException();

            if (m1.Columns != m2.Rows || m2.Length == 0 || m1.Length == 0)
                throw new ArgumentException();

            MyMatrix result = new MyMatrix(m1.Rows, m2.Columns);
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < result.Columns; k++) 
                        result[i, j] += (m1[i, k] * m2[k, j]);
                }
                 
            return result;
        }

        /// <summary>
        /// Multiplies the matrix by the number.
        /// </summary>
        /// <param name="m1">Matrix to multiply.</param>
        /// <param name="number">Number to multiply.</param>
        /// <returns>New matrix.</returns>
        public static MyMatrix operator *(MyMatrix m1, int number)
        {
            if (m1 is null)
                throw new ArgumentNullException();

            if (m1.Length == 0)
                throw new ArgumentException();

            MyMatrix result = new MyMatrix(m1.Rows, m1.Columns);
            for (int i = 0; i < result.Rows; i++)
                for (int j = 0; j < result.Columns; j++)
                    result[i, j] = m1[i, j]*number;

            return result;
        }

        /// <summary>
        /// Checks if two matrixes are equal.
        /// </summary>
        /// <param name="m1">First matrix to compare.</param>
        /// <param name="m2">Second mateix to compare.</param>
        public static bool operator==(MyMatrix m1, MyMatrix m2)
        {
            return m1.Equals(m2);
        }

        /// <summary>
        /// Checks if two matrixes are not equal.
        /// </summary>
        /// <param name="m1">First matrix to compare.</param>
        /// <param name="m2">Second matrix to compare.</param>
        public static bool operator !=(MyMatrix m1, MyMatrix m2)
        {
            return !m1.Equals(m2);
        }

        /// <summary>
        /// Checks if the first matrix is greater than the second.
        /// </summary>
        /// <param name="m1">First matrix to compare.</param>
        /// <param name="m2">Second matrix to compare.</param>
        public static bool operator>(MyMatrix m1, MyMatrix m2)
        {
            return m1.CompareTo(m2) > 0;
        }

        /// <summary>
        /// Checks if the first matrix is less than the second.
        /// </summary>
        /// <param name="m1">First matrix to compare.</param>
        /// <param name="m2">Second matrix to compare.</param>
        public static bool operator <(MyMatrix m1, MyMatrix m2)
        {
            return m1.CompareTo(m2) < 0;
        }

        #endregion

        /// <summary>
        /// Initializes a new matrix with specified parameters.
        /// </summary>
        /// <param name="rows">Number of rows.</param>
        /// <param name="columns">Number of columns.</param>
        public MyMatrix(int rows, int columns)
        {
            _matrix = new int[rows, columns];
            Rows = rows;
            Columns = columns;
            Length = rows * columns;
        }

        /// <summary>
        /// Initializes a new matrix with specified two dimensional array.
        /// </summary>
        /// <param name="array">Two dimensional array.</param>
        public MyMatrix(int[,] array)
        {
            if (array.Length == 0)
                throw new ArgumentException("Cant create zero dimensional matrix.");

            _matrix = array;
            Rows = array.GetLength(0);
            Columns = array.GetLength(1);
            Length = Rows * Columns;
        }



    }
}
