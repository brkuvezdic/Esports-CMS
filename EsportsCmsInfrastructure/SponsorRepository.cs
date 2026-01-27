using EsportsCmsApplication.DTOs;
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

        public async Task<SponsorDto> CreateSponsorAsync(CreateSponsorDto dto)
        {
            var sponsor = new Sponsor
            {
                SponsorId = dto.SponsorId,
                Title = dto.Title,
                Description = dto.Description,
                SponsorTier = dto.SponsorTier
            };

            _dbContext.Sponsors.Add(sponsor);
            await _dbContext.SaveChangesAsync();

            // Map manually to DTO
            return new SponsorDto
            {
                SponsorId = sponsor.SponsorId,
                Title = sponsor.Title,
                Description = sponsor.Description,
                SponsorTier = sponsor.SponsorTier
            };
        }

        public Task<List<Sponsor>> GetAllSponsorsAsync()
            {
                return _dbContext.Sponsors.OrderBy(item => item.SponsorId).ToListAsync();

            }
    }
}

