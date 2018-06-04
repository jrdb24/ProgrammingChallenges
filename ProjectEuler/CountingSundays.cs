using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ProjectEuler
{
    class CountingSundays
    {
        internal static double Solution()
        {
            DateTime startDate = new DateTime(1901, 01, 01);
            DateTime endDate = new DateTime(2000, 12, 31);
            int count = 0;

            while(startDate <= endDate)
            {
                if (startDate.DayOfWeek == DayOfWeek.Sunday && startDate.Day == 1)
                    count++;
                startDate = startDate.AddDays(1);
            }
            return count;
        }

        internal static double Solution(int v)
        {
            throw new NotImplementedException();
        }
    }

    [TestFixture]
    public class CountingSundaysShould
    {
        [Test]
        public void TestOne()
        {
            DateTime startDate = new DateTime(1901, 01, 01);
            DateTime endDate = new DateTime(2000, 12, 31);
            Assert.AreEqual(171, CountingSundays.Solution());
        }
    }
}
