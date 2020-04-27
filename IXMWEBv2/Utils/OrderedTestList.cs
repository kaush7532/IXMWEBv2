using IXMWEBv2.Tests.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace IXMWEBv2.Utils
{
    [TestClass]
    public class OrderedTestList : BaseTest
    {
        private LoginTests_TC login_tc = new LoginTests_TC();

        [TestMethod] // place only on the list--not the individuals
        [Ignore]
        public void OrderedStepsTest()
        {
            OrderedTest.Run(TestContext, new List<OrderedTest>
            {
                new OrderedTest ( login_tc.LoginPageUI, false ),
                new OrderedTest ( login_tc.AdminLogIn, false ),
                new OrderedTest ( login_tc.LogOut, true ) // continue on failure
                // ...
            });
        }
    }
}