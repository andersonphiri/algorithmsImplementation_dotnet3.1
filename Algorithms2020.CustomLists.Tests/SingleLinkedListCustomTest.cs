using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Algorithms2020.CustomLists.Tests
{
    [TestClass]
    public class SingleLinkedListCustomTest
    {
        [TestMethod]
        public void TestInsertDelete()
        {
            SingleLinkedListCustom<int> single = new SingleLinkedListCustom<int>();
            single.InsertDefault(20);
            single.InsertBegining(25);
            single.InsertBegining(5);
            single.InsertDefault(2);
            single.InsertBegining(250);
            var valueAt = single.GetValueAt(1);
            Assert.AreEqual(250, valueAt.Data);
            single.DeletePosition(1);
            single.DeletePosition(1);
            single.DeletePosition(1);
            valueAt = single.GetValueAt(2);
            Assert.AreEqual(2, valueAt.Data);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            {
                valueAt = single.GetValueAt(-22);
            });
        }
    }
}
