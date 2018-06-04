using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class ArraysLeftRotation //Scores 100%
    {
        public static string Solution(int length, int numMoves, string arrayOfInts)
        {
            string[] a_temp = arrayOfInts.Split(' ');
            List<int> list = Array.ConvertAll(a_temp, Int32.Parse).ToList();
            int[] templist = new int[length];

            for (int i = 0; i < length; i++)
            {
                int position = (i - numMoves + length);
                int positionModLength = position % length;
                templist[positionModLength] = list[i];
            }

            return string.Join(" ", templist).TrimEnd();
        }
    }

    [TestFixture]
    public class ArraysLeftRotationSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("5 1 2 3 4", ArraysLeftRotation.Solution(5, 4, "1 2 3 4 5"));
            Assert.AreEqual("77 97 58 1 86 58 26 10 86 51 41 73 89 7 10 1 59 58 84 77", ArraysLeftRotation.Solution(20, 10, "41 73 89 7 10 1 59 58 84 77 77 97 58 1 86 58 26 10 86 51"));
        }
    }
}
