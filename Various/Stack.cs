using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Various
{
    class Stack<T>
    {
        private T[] _array = null;
        private int _currentTopOfStack = -1;

        public Stack()
        {
            _array = new T[1];
        }

        public void Push(T obj)
        {
            _currentTopOfStack++;
            if (_currentTopOfStack == _array.Length)
            {
                Array.Resize(ref _array, _array.Length*2);
            }            
            _array[_currentTopOfStack] = obj;
        }

        public T Pop()
        {
            T item = _array[_currentTopOfStack];
            _currentTopOfStack--;
            if(!IsEmpty())
                Array.Resize(ref _array, Length);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new Exception("Stack is empty");
            return _array[_currentTopOfStack];
        }

        public int Length
        {
            get
            {
                return _currentTopOfStack + 1;
            }
        }

        public bool IsEmpty()
        {
            return _currentTopOfStack == -1;
        }
    }

    [TestFixture]
    public class StackShould
    {
        [Test]
        public void TestOne()
        {
            Stack<int> test = new Stack<int>();
            test.Push(1);
            Assert.AreEqual(1, test.Peek());
            Assert.AreEqual(1, test.Pop());

            test.Push(2);
            test.Push(3);
            test.Push(4);

            Assert.AreEqual(4, test.Peek());
            Assert.AreEqual(4, test.Pop());
            Assert.AreEqual(3, test.Peek());
            Assert.AreEqual(3, test.Pop());
            Assert.AreEqual(2, test.Peek());
            Assert.AreEqual(2, test.Pop());

            Assert.AreEqual(true, test.IsEmpty());

            for(int i = 0; i < 100; i++)
            {
                test.Push(i);
            }

            Assert.AreEqual(100, test.Length);

            Assert.AreEqual(99, test.Peek());
            Assert.AreEqual(99, test.Pop());
        }
    }
}
