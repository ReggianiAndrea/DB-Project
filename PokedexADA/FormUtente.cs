using Microsoft.EntityFrameworkCore;
using PokedexADA.PokedexADA;
using System.Linq;
using System.Net.NetworkInformation;

namespace PokedexADA
{
    public partial class FormUtente : Form
    {
        Dictionary<int, int> mapPokedexToGUIList = new Dictionary<int, int>();

        Giocatore giocatore;
        Giocatore? giocatoreSelezionato;
        EsemplarePokemon? pokemonTrovato;

        private Button? btnMostraShinyGiocatore;

        public FormUtente(int idGiocatore)
        {
            using var db = new PokedexAdaContext();
            try
            {
                giocatore = db.Giocatores.Where(go => go.IdGiocatore == idGiocatore).First();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Giocatore non valido... Chiusura applicazione");
                Application.Exit();
            }

            InitializeComponent();
            amiciList.SelectedIndexChanged += amiciList_SelectedIndexChanged;

            InizializzaControlliDinamici();
            battagliaTab.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

            GeneraPannelloStatistiche();

            pokemonDisponibiliBox.SelectedIndex = 0;
            pokemonDisponibiliBox.Items.AddRange(db.Pokemons.Select(p => p.Nome).ToArray());

            foreach (Pokemon p in db.Pokemons.OrderBy(pk => pk.NumeroPokemon))
            {
                var item = new ListViewItem(new[] { p.NumeroPokemon.ToString(), p.Nome, "" });
                pokedexList.Items.Add(item);
                mapPokedexToGUIList.Add(p.NumeroPokemon, pokedexList.Items.Count - 1);
            }

            var amicizie = giocatore.GetListaAmici();
            foreach (Amicizia a in amicizie)
            {
                int idAmico;
                if (a.IdGiocatore == giocatore.IdGiocatore)
                {
                    idAmico = a.IdGiocatoreAmico;
                }
                else
                {
                    idAmico = a.IdGiocatore;
                }
                using var db2 = new PokedexAdaContext();
                Giocatore g = db2.Giocatores.Where(g => g.IdGiocatore == idAmico).First();
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

                pokedexFiltraPerColoreComboBox.Items.AddRange(new[] { "Tutti", "Rosso", "Blu", "Verde", "Giallo", "Marrone", "Viola", "Nero", "Bianco" });
                pokedexFiltraPerColoreComboBox.SelectedIndex = 0;

                pokedexFiltraPerAbilitaComboBox.Items.Add("Tutti");
                pokedexFiltraPerAbilitaComboBox.Items.AddRange(db.Abilita.Select(a => a.NomeAbilita).ToArray());
                pokedexFiltraPerAbilitaComboBox.SelectedIndex = 0;

                pokedexFiltraPerBiomaComboBox.Items.Add("Tutti");
                pokedexFiltraPerBiomaComboBox.Items.AddRange(db.Biomas.Select(b => b.Habitat).ToArray());
                pokedexFiltraPerBiomaComboBox.SelectedIndex = 0;

                pokedexFiltraPerMossaComboBox.Items.Add("Tutti");
                pokedexFiltraPerMossaComboBox.Items.AddRange(db.Mossas.Select(m => m.NomeMossa).ToArray());
                pokedexFiltraPerMossaComboBox.SelectedIndex = 0;

                pokedexFiltraPerMetodoEvolutivoComboBox.Items.Add("Tutti");
                pokedexFiltraPerMetodoEvolutivoComboBox.Items.AddRange(db.MetodoEvolutivos.Select(m => m.Nome).ToArray());
                pokedexFiltraPerMetodoEvolutivoComboBox.SelectedIndex = 0;
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
                List<string> amiciLista = new List<string>();
                foreach (Amicizia a in giocatore.GetListaAmici())
                {
                    int idAmico;
                    if (a.IdGiocatore == giocatore.IdGiocatore)
                    {
                        idAmico = a.IdGiocatoreAmico;
                    }
                    else
                    {
                        idAmico = a.IdGiocatore;
                    }
                    using var db2 = new PokedexAdaContext();
                    Giocatore g = db2.Giocatores.Where(g => g.IdGiocatore == idAmico).First();
                    amiciLista.Add(g.Nickname);
                }

                avversarioComboBox.Items.Clear();
                avversarioComboBox.Items.AddRange(amiciLista.ToArray());
                if (avversarioComboBox.Items.Count > 0)
                {
                    avversarioComboBox.SelectedIndex = 0;
                }
                storicoBattaglieListView.Items.Clear();
                foreach (Battaglia b in giocatore.GetStoricoBattaglie())
                {
                    int idAvversario = b.IdGiocatoreSfidante == giocatore.IdGiocatore ? b.IdGiocatoreSfidato : b.IdGiocatoreSfidante;
                    string nicknameAvversario = db.Giocatores.Where(g => g.IdGiocatore == idAvversario).Select(g => g.Nickname).First();
                    bool vittoria;
                    if (b.IdGiocatoreSfidante == giocatore.IdGiocatore)
                    {
                        vittoria = b.SfidanteVincitore;
                    }
                    else
                    {
                        vittoria = !b.SfidanteVincitore;
                    }
                    storicoBattaglieListView.Items.Add(new ListViewItem(new[] { nicknameAvversario, vittoria ? "Vittoria" : "Sconfitta", b.Luogo, b.Data.ToString() }));
                }
            }
            else if (battagliaTab.SelectedTab == personalizzaUtenteTabPage)
            {
                using var db = new PokedexAdaContext();
                string image = db.Giocatores.Where(g => g.IdGiocatore == giocatore.IdGiocatore).Select(g => g.Immagine).First();
                if (File.Exists(@"..\..\..\res\" + image))
                {
                    cambiaImmagineProfiloPictureBox.Image = new Bitmap(@"..\..\..\res\" + image);
                }
                else
                {
                    cambiaImmagineProfiloPictureBox.Image = new Bitmap(@"..\..\..\res\questionmark.png");
                }
                if (giocatore.IdEsemplarePreferito != null)
                {
                    string immaginePreferito = (from p in db.Pokemons
                                                join ep in db.EsemplarePokemons on p.NumeroPokemon equals ep.NumeroPokemon
                                                where ep.IdEsemplare == giocatore.IdEsemplarePreferito
                                                select p.Immagine).First();
                    cambiaPokemonPreferitoPictureBox.Image = new Bitmap(@"..\..\..\res\" + immaginePreferito);
                    bool esemplareShiny = db.EsemplarePokemons.Where(ep => ep.IdEsemplare == giocatore.IdEsemplarePreferito).Select(ep => ep.Cromatico).First();
                    profiloCromaticoLabel.Text = esemplareShiny ? "\u2728" : "";
                }
                else
                {
                    cambiaPokemonPreferitoPictureBox.Image = new Bitmap(@"..\..\..\res\questionmark.png");
                }

                List<int> esemplari = (from ep in db.EsemplarePokemons
                                       where giocatore.IdGiocatore == ep.IdGiocatoreProprietario
                                       select ep.IdEsemplare).ToList();
                scegliPokemonPreferitoComboBox.Items.Clear();
                foreach (int esemplare in esemplari){
                    scegliPokemonPreferitoComboBox.Items.Add(esemplare.ToString());
                }
            }
        }

        private void CercaPokemonButtonOnClick(object sender, EventArgs e)
        {
            if (pokemonDisponibiliBox.SelectedItem == null)
            {
                MessageBox.Show("Scelta invalida", "Attenzione", MessageBoxButtons.OK);
                return;
            }
            int id;
            using var db = new PokedexAdaContext();
            if (pokemonDisponibiliBox.SelectedItem.ToString() == "Qualsiasi")
            {
                id = new Random().Next(db.Pokemons.Count());
            }
            else
            {
                id = pokemonDisponibiliBox.SelectedIndex - 1;
            }
            Pokemon pokemon = db.Pokemons.ElementAt(id);
            giocatore.Incontra(pokemon.NumeroPokemon);
            pokemonTrovato = TrovaPokemon(pokemon);
            outputBox.Text = $"{giocatore.Nickname} ha incontrato {pokemon.Nome}" + (pokemonTrovato.Cromatico ? " shiny!" : "") + "\n";
            outputBox.Text += $"Dettagli:\n - Livello: {pokemonTrovato.Livello}\n - Sesso: {pokemonTrovato.Sesso}\n";
            tentaCatturaButton.Enabled = true;
        }

        private EsemplarePokemon TrovaPokemon(Pokemon pokemon)
        {
            using var db = new PokedexAdaContext();
            EsemplarePokemon esemplareTrovato;
            Random rand = new Random(DateTime.Now.Second);
            esemplareTrovato = new EsemplarePokemon();
            esemplareTrovato.Cromatico = shinyCheckBox.Checked;
            esemplareTrovato.NumeroPokemon = pokemon.NumeroPokemon;
            esemplareTrovato.Sesso = rand.Next(2) == 0 ? "M" : "F";
            esemplareTrovato.Livello = rand.Next(10, 35);
            return esemplareTrovato;
        }

        private void TentaCatturaButtonOnClick(object sender, EventArgs e)
        {
            if (pokemonTrovato == null)
                return;
            using var db = new PokedexAdaContext();
            double catchRate = 0.5;
            int id = pokemonDisponibiliBox.SelectedIndex;
            Pokemon pokemon = db.Pokemons.Where(p => p.NumeroPokemon == pokemonTrovato.NumeroPokemon).First();
            bool catturato = giocatore.TentaCattura(pokemonTrovato, catchRate);
            if (catturato)
            {
                outputBox.Text += $"{giocatore.Nickname} ha catturato {pokemon.Nome}\n";
                tentaCatturaButton.Enabled = false;
                pokemonTrovato = null;
            }
            else
            {
                outputBox.Text += $"{giocatore.Nickname} ha fallito la cattura di {pokemon.Nome}\n";
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
            Bitmap picture = new Bitmap(@"..\..\..\res\" + pokemon.Immagine);
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
            List<Pokemon> pokemonVisti = giocatore.GetPokemonIncontrati();
            List<Pokemon> pokemonCatturati = giocatore.GetPokemonCatturati();
            bool visto = pokemonVisti.Where(p => p.NumeroPokemon == pokemon.NumeroPokemon).Any();
            bool catturato = pokemonCatturati.Where(p => p.NumeroPokemon == pokemon.NumeroPokemon).Any();
            if (!visto)
            {
                pokedexPicture.Image = new Bitmap(@"..\..\..\res\questionmark.png");
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
                totale = statistiche.Totale.ToString();
                puntiSalute = statistiche.PuntiSalute.ToString();
                attacco = statistiche.Attacco.ToString();
                difesa = statistiche.Difesa.ToString();
                attaccoSpeciale = statistiche.AttaccoSpeciale.ToString();
                difesaSpeciale = statistiche.DifesaSpeciale.ToString();
                velocita = statistiche.Velocita.ToString();

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
                    Bitmap image = new Bitmap(Image.FromFile(@"..\..\..\res\" + corrente.Immagine), 60, 60);
                    Bitmap imageEvo = new Bitmap(Image.FromFile(@"..\..\..\res\" + successivo.Immagine), 60, 60);
                    if (!corrVisto) image = new Bitmap(Image.FromFile(@"..\..\..\res\questionmark.png"), 60, 60);
                    if (corrVisto && !corrCatturato) image = filterPicture(image);
                    if (!evoVisto) imageEvo = new Bitmap(Image.FromFile(@"..\..\..\res\questionmark.png"), 60, 60);
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
            for (int i = 0; i < giocatore.GetListaAmici().Count(); i++)
            {
                Amicizia a = giocatore.GetListaAmici().ElementAt(i);
                int idAmico;
                if (a.IdGiocatore == giocatore.IdGiocatore)
                {
                    idAmico = a.IdGiocatoreAmico;
                }
                else
                {
                    idAmico = a.IdGiocatore;
                }
                Giocatore g = db.Giocatores.Where(g => g.IdGiocatore == idAmico).First();
                if (i < amiciList.Items.Count)
                {
                    amiciList.Items[i].SubItems[0].Text = g.Nickname;
                    amiciList.Items[i].SubItems[1].Text = a.Bloccato ? "bloccato" : "";
                }
            }
            var classificaShiny = (from g in db.Giocatores
                                   where g.NumeroCromatici > 0
                                   orderby g.NumeroCromatici descending
                                   select g).ToList();

            listShiny.Items.Clear();
            foreach (var s in classificaShiny)
            {
                listShiny.Items.Add(new ListViewItem(new[] { s.Nickname, s.NumeroCromatici.ToString() }));
            }
            if (classificaShiny.Count == 0)
            {
                listShiny.Items.Add(new ListViewItem(new[] { "Nessuno", "0" }));
            }

            var classificaPokemonPreferiti = (from p in db.Pokemons
                                              where p.NumeroSceltePreferito > 0
                                              orderby p.NumeroSceltePreferito descending
                                              select p).ToList();

            pokemonPreferitiComuniListView.Items.Clear();
            foreach (var s in classificaPokemonPreferiti)
            {
                pokemonPreferitiComuniListView.Items.Add(new ListViewItem(new[] { s.Nome, s.NumeroSceltePreferito.ToString() }));
            }
            if (classificaPokemonPreferiti.Count == 0)
            {
                pokemonPreferitiComuniListView.Items.Add(new ListViewItem(new[] { "Nessuno", "0" }));
            }

            var classificaPokemonCatturati = (from p in db.Giocatores
                                              where p.NumeroCatturati > 0
                                              orderby p.NumeroCatturati descending
                                              select p).ToList();

            numeroCatturatiListView.Items.Clear();
            foreach (var s in classificaPokemonCatturati)
            {
                numeroCatturatiListView.Items.Add(new ListViewItem(new[] { s.Nome, s.NumeroCatturati.ToString() }));
            }
            if (classificaPokemonCatturati.Count == 0)
            {
                numeroCatturatiListView.Items.Add(new ListViewItem(new[] { "Nessuno", "0" }));
            }
        }

        private void SelezionaPokedex()
        {
            using var db = new PokedexAdaContext();

            pokedexPicture.Image = new Bitmap(pokedexPicture.Width, pokedexPicture.Height);
            pokedexList.SelectedItems.Clear();
            pokedexList.Items.Clear();
            mapPokedexToGUIList.Clear();
            CaricaPokedexFiltrato(filtroNomeTextBox.Text, filtroElementoComboBox.SelectedItem?.ToString() ?? "Tutti");
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

            if (amico == null)
            {
                cercaGiocatoreFallitaLabel.Text = "Giocatore non trovato";
                return;
            }

            if (File.Exists(@"..\..\..\res\" + amico.Immagine))
            {
                cercaGiocatorePictureBox.Image = new Bitmap(@"..\..\..\res\" + amico.Immagine);
            }
            else
            {
                cercaGiocatorePictureBox.Image = new Bitmap(@"..\..\..\res\questionmark.png");
            }
            using var db = new PokedexAdaContext();
            if (amico.IdEsemplarePreferito != null)
            {
                Pokemon preferito = (from p in db.Pokemons
                                     join ep in db.EsemplarePokemons on p.NumeroPokemon equals ep.NumeroPokemon
                                     where ep.IdEsemplare == amico.IdEsemplarePreferito
                                     select p).First();
                bool esemplareShiny = db.EsemplarePokemons.Where(ep => ep.IdEsemplare == amico.IdEsemplarePreferito).Select(ep => ep.Cromatico).First();
                cercaGiocatorePokemonPreferitoPictureBox.Image = new Bitmap(@"..\..\..\res\" + preferito.Immagine);
                amicoCromaticoLabel.Text = esemplareShiny ? "\u2728" : "";
            }
            else
            {
                cercaGiocatorePokemonPreferitoPictureBox.Image = new Bitmap(@"..\..\..\res\questionmark.png");
            }
            cercaGiocatoreGroupBox.Show();
            nomeCercaGiocatoreLabel.Text = $"Nome: {amico.Nome}";
            cognomeCercaGiocatoreLabel.Text = $"Cognome: {amico.Cognome}";
            nicknameCercaGiocatoreLabel.Text = $"Nickname: {amico.Nickname}";

            var datiEsemplari = new List<(int IdEsemplare, int Livello, int NumeroPokemon, bool Cromatico)>();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT IdEsemplare, Livello, NumeroPokemon, Cromatico FROM esemplare_pokemon WHERE IdGiocatoreProprietario = @idAmico AND IdSquadra IS NOT NULL";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@idAmico";
                parameter.Value = amico.IdGiocatore;
                command.Parameters.Add(parameter);

                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    datiEsemplari.Add((reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetBoolean(3)));
                }
            }

            foreach (var p in datiEsemplari)
            {
                string nomePokemon = db.Pokemons
                    .Where(pk => pk.NumeroPokemon == p.NumeroPokemon)
                    .Select(pk => pk.Nome)
                    .FirstOrDefault() ?? "Sconosciuto";

                var item = new ListViewItem(new[] { p.IdEsemplare.ToString(), nomePokemon, p.Livello.ToString(), p.Cromatico ? "\u2728" : "" });
                squadraAmicoListView.Items.Add(item);
            }

            // BOTTONE BOX SHINY
            if (btnMostraShinyGiocatore == null)
            {
                btnMostraShinyGiocatore = new Button
                {
                    Text = "Guarda Box Shiny \u2728", // Simbolo della scintilla
                    AutoSize = true,
                    BackColor = Color.Gold,
                    Cursor = Cursors.Hand
                };
                btnMostraShinyGiocatore.Click += BtnMostraShinyGiocatore_Click;

                // Lo agganciamo allo stesso pannello genitore della lista squadra
                if (squadraAmicoListView.Parent != null)
                {
                    squadraAmicoListView.Parent.Controls.Add(btnMostraShinyGiocatore);
                }
            }

            btnMostraShinyGiocatore.Location = new Point(squadraAmicoListView.Location.X + 250, squadraAmicoListView.Location.Y - 30);
            btnMostraShinyGiocatore.Tag = amico.IdGiocatore; // Salviamo l'ID dell'amico nel bottone
            btnMostraShinyGiocatore.Show();

            var amicizia = giocatore.AmiciziaCon(amico);
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

        // MOSTRA GLI SHINY DEL GIOCATORE
        private void BtnMostraShinyGiocatore_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is int idAmico)
            {
                using var db = new PokedexAdaContext();

                
                var shinyList = (from ep in db.EsemplarePokemons
                                 join p in db.Pokemons on ep.NumeroPokemon equals p.NumeroPokemon
                                 where ep.IdGiocatoreProprietario == idAmico && ep.Cromatico == true
                                 select new { ep.IdEsemplare, SpeciePokemon = p.Nome, ep.NomeAllenatore, ep.Livello, ep.Sesso }).ToList();

                string nomeAmico = db.Giocatores.Where(g => g.IdGiocatore == idAmico).Select(g => g.Nickname).FirstOrDefault() ?? "L'allenatore";

                if (shinyList.Count == 0)
                {
                    MessageBox.Show($"{nomeAmico} non possiede nessun Pokémon Shiny.", "Box Shiny \u2728", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string messaggio = $"I Pokémon Shiny posseduti da {nomeAmico} ({shinyList.Count} esemplari):\n\n";
                foreach (var s in shinyList)
                {
                    messaggio += $"- {s.SpeciePokemon} (ID: {s.IdEsemplare}) | Lvl: {s.Livello} | Sesso: {s.Sesso} | AO: {s.NomeAllenatore}\n";
                }

                MessageBox.Show(messaggio, $"Shiny di {nomeAmico} \u2728", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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

            var query = db.Pokemons.Include(p => p.IdElementoPrimarioNavigation).Include(p => p.IdElementoSecondarioNavigation).AsQueryable();

            if (!string.IsNullOrWhiteSpace(nome))
                query = query.Where(p => p.Nome.Contains(nome) || p.Specie.Contains(nome));

            if (elemento != "Tutti" && !string.IsNullOrWhiteSpace(elemento))
                query = query.Where(p => p.IdElementoPrimarioNavigation.Tipologia == elemento || (p.IdElementoSecondarioNavigation != null && p.IdElementoSecondarioNavigation.Tipologia == elemento));

            string abilita = pokedexFiltraPerAbilitaComboBox.SelectedItem?.ToString() ?? "Tutti";
            if (abilita != "Tutti" && !string.IsNullOrWhiteSpace(abilita))
                query = query.Where(p => p.NomeAbilita == abilita);

            string mossa = pokedexFiltraPerMossaComboBox.SelectedItem?.ToString() ?? "Tutti";
            if (mossa != "Tutti" && !string.IsNullOrWhiteSpace(mossa))
                query = query.Where(p => p.NomeMossas.Select(m => m.NomeMossa).Contains(mossa));

            string colore = pokedexFiltraPerColoreComboBox.SelectedItem?.ToString() ?? "Tutti";
            if (colore != "Tutti" && !string.IsNullOrWhiteSpace(colore))
                query = query.Where(p => p.ColoreDominante == colore);

            string bioma = pokedexFiltraPerBiomaComboBox.SelectedItem?.ToString() ?? "Tutti";
            if (bioma != "Tutti" && !string.IsNullOrWhiteSpace(bioma))
                query = query.Where(p => p.IdBiomas.Select(b => b.Habitat).Contains(bioma));

            string metodo = pokedexFiltraPerMetodoEvolutivoComboBox.SelectedItem?.ToString() ?? "Tutti";
            if (metodo != "Tutti" && !string.IsNullOrWhiteSpace(metodo))
                query = query.Where(p => db.MetodoEvolutivos
                    .Where(m => p.EvoluzioneNumeroPokemonStadioSuccessivoNavigation != null && m.IdMetodo == p.EvoluzioneNumeroPokemonStadioSuccessivoNavigation.IdMetodo)
                    .Select(m => m.Nome)
                    .Contains(metodo)
                );


            var filtrati = query.OrderBy(p => p.NumeroPokemon).ToList();
            var visti = giocatore.GetPokemonIncontrati();
            var catturati = giocatore.GetPokemonCatturati();

            foreach (var p in filtrati)
            {
                bool visto = visti.Select(p => p.NumeroPokemon).Contains(p.NumeroPokemon);
                bool catturato = catturati.Select(p => p.NumeroPokemon).Contains(p.NumeroPokemon);
                string nomePokemon = visto ? p.Nome : "???";
                string status = catturato ? "\u00A9" : (visto ? "\u25CB" : "");
                var item = new ListViewItem(new[] { p.NumeroPokemon.ToString(), nomePokemon, status });
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
            pokedexFiltraPerAbilitaComboBox.SelectedIndex = 0;
            pokedexFiltraPerMossaComboBox.SelectedIndex = 0;
            pokedexFiltraPerColoreComboBox.SelectedIndex = 0;
            pokedexFiltraPerBiomaComboBox.SelectedIndex = 0;
            pokedexFiltraPerMetodoEvolutivoComboBox.SelectedIndex = 0;
            CaricaPokedexFiltrato("", "Tutti");
        }

        private void AggiornaVisteSquadraEBox()
        {
            boxListView.Items.Clear();
            squadraListView.Items.Clear();

            using var db = new PokedexAdaContext();

            var esemplariGrezzi = new List<(int IdEsemplare, int Livello, int NumeroPokemon, int? IdSquadra, bool Cromatico)>();

            using (var command = db.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "SELECT IdEsemplare, Livello, NumeroPokemon, IdSquadra, Cromatico FROM esemplare_pokemon WHERE IdGiocatoreProprietario = @idGiocatore";

                var parameter = command.CreateParameter();
                parameter.ParameterName = "@idGiocatore";
                parameter.Value = giocatore.IdGiocatore;
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
                    bool cromatico = reader.GetBoolean(4);

                    esemplariGrezzi.Add((idEs, livello, numeroPoke, idSquadra, cromatico));
                }
            }

            foreach (var e in esemplariGrezzi)
            {
                string nomePokemon = db.Pokemons
                    .Where(pk => pk.NumeroPokemon == e.NumeroPokemon)
                    .Select(pk => pk.Nome)
                    .FirstOrDefault() ?? "Sconosciuto";

                var item = new ListViewItem(new[] { e.IdEsemplare.ToString(), nomePokemon, e.Livello.ToString(), e.Cromatico ? "\u2728" : "" });
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
                // Il giocatore attuale ha almeno un Pokémon in squadra?
                if (!HaPokemonInSquadra(giocatore.IdGiocatore))
                {
                    MessageBox.Show("Non puoi lottare! Devi avere almeno un Pokémon nella tua squadra attiva.", "La tua Squadra è vuota", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                if (!HaPokemonInSquadra(avversario.IdGiocatore))
                {
                    MessageBox.Show($"L'allenatore {avversario.Nickname} non ha una squadra attiva (0 Pokémon pronti) e non può lottare!", "Avversario non pronto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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

                        storicoBattaglieListView.Items.Add(new ListViewItem(new[] { nicknameAvversario, hoVinto ? "Vittoria" : "Sconfitta", luogo, DateTime.Now.ToString() }));
                    }
                    else
                    {
                        MessageBox.Show($"L'allenatore {avversario.Nickname} non ha una squadra attiva, forse è ancora un principiante e non può lottare!", "Impossibile sfidare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    // Estraiamo errore generato dal db
                    string erroreReale = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                    MessageBox.Show($"L'inserimento della battaglia è fallito.\nErrore tecnico: {erroreReale}", "Dettaglio Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GeneraPannelloStatistiche()
        {
            // richiesta al DB
            using (var db = new PokedexAdaContext())
            {
                // Classifica Colori 
                var coloriComuni = db.Pokemons
                    .Select(p => p.ColoreDominante)
                    .AsEnumerable()
                    .Where(c => !string.IsNullOrWhiteSpace(c))
                    .GroupBy(c => c)
                    .Select(g => new { Colore = g.Key, Conteggio = g.Count() })
                    .OrderByDescending(x => x.Conteggio)
                    .Take(5)
                    .ToList();

                foreach (var c in coloriComuni)
                {
                    listColori.Items.Add(new ListViewItem(new[] { c.Colore, c.Conteggio.ToString() }));
                }

                // Classifica Metodi Evolutivi
                var tuttiMetodi = db.MetodoEvolutivos.ToList();
                var idMetodiUtilizzati = db.Pokemons
                    .Where(p => p.EvoluzioneNumeroPokemonStadioSuccessivoNavigation != null)
                    .Select(p => p.EvoluzioneNumeroPokemonStadioSuccessivoNavigation.IdMetodo)
                    .ToList();

                var metodiComuni = idMetodiUtilizzati
                    .GroupBy(id => id)
                    .Select(g => new
                    {
                        Metodo = tuttiMetodi.FirstOrDefault(m => m.IdMetodo == g.Key)?.Nome ?? "Ignoto",
                        Conteggio = g.Count()
                    })
                    .OrderByDescending(x => x.Conteggio)
                    .Take(5)
                    .ToList();

                foreach (var m in metodiComuni)
                {
                    listMetodi.Items.Add(new ListViewItem(new[] { m.Metodo, m.Conteggio.ToString() }));
                }
            }
        }

        private bool HaPokemonInSquadra(int idAllenatore)
        {
            using var db = new PokedexAdaContext();
            using var command = db.Database.GetDbConnection().CreateCommand();

            // Conta quanti esemplari possiede il giocatore
            command.CommandText = "SELECT COUNT(*) FROM esemplare_pokemon WHERE IdGiocatoreProprietario = @id AND IdSquadra IS NOT NULL";

            var parameter = command.CreateParameter();
            parameter.ParameterName = "@id";
            parameter.Value = idAllenatore;
            command.Parameters.Add(parameter);

            if (command.Connection.State != System.Data.ConnectionState.Open)
                command.Connection.Open();

            var result = command.ExecuteScalar();
            int conteggio = Convert.ToInt32(result);

            return conteggio > 0;
        }

        private void scegliImmagineProfiloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scegliImmagineProfiloComboBox.SelectedIndex == -1)
            {
                scegliImmagineProfiloComboBox.SelectedIndex = 0;
            }
            anteprimaImmagineProfiloPictureBox.Image = new Bitmap(@"..\..\..\res\trainer" + (scegliImmagineProfiloComboBox.SelectedIndex + 1) + ".png");
        }

        private void cambiaImmagineProfiloButton_Click(object sender, EventArgs e)
        {
            if (anteprimaImmagineProfiloPictureBox.Image == null)
            {
                MessageBox.Show("Seleziona un immagine", "Attenzione", MessageBoxButtons.OK);
                return;
            }
            cambiaImmagineProfiloPictureBox.Image = anteprimaImmagineProfiloPictureBox.Image;
            giocatore.CambiaImmagineProfilo("trainer" + (scegliImmagineProfiloComboBox.SelectedIndex + 1) + ".png");
        }

        private void scegliPokemonPreferitoComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scegliPokemonPreferitoComboBox.SelectedItem == null)
            {
                return;
            }
            using var db = new PokedexAdaContext();
            Pokemon preferito = (from p in db.Pokemons
                                 join ep in db.EsemplarePokemons on p.NumeroPokemon equals ep.NumeroPokemon
                                 where ep.IdEsemplare == Int32.Parse(scegliPokemonPreferitoComboBox.SelectedItem.ToString())
                                 select p).First();

            anteprimaPokemonPreferitoPictureBox.Image = new Bitmap(@"..\..\..\res\" + preferito.Immagine);
        }

        private void cambiaPokemonPreferitoButton_Click(object sender, EventArgs e)
        {
            if (anteprimaPokemonPreferitoPictureBox.Image == null || scegliPokemonPreferitoComboBox.SelectedItem == null)
            {
                MessageBox.Show("Seleziona un immagine", "Attenzione", MessageBoxButtons.OK);
                return;
            }
            cambiaPokemonPreferitoPictureBox.Image = anteprimaPokemonPreferitoPictureBox.Image;
            giocatore.CambiaPokemonPreferito(Int32.Parse(scegliPokemonPreferitoComboBox.SelectedItem.ToString()));
            using var db = new PokedexAdaContext();
            bool esemplareShiny = db.EsemplarePokemons.Where(ep => ep.IdEsemplare == Int32.Parse(scegliPokemonPreferitoComboBox.SelectedItem.ToString())).Select(ep => ep.Cromatico).First();
            profiloCromaticoLabel.Text = esemplareShiny ? "\u2728" : "";
        }
    }
}