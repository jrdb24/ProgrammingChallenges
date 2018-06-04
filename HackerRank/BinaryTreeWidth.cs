using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace HackerRank
{
    public class BinaryTreeWidth
    {
        public static int MaxLevelWidthSolution(Tree root)
        {
            int height = GetHeightOfTree(root);
            int max = 0;

            int runningCountOfNodes = 0;

            for(int i = 1; i <= height; i++)
            {
                int temp = GetWidthOfLevel(root, i);
                runningCountOfNodes += temp;
                max = temp > max ? temp : max;
            }

            return max;
        }

        public static int AllNodeCountSolution(Tree root)
        {
            if (root == null)
                return 0;

            int leftCount = AllNodeCountSolution(root.l);
            int rightCount = AllNodeCountSolution(root.r);
            return leftCount + rightCount + 1;
        }





        public static int GetHeightOfTree(Tree node)
        {
            if (node == null)
                return 0;
            else
            {
                Trace.WriteLine(node.x);

                int lHeight = GetHeightOfTree(node.l);
                int rHeight = GetHeightOfTree(node.r);

                int height = (lHeight > rHeight) ? (lHeight + 1) : (rHeight + 1);
                return height;
            }
        }

        //TODO - do the below method iteratively

        public static int GetWidthOfLevel(Tree node, int level)
        {
            if (node == null)
                return 0;

            if (level == 1)
                return 1;
            else if (level > 1)
            {
                Trace.WriteLine(node.x);

                int leftLevelWidth = GetWidthOfLevel(node.l, level - 1);
                int rightLevelWidth = GetWidthOfLevel(node.r, level - 1);

                Trace.WriteLine("leftLevelWidth: " + leftLevelWidth + "rightLevelWidth: " + rightLevelWidth);

                return leftLevelWidth + rightLevelWidth;// GetWidthOfLevel(node.l, level - 1) + GetWidthOfLevel(node.r, level - 1);
            }
            return 0;
        }
    }

    [TestFixture]
    public class BinaryTreeWidthSolutionShould
    {
        //[Test]
        //public void TestWidthOfLevel()
        //{
        //    Tree root = new Tree();//root
        //    root.x = 0;
        //    root.l = new Tree();//1stlevel
        //    root.l.x = 1;
        //    root.r = new Tree();//1stlevel
        //    root.r.x = 2;
        //    root.r.l = new Tree();
        //    root.r.l.x = 5;
        //    root.r.r = null;
        //    root.l.l = new Tree();//2ndlevel
        //    root.l.l.x = 3;
        //    root.l.r = new Tree();//2ndlevel
        //    root.l.r.x = 4;

        //    Assert.AreEqual(3, BinaryTreeWidth.GetWidthOfLevel(root, 3));
        //}

        [Test]
        public void TestSimpleWidth()
        {
            Tree root = new Tree() { x = 0 };//root
            root.l = new Tree() { x = 1 };//1stlevel
            root.r = new Tree() { x = 2 };//1stlevel

            Assert.AreEqual(2, BinaryTreeWidth.GetWidthOfLevel(root, 2));
            Assert.AreEqual(2, BinaryTreeWidth.GetHeightOfTree(root));
            Assert.AreEqual(2, BinaryTreeWidth.MaxLevelWidthSolution(root));
            Assert.AreEqual(3, BinaryTreeWidth.AllNodeCountSolution(root));
            
        }

        [Test]
        public void TestThree()
        {
            Tree root = new Tree();//root
            root.x = 8;
            root.l = new Tree();//1stlevel
            root.l.x = 2;
            root.r = new Tree();//1stlevel
            root.r.x = 6;
            root.r.l = new Tree();
            root.r.l.x = 11;
            root.r.r = null;
            root.l.l = new Tree();//2ndlevel
            root.l.l.x = 8;
            root.l.r = new Tree();//2ndlevel
            root.l.r.x = 7;

            Assert.AreEqual(3, BinaryTreeWidth.MaxLevelWidthSolution(root));
            Assert.AreEqual(6, BinaryTreeWidth.AllNodeCountSolution(root));
            Assert.AreEqual(3, BinaryTreeWidth.GetHeightOfTree(root));
        }

        [Test]
        public void TestOne()
        {
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

            Assert.AreEqual(2, BinaryTreeWidth.MaxLevelWidthSolution(root));
            Assert.AreEqual(5, BinaryTreeWidth.AllNodeCountSolution(root));
            Assert.AreEqual(3, BinaryTreeWidth.GetHeightOfTree(root));
        }

        [Test]
        public void TestTwo()
        {
            Tree tree = new Tree(1);
            tree.l = new Tree(2);
            tree.r = new Tree(3);
            tree.l.l = new Tree(4);
            tree.l.r = new Tree(5);
            tree.r.r = new Tree(8);
            tree.r.r.l = new Tree(6);
            tree.r.r.r = new Tree(7);

            Assert.AreEqual(4, BinaryTreeWidth.GetHeightOfTree(tree));
            Assert.AreEqual(3, BinaryTreeWidth.MaxLevelWidthSolution(tree));
            Assert.AreEqual(8, BinaryTreeWidth.AllNodeCountSolution(tree));
        }

        
    }

    public class Tree
    {
        public int x;
        public Tree l;
        public Tree r;

        public Tree(int val = 0)
        {
            x = val;
        }
    }
}
