using CustomerTrackingAppReact.Entities;
using CustomerTrackingAppReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Persistence
{
    public interface IUserRepository
    {
        void Insert(User user);
        UserModel GetById(int id);
        IEnumerable<UserModel> GetAll();
        int GetUserIdByLogin(string username, string password);
    }
}
