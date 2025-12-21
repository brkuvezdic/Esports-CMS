using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Users;

namespace EsportsCmsApplication.Services
{
    public class UserService : IUsersService
    {

        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUsersRepository usersRepository, IMapper mapper)
        {
            _userRepository = usersRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> GetAllStudentsAsync()
        {
            var users = await _userRepository.GetAllStudentsAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
