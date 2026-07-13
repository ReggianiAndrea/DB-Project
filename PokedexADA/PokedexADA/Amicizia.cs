using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Amicizia
{
    public int IdGiocatore { get; set; }

    public int IdGiocatoreAmico { get; set; }

    public string Bloccato { get; set; } = null!;

    public virtual Giocatore IdGiocatoreAmicoNavigation { get; set; } = null!;

    public virtual Giocatore IdGiocatoreNavigation { get; set; } = null!;
}
