using EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Colleges
{
    public interface ICollegeRepository
    {
        Task<List<College>> GetAllCollegesAsync();

        Task<College?> GetCollegeByIdAsync(int id);
        Task ReorderCollegesAsync(List<ReorderCollegeDto> reordered);

        Task<bool> CollegeExistsAsync(string Title);
        Task<College> AddCollegeAsync(College college);
        Task<College> UpdateCollegeAsync(College college);
        Task<College> DeleteCollegeAsync(College college);

        Task<College> UpdateCollegeDescriptionAsync(int collegeId, string description);




        Task<List<College>> SearchCollegesByNameAsync(string Title);
        Task<List<College>> GetCollegesWithTeamsAsync();
        Task<College?> GetCollegeWithTeamsAsync(Guid id);
        Task<College?> GetCollegeWithStudentsAsync(Guid id);

    }
}
