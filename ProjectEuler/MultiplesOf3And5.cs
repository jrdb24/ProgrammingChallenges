using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    public class MultiplesOf3And5
    {
        public static int Solution()
        {
            return Enumerable.Range(0, 1000).Where(i => i % 3 == 0 || i % 5 == 0).Sum();
        }
    }

    [TestFixture]
    public class MultiplesOf3And5Should
    {
        [Test]
        public void TestMultiplesOf3And5()
        {
            Assert.AreEqual(233168, MultiplesOf3And5.Solution());
        }
    }
}

