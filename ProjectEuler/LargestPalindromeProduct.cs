using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    class LargestPalindromeProduct
    {
        public static int Solution(int l, int r)
        {
            int left = l;
            int right = r;

            int largestPalindrome = 0;

            for (int i = left; i > 0; i--)
            {
                for (int j = right; j > 0; j--)
                {
                    if(IsPalinDrome((i * j).ToString()))
                    {
                        largestPalindrome = Math.Max(largestPalindrome, i * j);
                    }
                }
            }

            return largestPalindrome;
        }

        private static bool IsPalinDrome(string value)
        {
            char[] backwards = value.ToCharArray();
            Array.Reverse(backwards);

            if (value == new string(backwards))
            {
                return true;
            }
            return false;
        }
    }

    [TestFixture]
    public class LargestPalindromeProductShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(9, LargestPalindromeProduct.Solution(9, 9));
            Assert.AreEqual(9009, LargestPalindromeProduct.Solution(99,99));

            Assert.AreEqual(906609, LargestPalindromeProduct.Solution(999, 999));
        }
    }
}