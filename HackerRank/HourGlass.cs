using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class HourGlass
    {
        public static int Solution(String[] args)
        {
            int[][] arr = new int[6][];
            for (int arr_i = 0; arr_i < 6; arr_i++)
            {
                string[] arr_temp = args[arr_i].Split(' '); //Console.ReadLine().Split(' ');
                arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
            }

            int output = CountHourGlass(arr);
            return output;
        }

        private static int CountHourGlass(int[][] arr)
        {
            int maxSum = int.MinValue;

            for(int i = 0; i < 4; i++)
            {                
                for (int j = 0; j < 4; j++)
                {
                    int one = arr[i][j];
                    int two = arr[i][j+1];
                    int three = arr[i][j+2];
                    int four = arr[i+1][j+1];
                    int five = arr[i+2][j];
                    int six = arr[i+2][j+1];
                    int seven = arr[i+2][j+2];
                    int hourGlassSum = one + two + three + four + five + six + seven;
                    maxSum = maxSum > hourGlassSum ? maxSum : hourGlassSum;
                }
            }

            return maxSum;
        }
    }

    [TestFixture]
    public class HourGlassShould
    {
        [Test]
        public void TestOne()
        {
            string[] array = new string[6];

            array[0] = "1 1 1 0 0 0";
            array[1] = "0 1 0 0 0 0";
            array[2] = "1 1 1 0 0 0";
            array[3] = "0 0 2 4 4 0";
            array[4] = "0 0 0 2 0 0";
            array[5] = "0 0 1 2 4 0";

            Assert.AreEqual(19, HourGlass.Solution(array));
        }       
        
        [Test]
        public void TestNegative()
        {
            string[] array = new string[6];

            array[0] = "-1 -1 0 -9 -2 -2";
            array[1] = "-2 -1 -6 -8 -2 -5";
            array[2] = "-1 -1 -1 -2 -3 -4";
            array[3] = "-1 -9 -2 -4 -4 -5";
            array[4] = "-7 -3 -3 -2 -9 -9";
            array[5] = "-1 -3 -1 -2 -4 -5";

            Assert.AreEqual(-6, HourGlass.Solution(array));
        }

    }
}
