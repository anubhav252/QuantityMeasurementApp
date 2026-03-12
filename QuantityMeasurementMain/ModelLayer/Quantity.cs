namespace QuantityMeasurementMain.ModelLayer
{
    public class Quantity<U> where U : Enum
    {
        public double Value { get; }
        public U Unit { get; }

        private const double Tolerance = 0.0001;

        public Quantity(double value, U unit)
        {
            if (unit == null)
                throw new ArgumentException("Unit cannot be null");

            if (double.IsNaN(value) || double.IsInfinity(value))
                throw new ArgumentException("Invalid value");

            Value = value;
            Unit = unit;
        }

               private double ToBaseUnit()
        {
            if (Unit is LengthUnit length)
                return length.ConvertToBaseUnit(Value);

            if (Unit is WeightUnit weight)
                return weight.ConvertToBaseUnit(Value);

            throw new ArgumentException("Unsupported unit type");
        }

        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ToBaseUnit();
            double converted;

            if (targetUnit is LengthUnit length)
                converted = length.ConvertFromBaseUnit(baseValue);
            else if (targetUnit is WeightUnit weight)
                converted = weight.ConvertFromBaseUnit(baseValue);
            else
                throw new ArgumentException("Unsupported unit type");

            return new Quantity<U>(Math.Round(converted, 2), targetUnit);
        }

        public Quantity<U> Add(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double baseSum = this.ToBaseUnit() + other.ToBaseUnit();

            double result;

            if (Unit is LengthUnit length)
                result = length.ConvertFromBaseUnit(baseSum);
            else if (Unit is WeightUnit weight)
                result = weight.ConvertFromBaseUnit(baseSum);
            else
                throw new ArgumentException("Unsupported unit type");

            return new Quantity<U>(result, Unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            double baseSum = this.ToBaseUnit() + other.ToBaseUnit();

            double result;

            if (targetUnit is LengthUnit length)
                result = length.ConvertFromBaseUnit(baseSum);
            else if (targetUnit is WeightUnit weight)
                result = weight.ConvertFromBaseUnit(baseSum);
            else
                throw new ArgumentException("Unsupported unit type");

            return new Quantity<U>(result, targetUnit);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != typeof(Quantity<U>))
                return false;

            var other = (Quantity<U>)obj;

            return Math.Abs(this.ToBaseUnit() - other.ToBaseUnit()) < Tolerance;
        }

        public override int GetHashCode()
        {
            return ToBaseUnit().GetHashCode();
        }

        public override string ToString()
        {
            return $"Quantity({Value}, {Unit})";
        }
    }
}