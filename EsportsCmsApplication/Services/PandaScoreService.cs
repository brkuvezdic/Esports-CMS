using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.PandaScore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace EsportsCmsInfrastructure.Services
{
    public class PandaScoreService : IPandaScoreService
    {
        private readonly HttpClient _http;
        private readonly string _endpoint;
        private readonly string _token;

        public PandaScoreService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _endpoint = "https://api.pandascore.co/matches/upcoming";
            _token = config["PandaScore:Token"];
        }

        public async Task<List<PandaScoreMatchDto>> GetUpcomingMatchesAsync()
        {
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", _token);

            var response = await _http.GetAsync(_endpoint);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var rawMatches = JsonSerializer.Deserialize<List<PandaScoreMatchRaw>>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            return rawMatches.Select(m => new PandaScoreMatchDto
            {
                Id = m.Id,
                Videogame = m.Videogame.Name,
                Name = m.Name,
                BeginAt = m.Begin_At,
                Status = m.Status,
                StreamUrl = m.Streams_List?.FirstOrDefault(s => s.Main)?.Raw_Url
            }).ToList();
        }
    }
}
