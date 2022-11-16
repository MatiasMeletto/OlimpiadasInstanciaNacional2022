﻿using CodeBluCore;

namespace CodeBluMovil.Services
{
    public interface ILoginService
    {
        UserDTO User { get; }
        Task SendLogAsync(UserDTO user);
        Task<bool> GetAuthAsync();
    }
}