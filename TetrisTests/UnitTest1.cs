using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tetris;
using Tetris.Controllers;
using System.Windows.Forms;

namespace TetrisTests
{
    [TestClass]
    public class UnitTest1
    {       
        [TestMethod]
        public void TestMethod1()
        {
            Form2 form = new Form2();
            form.Show();

            Button button = (Button)GetControl("button2", form);
            button.PerformClick();

            Assert.IsTrue(form.IsDisposed);
        }

        [TestMethod]
        public void TestMethod2()
        {
            MapController.ClearMap();
            Assert.AreEqual(0, MapController.score);
        }

        private Control GetControl(string name, Form form)
        {
            return form.Controls.Find(name, true)[0];
        }
    }
}

