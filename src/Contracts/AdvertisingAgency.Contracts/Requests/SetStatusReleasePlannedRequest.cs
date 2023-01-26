namespace AdvertisingAgency.Contracts.Requests
{
    public class SetStatusReleasePlannedRequest
    {
        public string BannerId { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
