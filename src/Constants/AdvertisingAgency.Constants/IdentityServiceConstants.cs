namespace AdvertisingAgency.Constants
{
    public static class IdentityServiceConstants
    {
        //User
        public const string queryGetUserById = "SELECT * FROM [User] WHERE Id = @id";
        public const string queryGetUserByEmail = "SELECT * FROM [User] WHERE Email = @email";
        public const string queryGetUserByUsername = "SELECT * FROM [User] WHERE Username = @username";
        public const string queryGetUserByEmailOrUsername = "SELECT * FROM [User] WHERE Username = @username OR Email = @email";
        public const string queryGetUserByUsernameAndEmail = "SELECT * FROM [User] WHERE Username = @username AND Email = @email";
        public const string queryGetUserByLoginRequest = "SELECT * FROM [User] WHERE Username = @usernameOfEmail OR Email = @usernameOfEmail";
        public const string queryInsertNewUser = "INSERT INTO [User] OUTPUT INSERTED.Id VALUES (@id ,@username, @birthday, @email, @passwordHash, @aboutInfo, NULL, NULL, @roleId)";
        public const string queryGetAllUserWithoutCurrUser = "SELECT * FROM [User] WHERE Id != @id";
        public const string queryGetUsernameByUserId = "SELECT Username FROM [User] WHERE Id = @userId";
        public const string queryDeleteUserByUsernameAndEmail = "DELETE FROM [User] WHERE Username = @username AND Email = @email";
        public const string queryUpdateRoleId = "UPDATE [User] SET RoleId = (SELECT Id FROM [Role] WHERE RoleName = @roleName), IsOldUser = 1 WHERE Id = @userId";

        //Role
        public const string queryGetRoleNameById = "SELECT RoleName FROM [Role] WHERE Id = @id";

        //RoleRequest
        public const string queryInsertNewRoleRequest = "INSERT INTO [RoleRequest] VALUES (@userId, @roleName, @numberOfPublications, @isOldUser)";
        public const string queryGetRoleRequestByUserId = "SELECT * FROM [RoleRequest] WHERE UserId = @userId";
        public const string queryGetAllRoleRequests = "SELECT * FROM [RoleRequest] WHERE UserId != @userId";
        public const string queryDeleteFromRoleRequestByUserId = "DELETE FROM [RoleRequest] WHERE UserId = @userId";
    }
}