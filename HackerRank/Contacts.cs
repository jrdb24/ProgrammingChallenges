using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Threading;

namespace HackerRank
{
    class Contacts //100% on hackerrank
    {
        private static Dictionary<string, int> _contactList;

        public static List<int> Solution(string[] A)
        {
            _contactList = new Dictionary<string, int>();
            int n = Convert.ToInt32(A[0]);  //Console.ReadLine());

            List<int> output = new List<int>();

            for (int a0 = 0; a0 < n; a0++)
            {
                string[] tokens_op = A[a0+1].Split(' '); //Console.ReadLine().Split(' ');
                string op = tokens_op[0];
                string contact = tokens_op[1];

                switch (op)
                {
                    case "add":
                        Add(contact);
                        break;
                    case "find":
                        output.Add(Find(contact));
                        break;
                    default:
                        throw new Exception("Unknown Operation");

                }
            }

            return output;
        }

        private static void Add(string contact)
        {
            for (int i = 1; i <= contact.Length; i++)
            {
                String sub = contact.Substring(0, i);

                if (_contactList.ContainsKey(sub))
                    _contactList[sub]++;
                else
                    _contactList.Add(sub, 1);
            }
        }

        private static int Find(string toFind)
        {
            int count = 0;
            _contactList.TryGetValue(toFind, out count);
            return count;
        }
    }

    [TestFixture]
    public class ContactsShould
    {
        [Test]
        public void TestOne()
        {
            List<int> temp = new List<int>();
            temp = Contacts.Solution(new string[] { "4", "add hack", "add hackerrank", "find hac", "find hak" });
            Assert.Contains(0, temp);
            Assert.Contains(2,temp);
        }
    }
}
