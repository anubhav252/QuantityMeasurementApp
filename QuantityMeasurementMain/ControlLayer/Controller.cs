using QuantityMeasurementMain.BusinessLayer;
using QuantityMeasurementMain.ModelLayer;

namespace QuantityMeasurementMain.ControlLayer
{
    public class Controller
    {
        public static void Menu()
        {
            System.Console.WriteLine("Welcomme to Quantity Measurement App");
            while (true)
            {
                System.Console.WriteLine("1.check Lengths Equality \n2.Convert to other unit \n3.Add two lengths \n4.Add two lengths with target unit \n5.Check Weight Equality \n6.Convert Weight \n7.Add Weight \n8.Add Weight With Target Unit \n0.Exit");
                System.Console.WriteLine("Enter your choice");
                
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("invalid input");
                    continue;
                }
                switch (choice)
                {
                    case 0:
                        return;
                    case 1:
                        HandleInputAndOutputForEquality();
                        break;
                    case 2:
                        HandleInputAndOutputForConversion();
                        break;
                    case 3:
                        HandleInputAndOutputForAddition();
                        break;
                    case 4:
                        HandleAdditionWithTargetUnit();
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
                        HandleWeightAdditionWithTargetUnit();
                        break;
                }
            }
        }
        //handle input outputs for different task
        public static void HandleInputAndOutputForEquality()
        {
            System.Console.Write("Enter first  input:");
            double input1=double.Parse(Console.ReadLine());
            System.Console.Write("unit  for first input :");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit unit1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }
            System.Console.Write("Enter second  Input:");
            double input2=double.Parse(Console.ReadLine());
            System.Console.Write("unit  for second input :");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit unit2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }
            System.Console.WriteLine($"{input1} {unit1} and {input2} {unit2} are equal: {LengthEqualityUtility.CheckLengthEquality(input1,unit1,input2,unit2)}"); 
        }
        //input output handler for conversion of one unit to other
        public static void HandleInputAndOutputForConversion()
        {
            System.Console.WriteLine("Enter value");
            double value=double.Parse(Console.ReadLine());
            System.Console.WriteLine("Enter unit for value");
            if (!Enum.TryParse(Console.ReadLine(),true,out LengthUnit valueUnit))
            {
                System.Console.WriteLine("invalid unit");
                return;
            }
            System.Console.WriteLine("Enter target unit");
            if(!Enum.TryParse(Console.ReadLine(),true,out LengthUnit targetUnit))
            {
                System.Console.WriteLine("invalid unit");
                return;
            }
            Length length=new Length(value,valueUnit);
            Length result=LengthEqualityUtility.ConvertToOtherUnit(length,targetUnit);
            System.Console.WriteLine(result);
        }
        //input output handler for addition of two lengths
        public static void HandleInputAndOutputForAddition()
        {
            Console.WriteLine("Enter first value");
            double value1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter unit for first value");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit unit1))
            {
                Console.WriteLine("invalid unit");
                return;
            }

            Console.WriteLine("Enter second value");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter unit for second value");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit unit2))
            {
                Console.WriteLine("invalid unit");
                return;
            }

            Length l1 = new Length(value1, unit1);
            Length l2 = new Length(value2, unit2);

            Length result = LengthEqualityUtility.AddLengths(l1, l2);

            Console.WriteLine($"Result: {result}");
        }
        //input output handler for addition of two lengths with target unit
        public static void HandleAdditionWithTargetUnit()
        {
            Console.WriteLine("Enter first value");
            double v1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter unit for first value");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit u1))
            {
                Console.WriteLine("invalid unit");
                return;
            }

            Console.WriteLine("Enter second value");
            double v2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter unit for second value");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit u2))
            {
                Console.WriteLine("invalid unit");
                return;
            }

            Console.WriteLine("Enter target unit");
            if (!Enum.TryParse(Console.ReadLine(), true, out LengthUnit target))
            {
                Console.WriteLine("invalid unit");
                return;
            }

            Length l1 = new Length(v1, u1);
            Length l2 = new Length(v2, u2);

            Length result =
                LengthEqualityUtility.AddLengths(l1, l2, target);

            Console.WriteLine($"Result: {result}");
        }

        //for weightunit opertions
        public static void HandleWeightEquality()
        {
            Console.Write("Enter first weight value: ");
            double v1 = double.Parse(Console.ReadLine());
        
            Console.Write("Enter unit for first value: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }
        
            Console.Write("Enter second weight value: ");
            double v2 = double.Parse(Console.ReadLine());
        
            Console.Write("Enter unit for second value: ");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }
        
            bool result =WeightUtility.CheckWeightEquality(v1, u1, v2, u2);
        
            Console.WriteLine($"{v1} {u1} and {v2} {u2} are equal: {result}");
        }

        public static void HandleWeightConversion()
        {
            Console.WriteLine("Enter value:");
            double value = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter unit:");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit unit))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.WriteLine("Enter target unit:");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit target))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Weight weight = new Weight(value, unit);

            Weight result =WeightUtility.ConvertToOtherUnit(weight, target);

            Console.WriteLine(result);
        }

        public static void HandleWeightAddition()
        {
            Console.WriteLine("Enter first value:");
            double v1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit:");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.WriteLine("Enter second value:");
            double v2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second unit:");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Weight w1 = new Weight(v1, u1);
            Weight w2 = new Weight(v2, u2);

            Weight result =WeightUtility.AddWeights(w1, w2);

            Console.WriteLine($"Result: {result}");
        }
        public static void HandleWeightAdditionWithTargetUnit()
        {
            Console.WriteLine("Enter first value:");
            double v1 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter first unit:");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.WriteLine("Enter second value:");
            double v2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter second unit:");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit u2))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Console.WriteLine("Enter target unit:");
            if (!Enum.TryParse(Console.ReadLine(), true, out WeightUnit target))
            {
                Console.WriteLine("Invalid unit");
                return;
            }

            Weight w1 = new Weight(v1, u1);
            Weight w2 = new Weight(v2, u2);

            Weight result =WeightUtility.AddWeights(w1, w2, target);

            Console.WriteLine($"Result: {result}");
        }
    } 
}