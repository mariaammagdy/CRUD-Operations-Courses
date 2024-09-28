using STDem0.Data;
using STDem0.Models;

namespace STDem0.Repository
{
	public class UserRepo : IUserRepo
	{
		ITIContext db;
		public UserRepo(ITIContext _db)
		{
			db = _db;
		}
		public void Add(User user)
		{
			db.Add(user);
			db.SaveChanges();
		}

		public List<User> GetAll()
		{
			return db.Users.ToList();
		}

		public User GetUserByCredentials(string username, string password)
		{
			return db.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
		}
	}
}
