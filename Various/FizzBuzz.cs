using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    class FizzBuzz
    {
        public static string Start()
        {
            string output = string.Empty;

            for (int i = 0; i < 100; i++)
            {
                string temp = i % 3 == 0 ? "Fizz" : "";
                temp += i % 5 == 0 ? "Buzz" : "";
                output += temp != "" ? temp + "\n" : "";
            }

            return output;
        }
    }

    [TestFixture]
    public class FizzBuzzShould
    {
        [Test]
        public void TestOne()
        {
            string output = "FizzBuzz\nFizz\nBuzz\nFizz\nFizz\nBuzz\nFizz\nFizzBuzz\nFizz\nBuzz\nFizz\nFizz\nBuzz\nFizz\nFizzBuzz\nFizz\nBuzz\nFizz\nFizz\nBuzz\nFizz\nFizzBuzz\nFizz\nBuzz\nFizz\nFizz\nBuzz\nFizz\nFizzBuzz\nFizz\nBuzz\nFizz\nFizz\nBuzz\nFizz\nFizzBuzz\nFizz\nBuzz\nFizz\nFizz\nBuzz\nFizz\nFizzBuzz\nFizz\nBuzz\nFizz\nFizz\n";
            Assert.AreEqual(output, FizzBuzz.Start());
        }
    }
}
