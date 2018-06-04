using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Codility
{
    class Helper
    {
        private static Random _random = new Random();

        public static int[] GenerateRandomArray(int arraysize, int min, int max)
        {
            int[] array = new int[arraysize];

            for (int i = 0; i < arraysize; i++)
            {
                array[i] = _random.Next(min, max);
            }

            return array;
        }

        public static int[] GenerateContiguousArray(int arraysize, int startAt)
        {
            int[] array = new int[arraysize];
            int count = 0;

            //for (int i = startAt; i < arraysize + 1; i++)
            //{
            //    array[count++] = i;
            //}

            for (int i = 0; i < arraysize; i++)
            {
                array[count++] = startAt++;
            }

            return array;
        }

        public static int[] GenerateDistinctArray(int arraysize, int min, int max)
        {
            List<int> intList = new List<int>();

            while(intList.Count < arraysize)
            {
                int temp = _random.Next(min, max);

                if(!intList.Contains(temp))
                {
                    intList.Add(temp);
                }
            }

            return intList.ToArray();
        }

        //List<Int64> range = (from i in Enumerable.Range(A, (B-A)+1) select (Int64)i).ToList();

        [TestFixture]
        public class ArraysShould
        {
            [Test]
            public void ContiguousArrayShould()
            {
                List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
                Assert.AreEqual(list.ToArray(), Helper.GenerateContiguousArray(10, 1));
            }
        }
    }
}
