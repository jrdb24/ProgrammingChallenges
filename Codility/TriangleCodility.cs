using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Codility
{
    public class TriangleCodility
    {
        public static int Solution(int[] A)
        {
            if (A == null)
                return -1;

            int length = A.Length;

            if (length < 3)
                return -1;

            List<int> possibleMaximumSums = new List<int>();

            Array.Sort(A);

            for (int i = 0; i < length - 2; i++)
            {
                int P = A[i];
                int Q = A[i + 1];
                int R = A[i + 2];

                if ((P + Q > R) && (Q + R > P) && (R + P > Q))
                {
                    int sum = P + Q + R;
                    possibleMaximumSums.Add(sum);
                }
            }

            if (possibleMaximumSums.Count > 0)
                return possibleMaximumSums.Max();

            return -1;
        }
    }

    [TestFixture]
    public class TriangleCodilityShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(-1, TriangleCodility.Solution(null));

            Assert.AreEqual(-1, TriangleCodility.Solution(new int[] { 10, 20, 30 }));
            Assert.AreEqual(23, TriangleCodility.Solution(new int[] { 10, 2, 5, 1, 8, 20 }));
            Assert.AreEqual(25, TriangleCodility.Solution(new int[] { 5, 10, 18, 7, 8, 3 }));


            //Assert.AreEqual(-1, TriangleCodility.Solution(new int[] { 100000000, 100000000, 100000001 }));
        }

        [Test]
        public void ExceptionTest()
        {
            for (int i = 0; i < 100; i++)
            {
                Assert.DoesNotThrow(() => TriangleCodility.Solution(GenerateArray(i, -2147483648, 2147483647)));
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
