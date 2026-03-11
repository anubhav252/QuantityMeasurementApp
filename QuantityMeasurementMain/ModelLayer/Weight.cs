namespace QuantityMeasurementMain.ModelLayer
{
    public class Weight
    {
        public double Value { get; }
        public WeightUnit Unit { get; }

        private const double Tolerance = 0.0001;

        public Weight(double value, WeightUnit unit)
        {
            if (unit == null)
                throw new ArgumentException("Unit cannot be null");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid weight value");

            Value = value;
            Unit = unit;
        }

        private double ToBaseUnit()
        {
            return Unit.ConvertToBaseUnit(Value);
        }

        // conversion
        public Weight ConvertTo(WeightUnit targetUnit)
        {
            double baseValue = ToBaseUnit();
            double result = targetUnit.ConvertFromBaseUnit(baseValue);

            return new Weight(result, targetUnit);
        }

        // addition (UC6 equivalent)
        public Weight Add(Weight other)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double baseSum = this.ToBaseUnit() + other.ToBaseUnit();

            double result =
                this.Unit.ConvertFromBaseUnit(baseSum);

            return new Weight(result, this.Unit);
        }

        // addition with explicit unit (UC7 equivalent)
        public Weight Add(Weight other, WeightUnit targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double baseSum = this.ToBaseUnit() + other.ToBaseUnit();

            double result =
                targetUnit.ConvertFromBaseUnit(baseSum);

            return new Weight(result, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(Weight))
                return false;

            Weight other = (Weight)obj;

            return Math.Abs(
                this.ToBaseUnit() - other.ToBaseUnit()
            ) < Tolerance;
        }

        public override int GetHashCode()
        {
            return ToBaseUnit().GetHashCode();
        }

        public override string ToString()
        {
            return $"Quantity : {Value}, {Unit}";
        }
    }
}