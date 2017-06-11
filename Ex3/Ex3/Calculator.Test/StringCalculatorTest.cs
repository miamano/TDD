using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Calculator.Test
{
    [TestFixture]
    public class StringCalculatorTest
    {
        private StringCalculator sut;

        [SetUp]
        public void Setup()
        {
            sut = new StringCalculator();
        }

        [Test]
        public void InputEmptyString()
        {
            var result = sut.Add("");

            Assert.AreEqual(result, 0);
        }

        [Test]
        public void InputOneNumber()
        {
           var result = sut.Add("5");

           Assert.AreEqual(result, 5);
        }

        [Test]
        public void InputTwoNumbers()
        {
            var result = sut.Add("2,5");

            Assert.AreEqual(result, 7);
        }

        [Test]
        public void InputAnyNumbers()
        {
            var result = sut.Add("2,5,7,9,11");
            var result2 = sut.Add("2,5,7,9,11,20,25,35");

            Assert.AreEqual(result, 34);
            Assert.AreEqual(result2, 114);
        }

        [Test]
        public void InputAnyAndEmptyNumbers()
        {
            var result = sut.Add("2,5,,9,11");

            Assert.AreEqual(result, 27);
        }

        [Test]
        public void InputAnyNumberIncludingNewLines()
        {
            var result = sut.Add("2,5\n6,9,11");

            Assert.AreEqual(result, 33);
        }

        [Test]
        public void InputAnyNumberAnyDelimiters()
        {
            var result = sut.Add("//;\n2;5\n6;9;11");

            Assert.AreEqual(result, 33);
        }

        [Test]
        public void InputNegativenumbers()
        {
            Assert.Throws<NegativeNumbersNotAllowedException>(() => sut.Add("5,6,-9,11"));
        }

        [Test]
        public void InputGreatNumbers()
        {
            var result = sut.Add("2,1005,8,2876");

            Assert.AreEqual(result, 10);
        }

        [Test]
        public void AllowAnyLengthOfDelimiters()
        {
            var result = sut.Add("//***\n1***2***3");

            Assert.AreEqual(result, 6);
        }

        [Test]
        public void AllowMultipleDelimiters()
        {
            var result = sut.Add("//*%\n1*2%3");

            Assert.AreEqual(result, 6);
        }
    }
}
