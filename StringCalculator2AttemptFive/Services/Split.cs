using System;

namespace StringCalculator2AttemptFive.Services
{
    public class Split : ISplit
    {
        IDelimiters _delimiters;
        public Split(IDelimiters delimiters)
        {
            _delimiters = delimiters;
        }

        public string[] SplitNumbers(string numbers, int startingIndex)
        {
            string[] delimitersList = _delimiters.GetDelimiters(numbers);
            if (startingIndex != 0)
            {
                string trimmedNumbers = numbers.Substring(startingIndex + 1);

                return trimmedNumbers.Split(delimitersList, StringSplitOptions.None);
            }

            return numbers.Split(delimitersList, StringSplitOptions.None); ;
        }
    }
}
