﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Columns
{ 
    [TestClass]
    public class ColumnsTests
    {
        [TestMethod]
        public void FirstArea()
        {
        float area = CalculateArea(1, 1, 1, 1, 1, 1);
        Assert.AreEqual(0, area);
        }
         float CalculateArea(float Xa, float Ya, float Xb, float Yb, float Xc, float Yc)
        {
            float determinant = Xa * Yb + Xb * Yc + Ya * Xc - Yb * Xc - Yc * Xa - Ya * Xb;
            return determinant;
        }
    }
}
