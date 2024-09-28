using STDem0.Models;

namespace STDem0.Repository
{
	public interface IUserRepo
	{
		public List<User> GetAll();
		public User GetUserByCredentials(string username, string password);
        public void Add(User user);
	}
}
