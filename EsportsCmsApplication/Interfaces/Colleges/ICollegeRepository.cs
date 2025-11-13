using EsportsCmsDomain.EntitiesNew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.Interfaces.Colleges
{
    public interface ICollegeRepository
    {
        Task<List<College>> GetAllCollegesAsync();
    }
}
