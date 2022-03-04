using System;

namespace StringCalculator2AttemptFive.Services
{
    public class CustomExceptions : ICustomExceptions
    {
        public void NumbersAboveRangeException(string numbersAboveRange)
        {
            throw new Exception("Numbers are above range " + numbersAboveRange);
        }
    }
}
