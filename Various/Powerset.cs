using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace Various
{
    public class Powerset
    {
        public static List<List<string>> Solution(string[] set)
        {
            int lengthOfPowerSet = (int)Math.Pow(2, set.Count());
            List<List<string>> powerSet = new List<List<string>>();
            List<string> subset = new List<string>();

            for (int i = 0; i < lengthOfPowerSet; i++)
            {
                string asBinary = Convert.ToString(i, 2).PadLeft(set.Count(), '0');

                for (int j = 0; j < asBinary.Length; j++)
                    if (asBinary[j] == '1')
                        subset.Add(set.ElementAt(j));

                powerSet.Add(new List<string>(subset));
                subset.Clear();
            }

            PrintPowerset(powerSet);

            return powerSet;
        }

        private static void PrintPowerset(List<List<string>> powerSet)
        {
            foreach (List<string> p in powerSet.OrderBy(p => p.FirstOrDefault()))
            {
                string line = string.Empty;

                foreach (string s in p.OrderBy(o => o))
                {
                    line += s.ToString() + ",";
                }

                Trace.WriteLine(line.TrimEnd(','));
            }
        }
    }

    [TestFixture]
    public class PowersetSolutionShould
    {
        //[Test]
        //public void TestCounts()
        //{
        //    Assert.AreEqual(8, Powerset.Solution(new int[] { 1, 2, 3 }).Count);
        //    Assert.AreEqual(16, Powerset.Solution(new int[] { 1, 2, 3, 4 }).Count);
        //    Assert.AreEqual(32, Powerset.Solution(new int[] { 1, 2, 3, 4, 5 }).Count);
        //    Assert.AreEqual(64, Powerset.Solution(new int[] { 1, 2, 3, 4, 5, 6 }).Count);
        //}

        //[Test]
        //public void TestContentAgain()
        //{
        //    var list = Powerset.Solution(new string[] { "t", "o", "m", "m", "a", "r", "v", "o", "l", "o", "r", "i", "d", "d", "l", "e" });
        //    Assert.AreEqual(16, list.Count());

        //    //List<int> emptyList = new List<int>();
        //    //Assert.Contains(emptyList, list);

        //    //List<int> listWithJustOne = new List<int>() { 1 };
        //    //Assert.Contains(listWithJustOne, list);

        //    //List<int> listWithJustTwo = new List<int>() { 2 };
        //    //Assert.Contains(listWithJustTwo, list);

        //    //List<int> listWithJustThree = new List<int>() { 3 };
        //    //Assert.Contains(listWithJustThree, list);

        //    //List<int> listWith123 = new List<int>() { 1, 2, 3 };
        //    //Assert.Contains(listWith123, list);

        //    //List<int> listWith12 = new List<int>() { 1, 2 };
        //    //Assert.Contains(listWith12, list);

        //    //List<int> listWith13 = new List<int>() { 1, 3 };
        //    //Assert.Contains(listWith13, list);

        //    //List<int> listWith23 = new List<int>() { 2, 3 };
        //    //Assert.Contains(listWith23, list);
        //}

        //[Test]
        //public void TestContent()
        //{
        //    var list = Powerset.Solution(new int[] { 1, 2, 3, 4 });

        //    Assert.AreEqual(16, list.Count);

        //    List<int> emptyList = new List<int>();
        //    Assert.Contains(emptyList, list);

        //    List<int> listWithJustOne = new List<int>() { 1 };
        //    Assert.Contains(listWithJustOne, list);

        //    List<int> listWithJustTwo = new List<int>() { 2 };
        //    Assert.Contains(listWithJustTwo, list);

        //    List<int> listWithJustThree = new List<int>() { 3 };
        //    Assert.Contains(listWithJustThree, list);

        //    List<int> listWithJustFour = new List<int>() { 4 };
        //    Assert.Contains(listWithJustFour, list);

        //    List<int> listWith123 = new List<int>() { 1, 2, 3 };
        //    Assert.Contains(listWith123, list);

        //    List<int> listWith1234 = new List<int>() { 1, 2, 3, 4 };
        //    Assert.Contains(listWith1234, list);

        //    List<int> listWith23 = new List<int>() { 2, 3 };
        //    Assert.Contains(listWith23, list);

        //    List<int> listWith234 = new List<int>() { 2, 3, 4 };
        //    Assert.Contains(listWith234, list);

        //    List<int> listWith34 = new List<int>() { 3, 4 };
        //    Assert.Contains(listWith34, list);

        //    List<int> listWith134 = new List<int>() { 1, 3, 4 };
        //    Assert.Contains(listWith134, list);

        //    List<int> listWith24 = new List<int>() { 2, 4 };
        //    Assert.Contains(listWith24, list);

        //    List<int> listWith14 = new List<int>() { 1, 4 };
        //    Assert.Contains(listWith14, list);

        //    List<int> listWith12 = new List<int>() { 1, 2 };
        //    Assert.Contains(listWith12, list);

        //    List<int> listWith13 = new List<int>() { 1, 2 };
        //    Assert.Contains(listWith13, list);
        //}
    }
}
