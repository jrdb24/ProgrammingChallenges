using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class RecursionStaircase
    {
        Dictionary<int, int> values = new Dictionary<int, int>();

        public static int Solution(int numberOfStairs)
        {
            return CountPossibleWaysUpStairs(numberOfStairs);
        }

        public static int CountPossibleWaysUpStairs(int numberOfStairs)
        {
            if (numberOfStairs == 0)
                return 0;

            if (numberOfStairs == 1)
                return 1;

            if (numberOfStairs == 2)
                return 2;

            int[] array = new int[numberOfStairs];

            array[0] = 1;
            array[1] = 2;
            array[2] = 4;

            for(int i = 3; i < numberOfStairs; i++)
            {
                array[i] = array[i-1] + array[i-2] + array[i-3];
            }

            return array[array.Length-1];
        }
    }

    [TestFixture]
    public class RecursionStaircaseShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(0, RecursionStaircase.CountPossibleWaysUpStairs(0));
            Assert.AreEqual(1, RecursionStaircase.CountPossibleWaysUpStairs(1));
            Assert.AreEqual(2, RecursionStaircase.CountPossibleWaysUpStairs(2));
            Assert.AreEqual(4, RecursionStaircase.CountPossibleWaysUpStairs(3));
            Assert.AreEqual(7, RecursionStaircase.CountPossibleWaysUpStairs(4));
            Assert.AreEqual(13, RecursionStaircase.CountPossibleWaysUpStairs(5));
            Assert.AreEqual(24, RecursionStaircase.CountPossibleWaysUpStairs(6));
            Assert.AreEqual(44, RecursionStaircase.CountPossibleWaysUpStairs(7));
        }
    }
}
