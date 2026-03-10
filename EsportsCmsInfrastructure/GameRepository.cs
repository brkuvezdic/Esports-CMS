using EsportsCmsApplication.Interfaces.Games;
using EsportsCmsDomain.EntitiesNew;
using Microsoft.EntityFrameworkCore;

namespace EsportsCmsInfrastructure
{

    public class GameRepository : IGameRepository
    {
        private readonly EsportsCmsContext _dbContext;

        public GameRepository(EsportsCmsContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Task<List<Game>> GetAllGamesAsync()
        {
            return _dbContext.Games.Distinct().ToListAsync();
        }
    }
}
