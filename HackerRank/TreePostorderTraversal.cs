using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class TreePostorderTraversal
    {
        public static string output = string.Empty;

        public static string PostOrder(Tree root)
        {
            if (root == null)
                return string.Empty;
            
            PostOrder(root.l);
            PostOrder(root.r);
            output += root.x.ToString() + " ";

            return output.Trim();
        }
    }

    [TestFixture]
    public class TreePostorderTraversalShould
    {
        [Test]
        public void TestOne()
        {
            Tree root = new Tree(1);
            root.r = new Tree(2);
            root.r.r = new Tree(5);
            root.r.r.l = new Tree(3);
            root.r.r.r = new Tree(6);
            root.r.r.l.r = new Tree(4);

            Assert.AreEqual("4 3 6 5 2 1", TreePostorderTraversal.PostOrder(root));
        }
    }
}
