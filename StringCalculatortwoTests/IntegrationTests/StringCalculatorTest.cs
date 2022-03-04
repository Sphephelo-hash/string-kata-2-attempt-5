using NUnit.Framework;
using StringCalculator2AttemptFive;
using StringCalculator2AttemptFive.Services;
using System;

namespace StringCalculatortwoTests.IntegrationTests
{
    class StringCalculatorTest
    {
        StringCalculator _stringCalculator;

        [SetUp]
        public void SetUp()
        {

            _stringCalculator = new StringCalculator(new ProcessNumbers(new CustomExceptions(), new Split(new Delimiters())), new SubtractOperation());
        }

        [Test]
        public void GivenStringNumbers_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "1,2,3";
            int expected = -6;

            //Act            
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithNewLines_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "1,2\n3";
            int expected = -6;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithCustomdelimiter_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "##;\n1;2;3";
            int expected = -6;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithDelimiterOfDifferentLength_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "##[***]\n1***2***3";
            int expected = -6;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithMultipleCustomDelimiters_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "##[;][$$$]\n1;2$$$3";
            int expected = -6;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithDelimiterSeparators_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "<(>)##(*)\n1*2*3";
            int expected = -6;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithDelimiterSeparators2_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "<>><##>&<\n1&4&5&6";
            int expected = -16;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithDelimiterSeparatorsAndMultipleDelimiters_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "<<>>##<$$$><###>\n5$$$6###7";
            int expected = -18;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringCharacters_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "a,b,c,d";
            int expected = -6;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringCharacters2_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "a,b,c,p";
            int expected = -3;

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringWithOneNumberAbove1000_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "1001,2,5,9";
            string expected = "Numbers are above range 1001";

            //Act
            var result = Assert.Throws<Exception>(() => _stringCalculator.Subtract(input));

            //Assert
            Assert.AreEqual(expected, result.Message);
        }

        [Test]
        public void GivenStringWithNumbersAbove1000_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "1001,2,5,9000";
            string expected = "Numbers are above range 1001, 9000";

            //Act
            var result = Assert.Throws<Exception>(() => _stringCalculator.Subtract(input));

            //Assert
            Assert.AreEqual(expected, result.Message);
        }
    }
}
