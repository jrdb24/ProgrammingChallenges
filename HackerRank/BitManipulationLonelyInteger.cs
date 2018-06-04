using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class BitManipulationLonelyInteger //Scores 100% on HackerRank
    {
        public static int Solution(int count, string lineofNumbers)
        {
            string[] a_temp = lineofNumbers.Split(' ');
            int[] A = Array.ConvertAll(a_temp, Int32.Parse);
            Array.Sort(A);

            int iterator = A.Min();
            int lonelyInteger = 0;

            for (int i = 0; i < A.Length; i= i + 2)
            {
                iterator = A[i];

                if (i + 1 == A.Length || A[i + 1] != iterator)
                {
                    lonelyInteger = A[i];
                    break;
                }
            }

            return lonelyInteger;
        }
    }

    [TestFixture]
    public class BitManipulationLonelyIntegerSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(2, BitManipulationLonelyInteger.Solution(5, "0 0 1 2 1"));
            Assert.AreEqual(2, BitManipulationLonelyInteger.Solution(3, "1 1 2"));
            Assert.AreEqual(95, BitManipulationLonelyInteger.Solution(9, "4 9 95 93 57 4 57 93 9"));
            Assert.AreEqual(8, BitManipulationLonelyInteger.Solution(17, "0 0 1 5 6 6 7 7 8 1 2 2 3 3 4 4 5"));
            Assert.AreEqual(3, BitManipulationLonelyInteger.Solution(17, "0 0 1 1 2 2 3 4 4 5 5 6 6 7 7 8 8"));
            Assert.AreEqual(9, BitManipulationLonelyInteger.Solution(17, "0 0 1 1 9"));
        }
    }
}
