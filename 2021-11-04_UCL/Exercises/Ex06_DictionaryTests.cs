using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Exercises
{
    public class Ex06_DictionaryTests
    {
        [Fact]
        public void Translating_1337_to_leet_speak_is_leet()
        {
            // Arrange
            var expectedKey = 1337;
            var expectedValue = "leet";

            // Act
            Dictionary<int, string> leetSpeak = GetLeetSpeak();

            // Assert
            leetSpeak.Should().ContainKey(expectedKey).WhoseValue.Equals(expectedValue);
        }

        #region Helpers
        private static Dictionary<int, string> GetLeetSpeak() => new()
        {
            [1337] = "leet"
        };
        #endregion
    }
}
