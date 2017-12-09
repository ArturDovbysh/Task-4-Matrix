using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_4_ArturDovbysh;

namespace Task_4_MyMatrix.Tests
{
    [TestClass]
    public class FunctionsTest
    {
        [TestMethod]
        public void Transpose_ShouldReturn_ExpectedMatrix()
        {
            int[,] arr = { { 1, 2 }, { 3, 4 } };
            MyMatrix m1 = new MyMatrix(arr);

            MyMatrix m2 = m1.Transpose();
            int[,] expected = { { 1, 3 }, { 2, 4 } };

            Assert.IsTrue(m2 == new MyMatrix(expected));
        }

        [TestMethod]
        public void SubMatrix_ShouldReturn_ExpectedMatrix()
        {
            int[,] arr = { { 1, 2, 3 }, { 3, 4, 5 }, { 5, 6, 7 } };
            MyMatrix m1 = new MyMatrix(arr);

            MyMatrix m2 = m1.GetSubMatrix(2, 2);
            int[,] expected = { { 1, 2 }, { 3, 4 } };

            Assert.IsTrue(m2 == new MyMatrix(expected));
        }
    }
}
