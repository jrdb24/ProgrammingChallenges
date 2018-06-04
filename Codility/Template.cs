using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Codility
{
    public class Template
    {
        public static int Solution(int[] A)
        {
            return 0;
        }
    }

    [TestFixture]
    public class TemplateShould
    {
        [Test]
        public void TestOne()
        {
           Assert.AreEqual(0, Template.Solution(new int[] { 30, 20, 10 }));
        }
    }
}
