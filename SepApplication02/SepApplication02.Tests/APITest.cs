using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SepApplication02.Tests
{
    [TestClass]
    public class APITest
    {
        [TestMethod]
        public void TestLogin()
        {
            var api = new API();
            var result0 = api.Login("phamngocduy", "tradristel");
            var result1 = api.Login("phamngocduy", "123456789");
            Assert.AreEqual(0, result0.Code);
            Assert.AreEqual(1, result1.Code);
        }

        [TestMethod]
        public void TestGetCourse()
        {
            var api = new API();
            var result = api.GetCourses("ND");
            Assert.AreEqual(3, result.Code);
        }

        [TestMethod]
        public void TestGetStudent()
        {
            var api = new API();
            var result0 = api.GetStudents("T152212");
            var result1 = api.GetStudents("T156789");
            Assert.AreEqual(0, result0.code);
            Assert.AreEqual(1, result1.code);
           
        }
    }
}
