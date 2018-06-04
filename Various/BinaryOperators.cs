using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    public class BinaryOperators
    {
        public static int BitwiseAnd(int val1, int val2)
        {
            //computes the logical bitwise AND (only if BOTH bits are set)
            return val1 & val2;
        }

        public static int BitwiseExclusiveOr(int val1, int val2)
        {
            //computes the bitwise exclusive-OR (only if one bit OR the other is set)
            return val1 ^ val2;
        }
        
        public static int LeftShift(int valueToShift, int numberOfBits)
        {
            //This is how you double using bitshift (shift 1 to left)
            return valueToShift << numberOfBits;
        }

        public static int RightShift(int valueToShift, int numberOfBits)
        {
            //This is how you halve using bitshift (shift 1 to right)
            return valueToShift >> numberOfBits;
        }
    }

    [TestFixture]
    public class BinaryOperatorsShould
    {
        [Test]
        public void TestRightShift()
        {
            Assert.AreEqual(0, BinaryOperators.RightShift(1, 1));
            Assert.AreEqual(1, BinaryOperators.RightShift(2, 1));
            Assert.AreEqual(10, BinaryOperators.RightShift(20, 1));
            Assert.AreEqual(9, BinaryOperators.RightShift(18, 1));
            Assert.AreEqual(3, BinaryOperators.RightShift(6, 1));
            Assert.AreEqual(42, BinaryOperators.RightShift(85, 1));
            Assert.AreEqual(21, BinaryOperators.RightShift(43, 1));
            Assert.AreEqual(1, BinaryOperators.RightShift(3, 1));
            Assert.AreEqual(3, BinaryOperators.RightShift(7, 1));
            Assert.AreEqual(6, BinaryOperators.RightShift(13, 1));
            Assert.AreEqual(10, BinaryOperators.RightShift(85, 3));
        }

        [Test]
        public void TestLeftShift()
        {
            Assert.AreEqual(2, BinaryOperators.LeftShift(1,1));
            Assert.AreEqual(4, BinaryOperators.LeftShift(1,2));
            Assert.AreEqual(8, BinaryOperators.LeftShift(1,3));
            Assert.AreEqual(16, BinaryOperators.LeftShift(1,4));
            Assert.AreEqual(22, BinaryOperators.LeftShift(11, 1));
            Assert.AreEqual(34, BinaryOperators.LeftShift(17, 1));
            Assert.AreEqual(40, BinaryOperators.LeftShift(20, 1));
            Assert.AreEqual(64, BinaryOperators.LeftShift(32, 1));
            Assert.AreEqual(80, BinaryOperators.LeftShift(10, 3));
            Assert.AreEqual(48, BinaryOperators.LeftShift(12, 2));
            Assert.AreEqual(56, BinaryOperators.LeftShift(14, 2));
        }

        [Test]
        public void TestBitwiseExclusiveOr()
        {
            Assert.AreEqual(3, BinaryOperators.BitwiseExclusiveOr(1, 2));
            Assert.AreEqual(11, BinaryOperators.BitwiseExclusiveOr(3, 8));
            Assert.AreEqual(2, BinaryOperators.BitwiseExclusiveOr(5, 7));
            Assert.AreEqual(31, BinaryOperators.BitwiseExclusiveOr(13, 18));
        }

        [Test]
        public void TestBitwiseAnd()
        {
            Assert.AreEqual(0, BinaryOperators.BitwiseAnd(1,2));
            Assert.AreEqual(1, BinaryOperators.BitwiseAnd(1, 3));
            Assert.AreEqual(0, BinaryOperators.BitwiseAnd(1, 4));
            Assert.AreEqual(1, BinaryOperators.BitwiseAnd(1, 5));
            Assert.AreEqual(0, BinaryOperators.BitwiseAnd(2,4));
            Assert.AreEqual(0, BinaryOperators.BitwiseAnd(2,8));
            Assert.AreEqual(10, BinaryOperators.BitwiseAnd(26, 10));
        }
    }
}
