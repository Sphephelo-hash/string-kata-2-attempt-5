using NSubstitute;
using NUnit.Framework;
using StringCalculator2AttemptFive;
using StringCalculator2AttemptFive.Services;
using System;
using System.Collections.Generic;

namespace StringCalculatortwoTests
{
    public class ProcessNumbersTests
    {
        IProcessNumbers _processNumbers;
        ISplit _split;
        ICustomExceptions _exceptions;

        [SetUp]
        public void SetUp()
        {
            _exceptions = Substitute.For<ICustomExceptions>();
            _split = Substitute.For<ISplit>();
            _processNumbers = new ProcessNumbers(_exceptions, _split);
        }

        [Test]
        public void GivenStringNumbers_WhenConverting_ReturnsIntegerNumbers()
        {
            //Arrange 
            string[] input = { "1", "2", "3" };
            List<int> expected = new List<int>() { 1, 2, 3 };

            //Act
            List<int> result = _processNumbers.ConvertStringNumbersToInt(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersAndLetters_WhenConverting_ReturnsIntegerNumbers()
        {
            //Arrange 
            string[] input = { "1", "c", "m" };
            List<int> expected = new List<int>() { 1, 2, 0 };

            //Act
            List<int> result = _processNumbers.ConvertStringNumbersToInt(input);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersAbove10000_WhenConverting_ThrowsException()
        {
            // Arrange 
            List<int> stringNumbers = new List<int> { 1, 2, 10001 };
            _exceptions.When(x => x.NumbersAboveRangeException(Arg.Any<string>()))
                .Do(x => throw new Exception("Numbers are above range "));
            string expected = "Numbers are above range ";

            // Act
            var results = Assert.Throws<System.Exception>(() => _processNumbers.CheckForNumbersAboveRange(stringNumbers));

            //assert
            Assert.AreEqual(expected, results.Message);
        }
    }
}