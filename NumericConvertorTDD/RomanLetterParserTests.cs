using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace NumericConvertorTDD
{
    [TestFixture]
    public class RomanLetterParserTests
    {
        [TestCase("XCIX", "XC,IX")]
        public void Roman_Valid_99(string roman, string romanDigitsCommaSeprated)
        {
            IEnumerable<string> letterParser = new RomanLetterParser(roman);

            var romanDigits = romanDigitsCommaSeprated.Split(',');

            int index = 0;
            foreach (var letter in letterParser)
            {
                Assert.AreEqual(romanDigits[index++], letter);
            }
        }

        [TestCase("XM", "")]
        [TestCase("IM", "")]
        [TestCase("XD", "")]
        [TestCase("ID", "")]
        [TestCase("IC", "")]
        [TestCase("IL", "")]
        public void Roman_InValid_990(string roman, string romanDigitsCommaSeprated)
        {
            IEnumerable<string> letterParser = new RomanLetterParser(roman);

            var romanDigits = romanDigitsCommaSeprated.Split(',');

            int index = 0;
            Assert.Throws<ArgumentException>(() =>
            {
                foreach (var letter in letterParser)
                {
                    Assert.AreEqual(romanDigits[index++], letter);
                }
            });
        }
    }
}