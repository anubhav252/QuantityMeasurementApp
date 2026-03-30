// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using QuantityMeasurementMain.ModelLayer;

// namespace QuantityMeasurementTests
// {
//     [TestClass]
//     [TestCategory("GenericQuantityTests")]
//     public class GenericQuantityTests
//     {

//         // ===============================
//         // IMeasurable Interface Tests
//         // ===============================

//         [TestMethod]
//         public void testIMeasurableInterface_LengthUnitImplementation()
//         {
//             LengthUnit unit = LengthUnit.FEET;

//             double factor = unit.GetConversionFactor();
//             double baseValue = unit.ConvertToBaseUnit(1);
//             double original = unit.ConvertFromBaseUnit(baseValue);
//             string name = unit.GetUnitName();

//             Assert.AreEqual(1.0, factor);
//             Assert.AreEqual(1.0, baseValue);
//             Assert.AreEqual(1.0, original);
//             Assert.AreEqual("FEET", name);
//         }

//         [TestMethod]
//         public void testIMeasurableInterface_WeightUnitImplementation()
//         {
//             WeightUnit unit = WeightUnit.KILOGRAM;

//             double factor = unit.GetConversionFactor();
//             double baseValue = unit.ConvertToBaseUnit(1);
//             double original = unit.ConvertFromBaseUnit(baseValue);
//             string name = unit.GetUnitName();

//             Assert.AreEqual(1.0, factor);
//             Assert.AreEqual(1.0, baseValue);
//             Assert.AreEqual(1.0, original);
//             Assert.AreEqual("KILOGRAM", name);
//         }

//         [TestMethod]
//         public void testIMeasurableInterface_ConsistentBehavior()
//         {
//             LengthUnit length = LengthUnit.FEET;
//             WeightUnit weight = WeightUnit.KILOGRAM;

//             Assert.IsTrue(length.GetConversionFactor() > 0);
//             Assert.IsTrue(weight.GetConversionFactor() > 0);
//         }


//         // ===============================
//         // Equality Tests
//         // ===============================

//         [TestMethod]
//         public void testGenericQuantity_LengthOperations_Equality()
//         {
//             var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCHES);

//             Assert.IsTrue(q1.Equals(q2));
//         }

//         [TestMethod]
//         public void testGenericQuantity_WeightOperations_Equality()
//         {
//             var q1 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
//             var q2 = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

//             Assert.IsTrue(q1.Equals(q2));
//         }


//         // ===============================
//         // Conversion Tests
//         // ===============================

//         [TestMethod]
//         public void testGenericQuantity_LengthOperations_Conversion()
//         {
//             var q = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

//             var result = q.ConvertTo(LengthUnit.INCHES);

//             Assert.AreEqual(12.0, result.Value);
//             Assert.AreEqual(LengthUnit.INCHES, result.Unit);
//         }

//         [TestMethod]
//         public void testGenericQuantity_WeightOperations_Conversion()
//         {
//             var q = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

//             var result = q.ConvertTo(WeightUnit.GRAM);

//             Assert.AreEqual(1000.0, result.Value);
//             Assert.AreEqual(WeightUnit.GRAM, result.Unit);
//         }


//         // ===============================
//         // Addition Tests
//         // ===============================

//         [TestMethod]
//         public void testGenericQuantity_LengthOperations_Addition()
//         {
//             var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCHES);

//             var result = q1.Add(q2, LengthUnit.FEET);

//             Assert.AreEqual(2.0, result.Value, 0.001);
//         }

//         [TestMethod]
//         public void testGenericQuantity_WeightOperations_Addition()
//         {
//             var q1 = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);
//             var q2 = new Quantity<WeightUnit>(1000.0, WeightUnit.GRAM);

//             var result = q1.Add(q2, WeightUnit.KILOGRAM);

//             Assert.AreEqual(2.0, result.Value, 0.001);
//         }


//         // ===============================
//         // Cross Category Prevention
//         // ===============================

//         [TestMethod]
//         public void testCrossCategoryPrevention_LengthVsWeight()
//         {
//             var length = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
//             var weight = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

//             Assert.IsFalse(length.Equals(weight));
//         }



//         // ===============================
//         // HashCode Consistency
//         // ===============================

//         [TestMethod]
//         public void testHashCode_GenericQuantity_Consistency()
//         {
//             var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCHES);

//             Assert.AreEqual(q1.GetHashCode(), q2.GetHashCode());
//         }


//         // ===============================
//         // Equals Contract
//         // ===============================

//         [TestMethod]
//         public void testEquals_GenericQuantity_ContractPreservation()
//         {
//             var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);
//             var q2 = new Quantity<LengthUnit>(12.0, LengthUnit.INCHES);
//             var q3 = new Quantity<LengthUnit>(0.3333, LengthUnit.YARDS);

//             Assert.IsTrue(q1.Equals(q2));
//             Assert.IsTrue(q2.Equals(q3));
//             Assert.IsTrue(q1.Equals(q3));
//         }


//         // ===============================
//         // Immutability
//         // ===============================

//         [TestMethod]
//         public void testImmutability_GenericQuantity()
//         {
//             var q1 = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

//             var q2 = q1.ConvertTo(LengthUnit.INCHES);

//             Assert.AreNotSame(q1, q2);
//         }


//         // ===============================
//         // Scalability Test
//         // ===============================

//         enum VolumeUnit
//         {
//             LITER,
//             MILLILITER
//         }

//         [TestMethod]
//         public void testScalability_NewUnitEnumIntegration()
//         {
//             Assert.IsTrue(Enum.IsDefined(typeof(VolumeUnit), VolumeUnit.LITER));
//         }

//     }
// }