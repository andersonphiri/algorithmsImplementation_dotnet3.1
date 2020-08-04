using FibonacciDynamic;
using System;
using Xunit;

namespace Algorithms2020.FibonacciDynamic.Tests
{
    public class FibonacciDynamicTest
    {
        readonly int fib9 = 34;

        [Fact]
        public void TestFibCompute()
        {
            var fib = (new Fibonacci(9)).ComputeFib();
           
            Assert.Equal(fib9, fib);
        }
    }
}
