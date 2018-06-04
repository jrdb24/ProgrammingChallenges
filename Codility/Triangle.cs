using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Codility
{
    class Triangle
    {
        public static int Solution(int[] A) //Gets 100%
        {
            int length = A.Length;

            if (length < 3)
                return 0;

            Array.Sort(A);

            for (int i = 0; i < length - 2; i++)
            {
                Int64 P = A[i];     //Int64 to handle Int32.MaxValue case
                Int64 Q = A[i + 1];
                Int64 R = A[i + 2];

                if ((P + Q > R) && (Q + R > P) && (R + P > Q))
                {
                    return 1;
                }
            }

            return 0;
        }

        [TestFixture]
        public class TriangleSolutionShould
        {
            [Test]
            public void TestOne()
            {
                Assert.AreEqual(1, Triangle.Solution(new int[] { 10, 2, 5, 1, 8, 20 }));
                Assert.AreEqual(0, Triangle.Solution(new int[] { 10, 50, 5, 1 }));

                Assert.AreEqual(0, Triangle.Solution(new int[] {1, 1, 2, 3, 5 }));
            }

            [Test]
            public void TestExtreme()
            {
                Assert.AreEqual(1, Triangle.Solution(new int[] { Int32.MaxValue, Int32.MaxValue, Int32.MaxValue }));
            }
        }

        [Test]
        public void ExceptionTest()
        {
            for (int i = 0; i < 100; i++)
            {
                Assert.DoesNotThrow(() => Triangle.Solution(GenerateArray(i, -2147483648, 2147483647)));
            }
        }

        private Random _random = new Random();

        public int[] GenerateArray(int arraysize, int min, int max)
        {
            int[] array = new int[arraysize];

            for (int i = 0; i < arraysize; i++)
            {
                array[i] = _random.Next(min, max);
            }

            return array;
        }
    }
}


