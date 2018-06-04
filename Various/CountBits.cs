using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    public class CountBits
    {
        public static int CountOnes(int number)
        {
            char[] binary = Convert.ToString(number, 2).ToCharArray();
            int numberOfSetbits =  0;

            for (int i = 0; i < binary.Length; i++)
                if (binary[i] == '1')
                    numberOfSetbits++;

            return numberOfSetbits;
        }

        public static int CountZeroes(int number)
        {
            char[] binary = Convert.ToString(number, 2).ToCharArray();

            int zeroes = 0;

            for (int i = 0; i < binary.Length; i++)
                if (binary[i] == '0')
                    zeroes++;

            return zeroes;
        }

        //If lower most bit is one add it to the sum, then shift the bits in the number to remove the lower most bit
        public static int CountOnesUsingBitShift(int value)
        {
            int sum = 0;

            while (value > 0)
            {
                sum += value & 0x01;
                value >>= 1;
            }

            return sum;
        }
    }

    [TestFixture]
    public class CountBitsSolutionShould
    {
        [Test]
        public void TestProp()
        {
            Assert.AreEqual(2, CountBits.CountOnes(3));
            Assert.AreEqual(3, CountBits.CountOnes(7));
            Assert.AreEqual(1, CountBits.CountOnes(4));
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual(1, CountBits.CountOnes(1));

            Assert.AreEqual(1, CountBits.CountOnesUsingBitShift(1));

            Assert.AreEqual(0, CountBits.CountOnes(0));
            Assert.AreEqual(0, CountBits.CountZeroes(1));
            Assert.AreEqual(1, CountBits.CountZeroes(0));

            Assert.AreEqual(8, CountBits.CountOnes(10000000));
            Assert.AreEqual(16, CountBits.CountZeroes(10000000));

            Assert.AreEqual(6, CountBits.CountOnes(9741));

            Assert.AreEqual(31, CountBits.CountOnes(int.MaxValue));

            Assert.AreEqual(31, CountBits.CountOnesUsingBitShift(int.MaxValue));
        }
    }
}
