namespace UnitConverter.Common
{
    /// <summary>
    /// Metric unit (e.g. length, temperature, digital storage etc).
    /// </summary>
    public interface IMetricUnit
    {
        /// <summary>
        /// Gets the metric prefix (e.g. kilo-, milli-, giga- etc).
        /// </summary>
        MetricPrefix MetricPrefix { get; }
    }

    /// <summary>
    /// Generic version of a metric unit.
    /// </summary>
    public interface IMetricUnit<TBaseUnitType> : IMetricUnit
    {
        TBaseUnitType BaseUnitType { get; }
    }
}
