using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;

namespace IdentityMicroservice.BLL.Interfaces
{
    public interface IIdentityService
    {
        Task<LoginRegisterResponse> Login(LoginRequest loginRequest);
        Task<LoginRegisterResponse> Register(RegisterRequest registerRequest);
        Task<GetCurrentUserResponse> GetCurrentUser(GetCurrentUserRequest getCurrentUserRequest);
        Task<IsExistReponse> IsUserExistByEmailOrUsername(IsExistByEmailOrUsernameRequest isExistByEmailRequest);
        Task<UpdateRoleResponse> UpdateRoleByUserId(UpdateRoleRequest updateRoleRequest);
        Task<GetAllUsersResponse> GetAllUsersWithoutCurrUser(GetAllUsersRequest getAllUsersRequest);
        Task<GetAllRoleRequestsResponseList> GetAllRoleRequests(GetAllRoleRequestsRequest getAllRoleRequestsRequest);
        Task<DeleteUserResponse> DeleteUser(DeleteUserRequest deleteUserRequest);
    }
}