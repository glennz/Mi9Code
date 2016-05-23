using System.Collections.Generic;
namespace App.Models
{
    public class PayloadDto
    {
        public IEnumerable<PayloadItemDto> Payload { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int TotalRecords { get; set; }
    }
}