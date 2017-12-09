using System;

namespace Task_4_ArturDovbysh
{
    /// <summary>
    /// Represents determinant calculator for square matrixes.
    /// </summary>
    public static class Determinant
    {
        /// <summary>
        /// Calculates the value of determinant.
        /// </summary>
        /// <param name="matrix">Matrix to calculate the determinant.</param>
        /// <returns>Value of determinant.</returns>
        public static int GetDeterminant(MyMatrix matrix, int size)
        {
            int determinant = 0;
            int degree = 1;  // (-1)^(1+j)
            MyMatrix tmp;    
            
            if (size == 1) //first condition for withdrawal from recursion
            {
                return matrix[0, 0];
            }
            else if (size == 2) //second condition for withdrawal from recursion
            {
                return matrix[0,0] * matrix[1,1] - matrix[0,1] * matrix[1,0];
            }
            else
            {
                for(int j = 0; j < matrix.Rows; j++)
                {
                    tmp = GetMatrixWithoutRowAndCol(matrix, 0, j);
                    determinant = determinant + (degree * matrix[0, j] * GetDeterminant(tmp, tmp.Rows)); //recursion
                    degree = -degree; 
                }
            }

            return determinant;
        }

        //helper to get minors of the matrix
        static MyMatrix GetMatrixWithoutRowAndCol(MyMatrix matrix, int row, int column)
        {
            MyMatrix result = new MyMatrix(matrix.Rows - 1, matrix.Columns - 1);

            byte offsetRow = 0;      
            byte offsetColumn = 0;

            for(int i = 0; i < matrix.Rows-1; i++)
            {
                if (i == row)
                    offsetRow = 1;

                offsetColumn = 0;
                for(int j = 0; j < matrix.Columns-1; j++)
                {
                    if (j == column)
                        offsetColumn = 1;

                    result[i,j] = matrix[i + offsetRow,j + offsetColumn];
                }
            }

            return result;
        }
    }
}

