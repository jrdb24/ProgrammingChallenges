using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class TreePreorderTraversal
    {
        public static string output = string.Empty;

        public static string PreOrder(Tree root)
        {
            if (root == null)
                return string.Empty;

            output += root.x.ToString() + " ";
            PreOrder(root.l);
            PreOrder(root.r);

            return output.Trim();
        }

        public static string TopOrder(Tree root)
        {
            if (root == null)
                return string.Empty;

            output += root.x.ToString() + " ";

            if(root.l != null)
                GoLeft(root.l, ref output);                
            else if (root.r != null)
                GoRight(root.r, ref output);

            return output.Trim();
        }

        private static void GoRight(Tree root, ref string output)
        {
            output += root.x.ToString() + " ";
            if(root.r != null)
                GoRight(root.r, ref output);
        }

        private static void GoLeft(Tree root, ref string output)
        {
            output += root.x.ToString() + " ";  
            if(root.l != null)
                GoLeft(root.l, ref output);
        }

        public static void Test()
        {
            var i = 0;
        }
    }

    [TestFixture]
    public class TreePreorderTraversalShould
    {
        //[Test]
        //public void TestTopOrder()
        //{
        //    TreePreorderTraversal.Test();

        //    Tree root = new Tree(1);
        //    root.r = new Tree(2);
        //    root.r.r = new Tree(5);
        //    root.r.r.l = new Tree(3);
        //    root.r.r.r = new Tree(6);
        //    root.r.r.l.r = new Tree(4);

        //    Assert.AreEqual("1 2 5 6", TreePreorderTraversal.TopOrder(root));
        //}

        [Test]
        public void TestOne()
        {
            Tree root = new Tree(1);
            root.r = new Tree(2);
            root.r.r = new Tree(5);
            root.r.r.l = new Tree(3);
            root.r.r.r = new Tree(6);
            root.r.r.l.r = new Tree(4);

            Assert.AreEqual("1 2 5 3 4 6", TreePreorderTraversal.PreOrder(root));
        }
    }
}
