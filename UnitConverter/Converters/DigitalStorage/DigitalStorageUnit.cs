using UnitConverter.Common;

namespace UnitConverter.Converters.DigitalStorage
{
    /// <summary>
    /// Digital storage unit.
    /// </summary>
    public sealed class DigitalStorageUnit : MetricUnitBase<DigitalStorageUnit, DigitalStorageBaseUnitType>
    {
        public DigitalStorageUnit(MetricPrefix metricPrefix, DigitalStorageBaseUnitType baseUnitType)
            : base(metricPrefix, baseUnitType)
        {
        }
    }
}
