using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Battaglia
{
    public int IdBattaglia { get; set; }

    public string SfidanteVincitore { get; set; } = null!;

    public DateTime Data { get; set; }

    public int IdGiocatoreSfidante { get; set; }

    public int IdGiocatoreSfidato { get; set; }

    public string Luogo { get; set; } = null!;

    public virtual Squadra IdGiocatoreSfidanteNavigation { get; set; } = null!;

    public virtual Squadra IdGiocatoreSfidatoNavigation { get; set; } = null!;
}
