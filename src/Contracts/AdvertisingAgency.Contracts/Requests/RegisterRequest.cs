namespace AdvertisingAgency.Contracts.Requests
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }
        public string AboutInfo { get; set; }
        public string Password { get; set; }
    }
}
