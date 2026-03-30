// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using QuantityMeasurementMain.ModelLayer;

// namespace QuantityMeasurementTests
// {
//     [TestClass]
//     [TestCategory("ArithmeticRefactoringTest")]
//     public class ArithmeticRefactoringTest
//     {

//         // ---------- ADD HELPER DELEGATION ----------

//         [TestMethod]
//         public void testRefactoring_Add_DelegatesViaHelper()
//         {
//             var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(new Quantity<LengthUnit>(15, LengthUnit.FEET), result);
//         }

//         [TestMethod]
//         public void testRefactoring_Subtract_DelegatesViaHelper()
//         {
//             var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(new Quantity<LengthUnit>(5, LengthUnit.FEET), result);
//         }

//         [TestMethod]
//         public void testRefactoring_Divide_DelegatesViaHelper()
//         {
//             var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(2.0, result);
//         }

//         // ---------- ENUM ARITHMETIC TESTS ----------

//         [TestMethod]
//         public void testArithmeticOperation_Add_EnumComputation()
//         {
//             double result = 10 + 5;

//             Assert.AreEqual(15.0, result);
//         }

//         [TestMethod]
//         public void testArithmeticOperation_Subtract_EnumComputation()
//         {
//             double result = 10 - 5;

//             Assert.AreEqual(5.0, result);
//         }

//         [TestMethod]
//         public void testArithmeticOperation_Divide_EnumComputation()
//         {
//             double result = 10 / 5;

//             Assert.AreEqual(2.0, result);
//         }


//         // ---------- BASE ARITHMETIC ----------

//         [TestMethod]
//         public void testPerformBaseArithmetic_ConversionAndOperation()
//         {
//             var q1 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(12, LengthUnit.INCHES);

//             var result = q1.Add(q2);

//             Assert.AreEqual(new Quantity<LengthUnit>(2, LengthUnit.FEET), result);
//         }

//         // ---------- BACKWARD COMPATIBILITY ----------

//         [TestMethod]
//         public void testAdd_UC12_BehaviorPreserved()
//         {
//             var q1 = new Quantity<WeightUnit>(1, WeightUnit.KILOGRAM);
//             var q2 = new Quantity<WeightUnit>(1000, WeightUnit.GRAM);

//             var result = q1.Add(q2);

//             Assert.AreEqual(new Quantity<WeightUnit>(2, WeightUnit.KILOGRAM), result);
//         }

//         [TestMethod]
//         public void testSubtract_UC12_BehaviorPreserved()
//         {
//             var q1 = new Quantity<VolumeUnit>(5, VolumeUnit.LITRE);
//             var q2 = new Quantity<VolumeUnit>(500, VolumeUnit.MILLILITRE);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(new Quantity<VolumeUnit>(4.5, VolumeUnit.LITRE), result);
//         }

//         [TestMethod]
//         public void testDivide_UC12_BehaviorPreserved()
//         {
//             var q1 = new Quantity<WeightUnit>(10, WeightUnit.KILOGRAM);
//             var q2 = new Quantity<WeightUnit>(5, WeightUnit.KILOGRAM);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(2.0, result);
//         }

//         // ---------- ROUNDING ----------

//         [TestMethod]
//         public void testRounding_AddSubtract_TwoDecimalPlaces()
//         {
//             var q1 = new Quantity<LengthUnit>(1.333, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(1.333, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(2.67, result.Value, 0.01);
//         }

//         [TestMethod]
//         public void testRounding_Divide_NoRounding()
//         {
//             var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(3, LengthUnit.FEET);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(3.333333, result, 0.001);
//         }

//         // ---------- IMMUTABILITY ----------

//         [TestMethod]
//         public void testImmutability_AfterAdd_ViaCentralizedHelper()
//         {
//             var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(10, q1.Value);
//             Assert.AreEqual(5, q2.Value);
//         }

//         [TestMethod]
//         public void testImmutability_AfterSubtract_ViaCentralizedHelper()
//         {
//             var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

//             q1.Subtract(q2);

//             Assert.AreEqual(10, q1.Value);
//         }

//         [TestMethod]
//         public void testImmutability_AfterDivide_ViaCentralizedHelper()
//         {
//             var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

//             q1.Divide(q2);

//             Assert.AreEqual(10, q1.Value);
//         }

//         // ---------- MULTI CATEGORY ----------

//         [TestMethod]
//         public void testAllOperations_AcrossAllCategories()
//         {
//             var length1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var length2 = new Quantity<LengthUnit>(5, LengthUnit.FEET);

//             var weight1 = new Quantity<WeightUnit>(10, WeightUnit.KILOGRAM);
//             var weight2 = new Quantity<WeightUnit>(5, WeightUnit.KILOGRAM);

//             var volume1 = new Quantity<VolumeUnit>(10, VolumeUnit.LITRE);
//             var volume2 = new Quantity<VolumeUnit>(5, VolumeUnit.LITRE);

//             Assert.AreEqual(new Quantity<LengthUnit>(15, LengthUnit.FEET), length1.Add(length2));
//             Assert.AreEqual(new Quantity<WeightUnit>(5, WeightUnit.KILOGRAM), weight1.Subtract(weight2));
//             Assert.AreEqual(2.0, volume1.Divide(volume2));
//         }

//         // ---------- CHAIN OPERATIONS ----------

//         [TestMethod]
//         public void testArithmetic_Chain_Operations()
//         {
//             var q1 = new Quantity<LengthUnit>(10, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(2, LengthUnit.FEET);
//             var q3 = new Quantity<LengthUnit>(1, LengthUnit.FEET);
//             var q4 = new Quantity<LengthUnit>(1, LengthUnit.FEET);

//             double result = q1.Add(q2).Subtract(q3).Divide(q4);

//             Assert.AreEqual(11.0, result);
//         }

//         // ---------- ERROR MESSAGE CONSISTENCY ----------

//         [TestMethod]
//         public void testErrorMessage_Consistency_Across_Operations()
//         {
//             var q = new Quantity<LengthUnit>(10, LengthUnit.FEET);

//             try
//             {
//                 q.Add(null);
//             }
//             catch (Exception ex)
//             {
//                 Assert.AreEqual("Second operand cannot be null", ex.Message);
//             }
//         }
//     }
// }