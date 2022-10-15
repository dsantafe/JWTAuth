using JWTAuth.WebApi.DTOs;
using JWTAuth.WebApi.Services;

namespace JWTAuth.WebApi.Data
{
    public class DataSeeder
    {
        public static void SeedUsers(UsersService usersService)
        {
            usersService.CreateUser(new UserDTO
            {
                UserId = Guid.NewGuid(),
                DisplayName = "admin",
                UserName = "Admin",
                Email = "admin@gmail.com",
                Password = "123456",
                CreatedDate = DateTime.Now,
            });
        }
    }
}
