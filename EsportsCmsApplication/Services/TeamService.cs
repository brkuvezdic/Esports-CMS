using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Teams;
using EsportsCmsApplication.Interfaces.Users;

namespace EsportsCmsApplication.Services
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;
        private readonly IUsersRepository _userRepository;

        public TeamService(ITeamRepository teamRepository, IMapper mapper, IUsersRepository userRepository)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<List<TeamDto>> GetAllTeamsAsync()
        {
            var teams = await _teamRepository.GetAllTeamsAsync();
            return _mapper.Map<List<TeamDto>>(teams);
        }

        public async Task<List<TeamDto>> GetTeamsByCollegeIdAsync(int collegeId)
        {
            var teams = await _teamRepository.GetTeamsByCollegeIdAsync(collegeId);
            return _mapper.Map<List<TeamDto>>(teams);
        }

        public async Task<List<TeamDto>> GetTeamsForUserAsync(Guid userId)
        {
            var user = await _userRepository.GetUserByIdAsync(userId);

            if (user == null || user.CollegeId == null)
                return new List<TeamDto>();

            var teams = await _teamRepository.GetTeamsByCollegeIdAsync(user.CollegeId.Value);

            return _mapper.Map<List<TeamDto>>(teams);
        }
    }
}