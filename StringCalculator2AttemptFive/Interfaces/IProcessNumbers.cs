using System.Collections.Generic;

namespace StringCalculator2AttemptFive
{
    public interface IProcessNumbers
    {
        void CheckForNumbersAboveRange(List<int> numbers);
        List<int> ConvertAndCheckNumbersAboverange(string numbers);
        int ConvertCharToInt(char letter);
        List<int> ConvertStringNumbersToInt(string[] numbers);
    }
}