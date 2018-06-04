using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class CompareTheTriplets
    {
        public static int[] solve(int a0, int a1, int a2, int b0, int b1, int b2)
        {
            int alice = 0;
            int bob = 0;

            Compare(a0, b0, ref alice, ref bob);
            Compare(a1, b1, ref alice, ref bob);
            Compare(a2, b2, ref alice, ref bob);

            List<int> temp = new List<int>() { alice, bob };
            return temp.ToArray();
        }

        private static void Compare(int a, int b, ref int alice, ref int bob)
        {
            if (a > b)
                alice++;
            else if (a < b)
                bob++;
        }
    }

    [TestFixture]
    public class CompareTheTripletsShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(new List<int>() { 1, 1 }.ToArray(), CompareTheTriplets.solve(5,6,7,3,6,10));
            Assert.AreEqual(new List<int>() { 0, 3 }.ToArray(), CompareTheTriplets.solve(6, 8, 12, 7, 9, 15));
        }
    }
}
