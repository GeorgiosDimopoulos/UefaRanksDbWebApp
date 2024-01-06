using static UefaRankingApplication.Data.Models.Utility.StartingDetails;

namespace UefaRankingApplication.Data.Models.Dtos
{
    // common endpoint's response for all of APIs
    public class RequestDto
    {
        public object Data { get; set; }
        public string Url { get; set; }
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string AccessToken { get; set; }
    }
}
