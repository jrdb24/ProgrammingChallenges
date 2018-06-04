using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    public class EvenFibonacciNumbers
    {
        public static int Solution()
        {
            int upTo = 4000000;
            SortedSet<int> Fibocaccis = CreateEvenFibonaccis(upTo);


            return Fibocaccis.Sum();
        }

        private static SortedSet<int> CreateEvenFibonaccis(int upTo)
        {
            SortedSet<int> fibocaccis = new SortedSet<int>();

            int a = 0;
            int b = 1;
            int temp = 0;

            while(temp < upTo)
            {
                temp = a + b;
                a = b;
                b = temp;
                if(temp % 2 == 0)
                    fibocaccis.Add(temp);
            }

            return fibocaccis;
        }

        private static SortedSet<int> CreateFibonacci(int upTo)
        {
            SortedSet<int> fibocaccis = new SortedSet<int>();

            int a = 0;
            int b = 1;
            int temp = 0;

            for (int i = 0; i < upTo; i++)
            {
                temp = a + b;
                a = b;
                b = temp;
                fibocaccis.Add(temp);
            }

            return fibocaccis;
        }

        public static List<int> CreateFibonaccis(int upTo)
        {
            int i = 0;
            int j = 1;
            int result = 0;

            List<int> fibonaccis = new List<int>();

            while (result <= upTo)
            {
                result = i + j;
                i = j;
                j = result;

                fibonaccis.Add(result);
            }

            return fibonaccis;
        }
    }

    [TestFixture]
    public class EvenFibonacciNumbersShould
    {

        [Test]
        public void TestBlah()
        {
            List<int> temp = new List<int>();
            temp = EvenFibonacciNumbers.CreateFibonaccis(13);

            Assert.Contains(1, temp);
            Assert.Contains(2, temp);
            Assert.Contains(3, temp);
            Assert.Contains(5, temp);
            Assert.Contains(8, temp);
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual(4613732, EvenFibonacciNumbers.Solution());
        }
    }
}

