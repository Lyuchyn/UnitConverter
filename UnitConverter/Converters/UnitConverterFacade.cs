using System;
using System.Linq;
using System.Reflection;
using UnitConverter.Common;
using UnitConverter.Converters.Length;

namespace UnitConverter.Converters
{
    /// <summary>
    /// Units converter facade.
    /// </summary>
    /// <remarks>
    /// Used as the entry point of the entire conversion application logic.
    /// </remarks>
    public class UnitConverterFacade
    {
        /// <summary>
        /// Converts <paramref name="value"/> from <paramref name="fromUnit"/> to <paramref name="toUnit"/>.
        /// </summary>
        /// <param name="fromUnit">Source unit in string representation (e.g. byte or kilometer).</param>
        /// <param name="toUnit">Destination unit in string representation (e.g. byte or kilometer).</param>
        /// <param name="value">Value to convert.</param>
        /// <returns></returns>
        public double Convert(string fromUnit, string toUnit, double value)
        {
            // get all the metric units registered in the
            var supportedUnits = Assembly.GetExecutingAssembly().GetTypes()
                .Where(p => typeof(IMetricUnit).IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .ToList();

            foreach (var unit in supportedUnits)
            {
                IMetricUnit metricUnitFrom = GetMetricUnit(fromUnit, unit);
                IMetricUnit metricUnitTo = GetMetricUnit(toUnit, unit);

                if (metricUnitFrom != null)
                {
                    if (metricUnitTo == null)
                    {
                        throw new ArgumentException($"'{toUnit}' unit couldn't be parsed to {metricUnitFrom.GetType().Name} metric system.");
                    }

                    var unitConverter = new UnitConverterFactory().GetConverter(metricUnitFrom);
                    return unitConverter.Convert(metricUnitFrom, metricUnitTo, value);
                }
            }

            throw new ArgumentException($"'{fromUnit}' couldn't be parsed to any recognizable metric unit type.");
        }

        private static IMetricUnit GetMetricUnit(string unit, Type unitType)
        {
            var result = unitType.GetMethod(nameof(LengthUnit.Parse),
                BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Invoke(null, new object[] { unit });

            return result as IMetricUnit;
        }
    }
}
