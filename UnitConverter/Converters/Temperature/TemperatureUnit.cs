using UnitConverter.Common;

namespace UnitConverter.Converters.Temperature
{
    /// <summary>
    /// Temperature metric unit.
    /// </summary>
    public sealed class TemperatureUnit : MetricUnitBase<TemperatureUnit, TemperatureUnitType>
    {
        public TemperatureUnit(TemperatureUnitType unitType)
            : this(MetricPrefix.None, unitType)
        {
        }

        private TemperatureUnit(MetricPrefix metricPrefix, TemperatureUnitType unitType)
            : base(MetricPrefix.None, unitType)
        {
        }
    }
}
