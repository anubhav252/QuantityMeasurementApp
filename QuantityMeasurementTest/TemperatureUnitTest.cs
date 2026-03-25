using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementMain.ModelLayer;

namespace QuantityMeasurementTests
{
    [TestClass]
    [TestCategory("TemperatureUnitTest")]
    public class TemperatureMeasurementTest
    {

        // ---------- EQUALITY TESTS ----------

        [TestMethod]
        public void testTemperatureEquality_CelsiusToCelsius_SameValue()
        {
            var q1 = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
            var q2 = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testTemperatureEquality_FahrenheitToFahrenheit_SameValue()
        {
            var q1 = new Quantity<TemperatureUnit>(32.0, TemperatureUnit.FAHRENHEIT);
            var q2 = new Quantity<TemperatureUnit>(32.0, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testTemperatureEquality_CelsiusToFahrenheit_0Celsius32Fahrenheit()
        {
            var c = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
            var f = new Quantity<TemperatureUnit>(32.0, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(c.Equals(f));
        }

        [TestMethod]
        public void testTemperatureEquality_CelsiusToFahrenheit_100Celsius212Fahrenheit()
        {
            var c = new Quantity<TemperatureUnit>(100.0, TemperatureUnit.CELSIUS);
            var f = new Quantity<TemperatureUnit>(212.0, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(c.Equals(f));
        }

        [TestMethod]
        public void testTemperatureEquality_CelsiusToFahrenheit_Negative40Equal()
        {
            var c = new Quantity<TemperatureUnit>(-40.0, TemperatureUnit.CELSIUS);
            var f = new Quantity<TemperatureUnit>(-40.0, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(c.Equals(f));
        }

        [TestMethod]
        public void testTemperatureEquality_SymmetricProperty()
        {
            var a = new Quantity<TemperatureUnit>(0.0, TemperatureUnit.CELSIUS);
            var b = new Quantity<TemperatureUnit>(32.0, TemperatureUnit.FAHRENHEIT);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(a));
        }

        [TestMethod]
        public void testTemperatureEquality_ReflexiveProperty()
        {
            var a = new Quantity<TemperatureUnit>(25.0, TemperatureUnit.CELSIUS);

            Assert.IsTrue(a.Equals(a));
        }

        // ---------- CONVERSION TESTS ----------

        [TestMethod]
        public void testTemperatureConversion_CelsiusToFahrenheit_VariousValues()
        {
            var q = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);
            var result = q.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(122.0, result.Value, 0.01);
        }

        [TestMethod]
        public void testTemperatureConversion_FahrenheitToCelsius_VariousValues()
        {
            var q = new Quantity<TemperatureUnit>(122, TemperatureUnit.FAHRENHEIT);
            var result = q.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(50.0, result.Value, 0.01);
        }

        [TestMethod]
        public void testTemperatureConversion_RoundTrip_PreservesValue()
        {
            var q = new Quantity<TemperatureUnit>(60, TemperatureUnit.CELSIUS);

            var converted = q.ConvertTo(TemperatureUnit.FAHRENHEIT)
                             .ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(60.0, converted.Value, 0.01);
        }

        [TestMethod]
        public void testTemperatureConversion_SameUnit()
        {
            var q = new Quantity<TemperatureUnit>(20, TemperatureUnit.CELSIUS);

            var result = q.ConvertTo(TemperatureUnit.CELSIUS);

            Assert.AreEqual(20, result.Value);
        }

        [TestMethod]
        public void testTemperatureConversion_ZeroValue()
        {
            var q = new Quantity<TemperatureUnit>(0, TemperatureUnit.CELSIUS);

            var result = q.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(32, result.Value, 0.01);
        }

        [TestMethod]
        public void testTemperatureConversion_NegativeValues()
        {
            var q = new Quantity<TemperatureUnit>(-20, TemperatureUnit.CELSIUS);

            var result = q.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(-4, result.Value, 0.01);
        }

        [TestMethod]
        public void testTemperatureConversion_LargeValues()
        {
            var q = new Quantity<TemperatureUnit>(1000, TemperatureUnit.CELSIUS);

            var result = q.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(1832, result.Value, 0.01);
        }

        // ---------- CROSS CATEGORY TESTS ----------

        [TestMethod]
        public void testTemperatureVsLengthIncompatibility()
        {
            var temp = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);
            var length = new Quantity<LengthUnit>(100, LengthUnit.FEET);

            Assert.IsFalse(temp.Equals(length));
        }

        [TestMethod]
        public void testTemperatureVsWeightIncompatibility()
        {
            var temp = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);
            var weight = new Quantity<WeightUnit>(50, WeightUnit.KILOGRAM);

            Assert.IsFalse(temp.Equals(weight));
        }

        [TestMethod]
        public void testTemperatureVsVolumeIncompatibility()
        {
            var temp = new Quantity<TemperatureUnit>(25, TemperatureUnit.CELSIUS);
            var volume = new Quantity<VolumeUnit>(25, VolumeUnit.LITRE);

            Assert.IsFalse(temp.Equals(volume));
        }

        // ---------- VALIDATION ----------



        [TestMethod]
        public void testTemperatureNullOperandValidation_InComparison()
        {
            var q = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);

            Assert.IsFalse(q.Equals(null));
        }

        [TestMethod]
        public void testTemperatureDifferentValuesInequality()
        {
            var a = new Quantity<TemperatureUnit>(50, TemperatureUnit.CELSIUS);
            var b = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);

            Assert.IsFalse(a.Equals(b));
        }

        // ---------- ENUM STRUCTURE ----------

        [TestMethod]
        public void testTemperatureUnit_AllConstants()
        {
            Assert.IsNotNull(TemperatureUnit.CELSIUS);
            Assert.IsNotNull(TemperatureUnit.FAHRENHEIT);
        }

        [TestMethod]
        public void testTemperatureUnit_NameMethod()
        {
            Assert.AreEqual("CELSIUS", TemperatureUnit.CELSIUS.ToString());
        }

        // ---------- GENERIC INTEGRATION ----------

        [TestMethod]
        public void testTemperatureIntegrationWithGenericQuantity()
        {
            var q = new Quantity<TemperatureUnit>(100, TemperatureUnit.CELSIUS);

            var converted = q.ConvertTo(TemperatureUnit.FAHRENHEIT);

            Assert.AreEqual(212, converted.Value, 0.01);
        }
    }
}