using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw_02_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw_02_4.Tests
{
    [TestClass()]
    public class TodoItemTests
    {
        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoItem item=new TodoItem("Abc");
            item.MarkAsCompleted();
            Assert.AreEqual(item.IsCompleted, true);
        }
        [TestMethod()]
        public void EqualsTest()
        {
            TodoItem item = new TodoItem("Abc");
            item.MarkAsCompleted();
            Assert.AreEqual(item.Equals(item), true);
        }
        [TestMethod()]
        public void DoesntEqualsTest()
        {
            TodoItem item = new TodoItem("Abc");
            item.MarkAsCompleted();
            Assert.AreEqual(item.Equals(new TodoItem("A")), false);
        }
        [TestMethod()]
        public void DoesntEqualHashTest()
        {
            TodoItem item = new TodoItem("Abc");
            item.MarkAsCompleted();
            Assert.AreEqual(item.GetHashCode().Equals(new TodoItem("A").GetHashCode()), false);
        }
    }
}