using AutoMapper;
using EsportsCmsApplication.DTOs;
using EsportsCmsApplication.Interfaces.Colleges;
using EsportsCmsApplication.Interfaces.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Services
{
    public class GameService : IGameService
    {

        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }



        public async Task<List<GameDto>> GetAllGamesAsync()
        {
            var games = await _gameRepository.GetAllGamesAsync();
            return _mapper.Map<List<GameDto>>(games);
        }
    }
}
