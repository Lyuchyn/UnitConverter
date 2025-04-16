using System;
using UnitConverter.Common;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Base class for all application unit converters.
    /// </summary>
    /// <typeparam name="TUnit">Type of the metric unit.</typeparam>
    public abstract class UnitConverterBase<TUnit, TBaseUnitType> : IUnitConverter<TUnit>
        where TUnit : IMetricUnit<TBaseUnitType>
    {
        /// <inheritdoc />
        public double Convert(IMetricUnit fromUnit, IMetricUnit toUnit, double value)
        {
            return Convert((TUnit)fromUnit, (TUnit)toUnit, value);
        }

        /// <inheritdoc />
        public double Convert(TUnit fromUnit, TUnit toUnit, double value)
        {
            var prefixFactor = GetPrefixFactor(fromUnit, toUnit);
            var convertedValue = fromUnit.BaseUnitType.Equals(toUnit.BaseUnitType) 
                ? value 
                : ConvertImpl(fromUnit, toUnit, value);

            return Math.Round(prefixFactor * convertedValue, 5);
        }

        /// <summary>
        /// Implementation of a concrete unit conversion.
        /// </summary>
        /// <param name="fromUnit"></param>
        /// <param name="toUnit"></param>
        /// <param name="value"></param>
        protected abstract double ConvertImpl(TUnit fromUnit, TUnit toUnit, double value);

        private static double GetPrefixFactor(TUnit fromUnit, TUnit toUnit)
        {
            if (fromUnit.MetricPrefix == toUnit.MetricPrefix)
            {
                return 1;
            }

            var prefixFactorFrom = GetUnitPrefixFactor(fromUnit);
            var prefixFactorTo = GetUnitPrefixFactor(toUnit);

            return prefixFactorFrom / prefixFactorTo;
        }

        private static double GetUnitPrefixFactor(TUnit metricUnit)
        {
            return metricUnit.MetricPrefix switch
            {
                MetricPrefix.None => 1,
                MetricPrefix.Nano => Math.Pow(10, -9),
                MetricPrefix.Micro => Math.Pow(10, -6),
                MetricPrefix.Milli => Math.Pow(10, -3),
                MetricPrefix.Centi => Math.Pow(10, -2),
                MetricPrefix.Deci => Math.Pow(10, -1),
                MetricPrefix.Deca => Math.Pow(10, 1),
                MetricPrefix.Hecto => Math.Pow(10, 2),
                MetricPrefix.Kilo => Math.Pow(10, 3),
                MetricPrefix.Mega => Math.Pow(10, 6),
                MetricPrefix.Giga => Math.Pow(10, 9),
                MetricPrefix.Tera => Math.Pow(10, 12),
                MetricPrefix.Peta => Math.Pow(10, 15),
                _ => throw new NotImplementedException($"{metricUnit.MetricPrefix} is not supported.")
            };
        }
    }
}
