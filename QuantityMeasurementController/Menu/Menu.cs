using QuantityMeasurementControllers.Controller;
using QuantityMeasurementServices.Interfaces;
using QuantityMeasurementModel.DTOs;

namespace QuantityMeasurementControllers.Menu
{
    // Interactive console menu covering all UC1–UC14 operations.
    
    public class Menu
    {
        private readonly IQuantityMeasurementService _service;

        public Menu(IQuantityMeasurementService service)
        {
            _service = service;
        }

        public void Show()
        {
            while (true)
            {
                System.Console.WriteLine("\n===== Quantity Measurement App =====");
                System.Console.WriteLine("1. Compare Quantities");
                System.Console.WriteLine("2. Add Quantities");
                System.Console.WriteLine("3. Subtract Quantities");
                System.Console.WriteLine("4. Divide Quantities");
                System.Console.WriteLine("5. Convert Quantity");
                System.Console.WriteLine("6. Show History");
                System.Console.WriteLine("7. Delete History");
                System.Console.WriteLine("0. Exit");
                System.Console.Write("Choice: ");

                string? choice = System.Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1": CompareFlow();   break;
                        case "2": AddFlow();       break;
                        case "3": SubtractFlow();  break;
                        case "4": DivideFlow();    break;
                        case "5": ConvertFlow();   break;
                        case "6": ShowHistory();   break;
                        case "7": DeleteAllRecords(); break;
                        case "0":
                            System.Console.WriteLine("thanks!");
                            return;
                        default:
                            System.Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine($"[Error] {ex.Message}");
                }
            }
        }

        private void CompareFlow()
        {
            var first  = ReadQuantity("First");
            var second = ReadQuantity("Second");
            bool equal = _service.Compare(first, second);
            System.Console.WriteLine($"Result: {(equal ? "Equal " : "Not Equal ")}");
        }

        private void ConvertFlow()
        {
            var source = ReadQuantity("Source");

            System.Console.Write("Target Unit: ");
            string targetUnit = System.Console.ReadLine() ?? "";

            var result = _service.Convert(source, targetUnit);

            System.Console.WriteLine($"Converted: {result.BaseValue:G6} {result.Unit}");
        }


        private void AddFlow()
        {
            var first  = ReadQuantity("First");
            var second = ReadQuantity("Second");
            string targetUnit = ReadTargetUnitOptional();
            var result = _service.Add(first, second, targetUnit);
            System.Console.WriteLine($"Sum: {result.BaseValue:G6} {result.Unit}");
        }

        private void SubtractFlow()
        {
            var first  = ReadQuantity("First");
            var second = ReadQuantity("Second");
            string targetUnit = ReadTargetUnitOptional();
            var result = _service.Subtract(first, second, targetUnit);
            System.Console.WriteLine($"Difference: {result.BaseValue:G6} {result.Unit}");
        }

        private void DivideFlow()
        {
            var first  = ReadQuantity("First (dividend)");
            var second = ReadQuantity("Second (divisor)");
            double ratio = _service.Divide(first, second);
            System.Console.WriteLine($"Ratio: {ratio:G6}");
        }

        private void ShowHistory()
        {
            var (quantities, operations) = _service.GetFullHistory();

            Console.WriteLine("\n===== Quantity History =====");

            if (quantities.Count == 0)
            {
                Console.WriteLine("No quantity records found.");
            }
            else
            {
                Console.WriteLine($"\n{"ID",-4} {"Value",-12} {"Unit",-14} {"Category"}");
                Console.WriteLine(new string('-', 50));

                foreach (var item in quantities)
                {
                    Console.WriteLine($"{item.Id,-4} {item.Value,-12:G6} {item.Unit,-14} {item.Category}");
                }
            }

            Console.WriteLine("\n===== Operation History =====");

            if (operations.Count == 0)
            {
                Console.WriteLine("No operation history found.");
                return;
            }

            Console.WriteLine($"\n{"ID",-4} {"FirstQuantityId",-18} {"SecondQuantityId",-18} {"Operation",-12} {"Result",-12} {"Unit",-10} {"Time"}");
            Console.WriteLine(new string('-', 90));

            foreach (var op in operations)
            {
                Console.WriteLine($"{op.Id,-4} {op.FirstQuantityId,-18} {op.SecondQuantityId,-18} {op.OperationType,-12} {op.ResultValue,-12:G6} {op.ResultUnit,-10} {op.CreatedAt}");
            }
        }

        private void DeleteAllRecords()
        {
            Console.Write("Are you sure you want to delete ALL records? (yes/no): ");
            string input = Console.ReadLine() ?? "";

            if (input.Equals("yes", StringComparison.OrdinalIgnoreCase))
            {
                _service.DeleteAllRecords();
                Console.WriteLine("All records deleted successfully.");
            }
            else
            {
                Console.WriteLine("Operation cancelled.");
            }
        }

        private QuantityDTO ReadQuantity(string label)
        {
            System.Console.WriteLine($"\n-- {label} Quantity --");
            System.Console.Write("Category (Length / Weight / Volume / Temperature): ");
            string category = System.Console.ReadLine() ?? "";

            System.Console.Write("Unit: ");
            string unit = System.Console.ReadLine() ?? "";

            System.Console.Write("Value: ");
            double value = Convert.ToDouble(System.Console.ReadLine());

            return new QuantityDTO { Category = category, Unit = unit, Value = value };
        }
        private string? ReadTargetUnitOptional()
        {
            System.Console.Write("Enter target unit (or press Enter to skip): ");
            string? input = System.Console.ReadLine();

            return string.IsNullOrWhiteSpace(input) ? null : input;
        }
    }
}
