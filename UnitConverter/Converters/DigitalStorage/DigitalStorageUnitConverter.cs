using System;

namespace UnitConverter.Converters.DigitalStorage
{
    /// <summary>
    /// Digital storage metric unit converter.
    /// </summary>
    public class DigitalStorageUnitConverter : UnitConverterBase<DigitalStorageUnit, DigitalStorageBaseUnitType>
    {
        /// <inheritdoc />
        protected override double ConvertImpl(DigitalStorageUnit fromUnit, DigitalStorageUnit toUnit, double value)
        {
            return (fromUnit.BaseUnitType, toUnit.BaseUnitType) switch
            {
                (DigitalStorageBaseUnitType.Byte, DigitalStorageBaseUnitType.Bit) => value * 8,
                (DigitalStorageBaseUnitType.Bit, DigitalStorageBaseUnitType.Byte) => value / 8,
                (DigitalStorageBaseUnitType.Byte, DigitalStorageBaseUnitType.Kibibit) => value / 128,
                (DigitalStorageBaseUnitType.Kibibit, DigitalStorageBaseUnitType.Byte) => value * 128,
                (DigitalStorageBaseUnitType.Bit, DigitalStorageBaseUnitType.Kibibit) => value / 1024,
                (DigitalStorageBaseUnitType.Kibibit, DigitalStorageBaseUnitType.Bit) => value * 1024,
                _ => throw new NotImplementedException($"Cannot convert {fromUnit.BaseUnitType} to {toUnit.BaseUnitType}."),
            };
        }
    }
}
