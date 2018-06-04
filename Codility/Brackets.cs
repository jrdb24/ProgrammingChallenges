using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Codility
{
    class Brackets
    {
        public static int Solution(string S) //Scores 87% (100% correctness, but slow on massive input)
        {
            Dictionary<char, char> pairs = new Dictionary<char, char>();

            pairs.Add('(', ')');
            pairs.Add('[', ']');
            pairs.Add('{', '}');

            if (S == null || S.Length % 2 != 0)
                return 0;

            if (S == string.Empty)
                return 1;

            Stack<char> stack = new Stack<char>();

            foreach(char c in S.ToCharArray())
            {
                if(stack.Count() > 0 && IsPair(pairs, stack.Peek(), c))
                {
                   stack.Pop();
                }
                else
                {
                    stack.Push(c);
                }
            }

            stack.CheckNested('c');

            return stack.Count == 0 ? 1 : 0;
        }

        private static bool IsPair(Dictionary<char, char> pairs, char v, char c)
        {
            if(pairs.ContainsKey(v))
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
    public class BracketsSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(1, Brackets.Solution("{[()()()[]]}"));

            Assert.AreEqual(1, Brackets.Solution("{[()()]}"));
            Assert.AreEqual(0, Brackets.Solution("([)()]"));
            Assert.AreEqual(1, Brackets.Solution("{[()()]}{[()()]}"));
            Assert.AreEqual(1, Brackets.Solution("()()()[][]()()()()()()()()()()"));
            Assert.AreEqual(1, Brackets.Solution("()()()[][]()()()()()()()()()()()()()[][]()()()()()()()()()()()()()[][]()()()()()()()()()()()()()[][]()()()()()()()()()()()()()[][]()()()()()()()()()()()()()[][]()()()()()()()()()()"));
            Assert.AreEqual(0, Brackets.Solution("()()()[][]()()()()()()()()()()()()()[][]()()()()()()()()()()()()()[][]()()()()()(()()()()()()()()[][]()()()()()()()()()()()()()[][]()()()()()()()()()()()()()[][]()()()()()()()()()()"));
        }

        [Test]
        public void TestTwo()
        {
            Assert.AreEqual(0, Brackets.Solution(")("));
            Assert.AreEqual(1, Brackets.Solution(""));
            Assert.AreEqual(0, Brackets.Solution(null));
            Assert.AreEqual(1, Brackets.Solution("({{({}[]{})}}[]{})"));
        }

        //
    }
}
