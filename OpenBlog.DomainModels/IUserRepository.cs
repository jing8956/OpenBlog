﻿using System.Threading.Tasks;

namespace OpenBlog.DomainModels
{
    public interface IUserRepository
    {
        Task<string> RegistReader(User user);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUser(string userId);
        Task<bool> IsSystemAdminInited();
        Task InitSystemAdminUser(string email, string passwordSalt, string passwordHash);
        Task<bool> ValidateLastChanged(string userId, string lastChangeToken);
        
    }
}
