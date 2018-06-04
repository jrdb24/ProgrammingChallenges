using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Numerics;

namespace ProjectEuler
{
    class LargeSum
    {
        private static readonly string _inputFile = @"D:\My Documents\Visual Studio 2017\Projects\ProgrammingChallenges\Codility\input\largesum.txt";

        internal static string Solution()
        {
            //https://projecteuler.net/problem=13

            string[] lines = System.IO.File.ReadAllLines(_inputFile);
            List<BigInteger> bigInts = lines.Select(l => BigInteger.Parse(l)).ToList();
            var sum = bigInts.Aggregate(BigInteger.Add);
            return sum.ToString().Substring(0,10);
        }
    }

    [TestFixture]
    public class LargeSumShould
    {
        [Test]
        public void TestTwo()
        {
            Assert.AreEqual("5537376230", LargeSum.Solution());
        }

        [Test]
        public void TestOne()
        {
            BigInteger b = BigInteger.Parse("37107287533902102798797998220837590246510135740250");
        }
    }
}
