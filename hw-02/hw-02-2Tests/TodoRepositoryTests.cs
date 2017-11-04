using Microsoft.VisualStudio.TestTools.UnitTesting;
using hw_02_4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw_02_4.Tests
{
    [TestClass()]
    public class TodoRepositoryTests
    {

        [TestMethod()]
        public void GetTest()
        {
            TodoRepository repo=new TodoRepository();
            TodoItem item =new TodoItem("A");
            repo.Add(item);
            Assert.AreEqual(true,item.Equals(repo.Get(item.Id)));
        }

        [TestMethod()]
        public void AddTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem item = new TodoItem("A");
            repo.Add(item);
            Assert.AreEqual(true,repo.GetAll().ToArray()[0].Equals(item));
        }

        [TestMethod()]
        public void RemoveTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem item = new TodoItem("A");
            repo.Add(item);
            repo.Remove(item.Id);
            Assert.IsNull(repo.Get(item.Id));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem item = new TodoItem("A");
            repo.Add(item);
            item.MarkAsCompleted();
            
            Assert.AreEqual(true, item.Equals(repo.Update(item)));
        }

        [TestMethod()]
        public void MarkAsCompletedTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem item = new TodoItem("A");
            repo.Add(item);
            Assert.IsTrue(repo.MarkAsCompleted(item.Id));
        }

        [TestMethod()]
        public void GetAllTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem item = new TodoItem("A");
            Thread.Sleep(1);
            TodoItem itemc = new TodoItem("C");
            Thread.Sleep(1);
            TodoItem itemb = new TodoItem("B");
            repo.Add(itemc);
            repo.Add(itemb);
            repo.Add(item);
            Assert.AreEqual(true,repo.GetAll().ToArray()[0].Equals(itemb));
        }

        [TestMethod()]
        public void GetActiveTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem item = new TodoItem("A");
            TodoItem itemb = new TodoItem("B");
            item.MarkAsCompleted();
            repo.Add(itemb);
            repo.Add(item);
            Assert.AreEqual(true,repo.GetActive().ToArray()[0].Equals(itemb));
        }

        [TestMethod()]
        public void GetCompletedTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem item = new TodoItem("A");
            TodoItem itemb = new TodoItem("B");
            item.MarkAsCompleted();
            repo.Add(itemb);
            repo.Add(item);
            Assert.AreEqual(true,repo.GetCompleted().ToArray()[0].Equals(item));
        }

        [TestMethod()]
        public void GetFilteredTest()
        {
            TodoRepository repo = new TodoRepository();
            TodoItem item = new TodoItem("A");
            TodoItem itemb = new TodoItem("B");
            item.MarkAsCompleted();
            repo.Add(itemb);
            repo.Add(item);
            Assert.AreEqual(true,repo.GetFiltered(e=>e.Text.Equals("A")).ToArray()[0].Equals(item));
        }
    }
}