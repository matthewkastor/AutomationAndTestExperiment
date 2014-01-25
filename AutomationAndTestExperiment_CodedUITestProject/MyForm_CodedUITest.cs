using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace AutomationAndTestExperiment_CodedUITestProject
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class MyForm_CodedUITest
    {
        private System.Diagnostics.Process UiUnderTest;

        public MyForm_CodedUITest()
        {
        }

        [TestMethod]
        public void MyForm_MyStaticClass_SayHi_Btn_Click_CodedUITest()
        {
            this.UIMap.MyForm_MyStaticClass_SayHi_Btn_Click();
            this.UIMap.AssertMessageIsHi();
            //Assert.AreEqual(false, true);
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        //Use TestInitialize to run code before running each test 
        [TestInitialize()]
        public void MyTestInitialize()
        {
            UiUnderTest = System.Diagnostics.Process.Start("..\\..\\..\\AutomationAndTestExperiment_UI\\bin\\Debug\\AutomationAndTestExperiment.exe");
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            UiUnderTest.CloseMainWindow();
        }

        #endregion

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
        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}
