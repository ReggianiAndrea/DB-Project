using Microsoft.EntityFrameworkCore;
using PokedexADA.PokedexADA;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PokedexADA
{
    public partial class FormAdmin : Form
    {
        private TabControl tabPrincipale;
        private TabPage tabAmicizie;
        private TabPage tabPokemon;
        private DataGridView grigliaDati;
        private FlowLayoutPanel pannelloBottoni;

        public FormAdmin()
        {
            InitializeComponent();
            InizializzaInterfacciaDinamica();
        }

        private void InizializzaInterfacciaDinamica()
        {
            this.Text = "Pannello di Amministrazione Pokedex";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            tabPrincipale = new TabControl { Dock = DockStyle.Top, Height = 30 };
            tabAmicizie = new TabPage("Gestione Blocchi (Amicizie)");
            tabPokemon = new TabPage("Catalogo Pokémon");

            tabPrincipale.TabPages.Add(tabAmicizie);
            tabPrincipale.TabPages.Add(tabPokemon);
            tabPrincipale.SelectedIndexChanged += TabPrincipale_SelectedIndexChanged;

            grigliaDati = new DataGridView
            {
                Location = new Point(20, 40),
                Size = new Size(750, 480),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            pannelloBottoni = new FlowLayoutPanel
            {
                Location = new Point(780, 40),
                Size = new Size(180, 480),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            this.Controls.Add(tabPrincipale);
            this.Controls.Add(grigliaDati);
            this.Controls.Add(pannelloBottoni);

            CaricaDatiAmicizie();
        }

        private void TabPrincipale_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (tabPrincipale.SelectedTab == tabAmicizie) CaricaDatiAmicizie();
            else if (tabPrincipale.SelectedTab == tabPokemon) CaricaDatiPokemon();
        }

        private void AddParam(System.Data.Common.DbCommand cmd, string name, object? val)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = val ?? DBNull.Value;
            cmd.Parameters.Add(p);
        }

        // --- GESTIONE BLOCCHI/AMICIZIE ---
        private void CaricaDatiAmicizie()
        {
            pannelloBottoni.Controls.Clear();

            using var db = new PokedexAdaContext();
            var amicizie = db.Amicizia.Select(a => new
            {
                ID_Giocatore1 = a.IdGiocatore,
                ID_Giocatore2 = a.IdGiocatoreAmico,
                Stato_Bloccato = a.Bloccato ? "Sì" : "No"
            }).ToList();

            grigliaDati.DataSource = amicizie;

            Button btnInvertiBlocco = CreaBottoneDinamico("Inverti Stato Blocco", Color.Orange);
            btnInvertiBlocco.Click += BtnInvertiBlocco_Click;
            pannelloBottoni.Controls.Add(btnInvertiBlocco);
        }

        private void BtnInvertiBlocco_Click(object? sender, EventArgs e)
        {
            if (grigliaDati.SelectedRows.Count == 0) return;

            int id1 = (int)grigliaDati.SelectedRows[0].Cells["ID_Giocatore1"].Value;
            int id2 = (int)grigliaDati.SelectedRows[0].Cells["ID_Giocatore2"].Value;
            bool attualmenteBloccato = grigliaDati.SelectedRows[0].Cells["Stato_Bloccato"].Value.ToString() == "Sì";

            using var db = new PokedexAdaContext();
            var comandoSQL = "UPDATE amicizia SET bloccato = @stato WHERE idgiocatore = @id1 AND idgiocatoreamico = @id2";

            using var command = db.Database.GetDbConnection().CreateCommand();
            command.CommandText = comandoSQL;

            AddParam(command, "@stato", !attualmenteBloccato ? 1 : 0);
            AddParam(command, "@id1", id1);
            AddParam(command, "@id2", id2);

            if (command.Connection.State != ConnectionState.Open) command.Connection.Open();
            command.ExecuteNonQuery();

            MessageBox.Show("Stato utente aggiornato con successo.", "Amministratore");
            CaricaDatiAmicizie();
        }

        private void CaricaDatiPokemon()
        {
            pannelloBottoni.Controls.Clear();

            using var db = new PokedexAdaContext();
            var pokemon = db.Pokemons.Select(p => new
            {
                Numero = p.NumeroPokemon,
                Nome = p.Nome,
                Specie = p.Specie,
                Abilità = p.NomeAbilita
            }).ToList();

            grigliaDati.DataSource = pokemon;

            Button btnInserisci = CreaBottoneDinamico("Aggiungi Pokémon", Color.LightGreen);
            btnInserisci.Click += BtnAggiungiPokemon_Click;

            Button btnElimina = CreaBottoneDinamico("Elimina Selezionato", Color.LightCoral);
            btnElimina.Click += BtnEliminaPokemon_Click;

            pannelloBottoni.Controls.Add(btnInserisci);
            pannelloBottoni.Controls.Add(btnElimina);
        }

        private void BtnAggiungiPokemon_Click(object? sender, EventArgs e)
        {
            using (FormInserimentoPokemon formInserimento = new FormInserimentoPokemon())
            {
                if (formInserimento.ShowDialog() == DialogResult.OK)
                {
                    CaricaDatiPokemon();
                }
            }
        }

        private void BtnEliminaPokemon_Click(object? sender, EventArgs e)
        {
            if (grigliaDati.SelectedRows.Count == 0) return;

            int numeroPKMN = (int)grigliaDati.SelectedRows[0].Cells["Numero"].Value;
            string nomePKMN = grigliaDati.SelectedRows[0].Cells["Nome"].Value.ToString();

            var dialog = MessageBox.Show($"Sei sicuro di voler eliminare {nomePKMN}? Verranno rimossi avvistamenti e dipendenze.", "Conferma Eliminazione Forzata", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                using var db = new PokedexAdaContext();
                try
                {
                    using var command = db.Database.GetDbConnection().CreateCommand();
                    command.CommandText = @"
                        UPDATE giocatore SET IdEsemplarePreferito = NULL WHERE IdEsemplarePreferito IN (SELECT IdEsemplare FROM esemplare_pokemon WHERE NumeroPokemon = @id);
                        DELETE FROM acquisizione WHERE NumeroPokemon = @id;
                        DELETE FROM avvistamento WHERE NumeroPokemon = @id;
                        DELETE FROM cattura WHERE NumeroPokemon = @id;
                        DELETE FROM permanenza WHERE NumeroPokemon = @id;
                        DELETE FROM evoluzione WHERE NumeroPokemonStadioCorrente = @id OR NumeroPokemonStadioSuccessivo = @id;
                        DELETE FROM esemplare_pokemon WHERE NumeroPokemon = @id;
                        DELETE FROM pokemon WHERE NumeroPokemon = @id;
                    ";
                    AddParam(command, "@id", numeroPKMN);

                    if (command.Connection.State != ConnectionState.Open) command.Connection.Open();
                    command.ExecuteNonQuery();

                    MessageBox.Show($"{nomePKMN} eliminato con successo.", "Operazione Riuscita");
                    CaricaDatiPokemon();
                }
                catch (Exception ex) { MessageBox.Show($"Errore:\n{ex.Message}", "Errore Interno", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private Button CreaBottoneDinamico(string testo, Color coloreSfondo)
        {
            return new Button { Text = testo, BackColor = coloreSfondo, Width = 160, Height = 45, Margin = new Padding(5), Cursor = Cursors.Hand, FlatStyle = FlatStyle.Flat };
        }
    }

    public class FormInserimentoPokemon : Form
    {
        private NumericUpDown numPokedex, numPS, numAtk, numDif, numVel;
        private TextBox txtNome, txtSpecie, txtDescrizione;
        private ComboBox cmbElemento, cmbAbilita;
        private Button btnSalva, btnAnnulla;

        public FormInserimentoPokemon()
        {
            this.Text = "Inserisci un nuovo Pokémon";
            this.Size = new Size(400, 550);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            TableLayoutPanel pannello = new TableLayoutPanel { Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 10, Padding = new Padding(10) };
            pannello.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            pannello.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));

            numPokedex = new NumericUpDown { Maximum = 9999, Minimum = 1, Width = 200 };
            txtNome = new TextBox { Width = 200 };
            txtSpecie = new TextBox { Width = 200 };
            txtDescrizione = new TextBox { Width = 200 };
            cmbElemento = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbAbilita = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };

            numPS = new NumericUpDown { Maximum = 300, Width = 80 };
            numAtk = new NumericUpDown { Maximum = 300, Width = 80 };
            numDif = new NumericUpDown { Maximum = 300, Width = 80 };
            numVel = new NumericUpDown { Maximum = 300, Width = 80 };

            CaricaDatiTendine();

            pannello.Controls.Add(new Label { Text = "Numero Pokédex:", Anchor = AnchorStyles.Left }, 0, 0);
            pannello.Controls.Add(numPokedex, 1, 0);
            pannello.Controls.Add(new Label { Text = "Nome:", Anchor = AnchorStyles.Left }, 0, 1);
            pannello.Controls.Add(txtNome, 1, 1);
            pannello.Controls.Add(new Label { Text = "Specie:", Anchor = AnchorStyles.Left }, 0, 2);
            pannello.Controls.Add(txtSpecie, 1, 2);
            pannello.Controls.Add(new Label { Text = "Elemento Primario:", Anchor = AnchorStyles.Left }, 0, 3);
            pannello.Controls.Add(cmbElemento, 1, 3);
            pannello.Controls.Add(new Label { Text = "Abilità:", Anchor = AnchorStyles.Left }, 0, 4);
            pannello.Controls.Add(cmbAbilita, 1, 4);
            pannello.Controls.Add(new Label { Text = "Descrizione:", Anchor = AnchorStyles.Left }, 0, 5);
            pannello.Controls.Add(txtDescrizione, 1, 5);

            FlowLayoutPanel panelStats = new FlowLayoutPanel { Dock = DockStyle.Fill };
            panelStats.Controls.Add(new Label { Text = "PS:" }); panelStats.Controls.Add(numPS);
            panelStats.Controls.Add(new Label { Text = "ATK:" }); panelStats.Controls.Add(numAtk);
            panelStats.Controls.Add(new Label { Text = "DIF:" }); panelStats.Controls.Add(numDif);
            panelStats.Controls.Add(new Label { Text = "VEL:" }); panelStats.Controls.Add(numVel);

            pannello.Controls.Add(new Label { Text = "Statistiche Base:", Anchor = AnchorStyles.Left }, 0, 6);
            pannello.Controls.Add(panelStats, 1, 6);

            btnSalva = new Button { Text = "Salva", BackColor = Color.LightGreen, DialogResult = DialogResult.None };
            btnSalva.Click += BtnSalva_Click;
            btnAnnulla = new Button { Text = "Annulla", DialogResult = DialogResult.Cancel };

            FlowLayoutPanel panelBottoni = new FlowLayoutPanel { Dock = DockStyle.Fill, FlowDirection = FlowDirection.RightToLeft };
            panelBottoni.Controls.Add(btnAnnulla);
            panelBottoni.Controls.Add(btnSalva);

            pannello.Controls.Add(panelBottoni, 1, 8);
            this.Controls.Add(pannello);
        }

        private void CaricaDatiTendine()
        {
            using var db = new PokedexAdaContext();
            var elementi = db.Elementos.ToList();
            cmbElemento.DataSource = elementi;
            cmbElemento.DisplayMember = "Tipologia";
            cmbElemento.ValueMember = "IdElemento";

            var abilita = db.Abilita.Select(a => a.NomeAbilita).ToList();
            cmbAbilita.DataSource = abilita;
        }

        private void AddParam(System.Data.Common.DbCommand cmd, string name, object? val)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = name;
            p.Value = val ?? DBNull.Value;
            cmd.Parameters.Add(p);
        }

        private void BtnSalva_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtSpecie.Text))
            {
                MessageBox.Show("Nome e Specie sono obbligatori!", "Errore validazione");
                return;
            }

            int totaleStats = (int)(numPS.Value + numAtk.Value + numDif.Value + numVel.Value + 100);

            using var db = new PokedexAdaContext();

            try
            {
                if (db.Database.GetDbConnection().State != ConnectionState.Open)
                    db.Database.GetDbConnection().Open();


                using var cmdId = db.Database.GetDbConnection().CreateCommand();
                cmdId.CommandText = "SELECT COALESCE(MAX(IdStatistiche), 0) + 1 FROM set_statistiche;";
                int nextStatId = Convert.ToInt32(cmdId.ExecuteScalar());

                using var cmdStats = db.Database.GetDbConnection().CreateCommand();
                cmdStats.CommandText = @"
                    INSERT INTO set_statistiche (idstatistiche, puntisalute, attacco, difesa, attaccospeciale, difesaspeciale, velocita, totale) 
                    VALUES (@nextId, @ps, @atk, @dif, 50, 50, @vel, @totale);";

                AddParam(cmdStats, "@nextId", nextStatId);
                AddParam(cmdStats, "@ps", (int)numPS.Value);
                AddParam(cmdStats, "@atk", (int)numAtk.Value);
                AddParam(cmdStats, "@dif", (int)numDif.Value);
                AddParam(cmdStats, "@vel", (int)numVel.Value);
                AddParam(cmdStats, "@totale", totaleStats);

                cmdStats.ExecuteNonQuery(); 
                using var cmdPkmn = db.Database.GetDbConnection().CreateCommand();
                cmdPkmn.CommandText = @"
                    INSERT INTO pokemon (
                        numeropokemon, specie, nome, descrizionepokemon, altezza, peso, impronta, immagine, 
                        coloredominante, idelementoprimario, idstatistiche, nomeabilita
                    ) VALUES (
                        @num, @specie, @nome, @desc, 1.0, 10.0, 'Bestia', 'questionmark.png', 
                        'Ignoto', @idElemento, @nextId, @abilita
                    );";

                AddParam(cmdPkmn, "@num", (int)numPokedex.Value);
                AddParam(cmdPkmn, "@specie", txtSpecie.Text);
                AddParam(cmdPkmn, "@nome", txtNome.Text);
                AddParam(cmdPkmn, "@desc", txtDescrizione.Text);
                AddParam(cmdPkmn, "@idElemento", cmbElemento.SelectedValue);
                AddParam(cmdPkmn, "@nextId", nextStatId); // Colleghiamo lo stesso ID di prima
                AddParam(cmdPkmn, "@abilita", cmbAbilita.SelectedItem?.ToString());

                cmdPkmn.ExecuteNonQuery(); // Esegue il secondo inserimento

                // Se arriva fin qui senza errori, diamo l'ok per chiudere la finestra e aggiornare la griglia
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Impossibile salvare.\nErrore tecnico: {ex.Message}", "Errore Salvataggio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}