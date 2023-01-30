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
        Task<MessageResponse> UpdateRoleByUserId(UpdateRoleRequest updateRoleRequest);
        Task<GetAllUsersResponse> GetAllUsersWithoutCurrUser(GetAllUsersRequest getAllUsersRequest);
        Task<GetAllRoleRequestsResponseList> GetAllRoleRequests(GetAllRoleRequestsRequest getAllRoleRequestsRequest);
        Task<MessageResponse> DeleteUser(DeleteUserRequest deleteUserRequest);
        Task<MessageResponse> RejectRoleRequest(RejectRoleRequest rejectRoleRequest);
        Task<MessageResponse> AcceptRoleRequest(AcceptRoleRequest acceptRoleRequest);
        Task<GetUsernameResponse> GetUsername(GetUsernameRequest getUsernameRequest);
    }
}