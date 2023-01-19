namespace AdvertisingAgency.Constants
{
    public static class IdentityServiceConstants
    {
        //User
        public const string queryGetUserById = "SELECT * FROM [User] WHERE Id = @id";
        public const string queryGetUserByEmail = "SELECT * FROM [User] WHERE Email = @email";
        public const string queryGetUserByUsername = "SELECT * FROM [User] WHERE Username = @username";
        public const string queryGetUserByEmailOrUsername = "SELECT * FROM [User] WHERE Username = @username OR Email = @email";
        public const string queryGetUserByLoginRequest = "SELECT * FROM [User] WHERE Username = @usernameOfEmail OR Email = @usernameOfEmail";
        public const string queryInsertNewUser = "INSERT INTO [User] OUTPUT INSERTED.Id VALUES (@id ,@username, @birthday, @email, @passwordHash, @aboutInfo, NULL, NULL, @roleId)";

        //Role
        public const string queryGetRoleNameById = "SELECT RoleName FROM [Role] WHERE Id = @id";
    }
}
