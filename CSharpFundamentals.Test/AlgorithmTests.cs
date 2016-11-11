using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpFundamentals.Test
{
    /// <summary>
    /// Summary description for AlgorithmTests
    /// </summary>
    [TestClass]
    public class AlgorithmTests
    {
        public AlgorithmTests()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void ReverseWordsInSentence()
        {
            string sentence = "I like Mondays but I prefer Fridays";
            string expectedResult = "I ekil syadnoM tub I referp syadirF";
            string reversed1 = CSharpFundamentals.IndependentExercices
                .ReverseWordsInSentence(sentence);
            string reversed2 = CSharpFundamentals.IndependentExercices
                .ReverseWordsInSentenceNoHelpers(sentence);
            string reversed3 = CSharpFundamentals.IndependentExercices
                .ReverseWordsInSentenceBySteps(sentence);

            Assert.AreEqual(reversed1, expectedResult);
            Assert.AreEqual(reversed2, expectedResult);
            Assert.AreEqual(reversed3, expectedResult);
        }
    }
}
