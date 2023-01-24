namespace AdvertisingAgency.Constants
{
    public static class AdvertisementsServiceConstants
    {
        //Banner
        public const string queryGetAllBanners = "SELECT * FROM [Banner]";
        public const string queryGetBannerById = "SELECT * FROM [Banner] WHERE Id = @id";
        public const string queryAddbannerAdnReturnBannerId = "" +
            "INSERT INTO [Banner] (Title, SubTitle, Description, LinkToBrowserPage, ReleaseDate, StatusId, PhotoUrl) " +
            "OUTPUT INSERTED.Id VALUES(@title, @subtitle, @description, @linkToBrowserPage, NULL, 1, @photoUrl)";

        //UserBanner
        public const string queryGetAllUserBanners = "SELECT * FROM [UserBanner]";
        public const string queryAddUserBanner = "INSERT INTO [UserBanner] (UserId, BannerId) VALUES (@userId, @bannerId)";

        //Status
        public const string queryGetStatusNameById = "SELECT (StatusName) FROM [Status] WHERE Id = @id";
    }
}
