using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codility
{
    public class BinaryGapSolution //Scores 100%
    {
        public static int Solution(int n)
        {
            char[] binary = Convert.ToString(n, 2).ToCharArray();

            int maxZeroes = 0;

            for(int i = 0; i < binary.Length; i++)
            {
                int tempZeroCount = 0;

                if(binary[i] == '0')
                {
                    if (HasOneAfterwards(binary, i))
                    {
                        int temp = i;

                        while (binary[temp++] != '1')
                            tempZeroCount++;

                        if (tempZeroCount > maxZeroes)
                            maxZeroes = tempZeroCount;
                    }
                }
            }

            return maxZeroes;
        }

        private static bool HasOneAfterwards(char[] binary, int startAt)
        {
            int remaining = binary.Length - startAt;
            List<char> blah = binary.Skip(startAt).Take(remaining).ToList();

            if(blah.Contains('1'))
                return true;

            return false;
        }
    }

    [TestFixture]
    public class BinaryGapSolutionShould
    {
        [Test]
        public void FirstTest()
        {
            Assert.AreEqual(5, BinaryGapSolution.Solution(1041));
            Assert.AreEqual(0, BinaryGapSolution.Solution(6));
            Assert.AreEqual(0, BinaryGapSolution.Solution(4));
            Assert.AreEqual(2, BinaryGapSolution.Solution(9));
            Assert.AreEqual(28, BinaryGapSolution.Solution(1610612737));
            Assert.AreEqual(4, BinaryGapSolution.Solution(74901729));
        }

        [Test]
        public void ExceptionTest()
        {
            for (int i = 1; i < 1000; i++)
                Assert.DoesNotThrow(() => BinaryGapSolution.Solution(i));
        }
    }
}
