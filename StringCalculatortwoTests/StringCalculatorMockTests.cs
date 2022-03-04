using NUnit.Framework;
using System;
using System.Collections.Generic;
using StringCalculator2AttemptFive;
using StringCalculator2AttemptFive.Services;
using NSubstitute;

namespace StringCalculatortwoTests
{
    class StringCalculatorMockTests
    {
        StringCalculator _stringCalculator;
        IProcessNumbers _processNumbers;
        ICalculator _calculator;

        [SetUp]
        public void SetUp()
        {
            _processNumbers = Substitute.For<IProcessNumbers>();
            _calculator = Substitute.For<ICalculator>();
            _stringCalculator = new StringCalculator(_processNumbers, _calculator);
        }

        [Test]
        public void GivenStringNumbers_WhenCalculating_ReturnDifference()
        {
            //Arrange
            string input = "1,2,3";
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 1, 4, 5, 6 };
            int expected = -16;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 5, 6, 7 };
            int expected = -18;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 0, 1, 2, 3 };
            int expected = -6;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

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
            List<int> intNumbers = new List<int>() { 0, 1, 2, 0 };
            int expected = -3;

            _processNumbers.ConvertAndCheckNumbersAboverange(input).Returns(intNumbers);
            _calculator.CalculateNumbers(intNumbers).Returns(expected);

            //Act
            int result = _stringCalculator.Subtract(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GiveStrinNumbersWithNegativeNumber_WhenCalculatinf_ThrowsAnError()
        {
            string input = "1000,2,3";
            string expected = "Numbers are above range 1000 ";
            List<int> numbers = new List<int> { 1000, 2, 3 };
            _processNumbers.When(x => x.ConvertAndCheckNumbersAboverange(input))
                .Do(x => throw new Exception("Numbers are above range 1000 "));
            var results = Assert.Throws<System.Exception>(() => _stringCalculator.Subtract(input));

            //assert
            Assert.AreEqual(expected, results.Message);
        }
    }
}

