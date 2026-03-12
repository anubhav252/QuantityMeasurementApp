using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantityMeasurementMain.ModelLayer;

namespace QuantityMeasurementTests
{
    [TestClass]
    [TestCategory("VolumeUnitTest")]
    public class VolumeQuantityTests
    {

        private const double EPS = 0.0001;

        // ---------- EQUALITY TESTS ----------

        [TestMethod]
        public void testEquality_LitreToLitre_SameValue()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_LitreToLitre_DifferentValue()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRE);

            Assert.IsFalse(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_LitreToMillilitre_EquivalentValue()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_MillilitreToLitre_EquivalentValue()
        {
            var q1 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);
            var q2 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_LitreToGallon_EquivalentValue()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(0.264172, VolumeUnit.GALLON);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_GallonToLitre_EquivalentValue()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);
            var q2 = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_VolumeVsLength_Incompatible()
        {
            var volume = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var length = new Quantity<LengthUnit>(1.0, LengthUnit.FEET);

            Assert.IsFalse(volume.Equals(length));
        }

        [TestMethod]
        public void testEquality_VolumeVsWeight_Incompatible()
        {
            var volume = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var weight = new Quantity<WeightUnit>(1.0, WeightUnit.KILOGRAM);

            Assert.IsFalse(volume.Equals(weight));
        }

        [TestMethod]
        public void testEquality_NullComparison()
        {
            var q = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.IsFalse(q.Equals(null));
        }

        [TestMethod]
        public void testEquality_SameReference()
        {
            var q = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.IsTrue(q.Equals(q));
        }

        [TestMethod]
        public void testEquality_TransitiveProperty()
        {
            var a = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var b = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);
            var c = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            Assert.IsTrue(a.Equals(b));
            Assert.IsTrue(b.Equals(c));
            Assert.IsTrue(a.Equals(c));
        }

        [TestMethod]
        public void testEquality_ZeroValue()
        {
            var q1 = new Quantity<VolumeUnit>(0.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(0.0, VolumeUnit.MILLILITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_NegativeVolume()
        {
            var q1 = new Quantity<VolumeUnit>(-1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(-1000.0, VolumeUnit.MILLILITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_LargeVolumeValue()
        {
            var q1 = new Quantity<VolumeUnit>(1000000.0, VolumeUnit.MILLILITRE);
            var q2 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.LITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        [TestMethod]
        public void testEquality_SmallVolumeValue()
        {
            var q1 = new Quantity<VolumeUnit>(0.001, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(1.0, VolumeUnit.MILLILITRE);

            Assert.IsTrue(q1.Equals(q2));
        }

        // ---------- CONVERSION TESTS ----------

        [TestMethod]
        public void testConversion_LitreToMillilitre()
        {
            var q = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);

            var result = q.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(1000.0, result.Value, EPS);
        }

        [TestMethod]
        public void testConversion_MillilitreToLitre()
        {
            var q = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var result = q.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(1.0, result.Value, EPS);
        }

        [TestMethod]
        public void testConversion_GallonToLitre()
        {
            var q = new Quantity<VolumeUnit>(1.0, VolumeUnit.GALLON);

            var result = q.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(3.78541, result.Value, EPS);
        }

        [TestMethod]
        public void testConversion_LitreToGallon()
        {
            var q = new Quantity<VolumeUnit>(3.78541, VolumeUnit.LITRE);

            var result = q.ConvertTo(VolumeUnit.GALLON);

            Assert.AreEqual(1.0, result.Value, EPS);
        }

        [TestMethod]
        public void testConversion_SameUnit()
        {
            var q = new Quantity<VolumeUnit>(5.0, VolumeUnit.LITRE);

            var result = q.ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(5.0, result.Value, EPS);
        }

        [TestMethod]
        public void testConversion_ZeroValue()
        {
            var q = new Quantity<VolumeUnit>(0.0, VolumeUnit.LITRE);

            var result = q.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(0.0, result.Value, EPS);
        }

        [TestMethod]
        public void testConversion_NegativeValue()
        {
            var q = new Quantity<VolumeUnit>(-1.0, VolumeUnit.LITRE);

            var result = q.ConvertTo(VolumeUnit.MILLILITRE);

            Assert.AreEqual(-1000.0, result.Value, EPS);
        }

        [TestMethod]
        public void testConversion_RoundTrip()
        {
            var q = new Quantity<VolumeUnit>(1.5, VolumeUnit.LITRE);

            var result = q.ConvertTo(VolumeUnit.MILLILITRE)
                          .ConvertTo(VolumeUnit.LITRE);

            Assert.AreEqual(1.5, result.Value, EPS);
        }

        // ---------- ADDITION TESTS ----------

        [TestMethod]
        public void testAddition_SameUnit_LitrePlusLitre()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(2.0, VolumeUnit.LITRE);

            var result = q1.Add(q2);

            Assert.AreEqual(3.0, result.Value, EPS);
        }

        [TestMethod]
        public void testAddition_CrossUnit_LitrePlusMillilitre()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var result = q1.Add(q2);

            Assert.AreEqual(2.0, result.Value, EPS);
        }

        [TestMethod]
        public void testAddition_ExplicitTargetUnit_Millilitre()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var result = q1.Add(q2, VolumeUnit.MILLILITRE);

            Assert.AreEqual(2000.0, result.Value, EPS);
        }

        [TestMethod]
        public void testAddition_Commutativity()
        {
            var q1 = new Quantity<VolumeUnit>(1.0, VolumeUnit.LITRE);
            var q2 = new Quantity<VolumeUnit>(1000.0, VolumeUnit.MILLILITRE);

            var r1 = q1.Add(q2);
            var r2 = q2.Add(q1);

            Assert.IsTrue(r1.Equals(r2));
        }
        // ---------- ENUM TESTS ----------

        [TestMethod]
        public void testVolumeUnitEnum_LitreConstant()
        {
            Assert.AreEqual(1.0, VolumeUnit.LITRE.GetConversionFactor());
        }

        [TestMethod]
        public void testVolumeUnitEnum_MillilitreConstant()
        {
            Assert.AreEqual(0.001, VolumeUnit.MILLILITRE.GetConversionFactor());
        }

        [TestMethod]
        public void testVolumeUnitEnum_GallonConstant()
        {
            Assert.AreEqual(3.78541, VolumeUnit.GALLON.GetConversionFactor());
        }

        // ---------- BASE UNIT TESTS ----------

        [TestMethod]
        public void testConvertToBaseUnit_GallonToLitre()
        {
            double result = VolumeUnit.GALLON.ConvertToBaseUnit(1.0);

            Assert.AreEqual(3.78541, result, EPS);
        }

        [TestMethod]
        public void testConvertFromBaseUnit_LitreToMillilitre()
        {
            double result = VolumeUnit.MILLILITRE.ConvertFromBaseUnit(1.0);

            Assert.AreEqual(1000.0, result, EPS);
        }

    }
}