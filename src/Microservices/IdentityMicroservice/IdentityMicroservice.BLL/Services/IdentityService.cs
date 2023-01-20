﻿using AdvertisingAgency.Contracts.Requests;
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
        private readonly IRoleRequestRepository _roleRequestRepository;

        public IdentityService(
            ITokenService tokenService, 
            IIdentityServiceHelper identityServiceHelper, 
            IUserRepository userRepository, 
            IRoleRepository roleRepository, 
            IRoleRequestRepository roleRequestRepository)
        {
            _tokenService = tokenService;
            _identityServiceHelper = identityServiceHelper;
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _roleRequestRepository = roleRequestRepository;
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
                registerRequest.Birthday,
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
                Age = _identityServiceHelper.GetAgeByBirthday(user.Birthday),
                Email = user.Email,
                AboutInfo = user.AboutInfo,
                NumberOfPublications = user.NumberOfPublications,
                IsOldUser = user.IsOldUser,
                RoleName = await _roleRepository.GetRoleNameById(user.RoleId),
            };
        }

        public async Task<IsExistReponse> IsUserExistByEmailOrUsername(IsExistByEmailOrUsernameRequest isExistByEmailRequest)
        {
            var user = await _userRepository.GetUserByLoginRequest(isExistByEmailRequest.RequestValue);

            if (user == null)
            {
                return new IsExistReponse { IsExist = false, ErrorMessage = null };
            }

            return new IsExistReponse { IsExist = true, ErrorMessage = null };
        }

        public async Task<UpdateRoleResponse> UpdateRoleByUserId(UpdateRoleRequest updateRoleRequest)
        {
            var userId = _identityServiceHelper.GetUserIdByDecodingJwtToken(updateRoleRequest.Token);
            var user = await _userRepository.GetUserById(userId);
            var numberOfPublications = 0;
            var isOldUser = false;

            var roleRequest = await _roleRequestRepository.GetRoleRequestByUserId(userId);
            if (roleRequest != null)
            {
                return new UpdateRoleResponse { Message = "You have already sent a request, please wait while it is being considered by the site administration" };
            }

            if (user.NumberOfPublications != null)
            {
                numberOfPublications = user.NumberOfPublications.Value;
            }
            if (user.IsOldUser != null)
            {
                isOldUser = user.IsOldUser.Value;
            }

            try
            {
                await _roleRequestRepository.InsertNewRoleRequest(userId, updateRoleRequest.RoleName, numberOfPublications, isOldUser);
                return new UpdateRoleResponse { Message = "Your request has been accepted to review." };
            }
            catch (Exception ex)
            {
                return new UpdateRoleResponse { Message = ex.Message };
            }
        }
    }
}