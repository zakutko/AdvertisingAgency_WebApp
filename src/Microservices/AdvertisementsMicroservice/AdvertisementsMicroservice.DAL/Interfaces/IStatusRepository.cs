namespace AdvertisementsMicroservice.DAL.Interfaces
{
    public interface IStatusRepository
    {
        Task<string> GetStatusNameById(int id);
    }
}
