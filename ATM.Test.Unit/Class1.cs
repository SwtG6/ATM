using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using NUnit.Framework;

namespace ATM.Test.Unit
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Add_TwoNumbers_ReturnEquals1()
        {
            // Arrange
            var uut = new Calc();

            // Act
            uut.add(2, 3);

            // Assert
            Assert.That(uut.add(2, 3), Is.EqualTo(5));
        }
    }
}
