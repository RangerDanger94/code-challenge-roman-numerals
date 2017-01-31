using System;
using System.Collections.Generic;
using static RomanNumeralTranslator.RomanNumeralTranslator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RomanNumeralTranslatorTest
{
    [TestClass]
    public class TranslatorTest
    {
        private Dictionary<int, string> translations = new Dictionary<int, string>
        {
            {4      , "IV"},
            {34     , "XXXIV"},
            {267    , "CCLXVII"},
            {764    , "DCCLXIV"},
            {987    , "CMLXXXVII"},
            {1983   , "MCMLXXXIII"},
            {2014   , "MMXIV"},
            {4000   , "MMMM"},
            {4999   , "MMMMCMXCIX"}
        };

        [TestMethod]
        public void ValidNumeralToInt()
        {
            foreach(KeyValuePair<int, string> t in translations)
            {
                int result = RomanNumeralToInt(t.Value);
                Assert.AreEqual(t.Key, result);
            }
        }

        [TestMethod]
        public void ValidIntToNumeral()
        {
            foreach (KeyValuePair<int, string> t in translations)
            {
                string result = IntToRomanNumeral(t.Key);
                Assert.AreEqual(t.Value, result);
            }
        }
    }
}
