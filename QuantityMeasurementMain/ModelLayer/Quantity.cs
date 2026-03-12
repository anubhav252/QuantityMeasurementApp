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
        //  ENUM FOR ARITHMETIC OPERATIONS 
        private enum ArithmeticOperation
        {
            ADD,
            SUBTRACT,
            DIVIDE
        }

        //  VALIDATION HELPER 
        private void ValidateOperands(Quantity<U> other, U targetUnit, bool targetRequired)
        {
            if (other == null)
                throw new ArgumentException("Second operand cannot be null");

            if (targetRequired && targetUnit == null)
                throw new ArgumentException("Target unit cannot be null");

            if (double.IsNaN(Value) || double.IsInfinity(Value) ||double.IsNaN(other.Value) || double.IsInfinity(other.Value))
                throw new ArgumentException("Invalid numeric value");
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
        private double ConvertFromBase(double baseValue, U targetUnit)
        {
            if (targetUnit is LengthUnit length)
                return length.ConvertFromBaseUnit(baseValue);

            if (targetUnit is WeightUnit weight)
                return weight.ConvertFromBaseUnit(baseValue);

            if (targetUnit is VolumeUnit volume)
                return volume.ConvertFromBaseUnit(baseValue);

            throw new ArgumentException("Unsupported unit type");
        }
         // CENTRALIZED ARITHMETIC HELPER 
        private double PerformBaseArithmetic(Quantity<U> other, ArithmeticOperation operation)
        {
            double base1 = this.ToBaseUnit();
            double base2 = other.ToBaseUnit();

            return operation switch
            {
                ArithmeticOperation.ADD => base1 + base2,
                ArithmeticOperation.SUBTRACT => base1 - base2,
                ArithmeticOperation.DIVIDE => base2 == 0 ? throw new ArithmeticException("Division by zero") : base1 / base2,
                _ => throw new ArgumentException("Invalid operation")
            };
        }

        public Quantity<U> ConvertTo(U targetUnit)
        {
            double baseValue = ToBaseUnit();
            double converted = ConvertFromBase(baseValue, targetUnit);

            return new Quantity<U>(Math.Round(converted, 2), targetUnit);
        }

        public Quantity<U> Add(Quantity<U> other)
        {
            return Add(other, Unit);
        }

        public Quantity<U> Add(Quantity<U> other, U targetUnit)
        {
            ValidateOperands(other, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.ADD);
            double result = ConvertFromBase(baseResult, targetUnit);

            return new Quantity<U>(Math.Round(result, 2), targetUnit);
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
            ValidateOperands(other, targetUnit, true);

            double baseResult = PerformBaseArithmetic(other, ArithmeticOperation.SUBTRACT);
            double result = ConvertFromBase(baseResult, targetUnit);

            return new Quantity<U>(Math.Round(result, 2), targetUnit);
        }

        public double Divide(Quantity<U> other)
        {
            ValidateOperands(other, default, false);

            return PerformBaseArithmetic(other, ArithmeticOperation.DIVIDE);
        }
    }
}