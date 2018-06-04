using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace ProjectEuler
{
    class HighlyDivisibleTriangularNumber
    {
        internal static long Solution(int limit)
        {
            List<long> triangles = CalculateTriangles(limit);

            foreach(long l in triangles)
            {
                int numDivisors = CalculateNumberOfDivisors(l);
                Trace.WriteLine("Number " + l + " has " + numDivisors + " divisors");

                if (numDivisors >= 500)
                    throw new Exception("Found it");
            }            

            return 0;
        }

        internal static int CalculateNumberOfDivisors(long value)
        {
            int numberOfDivisors = 0;
            long upTo = value;           

            for (int i = 1; i < upTo; ++i)
            {
                if (value % i == 0)
                {
                    upTo = value / i;

                    if (upTo != i)
                    {
                        numberOfDivisors++;
                    }
                    numberOfDivisors++;
                }
            }

            return numberOfDivisors;
        }

        private static List<long> CalculateTriangles(int limit)
        {
            List<long> triangles = new List<long>() { 1 };

            for(int i = 2; i < limit; i++)
                triangles.Add(triangles[i - 2] + i);

            return triangles;
        }
    }

    [TestFixture]
    public class HighlyDivisibleTriangularNumberShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(4, HighlyDivisibleTriangularNumber.CalculateNumberOfDivisors(15));
            Assert.AreEqual(6, HighlyDivisibleTriangularNumber.CalculateNumberOfDivisors(28));
        }

        [Test]
        public void TestBigInteger()
        {
            System.Numerics.BigInteger b = System.Numerics.BigInteger.Parse("37107287533902102798797998220837590246510135740250");
        }
    }
}
