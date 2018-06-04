using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace HackerRank
{
    class QueuesATaleOfTwoStacks //Works on hacker rank, but slow
    {
        public static string Solution(string[] array)
        {
            Stack<string> oldestValuesAtTop = new Stack<string>();
            Stack<string> newestValuesAtTop = new Stack<string>();
            string output = string.Empty;

            foreach(string s in array.Skip(1))
            {
                string value = string.Empty;

                string action = s.Split(' ')[0];
                if(s.Split(' ').Count() == 2)
                    value = s.Split(' ')[1];

                switch(action)
                {
                    case "1":   //enqueue
                        oldestValuesAtTop.Push(value);  
                        break;
                    case "2":   //dequeue
                        if (newestValuesAtTop.Count == 0)
                        {
                            while (oldestValuesAtTop.Count > 0)
                                newestValuesAtTop.Push(oldestValuesAtTop.Pop());                            
                        }
                        newestValuesAtTop.Pop();
                        break;
                    case "3":   //print
                        if (newestValuesAtTop.Count == 0)
                        {
                            while (oldestValuesAtTop.Count > 0)
                                newestValuesAtTop.Push(oldestValuesAtTop.Pop());
                        }
                        output += newestValuesAtTop.Peek() + "\n";
                        break;
                    default:
                        throw new Exception("Unknown action!");
                }
            }

            return output;
        }
    }

    [TestFixture]
    public class QueuesATaleOfTwoStacksShould
    {
        [Test]
        public void TestOne()
        {
            //Assert.AreEqual("14\n", QueuesATaleOfTwoStacks.Solution(new string[] { "10", "1 42", "2", "1 14", "3" }));
            //Assert.AreEqual("14\n14\n", QueuesATaleOfTwoStacks.Solution(new string[] { "10", "1 42", "2", "1 14", "3", "1 28", "3" }));
            Assert.AreEqual("14\n14\n", QueuesATaleOfTwoStacks.Solution(new string[] { "10", "1 42", "2", "1 14", "3", "1 28", "3", "1 60", "1 78", "2", "2" }));
            //Assert.AreEqual("14\n14\n60\n", QueuesATaleOfTwoStacks.Solution(new string[] { "1 42", "2", "1 14", "3", "1 28", "3", "1 60", "1 78", "2", "2", "3" }));
        }
    }
}
