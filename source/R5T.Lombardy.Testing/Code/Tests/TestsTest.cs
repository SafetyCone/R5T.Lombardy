using System;
//using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace R5T.Lombardy.Testing
{
    /// <summary>
    /// Shows that the constructor method of a class can be used to perform setup.
    /// </summary>
    [TestClass]
    public class TestsTest
    {
        private const string ValueA = "A";
        private const string ValueB = "B";
        private const string ValueC = "C";


        private string StringA { get; set; }


        /// <summary>
        /// Shows that the class constructor can be used to perform test setup.
        /// </summary>
        public TestsTest()
        {
            this.StringA = TestsTest.ValueB;
        }


        [TestInitialize]
        public void TestInitialize()
        {
            Console.WriteLine("Initializing test...");

            //Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
            //Trace.WriteLine("Initializing test...");


            this.StringA = TestsTest.ValueC;
        }

        [TestMethod]
        public void TestStringAValue()
        {
            Assert.AreEqual(this.StringA, TestsTest.ValueB);
        }
    }
}
