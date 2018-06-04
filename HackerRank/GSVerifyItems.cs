using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class GS1
    {
        public static int verifyItems(string[] origItems, float[] origPrices, string[] items, float[] prices)
        {
            Dictionary<string, float> originalItems = new Dictionary<string, float>();
            int difCount = 0;

            for (int i = 0; i < origItems.Count(); i++)
                originalItems.Add(origItems[i], origPrices[i]);

            for (int i = 0; i < items.Count(); i++)
                if(originalItems[items[i]] != prices[i])
                    difCount++;

            return difCount;
        }
    }

    [TestFixture]
    public class GS1SolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(2, GS1.verifyItems(new string[] { "rice", "sugar", "wheat", "cheese" }, new float[] { 16.89F, 56.92F, 20.89F, 345.99F }, new string[] { "rice", "cheese" }, new float[] { 18.99F, 400.89F }));
            Assert.AreEqual(1, GS1.verifyItems(new string[] { "chocolate", "cheese", "tomato"  }, new float[] { 15.00F, 300.90F, 23.44F }, new string[] { "chocolate", "cheese", "tomato" }, new float[] { 15.00F, 300.90F, 10.00F }));
        }
    }
}
