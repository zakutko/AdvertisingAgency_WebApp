﻿using IdentityMicroservice.DAL.Models;

namespace IdentityMicroservice.DAL.Interfaces
{
    public interface IRoleRequestRepository
    {
        Task<RoleRequest> GetRoleRequestByUserId(string userId);
        Task InsertNewRoleRequest(string userId, string roleName, int numberOfPublications, bool isOldUser);
        Task<IEnumerable<RoleRequest>> GetAllRoleRequests(string userId);
        Task DeleteRoleRequestWhereUserId(string userId);
    }
}
