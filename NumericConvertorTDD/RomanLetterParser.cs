using System;
using System.Collections;
using System.Collections.Generic;

namespace NumericConvertorTDD
{
    public class RomanLetterParser : IEnumerable<string>
    {
        private string _romanNumerals;

        //TODO : Use DI container.
        private readonly IRomanLetterToArabicValueConvertor _toArabicValueConvertor = new RomanLetterToArabicValueConvertor();

        public RomanLetterParser(string romanNumerals)
        {
            _romanNumerals = romanNumerals;
        }

        public IEnumerator<string> GetEnumerator()
        {
            int prevIndex = 0;
            int currentIndex = 0;
            int length = _romanNumerals.Length;
            int prevValue = int.MaxValue;

            if (length == 1)
            {
                yield return _romanNumerals[currentIndex].ToString();
            }

            while (currentIndex < length)
            {
                int currValue = _toArabicValueConvertor.GetValue(_romanNumerals[currentIndex].ToString());

                if (currentIndex == 0)
                {
                    prevValue = currValue;
                    prevIndex = currentIndex;
                    currentIndex++;

                    continue;
                }

                if (prevValue < currValue)
                {
                    if ((currValue - prevValue) > prevValue * 10)
                    {
                        throw new ArgumentException("Invalid format");
                    }
                    yield return _romanNumerals.Substring(prevIndex, 2);
                    currentIndex++;
                    if (currentIndex >= length) yield break;
                    currValue = _toArabicValueConvertor.GetValue(_romanNumerals[currentIndex].ToString());
                }
                else if (currentIndex - 2 == length)
                {
                    yield return _romanNumerals.Substring(prevIndex, 2);
                    yield return _romanNumerals.Substring(currentIndex, 1);
                }
                else
                {
                    yield return _romanNumerals.Substring(prevIndex, 1);
                }
                prevValue = currValue;
                prevIndex = currentIndex;
                currentIndex++;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}