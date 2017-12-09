using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_4_ArturDovbysh;

namespace Task_4_MyMatrix.Tests
{
    [TestClass]
    public class OperatorsTest
    {
        [TestMethod]
        public void OperatorPlus_ShouldReturn_ExpectedMatrix()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            int[,] arr2 = { { 1, 1 }, { 3, 3 } };
            MyMatrix m2 = new MyMatrix(arr2);

            MyMatrix m3 = m1 + m2;

            int[,] excpected = { { 3, 4 }, { 4, 4 } };

            Assert.IsTrue(m3 == new MyMatrix(excpected));
        }

        [TestMethod]
        public void OperatorMinus_ShouldReturn_ExpectedMatrix()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            int[,] arr2 = { { 1, 1 }, { 3, 3 } };
            MyMatrix m2 = new MyMatrix(arr2);

            MyMatrix m3 = m1 - m2;

            int[,] excpected = { { 1, 2 }, { -2, -2 } };

            Assert.IsTrue(m3 == new MyMatrix(excpected));
        }

        [TestMethod]
        public void OperatorMultiplyByMatrix_ShouldReturn_ExpectedMatrix()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            int[,] arr2 = { { 1, 1 }, { 3, 3 } };
            MyMatrix m2 = new MyMatrix(arr2);

            MyMatrix m3 = m1 * m2;

            int[,] excpected = { { 11, 11 }, { 4, 4 } };

            Assert.IsTrue(m3 == new MyMatrix(excpected));
        }

        [TestMethod]
        public void OperatorMultiplyByNumber_ShouldReturn_ExpectedMatrix()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            MyMatrix m3 = m1 * 10;

            int[,] excpected = { { 20, 30 }, { 10, 10 } };

            Assert.IsTrue(m3 == new MyMatrix(excpected));
        }

        [TestMethod]
        public void OperatorIsEqualTo_ShouldReturn_True()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            int[,] arr2 = { { 1, 1 }, { 3, 3 } };
            MyMatrix m2 = new MyMatrix(arr2);

            MyMatrix m3 = m1 * m2;

            int[,] excpected = { { 11, 11 }, { 4, 4 } };

            Assert.IsTrue(m3 == new MyMatrix(excpected));
        }

        [TestMethod]
        public void OperatorIsEqualTo_ShouldReturn_False()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            int[,] arr2 = { { 1, 1 }, { 3, 3 } };
            MyMatrix m2 = new MyMatrix(arr2);

            MyMatrix m3 = m1 * m2;

            Assert.IsFalse(m3 == m1);
        }

        [TestMethod]
        public void OperatorIsNotEqualTo_ShouldReturn_True()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            int[,] arr2 = { { 1, 1 }, { 3, 3 } };
            MyMatrix m2 = new MyMatrix(arr2);

            MyMatrix m3 = m1 * m2;

            Assert.IsTrue(m3 != m1);
        }

        [TestMethod]
        public void OperatorIsNotEqualTo_ShouldReturn_False()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            int[,] arr2 = { { 1, 1 }, { 3, 3 } };
            MyMatrix m2 = new MyMatrix(arr2);

            MyMatrix m3 = m1 * m2;

            int[,] excpected = { { 5, 15 }, { 2, 6 } };

            Assert.IsFalse(m3 == new MyMatrix(excpected));
        }

        [TestMethod]
        public void OperatorIsGreaterThan_ShouldReturn_True()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            MyMatrix m3 = m1 *10;

            Assert.IsTrue(m3 > m1);
        }

        [TestMethod]
        public void OperatorIsGreaterThan_ShouldReturn_False()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            MyMatrix m3 = m1 * 10;

            Assert.IsFalse(m1 > m3);
        }


        [TestMethod]
        public void OperatorIsLessThan_ShouldReturn_True()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            MyMatrix m3 = m1 * 10;

            Assert.IsTrue(m1 < m3);
        }

        [TestMethod]
        public void OperatorIsLessThan_ShouldReturn_False()
        {
            int[,] arr1 = { { 2, 3 }, { 1, 1 } };
            MyMatrix m1 = new MyMatrix(arr1);

            MyMatrix m3 = m1 * 10;

            Assert.IsFalse(m3 < m1);
        }
    }
}
