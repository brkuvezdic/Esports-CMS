using EsportsCmsApplication.DTOs;
using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Games
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllGamesAsync();

    }
}
