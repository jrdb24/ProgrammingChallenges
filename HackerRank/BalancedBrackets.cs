using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class BalancedBrackets //Scores 100% on HackerRank
    {
        public static string Solution(string count, string[] args)
        {
            int t = Convert.ToInt32(count);//int t = Convert.ToInt32(Console.ReadLine());

            string output = string.Empty;

            for (int a0 = 0; a0 < t; a0++)
            {
                string expression = args[a0];// Console.ReadLine();//string expression = Console.ReadLine();

                output += DecideIfNestedCorrectly(expression);
            }

            return output;//Console.WriteLine(output);
        }

        private static string DecideIfNestedCorrectly(string S)
        {
            Dictionary<char, char> pairs = new Dictionary<char, char>();

            pairs.Add('(', ')');
            pairs.Add('[', ']');
            pairs.Add('{', '}');

            if (S == null || S.Length % 2 != 0)
                return "NO\n";

            if (S == string.Empty)
                return "YES\n";

            Stack<char> stack = new Stack<char>();

            foreach (char c in S.ToCharArray())
            {
                if (stack.Count() > 0 && IsPair(pairs, stack.Peek(), c))
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            //stack.CheckNested('c');

            return stack.Count == 0 ? "YES\n" : "NO\n";
        }

        private static bool IsPair(Dictionary<char, char> pairs, char v, char c)
        {
            if (pairs.ContainsKey(v))
                return pairs[v] == c;
            return false;
        }
    }

    public static class Extensions
    {
        public static void CheckNested(this Stack<char> stack, char value)
        {
            if (stack.Count() != 0 && stack.Peek() == value)
            {
                stack.Pop();
            }
        }
    }

    [TestFixture]
    public class BalancedBracketsSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual("YES\nNO\nYES\n", BalancedBrackets.Solution("3", new string[] { "{[()]}", "{[(])}", "{{[[(())]]}}" }));
            Assert.AreEqual("NO\n", BalancedBrackets.Solution("1", new string[] { "([)()]" }));
            Assert.AreEqual("YES\n", BalancedBrackets.Solution("1", new string[] { "({{({}[]{})}}[]{})" }));
        }
    }
}
