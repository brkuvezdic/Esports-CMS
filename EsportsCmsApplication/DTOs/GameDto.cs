using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportsCmsApplication.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public int TeamSize { get; set; }
    }
}
