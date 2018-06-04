using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Numerics;

namespace ProjectEuler
{
    class NamesScores
    {
        private static readonly string _inputFile = @"D:\My Documents\Visual Studio 2017\Projects\ProgrammingChallenges\Codility\input\p022_names.txt";
        private static readonly string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private static Dictionary<string, long> _nameScores = new Dictionary<string, long>();

        internal static long Solution()
        {
            var lines = System.IO.File.ReadAllText(_inputFile).Split(',').Select(l => l.Replace("\"", ""));
            SortedSet<string> orderedNames = new SortedSet<string>(lines.OrderBy(n => n));
            int position = 1;

            foreach(var name in orderedNames)
            {
                int alphabeticalValue = CalculateAlphabeticalValue(name);
                _nameScores.Add(name, alphabeticalValue * position);
                position++;
            }

            return _nameScores.Sum(x => x.Value);
        }

        internal static int CalculateAlphabeticalValue(string name)
        {
            int value = 0;
            foreach(char c in name)
                value += _alphabet.IndexOf(c)+1;
            return value;
        }
    }

    [TestFixture]
    public class NamesScoresShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(53, NamesScores.CalculateAlphabeticalValue("COLIN"));
            Assert.AreEqual(6, NamesScores.CalculateAlphabeticalValue("ABC"));
            Assert.AreEqual(871198282, NamesScores.Solution()); //correct project euler answer
        }
    }
}
