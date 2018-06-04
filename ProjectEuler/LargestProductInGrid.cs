using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Diagnostics;

namespace ProjectEuler
{
    class LargestProductInGrid
    {
        //What is the greatest product of four adjacent numbers in the same direction (up, down, left, right, or diagonally) in the 20×20 grid?

        private static string grid = "08 02 22 97 38 15 00 40 00 75 04 05 07 78 52 12 50 77 91 08" +
                                    "49 49 99 40 17 81 18 57 60 87 17 40 98 43 69 48 04 56 62 00" +
                                    "81 49 31 73 55 79 14 29 93 71 40 67 53 88 30 03 49 13 36 65" +
                                    "52 70 95 23 04 60 11 42 69 24 68 56 01 32 56 71 37 02 36 91" +
                                    "22 31 16 71 51 67 63 89 41 92 36 54 22 40 40 28 66 33 13 80" +
                                    "24 47 32 60 99 03 45 02 44 75 33 53 78 36 84 20 35 17 12 50" +
                                    "32 98 81 28 64 23 67 10 26 38 40 67 59 54 70 66 18 38 64 70" +
                                    "67 26 20 68 02 62 12 20 95 63 94 39 63 08 40 91 66 49 94 21" +
                                    "24 55 58 05 66 73 99 26 97 17 78 78 96 83 14 88 34 89 63 72" +
                                    "21 36 23 09 75 00 76 44 20 45 35 14 00 61 33 97 34 31 33 95" +
                                    "78 17 53 28 22 75 31 67 15 94 03 80 04 62 16 14 09 53 56 92" +
                                    "16 39 05 42 96 35 31 47 55 58 88 24 00 17 54 24 36 29 85 57" +
                                    "86 56 00 48 35 71 89 07 05 44 44 37 44 60 21 58 51 54 17 58" +
                                    "19 80 81 68 05 94 47 69 28 73 92 13 86 52 17 77 04 89 55 40" +
                                    "04 52 08 83 97 35 99 16 07 97 57 32 16 26 26 79 33 27 98 66" +
                                    "88 36 68 87 57 62 20 72 03 46 33 67 46 55 12 32 63 93 53 69" +
                                    "04 42 16 73 38 25 39 11 24 94 72 18 08 46 29 32 40 62 76 36" +
                                    "20 69 36 41 72 30 23 88 34 62 99 69 82 67 59 85 74 04 36 16" +
                                    "20 73 35 29 78 31 90 01 74 31 49 71 48 86 81 16 23 57 05 54" +
                                    "01 70 54 71 83 51 54 69 16 92 33 48 61 43 52 01 89 19 67 48";

        internal static int[,] CreateArrayFromString()
        {
            int[,] array = new int[20, 20];
            string gridNoSpaces = grid.Replace(" ", "");

            for (int row = 0; row < 40; row = row + 2)
            {
                for (int column = 0; column < 40; column = column + 2)
                {
                    array[row == 0 ? 0 : row / 2, column == 0 ? 0 : column / 2] = Int32.Parse(gridNoSpaces[(row * 20) + column].ToString() + gridNoSpaces[(row * 20) + (column + 1)].ToString());// gridNoSpaces[(row * 20) + column]; //
                }
            }

            return array;
        }

        struct Direction
        {
            public string Name;
            public int RowStart;
            public int ColumnStart;
            public int RowMove;
            public int ColumnMove;
        }

        private static List<Direction> CreateDirections()
        {
            List<Direction> directions = new List<Direction>();
            directions.Add(new Direction() { Name = "Up", ColumnStart = 0, RowStart = 3, ColumnMove = 1, RowMove = -1 });
            directions.Add(new Direction() { Name = "Down", ColumnStart = 0, RowStart = 0, ColumnMove = 1, RowMove = 1 });
            //directions.Add(new Direction() { Name = "Left", ColumnStart = 3, RowStart = 0, ColumnMove = -1, RowMove = 0 });
            //directions.Add(new Direction() { Name = "Right", ColumnStart = 0, RowStart = 0, ColumnMove = 1, RowMove = 0 });
            //directions.Add(new Direction() { Name = "UpRight", ColumnStart = 0, RowStart = 3, ColumnMove = 1, RowMove = -1 });
            //directions.Add(new Direction() { Name = "DownRight", ColumnStart = 0, RowStart = 0, ColumnMove = 1, RowMove = 1 });
            //directions.Add(new Direction() { Name = "DownLeft", ColumnStart = 3, RowStart = 0, ColumnMove = -1, RowMove = 1 });
            //directions.Add(new Direction() { Name = "UpLeft", ColumnStart = 3, RowStart = 3, ColumnMove = -1, RowMove = -1 });
            return directions;
        }

        internal static int Solution()
        {
            int[,] gridarray = CreateArrayFromString();
            List<Direction> directions = CreateDirections();
            int columnEnd = 20, rowEnd = 20, maxSum = 0, tempSum = 0;

            //down
            for (int columnPosition = 0; columnPosition < columnEnd; columnPosition++)
            {
                for (int rowPosition = 0; rowPosition <= rowEnd - 4; rowPosition++)
                {
                    //Trace.WriteLine(gridarray[rowPosition, columnPosition] + "," + gridarray[rowPosition + 1, columnPosition] + "," + gridarray[rowPosition + 2, columnPosition] + "," + gridarray[rowPosition + 3, columnPosition]);
                    tempSum = gridarray[rowPosition, columnPosition] * gridarray[rowPosition + 1, columnPosition] * gridarray[rowPosition + 2, columnPosition] * gridarray[rowPosition + 3, columnPosition];
                    maxSum = tempSum > maxSum ? tempSum : maxSum;
                }                
            }

            //up
            for (int columnPosition = 0; columnPosition < columnEnd; columnPosition++)
            {
                for (int rowPosition = 3; rowPosition < rowEnd; rowPosition++)
                {
                    tempSum = gridarray[rowPosition, columnPosition] * gridarray[rowPosition - 1, columnPosition] * gridarray[rowPosition - 2, columnPosition] * gridarray[rowPosition - 3, columnPosition];
                    maxSum = tempSum > maxSum ? tempSum : maxSum;
                }
            }

            //right
            for (int rowPosition = 0; rowPosition < rowEnd; rowPosition++)
            {
                for (int columnPosition = 0; columnPosition < columnEnd - 3; columnPosition++)
                {
                    tempSum = gridarray[rowPosition, columnPosition] * gridarray[rowPosition, columnPosition + 1] * gridarray[rowPosition, columnPosition + 2] * gridarray[rowPosition, columnPosition + 3];
                    maxSum = tempSum > maxSum ? tempSum : maxSum;
                }
            }

            //left
            for (int rowPosition = 0; rowPosition < rowEnd; rowPosition++)
            {
                for (int columnPosition = 3; columnPosition < columnEnd; columnPosition++)
                {
                    tempSum = gridarray[rowPosition, columnPosition] * gridarray[rowPosition, columnPosition - 1] * gridarray[rowPosition, columnPosition - 2] * gridarray[rowPosition, columnPosition - 3];
                    maxSum = tempSum > maxSum ? tempSum : maxSum;
                }
            }

            //UpRight
            for (int rowPosition = 3; rowPosition < rowEnd; rowPosition++)
            {
                for (int columnPosition = 3; columnPosition < columnEnd - 3; columnPosition++)
                {
                    tempSum = gridarray[rowPosition, columnPosition] * gridarray[rowPosition - 1, columnPosition + 1] * gridarray[rowPosition - 2, columnPosition + 2] * gridarray[rowPosition - 3, columnPosition + 3];
                    maxSum = tempSum > maxSum ? tempSum : maxSum;
                }
            }

            //DownRight
            for (int rowPosition = 0; rowPosition < rowEnd - 3; rowPosition++)
            {
                for (int columnPosition = 0; columnPosition < columnEnd - 3; columnPosition++)
                {
                    tempSum = gridarray[rowPosition, columnPosition] * gridarray[rowPosition + 1, columnPosition + 1] * gridarray[rowPosition + 2, columnPosition + 2] * gridarray[rowPosition + 3, columnPosition + 3];
                    maxSum = tempSum > maxSum ? tempSum : maxSum;
                }
            }

            //DownLeft
            for (int rowPosition = 0; rowPosition < rowEnd - 3; rowPosition++)
            {
                for (int columnPosition = 3; columnPosition < columnEnd; columnPosition++)
                {
                    tempSum = gridarray[rowPosition, columnPosition] * gridarray[rowPosition + 1, columnPosition - 1] * gridarray[rowPosition + 2, columnPosition - 2] * gridarray[rowPosition + 3, columnPosition - 3];
                    maxSum = tempSum > maxSum ? tempSum : maxSum;
                }
            }

            //UpLeft
            for (int rowPosition = 3; rowPosition < rowEnd; rowPosition++)
            {
                for (int columnPosition = 3; columnPosition < columnEnd; columnPosition++)
                {
                    tempSum = gridarray[rowPosition, columnPosition] * gridarray[rowPosition - 1, columnPosition - 1] * gridarray[rowPosition - 2, columnPosition - 2] * gridarray[rowPosition - 3, columnPosition - 3];
                    maxSum = tempSum > maxSum ? tempSum : maxSum;
                }
            }

            return maxSum;
        }
    }

    [TestFixture]
    public class LargestProductInGridShould
    {
        [Test]
        public void TestOne()
        {
            Assert.AreEqual(70600674, LargestProductInGrid.Solution());
        }

        [Test]
        public void TestArray()
        {
            Assert.AreEqual(8, LargestProductInGrid.CreateArrayFromString()[0,0]);
            Assert.AreEqual(8, LargestProductInGrid.CreateArrayFromString()[0, 19]);
            Assert.AreEqual(49, LargestProductInGrid.CreateArrayFromString()[1, 0]);
            Assert.AreEqual(0, LargestProductInGrid.CreateArrayFromString()[1, 19]);
            Assert.AreEqual(48, LargestProductInGrid.CreateArrayFromString()[19, 19]);
        }
    }
}
