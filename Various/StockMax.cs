using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    public class StockMax
    {
        public static string Solution(string[] A)
        {
            string output = string.Empty;

            int numberOfTestCases = Convert.ToInt32(A[0]);

            for(int i = 0; i < numberOfTestCases; i++)
            {
                int position = (i * 2) + 1;
                //int numberOfDays = Convert.ToInt32(A[position]);
                List<int> prices = A[position + 1].Split(' ').Select(a => Convert.ToInt32(a)).ToList();
                output += CalculateProfit(prices) + "\n";
            }

            return output;
        }

        public static long MaxProfit(IList<int> prices)
        {
            int profit = 0;
            int maxPriceSoFar = 0;

            List<int> temp = new List<int>(prices);
            temp.Reverse();

            foreach (int price in temp)
            {
                int currentPrice = price;
                maxPriceSoFar = Math.Max(maxPriceSoFar, currentPrice);
                int soldPrice = maxPriceSoFar - currentPrice;
                profit += soldPrice;
            }

            return profit;
        }

        public static int CalculateProfit(List<int> prices)
        {
            int profit = 0;
            int maxPriceSoFar = 0;

            prices.Reverse();

            foreach (int price in prices)
            {
                int currentPrice = price;
                maxPriceSoFar = Math.Max(maxPriceSoFar, currentPrice);
                int soldPrice = maxPriceSoFar - currentPrice;
                profit += soldPrice;
            }

            return profit;
        }
    }

    [TestFixture]
    public class StockMaxSolutionShould
    {
        [Test]
        public void TestMaxPrice()
        {
            Assert.AreEqual(0, StockMax.MaxProfit(new List<int>() { 5, 3, 2 }));

            Assert.AreEqual(0, StockMax.MaxProfit(new List<int>() { 5, 3, 2 }));

            Assert.AreEqual(3, StockMax.MaxProfit(new List<int>() { 1, 3, 1, 2 }));
            Assert.AreEqual(197, StockMax.MaxProfit(new List<int>() { 1, 2, 100 }));
            Assert.AreEqual(439, StockMax.MaxProfit(new List<int>() { 1, 3, 1, 2, 97, 5, 63, 1 })); 
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual("0\n197\n3\n", StockMax.Solution(new string[] { "3", "3", "5 3 2", "3", "1 2 100", "4", "1 3 1 2" }));
        }
    }
}
