using System;

namespace UnitConverter.Converters.Length
{
    /// <summary>
    /// Length metric unit converter.
    /// </summary>
    public class LengthUnitConverter : UnitConverterBase<LengthUnit, LengthBaseUnitType>
    {
        /// <inheritdoc />
        protected override double ConvertImpl(LengthUnit fromUnit, LengthUnit toUnit, double value)
        {
            return (fromUnit.BaseUnitType, toUnit.BaseUnitType) switch
            {
                (LengthBaseUnitType.Meter, LengthBaseUnitType.Foot) => value * 3.281,
                (LengthBaseUnitType.Foot, LengthBaseUnitType.Meter) => value / 3.281,
                (LengthBaseUnitType.Meter, LengthBaseUnitType.Inch) => value * 39.37,
                (LengthBaseUnitType.Inch, LengthBaseUnitType.Meter) => value / 39.37,
                (LengthBaseUnitType.Meter, LengthBaseUnitType.Mile) => value / 1609,
                (LengthBaseUnitType.Mile, LengthBaseUnitType.Meter) => value * 1609,
                (LengthBaseUnitType.Meter, LengthBaseUnitType.Yard) => value * 1.094,
                (LengthBaseUnitType.Yard, LengthBaseUnitType.Meter) => value / 1.094,
                (LengthBaseUnitType.Yard, LengthBaseUnitType.Mile) => value / 1760,
                (LengthBaseUnitType.Mile, LengthBaseUnitType.Yard) => value * 1760,
                (LengthBaseUnitType.Yard, LengthBaseUnitType.Foot) => value * 3,
                (LengthBaseUnitType.Foot, LengthBaseUnitType.Yard) => value / 3,
                (LengthBaseUnitType.Yard, LengthBaseUnitType.Inch) => value * 36,
                (LengthBaseUnitType.Inch, LengthBaseUnitType.Yard) => value / 36,
                _ => throw new NotImplementedException($"Cannot convert {fromUnit.BaseUnitType} to {toUnit.BaseUnitType}."),
            };
        }
    }
}
