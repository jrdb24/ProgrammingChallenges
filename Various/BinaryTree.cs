using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace Various
{
    class BinaryTree
    {
        internal static int CountLeaves(Tree root)
        {
            //A node is a leaf node if both left and right children of it are NULL
            if (root == null)
                return 0;

            if (root.l == null && root.r == null)
            {
                return 1;
            }
            else
            {
                int lc = CountLeaves(root.l);
                int rc = CountLeaves(root.r);
                return lc + rc;
            }

        }

        internal static Tree DeleteNode(Tree root, Tree toDelete)
        {
            if (root == null)
            {
                return root;
            }
            if (toDelete.x < root.x)
            {
                root.l = DeleteNode(root.l, toDelete);
            }
            if (toDelete.x > root.x)
            {
                root.r = DeleteNode(root.r, toDelete);
            }

            if (toDelete.x == root.x)
            {                
                if (root.l == null && root.r == null) //No child nodes at all
                {
                    root = null;
                    return root;
                }
                else if (root.l == null)  //No left child
                {
                    Tree temp = root;
                    root = root.r;
                    temp = null;
                }                
                else if (root.r == null) //No right child
                {
                    Tree temp = root;
                    root = root.l;
                    temp = null;
                }
                else //Has both child nodes
                {
                    Tree min = GetMinValue(root.r);
                    root.x = min.x;
                    root.r = DeleteNode(root.r, min);
                }
            }
            return root;
        }

        public static Tree GetMinValue(Tree node)
        {
            Tree cur = node;
            while (cur.l != null)
                cur = cur.l;
            return cur;
        }

        internal static Tree AddNode(Tree root, int valueToAdd)
        {
            if(root == null)
            {
                root = new Tree();
                root.x = valueToAdd;
                root.l = null;
                root.r = null;                
            }
            else
            {
                if (valueToAdd < root.x)
                {
                    root.l = AddNode(root.l, valueToAdd);
                }
                else
                {
                    root.r = AddNode(root.r, valueToAdd);
                }
            }

            return root;
        }

        internal static int CountAllNodes(Tree root)
        {
            if (root == null)
                return 0;

            Queue<Tree> queue = new Queue<Tree>();

            int rootCount = 1;
            int rcount = 0;
            int lcount = 0;

            queue.Enqueue(root);

            while(queue.Count != 0)
            {
                Tree temp = queue.Dequeue();

                if (temp.l != null)
                {
                    lcount++;
                    queue.Enqueue(temp.l);
                }
                if (temp.r != null)
                {
                    rcount++;
                    queue.Enqueue(temp.r);
                }
            }

            return rootCount + rcount + lcount;
        }

        public static int GetHeightOfTree(Tree node)
        {
            if (node == null)
                return 0;
            else
            {
                int lHeight = GetHeightOfTree(node.l);
                int rHeight = GetHeightOfTree(node.r);

                int height = (lHeight > rHeight) ? (lHeight + 1) : (rHeight + 1);
                return height;
            }
        }

        internal static void printNode(Tree root)
        {
            if (root != null)
            {
                Trace.WriteLine(root.x);
                printNode(root.l);
                printNode(root.r);
            }
        }
    }

    [TestFixture]
    public class BinaryTreeShould
    {
        [Test]
        public void TestDelete()
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


            Assert.AreEqual(6, BinaryTree.CountAllNodes(root));
            Tree temp = BinaryTree.DeleteNode(root, root.l);
            Assert.AreEqual(5, BinaryTree.CountAllNodes(temp));
        }

        [Test]
        public void TestAdd()
        {
            Tree root = new Tree();
            root.x = 8;
            Tree temp = BinaryTree.AddNode(root, 12);

            Assert.AreEqual(1, BinaryTree.CountLeaves(temp));
            Assert.AreEqual(2, BinaryTree.CountAllNodes(temp));
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
            root.r.l = new Tree();
            root.r.l.x = 11;
            root.r.r = null;
            root.l.l = new Tree();//2ndlevel
            root.l.l.x = 8;
            root.l.r = new Tree();//2ndlevel
            root.l.r.x = 7;

            BinaryTree.printNode(root);

            Assert.AreEqual(3, BinaryTree.CountLeaves(root));
            Assert.AreEqual(6, BinaryTree.CountAllNodes(root));

            //Assert.AreEqual(6, BinaryTree.RemoveNode(root));
            //Assert.AreEqual(3, BinaryTree.HighestWidth(root));
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
