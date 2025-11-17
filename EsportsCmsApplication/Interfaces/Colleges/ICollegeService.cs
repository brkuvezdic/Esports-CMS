using EsportsCmsApplication.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Colleges
{
    public interface ICollegeService
    {
        Task<List<CollegeDto>> GetAllCollegesAsync();

        Task<CollegeDto?> GetCollegeByIdAsync(int id);

        Task<CollegeDto> CreateCollegeAsync(CreateCollegeDto createDto);

        Task<CollegeDto> UpdateCollegeAsync(UpdateCollegeDto updateDto);

        Task<CollegeDto> UpdateCollegeDescriptionAsync(UpdateCollegeDescriptionDto updateDto);

        Task<bool> DeleteCollegeAsync(int id);
    }
}
