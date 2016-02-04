﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BinaryOperations
{
    [TestClass]
    public class BinaryOperationsTests
    {
        [TestMethod]
        public void CalculateArrayLengthTest()
        {
            Assert.AreEqual(6, (CalculateNeededArrayLength(49)));
        }
        [TestMethod]
        public void FirstToBinaryTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 0, 0, 0, 1 }, ToBinary(49));
        }
        [TestMethod]
        public void SecondToBinaryTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0, 1, 1, 0 }, ToBinary(38));
        }
        [TestMethod]
        public void ThirdToBinaryTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 }, ToBinary(123456));
        }
        [TestMethod]
        public void FirstNotOperatorTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 1, 1, 1, 0 }, NotOperator(new byte[] { 1, 1, 0, 0, 0, 1 }));
        }
        [TestMethod]
        public void SecondNotOperatorTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 1, 0, 0, 1 }, NotOperator(new byte[] { 1, 0, 0, 1, 1, 0 }));
        }
        [TestMethod]
        public void ThirdNotOperatorTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 0, 0, 1, 1, 1, 0, 1, 1, 0, 1, 1, 1, 1, 1, 1 }, NotOperator(new byte[] { 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0 }));
        }
        [TestMethod]
        public void FirstOrOperatorTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, OrOperator(new byte[] { 1, 0, 1 }, new byte[] { 1, 1, 0 }));
        }
        [TestMethod]
        public void ToBinary()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1 }, ToBinary(3));
        }
        [TestMethod]
        public void SecondOrOperatorTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 1, 1 }, OrOperator(ToBinary(5), ToBinary(3)));
        }
        [TestMethod]
        public void FirstAndOperatorTest()
        {
            CollectionAssert.AreEqual(new byte[] { 1, 0, 0, 0, 0, 0 }, AndOperator(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 0, 0, 1, 1, 0 }));
        }
        [TestMethod]
        public void FirstXorOperatorTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 1, 0, 1, 1, 1 }, XorOperator(new byte[] { 1, 1, 0, 0, 0, 1 }, new byte[] { 1, 0, 0, 1, 1, 0 }));
        }
        [TestMethod]
        public void RightShift()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 1 }, RightShift(new byte[] { 0, 1, 0 }, 1));
        }
        [TestMethod]
        public void SecondRightShiftTest()
        {
            CollectionAssert.AreEqual(new byte[] { 0, 0, 1 }, RightShift(new byte[] { 1, 1, 0 }, 2));
        }
        [TestMethod]
        public void ThirdRightShiftTest()
        {
            CollectionAssert.AreEqual(ToBinary(2), LeftShift(ToBinary(1), 1));
        }
        [TestMethod]
        public void FirstIsNotSmallerThanSecond()
        {
            Assert.AreEqual(false, LessThan(ToBinary(49), ToBinary(8)));
        }
        [TestMethod]
        public void FirstIsNotSMallerThanSecond()
        {
            Assert.AreEqual(false, LessThan(ToBinary(49), ToBinary(38)));
        }
        [TestMethod]
        public void FirstIsSmallerThanSecond()
        {
            Assert.AreEqual(true, LessThan(ToBinary(48), ToBinary(49)));
        }
        [TestMethod]
        public void FirstIsGreaterThanSecond()
        {
            Assert.AreEqual(true, GreaterThan(ToBinary(49), ToBinary(13)));
        }
        [TestMethod]
        public void FirstIsGReaterThanSecond()
        {
            Assert.AreEqual(true, GreaterThan(ToBinary(49), ToBinary(38)));
        }
        [TestMethod]
        public void FirstIsNotGreaterThanSecond()
        {
            Assert.AreEqual(false, GreaterThan(ToBinary(48), ToBinary(49)));
        }
        [TestMethod]
        public void FirstIsGREaterThanSecond()
        {
            Assert.AreEqual(true, GreaterThan(ToBinary(49), ToBinary(48)));
        }
        [TestMethod]
        public void FirstIsGREAterThanSecond()
        {
            Assert.AreEqual(true, GreaterThan(ToBinary(1124), ToBinary(5)));
        }
        [TestMethod]
        public void GetAt0()
        {
            byte[] byteArray = { 3, 2, 1 };
            Assert.AreEqual(1, GetAt(byteArray, 0));
        }
        [TestMethod]
        public void GetAt1()
        {
            byte[] byteArray = { 3, 2, 1 };
            Assert.AreEqual(2, GetAt(byteArray, 1));
        }
        [TestMethod]
        public void GetAt2()
        {
            byte[] byteArray = { 3, 2, 1 };
            Assert.AreEqual(3, GetAt(byteArray, 2));
        }
        [TestMethod]
        public void GetAt3()
        {
            byte[] byteArray = { 3, 2, 1 };
            Assert.AreEqual(0, GetAt(byteArray, 3));
        }
        [TestMethod]
        public void FiveEqualsFive()
        {
            Assert.AreEqual(true, Equal(ToBinary(5), ToBinary(5)));
        }
        [TestMethod]
        public void TwentyEqualsTwenty()
        {
            Assert.AreEqual(true, Equal(ToBinary(20), ToBinary(20)));
        }
        [TestMethod]
        public void ThreeIsNotEqualToFive()
        {
            Assert.AreEqual(false, Equal(ToBinary(3), ToBinary(5)));
        }


        byte[] Summation(byte[] firstByteArray, byte[] secondByteArray)
        {
            byte[] resultedByteArray = new byte[Math.Max(firstByteArray.Length, secondByteArray.Length)];
            for (int i = 0; i < Math.Max(firstByteArray.Length, secondByteArray.Length); i++)
            {
                int remainder = 0;
                if ((byte)GetAt(firstByteArray, i) + GetAt(secondByteArray, i) > 1) remainder = 1;
                else remainder = 0;
                resultedByteArray[resultedByteArray.Length - 1 - i] = (byte)(GetAt(firstByteArray, i) + GetAt(secondByteArray, i) + remainder);
            }
            return resultedByteArray;
        }

        bool Equal(byte[] firstByteArray, byte[] secondByteArray)
        {
            return (((LessThan(firstByteArray, secondByteArray) == true) && (GreaterThan(firstByteArray, secondByteArray) == false)) || (((LessThan(firstByteArray, secondByteArray) == false) && ((GreaterThan(firstByteArray, secondByteArray) == true)))));
        }

        byte GetAt(byte[] byteArray, int i)
        {
            if (i >= byteArray.Length) return 0;
            return byteArray[byteArray.Length - 1 - i];
        }

        bool GreaterThan(byte[] firstByteArray, byte[] secondByteArray)
        {
            if (LessThan(firstByteArray, secondByteArray) == false) return true;
            return false;
        }

        bool LessThan(byte[] firstByteArray, byte[] secondByteArray)
        {
            for (int i = 0; i < Math.Max(firstByteArray.Length, secondByteArray.Length); i++)
            {
                if (GetAt(firstByteArray, i) > GetAt(secondByteArray, i))
                    return false;
            }
            return true;
        }
        /// 49 -> 110001
        /// 48 -> 110000
        /// 38 -> 100110

        byte[] LeftShift(byte[] byteArray, int shiftingNumber)
        {
            byte[] secondByte = new byte[byteArray.Length + shiftingNumber];
            for (int i = 0; i < byteArray.Length; i++)
            {
                secondByte[i] = byteArray[i];
            }
            return secondByte;
        }

        byte[] RightShift(byte[] firstByteArray, int shiftingNumber)
        {   
            byte[] secondByte = firstByteArray;
            while (shiftingNumber > 0)
            {
                for (int i = secondByte.Length - 1; i > 0; i--)
                {
                    secondByte[i] = secondByte[i - 1];
                }
                secondByte[0] = 0;
                shiftingNumber--;
            }
            return secondByte;
        }

        byte[] XorOperator(byte[] firstByteArray, byte[] secondByteArray)
        {
            byte[] wantedByte = new byte[Math.Max(firstByteArray.Length, secondByteArray.Length)];
            for (int i = 0; i < Math.Max(firstByteArray.Length, secondByteArray.Length); i++)
            {
                wantedByte[wantedByte.Length - 1 - i] = (byte)((((GetAt(firstByteArray, i) == 1) && (GetAt(secondByteArray, i) == 0)) || ((GetAt(firstByteArray, i) == 0) && (GetAt(secondByteArray, i) == 1))) ? 1 : 0);
            } 
            return wantedByte;
        }

        byte[] AndOperator(byte[] firstByteArray, byte[] secondByteArray)
        {
            byte[] wantedByteArray = new byte[Math.Max(firstByteArray.Length, secondByteArray.Length)];
            for (int i = 0; i < Math.Max(firstByteArray.Length, secondByteArray.Length); i++)
            {
                wantedByteArray[wantedByteArray.Length - 1 - i] = (byte)(((GetAt(firstByteArray, i) == 1) && (GetAt(secondByteArray, i) == 1)) ? 1 : 0);
            } 
            return wantedByteArray;
        }

        byte[] OrOperator(byte[] firstByteArray, byte[] secondByteArray)
        {
            byte[] wantedByteArray = new byte[Math.Max(firstByteArray.Length, secondByteArray.Length)];
            for (int i = 0; i < firstByteArray.Length; i++)
            {
                wantedByteArray[i] = (byte)((((GetAt(firstByteArray, i) == 0) && ((GetAt(secondByteArray, i) == 0)) ? 0 : 1)));
            } 
            return wantedByteArray;
        }

        byte[] NotOperator(byte[] byteArray)
        {
            byte[] wantedByteArray = new byte[byteArray.Length];
            for (int i = 0; i < byteArray.Length; i++)
            {
                wantedByteArray[wantedByteArray.Length - 1 - i] = (byte)((GetAt(byteArray, i) == 0) ? 1 : 0); 
            }
            return wantedByteArray;
        }
        byte[] ToBinary(int number)
        {   
            byte[] binaryVersion = new byte[CalculateNeededArrayLength(number)];
            while (number > 0)
            {
                binaryVersion[CalculateNeededArrayLength(number) - 1] = (byte)(number % 2);
                number = number / 2;
            }
            return binaryVersion;
        }

        int CalculateNeededArrayLength(int number)
        {
            int length = 0;
            while (number > 0)
            {
                number /= 2;
                length += 1;
            }
            return length;
        }
    }
}
