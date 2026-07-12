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

        public static List<Pokemon> GetPokedex()
        {
            var query = from p in Instance.db.Pokemons select p;
            return query.ToList();
        }

        private static Database instance;

        private static Database Instance
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
