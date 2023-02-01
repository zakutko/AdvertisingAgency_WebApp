namespace AdvertisingAgency.Contracts.Requests
{
    public class AddBannerRequest
    {
        public string UserId { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string LinkToBrowserPage { get; set; }
        public string ImageUrl { get; set; }
    }
}