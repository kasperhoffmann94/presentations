using System;
using FluentAssertions;
using Xunit;

namespace Exercises
{
    public class Ex01_BooleanTests
    {
        [Fact]
        public void Adults_are_allowed_to_buy_alcohol()
        {
            // Arrange
            var person = new Person
            {
                Age = 18
            };

            // Act
            bool result = CanBuyAlcohol(person);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Children_are_not_allowed_to_buy_alcohol()
        {
            // Arrange
            var person = new Person
            {
                Age = 5
            };

            // Act
            bool result = CanBuyAlcohol(person);

            // Assert
            result.Should().BeFalse();
        }

        #region Helpers
        private static bool CanBuyAlcohol(Person person) => person.Age >= 18;

        private class Person
        {
            public int Age { get; set; }
        }
        #endregion
    }
}
