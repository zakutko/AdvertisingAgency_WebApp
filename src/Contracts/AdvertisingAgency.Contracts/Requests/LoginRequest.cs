﻿namespace AdvertisingAgency.Contracts.Requests
{
    public class LoginRequest
    {
        public string? UsernameOrEmail { get; set; }
        public string? Password { get; set; }
    }
}
