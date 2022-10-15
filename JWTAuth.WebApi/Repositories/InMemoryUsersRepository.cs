using JWTAuth.WebApi.Interfaces;
using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Repositories
{
    public class InMemoryUsersRepository : IUsersRepository
    {
        private readonly IDictionary<Guid, User> _users = new Dictionary<Guid, User>();
        public IEnumerable<User> GetUsers()
        {
            return _users.Values;
        }

        public User GetUser(Guid id)
        {
            return _users[id];
        }

        public void AddUser(User user)
        {
            _users.Add(user.UserId, user);
        }

        public void RemoveUser(Guid id)
        {
            if (_users.ContainsKey(id))
            {
                _users.Remove(id);
            }
        }

        public void UpdateUser(Guid id, User user)
        {
            _users[id] = user;
        }
    }
}
