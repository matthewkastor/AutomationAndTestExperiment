namespace AutomationAndTestExperiment_CodedUITestProject
{
    using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;


    public partial class UIMap
    {

        /// <summary>
        /// Asserts that the message is "Hi"
        /// </summary>
        public void AssertMessageIsHi()
        {
            #region Variable Declarations
            WinEdit uIMessageDisplayEdit = this.UIMyFormWindow.UIMessageDisplayWindow.UIMessageDisplayEdit;
            #endregion

            // Verify that the 'Text' property of 'MessageDisplay' text box equals 'Hi'
            Assert.AreEqual(this.AssertMessageIsHiExpectedValues.UIMessageDisplayEditText, uIMessageDisplayEdit.Text, "Message displayed was not \"Hi\"");
        }

        public virtual AssertMessageIsHiExpectedValues AssertMessageIsHiExpectedValues
        {
            get
            {
                if ((this.mAssertMessageIsHiExpectedValues == null))
                {
                    this.mAssertMessageIsHiExpectedValues = new AssertMessageIsHiExpectedValues();
                }
                return this.mAssertMessageIsHiExpectedValues;
            }
        }

        private AssertMessageIsHiExpectedValues mAssertMessageIsHiExpectedValues;

        /// <summary>
        /// Clicks the SayHi button on MyForm
        /// </summary>
        public void MyForm_MyStaticClass_SayHi_Btn_Click()
        {
            #region Variable Declarations
            WinButton uIMyStaticClassSayHiButton = this.UIMyFormWindow.UIMyStaticClassSayHiWindow.UIMyStaticClassSayHiButton;
            #endregion

            // Click 'MyStaticClass.SayHi' button
            Mouse.Click(uIMyStaticClassSayHiButton, new Point(197, 12));
        }
    }
    /// <summary>
    /// Parameters to be passed into 'AssertMessageIsHi'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "12.0.21005.1")]
    public class AssertMessageIsHiExpectedValues
    {

        #region Fields
        /// <summary>
        /// Verify that the 'Text' property of 'MessageDisplay' text box equals 'Hi'
        /// </summary>
        public string UIMessageDisplayEditText = AutomationAndTestExperiment_PortableClassLib
            .MyStaticClass.SayHi();
        #endregion
    }
}
