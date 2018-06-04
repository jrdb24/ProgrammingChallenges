using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    class ReverseLinkedList
    {
    }

    [TestFixture]
    public class ReverseLinkedListShould
    {
        [Test]
        public void TestOne()
        {
            Node first = new Node();
            first.Value = 1;

            Node second = new Node();
            second.Value = 2;

            Node third = new Node();
            third.Value = 3;

            Node fourth = new Node();
            fourth.Value = 4;

            first.Next = second;
            second.Next = third;
            third.Next = fourth;

            Assert.AreEqual(2, ReverseLinkedList.Solution(first));
        }
    }

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }
}
