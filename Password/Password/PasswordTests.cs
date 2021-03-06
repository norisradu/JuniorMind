﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Password
{
    [TestClass]
    public class PasswordTests
    {
        [TestMethod]
        public void CheckTheNumberOfUppercaseCharacters()
        {
            var password = GetUppercase(new PasswordSettings(5, 2, 1, 2, true, true));
            Assert.AreEqual(true, Count(password, 2));
        }
        [TestMethod]
        public void CheckTheNumberOfDigits()
        {
            var password = GetDigits(new PasswordSettings(16, 5, 8, 3, true, true));
            Assert.AreEqual(true, Count(password, 8));
        }
        [TestMethod]
        public void CheckTheNumberOfSymbols()
        {
            var password = GetSymbols(7);
            Assert.AreEqual(true, Count(password, 7));
        }
        [TestMethod]
        public void CheckTheLengthOfThePassword()
        {
            var password = GetPassword(new PasswordSettings(23, 10, 5, 8, true, true));
            Assert.AreEqual(true, Count(password, 23));
        }
        [TestMethod]
        public void ShouldCountLowercaseCharacters()
        {
            var password = GetPassword(new PasswordSettings(25, 5, 4, 3, false, true));
            Assert.AreEqual(13, CountLowercase(password));
        }
        [TestMethod]
        public void ShouldCountLowercaseChars()
        {
            var password = GetPassword(new PasswordSettings(15, 2, 1, 3, true, true));
            Assert.AreEqual(9, CountLowercase(password));
        }
        [TestMethod]
        public void MoreComplexTest()
        {
            var password = GetPassword(new PasswordSettings(50, 10, 20, 5, false, false));
            Assert.AreEqual(true, Count(password, 50));
            var uppercase = GetUppercase(new PasswordSettings(50, 10, 20, 5, true, true), "l1Io0O");
            Assert.AreEqual(true, Count(uppercase,10));
            var digits = GetDigits(new PasswordSettings(50, 10, 20, 5, true, true), "l1Io0O");
            Assert.AreEqual(true, Count(digits, 20));
            var symbols = GetSymbols(5, "{}[]()/\'~,;.<>\"");
            Assert.AreEqual(true, Count(symbols, 5));
            Assert.AreEqual(15, CountLowercase(password));
        }
       

        public struct PasswordSettings
        {
            public int chosenLength;
            public int uppercaseLetters;
            public int digits;
            public int symbols;
            public bool excludeSimilar;
            public bool excludeAmbiguous;

            public PasswordSettings(int chosenLength, int uppercaseLetters, int digits, int symbols, bool excludeSimilar, bool excludeAmbiguous)
            {
                this.chosenLength = chosenLength;
                this.uppercaseLetters = uppercaseLetters;
                this.digits = digits;
                this.symbols = symbols;
                this.excludeSimilar = excludeSimilar;
                this.excludeAmbiguous = excludeAmbiguous;
            }
        }

        static Random random = new Random();

        public static int ReturnRandomCharacter(int lowerBound, int upperBound)
        {
            return random.Next(lowerBound, upperBound);
        }

        public static char ReturnRandomUppercaseLetter()
        {
            return (char)(ReturnRandomCharacter('A', 'Z'));
        }

        public static char ReturnRandomSymbol()
        {
            string symbols = "!@#$%^&*()-=_+[{}];:'<,>.?/";
            int i = random.Next(0, symbols.Length - 1);
            return symbols[i];
        }

        public static int ReturnRandomDigit()
        {
            return ReturnRandomCharacter(0, 9);
        }

        string GetString(int count, int lowerBound, int upperBound, string excluded = "l1Io0O{}[]()/\'~,;.<>\"")
        {
            string generated = string.Empty;
            int i = 0;
                while (i < count)
                {
                    char randomUppercase = (char)ReturnRandomCharacter(lowerBound, upperBound);
                var doesContain = excluded.Contains(randomUppercase.ToString());
                    if (!doesContain)
                    {
                        generated += randomUppercase;
                        i++;
                    }
                }
            return generated;
        }

         string GetUppercase(PasswordSettings password, string similar = "l1Io0O")
        {
            if (password.excludeSimilar)
            return GetString(password.uppercaseLetters, 'A', 'Z', "l1Io0O");
            return GetString(password.uppercaseLetters, 'A', 'Z', string.Empty);
        }

        string GetDigits(PasswordSettings password, string similar = "l1Io0O")
        {
            if (password.excludeAmbiguous)
            return GetString(password.digits, 0, 9, "l1Io0O");
            return GetString(password.digits, 0, 9, string.Empty);
        }

        string GetSymbols(int count, string excludedSymbols = "")
        {
            string symbols = string.Empty;
            int i = 0;
                while (i < count)
                {
                char randomSymbol = ReturnRandomSymbol();
                        symbols += randomSymbol;
                        i++;
                 }
            return symbols;
        }

        string GetPassword(PasswordSettings password)
        {
            var excluded = password.excludeSimilar ? "l1Io0O" : string.Empty;
            var excludedSymbols = password.excludeAmbiguous ? "{}[]()/\'~,;.<>\"" : string.Empty;
            var result = GetString(GetLowercaseCount(password), 'a', 'z', excluded);
            result += GetString(password.uppercaseLetters, 'A', 'Z', excluded);
            result += GetString(password.digits, 0, 9, excluded);
            result += GetSymbols(password.symbols, excludedSymbols);
            return result;
        }

        int GetLowercaseCount(PasswordSettings password)
        {
            int lowercaseCount = password.chosenLength - password.uppercaseLetters - password.digits - password.symbols;
            return lowercaseCount;
        }

        int CountLowercase(string password)
        {
            int counter = 0;
            foreach (char c in password)
            {
                if (Char.IsLower(c))
                    counter++;
            }
            return counter;
        }


        bool Count(string password, int toBeCounted)
        {
            return (password.Length == toBeCounted);
        }
    }
}
