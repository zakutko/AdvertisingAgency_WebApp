namespace AdvertisingAgency.Constants
{
    public static class AdvertisementsServiceConstants
    {
        //Banner
        public const string queryGetAllBanners = "SELECT * FROM [Banner]";
        public const string queryGetBannerById = "SELECT * FROM [Banner] WHERE Id = @id";

        //UserBanner
        public const string queryGetAllUserBanners = "SELECT * FROM [UserBanners]";
    }
}
