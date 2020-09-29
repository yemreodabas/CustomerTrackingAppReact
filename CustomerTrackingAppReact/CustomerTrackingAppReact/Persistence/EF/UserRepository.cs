using CustomerTrackingAppReact.Entities;
using CustomerTrackingAppReact.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerTrackingAppReact.Persistence.EF
{
	public class UserRepository : BaseRepository, IUserRepository
	{
		public void Insert(User user)
		{
			using (SQLiteDBContext dbConnection = this.OpenConnection())
			{
				dbConnection.User.Add(user);
				dbConnection.SaveChanges();
			}
		}

		public IEnumerable<UserModel> GetAll()
		{
			using (SQLiteDBContext dbConnection = this.OpenConnection())
			{
				var users = dbConnection.User.ToList();
				return users.Select(u => new UserModel(u)).ToList();
			}
		}

		public UserModel GetById(int id)
		{
			using (SQLiteDBContext dbConnection = this.OpenConnection())
			{
				var user = dbConnection.User.Where(u => u.Id == id).FirstOrDefault();
				return user == null ? null : new UserModel(user);
			}
		}

		public int GetUserIdByLogin(string username, string password)
		{
			using (SQLiteDBContext dbConnection = this.OpenConnection())
			{
				var userId = dbConnection.User.Where(u => u.Username == username && u.Password == password).Select(u => u.Id).FirstOrDefault();
				return userId;
			}
		}
	}
}
