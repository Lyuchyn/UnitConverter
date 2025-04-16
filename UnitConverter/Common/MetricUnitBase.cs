using System;
using System.Linq;
using System.Reflection;

namespace UnitConverter.Common
{
    /// <summary>
    /// Base class for the application metric units.
    /// </summary>
    /// <typeparam name="TUnit">Type of the metric unit.</typeparam>
    /// <typeparam name="TBaseUnitType">Unit type (e.g. kilometer or Celsius).</typeparam>
    public abstract class MetricUnitBase<TUnit, TBaseUnitType> : IMetricUnit<TBaseUnitType>
        where TBaseUnitType : struct
        where TUnit : IMetricUnit
    {
        protected MetricUnitBase(MetricPrefix metricPrefix, TBaseUnitType baseUnitType)
        {
            MetricPrefix = metricPrefix;
            BaseUnitType = baseUnitType;
        }

        /// <inheritdoc />
        public MetricPrefix MetricPrefix { get; } = MetricPrefix.None;

        /// <inheritdoc />
        public TBaseUnitType BaseUnitType { get; }

        /// <summary>
        /// Parses the <paramref name="unit"/> from string to the object of type <see cref="IMetricUnit"/>.
        /// </summary>
        /// <param name="unit">Unit in string representation.</param>
        public static IMetricUnit Parse(string unit)
        {
            var unitType = ParseFromString<TBaseUnitType>(unit);
            if (unitType is null)
            {
                return null;
            }

            var metricPrefix = ParseFromString<MetricPrefix>(unit) ?? MetricPrefix.None;

            return (TUnit) Activator.CreateInstance(
                typeof(TUnit), BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic,
                null, new object[] { metricPrefix, unitType }, null);
        }

        private static TEnumType? ParseFromString<TEnumType>(string str)
            where TEnumType : struct
        {
            // get the most matching value
            var strEnumValue = Enum.GetNames(typeof(TEnumType))
                .OrderByDescending(x => x.Length)
                .FirstOrDefault(x => str.Contains(x, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrWhiteSpace(strEnumValue))
            {
                return (TEnumType) Enum.Parse(typeof(TEnumType), strEnumValue, true);
            }

            return default;
        }
    }
}
