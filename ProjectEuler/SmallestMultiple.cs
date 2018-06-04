using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    class SmallestMultiple
    {
        public static int Solution(int start, int end)
        {
            int lowestPossibleValue = end * 2;

            for (int i = lowestPossibleValue; i < Int32.MaxValue; i=i+end)
            {
                bool divisibleByAll = true;

                for (int j = start; j < end; j++)
                {
                    if (i % j != 0)
                    {
                        divisibleByAll = false;
                        break;
                    }
                }

                if (divisibleByAll)
                    return i;
            }

            return 0;
        }
    }

    [TestFixture]
    public class SmallestMultipleShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(2520, SmallestMultiple.Solution(1, 10));
            //Below is correct but takes a long time. Surely can try and parallelize?
            //Assert.AreEqual(232792560, SmallestMultiple.Solution(1, 20));//
        }
    }
}
