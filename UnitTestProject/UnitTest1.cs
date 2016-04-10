using System;
using ContentConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var badWords = Program.StoryOne();

            Assert.AreEqual(2, badWords, "Number of Bad Words are Correct.");
        }
    }
}
