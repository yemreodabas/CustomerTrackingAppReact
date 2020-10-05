using CustomerTrackingAppReact.Entities;
using CustomerTrackingAppReact.Models;
using CustomerTrackingAppReact.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Controllers
{
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		private static readonly List<string> Users = new List<string>()
		{
			"Oguz", "Mete"
		};

		private readonly ILogger<WeatherForecastController> _logger;


		public UserController(ILogger<WeatherForecastController> logger, IUserService userService)
		{
			_logger = logger;
			_userService = userService;
		}

		[HttpPost]
		public IEnumerable<string> AddUser(UserModel newUser)
		{
			Users.Add(newUser.Username);

			return Users.ToArray();
		}

		[HttpGet]
		public IEnumerable<string> GetUsers()
		{
			return Users.ToArray();
		}

		[HttpPost]
		public ApiResponse Login([FromBody] UserLoginModel model)
		{
			try
			{
				var onlineUser = this._userService.GetOnlineUser(this.HttpContext);

				if (onlineUser != null)
				{
					return ApiResponse.WithError("There is currently an open account!");
				}

				if (!this._userService.TryLogin(model, this.HttpContext))
				{
					return ApiResponse.WithError("Invalid Username or Password!");
				}

				return ApiResponse.WithSuccess();
			}
			catch (Exception exp)
			{
				return ApiResponse.WithError(exp.ToString());
			}
		}

		[HttpPost]
		public ApiResponse Logout([FromBody] UserLoginModel model)
		{
			try
			{
				this._userService.Logout(this.HttpContext);

				return ApiResponse.WithSuccess();
			}
			catch (Exception exp)
			{
				return ApiResponse.WithError(exp.ToString());
			}
		}

		[HttpPost]
		public ApiResponse GetOnlineUser([FromBody] UserLoginModel model)
		{
			try
			{
				var onlineUser = this._userService.GetOnlineUser(this.HttpContext);

				return ApiResponse.WithSuccess();
			}
			catch (Exception exp)
			{
				return ApiResponse.WithError(exp.ToString());
			}
		}
	}
}
