using System;
using NUnit.Framework;

namespace HackerRank
{
    public class GSLinkedListRemoveEvens
    {
        public static LinkedListNode deleteEven(LinkedListNode head)
        {
            LinkedListNode result = new LinkedListNode() { Next = head };
            LinkedListNode temp = result;

            while (temp.Next != null)
            {
                if (temp.Next.val % 2 == 0)//node value is even so remove it
                    temp.Next = temp.Next.Next;
                else
                    temp = temp.Next;
            }

            return result.Next;

        }

        internal static LinkedListNode DeleteFromPosition(LinkedListNode head, int position)
        {
            if (position == 0)
            {
                return head.Next;
            }
            head.Next = DeleteFromPosition(head.Next, position - 1);
            return head;
        }
    }

    

    public class LinkedListNode
    {
        public int val { get; set; }
        public LinkedListNode Next { get; set; }
    }

    [TestFixture]
    public class GSLinkedListSolutionShould
    {
        [Test]
        public void TestOne()
        {
            LinkedListNode testNodeSecond = new LinkedListNode();
            testNodeSecond.val = 10;
            LinkedListNode testNodeThird = new LinkedListNode();
            testNodeThird.val = 2;
            LinkedListNode testNodeFourth = new LinkedListNode();
            testNodeFourth.val = 4;
            LinkedListNode testNodeFifth = new LinkedListNode();
            testNodeFifth.val = 5;
            LinkedListNode testNodeSixth = new LinkedListNode();
            testNodeSixth.val = 6;

            testNodeSecond.Next = testNodeThird;
            testNodeThird.Next = testNodeFourth;
            testNodeFourth.Next = testNodeFifth;
            testNodeFifth.Next = testNodeSixth;
            testNodeSixth.Next = null;

            LinkedListNode compare1 = new LinkedListNode() { val = 5, Next = null };
            LinkedListNode compare2 = GSLinkedListRemoveEvens.deleteEven(testNodeSecond);

            Assert.AreEqual(compare1.val, compare2.val);
            Assert.AreEqual(compare1.Next, compare2.Next);
        }

        [Test]
        public void TestTwo()
        {
            LinkedListNode testNodeSecond = new LinkedListNode();
            testNodeSecond.val = 13;
            LinkedListNode testNodeThird = new LinkedListNode();
            testNodeThird.val = 3;
            LinkedListNode testNodeFourth = new LinkedListNode();
            testNodeFourth.val = 4;
            LinkedListNode testNodeFifth = new LinkedListNode();
            testNodeFifth.val = 5;
            LinkedListNode testNodeSixth = new LinkedListNode();
            testNodeSixth.val = 6;

            testNodeSecond.Next = testNodeThird;
            testNodeThird.Next = testNodeFourth;
            testNodeFourth.Next = testNodeFifth;
            testNodeFifth.Next = testNodeSixth;
            testNodeSixth.Next = null;

            LinkedListNode compare1 = new LinkedListNode() { val = 13, Next = null };
            LinkedListNode compare2 = new LinkedListNode() { val = 3, Next = null };
            LinkedListNode compare3 = new LinkedListNode() { val = 5, Next = null };
            LinkedListNode result = GSLinkedListRemoveEvens.deleteEven(testNodeSecond);

            Assert.AreEqual(compare1.val, result.val);
            Assert.AreEqual(compare2.val, result.Next.val);
            Assert.AreEqual(compare3.val, result.Next.Next.val);
        }
    }
}
