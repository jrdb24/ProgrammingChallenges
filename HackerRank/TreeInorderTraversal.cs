using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class TreeInorderTraversal
    {
        public static string output = string.Empty;

        public static string Inorder(Tree root)
        {
            if (root == null)
                return string.Empty;

            Inorder(root.l);
            output += root.x.ToString() + " ";
            Inorder(root.r);

            return output.Trim();
        }

        public static string InorderIterative(Tree root)
        {
            Stack<Tree> stack = new Stack<Tree>();
            Tree node = root;
            string output = string.Empty;

            while(node != null)
            {
                stack.Push(node);
                node = node.l;
            }

            while(stack.Count > 0)
            {
                node = stack.Pop();
                output += node.x + " ";

                if (node.r != null)
                {
                    node = node.r;

                    while (node != null)
                    {
                        stack.Push(node);
                        node = node.l;
                    }
                }
                
            }

            return output.Trim();
        }


        //public static string inorderagain(Tree root)
        //{
        //    Stack<Tree> stack = new Stack<Tree>();
        //    Tree node = root;
        //    string output = string.Empty;

        //    while(node != null)
        //    {
        //        stack.Push(node);
        //        node = node.l;
        //    }

        //    while(stack.Count() > 0)
        //    {
        //        node = stack.Pop();
        //        output += node.x + " ";

        //        if(node.r != null)
        //        {
        //            node = node.r;

        //            while (node != null)
        //            {
        //                stack.Push(node);
        //                node = node.l;
        //            }
        //        }
        //    }

        //    return output.Trim();
        //}

        public static string inorderagain(Tree root)
        {
            Stack<Tree> stack = new Stack<Tree>();
            Tree node = root;
            string output = string.Empty;

            while(node != null)
            {
                stack.Push(node);
                node = node.l;
            }

            while(stack.Count > 0)
            {
                node = stack.Pop();
                output += node.x + " ";

                if (node.r != null)
                {
                    node = node.r;

                    while (node != null)
                    {
                        stack.Push(node);
                        node = node.l;
                    }
                }
            }

            return output.Trim();
        }
    }

    [TestFixture]
    public class TreeInorderTraversalShould
    {
        [Test]
        public void TestIterative()
        {
            Tree root = new Tree(1);
            root.r = new Tree(2);
            root.r.r = new Tree(5);
            root.r.r.l = new Tree(3);
            root.r.r.r = new Tree(6);
            root.r.r.l.r = new Tree(4);

            //Assert.AreEqual("1 2 3 4 5 6", TreeInorderTraversal.inorder(root));
            Assert.AreEqual("1 2 3 4 5 6", TreeInorderTraversal.inorderagain(root));
            Assert.AreEqual("1 2 3 4 5 6", TreeInorderTraversal.InorderIterative(root));
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

            Assert.AreEqual("1 2 3 4 5 6", TreeInorderTraversal.Inorder(root));
        }
    }
}
