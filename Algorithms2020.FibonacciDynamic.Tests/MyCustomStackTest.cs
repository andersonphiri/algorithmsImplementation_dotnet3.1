using Algorithms2020.CustomQueue;
using Algorithms2020.CustomStack;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Algorithms2020.FibonacciDynamic.Tests
{
   
    public class MyCustomStackTest
    {
        [Fact]
        public void TestStack()
        {
            var myStack = new MyCustomStack(30);
            myStack.Push(20);
            myStack.Push(34);
            myStack.Push(2);
            Assert.Equal(2, myStack.Peek());
            myStack.Pop();
            Assert.Equal(34, myStack.Peek());
            myStack.Pop();
            Assert.Equal(20, myStack.Pop());
            Assert.True(myStack.IsEmpty());
            Assert.Equal(0, myStack.Size());
            Assert.Throws<InvalidOperationException>(()=>
            {
                myStack.Pop();
            });

        }


      
    }
}
