using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.DTOs
{
    public class TeamDto
    {
        public int TeamId { get; set; }
        public int CollegeId { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; } = null!;
    }
}
