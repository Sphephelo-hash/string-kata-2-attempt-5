using NUnit.Framework;
using StringCalculator2AttemptFive.Services;

namespace StringCalculatortwoTests
{
    class DelimitersTests
    {
        Delimiters _delimiters;

        [SetUp]
        public void SetUp()
        {
            _delimiters = new Delimiters();
        }

        [Test]
        public void GivenStringNumbers_WhenFindingDelimiters_ReturnDelimiters()
        {
            // Arrange
            string input = "1,2,3";
            string[] expected = { "\n", "," };

            // Act
            string[] result = _delimiters.GetDelimiters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithNewLine_WheFindingDelimiters_ReturnDelimiters()
        {
            // Arrange
            string input = "1\n2,3";
            string[] expected = { "\n", "," };

            // Act
            string[] result = _delimiters.GetDelimiters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithCustomDelimiter_WhenFindingDelimiters_ReturnDelimiters()
        {
            // Arrange
            string input = "##;\n1;2;3";
            string[] expected = { ";" };

            // Act
            string[] result = _delimiters.GetDelimiters(input);


            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithEnclosedCustomDelimiter_WhenFindingDelimiters_ReturnDelimiters()
        {
            // Arrange
            string input = "##[*]\n1*2*3";
            string[] expected = { "*" };

            // Act
            string[] result = _delimiters.GetDelimiters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithMultipleEnclosedCustomDelimiter_WhenFindingDelimiters_ReturnDelimiters()
        {
            // Arrange
            string input = "##[$$][&&]\n1$$2&&3";
            string[] expected = { "$$", "&&" };

            // Act
            string[] result = _delimiters.GetDelimiters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithDelimiterSeparators_WhenFindingDelimiters_ReturnDelimiters()
        {
            // Arrange
            string input = "<(>}##(::}\n1::8::3";
            string[] expected = { "::" };

            // Act
            string[] result = _delimiters.GetDelimiters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GivenStringNumbersWithDelimiterSeparatorsAndMultipleDelimiters_WhenFindingDelimiters_ReturnDelimiters()
        {
            // Arrange
            string input = "<<>>##<$$$><###>\n5$$$6$$9";
            string[] expected = { "$$$", "###" };

            // Act
            string[] result = _delimiters.GetDelimiters(input);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
