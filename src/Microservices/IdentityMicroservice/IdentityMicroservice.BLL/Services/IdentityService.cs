using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using IdentityMicroservice.BLL.Interfaces;
using IdentityMicroservice.DAL.Interfaces;

namespace IdentityMicroservice.BLL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ITokenService _tokenService;
        private readonly IIdentityServiceHelper _identityServiceHelper;
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public IdentityService(ITokenService tokenService, IIdentityServiceHelper identityServiceHelper, IUserRepository userRepository, IRoleRepository roleRepository)
        {
            _tokenService = tokenService;
            _identityServiceHelper = identityServiceHelper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
        }

        public async Task<LoginRegisterResponse> Login(LoginRequest loginRequest)
        {
            var user = await _userRepository.GetUserByLoginRequest(loginRequest.UsernameOrEmail);

            if (user == null)
            {
                throw new Exception("User does not exist.");
            }

            var passwordHash = _identityServiceHelper.HashPassword(loginRequest.Password);
            if (user.PasswordHash != passwordHash)
            {
                throw new Exception("Incorrect password.");
            }

            return new LoginRegisterResponse
            {
                Token = _tokenService.CreateToken(user)
            };
        }

        public async Task<LoginRegisterResponse> Register(RegisterRequest registerRequest)
        {
            var user = await _userRepository.GetUserByEmailOrUsername(registerRequest.Username, registerRequest.Email);

            if (user != null)
            {
                throw new Exception("Username or email already taken!");
            }

            var newUser = await _userRepository.InsertNewUser(
                Guid.NewGuid(),
                registerRequest.Username,
                registerRequest.Age,
                registerRequest.Email,
                _identityServiceHelper.HashPassword(registerRequest.Password),
                registerRequest.AboutInfo,
                1);

            return new LoginRegisterResponse
            {
                Token = _tokenService.CreateToken(newUser)
            };
        }

        public async Task<GetCurrentUserResponse> GetCurrentUser(GetCurrentUserRequest getCurrentUserRequest)
        {
            var username = _identityServiceHelper.GetUsernameByDecodingJwtToken(getCurrentUserRequest.Token);

            var user = await _userRepository.GetUserByUsername(username);

            return new GetCurrentUserResponse
            {
                Username = user.Username,
                Age = user.Age,
                Email = user.Email,
                AboutInfo = user.AboutInfo,
                NumberOfPublications = user.NumberOfPublications,
                IsOldUser = user.IsOldUser,
                RoleName = await _roleRepository.GetRoleNameById(user.RoleId),
            };
        }
    }
}
