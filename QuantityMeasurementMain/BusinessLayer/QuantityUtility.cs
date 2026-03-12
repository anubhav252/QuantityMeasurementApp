using QuantityMeasurementMain.ModelLayer;

namespace QuantityMeasurementMain.BusinessLayer
{
    public static class QuantityUtility
    {
        public static bool CheckEquality<U>(Quantity<U> q1, Quantity<U> q2)
            where U : Enum
        {
            return q1.Equals(q2);
        }

        public static Quantity<U> Convert<U>(Quantity<U> quantity, U targetUnit)
            where U : Enum
        {
            return quantity.ConvertTo(targetUnit);
        }

        public static Quantity<U> Add<U>(Quantity<U> q1, Quantity<U> q2)
            where U : Enum
        {
            return q1.Add(q2);
        }

        public static Quantity<U> Add<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit)
            where U : Enum
        {
            return q1.Add(q2, targetUnit);
        }
        //UC12- Subtraction and Division Operations
        public static Quantity<U> Subtract<U>(Quantity<U> q1, Quantity<U> q2)
            where U : Enum
        {
            return q1.Subtract(q2);
        }

        public static Quantity<U> Subtract<U>(Quantity<U> q1, Quantity<U> q2, U targetUnit)
            where U : Enum
        {
            return q1.Subtract(q2, targetUnit);
        }

        public static double Divide<U>(Quantity<U> q1, Quantity<U> q2)
            where U : Enum
        {
            return q1.Divide(q2);
        }
    }
}