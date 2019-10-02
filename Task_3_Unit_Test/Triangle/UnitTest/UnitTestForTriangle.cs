using Microsoft.VisualStudio.TestTools.UnitTesting;
using Triangle;

namespace UnitTest
{
    [TestClass]
    public class UnitTestForTriangle
    {
        [TestMethod]
        public void IsTriangleIsoscelesTriangle()
        {
            Assert.IsTrue(TriangleTest.IsTriangle(7, 7, 9));
        }

        [TestMethod]
        public void IsRightTriangle()
        {
            Assert.IsTrue(TriangleTest.IsTriangle(6, 8, 10));
        }

        [TestMethod]
        public void IsTrianglePossible_SumMoreThanSideLength()
        {
            Assert.IsTrue(TriangleTest.IsTriangle(3, 2, 5));
        }

        [TestMethod]
        public void IsTriangleEquilateralTriangle()
        {
            Assert.IsTrue(TriangleTest.IsTriangle(7, 7, 7));
        }

        [TestMethod]
        public void OneSideIsNegative()
        {
            Assert.IsFalse(TriangleTest.IsTriangle(-3, 2, 4));
        }

        [TestMethod]
        public void TwoSideIsNegative()
        {
            Assert.IsFalse(TriangleTest.IsTriangle(-3, -2, 4));
        }

        [TestMethod]
        public void AllSidesIsNegative()
        {
            Assert.IsFalse(TriangleTest.IsTriangle(-3, -2, 4));
        }
        [TestMethod]
        public void OneSideIsZero()
        {
            Assert.IsFalse(TriangleTest.IsTriangle(0, 1, 5));
        }
        [TestMethod]
        public void TwoSideIsZero()
        {
            Assert.IsFalse(TriangleTest.IsTriangle(0, 0, 5));
        }

        [TestMethod]
        public void AllSidesIsZero()
        {
            Assert.IsFalse(TriangleTest.IsTriangle(0, 0, 0));
        }
    }
}
