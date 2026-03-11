using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementMain.ModelLayer;

namespace QuantityMeasurementTest
{
    [TestClass]
    [TestCategory("WeightUnitTest")]
    public class WeightMsTest
    {
        private const double EPSILON = 0.0001;

        // ---------------- EQUALITY TESTS ----------------

        [TestMethod]
        public void testEquality_KilogramToKilogram_SameValue()
        {
            var w1 = new Weight(1.0, WeightUnit.KILOGRAM);
            var w2 = new Weight(1.0, WeightUnit.KILOGRAM);

            Assert.IsTrue(w1.Equals(w2));
        }

        [TestMethod]
        public void testEquality_KilogramToKilogram_DifferentValue()
        {
            var w1 = new Weight(1.0, WeightUnit.KILOGRAM);
            var w2 = new Weight(2.0, WeightUnit.KILOGRAM);

            Assert.IsFalse(w1.Equals(w2));
        }

        [TestMethod]
        public void testEquality_KilogramToGram_EquivalentValue()
        {
            var w1 = new Weight(1.0, WeightUnit.KILOGRAM);
            var w2 = new Weight(1000.0, WeightUnit.GRAM);

            Assert.IsTrue(w1.Equals(w2));
        }

        [TestMethod]
        public void testEquality_GramToKilogram_EquivalentValue()
        {
            var w1 = new Weight(1000.0, WeightUnit.GRAM);
            var w2 = new Weight(1.0, WeightUnit.KILOGRAM);

            Assert.IsTrue(w1.Equals(w2));
        }

        [TestMethod]
        public void testEquality_WeightVsLength_Incompatible()
        {
            var weight = new Weight(1.0, WeightUnit.KILOGRAM);
            var length = new Length(1.0, LengthUnit.FEET);

            Assert.IsFalse(weight.Equals(length));
        }

        [TestMethod]
        public void testEquality_NullComparison()
        {
            var weight = new Weight(1.0, WeightUnit.KILOGRAM);

            Assert.IsFalse(weight.Equals(null));
        }

        [TestMethod]
        public void testEquality_SameReference()
        {
            var weight = new Weight(1.0, WeightUnit.KILOGRAM);

            Assert.IsTrue(weight.Equals(weight));
        }

        [TestMethod]
        public void testEquality_TransitiveProperty()
        {
            var a = new Weight(1.0, WeightUnit.KILOGRAM);
            var b = new Weight(1000.0, WeightUnit.GRAM);
            var c = new Weight(1.0, WeightUnit.KILOGRAM);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(c));
            Assert.IsTrue(a.Equals(c));
        }

        [TestMethod]
        public void testEquality_ZeroValue()
        {
            var a = new Weight(0.0, WeightUnit.KILOGRAM);
            var b = new Weight(0.0, WeightUnit.GRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_NegativeWeight()
        {
            var a = new Weight(-1.0, WeightUnit.KILOGRAM);
            var b = new Weight(-1000.0, WeightUnit.GRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_LargeWeightValue()
        {
            var a = new Weight(1000000.0, WeightUnit.GRAM);
            var b = new Weight(1000.0, WeightUnit.KILOGRAM);

            Assert.IsTrue(a.Equals(b));
        }

        [TestMethod]
        public void testEquality_SmallWeightValue()
        {
            var a = new Weight(0.001, WeightUnit.KILOGRAM);
            var b = new Weight(1.0, WeightUnit.GRAM);

            Assert.IsTrue(a.Equals(b));
        }

        // ---------------- CONVERSION TESTS ----------------

        [TestMethod]
        public void testConversion_PoundToKilogram()
        {
            var weight = new Weight(2.20462, WeightUnit.POUND);

            var result = weight.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(1.0, result.Value, 0.01);
        }

        [TestMethod]
        public void testConversion_KilogramToPound()
        {
            var weight = new Weight(1.0, WeightUnit.KILOGRAM);

            var result = weight.ConvertTo(WeightUnit.POUND);

            Assert.AreEqual(2.20462, result.Value, 0.01);
        }

        [TestMethod]
        public void testConversion_SameUnit()
        {
            var weight = new Weight(5.0, WeightUnit.KILOGRAM);

            var result = weight.ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(5.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testConversion_ZeroValue()
        {
            var weight = new Weight(0.0, WeightUnit.KILOGRAM);

            var result = weight.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(0.0, result.Value);
        }

        [TestMethod]
        public void testConversion_NegativeValue()
        {
            var weight = new Weight(-1.0, WeightUnit.KILOGRAM);

            var result = weight.ConvertTo(WeightUnit.GRAM);

            Assert.AreEqual(-1000.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testConversion_RoundTrip()
        {
            var weight = new Weight(1.5, WeightUnit.KILOGRAM);

            var result =
                weight.ConvertTo(WeightUnit.GRAM)
                      .ConvertTo(WeightUnit.KILOGRAM);

            Assert.AreEqual(1.5, result.Value, EPSILON);
        }

        // ---------------- ADDITION TESTS ----------------

        [TestMethod]
        public void testAddition_SameUnit_KilogramPlusKilogram()
        {
            var w1 = new Weight(1.0, WeightUnit.KILOGRAM);
            var w2 = new Weight(2.0, WeightUnit.KILOGRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_CrossUnit_KilogramPlusGram()
        {
            var w1 = new Weight(1.0, WeightUnit.KILOGRAM);
            var w2 = new Weight(1000.0, WeightUnit.GRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(2.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_CrossUnit_PoundPlusKilogram()
        {
            var w1 = new Weight(2.20462, WeightUnit.POUND);
            var w2 = new Weight(1.0, WeightUnit.KILOGRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(4.40924, result.Value, 0.01);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Kilogram()
        {
            var w1 = new Weight(1.0, WeightUnit.KILOGRAM);
            var w2 = new Weight(1000.0, WeightUnit.GRAM);

            var result = w1.Add(w2, WeightUnit.GRAM);

            Assert.AreEqual(2000.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_Commutativity()
        {
            var a = new Weight(1.0, WeightUnit.KILOGRAM);
            var b = new Weight(1000.0, WeightUnit.GRAM);

            var r1 = a.Add(b);
            var r2 = b.Add(a);

            Assert.IsTrue(r1.Equals(r2));
        }

        [TestMethod]
        public void testAddition_WithZero()
        {
            var w1 = new Weight(5.0, WeightUnit.KILOGRAM);
            var w2 = new Weight(0.0, WeightUnit.GRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(5.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_NegativeValues()
        {
            var w1 = new Weight(5.0, WeightUnit.KILOGRAM);
            var w2 = new Weight(-2000.0, WeightUnit.GRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(3.0, result.Value, EPSILON);
        }

        [TestMethod]
        public void testAddition_LargeValues()
        {
            var w1 = new Weight(1e6, WeightUnit.KILOGRAM);
            var w2 = new Weight(1e6, WeightUnit.KILOGRAM);

            var result = w1.Add(w2);

            Assert.AreEqual(2e6, result.Value, EPSILON);
        }
    }
}