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

            // Map tiers to numeric values for ordering
            var tierOrder = new Dictionary<string, int>
                    {
                        { "Diamond", 1 },
                        { "Platinum", 2 },
                        { "Gold", 3 },
                        { "Silver", 4 }
                    };

            var sponsorDtos = sponsors
                .Select(s => new SponsorDto
                {
                    SponsorId = s.SponsorId,
                    Title = s.Title,
                    Description = s.Description,
                    SponsorTier = s.SponsorTier
                })
                .OrderBy(s => tierOrder.ContainsKey(s.SponsorTier) ? tierOrder[s.SponsorTier] : int.MaxValue)
                .ToList();

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
