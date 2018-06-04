using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class BalancedBracketsAgain
    {
        

        public static string Solution(string count, string[] args)
        {
            int t = Convert.ToInt32(count);
            string output = string.Empty;
            

            for (int a0 = 0; a0 < t; a0++)
            {
                string expression = args[a0];// Console.ReadLine();//string expression = Console.ReadLine();
                output += DecideIfNestedCorrectly(expression);
            }

            return output;
        }

        private static string DecideIfNestedCorrectly(string expression)
        {
            Stack<char> stack = new Stack<char>();

            for (int i = 0; i < expression.Length; i++)
            {
                char c = expression[i];
                if (c == '(' || c == '[' || c == '{')
                {
                    stack.Push(c);
                }
                else
                {
                    if(IsPair(c, stack.Peek))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        //something wrong
                    }
                }
            }

            return stack.Count == 0 ? "YES\n" : "NO\n";
        }

        private static bool IsPair(char c, Func<char> peek)
        {
            Dictionary<char, char> pairs = new Dictionary<char, char>();
            pairs.Add('(', ')');
            pairs.Add('[', ']');
            pairs.Add('{', '}');

            return pairs[peek.Invoke()] == c;
        }
    }

    [TestFixture]
    public class BalancedBracketsAgainShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("YES\nNO\nYES\n", BalancedBracketsAgain.Solution("3", new string[] { "{[()]}", "{[(])}", "{{[[(())]]}}" }));
            Assert.AreEqual("NO\n", BalancedBracketsAgain.Solution("1", new string[] { "([)()]" }));
            Assert.AreEqual("YES\n", BalancedBracketsAgain.Solution("1", new string[] { "({{({}[]{})}}[]{})" }));
        }
    }
}
