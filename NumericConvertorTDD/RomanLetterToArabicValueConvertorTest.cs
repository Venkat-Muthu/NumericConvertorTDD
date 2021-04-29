using NUnit.Framework;

namespace NumericConvertorTDD
{
    [TestFixture]
    public class RomanLetterToArabicValueConvertorTest
    {
        [TestCase("I", 1)]
        [TestCase("II", 2)]
        [TestCase("III", 3)]
        [TestCase("IV", 4)]
        [TestCase("V", 5)]
        [TestCase("IX", 9)]
        public void ConvertValidLetters(string roman, int expected)
        {
            var romanLetterToArabicValueConvertor = new RomanLetterToArabicValueConvertor();

            var actual = romanLetterToArabicValueConvertor.GetValue(roman);

            Assert.AreEqual(actual, expected);
        }


        [TestCase("IIII", 0)]
        [TestCase("IIV", 0)]
        public void ConvertInValidLetters(string roman, int expected)
        {
            var romanLetterToArabicValueConvertor = new RomanLetterToArabicValueConvertor();

            var actual = romanLetterToArabicValueConvertor.GetValue(roman);

            Assert.AreEqual(actual, expected);
        }
    }
}