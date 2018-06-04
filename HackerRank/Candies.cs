//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace HackerRank
//{
//    class Candies
//    {
//        internal static int Solution(string[] A)
//        {
//            string number = A[0];
//            int[] children = A.Skip(1).Take(A.Length-1).Select(a=>Convert.ToInt32(a)).ToArray();
//            int[] sweetCount = new int[children.Length];

//            int size = children.Length;
//            if (size <= 1)
//                return size;

//            for (int i = 1; i < size; i++)
//            {
//                if (children[i] > children[i - 1])
//                    sweetCount[i] = sweetCount[i - 1] + 1;
//            }
//            for (int i = size - 1; i > 0; i--)
//            {
//                if (children[i - 1] > children[i])
//                    sweetCount[i - 1] = Math.Max(sweetCount[i] + 1, sweetCount[i - 1]);
//            }
//            int result = 0;
//            for (int i = 0; i < size; i++)
//            {
//                result += sweetCount[i];
//            }
//            return result;

//            //return sweetCount.Sum();
//        }
//    }

//    [TestFixture]
//    public class CandiesShould
//    {
//        [Test]
//        public void TestOne()
//        {
//            Assert.AreEqual(4, Candies.Solution(new string[] { "3", "1", "2", "2" }));
//            //Assert.AreEqual(19, Candies.Solution(new string[] { "10","2","4","2","6","1","7","8","9","2","1" }));

//            //Assert.AreEqual(18, Candies.Solution(new string[] { "10","11","10","9","8","7","6","5","4","3","2" }));
//        }
//    }
//}
