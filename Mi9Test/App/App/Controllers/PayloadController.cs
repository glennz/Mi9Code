namespace App.Controllers
{
    using System.Linq;
    using System.Net;
    using System.Web.Http;
    using App.Models;
    using App.Services;

    public class PayloadController : ApiController
    {
        private readonly IDataService _dataService;

        public PayloadController(IDataService dataService)
        {
            _dataService = dataService;
        }

        /// <summary>
        /// Filter Payload
        /// </summary>
        /// <param name="payloadDto"></param>
        /// <returns></returns>
        [HttpPost, Route]
        public IHttpActionResult FilterPayload([FromBody] PayloadDto payloadDto)
        {
            if (!_dataService.ValidatePayload(payloadDto))
            {
                //if invalid, return 400 with message
                return Content(HttpStatusCode.BadRequest, 
                    new ErrorMessageDto { Error = "Could not decode request: JSON parsing failed" });
            }

            var data = _dataService.FilterPayload(payloadDto);

            var payloadItemShortDtos = data as PayloadItemShortDto[] ?? data.ToArray();

            return Ok(new PayloadResponseDto { Response = payloadItemShortDtos });
        }
    }
}
