namespace App.Services
{
    using System.Collections.Generic;

    using App.Models;

    public interface IDataService
    {
        IEnumerable<PayloadItemShortDto> FilterPayload(PayloadDto payloadDto);

        bool ValidatePayload(PayloadDto payloadDto);
    }
}
