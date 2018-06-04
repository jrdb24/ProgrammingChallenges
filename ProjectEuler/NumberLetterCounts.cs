using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Diagnostics;
using System.Numerics;

namespace ProjectEuler
{
    class NumberLetterCounts
    {
        private static Dictionary<int, int> _numberLengths = new Dictionary<int, int>() { { 1, 3 }, { 2, 3 }, { 3, 5 }, { 4, 4 }, { 5, 4 }, { 6, 3 }, { 7, 5 }, { 8, 5 }, { 9, 4 }, { 0, 4 } };
        private static Dictionary<int, int> _elevenToNineteen = new Dictionary<int, int>() { { 11, 6 }, { 12, 6 }, { 13, 8 }, { 14, 8 }, { 15, 7 }, { 16, 7 }, { 17, 9 }, { 18, 8 }, { 19, 8 } };
        private static Dictionary<int, int> _multiplesOfTen = new Dictionary<int, int>() { { 10, 3 }, { 20, 6 }, { 30, 6 }, { 40, 5 }, { 50, 5 }, { 60, 5 }, { 70, 7 }, { 80, 6 }, { 90, 6 } };

        internal static int Solution(int start, int end)
        {
            int letterCount = 0;

            for(int i = start; i <= end; i++)
            {
                if(i == 1000)
                    letterCount += "onethousand".Length;
                else if(i % 100 == 0)
                    letterCount += _numberLengths[i / 100] + "hundred".Length;
                else if (i < 100 && i % 10 == 0)
                    letterCount += _multiplesOfTen[i];
                else if (i > 10 && i < 20)
                    letterCount += _elevenToNineteen[i];
                else
                {
                    if (i.ToString().Length == 1)
                        letterCount += _numberLengths[i];
                    else if (i.ToString().Length == 2)
                    {
                        letterCount += _multiplesOfTen[i - (i % 10)];
                        letterCount += _numberLengths[i % 10];
                    }
                    else if (i.ToString().Length == 3)
                    { 
                        letterCount += _numberLengths[i / 100] + "hundredand".Length;
                        
                        if (i % 100 > 10 && i % 100 < 20)
                        {
                            letterCount += _elevenToNineteen[i % 100];
                        }
                        else
                        {
                            letterCount += i % 100 - i % 10 != 0 ? _multiplesOfTen[i % 100 - i % 10] : 0;
                            letterCount += i % 10 != 0 ? _numberLengths[i % 10] : 0;
                        }
                    }
                }
            }

            return letterCount;
        }
    }

    [TestFixture]
    public class NumberLetterCountsShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(19, NumberLetterCounts.Solution(1, 5));
            Assert.AreEqual(27, NumberLetterCounts.Solution(1, 7));
            Assert.AreEqual(36, NumberLetterCounts.Solution(1, 9));
            Assert.AreEqual(39, NumberLetterCounts.Solution(1, 10));
            Assert.AreEqual(45, NumberLetterCounts.Solution(1, 11));
            Assert.AreEqual(51, NumberLetterCounts.Solution(1, 12));
            Assert.AreEqual(59, NumberLetterCounts.Solution(1, 13));
            Assert.AreEqual(81, NumberLetterCounts.Solution(1, 16));
            Assert.AreEqual(106, NumberLetterCounts.Solution(1, 19));
            Assert.AreEqual(112, NumberLetterCounts.Solution(1, 20));
            Assert.AreEqual(121, NumberLetterCounts.Solution(1, 21));
            Assert.AreEqual(141, NumberLetterCounts.Solution(1, 23));
            Assert.AreEqual(6, NumberLetterCounts.Solution(30, 30));
            Assert.AreEqual(5, NumberLetterCounts.Solution(40, 40));
            Assert.AreEqual("fortyfortyonefortytwofortythreefortyfourfortyfivefortysixfortysevenfortyeightfortyninefiftyfiftyonefiftytwofiftythreefiftyfourfiftyfive".Length, NumberLetterCounts.Solution(40, 55));
            Assert.AreEqual(5, NumberLetterCounts.Solution(50, 50));
            Assert.AreEqual(21, NumberLetterCounts.Solution(50, 52));
            Assert.AreEqual(49, NumberLetterCounts.Solution(50, 55));
            Assert.AreEqual(5, NumberLetterCounts.Solution(60, 60));
            Assert.AreEqual(7, NumberLetterCounts.Solution(70, 70));
            Assert.AreEqual("ninety".Length, NumberLetterCounts.Solution(90, 90));
            Assert.AreEqual("ninetyninetyone".Length, NumberLetterCounts.Solution(90, 91));
            Assert.AreEqual(55, NumberLetterCounts.Solution(90, 95));
            Assert.AreEqual(96, NumberLetterCounts.Solution(90, 99));
            Assert.AreEqual(106, NumberLetterCounts.Solution(90, 100));
            Assert.AreEqual(122, NumberLetterCounts.Solution(90, 101));
            Assert.AreEqual(138, NumberLetterCounts.Solution(90, 102));
            Assert.AreEqual(10, NumberLetterCounts.Solution(100, 100));
            Assert.AreEqual("onehundredandone".Length, NumberLetterCounts.Solution(101, 101));
            Assert.AreEqual("onehundredandoneonehundredandtwo".Length, NumberLetterCounts.Solution(101, 102));
            Assert.AreEqual("onehundredandoneonehundredandtwoonehundredandthree".Length, NumberLetterCounts.Solution(101, 103));
            Assert.AreEqual("onehundredandoneonehundredandtwoonehundredandthreeonehundredandfour".Length, NumberLetterCounts.Solution(101, 104));
            Assert.AreEqual("onehundredandninetyninetwohundred".Length, NumberLetterCounts.Solution(199, 200));
            Assert.AreEqual("onehundredandninetyninetwohundredtwohundredandone".Length, NumberLetterCounts.Solution(199, 201));
            Assert.AreEqual("twohundredandonetwohundredandtwotwohundredandthreetwohundredandfourtwohundredandfivetwohundredandsix".Length, NumberLetterCounts.Solution(201, 206));
            Assert.AreEqual("twohundredandten".Length, NumberLetterCounts.Solution(210, 210));
            Assert.AreEqual("twohundredandeleven".Length, NumberLetterCounts.Solution(211, 211));
            Assert.AreEqual("twohundredandthirteen".Length, NumberLetterCounts.Solution(213, 213));
            Assert.AreEqual("twohundredandeighteen".Length, NumberLetterCounts.Solution(218, 218));
            Assert.AreEqual("twohundredandeighteentwohundredandnineteentwohundredandtwenty".Length, NumberLetterCounts.Solution(218, 220));
            Assert.AreEqual("twohundredandeighteentwohundredandnineteentwohundredandtwentytwohundredandtwentyone".Length, NumberLetterCounts.Solution(218, 221));
            Assert.AreEqual(10, NumberLetterCounts.Solution(200, 200));
            Assert.AreEqual(12, NumberLetterCounts.Solution(300, 300));
            Assert.AreEqual(23, NumberLetterCounts.Solution(342, 342));
            Assert.AreEqual(20, NumberLetterCounts.Solution(115, 115));
            Assert.AreEqual(20, NumberLetterCounts.Solution(116, 116));
            Assert.AreEqual(40, NumberLetterCounts.Solution(115, 116));
            Assert.AreEqual(83, NumberLetterCounts.Solution(115, 118));
            Assert.AreEqual("onehundredandfifteenonehundredandsixteenonehundredandseventeenonehundredandeighteen".Length, NumberLetterCounts.Solution(115, 118));
            Assert.AreEqual("ninehundredandninetyeightninehundredandninetynine".Length, NumberLetterCounts.Solution(998, 999));
            Assert.AreEqual("ninehundredandninetynine".Length, NumberLetterCounts.Solution(999, 999));
            Assert.AreEqual("onethousand".Length, NumberLetterCounts.Solution(1000, 1000));
            Assert.AreEqual("ninehundredandninetynineonethousand".Length, NumberLetterCounts.Solution(999, 1000));

            Assert.AreEqual(21124, NumberLetterCounts.Solution(1, 1000));
        }

        [Test]
        public void TestExtract2()
        {
            int i = 116;
            int three = i / 100;
            int forty = i % 100 - i % 10;
            int two = i % 10;
            Assert.AreEqual(1, three);
            Assert.AreEqual(10, forty);
            Assert.AreEqual(6, two);
        }

        [Test]
        public void TestExtract()
        {
            int i = 342;
            int three = i / 100;
            int forty = i % 100 - i % 10;
            int two = i % 10;
            Assert.AreEqual(3, three);
            Assert.AreEqual(40, forty);
            Assert.AreEqual(2, two);
        }
    }
}
