using System;
using Xunit;

namespace HiLowGame.Tests
{
    public class Program
    {
        public static int ValidateInput(string input)
        {
            if (int.TryParse(input, out int result))
            {
                return result;
            }

            return 0;
        }

        public static string CheckGuess(int mysteryNumber, int guess)
        {
            if (guess < mysteryNumber)
            {
                return "Too low! Try again:";
            }
            else if (guess > mysteryNumber)
            {
                return "Too high! Try again:";
            }
            else
            {
                return "Correct!";
            }
        }

        public static bool AskToPlayAgain(string input)
        {
            return input.ToLower() == "y";
        }
    }
    public class ProgramTests
    {
        [Fact]
        public void TestInvalidInput()
        {
            // Arrange
            string input = "abc";
            int expected = 0;

            // Act
            int result = Program.ValidateInput(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestValidInput()
        {
            // Arrange
            string input = "50";
            int expected = 50;

            // Act
            int result = Program.ValidateInput(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGuessTooLow()
        {
            // Arrange
            int mysteryNumber = 50;
            int guess = 25;
            string expected = "Too low! Try again:";

            // Act
            string result = Program.CheckGuess(mysteryNumber, guess);

            // Assert
            Assert.Equal(expected, result);
        }

               [Fact]
        public void TestGuessTooHigh()
        {
            // Arrange
            int mysteryNumber = 50;
            int guess = 75;
            string expected = "Too high! Try again:";

            // Act
            string result = Program.CheckGuess(mysteryNumber, guess);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestGuessCorrect()
        {
            // Arrange
            int mysteryNumber = 50;
            int guess = 50;
            string expected = "Correct!";

            // Act
            string result = Program.CheckGuess(mysteryNumber, guess);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestPlayAgainYes()
        {
            // Arrange
            string input = "y";
            bool expected = true;

            // Act
            bool result = Program.AskToPlayAgain(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestPlayAgainNo()
        {
            // Arrange
            string input = "n";
            bool expected = false;

            // Act
            bool result = Program.AskToPlayAgain(input);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestPlayAgainInvalidInput()
        {
            // Arrange
            string input = "abc";
            bool expected = false;

            // Act
            bool result = Program.AskToPlayAgain(input);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}

