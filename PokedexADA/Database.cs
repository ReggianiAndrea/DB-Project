using MySql.Data.MySqlClient;
using PokedexADA.PokedexADA;
using System.ComponentModel;

namespace PokedexADA
{
    internal class Database
    {
        PokedexAdaContext db;

        private Database()
        {
            db = new PokedexAdaContext();
        }

        public List<Pokemon> GetPokedex()
        {
            var query = from p in db.Pokemons select p;
            return query.ToList();
        }

        private static Database instance;

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Database();
                }
                return instance;
            }
        }
    }
}
