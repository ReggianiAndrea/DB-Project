using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokedexADA
{
    internal interface ICatturaFallita
    {
        //intendiamo il pokemon è fuggito
        void CatturaFallita(string nomePokemon);
    }
}
