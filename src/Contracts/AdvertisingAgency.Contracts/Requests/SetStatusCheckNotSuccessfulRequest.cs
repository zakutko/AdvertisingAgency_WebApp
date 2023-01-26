namespace AdvertisingAgency.Contracts.Requests
{
    public class SetStatusCheckNotSuccessfulRequest
    {
        public string BannerId { get; set; }
        public string Comment { get; set; }
    }
}