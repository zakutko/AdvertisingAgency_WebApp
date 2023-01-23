namespace AdvertisingAgency.Contracts.Responses
{
    public class GetAllRoleRequestResponse
    {
        public string Username { get; set; }
        public string RoleName { get; set; }
        public int NumberOfPublications { get; set; }
        public bool IsOldUser { get; set; }
    }
}
