// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using QuantityMeasurementServices.Services;
// using QuantityMeasurementServices.Interfaces;
// using QuantityMeasurementRepository.Interfaces;
// using QuantityMeasurementRepository.Database;
// using QuantityMeasurementModel.DTOs;
// using QuantityMeasurementModel.Models;
// using QuantityMeasurementRepository.Configuration;

// namespace QuantityMeasurementTests
// {
//     [TestClass]
//     [TestCategory("DatabaseTesting")]
//     public class QuantityMeasurementServiceTests
//     {
//         private IQuantityMeasurementService _service;
//         private IQuantityMeasurementRepository _repository;

//         [TestInitialize]
//         public void Setup()
//         {
//             // Use DB repo (UC16)
//             _repository = new QuantityMeasurementDatabaseRepository();
//             _service = new QuantityMeasurementService(_repository);

//             // Clean DB before each test
//             _repository.DeleteAllRecords();
//         }

//         // Compare
//         [TestMethod]
//         public void Compare_ShouldReturnTrue_ForEqualQuantities()
//         {
//             var q1 = new QuantityDTO { Value = 1, Unit = "Feet", Category = "Length" };
//             var q2 = new QuantityDTO { Value = 12, Unit = "Inch", Category = "Length" };

//             bool result = _service.Compare(q1, q2);

//             Assert.IsTrue(result);
//         }

//         // Add
//         [TestMethod]
//         public void Add_ShouldReturnCorrectResult()
//         {
//             var q1 = new QuantityDTO { Value = 1, Unit = "Feet", Category = "Length" };
//             var q2 = new QuantityDTO { Value = 12, Unit = "Inch", Category = "Length" };

//             var result = _service.Add(q1, q2, "Feet");

//             Assert.AreEqual(2, result.BaseValue, 0.0001);
//         }

//         //  Subtract
//         [TestMethod]
//         public void Subtract_ShouldReturnCorrectResult()
//         {
//             var q1 = new QuantityDTO { Value = 2, Unit = "Feet", Category = "Length" };
//             var q2 = new QuantityDTO { Value = 12, Unit = "Inch", Category = "Length" };

//             var result = _service.Subtract(q1, q2, "Feet");

//             Assert.AreEqual(1, result.BaseValue, 0.0001);
//         }

//         //  Divide
//         [TestMethod]
//         public void Divide_ShouldReturnCorrectRatio()
//         {
//             var q1 = new QuantityDTO { Value = 10, Unit = "Feet", Category = "Length" };
//             var q2 = new QuantityDTO { Value = 5, Unit = "Feet", Category = "Length" };

//             double result = _service.Divide(q1, q2);

//             Assert.AreEqual(2, result, 0.0001);
//         }

//         //  Convert
//         [TestMethod]
//         public void Convert_ShouldConvertCorrectly()
//         {
//             var q = new QuantityDTO { Value = 1, Unit = "Feet", Category = "Length" };

//             var result = _service.Convert(q, "Inch");

//             Assert.AreEqual(12, result.BaseValue, 0.0001);
//         }
//         //  Operation History Saved
//         [TestMethod]
//         public void Add_ShouldSaveOperationHistory()
//         {
//             var q1 = new QuantityDTO { Value = 1, Unit = "Feet", Category = "Length" };
//             var q2 = new QuantityDTO { Value = 12, Unit = "Inch", Category = "Length" };

//             _service.Add(q1, q2, "Feet");

//             var operations = _service.GetOperationHistory();

//             Assert.IsTrue(operations.Count > 0);
//             Assert.AreEqual("Addition", operations[0].OperationType);
//         }

//         // Get Full History
//         [TestMethod]
//         public void GetFullHistory_ShouldReturnBothTables()
//         {
//             var q1 = new QuantityDTO { Value = 1, Unit = "Feet", Category = "Length" };
//             var q2 = new QuantityDTO { Value = 12, Unit = "Inch", Category = "Length" };

//             _service.Add(q1, q2, "Feet");

//             var (quantities, operations) = _service.GetFullHistory();

//             Assert.IsTrue(quantities.Count > 0);
//             Assert.IsTrue(operations.Count > 0);
//         }
//     }
// }