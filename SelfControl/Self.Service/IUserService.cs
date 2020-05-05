using Self.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Service
{
    public interface IUserService
    {
        Task<User> AddUser(User user);
        User Authenticate(string userName, string password);
    }
}
