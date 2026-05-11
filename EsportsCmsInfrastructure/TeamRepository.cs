using EsportsCmsApplication.Interfaces.Teams;
using EsportsCmsDomain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsInfrastructure
{
    public class TeamRepository : ITeamRepository
    {
        private readonly EsportsCmsContext _dbContext;

        public TeamRepository(EsportsCmsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Team>> GetAllTeamsAsync()
        {
            return _dbContext.Teams
                .Include(t => t.Game)
                .ToListAsync();
        }
        public Task<List<Team>> GetTeamsByCollegeIdAsync(int collegeId)
        {
            return _dbContext.Teams
                .Include(t => t.Game)
                .Where(t => t.CollegeId == collegeId)
                .ToListAsync();
        }

    }
}
