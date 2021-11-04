using FluentAssertions;
using FluentAssertions.Common;
using FluentAssertions.Extensions;
using System;
using Xunit;

namespace Exercises
{
    public class Ex02_DateTimeTests
    {
        [Fact]
        public void In_2021_Easter_Sunday_Falls_On_April_4th()
        {
            // Arrange
            var expected = 4.April(2021);

            // Act
            DateTime date = EasterSunday();

            // Assert
            date.Should().Be(expected);
        }

        [Fact]
        public void The_start_of_this_presentation_is_within_5_minutes_of_the_scheduled_time()
        {
            // Arrange
            var expectedStartOfLecture = 04.November(2021).At(09.Hours());

            // Act
            DateTime date = StartOfThisPresentation();

            // Assert
            date.Should().BeCloseTo(expectedStartOfLecture, TimeSpan.FromMinutes(5));
        }

        [Fact]
        public void A_random_day_from_julekalender_in_2021_is_between_1st_and_24th_of_december()
        {
            // Arrange
            var firstDayToOpen = 1.December(2021);
            var lastDayToOpen = 24.December(2021);

            // Act
            DateTime date = RandomDateFromJuleKalender();

            // Assert
            date.Should().BeAfter(firstDayToOpen).And.BeBefore(lastDayToOpen);
        }

        [Fact]
        public void In_2021_Danish_daylight_saving_time_ends_25th_of_October_at_0300_GMT_Plus2()
        {
            // Express expectedEndOfDst using the Fluent API from FluentAssertions.Extensions

            // Arrange
            DateTimeOffset expectedEndOfDst = 31.October(2021).At(03,00).WithOffset(2.Hours());

            // Act
            DateTimeOffset date = DaylightSavingTimeEnd();

            // Assert
            date.Should().Be(expectedEndOfDst);
        }

        #region Helpers
        private static DateTime EasterSunday() => new(2021, 04, 04);

        private static DateTime StartOfThisPresentation() => new DateTime(2021, 11, 04, 09, 00, 00).AddMinutes(new Random().Next(-5, 5));

        private static DateTime RandomDateFromJuleKalender() => new(2021, 12, new Random().Next(01, 24));

        private static DateTimeOffset DaylightSavingTimeEnd() => new(2021, 10, 31, 03, 00, 00, TimeSpan.FromHours(2));
        #endregion
    }
}
