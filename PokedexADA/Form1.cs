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
        Giocatore? giocatoreSelezionato;

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
            pokedexPicture.Image = null;
            mossePokemonListView.Items.Clear();
            lineaEvolutivaPokemonLayout.Visible = false;
            if (pokedexList.SelectedItems.Count != 1) {
                pokemonLabel.Text = "Numero:";
                speciePokemonLabel.Text = "Pokemon:";
                biomaPokemonLabel.Text = "Bioma:";
                abilitaPokemonLabel.Text = "Abilità:";
                elementiPokemonLabel.Text = "Elementi:";
                altezzaPokemonLabel.Text = "Altezza:";
                pesoPokemonLabel.Text = "Peso:";
                improntaPokemonLabel.Text = "Impronta:";
                descrizionePokemonTextBox.Text = "";
                statistichePokemonPuntiSaluteLabel.Text = "Punti salute:";
                statistichePokemonAttaccoLabel.Text = "Attacco:";
                statistichePokemonDifesaLabel.Text = "Difesa:";
                statistichePokemonAttaccoSpecialeLabel.Text = "Attacco speciale:";
                statistichePokemonDifesaSpecialeLabel.Text = "Difesa speciale:";
                statistichePokemonVelocitaLabel.Text = "Velocità:";
                statistichePokemonTotaleLabel.Text = "Totale:";
                return;
            }
            using var db = new PokedexAdaContext();
            int id = pokedexList.SelectedItems[0].Index;
            Pokemon pokemon = db.Pokemons.ElementAt(id);
            Bitmap picture = (Bitmap)Image.FromFile(@"..\..\..\res\" + pokemon.Immagine);
            string nome = "???";
            string abilita = "???";
            string bioma = "???";
            string specie = "???";
            string altezza = "???";
            string peso = "???";
            string impronta = "???";
            string elementi = "???";
            string puntiSalute = "???";
            string attacco = "???";
            string difesa = "???";
            string attaccoSpeciale = "???";
            string difesaSpeciale = "???";
            string velocita = "???";
            string totale = "???";
            string descrizione = "";
            List<Pokemon> pokemonVisti = (
                from g in db.Giocatores
                from p in g.NumeroPokemonAvvistati
                select p)
                .ToList();
            List<Pokemon> pokemonCatturati = (
                from g in db.Giocatores
                from p in g.NumeroPokemonCatturati
                select p)
                .ToList();
            bool visto = pokemonVisti.Where(p => p.NumeroPokemon == pokemon.NumeroPokemon).Any();
            bool catturato = pokemonCatturati.Where(p => p.NumeroPokemon == pokemon.NumeroPokemon).Any();
            if (visto && !catturato)
            {
                pokedexPicture.Image = filterPicture(picture);
            }
            if (visto)
            {
                nome = pokemon.Nome;
                specie = pokemon.Specie;
                bioma = (
                    from p in db.Pokemons
                    from b in p.IdBiomas
                    where p.NumeroPokemon == pokemon.NumeroPokemon
                    select b.Habitat)
                    .First();
                string elementoPrimarioPokemon = (
                    from el in db.Elementos
                    where pokemon.IdElementoPrimario == el.IdElemento
                    select el.Tipologia)
                    .First();
                string? elementoSecondarioPokemon = (
                    from el in db.Elementos
                    where pokemon.IdElementoSecondario == el.IdElemento
                    select el.Tipologia)
                    .FirstOrDefault();
                elementi = elementoPrimarioPokemon + (elementoSecondarioPokemon != null ? " / " + elementoSecondarioPokemon : "");
                SetStatistiche statistiche = (
                    from s in db.SetStatistiches
                    where pokemon.IdStatistiche == s.IdStatistiche
                    select s)
                    .First();
                int ps = statistiche.PuntiSalute;
                int att = statistiche.Attacco;
                int def = statistiche.Difesa;
                int attsp = statistiche.AttaccoSpeciale;
                int defsp = statistiche.DifesaSpeciale;
                int spd = statistiche.Velocita;
                totale = (ps + att + def + attsp + defsp + spd).ToString();
                puntiSalute = ps.ToString();
                attacco = att.ToString();
                difesa = def.ToString();
                attaccoSpeciale = attsp.ToString();
                difesaSpeciale = defsp.ToString();
                velocita = spd.ToString();
                lineaEvolutivaPokemonLayout.Controls.Clear();
                foreach (Pokemon evo in pokemon.GetLineaEvolutiva())
                {
                    bool evoVisto = pokemonVisti.Where(p => p.NumeroPokemon == evo.NumeroPokemon).Any();
                    bool evoCatturato = pokemonCatturati.Where(p => p.NumeroPokemon == evo.NumeroPokemon).Any();
                    PictureBox box = new PictureBox();
                    Bitmap image = new Bitmap(Image.FromFile(@"..\..\..\res\" + evo.Immagine), new Size(120, 120));
                    if (!evoVisto)
                    {
                        image = new Bitmap(120, 120);
                    }
                    if (evoVisto && !evoCatturato)
                    {
                        image = filterPicture(image);
                    }
                    box.Size = image.Size;
                    box.Image = image;
                    lineaEvolutivaPokemonLayout.Controls.Add(box);
                }
                if (pokemon.GetLineaEvolutiva().Count == 0)
                {
                    Label label = new Label();
                    label.Width = 500;
                    label.Text = "Questo pokemon non ha nessuna linea evolutiva";
                    lineaEvolutivaPokemonLayout.Controls.Add(label);
                }
                lineaEvolutivaPokemonLayout.Visible = true;
            }
            if (catturato)
            {
                altezza = "" + pokemon.Altezza;
                peso = "" + pokemon.Peso;
                impronta = pokemon.Impronta;
                descrizione = pokemon.DescrizionePokemon;
                abilita = pokemon.NomeAbilita;
                foreach (Mossa m in pokemon.GetMosseApprendibili())
                {
                    string nomeElemento = (
                        from el in db.Elementos
                        where el.IdElemento == m.IdElemento
                        select el.Tipologia)
                        .First();
                    string danno = m.Danno != null ? m.Danno.GetValueOrDefault().ToString() : "-";
                    string precisione = m.Precisione <= 100 ? m.Precisione.ToString() : "-";
                    var item = new ListViewItem(new[] { m.NomeMossa, nomeElemento, danno, precisione, m.DescrizioneMossa });
                    mossePokemonListView.Items.Add(item);
                }
                pokedexPicture.Image = picture;
            }
            pokemonLabel.Text = $"{pokemon.NumeroPokemon}: {nome}";
            speciePokemonLabel.Text = $"Pokemon: {specie}";
            abilitaPokemonLabel.Text = $"Abilità: {abilita}";
            biomaPokemonLabel.Text = $"Bioma: {bioma}";
            altezzaPokemonLabel.Text = $"Altezza: {altezza} m";
            pesoPokemonLabel.Text = $"Peso: {peso} kg";
            improntaPokemonLabel.Text = $"Impronta: {impronta}";
            elementiPokemonLabel.Text = $"Elementi: {elementi}";
            descrizionePokemonTextBox.Text = descrizione;
            statistichePokemonPuntiSaluteLabel.Text = $"Punti salute: {puntiSalute}";
            statistichePokemonAttaccoLabel.Text = $"Attacco: {attacco}";
            statistichePokemonDifesaLabel.Text = $"Difesa: {difesa}";
            statistichePokemonAttaccoSpecialeLabel.Text = $"Attacco speciale: {attaccoSpeciale}";
            statistichePokemonDifesaSpecialeLabel.Text = $"Difesa speciale: {difesaSpeciale}";
            statistichePokemonVelocitaLabel.Text = $"Velocità: {velocita}";
            statistichePokemonTotaleLabel.Text = $"Totale: {totale}";
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
                    status = "\u00A9";
                }
                else if (visti.Any(pok => pok.NumeroPokemon == p.NumeroPokemon))
                {
                    status = "\u25CB";
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
            using var db = new PokedexAdaContext();
            cercaGiocatoreTextBox.Text = "";
            giocatoreSelezionato = db.Giocatores.Where(p => p.Nickname == nickname).FirstOrDefault();
            MostraGiocatore(giocatoreSelezionato);
        }

        private void MostraGiocatore(Giocatore? amico)
        {
            cercaGiocatoreBloccaButton.Hide();
            cercaGiocatoreSbloccaButton.Hide();
            cercaGiocatoreAggiungiButton.Hide();
            cercaGiocatoreRimuoviButton.Hide();
            nomeCercaGiocatoreLabel.Hide();
            cognomeCercaGiocatoreLabel.Hide();
            cercaGiocatoreFallitaLabel.Text = "";
            using var db = new PokedexAdaContext();
            if (amico == null)
            {
                cercaGiocatoreFallitaLabel.Text = "Giocatore non trovato";
                return;
            }
            cercaGiocatoreGroupBox.Show();
            cercaGiocatorePictureBox.ImageLocation = amico.Immagine;
            nomeCercaGiocatoreLabel.Text = $"Nome: {amico.Nome}";
            cognomeCercaGiocatoreLabel.Text = $"Cognome: {amico.Cognome}";
            nicknameCercaGiocatoreLabel.Text = $"Nickname: {amico.Nickname}";
            var query2 =
                from a in db.Amicizia
                where a.IdGiocatore == giocatore.IdGiocatore && a.IdGiocatoreAmico == amico.IdGiocatore
                select a;
            Amicizia? amicizia = query2.FirstOrDefault();
            if (amicizia != null)
            {
                cercaGiocatoreRimuoviButton.Show();
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
            else if (giocatore.IdGiocatore != amico.IdGiocatore)
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
            if (giocatoreSelezionato != null)
            {
                giocatore.BloccaAmico(giocatoreSelezionato.IdGiocatore);
                MostraGiocatore(giocatoreSelezionato);
            }
        }

        private void cercaGiocatoreSbloccaButton_Click(object sender, EventArgs e)
        {
            if (giocatoreSelezionato != null)
            {
                giocatore.SbloccaAmico(giocatoreSelezionato.IdGiocatore);
                MostraGiocatore(giocatoreSelezionato);
            }
        }

        private void cercaGiocatoreAggiungiButton_Click(object sender, EventArgs e)
        {
            if (giocatoreSelezionato != null)
            {
                giocatore.AggiungiAmico(giocatoreSelezionato.IdGiocatore);
                var item = new ListViewItem(new[] { giocatoreSelezionato.Nickname, "" });
                amiciList.Items.Add(item);
                MostraGiocatore(giocatoreSelezionato);
            }
        }

        private void cercaGiocatoreRimuoviButton_Click(object sender, EventArgs e)
        {
            if (giocatoreSelezionato != null)
            {
                using var db = new PokedexAdaContext();
                amiciList.Items.Clear();
                for (int i = 0; i < amiciList.Items.Count; i++)
                {
                    if (amiciList.Items[i].SubItems[0].Text == giocatoreSelezionato.Nickname)
                    {
                        amiciList.Items.RemoveAt(i);
                        break;
                    }
                }
                giocatore.RimuoviAmico(giocatoreSelezionato.IdGiocatore);
                MostraGiocatore(giocatoreSelezionato);
            }
        }

        private void amiciList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (giocatoreSelezionato != null && amiciList.SelectedItems.Count > 0 && giocatoreSelezionato.Nickname != amiciList.SelectedItems[0].SubItems[0].Text)
            {
                using var db = new PokedexAdaContext();
                giocatoreSelezionato = db.Giocatores.Where(p => p.Nickname == amiciList.SelectedItems[0].SubItems[0].Text).FirstOrDefault();
                MostraGiocatore(giocatoreSelezionato);
            }
        }
    }

}
