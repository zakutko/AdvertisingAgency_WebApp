namespace AdvertisingAgency.Contracts.Responses
{
    public class GetAllBannersResponse
    {
        public List<BannerResponse> BannerList { get; set; } = new List<BannerResponse>();
    }
}
