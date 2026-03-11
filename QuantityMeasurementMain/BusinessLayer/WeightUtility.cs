using QuantityMeasurementMain.ModelLayer;

namespace QuantityMeasurementMain.BusinessLayer
{
    public class WeightUtility
    {
        // equality check
        public static bool CheckWeightEquality(double value1, WeightUnit unit1,double value2, WeightUnit unit2)
        {
            Weight w1 = new Weight(value1, unit1);
            Weight w2 = new Weight(value2, unit2);

            return w1.Equals(w2);
        }

        // conversion
        public static Weight ConvertToOtherUnit(Weight weight,WeightUnit targetUnit)
        {
            return weight.ConvertTo(targetUnit);
        }

        // addition (implicit target unit)
        public static Weight AddWeights(Weight w1, Weight w2)
        {
            return w1.Add(w2);
        }

        // addition with explicit target unit
        public static Weight AddWeights(Weight w1,Weight w2,WeightUnit targetUnit)
        {
            return w1.Add(w2, targetUnit);
        }
    }
}