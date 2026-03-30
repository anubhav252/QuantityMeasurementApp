using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Threading.Tasks;

namespace QuantityMeasurementTest
{
    [TestClass]
    [TestCategory("AspDotNetTest")]
    public class QuantityApiTests
    {
        private static HttpClient _client;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            var factory = new WebApplicationFactory<Program>();
            _client = factory.CreateClient();
        }

        
        [TestMethod]
        public async Task TestApplicationStarts()
        {
            var response = await _client.GetAsync("/swagger");
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestMethod]
        public async Task TestConvertQuantities()
        {
            var request = new
            {
                input = new
                {
                    value = 10,
                    unit = "Feet",
                    category = "Length"
                },
                targetUnit = "Inch"
            };

            var response = await _client.PostAsJsonAsync("/api/quantities/convert", request);

            var content = await response.Content.ReadAsStringAsync();
            Console.WriteLine(content);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
        
        [TestMethod]
        public async Task TestAddQuantities()
        {
            var request = new
            {
                first = new { value = 2, unit = "Feet", category = "Length" },
                second = new { value = 12, unit = "Inch", category = "Length" },
                targetUnit = "Feet"
            };

            var response = await _client.PostAsJsonAsync("/api/quantities/add", request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        
        [TestMethod]
        public async Task TestCompareQuantities()
        {
            var request = new
            {
                first = new { value = 1, unit = "Feet", category = "Length" },
                second = new { value = 12, unit = "Inch", category = "Length" }
            };

            var response = await _client.PostAsJsonAsync("/api/quantities/compare", request);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

    
        [TestMethod]
        public async Task TestInvalidInput_Returns400()
        {
            var request = new
            {
                first = (object)null
            };

            var response = await _client.PostAsJsonAsync("/api/quantities/add", request);

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
        }

        
        [TestMethod]
        public async Task TestHistoryEndpoint()
        {
            var response = await _client.GetAsync("/api/quantities/history");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            var content = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(content.Contains("quantities"));
        }

        
        [TestMethod]
        public async Task TestSwaggerLoads()
        {
            var response = await _client.GetAsync("/swagger/index.html");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        
        [TestMethod]
        public async Task TestContentNegotiation_JSON()
        {
            var request = new
            {
                input = new
                {
                    value = 10,
                    unit = "Feet",
                    category = "Length"
                },
                targetUnit = "Inch"
            };

            var response = await _client.PostAsJsonAsync("/api/quantities/convert", request);

            var content = await response.Content.ReadAsStringAsync();
            
            Console.WriteLine(content); 

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.IsTrue(response.Content.Headers.ContentType.ToString().Contains("json"));
        }
    }
}