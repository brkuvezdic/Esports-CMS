using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Sponsors;
using EsportsCmsDomain.EntitiesNew;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Services
{
    public class SponsorService : ISponsorService
    {
        private readonly ISponsorRepository _sponsorRepository;

        public SponsorService(ISponsorRepository sponsorRepository)
        {
            _sponsorRepository = sponsorRepository;
        }

        public async Task<List<SponsorDto>> GetAllSponsorsAsync()
        {
            var sponsors = await _sponsorRepository.GetAllSponsorsAsync();

            var sponsorDtos = sponsors.Select(s => new SponsorDto
            {
                SponsorId = s.SponsorId,
                Title = s.Title,
                Description = s.Description,
                SponsorTier = s.SponsorTier
            }).ToList();

            return sponsorDtos;
        }

        public async Task<SponsorDto> CreateSponsorAsync(CreateSponsorDto dto)
        {
            // Call repository, repository returns DTO
            var created = await _sponsorRepository.CreateSponsorAsync(dto);
            return created;
        }
    }
}
