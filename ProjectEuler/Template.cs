using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProjectEuler
{
    public class Template
    {
        public static int Solution()
        {
            return 0;
        }
    }

    [TestFixture]
    public class TemplateSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(0, Template.Solution());
        }
    }
}

