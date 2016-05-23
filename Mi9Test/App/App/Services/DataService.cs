namespace App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using App.Models;

    public class DataService : IDataService
    {
        /// <summary>
        /// Filter payloadDto
        /// </summary>
        /// <param name="payloadDto"></param>
        /// <returns></returns>
        public IEnumerable<PayloadItemShortDto> FilterPayload(PayloadDto payloadDto)
        {
            return from item in payloadDto.Payload
                   where item != null
                   && item.Drm.HasValue
                   && item.Drm == true
                   && item.EpisodeCount.HasValue
                   && item.EpisodeCount > 0
                   select new PayloadItemShortDto
                   {
                       Image = item.Image.ShowImage, 
                       Slug = item.Slug, 
                       Title = item.Title
                   };
        }

        /// <summary>
        /// Validate payloadDto
        /// </summary>
        /// <param name="payloadDto"></param>
        /// <returns></returns>
        public bool ValidatePayload(PayloadDto payloadDto)
        {
            return payloadDto != null && payloadDto.Payload != null;
        }
    }
}