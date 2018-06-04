using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Codility
{
    public class BattleShips
    {
        public static string Solution(int n, string ships, string hits)
        {
            int countOfSunkenShips = 0;
            int shipsHitButNotSunk = 0;

            List<Ship> shipCollection = new List<Ship>();
            List<string> hitSquares = new List<string>();

            if (ships != null && hits != null && ships.Length >= 2 && hits.Length >= 2)
            {
                shipCollection = ParseShips(ships);
                hitSquares = ParseHits(hits);
            }

            foreach(Ship s in shipCollection)
            {
                if (s.IsSunk(hitSquares))
                    countOfSunkenShips++;
                else if (s.IsHit(hitSquares))
                    shipsHitButNotSunk++;
            }

            return countOfSunkenShips + "," + shipsHitButNotSunk;
        }

        public static List<string> ParseHits(string hits)
        {
            List<string> temp = hits.Trim().Split(' ').ToList();
            return temp;
        }

        public static List<Ship> ParseShips(string ships)
        {
            List<Ship> shipCollection = new List<Ship>();
            List<string> parsed = ships.Split(',').ToList();

            foreach(string s in parsed)
            {
                string temp = s.Trim();
                shipCollection.Add(new Ship(temp.Split(' ')[0], temp.Split(' ')[1]));
            }

            return shipCollection;
        }
    }

    public class Ship
    {
        public string TopLeft { get; set; }
        public string BottomRight { get; set; }

        public Ship(string topLeft, string bottomRight)
        {
            TopLeft = topLeft;
            BottomRight = bottomRight;
        }

        private int shipRowStart = 0;
        private int shipRowEnd = 0;
        private int shipColumnStart = 0;
        private int shipColumnEnd = 0;

        public bool ContainsSquare(string square)
        {
            shipRowStart = Convert.ToInt32(TopLeft.First().ToString());
            shipRowEnd = Convert.ToInt32(BottomRight.First().ToString());
            shipColumnStart = (TopLeft.Skip(1).First() - 'A')+1;
            shipColumnEnd = (BottomRight.Skip(1).First() - 'A')+1;

            int squareRow = Convert.ToInt32(square.First().ToString());
            int squareColumn = (square.Skip(1).First() - 'A') + 1;

            if (squareRow >= shipRowStart && squareRow <= shipRowEnd && squareColumn >= shipColumnStart && squareColumn <= shipColumnEnd)
                return true;

            return false;
        }

        public bool IsHit(List<string> hitSquares)
        {
            foreach(string s in hitSquares)
            {
                if (ContainsSquare(s))
                    return true;
            }
            return false;
        }

        public bool IsSunk(List<string> hitSquares)
        {
            int count = 0;

            foreach (string s in hitSquares)
            {
                if (ContainsSquare(s))
                    count++;
            }

            if(count == NumberOfSquares())
            {
                return true;
            }

            return false;
        }

        private int NumberOfSquares()
        {
            int rows = (shipRowEnd - shipRowStart) + 1;
            int columns = (shipColumnEnd - shipColumnStart) + 1;
            return rows * columns;
        }

        public string NextLetter(char firstLetter)
        {
            return ((char)Convert.ToInt32(firstLetter + 1)).ToString();
        }
    }

    [TestFixture]
    public class BattleShipsShould
    {
        [Test]
        public void TestParseHits()
        {
            List<string> test = BattleShips.ParseHits("2B 2D 3D 4D 4A");
            Assert.AreEqual(5, test.Count);
        }

        [Test]
        public void TestParseShips()
        {
            List<Ship> test = BattleShips.ParseShips("1B 2C, 2D 4D");
            Assert.AreEqual(2, test.Count);
        }

        [Test]
        public void TestOne()
        {
            string ships = "1B 2C, 2D 4D";
            string hits = "2B 2D 3D 4D 4A";
            int N = 4;

            Assert.AreEqual("1,1", BattleShips.Solution(N, ships, hits));
        }

        [Test]
        public void TestTwo()
        {
            string ships = "1A 1B, 2C 2C";
            string hits = "1B";
            int N = 3;
            Assert.AreEqual("0,1", BattleShips.Solution(N, ships, hits));
        }

        [Test]
        public void TestThree()
        {
            string ships = "1A 2A, 12A 12A";
            string hits = "12A";
            int N = 12;
            Assert.AreEqual("1,0", BattleShips.Solution(N, ships, hits));
        }

        [Test]
        public void TestFour()
        {
            string ships = "1A 2B, 5D 7D";
            string hits = "3A 7C 2E 4D 8C";
            int N = 10;
            Assert.AreEqual("0,0", BattleShips.Solution(N, ships, hits));
        }

        [Test]
        public void TestFive()
        {
            string ships = "";
            string hits = "";
            int N = 10;
            Assert.AreEqual("0,0", BattleShips.Solution(N, ships, hits));
        }

        [Test]
        public void TestShip()
        {
            Ship s = new Ship("1B", "2C");

            Assert.IsTrue(s.ContainsSquare("1C"));
            Assert.IsTrue(s.ContainsSquare("1B"));
            Assert.IsTrue(s.ContainsSquare("2B"));
            Assert.IsTrue(s.ContainsSquare("2C"));
            Assert.IsFalse(s.ContainsSquare("2D"));
            Assert.IsFalse(s.ContainsSquare("1A"));
        }


    }
}