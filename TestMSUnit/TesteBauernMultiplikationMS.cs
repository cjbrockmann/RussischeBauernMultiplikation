using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RussischeBauernMultiplikation;

namespace TestMSUnit
{

    [TestClass]
    public class TesteMSBauernMultiplikation
    {
        
        /// <summary>
        /// Entsprechend der Bauernregel
        /// Der erste Multiplikator ist innerhalb 
        /// der geometrischen Reihe 1,2,4,8,16.32...
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expectedResult"></param>
        [DataTestMethod]
        [DataRow(2, 8, 16)]
        [DataRow(4, 12, 48)]
        [DataRow(8, 2, 16)]
        public void Mul_FirstParamIsInGeometricFollow_ReturnsTrue(int? a, int? b, int? expectedResult)
        {
            // Arrange/Act
            var actual = BauernMultiplikation.Mul(a, b);
            // Assert 
            Assert.AreEqual(expectedResult, actual);

        }




        /// <summary>
        /// Entsprechend der Bauernregel
        /// Der erste Multiplikator ist AUSSERHALB der geometrischen Reihe 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="expectedResult"></param>
        [DataTestMethod]
        [DataRow(3, 8, 24)]
        [DataRow(6, 12, 72)]
        [DataRow(7, 2, 14)]
        [DataRow(10, 10, 100)]
        [DataRow(9, 3, 27)]
        [DataRow(3, 9, 27)]
        [DataRow(47, 42, 1974)]

        public void Mul_FirstParamOutsideGeometricFollow_ReturnsTrue(int? a, int? b, int? expectedResult)
        {
            // Arrange/Act
            var actual = BauernMultiplikation.Mul(a, b);
            // Assert 
            Assert.AreEqual(expectedResult, actual);
        }

        /// <summary>
        /// Wirft eine Ausnahme aus, wenn einer der Multiplikatoren kleiner 1 oder null ist
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [DataTestMethod]
        [DataRow(-1, 2)]
        [DataRow(3, -3)]
        [DataRow(-3, -5)]
        [DataRow(null, -5)]
        [DataRow(-5,int.MaxValue)]
        public void Mul_ArgumentLowerThanOneOrNull_ThrowsException(int? a, int? b)
        {
            // Arrange / Act
            Func<int?, int?, int?> myFunc = BauernMultiplikation.Mul;
            // Assert
            Assert.ThrowsException<InvalidOperationException>(() => myFunc(a, b));
        }

        /// <summary>
        /// Beim Überlauffehler soll eine Ausnahme ausgelöst werden.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        [DataTestMethod]
        [DataRow(3, int.MaxValue / 2)]
        [DataRow(int.MaxValue / 2, 3)]
        public void Mul_TesteMitMax(int? a, int? b)
        {
            // Arrange
            int x = a ?? default(int);
            int y = b ?? default(int);
            Func<int?, int?, int?> myFunc = BauernMultiplikation.Mul;
            // Act //Assert 
            Assert.ThrowsException<OverflowException>(() => myFunc(x, y));

        }

        /// <summary>
        /// Getested wird, ob bei der Division immer stets Math.Floor herauskommt. 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        [DataTestMethod]
        [DataRow(11, 3, 3)]
        [DataRow(12, 3, 4)]
        [DataRow(14, 3, 4)]
        public void DivideHelper_TestenDerPrivatenMethode(int? a, int? b, int? result)
        {
            // Arrange 
            PrivateType privateTypeObject = new PrivateType(typeof(BauernMultiplikation));
            // Act
            object obj = privateTypeObject.InvokeStatic("DivideHelper", a, b);
            // Assert
            Assert.AreEqual(result, (int)obj);
        }

        /// <summary>
        /// Testen, ob die Berechnung gemacht werden kann
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        [DataTestMethod]
        [DataRow(11, 3, true)]
        [DataRow(12, 3, true)]
        [DataRow(14, 3, true)]
        public void KannBerechnetWerden_IstMoeglich_ReturnsTrue(int? a, int? b, bool result)
        {
            // Arrange 
            bool? actual = null;
            // Act 
            actual = BauernMultiplikation.KannBerechnetWerden(a, b);
            // Assert
            Assert.AreEqual(result, actual);
        }


        /// <summary>
        /// Testen, ob bei falscher Eingabe, diese Funktion false zurückgibt
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="result"></param>
        [DataTestMethod]
        [DataRow(-2, 3, false)]
        [DataRow(12, -5, false)]
        [DataRow(-4, -3, false)]
        [DataRow(4, null, false)]
        [DataRow(null, -5, false)]
        public void KannBerechnetWerden_KeineBerechnungMoeglich_ReturnsTrue(int? a, int? b, bool result)
        {
            // Arrange 
            bool? actual = null;
            // Act 
            actual = BauernMultiplikation.KannBerechnetWerden(a, b);
            // Assert
            Assert.AreEqual(result, actual);
        }



    }





}
