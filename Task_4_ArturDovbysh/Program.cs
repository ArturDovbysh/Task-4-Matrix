using System;

namespace Task_4_ArturDovbysh
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] array = { {4, 1, 2, 3 }, { 4, 4, 5, 6 }, { 1,7, 8, 9 } };
            int[,] array2 = { { 1, 3, 4 }, { 4, 3, 1 }, { 0, 3, 0 }, { 3,3,3} };
            MyMatrix matrix1 = new MyMatrix(array);
            MyMatrix matrix2 = new MyMatrix(array2);

            Console.WriteLine("Matrix 1");
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    Console.Write($"{matrix1[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-',20));

            Console.WriteLine("Matrix 2");
            for (int i = 0; i < matrix2.Rows; i++)
            {
                for (int j = 0; j < matrix2.Columns; j++)
                {
                    Console.Write($"{matrix2[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Matrix 1 * Matrix 2 = Matrix 3");
            MyMatrix matrix3 = matrix1 * matrix2;
            for (int i = 0; i < matrix3.Rows; i++)
            {
                for (int j = 0; j < matrix3.Columns; j++)
                {
                    Console.Write($"{matrix3[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 20));

            Console.WriteLine("Matrix 3 * 10");
            matrix3 *= 10;
            for (int i = 0; i < matrix3.Rows; i++)
            {
                for (int j = 0; j < matrix3.Columns; j++)
                {
                    Console.Write($"{matrix3[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 20));

            MyMatrix tMatrix = matrix3.Transpose();
            Console.WriteLine("Matrix 3 transposed");
            for (int i = 0; i < tMatrix.Rows; i++)
            {
                for (int j = 0; j < tMatrix.Columns; j++)
                {
                    Console.Write($"{tMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 20));

            MyMatrix matrix4 = new MyMatrix(array2);

            Console.WriteLine("Matrix 4");
            for (int i = 0; i < matrix4.Rows; i++)
            {
                for (int j = 0; j < matrix4.Columns; j++)
                {
                    Console.Write($"{matrix4[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 20));

            Console.WriteLine($"Matrix 4 = Matrix 2 ? : {matrix2 == matrix4}");
            Console.WriteLine($"Matrix 4 != Matrix 2 ? : {matrix2 != matrix4}");
            Console.WriteLine(new string('-', 20));


            Console.WriteLine("Submatrix 2x2 of matrix 4");
            MyMatrix subMatrix = matrix4.GetSubMatrix(2, 2);
            for(int i = 0; i < subMatrix.Rows; i++)
            { 
                for(int j =0; j < subMatrix.Columns; j++)
                {
                    Console.Write($"{subMatrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(new string('-', 20));

            Console.WriteLine($"Determinant of the subMatrix = {Determinant.GetDeterminant(subMatrix,subMatrix.Rows)}");

            Console.WriteLine("For more options of the MyMatrix class watch UnitTestingProject");

        }
    }
}
