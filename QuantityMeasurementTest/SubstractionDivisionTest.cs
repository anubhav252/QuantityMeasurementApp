// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using QuantityMeasurementMain.ModelLayer;

// namespace QuantityMeasurementTests
// {
//     [TestClass]
//     [TestCategory("SubtractionDivisionTests")]
//     public class SubtractionDivisionTests
//     {
//         private const double EPS = 0.001;

//         // ---------- SUBTRACTION TESTS ----------

//         [TestMethod]
//         public void testSubtraction_SameUnit_FeetMinusFeet()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(5.0, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_SameUnit_LitreMinusLitre()
//         {
//             var q1 = new Quantity<VolumeUnit>(10.0, VolumeUnit.LITRE);
//             var q2 = new Quantity<VolumeUnit>(3.0, VolumeUnit.LITRE);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(7.0, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_CrossUnit_FeetMinusInches()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(6.0, LengthUnit.INCHES);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(9.5, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_ExplicitTargetUnit_Inches()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(6.0, LengthUnit.INCHES);

//             var result = q1.Subtract(q2, LengthUnit.INCHES);

//             Assert.AreEqual(114.0, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_ResultingInNegative()
//         {
//             var q1 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(-5.0, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_ResultingInZero()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(120.0, LengthUnit.INCHES);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(0.0, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_WithZeroOperand()
//         {
//             var q1 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(0.0, LengthUnit.INCHES);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(5.0, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_WithNegativeValues()
//         {
//             var q1 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(-2.0, LengthUnit.FEET);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(7.0, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_NonCommutative()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

//             var r1 = q1.Subtract(q2);
//             var r2 = q2.Subtract(q1);

//             Assert.AreEqual(5.0, r1.Value, EPS);
//             Assert.AreEqual(-5.0, r2.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_WithLargeValues()
//         {
//             var q1 = new Quantity<WeightUnit>(1e6, WeightUnit.KILOGRAM);
//             var q2 = new Quantity<WeightUnit>(5e5, WeightUnit.KILOGRAM);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(5e5, result.Value, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_ChainedOperations()
//         {
//             var result = new Quantity<LengthUnit>(10.0, LengthUnit.FEET)
//                 .Subtract(new Quantity<LengthUnit>(2.0, LengthUnit.FEET))
//                 .Subtract(new Quantity<LengthUnit>(1.0, LengthUnit.FEET));

//             Assert.AreEqual(7.0, result.Value, EPS);
//         }

//         // ---------- DIVISION TESTS ----------

//         [TestMethod]
//         public void testDivision_SameUnit_FeetDividedByFeet()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(5.0, result, EPS);
//         }

//         [TestMethod]
//         public void testDivision_SameUnit_LitreDividedByLitre()
//         {
//             var q1 = new Quantity<VolumeUnit>(10.0, VolumeUnit.LITRE);
//             var q2 = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(2.0, result, EPS);
//         }

//         [TestMethod]
//         public void testDivision_CrossUnit_FeetDividedByInches()
//         {
//             var q1 = new Quantity<LengthUnit>(24.0, LengthUnit.INCHES);
//             var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(1.0, result, EPS);
//         }

//         [TestMethod]
//         public void testDivision_RatioGreaterThanOne()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(2.0, LengthUnit.FEET);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(5.0, result, EPS);
//         }

//         [TestMethod]
//         public void testDivision_RatioLessThanOne()
//         {
//             var q1 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(0.5, result, EPS);
//         }

//         [TestMethod]
//         public void testDivision_RatioEqualToOne()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(1.0, result, EPS);
//         }

//         [TestMethod]
//         public void testDivision_NonCommutative()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

//             double r1 = q1.Divide(q2);
//             double r2 = q2.Divide(q1);

//             Assert.AreEqual(2.0, r1, EPS);
//             Assert.AreEqual(0.5, r2, EPS);
//         }

//         [TestMethod]
//         public void testDivision_WithLargeRatio()
//         {
//             var q1 = new Quantity<WeightUnit>(1e6, WeightUnit.KILOGRAM);
//             var q2 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(1e6, result, EPS);
//         }

//         [TestMethod]
//         public void testDivision_WithSmallRatio()
//         {
//             var q1 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
//             var q2 = new Quantity<WeightUnit>(1e6, WeightUnit.KILOGRAM);

//             double result = q1.Divide(q2);

//             Assert.AreEqual(1e-6, result, EPS);
//         }

//         [TestMethod]
//         public void testSubtraction_Immutability()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

//             var result = q1.Subtract(q2);

//             Assert.AreEqual(10.0, q1.Value);
//             Assert.AreEqual(5.0, q2.Value);
//         }

//         [TestMethod]
//         public void testDivision_Immutability()
//         {
//             var q1 = new Quantity<LengthUnit>(10.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(5.0, LengthUnit.FEET);

//             q1.Divide(q2);

//             Assert.AreEqual(10.0, q1.Value);
//             Assert.AreEqual(5.0, q2.Value);
//         }

//     }
// }