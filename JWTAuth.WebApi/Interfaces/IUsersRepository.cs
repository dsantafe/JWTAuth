using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Interfaces
{
    public interface IUsersRepository
    {
        IEnumerable<User> GetUsers();
        User GetUser(Guid id);
        void AddUser(User user);
        void RemoveUser(Guid id);
        void UpdateUser(Guid id, User user);
    }
}
