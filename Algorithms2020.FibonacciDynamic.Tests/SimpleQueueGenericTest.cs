using Algorithms2020.CustomQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Algorithms2020.FibonacciDynamic.Tests
{
    
    public class SimpleQueueGenericTest
    {
        [Fact]
        public void TestSimpleGenericQueue()
        {
            SimpleQueueGeneric<string> simpleQueue = new SimpleQueueGeneric<string>(2, 3);
            simpleQueue.Enqueue("item1");
            simpleQueue.Enqueue("item2");
            var item1 = simpleQueue.Dequeue();
            Assert.False(simpleQueue.IsEmpty());
            Assert.Equal("item1", item1);
            var item2 = simpleQueue.Dequeue();
            Assert.Equal("item2", item2);
            Assert.True(simpleQueue.IsEmpty());
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                simpleQueue.Dequeue();
            });

        }

        [Fact]
        public void TestSimpleGenericCircularQueue()
        {
            SimpleQueueGenericCircular<string> simpleQueue = new SimpleQueueGenericCircular<string>(2, 3);
            simpleQueue.Enqueue("item1");
            simpleQueue.Enqueue("item2");
            var item1 = simpleQueue.Dequeue();
            Assert.False(simpleQueue.IsEmpty());
            Assert.Equal("item1", item1);
            var item2 = simpleQueue.Dequeue();
            Assert.Equal("item2", item2);
            Assert.True(simpleQueue.IsEmpty());
            Assert.Throws<System.InvalidOperationException>(() =>
            {
                simpleQueue.Dequeue();
            });

        }

    }
}
