namespace AdvertisingAgency.Constants
{
    public static class AdvertisementsServiceConstants
    {
        //Banner
        public const string queryGetAllBanners = "SELECT * FROM [Banner]";
        public const string queryGetBannerById = "SELECT * FROM [Banner] WHERE Id = @id";
        public const string queryGetBannerByIdWhereStatusRelease = "SELECT * FROM [Banner] WHERE Id = @id AND StatusId = 6";
        public const string queryGetBannerByIdWhereStatusReleasePlanned = "SELECT * FROM [Banner] WHERE Id = @id AND StatusId = 5";
        public const string queryGetBannerByIdAndStatusInQueueToCheck = "SELECT * FROM[Banner] WHERE Id = @id AND StatusId = 2";
        public const string queryGetBannerByIdAndStatusCheckSuccessful = "SELECT * FROM[Banner] WHERE Id = @id AND StatusId = 3";
        public const string queryGetBannerByIdAnyStatus = "SELECT * FROM [Banner] WHERE Id = @id";
        public const string queryAddbannerAdnReturnBannerId = "" +
            "INSERT INTO [Banner] (Title, SubTitle, Description, LinkToBrowserPage, StatusId, PhotoUrl) " +
            "OUTPUT INSERTED.Id " +
            "VALUES(@title, @subtitle, @description, @linkToBrowserPage, 1, @photoUrl)";
        public const string queryUpdateBannerAddToQueueToCheck = "UPDATE [Banner] SET StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'InQueueToCheck') WHERE Id = @bannerId";
        public const string querySetStatusCheckSuccessful = "UPDATE [Banner] SET StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'CheckSuccessful') WHERE Id = @bannerId";
        public const string querySetStatusReleased = "" +
            "UPDATE [Banner] SET StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'Released'), ReleaseDate = @releaseDate " +
            "WHERE Id = @bannerId";
        public const string querySetStatusCheckNotSuccessful = "UPDATE [Banner] " +
            "SET StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'CheckNotSuccessful'), Comment = @comment " +
            "WHERE Id = @bannerId";
        public const string querySetStatusReleasePlanned = "UPDATE [Banner] SET StatusId = " +
            "(SELECT Id FROM [Status] WHERE StatusName = 'ReleasePlanned'), ReleaseDate = @releaseDate WHERE Id = @bannerId";
        public const string queryUpdateBannerById = "UPDATE [Banner] " +
            "SET Title = @title, SubTitle = @subTitle, Description = @description, LinkToBrowserPage = @linkToBrowserPage, PhotoUrl = @photoUrl, " +
            "StatusId = (SELECT Id FROM [Status] WHERE StatusName = 'InQueueToCheck'), Comment = NULL " +
            "WHERE Id = @bannerId";

        //UserBanner
        public const string queryGetAllUserBanners = "SELECT * FROM [UserBanner]";
        public const string queryGetAllUserBannersByUserId = "SELECT * FROM [UserBanner] WHERE UserId = @userId";
        public const string queryAddUserBanner = "INSERT INTO [UserBanner] (UserId, BannerId) VALUES (@userId, @bannerId)";
        public const string queryDeleteUserBanner = "DELETE FROM [UserBanner] WHERE UserId = @userId AND BannerId = @bannerId";

        //Status
        public const string queryGetStatusNameById = "SELECT (StatusName) FROM [Status] WHERE Id = @id";
    }
}