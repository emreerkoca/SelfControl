using Self.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Self.Core.Interfaces
{
    public interface IUserRepository
    {
        User AddNewUser(User user);
        User Authenticate(string username, string password);
    }
}
