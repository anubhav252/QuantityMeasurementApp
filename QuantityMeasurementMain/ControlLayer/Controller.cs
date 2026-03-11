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
                System.Console.WriteLine("1.check Lengths Equality \n2.Convert to other unit \n3.Add two lengths \n0.Exit");
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
                }
            }
        }
        //handle input outputs for different task
        public static void HandleInputAndOutputForEquality()
        {
            System.Console.Write("Enter first  input:");
            double input1=double.Parse(Console.ReadLine());
            System.Console.Write("unit  for first input :");
            if (!Enum.TryParse(Console.ReadLine(), true, out Length.LengthUnit unit1))
            {
                Console.WriteLine("Invalid unit");
                return;
            }
            System.Console.Write("Enter second  Input:");
            double input2=double.Parse(Console.ReadLine());
            System.Console.Write("unit  for second input :");
            if (!Enum.TryParse(Console.ReadLine(), true, out Length.LengthUnit unit2))
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
            if (!Enum.TryParse(Console.ReadLine(),true,out Length.LengthUnit valueUnit))
            {
                System.Console.WriteLine("invalid unit");
                return;
            }
            System.Console.WriteLine("Enter target unit");
            if(!Enum.TryParse(Console.ReadLine(),true,out Length.LengthUnit targetUnit))
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
            if (!Enum.TryParse(Console.ReadLine(), true, out Length.LengthUnit unit1))
            {
                Console.WriteLine("invalid unit");
                return;
            }

            Console.WriteLine("Enter second value");
            double value2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter unit for second value");
            if (!Enum.TryParse(Console.ReadLine(), true, out Length.LengthUnit unit2))
            {
                Console.WriteLine("invalid unit");
                return;
            }

            Length l1 = new Length(value1, unit1);
            Length l2 = new Length(value2, unit2);

            Length result = LengthEqualityUtility.AddLengths(l1, l2);

            Console.WriteLine($"Result: {result}");
        }
    } 
}