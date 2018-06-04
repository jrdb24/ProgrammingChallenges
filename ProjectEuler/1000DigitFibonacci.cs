using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Numerics;
using System.Diagnostics;

namespace ProjectEuler
{
    class ThousandDigitFibonacci
    {
        internal static void Solution()
        {
            SortedSet<BigInteger> fibocaccis = new SortedSet<BigInteger>();
            BigInteger a = 0;
            BigInteger b = 1;
            BigInteger temp = 0;

            while(true)
            {
                temp = a + b;
                a = b;
                b = temp;
                fibocaccis.Add(temp);

                if (temp.ToString().Length == 1000)
                    Trace.WriteLine("Index: " + fibocaccis.Count);
            }
        }

        [TestFixture]
        public class ThousandDigitFibonacciShould
        {
            //[Test]
            //public void TestOne()
            //{
            //    Assert.AreEqual(2, ThousandDigitFibonacci.Solution());
            //}
        }
    }
}
