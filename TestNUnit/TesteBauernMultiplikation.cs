using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RussischeBauernMultiplikation;
//using MbUnit.Framework;

namespace TestNUnit
{
    [TestFixture]
    public class TesteBauernMultiplikation
    {

        /// <summary>
        /// Entsprechend der Bauernregel
        /// Der erste Multiplikator ist innerhalb 
        /// der geometrischen Reihe 1,2,4,8,16.32...
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expectedResult"></param>
        [Test, TestCase(2, 8, 16)]
        [TestCase(4, 12, 48)]
        [TestCase(8, 2, 16)]
        public void Mul_FirstParamIsInGeometricFollow_ReturnsTrue(int? a, int? b, int? expectedResult) {
            // Arrange/Act
            var actual = BauernMultiplikation.Mul(a, b);
            // Assert 
            Assert.AreEqual(expectedResult, actual);
        }

        /// <summary>
        /// Entsprechend der Bauernregel
        /// Der erste Multiplikator ist außerhalb 
        /// der geometrischen Reihe 1,2,4,8,16.32...
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expectedResult"></param>
        [Test, TestCase(3, 8, 24)]
        [TestCase(6, 12, 72)]
        [TestCase(7, 2, 14)]
        [TestCase(10, 10, 100)]
        [TestCase(9, 3, 27)]
        [TestCase(3, 9, 27)]
        [TestCase(47, 42, 1974)]
        public void Mul_FirstParamOutsideGeometricFollow_ReturnsTrue(int? a, int? b, int? expectedResult)
        {
            // Arrange/Act
            var actual = BauernMultiplikation.Mul(a, b);
            // Assert 
            Assert.AreEqual(expectedResult, actual);
        }

        /// <summary>
        /// Wirft eine Ausnahme aus, wenn einer der Multiplikatoren kleiner 1 ist
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [Test, TestCase(-1,2)]
        [TestCase(3,-3)]
        [TestCase(-3,-5)]
        [TestCase(null, 2)]
        [TestCase(2, null)]
        public void Mul_ArgumentLowerThanOne_ThrowsException(int? a, int? b)
        {
            // Arrange / Act
            Func<int?, int?, int?> myFunc = BauernMultiplikation.Mul;
            // Assert
            Assert.Throws<InvalidOperationException>(() => myFunc(a, b)); 
        }
        
        



    }
}
