namespace QuantityMeasurementMain.ModelLayer
{
    //Generic Quantity class to handle different types of measurements 
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
            if (Unit is VolumeUnit volume) // for Volume Measurement
                return volume.ConvertToBaseUnit(Value);
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
            else if (targetUnit is VolumeUnit volume)
                converted = volume.ConvertFromBaseUnit(baseValue);
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
            else if (Unit is VolumeUnit volume)
                result = volume.ConvertFromBaseUnit(baseSum);
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
            else if (targetUnit is VolumeUnit volume)
                result = volume.ConvertFromBaseUnit(baseSum);
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
        //methods for subtraction, division 
        public Quantity<U> Subtract(Quantity<U> other)
        {
            return Subtract(other, Unit);
        }
        
        public Quantity<U> Subtract(Quantity<U> other, U targetUnit)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");
        
            double baseDifference = this.ToBaseUnit() - other.ToBaseUnit();
            double result;
        
            if (targetUnit is LengthUnit length)
                result = length.ConvertFromBaseUnit(baseDifference);
        
            else if (targetUnit is WeightUnit weight)
                result = weight.ConvertFromBaseUnit(baseDifference);
        
            else if (targetUnit is VolumeUnit volume)
                result = volume.ConvertFromBaseUnit(baseDifference);
        
            else
                throw new ArgumentException("Unsupported unit type");
        
            return new Quantity<U>(Math.Round(result, 2), targetUnit);
        }
        
        public double Divide(Quantity<U> other)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");
        
            double baseOther = other.ToBaseUnit();
        
            if (baseOther == 0)
                throw new ArithmeticException("Division by zero");
        
            double result = this.ToBaseUnit() / baseOther;
        
            return result;
        }
    }
}