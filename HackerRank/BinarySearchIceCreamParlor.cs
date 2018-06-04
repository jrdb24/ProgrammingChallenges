using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class BinarySearchIceCreamParlor //Scores 100% on hacker rank
    {
        public static List<Tuple<int, int>> Solution(string[] args)
        {
            List<Tuple<int, int>> output = new List<Tuple<int, int>>();

            int t = Convert.ToInt32(args[0]); // (Console.ReadLine());

            for (int a0 = 0; a0 < t; a0++)
            {
                int target = Convert.ToInt32(args[(a0*3)+1]);// Console.ReadLine());
                int numberOfValues = Convert.ToInt32(args[(a0 * 3) + 2]);// Console.ReadLine());
                string[] a_temp = args[(a0 * 3) + 3].Split(' ');// Console.ReadLine().Split(' ');
                int[] values = Array.ConvertAll(a_temp, Int32.Parse);

                bool done = false;

                for (int i = 0; i < values.Length - 1; i++)
                {
                    int slow = values[i];                    

                    if (done)
                        break;

                    for (int j = i+1; j < values.Length; j++)
                    {                      
                        int fast = values[j];

                        if (slow + fast == target)
                        {
                            output.Add(new Tuple<int, int>(i + 1, j + 1));
                            done = true;
                            break;
                        }
                    }
                }

            }

            foreach (var v in output)
                Console.WriteLine(v.Item1 + " " + v.Item2);

            return output;
        }
    }

    [TestFixture]
    public class BinarySearchIceCreamParlorShould
    {
        [Test]
        public void TestBigger()
        {
            List<Tuple<int, int>> tempList = BinarySearchIceCreamParlor.Solution(new string[] { "1", "295", "17", "678 227 764 37 956 982 118 212 177 597 519 968 866 121 771 343 561" });
            Assert.Contains(new Tuple<int, int>(7, 9), tempList);

            List<Tuple<int, int>> tempList2 = BinarySearchIceCreamParlor.Solution(new string[] { "1", "100", "3", "5 75 25" });
            Assert.Contains(new Tuple<int, int>(2, 3), tempList2);
        }

        [Test]
        public void TestOne()
        {
            List<Tuple<int, int>> tempList = BinarySearchIceCreamParlor.Solution(new string[] { "2", "4", "5", "1 4 5 3 2", "4", "4", "2 2 4 3" });
            Assert.Contains(new Tuple<int, int>(1,4), tempList);
            Assert.Contains(new Tuple<int, int>(1, 2), tempList);
        }
    }
}
