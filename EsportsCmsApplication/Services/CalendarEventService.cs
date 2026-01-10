using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.CalendarEvents;
using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Services
{
    public class CalendarEventService : ICalendarEventService
    {
        private readonly ICalendarEventRepository _repo;
        private readonly IMapper _mapper;

        public CalendarEventService(ICalendarEventRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<CalendarEventDto>> GetPublicAsync()
            => _mapper.Map<List<CalendarEventDto>>(await _repo.GetPublishedAsync());

        public async Task<List<CalendarEventDto>> GetAllAsync()
            => _mapper.Map<List<CalendarEventDto>>(await _repo.GetAllAsync());

        public async Task<CalendarEventDto> CreateAsync(CreateCalendarEventDto dto)
        {
            var ev = _mapper.Map<CalendarEvent>(dto);
            ev.Id = Guid.NewGuid();
            ev.CreatedAt = DateTimeOffset.UtcNow;

            return _mapper.Map<CalendarEventDto>(await _repo.AddAsync(ev));
        }

        public async Task<CalendarEventDto> UpdateAsync(UpdateCalendarEventDto dto)
        {
            var ev = await _repo.GetByIdAsync(dto.Id)
                ?? throw new KeyNotFoundException();

            _mapper.Map(dto, ev);
            ev.UpdatedAt = DateTimeOffset.UtcNow;

            return _mapper.Map<CalendarEventDto>(await _repo.UpdateAsync(ev));
        }
    }

}
