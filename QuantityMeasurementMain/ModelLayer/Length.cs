namespace QuantityMeasurementMain.ModelLayer
{
    //generic class for single responsibility prociple
    public class Length
    {
        public double Value{get;}
        public LengthUnit Unit{get;}
        
        public Length(double value,LengthUnit unit)
        {
            Value=value;
            Unit=unit;
        }
         private double ToBaseUnit()
        {
            return Unit.ConvertToBaseUnit(Value);
        }

        
        private const double Tolerence=0.0001;//acceptable floating point difference
        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if(obj is not Length second)
            {
                return false;
            }
            return Math.Abs(this.ToBaseUnit()-second.ToBaseUnit())<Tolerence;
        }
        public override int GetHashCode()
        {
            return ToBaseUnit().GetHashCode();
        }

        public override string ToString()
        {
            return ($"Quantity : {Value} {Unit}");
        }

        // UC5 unit conversion
        public Length ConvertTo(LengthUnit targetUnit)
        {
            double baseValue = ToBaseUnit();
            double converted = targetUnit.ConvertFromBaseUnit(baseValue);
            return new Length(converted, targetUnit);
        }
        
        // ----------- UC6 method for ADDITION  ----------------
        public Length Add(Length other)
        {
            if (other == null)
                throw new Exception("Second operand cannot be null");

            double baseSum =this.ToBaseUnit() +other.ToBaseUnit();

            double result =this.Unit.ConvertFromBaseUnit(baseSum);

            return new Length(result, this.Unit);
        }

         // ---------- UC7 method for addition with target unit ----------
        public Length Add(Length other, LengthUnit targetUnit)
        {
            if (other == null)
                throw new Exception("Second operand cannot be null");

            double baseSum =this.ToBaseUnit() +other.ToBaseUnit();

            double result =targetUnit.ConvertFromBaseUnit(baseSum);

            return new Length(result, targetUnit);
        }
    } 
}