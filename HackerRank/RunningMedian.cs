using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class RunningMedian //Works but slow on hacker rank
    {
        public static List<double> Solution(int[] values)
        {
            List<int> medians = new List<int>();
            List<double> output = new List<double>();

            for(int i = 0; i < values.Length; i++)
            {
                medians.Add(values[i]);
                double currentRunningMedian = CalculateMedian(medians);
                output.Add(currentRunningMedian);
            }

            return output;
        }

        private static double CalculateMedian(List<int> medians)
        {
            medians.Sort();

            if(medians.Count % 2 == 0)
            {
                int first = medians[(medians.Count / 2) - 1];
                int second = medians[(medians.Count / 2)];
                return (((double)first + (double)second) / 2);
            }
            else
            {
                return (double)medians[(medians.Count - 1) / 2];
            }
        }
    }

    [TestFixture]
    public class RunningMedianShould
    {
        [Test]
        public void TestOne()
        {
            List<double> temp = RunningMedian.Solution(new int[] { 12, 4, 5, 3, 8, 7 });

            Assert.Contains(12.0, temp);
            Assert.Contains(8.0, temp);
            Assert.Contains(5.0, temp);
            Assert.Contains(4.5, temp);
            Assert.Contains(5.0, temp);
            Assert.Contains(6.0, temp);

            List<double> temp2 = RunningMedian.Solution(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            Assert.Contains(1.0, temp2);
            Assert.Contains(3.5, temp2);
            Assert.Contains(5.5, temp2);
            Assert.Contains(4.5, temp2);
            Assert.Contains(2.5, temp2);

            //1.0
            //1.5
            //2.0
            //2.5
            //3.0
            //3.5
            //4.0
            //4.5
            //5.0
            //5.5
        }
    }
}
