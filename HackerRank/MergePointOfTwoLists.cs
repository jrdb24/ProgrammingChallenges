using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    public class MergePointOfTwoLists
    {
        internal static double Solution(Node one, Node two)
        {
            Node temp1 = one.next;
            Node temp2 = two.next;
            int output = 0;

            while (true)
            {
                if (temp1.data == temp2.data)
                {
                    output = temp1.data;
                    break;
                }

                temp1 = temp1.next == null ? one : temp1.next;
                temp2 = temp2.next == null ? two : temp2.next;
            }

            return output;
        }
    }

    [TestFixture]
    public class MergePointOfTwoListsShould
    {
        [Test]
        public void TestTwo()
        {
            Node firstList1 = new Node();
            Node firstList2 = new Node();
            Node firstList3 = new Node();
            Node firstList4 = new Node();
            Node firstList5 = new Node();
            firstList1.data = 1;
            firstList2.data = 2;
            firstList3.data = 3;
            firstList4.data = 4;
            firstList5.data = 5;

            firstList1.next = firstList2;
            firstList2.next = firstList3;
            firstList3.next = firstList4;
            firstList4.next = firstList5;

            Node secondList1 = new Node();
            secondList1.data = 1;

            secondList1.next = firstList5;

            Node six = new Node();
            six.data = 6;

            firstList5.next = six;
            six.next = null;

            Assert.AreEqual(5, MergePointOfTwoLists.Solution(firstList1, secondList1));
        }


        [Test]
        public void TestOne()
        {
            Node firstList1 = new Node();
            Node secondList1 = new Node();
            firstList1.data = 1;
            secondList1.data = 1;
            Node second = new Node();
            second.data = 2;
            firstList1.next = second;
            secondList1.next = second;
            Node third = new Node();
            third.data = 3;
            second.next = third;
            third.next = null;
            Assert.AreEqual(2, MergePointOfTwoLists.Solution(firstList1, secondList1));
        }
    }

    class Node
    {
        public int data;
        public Node next;
    }
}
