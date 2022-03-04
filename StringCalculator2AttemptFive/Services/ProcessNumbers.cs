using StringCalculator2AttemptFive.Services;
using System.Collections.Generic;

namespace StringCalculator2AttemptFive
{
    public class ProcessNumbers : IProcessNumbers
    {
        ICustomExceptions _exceptions;
        ISplit _split;
        public ProcessNumbers(ICustomExceptions exceptions, ISplit split)
        {
            _exceptions = exceptions;
            _split = split;
        }

        public List<int> ConvertAndCheckNumbersAboverange(string numbers)
        {
            int startingIndex = char.IsLetterOrDigit(numbers[0]) ? 0 : numbers.IndexOf(Constants.NewLine);
            string[] stringNumbers = _split.SplitNumbers(numbers, startingIndex);
            List<int> numbersList = ConvertStringNumbersToInt(stringNumbers);
            CheckForNumbersAboveRange(numbersList);

            return numbersList;
        }

        public List<int> ConvertStringNumbersToInt(string[] numbers)
        {
            List<int> intNumbers = new List<int>();
            foreach (string number in numbers)
            {
                if (char.IsLetter(number[0]))
                {
                    intNumbers.Add(ConvertCharToInt(number[0]));
                }
                else
                {
                    intNumbers.Add(int.Parse(number));
                }
            }

            return intNumbers;
        }

        public int ConvertCharToInt(char letter)
        {
            int result = letter - 'a';
            return (result < 10 && result > 0) ? result : 0;
        }

        public void CheckForNumbersAboveRange(List<int> numbers)
        {
            string numbersAboveRange = string.Empty;

            foreach (int number in numbers)
            {
                if (number > Constants.UpperBound)
                {
                    numbersAboveRange += number + ", ";
                }
            }

            if (!string.IsNullOrEmpty(numbersAboveRange))
            {
                _exceptions.NumbersAboveRangeException(numbersAboveRange.TrimEnd(Constants.Comma, ' '));

            }
        }
    }
}
