using Microsoft.EntityFrameworkCore;
using PokedexADA.PokedexADA;

namespace PokedexADA
{
    public partial class Form1 : Form
    {
        Dictionary<int, int> mapPokedexToGUIList = new Dictionary<int, int>();

        int idGiocatore = 1;
        Giocatore giocatore;
        Giocatore? giocatoreSelezionato;

        // Controlli dinamici Pokedex
        TextBox filtroNomeTextBox;
        ComboBox filtroElementoComboBox;
        Button applicaFiltroButton;
        Button resetFiltroButton;

        TabPage gestisciSquadraTab;
        TabPage battagliaTabPage;
        ListView boxListView;
        ListView squadraListView;
        Button spostaInSquadraButton;
        Button spostaInBoxButton;

        // Controlli dinamici Battaglia
        Button cercaGiocatoreSfidaButton;
        ComboBox luogoBattagliaComboBox;
        ComboBox avversarioComboBox;

        // ListView per la squadra dell'amico in Visualizza Amici
        ListView squadraAmicoListView;

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

            tentaCatturaButton.Enabled = false;

            // Inizializzazione della lista squadra amico con anche il nome del Pokémon
            squadraAmicoListView = new ListView
            {
                Location = new Point(20, 220),
                Size = new Size(280, 150),
                View = View.Details,
                FullRowSelect = true
            };
            squadraAmicoListView.Columns.Add("ID", 40);
            squadraAmicoListView.Columns.Add("Nome", 130);
            squadraAmicoListView.Columns.Add("Livello", 60);

            // Aggiungiamo un'etichetta descrittiva sopra la lista dell'amico
            Label labelSquadraAmico = new Label
            {
                Text = "Squadra Attiva dell'Amico:",
                Location = new Point(20, 195),
                AutoSize = true,
                Font = new Font(Font, FontStyle.Bold)
            };

            cercaGiocatoreGroupBox.Controls.Add(labelSquadraAmico);
            cercaGiocatoreGroupBox.Controls.Add(squadraAmicoListView);
        }

        private void InizializzaControlliDinamici()
        {
            // FILTRI POKEDEX
            filtroNomeTextBox = new TextBox { Location = new Point(9, 830), Width = 120, PlaceholderText = "Cerca nome..." };
            filtroElementoComboBox = new ComboBox { Location = new Point(135, 830), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            applicaFiltroButton = new Button { Location = new Point(240, 828), Width = 70, Text = "Filtra" };
            resetFiltroButton = new Button { Location = new Point(315, 828), Width = 70, Text = "Reset" };

            using (var db = new PokedexAdaContext())
            {
                filtroElementoComboBox.Items.Add("Tutti");
                filtroElementoComboBox.Items.AddRange(db.Elementos.Select(e => e.Tipologia).ToArray());
                filtroElementoComboBox.SelectedIndex = 0;
            }

            applicaFiltroButton.Click += ApplicaFiltroButton_Click;
            resetFiltroButton.Click += ResetFiltroButton_Click;

            pokedexList.Height = 810;
            visualizzaPokedex.Controls.Add(filtroNomeTextBox);
            visualizzaPokedex.Controls.Add(filtroElementoComboBox);
            visualizzaPokedex.Controls.Add(applicaFiltroButton);
            visualizzaPokedex.Controls.Add(resetFiltroButton);

            // GESTIONE SQUADRA
            gestisciSquadraTab = new TabPage("Gestisci Squadra");

            Label labelBox = new Label { Text = "Box Pokémon", Location = new Point(20, 0), AutoSize = true, Font = new Font(Font, FontStyle.Bold) };
            Label labelSquadra = new Label { Text = "Squadra Attiva", Location = new Point(500, 0), AutoSize = true, Font = new Font(Font, FontStyle.Bold) };

            boxListView = new ListView { Location = new Point(20, 25), Size = new Size(300, 780), View = View.Details, FullRowSelect = true };
            boxListView.Columns.Add("ID", 40);
            boxListView.Columns.Add("Nome", 150);
            boxListView.Columns.Add("Livello", 80);

            squadraListView = new ListView { Location = new Point(500, 25), Size = new Size(300, 780), View = View.Details, FullRowSelect = true };
            squadraListView.Columns.Add("ID", 40);
            squadraListView.Columns.Add("Nome", 150);
            squadraListView.Columns.Add("Livello", 80);

            spostaInSquadraButton = new Button { Location = new Point(340, 350), Size = new Size(140, 50), Text = "Aggiungi a Squadra ->" };
            spostaInBoxButton = new Button { Location = new Point(340, 420), Size = new Size(140, 50), Text = "<- Sposta nel Box" };

            spostaInSquadraButton.Click += SpostaInSquadraButton_Click;
            spostaInBoxButton.Click += SpostaInBoxButton_Click;

            gestisciSquadraTab.Controls.Add(labelBox);
            gestisciSquadraTab.Controls.Add(labelSquadra);
            gestisciSquadraTab.Controls.Add(boxListView);
            gestisciSquadraTab.Controls.Add(squadraListView);
            gestisciSquadraTab.Controls.Add(spostaInSquadraButton);
            gestisciSquadraTab.Controls.Add(spostaInBoxButton);

            battagliaTab.TabPages.Add(gestisciSquadraTab);

            // CONTROLLI BATTAGLIA 
            Label avversarioLabel = new Label { Text = "Scegli Avversario:", Location = new Point(30, 20), AutoSize = true };
            avversarioComboBox = new ComboBox { Location = new Point(30, 45), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

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
            battagliaTabPage = new TabPage("Battaglia");

            luogoBattagliaComboBox = new ComboBox
            {
                Location = new Point(30, 30),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };

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
            Label luogoLabel = new Label { Text = "Scegli Luogo:", Location = new Point(30, 85), AutoSize = true };
            luogoBattagliaComboBox = new ComboBox { Location = new Point(30, 110), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

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

            cercaGiocatoreSfidaButton = new Button { Location = new Point(30, 155), Size = new Size(150, 37), Text = "Sfida Giocatore!", Visible = true };
            cercaGiocatoreSfidaButton.Click += CercaGiocatoreSfidaButton_Click;

            battagliaTabPage.Controls.Add(avversarioLabel);
            battagliaTabPage.Controls.Add(avversarioComboBox);
            battagliaTabPage.Controls.Add(luogoLabel);
            battagliaTabPage.Controls.Add(luogoBattagliaComboBox);
            battagliaTabPage.Controls.Add(cercaGiocatoreSfidaButton);

            battagliaTab.TabPages.Add(battagliaTabPage);
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
                List<int> numeriEvoluzioni = new List<int>();
                using (var cmdEvo = db.Database.GetDbConnection().CreateCommand())
                {
                    cmdEvo.CommandText = "SELECT NumeroPokemonArrivo FROM evoluzione WHERE NumeroPokemonPartenza = @numPoke";
                    var pNum = cmdEvo.CreateParameter();
                    pNum.ParameterName = "@numPoke";
                    pNum.Value = pokemon.NumeroPokemon;
                    cmdEvo.Parameters.Add(pNum);

                    if (cmdEvo.Connection.State != System.Data.ConnectionState.Open)
                        cmdEvo.Connection.Open();

                    using var readerEvo = cmdEvo.ExecuteReader();
                    while (readerEvo.Read())
                    {
                        numeriEvoluzioni.Add(readerEvo.GetInt32(0));
                    }
                }

                foreach (int numEvo in numeriEvoluzioni)
                {
                    using var dbEvo = new PokedexAdaContext();
                    Pokemon? pokeEvo = dbEvo.Pokemons.FirstOrDefault(p => p.NumeroPokemon == numEvo);

                    if (pokeEvo != null)
                    {
                        bool evoVisto = pokemonVisti.Where(p => p.NumeroPokemon == pokeEvo.NumeroPokemon).Any();
                        bool evoCatturato = pokemonCatturati.Where(p => p.NumeroPokemon == pokeEvo.NumeroPokemon).Any();
                        PictureBox box = new PictureBox();
                        Bitmap image = new Bitmap(Image.FromFile(@"..\..\..\res\" + pokeEvo.Immagine), new Size(120, 120));
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
                }

                if (numeriEvoluzioni.Count == 0)
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
                if (mapPokedexToGUIList.ContainsKey(p.NumeroPokemon))
                {
                    int index = mapPokedexToGUIList[p.NumeroPokemon];
                    pokedexList.Items[index].SubItems[2].Text = status;
                }
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
        }
    }
}