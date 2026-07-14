using PokedexADA.PokedexADA;

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
            giocatore = db.Giocatores.Where(go => go.IdGiocatore == idGiocatore).First();
            foreach (Pokemon p in db.Pokemons)
            {
                var item = new ListViewItem(new[] { p.NumeroPokemon.ToString(), p.Nome, "" });
                pokedexList.Items.Add(item);
                mapPokedexToGUIList.Add(p.NumeroPokemon, pokedexList.Items.Count - 1);
            }
            foreach (Amicizia a in db.Amicizia)
            {
                using var context = new PokedexAdaContext();
                Giocatore g = context.Giocatores.Where(g => g.IdGiocatore == a.IdGiocatoreAmico).First();
                var item = new ListViewItem(new[] { g.Nickname, a.Bloccato ? "bloccato" : "" });
                amiciList.Items.Add(item);
            }
            tentaCatturaButton.Enabled = false;
        }

        private void MostraStatoButtonOnClick(object sender, EventArgs e)
        {
            outputBox.Text = $"Status giocatore {giocatore.Nickname}\nPokemon incontrati:\n";
            foreach (Pokemon p in giocatore.GetPokemonIncontrati())
            {
                outputBox.Text += $"- {p.Nome}\n";
            }
            outputBox.Text += $"Pokemon catturati:\n";
            foreach (Pokemon p in giocatore.GetPokemonCatturati())
            {
                outputBox.Text += $"- {p.Nome}\n";
            }
            tentaCatturaButton.Enabled = false;
        }

        private void CercaPokemonSelezionatoButtonOnClick(object sender, EventArgs e)
        {
            if (pokemonDisponibiliBox.SelectedIndex == -1)
            {
                outputBox.Text = "Prima seleziona un pokemon";
                return;
            }
            using var db = new PokedexAdaContext();
            Pokemon pokemon = db.Pokemons.ElementAt(pokemonDisponibiliBox.SelectedIndex);
            giocatore.Incontra(pokemon.NumeroPokemon);
            outputBox.Text = $"{giocatore.Nickname} ha incontrato {pokemon.Nome}\n";
            tentaCatturaButton.Enabled = true;
        }

        private void CercaPokemonButtonOnClick(object sender, EventArgs e)
        {
            using var db = new PokedexAdaContext();
            int id = new Random().Next(db.Pokemons.Count());
            Pokemon pokemon = db.Pokemons.ElementAt(id);
            pokemonDisponibiliBox.SelectedIndex = id;
            giocatore.Incontra(pokemon.NumeroPokemon);
            outputBox.Text = $"{giocatore.Nickname} ha incontrato {pokemon.Nome}\n";
            tentaCatturaButton.Enabled = true;
        }

        private void TentaCatturaButtonOnClick(object sender, EventArgs e)
        {
            using var db = new PokedexAdaContext();
            double catchRate = 0.5;
            int id = pokemonDisponibiliBox.SelectedIndex;
            Pokemon pokemon = db.Pokemons.ElementAt(id);
            string nome = pokemon.Nome;
            bool catturato = giocatore.TentaCattura(pokemon.NumeroPokemon, catchRate);
            if (catturato)
            {
                outputBox.Text += $"{giocatore.Nickname} ha catturato {nome}\n";
                tentaCatturaButton.Enabled = false;
            }
            else
            {
                outputBox.Text += $"{giocatore.Nickname} ha fallito la cattura di {nome}\n";
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
            if (tabControl1.SelectedIndex == 1)
            {
                SelezionaPokedex();
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                SelezionaListaAmici();
            }
        }

        private void SelezionaListaAmici()
        {
            using var db = new PokedexAdaContext();
            for (int i = 0; i < db.Amicizia.Count(); i++)
            {
                Amicizia a = db.Amicizia.ElementAt(i);
                Giocatore g = db.Giocatores.Where(g => g.IdGiocatore == a.IdGiocatoreAmico).First();
                amiciList.Items[i].SubItems[0].Text = g.Nickname;
                amiciList.Items[i].SubItems[1].Text = a.Bloccato ? "bloccato" : "";
            }
        }

        private void SelezionaPokedex()
        {
            pokedexPicture.Image = new Bitmap(pokedexPicture.Width, pokedexPicture.Height);
            pokedexList.SelectedItems.Clear();

            using var db = new PokedexAdaContext();
            List<Pokemon> visti = (
                from g in db.Giocatores
                from p in g.NumeroPokemonAvvistati
                select p)
                .ToList();
            List<Pokemon> catturati = (
                from g in db.Giocatores
                from p in g.NumeroPokemonCatturati
                select p)
                .ToList();
            foreach (Pokemon p in db.Pokemons)
            {
                string status;
                if (catturati.Any(pok => pok.NumeroPokemon == p.NumeroPokemon))
                {
                    status = "x";
                }
                else if (visti.Any(pok => pok.NumeroPokemon == p.NumeroPokemon))
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

        private void cercaGiocatoreButton_Click(object sender, EventArgs e)
        {
            string nickname = cercaGiocatoreTextBox.Text;
            MostraGiocatore(nickname);
        }

        private void MostraGiocatore(string nickname)
        {
            cercaGiocatoreBloccaButton.Hide();
            cercaGiocatoreSbloccaButton.Hide();
            cercaGiocatoreAggiungiButton.Hide();
            nomeCercaGiocatoreLabel.Hide();
            cognomeCercaGiocatoreLabel.Hide();
            cercaGiocatoreFallitaLabel.Text = "";
            using var db = new PokedexAdaContext();
            var query =
                from g in db.Giocatores
                where g.Nickname == nickname
                select g;
            Giocatore? giocatoreTrovato = query.FirstOrDefault();
            if (giocatoreTrovato == null)
            {
                cercaGiocatoreFallitaLabel.Text = "Giocatore non trovato";
                return;
            }
            cercaGiocatoreGroupBox.Show();
            cercaGiocatorePictureBox.ImageLocation = giocatoreTrovato.Immagine;
            nomeCercaGiocatoreLabel.Text = $"Nome: {giocatoreTrovato.Nome}";
            cognomeCercaGiocatoreLabel.Text = $"Cognome: {giocatoreTrovato.Cognome}";
            nicknameCercaGiocatoreLabel.Text = $"Nickname: {giocatoreTrovato.Nickname}";
            var query2 =
                from a in db.Amicizia
                where a.IdGiocatore == giocatore.IdGiocatore && a.IdGiocatoreAmico == giocatoreTrovato.IdGiocatore
                select a;
            Amicizia? amicizia = query2.FirstOrDefault();
            if (amicizia != null)
            {
                nomeCercaGiocatoreLabel.Show();
                cognomeCercaGiocatoreLabel.Show();
                if (amicizia.Bloccato)
                {
                    cercaGiocatoreSbloccaButton.Show();
                }
                else
                {
                    cercaGiocatoreBloccaButton.Show();
                }
            }
            else if (giocatore.IdGiocatore != giocatoreTrovato.IdGiocatore)
            {
                cercaGiocatoreAggiungiButton.Show();
            }
            else
            {
                nomeCercaGiocatoreLabel.Show();
                cognomeCercaGiocatoreLabel.Show();
            }
            SelezionaListaAmici();
        }

        private void cercaGiocatoreBloccaButton_Click(object sender, EventArgs e)
        {
            string nickname = cercaGiocatoreTextBox.Text;
            using var db = new PokedexAdaContext();
            giocatore.BloccaAmico(db.Giocatores.Where(p => p.Nickname == nickname).Select(p => p.IdGiocatore).First());
            MostraGiocatore(nickname);
        }

        private void cercaGiocatoreSbloccaButton_Click(object sender, EventArgs e)
        {
            string nickname = cercaGiocatoreTextBox.Text;
            using var db = new PokedexAdaContext();
            giocatore.SbloccaAmico(db.Giocatores.Where(p => p.Nickname == nickname).Select(p => p.IdGiocatore).First());
            MostraGiocatore(nickname);
        }

        private void cercaGiocatoreAggiungiButton_Click(object sender, EventArgs e)
        {
            string nickname = cercaGiocatoreTextBox.Text;
            using var db = new PokedexAdaContext();
            giocatore.AggiungiAmico(db.Giocatores.Where(p => p.Nickname == nickname).Select(p => p.IdGiocatore).First());
            MostraGiocatore(nickname);
        }

        private void amiciList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nickname = amiciList.SelectedItems[0].SubItems[0].Text;
            MostraGiocatore(nickname);
        }
    }

}
