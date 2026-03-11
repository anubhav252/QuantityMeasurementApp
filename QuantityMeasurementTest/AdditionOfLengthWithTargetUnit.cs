using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementMain.ModelLayer;

namespace QuantityMeasurementTest
{
    [TestClass]
    [TestCategory("AdditionOfLengthWithTargetUnit")]
    public class LengthAdditionExplicitTargetMsTest
    {
        private const double EPSILON = 0.0001;

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Feet()
        {
            var a = new Length(1.0, Length.LengthUnit.FEET);
            var b = new Length(12.0, Length.LengthUnit.INCHES);

            var result = a.Add(b, Length.LengthUnit.FEET);

            Assert.AreEqual(2.0, result.Value, EPSILON);
            Assert.AreEqual(Length.LengthUnit.FEET, result.Unit);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Inches()
        {
            var a = new Length(1.0, Length.LengthUnit.FEET);
            var b = new Length(12.0, Length.LengthUnit.INCHES);

            var result = a.Add(b, Length.LengthUnit.INCHES);

            Assert.AreEqual(24.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Yards()
        {
            var a = new Length(1.0, Length.LengthUnit.FEET);
            var b = new Length(12.0, Length.LengthUnit.INCHES);

            var result = a.Add(b, Length.LengthUnit.YARDS);

            Assert.AreEqual(0.6667, result.Value, 0.001);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Centimeters()
        {
            var a = new Length(1.0, Length.LengthUnit.INCHES);
            var b = new Length(1.0, Length.LengthUnit.INCHES);

            var result = a.Add(b, Length.LengthUnit.CENTIMETER);

            Assert.AreEqual(5.08, result.Value, 0.01);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SameAsFirstOperand()
        {
            var a = new Length(2.0, Length.LengthUnit.YARDS);
            var b = new Length(3.0, Length.LengthUnit.FEET);

            var result = a.Add(b, Length.LengthUnit.YARDS);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SameAsSecondOperand()
        {
            var a = new Length(2.0, Length.LengthUnit.YARDS);
            var b = new Length(3.0, Length.LengthUnit.FEET);

            var result = a.Add(b, Length.LengthUnit.FEET);

            Assert.AreEqual(9.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Commutativity()
        {
            var a = new Length(1.0, Length.LengthUnit.FEET);
            var b = new Length(12.0, Length.LengthUnit.INCHES);

            var r1 = a.Add(b, Length.LengthUnit.YARDS);
            var r2 = b.Add(a, Length.LengthUnit.YARDS);

            Assert.AreEqual(r1.Value, r2.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_WithZero()
        {
            var a = new Length(5.0, Length.LengthUnit.FEET);
            var b = new Length(0.0, Length.LengthUnit.INCHES);

            var result = a.Add(b, Length.LengthUnit.YARDS);

            Assert.AreEqual(1.6667, result.Value, 0.001);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_NegativeValues()
        {
            var a = new Length(5.0, Length.LengthUnit.FEET);
            var b = new Length(-2.0, Length.LengthUnit.FEET);

            var result = a.Add(b, Length.LengthUnit.INCHES);

            Assert.AreEqual(36.0, result.Value, EPSILON);
        }
        [TestMethod]
        public void testAddition_ExplicitTargetUnit_LargeToSmallScale()
        {
            var a = new Length(1000.0, Length.LengthUnit.FEET);
            var b = new Length(500.0, Length.LengthUnit.FEET);

            var result = a.Add(b, Length.LengthUnit.INCHES);

            Assert.AreEqual(18000.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_SmallToLargeScale()
        {
            var a = new Length(12.0, Length.LengthUnit.INCHES);
            var b = new Length(12.0, Length.LengthUnit.INCHES);

            var result = a.Add(b, Length.LengthUnit.YARDS);

            Assert.AreEqual(0.6667, result.Value, 0.001);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_AllUnitCombinations()
        {
            var feet = new Length(1, Length.LengthUnit.FEET);
            var inches = new Length(12, Length.LengthUnit.INCHES);
            var yards = new Length(1, Length.LengthUnit.YARDS);

            var r1 = feet.Add(inches, Length.LengthUnit.FEET);
            var r2 = feet.Add(yards, Length.LengthUnit.INCHES);
            var r3 = yards.Add(inches, Length.LengthUnit.CENTIMETER);

            Assert.IsTrue(r1.Value > 0);
            Assert.IsTrue(r2.Value > 0);
            Assert.IsTrue(r3.Value > 0);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_PrecisionTolerance()
        {
            var a = new Length(0.1, Length.LengthUnit.FEET);
            var b = new Length(0.2, Length.LengthUnit.FEET);

            var result = a.Add(b, Length.LengthUnit.FEET);

            Assert.AreEqual(0.3, result.Value, 0.0001);
        }
    }
}