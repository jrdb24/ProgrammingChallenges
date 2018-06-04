using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    public class AnonymousTypes
    {
        public static int Test1(int[] A)
        {
            var myAnonymousType = new { first = A[0], second = A[1] };
            return myAnonymousType.first * myAnonymousType.second;
        }
    }

    public class Floor
    {
        public static double Test1()
        {
            double i = 1.9999999999d - (1.9999999999d % 1);
            return i;
        }
    }

    [TestFixture]
    public class FloorShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(1, Floor.Test1());
        }
    }

    [TestFixture]
    public class AnonymousTypesShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(4, AnonymousTypes.Test1(new int[] { 2, 2, 2, 2 }));
        }
    }
}
