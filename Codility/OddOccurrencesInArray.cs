using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codility
{
    class OddOccurrencesInArray
    {
        public static int Solution(int[] array) //Scores 100%
        {
            int appearsOddNumberOfTimes = 0;
            Dictionary<int,int> counter = new Dictionary<int, int>();

            foreach (int i in array)
            {
                if (counter.ContainsKey(i))
                    counter[i]++;
                else
                    counter.Add(i, 1);
            }

            appearsOddNumberOfTimes = counter.Where(a => a.Value % 2 == 1).Select(a => a.Key).Single();

            return appearsOddNumberOfTimes;
        }
    }

    [TestFixture]
    public class OddOccurrencesInArraySolutionShould
    {
        [Test]
        public void FirstTest()
        {
            Assert.AreEqual(7, OddOccurrencesInArray.Solution(new[] { 9, 3, 9, 3, 9, 7, 9 }));
            Assert.AreEqual(1, OddOccurrencesInArray.Solution(new[] { 9, 3, 9, 3, 9, 7, 9, 7, 1 }));
            Assert.AreEqual(1000001, OddOccurrencesInArray.Solution(new[] { 1, 1, 1, 1, 1, 1, 1000001, 1000001, 1000001 }));
        }

        /*
         * Assume that:
            N is an odd integer within the range [1..1,000,000];
            each element of array A is an integer within the range [1..1,000,000,000];
            all but one of the values in A occur an even number of times
         * 
         */

        [Test]
        public void ExceptionTest()
        {
            for (int i = 5; i < 100; i++)
            {
                if (i % 2 == 1)//odd
                    Assert.DoesNotThrow(() => OddOccurrencesInArray.Solution(GenerateRandomArray(i)));
            }
        }

        [Test]
        public void ExtremeTest()
        {
            var start = DateTime.Now;
            Assert.DoesNotThrow(() => OddOccurrencesInArray.Solution(GenerateRandomArray(1000000)));
            var end = DateTime.Now;
            Console.WriteLine("Time (ExtremeTest): " + (end - start).TotalMilliseconds + " ms");
        }

        private int[] GenerateRandomArray(int size)
        {
            Random r = new Random();

            List<int> array = new List<int>();

            for (int i = 0; i < size / 2; i++)
            {
                int random = r.Next(1, 10000000);
                array.Add(random);
                array.Add(random);
            }

            int loner = r.Next(1, 10000000);
            array.Add(loner);

            return array.ToArray();
        }
    }
}
