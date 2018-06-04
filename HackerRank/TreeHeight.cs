using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class TreeHeight
    {
        static int lCount = 0;
        static int rCount = 0;

        public static int HeightRecursive(Tree root)
        {
            if (root == null)
                return -1;

            return Math.Max(HeightRecursive(root.l)+1, HeightRecursive(root.r)+1);
        }

        public static int HeightStackIterative(Tree root)
        {
            Queue<Tree> stack = new Queue<Tree>();
            int nodeCount = 0;
            int height = 0;
            stack.Enqueue(root);

            while (true)
            {
                nodeCount = stack.Count;

                if (nodeCount == 0)
                    return height-1;

                height++;

                while (nodeCount > 0)
                {
                    Tree temp = stack.Dequeue();

                    if (temp.l != null)
                        stack.Enqueue(temp.l);

                    if (temp.r != null)
                        stack.Enqueue(temp.r);

                    nodeCount--;
                }
            }
        }

        internal static double HeightRecursiveZZ(Tree root)
        {
            if (root == null)
                return -1;

            return (HeightRecursiveZZ(root.l) + 1) + (HeightRecursiveZZ(root.r) + 1);
        }
    }

    [TestFixture]
    public class TreeHeightShould
    {
        [Test]
        public void TestThree()
        {
            Tree root = new Tree(1);
            root.r = new Tree(2);
            //Assert.AreEqual(1, TreeHeight.HeightRecursive(root));
            Assert.AreEqual(1, TreeHeight.HeightStackIterative(root));
        }

        [Test]
        public void TestTwo()
        {
            Tree root = new Tree(1);
            root.l = new Tree(2);
            Assert.AreEqual(1, TreeHeight.HeightRecursiveZZ(root));
            Assert.AreEqual(1, TreeHeight.HeightStackIterative(root));
        }

        [Test]
        public void TestOne()
        {
            Tree root = new Tree(1);
            root.r = new Tree(2);
            root.r.r = new Tree(5);
            root.r.r.l = new Tree(3);
            root.r.r.r = new Tree(6);
            root.r.r.l.r = new Tree(4);

            Assert.AreEqual(4, TreeHeight.HeightRecursive(root));
            Assert.AreEqual(4, TreeHeight.HeightStackIterative(root));
        }
    }
}
