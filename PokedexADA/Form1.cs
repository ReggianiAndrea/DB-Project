using Microsoft.EntityFrameworkCore;
using PokedexADA.PokedexADA;
using System.Linq;

namespace PokedexADA
{
    public partial class Form1 : Form
    {
        Dictionary<int, int> mapPokedexToGUIList = new Dictionary<int, int>();

        int idGiocatore = 1;
        Giocatore giocatore;
        Giocatore? giocatoreSelezionato;

        public Form1()
        {
            InitializeComponent();
            amiciList.SelectedIndexChanged += amiciList_SelectedIndexChanged;

            InizializzaControlliDinamici();
            battagliaTab.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

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
        }

        private void InizializzaControlliDinamici()
        {
            // FILTRI POKEDEX
            using (var db = new PokedexAdaContext())
            {
                filtroElementoComboBox.Items.Add("Tutti");
                filtroElementoComboBox.Items.AddRange(db.Elementos.Select(e => e.Tipologia).ToArray());
                filtroElementoComboBox.SelectedIndex = 0;
            }

            using (var db = new PokedexAdaContext())
            {
                var amiciLista = (from a in db.Amicizia
                                  join g in db.Giocatores on a.IdGiocatoreAmico equals g.IdGiocatore
                                  where a.IdGiocatore == idGiocatore && !a.Bloccato
                                  select g.Nickname).ToList();

                if (amiciLista.Count > 0)
                {
                    avversarioComboBox.Items.AddRange(amiciLista.ToArray());
                    avversarioComboBox.SelectedIndex = 0;
                }
            }

            using (var db = new PokedexAdaContext())
            {
                var amiciLista = (from a in db.Amicizia
                                  join g in db.Giocatores on a.IdGiocatoreAmico equals g.IdGiocatore
                                  where a.IdGiocatore == idGiocatore && !a.Bloccato
                                  select g.Nickname)
                                 .Distinct()
                                 .ToList();

                avversarioComboBox.Items.Clear();
                if (amiciLista.Count > 0)
                {
                    avversarioComboBox.Items.AddRange(amiciLista.ToArray());
                    avversarioComboBox.SelectedIndex = 0;
                }
            }

            using (var db = new PokedexAdaContext())
            {
                var luoghi = db.Biomas.Select(b => b.Habitat).Distinct().ToArray();
                if (luoghi.Length > 0)
                {
                    luogoBattagliaComboBox.Items.AddRange(luoghi);
                }
                else
                {
                    luogoBattagliaComboBox.Items.AddRange(new string[] { "Arena Neutrale", "Stadio Pokémon", "Grotta Oscura", "Bosco Smeraldo" });
                }
                luogoBattagliaComboBox.SelectedIndex = 0;
            }
        }

        private void tabControl1_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (battagliaTab.SelectedTab == visualizzaPokedex)
            {
                SelezionaPokedex();
            }
            else if (battagliaTab.SelectedTab == visualizzaAmici)
            {
                SelezionaListaAmici();
            }
            else if (battagliaTab.SelectedTab == gestisciSquadraTab)
            {
                AggiornaVisteSquadraEBox();
            }
            else if (battagliaTab.SelectedTab == battagliaTabPage)
            {
                using var db = new PokedexAdaContext();
                var amiciLista = (
                    from g in db.Giocatores
                    from a in g.AmiciziaIdGiocatoreNavigations
                    from g2 in db.Giocatores
                    where g.IdGiocatore == idGiocatore && !a.Bloccato && g2.IdGiocatore == a.IdGiocatoreAmico
                    select g2.Nickname);

                avversarioComboBox.Items.Clear();
                avversarioComboBox.Items.AddRange(amiciLista.ToArray());
                if (avversarioComboBox.Items.Count > 0)
                {
                    avversarioComboBox.SelectedIndex = 0;
                }
            }
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
            if (pokedexList.SelectedItems.Count != 1)
            {
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
            int id = Int32.Parse(pokedexList.SelectedItems[0].SubItems[0].Text);
            Pokemon pokemon = db.Pokemons.Where(p => p.NumeroPokemon == id).First();
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
            if (!visto)
            {
                pokedexPicture.Image = new Bitmap(Image.FromFile(@"..\..\..\res\questionmark.png"));
            }
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
                lineaEvolutivaPokemonLayout.RowCount = 0;
                foreach (Evoluzione evo in pokemon.GetLineaEvolutiva())
                {
                    Pokemon corrente = db.Pokemons.Where(p => p.NumeroPokemon == evo.NumeroPokemonStadioCorrente).First();
                    Pokemon successivo = db.Pokemons.Where(p => p.NumeroPokemon == evo.NumeroPokemonStadioSuccessivo).First();
                    bool corrVisto = pokemonVisti.Where(p => p.NumeroPokemon == corrente.NumeroPokemon).Any();
                    bool corrCatturato = pokemonCatturati.Where(p => p.NumeroPokemon == corrente.NumeroPokemon).Any();
                    bool evoVisto = pokemonVisti.Where(p => p.NumeroPokemon == successivo.NumeroPokemon).Any();
                    bool evoCatturato = pokemonCatturati.Where(p => p.NumeroPokemon == successivo.NumeroPokemon).Any();
                    Label label = new Label();
                    label.AutoSize = true;
                    label.Text = "Metodo: ???";
                    PictureBox box = new PictureBox();
                    PictureBox boxEvo = new PictureBox();
                    Bitmap image = new Bitmap(Image.FromFile(@"..\..\..\res\" + corrente.Immagine), 120, 120);
                    Bitmap imageEvo = new Bitmap(Image.FromFile(@"..\..\..\res\" + successivo.Immagine), 120, 120);
                    if (!corrVisto) image = new Bitmap(Image.FromFile(@"..\..\..\res\questionmark.png"), 120, 120);
                    if (corrVisto && !corrCatturato) image = filterPicture(image);
                    if (!evoVisto) imageEvo = new Bitmap(Image.FromFile(@"..\..\..\res\questionmark.png"), 120, 120);
                    if (evoVisto && !evoCatturato) imageEvo = filterPicture(imageEvo);
                    if (corrCatturato && evoCatturato)
                    {
                        string nomeMetodo = db.MetodoEvolutivos.Where(m => m.IdMetodo == evo.IdMetodo).Select(m => m.Nome).First();
                        label.Text = $"Metodo: {nomeMetodo}";
                    }
                    box.Size = image.Size;
                    box.Image = image;
                    boxEvo.Size = imageEvo.Size;
                    boxEvo.Image = imageEvo;
                    lineaEvolutivaPokemonLayout.RowCount += 1;
                    lineaEvolutivaPokemonLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                    lineaEvolutivaPokemonLayout.Controls.Add(box, 0, lineaEvolutivaPokemonLayout.RowCount - 1);
                    lineaEvolutivaPokemonLayout.Controls.Add(label, 1, lineaEvolutivaPokemonLayout.RowCount - 1);
                    lineaEvolutivaPokemonLayout.Controls.Add(boxEvo, 2, lineaEvolutivaPokemonLayout.RowCount - 1);
                }
                if (pokemon.GetLineaEvolutiva().Count == 0)
                {
                    Label label = new Label();
                    label.AutoSize = true;
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

        private void SelezionaListaAmici()
        {
            using var db = new PokedexAdaContext();
            for (int i = 0; i < db.Amicizia.Count(); i++)
            {
                Amicizia a = db.Amicizia.ElementAt(i);
                Giocatore g = db.Giocatores.Where(g => g.IdGiocatore == a.IdGiocatoreAmico).First();
                if (i < amiciList.Items.Count)
                {
                    amiciList.Items[i].SubItems[0].Text = g.Nickname;
                    amiciList.Items[i].SubItems[1].Text = a.Bloccato ? "bloccato" : "";
                }
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
                bool visto = visti.Any(pok => pok.NumeroPokemon == p.NumeroPokemon);
                bool catturato = catturati.Any(pok => pok.NumeroPokemon == p.NumeroPokemon);
                string nome = visto ? p.Nome : "???";
                string status;
                if (catturato)
                {
                    status = "\u00A9";
                }
                else if (visto)
                {
                    status = "\u25CB";
                }
                else
                {
                    status = "";
                }
                int index = mapPokedexToGUIList[p.NumeroPokemon];
                pokedexList.Items[index].SubItems[1].Text = nome;
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

            squadraAmicoListView.Items.Clear();

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

            var datiEsemplari = new List<(int IdEsemplare, int Livello, int NumeroPokemon)>();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT IdEsemplare, Livello, NumeroPokemon FROM esemplare_pokemon WHERE IdGiocatoreProprietario = @idAmico AND IdSquadra IS NOT NULL";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@idAmico";
                parameter.Value = amico.IdGiocatore;
                command.Parameters.Add(parameter);

                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datiEsemplari.Add((reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2)));
                }
            }

            foreach (var p in datiEsemplari)
            {
                string nomePokemon = db.Pokemons
                    .Where(pk => pk.NumeroPokemon == p.NumeroPokemon)
                    .Select(pk => pk.Nome)
                    .FirstOrDefault() ?? "Sconosciuto";

                var item = new ListViewItem(new[] { p.IdEsemplare.ToString(), nomePokemon, p.Livello.ToString() });
                squadraAmicoListView.Items.Add(item);
            }

            var amicizia = db.Amicizia.FirstOrDefault(a => a.IdGiocatore == idGiocatore && a.IdGiocatoreAmico == amico.IdGiocatore);
            if (amicizia != null)
            {
                cercaGiocatoreRimuoviButton.Show();
                nomeCercaGiocatoreLabel.Show();
                cognomeCercaGiocatoreLabel.Show();
                if (amicizia.Bloccato)
                    cercaGiocatoreSbloccaButton.Show();
                else
                    cercaGiocatoreBloccaButton.Show();
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

        private void amiciList_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (amiciList.SelectedItems.Count > 0)
            {
                string nicknameSelezionato = amiciList.SelectedItems[0].SubItems[0].Text;
                using var db = new PokedexAdaContext();
                giocatoreSelezionato = db.Giocatores.FirstOrDefault(p => p.Nickname == nicknameSelezionato);

                if (giocatoreSelezionato != null)
                {
                    MostraGiocatore(giocatoreSelezionato);
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }

        private void CaricaPokedexFiltrato(string nome, string elemento)
        {
            pokedexList.Items.Clear();
            using var db = new PokedexAdaContext();

            var query = db.Pokemons.Include(p => p.IdElementoPrimarioNavigation).AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(p => p.Nome.Contains(nome) || p.Specie.Contains(nome));

            if (elemento != "Tutti" && !string.IsNullOrWhiteSpace(elemento))
                query = query.Where(p => p.IdElementoPrimarioNavigation.Tipologia == elemento);

            var filtrati = query.ToList();
            var visti = db.Giocatores.Where(g => g.IdGiocatore == idGiocatore).SelectMany(g => g.NumeroPokemonAvvistati).Select(p => p.NumeroPokemon).ToList();
            var catturati = db.Giocatores.Where(g => g.IdGiocatore == idGiocatore).SelectMany(g => g.NumeroPokemonCatturati).Select(p => p.NumeroPokemon).ToList();

            foreach (var p in filtrati)
            {
                string status = catturati.Contains(p.NumeroPokemon) ? "\u00A9" : (visti.Contains(p.NumeroPokemon) ? "\u25CB" : "");
                var item = new ListViewItem(new[] { p.NumeroPokemon.ToString(), p.Nome, status });
                pokedexList.Items.Add(item);

                if (!mapPokedexToGUIList.ContainsKey(p.NumeroPokemon))
                {
                    mapPokedexToGUIList[p.NumeroPokemon] = pokedexList.Items.Count - 1;
                }
            }
        }

        private void ApplicaFiltroButton_Click(object? sender, EventArgs e)
        {
            CaricaPokedexFiltrato(filtroNomeTextBox.Text, filtroElementoComboBox.SelectedItem?.ToString() ?? "Tutti");
        }

        private void ResetFiltroButton_Click(object? sender, EventArgs e)
        {
            filtroNomeTextBox.Text = "";
            filtroElementoComboBox.SelectedIndex = 0;
            CaricaPokedexFiltrato("", "Tutti");
        }

        private void AggiornaVisteSquadraEBox()
        {
            boxListView.Items.Clear();
            squadraListView.Items.Clear();

            using var db = new PokedexAdaContext();

            var esemplariGrezzi = new List<(int IdEsemplare, int Livello, int NumeroPokemon, int? IdSquadra)>();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT IdEsemplare, Livello, NumeroPokemon, IdSquadra FROM esemplare_pokemon WHERE IdGiocatoreProprietario = @idGiocatore";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@idGiocatore";
                parameter.Value = idGiocatore;
                command.Parameters.Add(parameter);

                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int idEs = reader.GetInt32(0);
                    int livello = reader.GetInt32(1);
                    int numeroPoke = reader.GetInt32(2);
                    int? idSquadra = reader.IsDBNull(3) ? (int?)null : reader.GetInt32(3);

                    esemplariGrezzi.Add((idEs, livello, numeroPoke, idSquadra));
                }
            }

            foreach (var e in esemplariGrezzi)
            {
                string nomePokemon = db.Pokemons
                    .Where(pk => pk.NumeroPokemon == e.NumeroPokemon)
                    .Select(pk => pk.Nome)
                    .FirstOrDefault() ?? "Sconosciuto";

                var item = new ListViewItem(new[] { e.IdEsemplare.ToString(), nomePokemon, e.Livello.ToString() });
                item.Tag = e.IdEsemplare;

                if (e.IdSquadra != null)
                    squadraListView.Items.Add(item);
                else
                    boxListView.Items.Add(item);
            }
        }

        private void SpostaInSquadraButton_Click(object? sender, EventArgs e)
        {
            if (boxListView.SelectedItems.Count > 0)
            {
                int idEs = (int)boxListView.SelectedItems[0].Tag;

                if (giocatore.AggiungiASquadra(idEs))
                {
                    AggiornaVisteSquadraEBox();
                }
                else
                {
                    MessageBox.Show("Squadra piena (max 6) o errore!", "Impossibile spostare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SpostaInBoxButton_Click(object? sender, EventArgs e)
        {
            if (squadraListView.SelectedItems.Count > 0)
            {
                int idEs = (int)squadraListView.SelectedItems[0].Tag;
                if (giocatore.RimuoviDaSquadra(idEs, null))
                    AggiornaVisteSquadraEBox();
                else
                    MessageBox.Show("Errore durante lo spostamento nel box.", "Impossibile spostare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CercaGiocatoreSfidaButton_Click(object? sender, EventArgs e)
        {
            string? nicknameAvversario = avversarioComboBox.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(nicknameAvversario))
            {
                MessageBox.Show("Seleziona un avversario valido dalla tendina!", "Attenzione", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using var db = new PokedexAdaContext();
            var avversario = db.Giocatores.FirstOrDefault(g => g.Nickname == nicknameAvversario);

            if (avversario != null)
            {
                string luogo = luogoBattagliaComboBox.SelectedItem?.ToString() ?? "Arena Neutrale";
                bool hoVinto = new Random().Next(0, 2) == 1;
                try
                {
                    bool successo = giocatore.SfidaGiocatore(avversario.IdGiocatore, luogo, hoVinto);
                    if (successo)
                    {
                        if (hoVinto)
                            MessageBox.Show($"Hai sfidato {avversario.Nickname} a {luogo} e hai VINTO!", "Vittoria!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                            MessageBox.Show($"Hai sfidato {avversario.Nickname} a {luogo} ma sei stato SCONFITTO.", "Sconfitta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show($"L'allenatore {avversario.Nickname} non ha una squadra attiva, forse è ancora un principiante e non può lottare!", "Impossibile sfidare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Qualcosa è andato storto", "Sfida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}