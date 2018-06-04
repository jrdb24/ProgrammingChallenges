using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class LinkedListsDetectCycle //100% on hacker rank
    {
        public static bool HasCycle(LinkedListNode head)
        {
            LinkedListNode slow = head;
            LinkedListNode fast = head;
            bool result = false;

            while(fast != null)
            {
                fast = fast.Next;

                if (slow == fast)
                    return true;

                slow = slow.Next;
                fast = fast.Next;

            }

            return result;
        }
    }

    [TestFixture]
    public class LinkedListsDetectCycleSolutionShould
    {
        [Test]
        public void TestOne()
        {
            LinkedListNode testNodeFirst = new LinkedListNode();
            testNodeFirst.val = 1;
            LinkedListNode testNodeSecond = new LinkedListNode();
            testNodeSecond.val = 2;
            LinkedListNode testNodeThird = new LinkedListNode();
            testNodeThird.val = 3;
            LinkedListNode testNodeFourth = new LinkedListNode();
            testNodeFourth.val = 4;
            LinkedListNode testNodeFifth = new LinkedListNode();
            testNodeFifth.val = 5;
            LinkedListNode testNodeSixth = new LinkedListNode();
            testNodeSixth.val = 6;

            testNodeFirst.Next = testNodeSecond;
            testNodeSecond.Next = testNodeThird;
            testNodeThird.Next = testNodeFourth;
            testNodeFourth.Next = testNodeFifth;
            testNodeFifth.Next = testNodeSixth;
            testNodeSixth.Next = testNodeFirst;

            bool result = LinkedListsDetectCycle.HasCycle(testNodeFirst);

            Assert.AreEqual(true, result);

            testNodeSixth.Next = null;
            result = LinkedListsDetectCycle.HasCycle(testNodeFirst);
            Assert.AreEqual(false, result);
        }
    }
}
