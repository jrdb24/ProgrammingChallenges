//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using NUnit.Framework;

//namespace Codility
//{
//    public class MinMaxDivisionSolution
//    {
//        public static int Solution(int K, int M, int[] A)
//        {
//            int numBlocks = K;
//            int numberOfElements = A.Count();
//            int toReturn = A.Sum();

//            List<int[]> blocks = new List<int[]>();

//            for (int i = 0; i < numberOfElements; i++)
//            {
//                for (int j = 0; j < numBlocks; j++)
//                {
//                    if (j == 0)
//                    {
//                        int[] toAdd = new int[i];
//                        toAdd = A.Take(i).ToArray();
//                        blocks.Add(toAdd);
//                    }
//                    else
//                    {

//                    }
//                }
//            }

//            return toReturn;
//        }

//        private static List<int[]> CreateBlocks(int numBlocks, int numberOfElements)
//        {
//            List<int[]> blocks = new List<int[]>();

//            for (int i = 0; i < numBlocks; i++)
//            {
//                blocks.Add(new int[numberOfElements]);
//            }

//            return blocks;
//        }
//    }

//    [TestFixture]
//    public class MinMaxDivisionSolutionShould
//    {
//        [Test]
//        public void FirstTest()
//        {
//            Assert.AreEqual(6, MinMaxDivisionSolution.Solution(3, 5, new int[] { 2, 1, 5, 1, 2, 2, 2 }));

//            //Assert.AreEqual(8, MinMaxDivisionSolution.Solution(3, 7, new int[] { 2, 1, 6, 1, 1, 2, 6 }));

//            //Assert.AreEqual(13, MinMaxDivisionSolution.Solution(2, 8, new int[] { 2, 2, 4, 3, 6, 4, 7, 3 }));
//        }
//    }
//}
