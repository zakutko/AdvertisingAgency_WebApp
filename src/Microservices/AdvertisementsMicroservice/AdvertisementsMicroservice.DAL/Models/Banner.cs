namespace AdvertisementsMicroservice.DAL.Models
{
    public class Banner
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public string LinkToBrowserPage { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int StatusId { get; set; }
        public string PhotoUrl { get; set; }
        public string Comment { get; set; }
    }
}
