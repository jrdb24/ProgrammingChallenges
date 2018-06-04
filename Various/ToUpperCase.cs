using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    class ToUpperCase
    {
        internal static string Solution(string input)
        {
            //return char.ToUpper(input[0]) + input.Substring(1);

            return input.Substring(0,1).ToUpper() + input.Substring(1);
        }
    }

    [TestFixture]
    public class ToUpperCaseShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("Hereisastring", ToUpperCase.Solution("hereisastring"));
            Assert.AreEqual("H", ToUpperCase.Solution("h"));
        }
    }
}
