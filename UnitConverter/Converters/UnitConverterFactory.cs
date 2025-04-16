using System;
using UnitConverter.Common;
using UnitConverter.Converters.DigitalStorage;
using UnitConverter.Converters.Length;
using UnitConverter.Converters.Temperature;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Unit converter producer factory.
    /// </summary>
    public class UnitConverterFactory
    {
        /// <summary>
        /// Gets a concrete unit converter.
        /// </summary>
        /// <param name="metricUnit">Metric unit.</param>
        public IUnitConverter GetConverter(IMetricUnit metricUnit)
        {
            if (metricUnit is null)
            {
                throw new ArgumentNullException(nameof(metricUnit));
            }

            if (metricUnit is LengthUnit)
            {
                return new LengthUnitConverter();
            }

            if (metricUnit is TemperatureUnit)
            {
                return new TemperatureUnitConverter();
            }

            if (metricUnit is DigitalStorageUnit)
            {
                return new DigitalStorageUnitConverter();
            }

            throw new ArgumentOutOfRangeException($"No converter found for unit of type {metricUnit.GetType().Name}");
        }
    }
}
