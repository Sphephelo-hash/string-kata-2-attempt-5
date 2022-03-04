using System;

namespace StringCalculator2AttemptFive.Services
{
    public class Delimiters : IDelimiters
    {

        public string[] GetDelimiters(string numbers)
        {
            if (numbers.StartsWith(Constants.OpeningSeparatorFlag))
            {
                return GetFlaggedDelimiters(numbers);
            }

            if (numbers.StartsWith(Constants.CustomDelimiterFlag))
            {
                return GetCustomDelimiters(numbers);
            }

            return new string[] { (Constants.NewLine.ToString()), (Constants.Comma.ToString()) };
        }

        public string[] GetFlaggedDelimiters(string numbers)
        {
            string delimitersAndSeparators = numbers.Substring(numbers.IndexOf(Constants.HashTag) + 2, numbers.IndexOf(Constants.NewLine) - 6);
            char[] separators = FindSeparators(numbers);

            return FindDelimiters(delimitersAndSeparators, separators);
        }

        public string[] GetCustomDelimiters(string numbers)
        {
            string customDelimiters = numbers.Substring(2, numbers.IndexOf(Constants.NewLine) - 2);
            if (numbers.StartsWith(Constants.CustomDelimiterFlag + Constants.OpeningDelimiterFlag))
            {
                return FindDelimiters(customDelimiters, new char[] { Constants.OpeningDelimiterFlag, Constants.ClosingDelimiterFlag });
            }

            return new string[] { customDelimiters };
        }

        public char[] FindSeparators(string numbers)
        {
            string[] splittedNumbers = numbers.Split(Constants.HashTag);
            string separatorsAndFlags = splittedNumbers[0];

            return new char[] { separatorsAndFlags[1], separatorsAndFlags[3] };
        }

        public string[] FindDelimiters(string delimitersAndSeparators, char[] separators)
        {
            delimitersAndSeparators = delimitersAndSeparators.Trim(separators);

            return delimitersAndSeparators.Split(new string[] { separators[1].ToString() + separators[0].ToString() }, StringSplitOptions.None);
        }
    }
}


