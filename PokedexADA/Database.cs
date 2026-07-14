using MySql.Data.MySqlClient;
using PokedexADA.PokedexADA;
using System.ComponentModel;

namespace PokedexADA
{
    internal class Database
    {
        public PokedexAdaContext Db { get; private set; }

        private Database()
        {
            Db = new PokedexAdaContext();
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

        public static List<Pokemon> GetPokedex()
        {
            var query = from p in Instance.Db.Pokemons select p;
            return query.ToList();
        }

        public static Giocatore GetGiocatore(int id)
        {
            var query = from g in Instance.Db.Giocatores select g;
            return query.First();
        }
    }
}
