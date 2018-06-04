using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    public class Template
    {
        public static int Solution(int[] A)
        {
            KeyValuePair<int, string> kvp = new KeyValuePair<int, string>();

            Type t = kvp.GetType();
            // Get the IsValueType property of the myTestEnum variable.
            bool flag = t.IsValueType;
            int h = 0;
            return h;


            string s = "sduhdfksuddhfksddjhfdskdjhdfkjfd";

            string[] blah = s.Split('d');
        }
    }

    [TestFixture]
    public class TemplateSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(0, Template.Solution(new int[] { 2, 2, 2, 2 }));
        }
    }
}
