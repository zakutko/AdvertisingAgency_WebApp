﻿using AdvertisingAgency.Contracts.Requests;
using AdvertisingAgency.Contracts.Responses;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace AdvertisingAgency.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IdentityController : ControllerBase
    {
        private readonly IBus _bus;

        public IdentityController(IBus bus)
        {
            _bus = bus;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginRegisterResponse>> Login(LoginRequest loginRequest)
        {
            try
            {
                var response = await _bus.Request<LoginRequest, LoginRegisterResponse>(loginRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginRegisterResponse>> Register(RegisterRequest registerRequest)
        {
            try
            {
                var response = await _bus.Request<RegisterRequest, LoginRegisterResponse>(registerRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("currentUser")]
        public async Task<ActionResult<GetCurrentUserResponse>> GetCurrentUser(string token)
        {
            try
            {
                var getCurrUserRequest = new GetCurrentUserRequest { Token = token };
                var response = await _bus.Request<GetCurrentUserRequest, GetCurrentUserResponse>(getCurrUserRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("isExistByEmail")]
        public async Task<ActionResult<IsExistReponse>> IsExistByEmailOrUsername(string requestValue)
        {
            try
            {
                var request = new IsExistByEmailOrUsernameRequest { RequestValue = requestValue };
                var response = await _bus.Request<IsExistByEmailOrUsernameRequest, IsExistReponse>(request);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("updateRole")]
        public async Task<ActionResult<MessageResponse>> AddNewRoleRequest(UpdateRoleRequest updateRoleRequest)
        {
            try
            {
                var response = await _bus.Request<UpdateRoleRequest, MessageResponse>(updateRoleRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllUsers")]
        public async Task<ActionResult<GetAllUsersResponse>> GetAllUsers(string token)
        {
            try
            {
                var getAllUsersRequest = new GetAllUsersRequest { Token = token };
                var response = await _bus.Request<GetAllUsersRequest, GetAllUsersResponse>(getAllUsersRequest);
                return Ok(response.Message.UsersList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getAllRoleRequests")]
        public async Task<ActionResult<GetAllRoleRequestsResponseList>> GetAllRoleRequests(string token)
        {
            try
            {
                var getAllRoleRequestsRequest = new GetAllRoleRequestsRequest { Token = token };
                var response = await _bus.Request<GetAllRoleRequestsRequest, GetAllRoleRequestsResponseList>(getAllRoleRequestsRequest);
                return Ok(response.Message.AllRoleRequestResponses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("deleteUserByUsernameAndEmail")]
        public async Task<ActionResult<MessageResponse>> DeleteUser(string username, string email)
        {
            try
            {
                var deleteUserRequest = new DeleteUserRequest
                {
                    Username = username,
                    Email = email
                };
                var response = await _bus.Request<DeleteUserRequest, MessageResponse>(deleteUserRequest);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("rejectRoleRequest")]
        public async Task<ActionResult<MessageResponse>> RejectRoleRequest(string userId)
        {
            try
            {
                var request = new RejectRoleRequest { UserId = userId };
                var response = await _bus.Request<RejectRoleRequest, MessageResponse>(request);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("acceptRoleRequest")]
        public async Task<ActionResult<MessageResponse>> AcceptRoleRequest(string userId)
        {
            try
            {
                var request = new AcceptRoleRequest { UserId = userId };
                var response = await _bus.Request<AcceptRoleRequest, MessageResponse>(request);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("getUsername")]
        public async Task<ActionResult<GetUsernameResponse>> GetUsername(string userId)
        {
            try
            {
                var request = new GetUsernameRequest { UserId = userId };
                var response = await _bus.Request<GetUsernameRequest, GetUsernameResponse>(request);
                return Ok(response.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}