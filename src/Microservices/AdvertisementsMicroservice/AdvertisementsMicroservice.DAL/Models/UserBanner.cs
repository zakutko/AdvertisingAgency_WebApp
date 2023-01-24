namespace AdvertisementsMicroservice.DAL.Models
{
    public class UserBanner
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid BannerId { get; set; }
    }
}
