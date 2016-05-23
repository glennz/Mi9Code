namespace Mi9Test
{
    using System;
    using System.IO;

    using App.Models;

    using Newtonsoft.Json;

    public class DataProvider
    {
        private readonly string dir;

        public DataProvider()
        {
            dir = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
        }

        private string loadPayloadFromFile(string fileName)
        {
            var path = string.Format("{0}\\{1}", dir, fileName);
            return File.ReadAllText(path);
        }

        public PayloadDto PayloadData()
        {
            var payloadString = loadPayloadFromFile("payload.json");
            payloadString = payloadString.Replace("\r\n", "");
            var payload = JsonConvert.DeserializeObject<PayloadDto>(payloadString);
            return payload;
        }

        public PayloadResponseDto PayloadResponseData()
        {
            var payloadString = loadPayloadFromFile("result.json");
            payloadString = payloadString.Replace("\r\n", "");
            var payload = JsonConvert.DeserializeObject<PayloadResponseDto>(payloadString);
            return payload;
        }
    }
}
