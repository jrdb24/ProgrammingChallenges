using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    public class SortingComparator //Works but version on Hacker Rank doesn't take C#
    {
        public static string Solution(Player[] players)
        {
            Array.Sort(players);

            string output = string.Empty;

            for(int i = 0; i < players.Length; i++)
            {
                output += players[i].ToString();
            }

            return output;
        }
    }

    public class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public int CompareTo(Player compareTo)
        {
            int result = compareTo.Score.CompareTo(Score);
            if (result == 0)
                result = Name.CompareTo(compareTo.Name);
            return result;
        }

        public override string ToString()
        {
            return Name + " " + Score + "\n";
        }
    }

    [TestFixture]
    public class SortingComparatorSolutionShould
    {
        [Test]
        public void TestOne()
        {
            Player one = new Player() { Name = "amy", Score = 100 };
            Player two = new Player() { Name = "david", Score = 100 };
            Player three = new Player() { Name = "heraldo", Score = 50 };
            Player four = new Player() { Name = "aakansha", Score = 75 };
            Player five = new Player() { Name = "aleksa", Score = 150 };

            Assert.AreEqual("aleksa 150\namy 100\ndavid 100\naakansha 75\nheraldo 50\n", SortingComparator.Solution(new Player[] { one, two, three, four, five }));            
        }
    }
}
