namespace StringCalculator2AttemptFive.Services
{
    public interface IDelimiters
    {
        string[] FindDelimiters(string delimitersAndSeparators, char[] separators);
        char[] FindSeparators(string numbers);
        string[] GetCustomDelimiters(string numbers);
        string[] GetDelimiters(string numbers);
        string[] GetFlaggedDelimiters(string numbers);
    }
}