using Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetOneUser(int id);
        Task<User> CreateUser(User user);
        Task<User> UpdateUser(User user);
        Task<User> DeleteUser(int id);      
        Task<User> AuthenticateLogin(User user);
        Task<bool> CheckUsernameExist(string username);
        Task<bool> ChechEmailExist(string email);

    }
}
