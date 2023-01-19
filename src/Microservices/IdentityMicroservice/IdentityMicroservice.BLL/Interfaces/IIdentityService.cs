using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;

namespace IdentityMicroservice.BLL.Interfaces
{
    public interface IIdentityService
    {
        Task<LoginRegisterResponse> Login(LoginRequest loginRequest);
        Task<LoginRegisterResponse> Register(RegisterRequest registerRequest);
        Task<GetCurrentUserResponse> GetCurrentUser(GetCurrentUserRequest getCurrentUserRequest);
    }
}
