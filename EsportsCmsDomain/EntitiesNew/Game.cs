using System;
using System.Collections.Generic;

namespace EsportsCmsDomain.EntitiesNew;

public partial class Game
{
    public int Id { get; set; }

    public string GameName { get; set; } = null!;

    public int TeamSize { get; set; }
}
