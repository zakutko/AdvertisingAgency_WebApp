namespace AdvertisingAgency.Constants
{
    public static class AdvertisementsServiceConstants
    {
        //Banner
        public const string queryGetAllBanners = "SELECT * FROM [Banner]";
        public const string queryGetBannerById = "SELECT * FROM [Banner] WHERE Id = @id AND StatusId = 6";
        public const string queryGetBannerByIdAnyStatus = "SELECT * FROM [Banner] WHERE Id = @id";
        public const string queryAddbannerAdnReturnBannerId = "" +
            "INSERT INTO [Banner] (Title, SubTitle, Description, LinkToBrowserPage, ReleaseDate, StatusId, PhotoUrl) " +
            "OUTPUT INSERTED.Id VALUES(@title, @subtitle, @description, @linkToBrowserPage, NULL, 2, @photoUrl)";

        //UserBanner
        public const string queryGetAllUserBanners = "SELECT * FROM [UserBanner]";
        public const string queryGetAllUserBannersByUserId = "SELECT * FROM [UserBanner] WHERE UserId = @userId";
        public const string queryAddUserBanner = "INSERT INTO [UserBanner] (UserId, BannerId) VALUES (@userId, @bannerId)";

        //Status
        public const string queryGetStatusNameById = "SELECT (StatusName) FROM [Status] WHERE Id = @id";
    }
}
