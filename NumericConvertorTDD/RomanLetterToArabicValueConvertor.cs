using System.Collections.Generic;

namespace NumericConvertorTDD
{
    public interface IRomanLetterToArabicValueConvertor
    {
        int GetValue(string romanLetter);
    }

    public class RomanLetterToArabicValueConvertor : IRomanLetterToArabicValueConvertor
    {
        private readonly Dictionary<char, int> _romanToIntMap = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000},
        };

        public int GetValue(string romanLetter)
        {
            if (string.IsNullOrWhiteSpace(romanLetter))
            {
                return 0;
            }
            var romanLetterLength = romanLetter.Length;
            if (romanLetterLength > 3)
            {
                return 0;
            }

            var prevDigit = int.MaxValue;
            var index = 0;
            var sum = 0;
            while (index < romanLetterLength)
            {
                int digitValue = 0;
                if (_romanToIntMap.ContainsKey(romanLetter[index]))
                {
                    digitValue = _romanToIntMap[romanLetter[index]];
                }

                if (prevDigit < digitValue)
                {
                    sum -= 2 * prevDigit;
                    if (romanLetterLength == 3) return 0;
                }
                prevDigit = digitValue;
                sum += digitValue;
                index++;
            }

            return sum;
        }
    }
}