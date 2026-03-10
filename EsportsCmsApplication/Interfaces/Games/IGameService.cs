using EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Games
{
    public interface IGameService
    {

        Task<List<GameDto>> GetAllGamesAsync();

    }
}
