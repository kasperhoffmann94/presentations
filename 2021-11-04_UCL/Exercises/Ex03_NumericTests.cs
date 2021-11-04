using FluentAssertions;
using System;
using Xunit;

namespace Exercises
{
    public class Ex03_NumericTests
    {
        [Fact]
        public void The_answer_to_the_ultimate_question_of_life_the_universe_and_everything_according_to_Douglas_Adams_is_42()
        {
            // Arrange
            var expected = 42;

            // Act
            int result = TheAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything();

            // Assert
            result.Should().Be(42);
        }

        [Fact]
        public void A_prime_greater_than_2_is_odd()
        {
            // Act
            int result = GetPrimeGreaterThan2();

            // Assert
            result.Should().Match(r => r % 2 > 0);
        }

        [Fact]
        public void A_millionaire_donating_to_scouts_still_has_a_positive_balance()
        {
            // Arrange
            var account = new BankAccount
            {
                Balance = 1_000_000
            };

            // Act
            account.DonateToScouts();

            // Assert
            account.Balance.Should().BeGreaterThan(0);
        }

        [InlineData(2020)]
        [InlineData(2021)]
        [Theory]
        public void February_has_28_or_29_days(int year)
        {
            // Act
            int result = DateTime.DaysInMonth(year, 2);

            // Assert
            result.Should().Match(r => r == 28 || r == 29);
            result.Should().Match(r => r == 28 || r == 29);
        }

        [Fact]
        public void The_Primary_School_Pi_approximates_Math_PI_by_a_100th()
        {
            // Arrange
            double pi = Math.PI;

            // Act
            double primarySchoolPi = GetPrimarySchoolPi();

            // Assert
            primarySchoolPi.Should().BeApproximately(pi, 100);
        }

        #region Helpers
        private class BankAccount
        {
            public decimal Balance { get; set; }

            public void DonateToScouts() =>
                Balance -= new Random().Next(0, 100);
        }

        private static int TheAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything() => 42;

        private static int GetPrimeGreaterThan2() => 73;

        private static double GetPrimarySchoolPi() => 22 / 7d;
        #endregion
    }
}
