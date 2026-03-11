namespace QuantityMeasurementMain.ModelLayer
{
    public enum WeightUnit
    {
        KILOGRAM,
        GRAM,
        POUND
    }

    public static class WeightUnitExtensions
    {
        // convert value to base unit (KILOGRAM)
        public static double ConvertToBaseUnit(this WeightUnit unit, double value)
        {
            return unit switch
            {
                WeightUnit.KILOGRAM => value,
                WeightUnit.GRAM => value * 0.001,
                WeightUnit.POUND => value * 0.453592,
                _ => throw new ArgumentException("Invalid weight unit")
            };
        }

        // convert base unit to target unit
        public static double ConvertFromBaseUnit(this WeightUnit unit, double baseValue)
        {
            return unit switch
            {
                WeightUnit.KILOGRAM => baseValue,
                WeightUnit.GRAM => baseValue / 0.001,
                WeightUnit.POUND => baseValue / 0.453592,
                _ => throw new ArgumentException("Invalid weight unit")
            };
        }
    }
}