using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class ReverseLinkedList
    {
        //internal static LinkedListNode Solution(LinkedListNode head)
        //{
        //    LinkedListNode previous = null;
        //    LinkedListNode current = null;
        //    LinkedListNode next = null;

        //    /*
        //     * Now keep reversing the pointers one by one till currNode!=null:
        //        while(currNode!=null)
        //        {
        //             nextNode = currNode.next;
        //             currNode.next = prevNode;
        //             prevNode = currNode;
        //             currNode = nextNode;
        //        }
        //        At the end set head = prevNode;
        //     * 
        //     */

        //    current = head;

        //    while (current != null)
        //    {
        //        next = current.Next;
        //        current.Next = previous;
        //        previous = current;
        //        current = next;
        //    }

        //    head = previous;

        //    return head;
        //}

        internal static LinkedListNode Solution(LinkedListNode head)
        {
            LinkedListNode current = head;
            LinkedListNode prev = null;
            LinkedListNode next = null;

            while(current != null)
            {
                next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }
            head = prev;

            return head;
        }
    }

    [TestFixture]
    public class ReverseLinkedListShould
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
            //LinkedListNode testNodeFourth = new LinkedListNode();
            //testNodeFourth.val = 4;
            //LinkedListNode testNodeFifth = new LinkedListNode();
            //testNodeFifth.val = 5;
            //LinkedListNode testNodeSixth = new LinkedListNode();
            //testNodeSixth.val = 6;

            testNodeFirst.Next = testNodeSecond;
            testNodeSecond.Next = testNodeThird;
            //testNodeThird.Next = testNodeFourth;
            //testNodeFourth.Next = testNodeFifth;
            //testNodeFifth.Next = testNodeSixth;
            //testNodeSixth.Next = null;
            testNodeThird.Next = null;

            LinkedListNode result = ReverseLinkedList.Solution(testNodeFirst);

            Assert.AreEqual(3, result.val);
            Assert.AreEqual(2, result.Next.val);
            Assert.AreEqual(1, result.Next.Next.val);

            //Assert.AreEqual(6, result.val);
            //Assert.AreEqual(5, result.Next.val);
            //Assert.AreEqual(4, result.Next.Next.val);
            //Assert.AreEqual(3, result.Next.Next.Next.val);
            //Assert.AreEqual(2, result.Next.Next.Next.Next.val);
            //Assert.AreEqual(1, result.Next.Next.Next.Next.Next.val);
        }
    }
}
