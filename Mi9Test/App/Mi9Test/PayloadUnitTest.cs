namespace Mi9Test
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using System.Web.Http.Results;

    using App.Controllers;
    using App.Models;
    using App.Services;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class PayloadUnitTest
    {        
        [TestMethod]
        public void ShouldLoadPayloadDataFromJsonFile()
        {
            var dataProvider = new DataProvider();
            var o = dataProvider.PayloadData();

            Assert.IsTrue(o != null, "fail");
            Assert.IsTrue(o.TotalRecords == 75, "Fail");
            Assert.IsTrue(o.Payload.Count() == 10, "Fail");
            Assert.IsTrue(o.Payload.First().Country == "UK", "Fail");
        }

        [TestMethod]
        public void ShouldLoadPayloadResultDataFromJson()
        {
            var dataProvider = new DataProvider();
            var o = dataProvider.PayloadResponseData();

            Assert.IsTrue(o != null, "Fail");
            Assert.IsTrue(o.Response.Count() == 7, "Fail");
            Assert.IsTrue(o.Response.First().Image
                          == "http://mybeautifulcatchupservice.com/img/shows/16KidsandCounting1280.jpg");
        }

        [TestMethod]
        public void ShouldFilterPayloadData()
        {
            var dataProvider = new DataProvider();
            var o = dataProvider.PayloadData();
            var r = dataProvider.PayloadResponseData();

            var service = new DataService();
            var response = service.FilterPayload(o);

            var a = r.Response.ToList();
            var b = response.ToList();

            for (var i = 0; i < 7; i++)
            {
                Assert.IsTrue(a[i].Image == b[i].Image, string.Format("fail at {0}", i));
                Assert.IsTrue(a[i].Slug == b[i].Slug, string.Format("fail at {0}", i));
                Assert.IsTrue(a[i].Title == b[i].Title, string.Format("fail at {0}", i));
            }
        }

        //Test controller with mock
        [TestMethod]
        public void ShouldFilterPayloadDataAndReturnErrorMessage()
        {
            var m = new Mock<IDataService>();
            m.Setup(mock => mock.FilterPayload(null)).Returns((IEnumerable<PayloadItemShortDto>)null);

            var controller = new PayloadController(m.Object);
            var response = controller.FilterPayload(null);

            var result = response as NegotiatedContentResult<ErrorMessageDto>;

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Content);
            Assert.IsTrue(result.StatusCode == HttpStatusCode.BadRequest);
            Assert.IsTrue(result.Content.Error == "Could not decode request: JSON parsing failed");
        }
    }
}
