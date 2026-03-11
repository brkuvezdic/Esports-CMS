using EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Teams
{
    public interface ITeamService
    {
        Task<List<TeamDto>> GetAllTeamsAsync();
        Task<List<TeamDto>> GetTeamsByCollegeIdAsync(int collegeId);
        Task<List<TeamDto>> GetTeamsForUserAsync(Guid userId);


    }
}
