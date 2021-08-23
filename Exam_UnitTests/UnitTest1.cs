using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Exam_Tests;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Exam_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string path = @"C:\Temp";
            Text t = new Text(path);
            if (t == null)
            {
                Assert.Inconclusive();
            }
              
        }
        [TestMethod]
        public void TestMethod2()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Assert.IsNotNull(t);
            
        }
        [TestMethod]
        public void TestMethod3()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Assert.IsNotNull(t.ReadText());

        }
        [TestMethod]
        public void TestMethod4()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Dictionary<string, int> v = t.ReadText();       
            Assert.IsTrue(t.SortDescending(v) != null);

        }
        [TestMethod]
        public void TestMethod5()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Dictionary<string, int> v = t.ReadText();           
            IOrderedEnumerable<KeyValuePair<string, int>> vacabulary = t.SortDescending(v);
            string fileresult = Directory.GetCurrentDirectory();
            Assert.IsTrue(t.SaveToFile(vacabulary, fileresult) == 0);

        }
        [TestMethod]
        public void TestMethod6()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Dictionary<string, int> v = t.ReadText();
            IOrderedEnumerable<KeyValuePair<string, int>> vacabulary = t.SortDescending(v);
            
            Assert.IsTrue(v.Count == vacabulary.Count());
            
        }
        [TestMethod]
        public void TestMethod7()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Dictionary<string, int> v = t.ReadText();
            IOrderedEnumerable<KeyValuePair<string, int>> vacabulary = t.SortDescending(v);

            Assert.IsTrue(vacabulary.First().Value>vacabulary.Last().Value);
        }
        [TestMethod]
        public void TestMethod8()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Dictionary<string, int> v = t.ReadText();
            IOrderedEnumerable<KeyValuePair<string, int>> vacabulary = t.SortDescending(v);

            Assert.IsFalse(v.First().Value > v.Last().Value);
        }
        [TestMethod]
        public void TestMethod9()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Assert.IsFalse(t.GetFiles == null);
        }
        [TestMethod]
        public void TestMethod10()
        {
            string path = Directory.GetCurrentDirectory();
            Text t = new Text(path);
            Assert.IsFalse(t.GetFiles.Contains(".txt"));
        }
    }
}
