using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsDomain.EntitiesNew;

namespace EsportsCmsApplication.Services
{
    public class CollegeService : ICollegeService
    {
        private readonly ICollegeRepository _collegeRepository;
        private readonly IMapper _mapper;

        public CollegeService(ICollegeRepository collegeRepository, IMapper mapper)
        {
            _collegeRepository = collegeRepository;
            _mapper = mapper;
        }

        public async Task<List<CollegeDto>> GetAllCollegesAsync()
        {
            var colleges = await _collegeRepository.GetAllCollegesAsync();
            return _mapper.Map<List<CollegeDto>>(colleges);
        }

        public async Task<CollegeDto> GetCollegeByIdAsync(int id)
        {
            var college = await _collegeRepository.GetCollegeByIdAsync(id);
            if (college == null)
                throw new KeyNotFoundException($"College with ID {id} not found.");

            return _mapper.Map<CollegeDto>(college);
        }

        public async Task<CollegeDto> CreateCollegeAsync(CreateCollegeDto createDto)
        {
           
            var college = _mapper.Map<College>(createDto);
            college.CreatedBy = 1; // temp hardcoded value for now!
            college.CreatedOn = DateTime.UtcNow;

            var createdCollege = await _collegeRepository.AddCollegeAsync(college);
            return _mapper.Map<CollegeDto>(createdCollege);
        }

        public async Task<CollegeDto> UpdateCollegeAsync(UpdateCollegeDto updateDto)
        {
            var existingCollege = await _collegeRepository.GetCollegeByIdAsync(updateDto.Id);
            if (existingCollege == null)
                throw new KeyNotFoundException($"College with ID {updateDto.Id} not found.");

            var college = _mapper.Map(updateDto, existingCollege); // maps updateDto onto existingCollege
            var updatedCollege = await _collegeRepository.UpdateCollegeAsync(college);

            return _mapper.Map<CollegeDto>(updatedCollege);
        }

        public async Task<CollegeDto> UpdateCollegeDescriptionAsync(UpdateCollegeDescriptionDto updateDto)
        {
            var updatedCollege = await _collegeRepository.UpdateCollegeDescriptionAsync(updateDto.Id, updateDto.Description);
            if (updatedCollege == null)
                throw new KeyNotFoundException($"College with ID {updateDto.Id} not found.");

            return _mapper.Map<CollegeDto>(updatedCollege);
        }

        public async Task<bool> DeleteCollegeAsync(int id)
        {
            var college = await _collegeRepository.GetCollegeByIdAsync(id);
            if (college == null)
                return false;

            await _collegeRepository.DeleteCollegeAsync(college);
            return true;
        }

    }
}
