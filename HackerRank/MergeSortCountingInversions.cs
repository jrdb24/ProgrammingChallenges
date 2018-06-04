using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class MergeSortCountingInversions    //works on hacker rank but slow
    {
        //public static List<int> Solution(string[] A)
        //{
        //    List<int> output = new List<int>();

        //    int t = Convert.ToInt32(A[0]);// Console.ReadLine());

        //    for (int a0 = 0; a0 < t*2; a0++)
        //    {
        //        int n = Convert.ToInt32(A[a0+1]);//(Console.ReadLine());
        //        string[] arr_temp = (A[a0 + 2]).Split(' ');//Console.ReadLine().Split(' ');
        //        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

        //        output.Add(NumberOfInversions(arr));
        //        a0++;
        //    }

        //    return output;
        //}

        //public static int NumberOfInversions(int[] array)
        //{
        //    int numInversions = 0;

        //    for(int i = 0; i < array.Length-1; i++)
        //    {
        //        int first = array[i];
        //        int second = array[i + 1];

        //        if(second < first)
        //        {
        //            array[i] = second;
        //            array[i + 1] = first;
        //            numInversions++;
        //        }
        //    }

        //    if (!ArrayIsOrdered(array))
        //        numInversions += NumberOfInversions(array);

        //    return numInversions;
        //}

        //private static bool ArrayIsOrdered(int[] array)
        //{
        //    for (int i = 0; i < array.Length - 1; i++)
        //    {
        //        int first = array[i];
        //        int second = array[i + 1];

        //        if (second < first)
        //        {
        //            return false;
        //        }
        //    }
        //    return true;
        //}

        public static int mergeSort(int[] array)
        {
            mergeSort(array, new int[array.Length], 0, array.Length - 1);
            return swaps;
        }

        private static void mergeSort(int[] array, int[] temp, int leftStart, int rightEnd)
        {
            if (leftStart >= rightEnd)
                return;

            int middle = (leftStart + rightEnd) / 2;
            mergeSort(array, temp, leftStart, middle);
            mergeSort(array, temp, middle +1, rightEnd);
            mergeHalves(array, temp, leftStart, rightEnd, middle);
        }

        private static int swaps = 0;

        private static void mergeHalves(int[] array, int[] temp, int leftStart, int rightEnd, int middle)
        {
            int leftEnd = (rightEnd + leftStart) / 2;
            int rightStart = leftEnd + 1;
            int size = rightEnd - leftStart + 1;

            int left = leftStart;
            int right = rightStart;
            int index = leftStart;

            while(left <= leftEnd && right <= rightEnd)
            {
                if(array[left] <= array[right])
                {
                    temp[index] = array[left];
                    left++;
                }
                else
                {
                    temp[index] = array[right];
                    swaps += middle + 1 - left;
                    right++;
                }
                index++;
            }

            Array.Copy(array, left, temp, index, leftEnd - left + 1);
            Array.Copy(array, right, temp, index, rightEnd - right + 1);
            Array.Copy(temp, leftStart, array, leftStart, size);
        }
    }

    [TestFixture]
    public class MergeSortCountingInversionsShould
    {
        //

        [Test]
        public void TestAgain()
        {
            MergeSortCountingInversions.mergeSort(new int[] { 2, 1, 3, 1, 2 });

            //Assert.AreEqual(4, MergeSortCountingInversions.mergeSort(new int[] { 2, 1, 3, 1, 2 }));
        }

        //[Test]
        //public void TestAgain()
        //{
        //    Assert.AreEqual(4, MergeSortCountingInversions.NumberOfInversions(new int[] { 2, 1, 3, 1, 2 }));
        //}

        //[Test]
        //public void TestBlah()
        //{
        //    Assert.AreEqual(0, MergeSortCountingInversions.NumberOfInversions(new int[] { 1, 1, 1, 2, 2 }));
        //}

        //[Test]
        //public void TestOne()
        //{
        //    List<int> temp = MergeSortCountingInversions.Solution(new string[] { "2", "5", "1 1 1 2 2", "5", "2 1 3 1 2" });
        //    Assert.Contains(0, temp);
        //    Assert.Contains(4, temp);
        //}
    }
}
