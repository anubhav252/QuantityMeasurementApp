using QuantityMeasurementMain.BusinessLayer;
using QuantityMeasurementMain.ModelLayer;

namespace QuantityMeasurementMain.ControlLayer
{
    public class Controller
    {
        public static void Menu()
        {
            Console.WriteLine("Welcome to Quantity Measurement App");

            while (true)
            {
                Console.WriteLine("1.Check Length Equality\n" +"2.Convert Length\n" +"3.Add Length\n" +"4.Add Length With Target Unit\n" +"5.Check Weight Equality\n" +"6.Convert Weight\n" +"7.Add Weight\n" +"8.Add Weight With Target Unit\n" +"0.Exit");

                Console.WriteLine("Enter your choice");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input");
                    continue;
                }

                switch (choice)
                {
                    case 0:
                        return;

                    case 1:
                        HandleLengthEquality();
                        break;

                    case 2:
                        HandleLengthConversion();
                        break;

                    case 3:
                        HandleLengthAddition();
                        break;

                    case 4:
                        HandleLengthAdditionWithTarget();
                        break;

                    case 5:
                        HandleWeightEquality();
                        break;

                    case 6:
                        HandleWeightConversion();
                        break;

                    case 7:
                        HandleWeightAddition();
                        break;

                    case 8:
                        HandleWeightAdditionWithTarget();
                        break;
                }
            }
        }

        // ---------- LENGTH OPERATIONS ----------

        public static void HandleLengthEquality()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            var q1 = new Quantity<LengthUnit>(v1, u1);
            var q2 = new Quantity<LengthUnit>(v2, u2);

            Console.WriteLine($"Equality Result: {QuantityUtility.CheckEquality(q1, q2)}");
        }

        public static void HandleLengthConversion()
        {
            Console.Write("Enter value: ");
            double value = double.Parse(Console.ReadLine());

            Console.Write("Enter unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit unit))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter target unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit target))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            var quantity = new Quantity<LengthUnit>(value, unit);

            var result = QuantityUtility.Convert(quantity, target);

            Console.WriteLine($"Result: {result}");
        }

        public static void HandleLengthAddition()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            var q1 = new Quantity<LengthUnit>(v1, u1);
            var q2 = new Quantity<LengthUnit>(v2, u2);

            var result = QuantityUtility.Add(q1, q2);

            Console.WriteLine($"Result: {result}");
        }

        public static void HandleLengthAdditionWithTarget()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter target unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit target))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            var q1 = new Quantity<LengthUnit>(v1, u1);
            var q2 = new Quantity<LengthUnit>(v2, u2);

            var result = QuantityUtility.Add(q1, q2, target);

            Console.WriteLine($"Result: {result}");
        }

        // ---------- WEIGHT OPERATIONS ----------

        public static void HandleWeightEquality()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            var q1 = new Quantity<WeightUnit>(v1, u1);
            var q2 = new Quantity<WeightUnit>(v2, u2);

            Console.WriteLine($"Equality Result: {QuantityUtility.CheckEquality(q1, q2)}");
        }

        public static void HandleWeightConversion()
        {
            Console.Write("Enter value: ");
            double value = double.Parse(Console.ReadLine());

            Console.Write("Enter unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit unit))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter target unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit target))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            var quantity = new Quantity<WeightUnit>(value, unit);

            var result = QuantityUtility.Convert(quantity, target);

            Console.WriteLine($"Result: {result}");
        }

        public static void HandleWeightAddition()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            var q1 = new Quantity<WeightUnit>(v1, u1);
            var q2 = new Quantity<WeightUnit>(v2, u2);

            var result = QuantityUtility.Add(q1, q2);

            Console.WriteLine($"Result: {result}");
        }

        public static void HandleWeightAdditionWithTarget()
        {
            Console.Write("Enter first value: ");
            double v1 = double.Parse(Console.ReadLine());

            Console.Write("Enter first unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter second value: ");
            double v2 = double.Parse(Console.ReadLine());

            Console.Write("Enter second unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.Write("Enter target unit: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit target))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            var q1 = new Quantity<WeightUnit>(v1, u1);
            var q2 = new Quantity<WeightUnit>(v2, u2);

            var result = QuantityUtility.Add(q1, q2, target);

            Console.WriteLine($"Result: {result}");
        }
    }
}