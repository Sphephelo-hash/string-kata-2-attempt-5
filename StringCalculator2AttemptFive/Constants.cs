using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCalculator2AttemptFive.Services
{
    public class Constants
    {
        public const char NewLine = '\n';
        public const char Comma = ',';
        public static List<string> StandardDelimiters = new List<string> { Comma.ToString(), NewLine.ToString() };
        public const string CustomDelimiterFlag = "##";
        public const char OpeningDelimiterFlag = '[';
        public const char ClosingDelimiterFlag = ']';
        public const string OpeningSeparatorFlag = "<";
        public const int UpperBound = 1000;
        public const char HashTag = '#';
    }
}
