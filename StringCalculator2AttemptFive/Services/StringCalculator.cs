using System.Collections.Generic;

namespace StringCalculator2AttemptFive.Services
{
   public class StringCalculator
    {
        ICalculator _calculator;
        IProcessNumbers _processNumbers;

        public StringCalculator(IProcessNumbers processNumbers, ICalculator calculator)
        {
            _processNumbers = processNumbers;
            _calculator = calculator;
        }

        public int Subtract(string numbers)
        {
            numbers = numbers.Replace("-", "");
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            List<int> intNumbers = _processNumbers.ConvertAndCheckNumbersAboverange(numbers);
            return _calculator.CalculateNumbers(intNumbers);
        }
    }
}
