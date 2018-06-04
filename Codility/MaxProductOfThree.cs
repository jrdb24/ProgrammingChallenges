using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codility
{
    class MaxProductOfThree //Scores 100%
    {
        public static int Solution(int[] A)
        {
            List<int> values = A.OrderByDescending(c => c).ToList();
            int length = values.Count;

            int possHighest = values[0] * values[1] * values[2];
            int possHighestAgain = values[0] * values[length - 1] * values[length - 2];

            return Math.Max(possHighest, possHighestAgain);
        }
    }

    [TestFixture]
    public class MaxProductOfThreeSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(60, MaxProductOfThree.Solution(new int[] { -3, 1, 2, -2, 5, 6 }));
        }

        [Test]
        public void DoubleNegative()
        {
            Assert.AreEqual(125, MaxProductOfThree.Solution(new int[] { -5, 5, -5, 4 }));
        }

        [Test]
        public void TestSame()
        {
            Assert.AreEqual(216, MaxProductOfThree.Solution(new int[] { -3, 1, 2, -2, 5, 6, 6, 6 }));
        }

        [Test]
        public void TestNegativeAgain()
        {
            Assert.AreEqual(18018, MaxProductOfThree.Solution(new int[] { -3, 1, 2, -2, 5, 6, 6, 6, -1001 }));
        }

        [Test]
        public void TestNegative()
        {
            Assert.AreEqual(-1, MaxProductOfThree.Solution(new int[] { -3, -1, -2, -2, -1, -1 }));
        }

        [Test]
        public void ExceptionTest()
        {
            for (int i = 5; i < 100; i++)
            {
                Assert.DoesNotThrow(() => MaxProductOfThree.Solution(GenerateArray(i, -1000, 1000)));
            }
        }

        private Random _random = new Random();

        public int[] GenerateArray(int arraysize, int min, int max)
        {
            int[] array = new int[arraysize];

            for(int i = 0; i < arraysize; i++)
            {
                array[i] = _random.Next(min, max);
            }

            return array;
        }
    }
}
