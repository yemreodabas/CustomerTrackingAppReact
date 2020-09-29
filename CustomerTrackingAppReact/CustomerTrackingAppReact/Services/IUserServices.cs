using CustomerTrackingAppReact.Entities;
using CustomerTrackingAppReact.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Services
{
    public interface IUserService
    {
        void AddNewUser(User user);
        List<UserModel> GetAllUsers();
        UserModel GetById(int id);
        UserModel GetOnlineUser(HttpContext httpContext);
        void Logout(HttpContext httpContext);
        bool TryLogin(UserLoginModel loginData, HttpContext httpContext);
    }
}
