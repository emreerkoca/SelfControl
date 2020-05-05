using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Self.Core.Entities;
using Self.Core.Interfaces;
using Self.Infrastructure.Data;

namespace Self.Service
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;
        private IUserRepository _userRepository;

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            this._unitOfWork = unitOfWork as UnitOfWork;
            this._userRepository = userRepository;
        }

        public async Task<User> AddUser(User user)
        {
            User savedUser = _unitOfWork.UserRepository.AddNewUser(user);

            await _unitOfWork.CommitAsync();

            return savedUser;
        }

        public User Authenticate(string userName, string password)
        {
            User user = _userRepository.Authenticate(userName, password);

            return user;
        }
    }
}
