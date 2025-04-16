using UnitConverter.Converters;
using Xunit;
using FluentAssertions;
using System;
using UnitConverter.Converters.DigitalStorage;

namespace UnitConverter.UnitTests
{
    /// <summary>
    /// Test class for <see cref="UnitConverterFacade"/>.
    /// </summary>
    public class UnitConverterFacadeTest
    {
        private readonly UnitConverterFacade _unitConverterFacade = new UnitConverterFacade();

        [Fact]
        public void ConvertShouldThrowArgumentExceptionWhenUnitIsNotRecognizable()
        {
            Action act = () => _unitConverterFacade.Convert("invalid", "meter", 10);
            act.Should().Throw<ArgumentException>()
                .WithMessage("'invalid' couldn't be parsed to any recognizable metric unit type.");
        }

        [Fact]
        public void ConvertShouldThrowArgumentExceptionWhenUnitsMetricsDoNotMatch()
        {
            Action act = () => _unitConverterFacade.Convert("byte", "meter", 10);
            act.Should().Throw<ArgumentException>()
                .WithMessage($"'meter' unit couldn't be parsed to {nameof(DigitalStorageUnit)} metric system.");
        }

        [Theory]
        [InlineData("byte", "bit", 10, 80)]
        [InlineData("byte", "byte", 1, 1)]
        [InlineData("byte", "kibibit", 1, 0.00781)]
        [InlineData("byte", "megabit", 100, 0.0008)]
        [InlineData("byte", "kilobit", 120, 0.96)]
        [InlineData("bit", "byte", 1, 0.125)]
        [InlineData("terabit", "gigabyte", 100, 12500)]
        [InlineData("petabyte", "Terabit", 2, 16000)]
        public void DigitalStorageUnitConverterTest(string unitFrom, string unitTo, double value, double expectedResult)
        {
            var result = _unitConverterFacade.Convert(unitFrom, unitTo, value);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("meter", "meter", 10, 10)]
        [InlineData("meter", "kilometer", 25, 0.025)]
        [InlineData("centimeter", "inch", 10, 3.937)]
        [InlineData("kilometer", "mile", 50, 31.0752)]
        [InlineData("yard", "foot", 12, 36)]
        [InlineData("nanometer", "micrometers", 1, 0.001)]
        [InlineData("decameter", "millimeter", 0.5, 5000)]
        [InlineData("mile", "yard", 1, 1760)]
        [InlineData("yard", "mile", 1, 0.00057)]
        [InlineData("inch", "yard", 100, 2.77778)]
        public void LenthUnitConverterTest(string unitFrom, string unitTo, double value, double expectedResult)
        {
            var result = _unitConverterFacade.Convert(unitFrom, unitTo, value);
            result.Should().Be(expectedResult);
        }

        [Theory]
        [InlineData("Celsius", "Fahrenheits", 20, 68)]
        [InlineData("celsius", "kelvin", 100, 373.15)]
        [InlineData("fahrenheit", "kelvin", 2, 256.48333)]
        [InlineData("kelvin", "fahrenheit", 88, -301.27)]
        [InlineData("celsius", "celsius", 0, 0)]
        public void TemperatureConverterTest(string unitFrom, string unitTo, double value, double expectedResult)
        {
            var result = _unitConverterFacade.Convert(unitFrom, unitTo, value);
            result.Should().Be(expectedResult);
        }
    }
}
