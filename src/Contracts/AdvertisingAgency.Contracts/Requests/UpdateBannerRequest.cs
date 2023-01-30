namespace AdvertisingAgency.Contracts.Requests
{
    public class UpdateBannerRequest
    {
        public string BannerId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string LinkToBrowserPage { get; set; }
        public string PhotoUrl { get; set; }
    }
}