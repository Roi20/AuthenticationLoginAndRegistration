﻿namespace AuthenticationLoginAndRegistration.Services
{
    public interface IEmailService
    {
        Task Send(string email, string subject, string body);
    }
}
