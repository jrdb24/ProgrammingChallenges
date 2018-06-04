using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    class LargestProductInSeries
    {
        static string input = "73167176531330624919225119674426574742355349194934" +
                        "96983520312774506326239578318016984801869478851843" +
                        "85861560789112949495459501737958331952853208805511" +
                        "12540698747158523863050715693290963295227443043557" +
                        "66896648950445244523161731856403098711121722383113" +
                        "62229893423380308135336276614282806444486645238749" +
                        "30358907296290491560440772390713810515859307960866" +
                        "70172427121883998797908792274921901699720888093776" +
                        "65727333001053367881220235421809751254540594752243" +
                        "52584907711670556013604839586446706324415722155397" +
                        "53697817977846174064955149290862569321978468622482" +
                        "83972241375657056057490261407972968652414535100474" +
                        "82166370484403199890008895243450658541227588666881" +
                        "16427171479924442928230863465674813919123162824586" +
                        "17866458359124566529476545682848912883142607690042" +
                        "24219022671055626321111109370544217506941658960408" +
                        "07198403850962455444362981230987879927244284909188" +
                        "84580156166097919133875499200524063689912560717606" +
                        "05886116467109405077541002256983155200055935729725" +
                        "71636269561882670428252483600823257530420752963450";

        public static long Start(int numAdjacent)
        { 
            List<List<int>> inputinChunks = CreateAdjacentChunks(input, numAdjacent);

            int processorCount = Environment.ProcessorCount;
            int range = inputinChunks.Count;
            int bucket = range / processorCount;
            List<long> output = new List<long>();
            List<Task<List<long>>> tasksGenerateProduct = new List<Task<List<long>>>();

            for (int i = 0; i < processorCount; i++)
            {
                int start = 0 + (bucket * i);
                int end = start + bucket;
                List<List<int>> temp = inputinChunks.GetRange(start, end - start);
                tasksGenerateProduct.Add(Task<List<long>>.Factory.StartNew(() => GenerateProduct(temp)));
            }

            Task.WaitAll(tasksGenerateProduct.ToArray());

            foreach (Task<List<long>> t in tasksGenerateProduct)
                output.AddRange(t.Result);

            return output.Max();
        }

        private static List<long> GenerateProduct(List<List<int>> input)
        {
            List<long> output = new List<long>();

            foreach (List<int> l in input)
            {
                long value = 1;
                for (int i = 0; i < l.Count; i++)
                    value = value * l[i];
                output.Add(value);
            }

            return output;
        }

        public static List<List<int>> CreateAdjacentChunks(string input, int numAdjacent)
        {
            List<List<int>> output = new List<List<int>>();
            int length = input.Length;

            for(int i = 0; i < length-(numAdjacent-1); i++)
            {
                List<int> temp = new List<int>();
                for (int j = 0; j < numAdjacent; j++)
                    temp.Add(Convert.ToInt32(input[i + j].ToString()));
                output.Add(temp);
            }

            return output;
        }
    }

    [TestFixture]
    public class LargestProductInSeriesShould
    {
        [Test]
        public void TestRun()
        {
            Assert.AreEqual(648, LargestProductInSeries.Start(3));
            Assert.AreEqual(5832, LargestProductInSeries.Start(4));
            Assert.AreEqual(40824, LargestProductInSeries.Start(5));
            Assert.AreEqual(285768, LargestProductInSeries.Start(6));
            Assert.AreEqual(23514624000, LargestProductInSeries.Start(13));
        }

        //8
        //

        [Test]
        public void TestTwo()
        {
            Assert.AreEqual(8, 2 * 4);
            Assert.AreEqual(0, 2 * 0 * 1 * 6 * 5);
            Assert.AreEqual(5832, 9 * 9 * 8 * 9);
            //Assert.AreEqual(8, 2 * 4);

            Assert.AreEqual(8, LargestProductInSeries.CreateAdjacentChunks("73167176531330624919", 13).Count);
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual(2, LargestProductInSeries.CreateAdjacentChunks("71636", 4).Count);
            Assert.AreEqual(7, LargestProductInSeries.CreateAdjacentChunks("7316717653", 4).Count);

            List<List<int>> temp = LargestProductInSeries.CreateAdjacentChunks("7316717653", 4);

            foreach(List<int> l in temp)
                Assert.AreEqual(4, l.Count);

            Assert.Contains(new List<int>() { 7, 3, 1, 6}, temp);
        }
    }
}
