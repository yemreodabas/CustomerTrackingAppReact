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
	[ApiController]
	[Route("api/User")]
	public class UserApiController : ControllerBase
	{
		private static readonly List<string> Users = new List<string>()
		{
			"Oguz", "Mete"
		};

		private readonly ILogger<WeatherForecastController> _logger;

		public UserApiController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		[Route("AddUser")]
		public IEnumerable<string> AddUser(UserModel newUser)
		{
			Users.Add(newUser.Username);

			return Users.ToArray();
		}

		[HttpGet]
		[Route("GetUsers")]
		public IEnumerable<string> GetUsers()
		{
			return Users.ToArray();
		}
	}
}
