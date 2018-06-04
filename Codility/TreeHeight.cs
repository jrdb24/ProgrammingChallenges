using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility
{
    class TreeHeight
    {
        public static int Solution(Tree T) //Scores 100%
        {
            if (T == null)
                return -1;
            return Math.Max(Solution(T.l) + 1, Solution(T.r) + 1);
        }
    }

    [TestFixture]
    public class TreeHeightSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Tree t = new Tree() { l = null, r = new Tree() { l = new Tree() { l = null, r = null, x = 30 }, r = null, x = 20 }, x = 10 };
            Assert.AreEqual(2, TreeHeight.Solution(t));
        }
    }

    //public class Tree
    //{
    //    public int x;
    //    public Tree l;
    //    public Tree r;
    //}
}



