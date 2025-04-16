using System;

namespace UnitConverter.Converters.Temperature
{
    /// <summary>
    /// Temperature converter.
    /// </summary>
    public class TemperatureUnitConverter : UnitConverterBase<TemperatureUnit, TemperatureUnitType>
    {
        /// <inheritdoc />
        protected override double ConvertImpl(TemperatureUnit fromUnit, TemperatureUnit toUnit, double value)
        {
            return (fromUnit.BaseUnitType, toUnit.BaseUnitType) switch
            {
                (TemperatureUnitType.Celsius, TemperatureUnitType.Fahrenheit) => value * 9/5 + 32,
                (TemperatureUnitType.Fahrenheit, TemperatureUnitType.Celsius) => (value - 32) * 5/9,
                (TemperatureUnitType.Fahrenheit, TemperatureUnitType.Kelvin) => (value - 32) * 5/9 + 273.15,
                (TemperatureUnitType.Kelvin, TemperatureUnitType.Fahrenheit) => (value - 273.15) * 9/5 + 32,
                (TemperatureUnitType.Celsius, TemperatureUnitType.Kelvin) => value + 273.15,
                (TemperatureUnitType.Kelvin, TemperatureUnitType.Celsius) => value - 273.15,
                _ => throw new NotImplementedException($"Cannot convert {fromUnit.BaseUnitType} to {toUnit.BaseUnitType}."),
            };
        }
    }
}
