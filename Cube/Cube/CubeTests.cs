﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cube
{
    [TestClass]
    public class CubeTests
    {
        [TestMethod]
        public void lastThreeDigitsCheck1()
        {
            Assert.AreEqual(true, IsEightEightEight(45888));
        }
        [TestMethod]
        public void lastThreeDigitsCheckFail()
        {
            Assert.AreEqual(false, IsEightEightEight(45788));
        }
        
        bool IsEightEightEight (int result)
        {
            return (bool)((((result % 1000) / 100) == 8) && (((result % 100) / 10) == 8) && ((result % 10) == 8));      
        }

    }
}
