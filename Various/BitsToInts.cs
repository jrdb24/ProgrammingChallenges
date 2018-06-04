using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace Various
{
    public class BitsToInts
    {
        public static int Solution(string input)
        {
            int output = 0;

            if((input[input.Length - 1]) == '1')
                output = 1;

            for(int i = input.Length-2; i >= 0; i--)
            {
                var value = input[i];
                if(value == '1')
                {
                    int temp = input.Length - (i + 1);
                    int blah = (int)Math.Pow((double)2, (double)temp);
                    output += blah;
                }
            }

            return output;
        }
    }

    [TestFixture]
    public class BitsToIntsShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(12, BitsToInts.Solution("1100"));
            Assert.AreEqual(24, BitsToInts.Solution("11000"));
            Assert.AreEqual(96, BitsToInts.Solution("1100000"));
            Assert.AreEqual(3, BitsToInts.Solution("11"));
            Assert.AreEqual(1, BitsToInts.Solution("1"));

            Assert.AreEqual(12, Convert.ToInt32("1100", 2));
        }
    }
}
