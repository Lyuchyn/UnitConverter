using UnitConverter.Common;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Units converter.
    /// </summary>
    /// <typeparam name="TUnit"></typeparam>
    public interface IUnitConverter<TUnit> : IUnitConverter
        where TUnit : IMetricUnit
    {
        double Convert(TUnit fromUnit, TUnit toUnit, double value);
    }

    public interface IUnitConverter
    {
        double Convert(IMetricUnit fromUnit, IMetricUnit toUnit, double value);
    }
}
