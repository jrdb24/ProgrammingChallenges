using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Codility
{
    class CodilityTreeHeightVisible
    {
        public static int Solution(Tree T)
        {
            if (T.l == null && T.r == null)
                return 1;

            return VisibleRecursiveCount(T);
        }

        private static int VisibleRecursiveCount(Tree T, int currentHighestNodeValue = 0)
        {
            if (T == null) //Tree has no nodes
                return 0;

            if (currentHighestNodeValue == 0)
            {
                //First iteration, so set the currentHighestNodeValue
                currentHighestNodeValue = T.x;
            }

            if (currentHighestNodeValue <= T.x)
            {
                //Visible node, so increment count by 1
                return VisibleRecursiveCount(T.l, T.x) + VisibleRecursiveCount(T.r, T.x) + 1;
            }
            else
            {
                //Node is not visible, so no increment
                return VisibleRecursiveCount(T.l, currentHighestNodeValue) + VisibleRecursiveCount(T.r, currentHighestNodeValue);
            }
        }
    }

    [TestFixture]
    public class CodilityTreeHeightVisibleSolutionShould
    {
        [Test]
        public void TestOne()
        {
            //Tree t = new Tree() { l = null, r = new Tree() { l = new Tree() { l = null, r = null, x = 30 }, r = null, x = 20 }, x = 10 };
            //Assert.AreEqual(2, CodilityTreeHeightVisible.Solution(t));

            Tree root = new Tree();//root
            root.x = 8;
            root.l = new Tree();//1stlevel
            root.l.x = 2;
            root.r = new Tree();//1stlevel
            root.r.x = 6;
            root.r.l = null;
            root.r.r = null;
            root.l.l = new Tree();//2ndlevel
            root.l.l.x = 8;
            root.l.r = new Tree();//2ndlevel
            root.l.r.x = 7;

            Assert.AreEqual(2, CodilityTreeHeightVisible.Solution(root));
        }

        [Test]
        public void TestTwo()
        {
            Tree root = new Tree();//root
            root.x = 8;
            Assert.AreEqual(1, CodilityTreeHeightVisible.Solution(root));
        }
    }

    public class Tree
    {
        public int x;
        public Tree l;
        public Tree r;
    }
}



