using JWTAuth.WebApi.DTOs;
using JWTAuth.WebApi.Interfaces;
using JWTAuth.WebApi.Models;

namespace JWTAuth.WebApi.Services
{
    public class UsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;            
        }

        public Guid CreateUser(UserDTO userInfoDTO)
        {
            var newId = Guid.NewGuid();
            var user = new User(newId,
                userInfoDTO.DisplayName,
                userInfoDTO.UserName,
                userInfoDTO.Email,
                userInfoDTO.Password,
                userInfoDTO.CreatedDate);

            _usersRepository.AddUser(user);
            return newId;
        }

        public UserDTO GetUser(Guid id)
        {
            UserDTO userDTO = Map(_usersRepository.GetUser(id));
            return userDTO;
        }

        public List<UserDTO> GetUsers()
        {
            List<UserDTO> usersDTO = _usersRepository.GetUsers()
                .Select(x => Map(x))
                .ToList();
            return usersDTO;
        }

        public UserDTO GetUser(string email, string password)
        {
            List<User> users = _usersRepository.GetUsers().ToList();
            UserDTO? userDTO = users
                .Where(x => x.Email == email && x.Password == password)
                .Select(x => Map(x))
                .FirstOrDefault();

            return userDTO ?? new();
        }

        private static UserDTO Map(User user) => new()
        {
            UserId = user.UserId,
            DisplayName = user.DisplayName,
            UserName = user.UserName,
            Email = user.Email,
            Password = user.Password,
            CreatedDate = user.CreatedDate
        };
    }
}