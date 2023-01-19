namespace IdentityMicroservice.DAL.Interfaces
{
    public interface IRoleRepository
    {
        Task<string> GetRoleNameById(int id);
    }
}
