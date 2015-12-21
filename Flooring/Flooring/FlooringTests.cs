﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flooring
{
    [TestClass]
    public class FlooringTests
    {
        [TestMethod]
        public void MostSimpleExample()
        {
            float neededPieces = CalculateFloorPieces(1, 1, 1, 1);
            Assert.AreEqual(2, neededPieces);
        }
        float CalculateFloorPieces(int roomLength, int roomWidth, int pieceLength, int pieceWidth)
        {
            int roomArea = roomLength * roomWidth;
            int pieceArea = pieceLength * pieceWidth;
            int smallerNumberOfNeededPieces = roomArea / pieceArea;
            float loss = ((float)(0.15)) * smallerNumberOfNeededPieces;
            float notRoundedNumberOfNeededPieces = (float)(smallerNumberOfNeededPieces + loss);
            double finalNumberOfNeededPieces = Math.Ceiling(notRoundedNumberOfNeededPieces);
            return (float)finalNumberOfNeededPieces;
        }
    }
}
