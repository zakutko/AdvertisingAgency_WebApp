namespace AdvertisingAgency.Contracts.Responses
{
    public class GetCurrentUserResponse
    {
        public string? Username { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? AboutInfo { get; set; }
        public int? NumberOfPublications { get; set; }
        public bool? IsOldUser { get; set; }
        public string? RoleName { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
