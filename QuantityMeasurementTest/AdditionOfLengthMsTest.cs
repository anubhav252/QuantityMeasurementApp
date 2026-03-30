// using Microsoft.VisualStudio.TestTools.UnitTesting;
// using QuantityMeasurementMain.ModelLayer;

// namespace QuantityMeasurementTest
// {
//     [TestClass]
//     [TestCategory("AdditionOfLength")]
//     public class LengthAdditionMsTest
//     {
//         private const double EPSILON = 0.0001;

//         [TestMethod]
//         public void TestAddition_SameUnit_FeetPlusFeet()
//         {
//             var q1 = new Length(1.0, LengthUnit.FEET);
//             var q2 = new Length(2.0, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(3.0, result.Value, EPSILON);
//             Assert.AreEqual(LengthUnit.FEET, result.Unit);
//         }

//         [TestMethod]
//         public void TestAddition_SameUnit_InchPlusInch()
//         {
//             var q1 = new Length(6.0, LengthUnit.INCHES);
//             var q2 = new Length(6.0, LengthUnit.INCHES);

//             var result = q1.Add(q2);

//             Assert.AreEqual(12.0, result.Value, EPSILON);
//             Assert.AreEqual(LengthUnit.INCHES, result.Unit);
//         }

//         [TestMethod]
//         public void TestAddition_CrossUnit_FeetPlusInches()
//         {
//             var q1 = new Length(1.0, LengthUnit.FEET);
//             var q2 = new Length(12.0, LengthUnit.INCHES);

//             var result = q1.Add(q2);

//             Assert.AreEqual(2.0, result.Value, EPSILON);
//             Assert.AreEqual(LengthUnit.FEET, result.Unit);
//         }

//         [TestMethod]
//         public void TestAddition_CrossUnit_InchPlusFeet()
//         {
//             var q1 = new Length(12.0, LengthUnit.INCHES);
//             var q2 = new Length(1.0, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(24.0, result.Value, EPSILON);
//             Assert.AreEqual(LengthUnit.INCHES, result.Unit);
//         }

//         [TestMethod]
//         public void TestAddition_CrossUnit_YardPlusFeet()
//         {
//             var q1 = new Length(1.0, LengthUnit.YARDS);
//             var q2 = new Length(3.0, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(2.0, result.Value, EPSILON);
//             Assert.AreEqual(LengthUnit.YARDS, result.Unit);
//         }

//         [TestMethod]
//         public void TestAddition_CrossUnit_CentimeterPlusInch()
//         {
//             var q1 = new Length(2.54, LengthUnit.CENTIMETERS);
//             var q2 = new Length(1.0, LengthUnit.INCHES);

//             var result = q1.Add(q2);

//             Assert.AreEqual(5.08, result.Value, EPSILON);
//             Assert.AreEqual(LengthUnit.CENTIMETERS, result.Unit);
//         }

//         [TestMethod]
//         public void TestAddition_Commutativity()
//         {
//             var a = new Length(1.0, LengthUnit.FEET);
//             var b = new Length(12.0, LengthUnit.INCHES);

//             var result1 = a.Add(b);
//             var result2 = b.Add(a);

//             Assert.IsTrue(result1.Equals(result2));
//         }

//         [TestMethod]
//         public void TestAddition_WithZero()
//         {
//             var q1 = new Length(5.0, LengthUnit.FEET);
//             var q2 = new Length(0.0, LengthUnit.INCHES);

//             var result = q1.Add(q2);

//             Assert.AreEqual(5.0, result.Value, EPSILON);
//             Assert.AreEqual(LengthUnit.FEET, result.Unit);
//         }

//         [TestMethod]
//         public void TestAddition_NegativeValues()
//         {
//             var q1 = new Length(5.0, LengthUnit.FEET);
//             var q2 = new Length(-2.0, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(3.0, result.Value, EPSILON);
//         }

//         [TestMethod]
//         public void TestAddition_LargeValues()
//         {
//             var q1 = new Length(1e6, LengthUnit.FEET);
//             var q2 = new Length(1e6, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(2e6, result.Value, EPSILON);
//         }

//         [TestMethod]
//         public void TestAddition_SmallValues()
//         {
//             var q1 = new Length(0.001, LengthUnit.FEET);
//             var q2 = new Length(0.002, LengthUnit.FEET);

//             var result = q1.Add(q2);

//             Assert.AreEqual(0.003, result.Value, EPSILON);
//         }
//     }
// }