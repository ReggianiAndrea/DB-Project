using PokedexADA.PokedexADA;
using System.Linq;

namespace PokedexADA
{
    public partial class Form1 : Form
    {
        Dictionary<int, int> mapPokedexToGUIList = new Dictionary<int, int>();

        // esempio di test
        int idGiocatore = 1;
        Giocatore giocatore;

        public Form1()
        {
            InitializeComponent();

            tabControl1.Selecting += new TabControlCancelEventHandler(tabControl1_Selecting);

            using var db = new PokedexAdaContext();
            pokemonDisponibiliBox.Items.AddRange(db.Pokemons.Select(p => p.Nome).ToArray());
            pokemonDisponibiliBox.SelectedItem = db.Pokemons.First().Nome;
            giocatore = db.Giocatores.Where(go => go.IdGiocatore == idGiocatore).First();

            foreach (Pokemon p in db.Pokemons)
            {
                var item = new ListViewItem(new[] { p.NumeroPokemon.ToString(), p.Nome, "" });
                pokedexList.Items.Add(item);
                mapPokedexToGUIList.Add(p.NumeroPokemon, pokedexList.Items.Count - 1);
            }
        }

        private void MostraStatoButtonOnClick(object sender, EventArgs e)
        {
            outputBox.Text = giocatore.MostraStato();
        }

        private void CercaPokemonSelezionatoButtonOnClick(object sender, EventArgs e)
        {
            using var db = new PokedexAdaContext();
            outputBox.Text = giocatore.Incontra(db.Pokemons.ElementAt(pokemonDisponibiliBox.SelectedIndex).NumeroPokemon);
        }

        private void CercaPokemonButtonOnClick(object sender, EventArgs e)
        {
            using var db = new PokedexAdaContext();
            int id = new Random().Next(db.Pokemons.Count());
            Pokemon pokemon = db.Pokemons.ElementAt(id);
            pokemonDisponibiliBox.SelectedIndex = id;
            outputBox.Text = giocatore.Incontra(pokemon.NumeroPokemon);
        }

        private void TentaCatturaButtonOnClick(object sender, EventArgs e)
        {
            using var db = new PokedexAdaContext();
            double catchRate = 0.5;
            int id = pokemonDisponibiliBox.SelectedIndex;
            Pokemon pokemon = db.Pokemons.ElementAt(id);
            string nome = db.Pokemons.ElementAt(id).Nome;
            outputBox.Text = giocatore.Incontra(pokemon.NumeroPokemon);
            if (new Random().NextDouble() < catchRate)
            {
                outputBox.Text += giocatore.Cattura(pokemon.NumeroPokemon);
            }
            else
            {
                outputBox.Text += giocatore.CatturaFallita(pokemon.NumeroPokemon);
            }
        }

        private void pokedexList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pokedexList.SelectedItems.Count == 0)
                return;

            using var db = new PokedexAdaContext();
            int id = pokedexList.SelectedItems[0].Index;
            Pokemon pokemon = db.Pokemons.ElementAt(id);
            Bitmap picture = (Bitmap)Image.FromFile(@"..\..\..\res\" + pokemon.Immagine);
            string nome, specie, altezza, peso, impronta, descrizione;
            nome = "???";
            specie = "???";
            altezza = "???";
            peso = "???";
            impronta = "???";
            descrizione = "";
            pokedexPicture.Image = null;
            bool visto = (
                from g in db.Giocatores
                from p in g.NumeroPokemonAvvistati
                where p.NumeroPokemon == pokemon.NumeroPokemon
                select p)
                .Any();
            bool catturato = (
                from g in db.Giocatores
                from p in g.NumeroPokemonCatturati
                where p.NumeroPokemon == pokemon.NumeroPokemon
                select p)
                .Any();
            if (visto && !catturato)
            {
                pokedexPicture.Image = filterPicture(picture);
            }
            if (visto)
            {
                nome = pokemon.Nome;
                specie = pokemon.Specie;
            }
            if (catturato)
            {
                altezza = "" + pokemon.Altezza;
                peso = "" + pokemon.Peso;
                impronta = pokemon.Impronta;
                descrizione = pokemon.DescrizionePokemon;
                pokedexPicture.Image = picture;
            }
            pokemonLabel.Text = $"{pokemon.NumeroPokemon}: {nome}";
            speciePokemonLabel.Text = $"Pokemon: {specie}";
            altezzaPokemonLabel.Text = $"Altezza: {altezza} m";
            pesoPokemonLabel.Text = $"Peso: {peso} kg";
            improntaPokemonLabel.Text = $"Impronta: {impronta}";
            descrizionePokemonTextBox.Text = descrizione;
        }

        private Bitmap filterPicture(Bitmap picture)
        {
            Bitmap filteredPicture = new Bitmap(picture.Width, picture.Height);
            for (int y = 0; y < filteredPicture.Height; y++)
            {
                for (int x = 0; x < filteredPicture.Width; x++)
                {
                    Color px = picture.GetPixel(x, y);
                    if (px.A != 0)
                    {
                        px = Color.Gray;
                    }
                    filteredPicture.SetPixel(x, y, px);
                }
            }
            return filteredPicture;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            pokedexPicture.Image = new Bitmap(pokedexPicture.Width, pokedexPicture.Height);
            pokedexList.SelectedItems.Clear();

            using var db = new PokedexAdaContext();
            foreach (Pokemon p in db.Pokemons)
            {
                string status;
                using var context = new PokedexAdaContext();
                bool visto = (
                    from g in context.Giocatores
                    from pok in g.NumeroPokemonAvvistati
                    where pok.NumeroPokemon == p.NumeroPokemon
                    select p)
                    .Any();
                bool catturato = (
                    from g in context.Giocatores
                    from pok in g.NumeroPokemonCatturati
                    where pok.NumeroPokemon == p.NumeroPokemon
                    select p)
                    .Any();
                if (catturato)
                {
                    status = "x";
                }
                else if (visto)
                {
                    status = "o";
                }
                else
                {
                    status = "";
                }
                int index = mapPokedexToGUIList[p.NumeroPokemon];
                pokedexList.Items[index].SubItems[2].Text = status;
            }
        }
    }

}
