using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsApplication.Interfaces.Users;
using Microsoft.EntityFrameworkCore;

namespace EsportsCmsApplication.Services
{
    public class UserService : IUsersService
    {

        private readonly IUsersRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly ICollegeRepository _collegeRepository;

        public UserService(IUsersRepository usersRepository, IMapper mapper, ICollegeRepository collegeRepository)
        {
            _userRepository = usersRepository;
            _mapper = mapper;
            _collegeRepository = collegeRepository;
        }

        public async Task<bool> AssignStudentToCollegeAsync(AssignUserToCollegeDto dto)
        {
            // check college exists
            var college = await _collegeRepository.GetCollegeByIdAsync(dto.CollegeId);
            if (college == null)
                return false;

            // assign user
            return await _userRepository.AssignStudentToCollegeAsync(
                dto.UserId,
                dto.CollegeId
            );
        }



        public async Task<List<UserDto>> GetAllStudentsAsync()
        {
            var users = await _userRepository.GetAllStudentsAsync();
            var orderedUsers = users
                .OrderByDescending(x => x.Role)
                .ToList();

            return _mapper.Map<List<UserDto>>(orderedUsers);
        }

        public async Task<bool> RemoveStudentFromCollegeAsync(RemoveUserFromCollegeDto dto)
        {
            return await _userRepository.RemoveStudentFromCollegeAsync(dto.UserId);
        }
    }
}
