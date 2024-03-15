using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
            var userExist = _context.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
            if (userExist == null)
            {
                throw new Exception("Incorrect e-mail or password");
            }
            return new UserDto
            {
                UserId = userExist.UserId,
                Name = userExist.Name,
                Email = userExist.Email,
                UserType = userExist.UserType
            };
        }
        public UserDto Add(UserDtoInsert user)
        {
            if (_context.Users.FirstOrDefault(u => u.Email == user.Email) != null)
            {
                throw new Exception("User email already exists");
            }
            var newUser = new User
            {
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                UserType = "client",
            };
            var userResponse = _context.Users.Add(newUser);
            _context.SaveChanges();
            return new UserDto
            {
                UserId = userResponse.Entity.UserId,
                Name = newUser.Name,
                Email = newUser.Email,
                UserType = newUser.UserType,
            };

        }

        public UserDto GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            throw new NotImplementedException();
        }

    }
}