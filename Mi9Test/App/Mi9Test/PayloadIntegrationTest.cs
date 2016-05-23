namespace Mi9Test
{
    using System.Net;
    using System.Web.Http.Results;

    using App.Controllers;
    using App.Models;
    using App.Services;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PayloadIntegrationTest
    {
        [TestMethod]
        public void ShouldThrowError()
        {
            IDataService service = new DataService();
            var controller = new PayloadController(service);

            var response = controller.FilterPayload(null);

            var result = response as NegotiatedContentResult<ErrorMessageDto>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsTrue(result.StatusCode == HttpStatusCode.BadRequest);
            Assert.IsTrue(result.Content.Error == "Could not decode request: JSON parsing failed");
        }
    }
}
