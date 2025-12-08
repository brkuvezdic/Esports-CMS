using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsApplication.Interfaces.Sponsors;
using EsportsCmsDomain.EntitiesNew;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsInfrastructure
{
    public class SponsorRepository : ISponsorRepository
    {

            private readonly EsportsCmsContext _dbContext;

            public SponsorRepository(EsportsCmsContext dbContext)
            {
                this._dbContext = dbContext;
            }

            public Task<List<Sponsor>> GetAllSponsorsAsync()
            {
                return _dbContext.Sponsors.OrderBy(item => item.SponsorId).ToListAsync();

            }
    }
}

