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
            Assert.IsTrue(TriangleTest.IsTriangle(3, 3, 5));
        }

        
    }
}
