using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BaseConversion.Tests
{
    using NUnit.Framework;
    [TestFixture]
    public class DecimalToBinaryTests
    {
        [Test]
        [TestCase(34, 100010)]
        [TestCase(6, 110)]
        [TestCase(5,101)]
        [TestCase(3,11)]
        public void BaseConversion_10to2(int arg1, int arg2)
        {
            Evaluate(arg1, arg2, 10, 2);
        }

        [Test]
        [TestCase(100010, 34)]
        [TestCase(110, 6)]
        [TestCase(101, 5)]
        [TestCase(11, 3)]
        public void BaseConversion_2to10(int arg1, int arg2)
        {
            Evaluate(arg1, arg2, 2, 10);
        }

        [Test]
        [TestCase(new[] {11, 1110}, 10001)]
        public void AddBinaryReturnBinary(int[] argInts, int result)
        {
            var output = new NumberWithBase(0,2);
            output = argInts.Aggregate(output, (current, argInt) => current + new NumberWithBase(argInt, 2));
            Assert.AreEqual(result, output.Value);
        }

        [Test]
        [TestCase(new[] { 1010,111 }, 17)]
        public void AddBinaryReturnDecimal(int[] argInts, int result)
        {
            var output = new NumberWithBase(0, 2);
            output = argInts.Aggregate(output, (current, argInt) => current + new NumberWithBase(argInt, 2));
            Console.Write(output.Value);
            output.ChangeBase(10);
            Assert.AreEqual(result, output.Value);
        }

        private static void Evaluate(int input, int expected, int sourceBase, int targetBase)
        {
            var test = new NumberWithBase(input, sourceBase);
            test.ChangeBase(targetBase);
            Assert.AreEqual(expected, test.Value);
        }
    }
}
