using EsportsCmsApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.PandaScore
{
    public interface IPandaScoreService
    {
        Task<List<PandaScoreMatchDto>> GetUpcomingMatchesAsync();

    }
}
