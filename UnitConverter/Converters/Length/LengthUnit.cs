using UnitConverter.Common;

namespace UnitConverter.Converters.Length
{
    /// <summary>
    /// Length metric unit.
    /// </summary>
    public sealed class LengthUnit : MetricUnitBase<LengthUnit, LengthBaseUnitType>
    {
        public LengthUnit(MetricPrefix metricPrefix, LengthBaseUnitType baseUnitType)
            : base(metricPrefix, baseUnitType)
        {
        }
    }
}
