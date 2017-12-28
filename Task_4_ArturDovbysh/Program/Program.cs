using System;

using Task_4_ArturDovbysh.Matrix;

namespace Task_4_ArturDovbysh.Program
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                RunDemo();
            }
            catch(Exception e)
            {
                Console.WriteLine("Demo error : {0} , in {1}",e.Message, e.TargetSite);
            }
        }

        static void RunDemo()
        {
            CreationDemo();
            OperationsDemo();
            FunctionsDemo();
        }

        static void CreationDemo()
        {
            Console.WriteLine("Creation Demo");

            try
            {
                int[,] array = { { 4, 1, 2, 3 }, { 4, 4, 5, 6 }, { 1, 7, 8, 9 } };
                int[,] array2 = { { 1, 3, 4 }, { 4, 3, 1 }, { 0, 3, 0 }, { 3, 3, 3 } };
                MyMatrix matrix1 = new MyMatrix(array);
                MyMatrix matrix2 = new MyMatrix(array2);

                Console.WriteLine("Matrix 1 created");
                PrintMatrix(matrix1);

                Console.WriteLine("Matrix 2 created");
                PrintMatrix(matrix2);
            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine(new string('-', 30));
        }

        static void OperationsDemo()
        {
            Console.WriteLine("Operations Demo");

            try
            {
                int[,] array = { { 4, 1, 2, 3 }, { 4, 4, 5, 6 }, { 1, 7, 8, 9 } };
                int[,] array2 = { { 1, 3, 4 }, { 4, 3, 1 }, { 0, 3, 0 }, { 3, 3, 3 } };
                MyMatrix matrix1 = new MyMatrix(array);
                MyMatrix matrix2 = new MyMatrix(array2);

                Console.WriteLine("Matrix 1 * Matrix 2 = Matrix 3");

                MyMatrix matrix3 = matrix1 * matrix2;
                PrintMatrix(matrix3);

                Console.WriteLine("Matrix 3 * 10");
                matrix3 *= 10;
                PrintMatrix(matrix3);


                Console.WriteLine($"Matrix 3 = Matrix 2 ? : {matrix3 == matrix2}");
                Console.WriteLine($"Matrix 3 != Matrix 2 ? : {matrix3 != matrix2}");

            }
            catch (Exception e)
            {
                throw e;
            }

            Console.WriteLine(new string('-',30));
        }

        static void FunctionsDemo()
        {
            Console.WriteLine("Functions Demo");

            try
            {
                int[,] array = { { 4, 1, 2, 3 }, { 4, 4, 5, 6 }, { 1, 7, 8, 9 } };
                int[,] array2 = { { 1, 3, 4 }, { 4, 3, 1 }, { 0, 3, 0 }, { 3, 3, 3 } };
                MyMatrix matrix1 = new MyMatrix(array);
                MyMatrix matrix2 = new MyMatrix(array2);      
                MyMatrix matrix3 = matrix1 * matrix2;
                matrix3 *= 10;

                Console.WriteLine("Matrix 3 transposed");
                PrintMatrix(matrix3.Transpose());


                Console.WriteLine("Submatrix 2x2 of matrix 3");
                PrintMatrix(matrix3.GetSubMatrix(2, 2));

                Console.WriteLine($"Determinant of the subMatrix = {Determinant.GetDeterminant(matrix3.GetSubMatrix(2,2), matrix3.GetSubMatrix(2, 2).Rows)}");

            }
            catch(Exception e)
            {
                throw e;
            }

            Console.WriteLine(new string('-',30));

        }

        static void PrintMatrix(MyMatrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
