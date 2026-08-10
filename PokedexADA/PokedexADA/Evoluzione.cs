using System;
using System.Collections.Generic;

namespace PokedexADA.PokedexADA;

public partial class Evoluzione
{
    public int NumeroPokemonStadioCorrente { get; set; }

    public int NumeroPokemonStadioSuccessivo { get; set; }

    public int IdMetodo { get; set; }

    public virtual Pokemon NumeroPokemonStadioCorrenteNavigation { get; set; } = null!;

    public virtual Pokemon NumeroPokemonStadioSuccessivoNavigation { get; set; } = null!;
}
