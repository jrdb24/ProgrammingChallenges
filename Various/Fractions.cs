using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    public class Fractions
    {
        public static string Solution(string fraction1, string fraction2)
        {
            int numerator1 = Convert.ToInt32(fraction1.Split('/')[0]);
            int numerator2 = Convert.ToInt32(fraction2.Split('/')[0]);

            int denominator1 = Convert.ToInt32(fraction1.Split('/')[1]);
            int denominator2 = Convert.ToInt32(fraction2.Split('/')[1]);

            int lowestCommonDenominator = FindLowestCommonDenominator(denominator1, denominator2);
            int outputNumerator = (lowestCommonDenominator / denominator1) * numerator1 + (lowestCommonDenominator / denominator2) * numerator2;

            int greatestCommonFactor = FindGreatestCommonFactor(lowestCommonDenominator, outputNumerator);

            return (outputNumerator / greatestCommonFactor).ToString() + "/" + (lowestCommonDenominator / greatestCommonFactor).ToString();
        }

        public static int FindLowestCommonDenominator(int denominator1, int denominator2)
        {
            int highest = denominator1 > denominator2 ? denominator1 : denominator2;
            int lowest = denominator1 < denominator2 ? denominator1 : denominator2;

            for (int i = 1; i <= lowest; i++)
            {
                int temp = lowest * i;

                if (temp % highest == 0 && temp >= highest)
                    return temp;
            }

            return denominator1 * denominator2;
        }

        public static int FindGreatestCommonFactor(int first, int second)
        {
            List<int> firstFactors = new List<int>();
            List<int> secondFactors = new List<int>();

            for (int i = 1; i <= first; i++)
                if(first % i ==0)
                    firstFactors.Add(i);

            for (int j = 1; j <= second; j++)
                if (second % j == 0)
                    secondFactors.Add(j);

            return firstFactors.Intersect(secondFactors).Max();
        }
    }

    [TestFixture]
    public class FractionsSolutionShould
    {
        [Test]
        public void TestFindLowestCommonDenominator()
        {
            Assert.AreEqual(4, Fractions.FindLowestCommonDenominator(2, 4));
            Assert.AreEqual(8, Fractions.FindLowestCommonDenominator(8, 4));
            Assert.AreEqual(16, Fractions.FindLowestCommonDenominator(8, 16));
            Assert.AreEqual(352, Fractions.FindLowestCommonDenominator(32, 88));
            Assert.AreEqual(6767, Fractions.FindLowestCommonDenominator(101, 67));
        }

        [Test]
        public void TestFindGreatestCommonFactor()
        {
            Assert.AreEqual(2, Fractions.FindGreatestCommonFactor(2, 4));
            Assert.AreEqual(3, Fractions.FindGreatestCommonFactor(9, 12));
            Assert.AreEqual(6, Fractions.FindGreatestCommonFactor(6, 18));
            Assert.AreEqual(6, Fractions.FindGreatestCommonFactor(12, 30));
            Assert.AreEqual(12, Fractions.FindGreatestCommonFactor(24, 108));
        }

        [Test]
        public void TestOne()
        {
            Assert.AreEqual("3/4", Fractions.Solution("1/2", "1/4"));
            //Assert.AreEqual("7/8", Fractions.Solution("5/8", "2/8"));
            //Assert.AreEqual("7/9", Fractions.Solution("3/9", "4/9"));
            //Assert.AreEqual("7/32", Fractions.Solution("5/32", "2/32"));
            //Assert.AreEqual("537/6767", Fractions.Solution("5/101", "2/67"));
            //Assert.AreEqual("1346/4819", Fractions.Solution("77/671", "13/79"));
        }
    }
}
