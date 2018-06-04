using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class SortingBubbleSort //Scores 100%
    {
        public static string Solution(int arraySize, string[] array)
        {
            int n = arraySize;// Convert.ToInt32(Console.ReadLine());
            string[] a_temp = array;// Console.ReadLine().Split(' ');
            int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            int totalSwaps = 0;

            int temp1 = 0;
            int temp2 = 0;

            for (int i = 0; i < n; i++)
            {
                // Track number of elements swapped during a single array traversal
                int numberOfSwaps = 0;

                for (int j = 0; j < n - 1; j++)
                {
                    // Swap adjacent elements if they are in decreasing order
                    if (a[j] > a[j + 1])
                    {
                        temp1 = a[j];
                        temp2 = a[j + 1];
                        a[j] = temp2;
                        a[j + 1] = temp1;
                        numberOfSwaps++;
                    }
                }

                totalSwaps += numberOfSwaps;

                // If no elements were swapped during a traversal, array is sorted
                if (numberOfSwaps == 0)
                {
                    break;
                }
            }

            return "Array is sorted in " + totalSwaps + " swaps.\nFirst Element: " + a[0] + "\nLast Element: " + a[arraySize-1];
        }
    }

    [TestFixture]
    public class SortingBubbleSortSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("Array is sorted in 3 swaps.\nFirst Element: 1\nLast Element: 3", SortingBubbleSort.Solution(3, new string[] { "3", "2", "1" }));
            Assert.AreEqual("Array is sorted in 3 swaps.\nFirst Element: 1\nLast Element: 6", SortingBubbleSort.Solution(6, new string[] { "3", "2", "1", "4", "5", "6" }));
        }
    }
}
