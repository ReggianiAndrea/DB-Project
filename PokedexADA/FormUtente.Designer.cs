using System.Drawing.Text;
using System.Windows.Forms;

namespace PokedexADA
{
    partial class FormUtente
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            visualizzaAmici = new TabPage();
            boxShiny = new GroupBox();
            listShiny = new ListView();
            columnHeader11 = new ColumnHeader();
            columnHeader12 = new ColumnHeader();
            cercaGiocatoreFallitaLabel = new Label();
            cercaGiocatoreButton = new Button();
            cercaGiocatoreGroupBox = new GroupBox();
            amicoCromaticoLabel = new Label();
            labelSquadraAmico = new Label();
            squadraAmicoListView = new ListView();
            id = new ColumnHeader();
            name = new ColumnHeader();
            level = new ColumnHeader();
            columnHeader13 = new ColumnHeader();
            pokemonPreferitoCercaGiocatoreLabel = new Label();
            cercaGiocatorePokemonPreferitoPictureBox = new PictureBox();
            cercaGiocatoreRimuoviButton = new Button();
            cercaGiocatoreSbloccaButton = new Button();
            cercaGiocatoreBloccaButton = new Button();
            cercaGiocatoreAggiungiButton = new Button();
            cercaGiocatorePictureBox = new PictureBox();
            nicknameCercaGiocatoreLabel = new Label();
            cognomeCercaGiocatoreLabel = new Label();
            nomeCercaGiocatoreLabel = new Label();
            cercaGiocatoreTextBox = new TextBox();
            cercaGiocatoreLabel = new Label();
            amiciList = new ListView();
            amico = new ColumnHeader();
            bloccato = new ColumnHeader();
            visualizzaPokedex = new TabPage();
            pokedexFiltraPerAbilitaLabel = new Label();
            pokedexFiltraPerColoreLabel = new Label();
            pokedexFiltraPerMossaLabel = new Label();
            pokedexFiltraPerColoreComboBox = new ComboBox();
            pokedexFiltraPerMossaComboBox = new ComboBox();
            pokedexFiltraPerAbilitaComboBox = new ComboBox();
            pokedexFiltraPerBiomaComboBox = new ComboBox();
            pokedexFiltraPerBiomaLabel = new Label();
            pokedexFiltraPerMetodoEvolutivoComboBox = new ComboBox();
            pokedexFiltraPerMetodoEvolutivoLabel = new Label();
            pokedexFiltraPerTipoLabel = new Label();
            pokedexFIltraPerNomeLabel = new Label();
            pokedexFiltraLabel = new Label();
            filtroNomeTextBox = new TextBox();
            filtroElementoComboBox = new ComboBox();
            applicaFiltroButton = new Button();
            resetFiltroButton = new Button();
            lineaEvolutivaPokemonLayout = new TableLayoutPanel();
            label1 = new Label();
            abilitaPokemonLabel = new Label();
            biomaPokemonLabel = new Label();
            mossePokemonLabel = new Label();
            mossePokemonListView = new ListView();
            Nome = new ColumnHeader();
            Elemento = new ColumnHeader();
            Danno = new ColumnHeader();
            Precisione = new ColumnHeader();
            Descrizione = new ColumnHeader();
            descrizionePokemonTextBox = new RichTextBox();
            statistichePokemonTotaleLabel = new Label();
            statistichePokemonVelocitaLabel = new Label();
            statistichePokemonDifesaSpecialeLabel = new Label();
            statistichePokemonAttaccoSpecialeLabel = new Label();
            statistichePokemonDifesaLabel = new Label();
            statistichePokemonAttaccoLabel = new Label();
            statistichePokemonPuntiSaluteLabel = new Label();
            statistichePokemonLabel = new Label();
            elementiPokemonLabel = new Label();
            descrizionePokemonLabel = new Label();
            improntaPokemonLabel = new Label();
            pesoPokemonLabel = new Label();
            altezzaPokemonLabel = new Label();
            speciePokemonLabel = new Label();
            pokemonLabel = new Label();
            pokedexPicture = new PictureBox();
            pokedexList = new ListView();
            ids = new ColumnHeader();
            names = new ColumnHeader();
            captured = new ColumnHeader();
            pannelloStat = new GroupBox();
            lblColori = new Label();
            lblMetodi = new Label();
            listColori = new ListView();
            columnHeader7 = new ColumnHeader();
            columnHeader8 = new ColumnHeader();
            listMetodi = new ListView();
            columnHeader9 = new ColumnHeader();
            columnHeader10 = new ColumnHeader();
            cercaECattura = new TabPage();
            panel2 = new Panel();
            outputBox = new RichTextBox();
            panel1 = new Panel();
            shinyCheckBox = new CheckBox();
            selezionaPokemonLabel = new Label();
            tentaCatturaButton = new Button();
            pokemonDisponibiliBox = new ComboBox();
            cercaPokemonButton = new Button();
            battagliaTab = new TabControl();
            gestisciSquadraTab = new TabPage();
            labelBox = new Label();
            labelSquadra = new Label();
            boxListView = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader15 = new ColumnHeader();
            squadraListView = new ListView();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            columnHeader14 = new ColumnHeader();
            spostaInSquadraButton = new Button();
            spostaInBoxButton = new Button();
            battagliaTabPage = new TabPage();
            label3 = new Label();
            storicoBattaglieListView = new ListView();
            columnHeader16 = new ColumnHeader();
            columnHeader17 = new ColumnHeader();
            columnHeader18 = new ColumnHeader();
            columnHeader19 = new ColumnHeader();
            avversarioLabel = new Label();
            avversarioComboBox = new ComboBox();
            luogoLabel = new Label();
            luogoBattagliaComboBox = new ComboBox();
            cercaGiocatoreSfidaButton = new Button();
            personalizzaUtenteTabPage = new TabPage();
            profiloCromaticoLabel = new Label();
            label2 = new Label();
            anteprimaPokemonPreferitoPictureBox = new PictureBox();
            anteprimaImmagineProfiloPictureBox = new PictureBox();
            pokemonPreferitoLabel = new Label();
            immagineProfiloLabel = new Label();
            scegliPokemonPreferitoLabel = new Label();
            scegliImmagineProfiloLabel = new Label();
            scegliPokemonPreferitoComboBox = new ComboBox();
            scegliImmagineProfiloComboBox = new ComboBox();
            cambiaPokemonPreferitoButton = new Button();
            cambiaImmagineProfiloButton = new Button();
            cambiaPokemonPreferitoPictureBox = new PictureBox();
            cambiaImmagineProfiloPictureBox = new PictureBox();
            visualizzaAmici.SuspendLayout();
            boxShiny.SuspendLayout();
            cercaGiocatoreGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePokemonPreferitoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePictureBox).BeginInit();
            visualizzaPokedex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).BeginInit();
            pannelloStat.SuspendLayout();
            cercaECattura.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            battagliaTab.SuspendLayout();
            gestisciSquadraTab.SuspendLayout();
            battagliaTabPage.SuspendLayout();
            personalizzaUtenteTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)anteprimaPokemonPreferitoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)anteprimaImmagineProfiloPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cambiaPokemonPreferitoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cambiaImmagineProfiloPictureBox).BeginInit();
            SuspendLayout();
            // 
            // visualizzaAmici
            // 
            visualizzaAmici.Controls.Add(boxShiny);
            visualizzaAmici.Controls.Add(cercaGiocatoreFallitaLabel);
            visualizzaAmici.Controls.Add(cercaGiocatoreButton);
            visualizzaAmici.Controls.Add(cercaGiocatoreGroupBox);
            visualizzaAmici.Controls.Add(cercaGiocatoreTextBox);
            visualizzaAmici.Controls.Add(cercaGiocatoreLabel);
            visualizzaAmici.Controls.Add(amiciList);
            visualizzaAmici.Location = new Point(4, 24);
            visualizzaAmici.Name = "visualizzaAmici";
            visualizzaAmici.Size = new Size(1121, 625);
            visualizzaAmici.TabIndex = 2;
            visualizzaAmici.Text = "Visualizza Amici";
            visualizzaAmici.UseVisualStyleBackColor = true;
            // 
            // boxShiny
            // 
            boxShiny.Controls.Add(listShiny);
            boxShiny.Location = new Point(853, 64);
            boxShiny.Name = "boxShiny";
            boxShiny.Size = new Size(260, 553);
            boxShiny.TabIndex = 0;
            boxShiny.TabStop = false;
            boxShiny.Text = "Allenatori con Pokémon Shiny ";
            // 
            // listShiny
            // 
            listShiny.Columns.AddRange(new ColumnHeader[] { columnHeader11, columnHeader12 });
            listShiny.Dock = DockStyle.Fill;
            listShiny.FullRowSelect = true;
            listShiny.GridLines = true;
            listShiny.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listShiny.Location = new Point(3, 19);
            listShiny.Name = "listShiny";
            listShiny.Size = new Size(254, 531);
            listShiny.TabIndex = 0;
            listShiny.UseCompatibleStateImageBehavior = false;
            listShiny.View = View.Details;
            // 
            // columnHeader11
            // 
            columnHeader11.Text = "Shiny";
            columnHeader11.Width = 130;
            // 
            // columnHeader12
            // 
            columnHeader12.Text = "Qt.";
            // 
            // cercaGiocatoreFallitaLabel
            // 
            cercaGiocatoreFallitaLabel.AutoSize = true;
            cercaGiocatoreFallitaLabel.Location = new Point(591, 37);
            cercaGiocatoreFallitaLabel.Margin = new Padding(2, 0, 2, 0);
            cercaGiocatoreFallitaLabel.Name = "cercaGiocatoreFallitaLabel";
            cercaGiocatoreFallitaLabel.Size = new Size(0, 15);
            cercaGiocatoreFallitaLabel.TabIndex = 7;
            // 
            // cercaGiocatoreButton
            // 
            cercaGiocatoreButton.Location = new Point(618, 37);
            cercaGiocatoreButton.Margin = new Padding(2);
            cercaGiocatoreButton.Name = "cercaGiocatoreButton";
            cercaGiocatoreButton.Size = new Size(88, 23);
            cercaGiocatoreButton.TabIndex = 6;
            cercaGiocatoreButton.Text = "Cerca";
            cercaGiocatoreButton.UseVisualStyleBackColor = true;
            cercaGiocatoreButton.Click += cercaGiocatoreButton_Click;
            // 
            // cercaGiocatoreGroupBox
            // 
            cercaGiocatoreGroupBox.Controls.Add(amicoCromaticoLabel);
            cercaGiocatoreGroupBox.Controls.Add(labelSquadraAmico);
            cercaGiocatoreGroupBox.Controls.Add(squadraAmicoListView);
            cercaGiocatoreGroupBox.Controls.Add(pokemonPreferitoCercaGiocatoreLabel);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatorePokemonPreferitoPictureBox);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatoreRimuoviButton);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatoreSbloccaButton);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatoreBloccaButton);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatoreAggiungiButton);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatorePictureBox);
            cercaGiocatoreGroupBox.Controls.Add(nicknameCercaGiocatoreLabel);
            cercaGiocatoreGroupBox.Controls.Add(cognomeCercaGiocatoreLabel);
            cercaGiocatoreGroupBox.Controls.Add(nomeCercaGiocatoreLabel);
            cercaGiocatoreGroupBox.Location = new Point(451, 64);
            cercaGiocatoreGroupBox.Margin = new Padding(2);
            cercaGiocatoreGroupBox.Name = "cercaGiocatoreGroupBox";
            cercaGiocatoreGroupBox.Padding = new Padding(2);
            cercaGiocatoreGroupBox.Size = new Size(397, 554);
            cercaGiocatoreGroupBox.TabIndex = 3;
            cercaGiocatoreGroupBox.TabStop = false;
            cercaGiocatoreGroupBox.Text = "Giocatore";
            cercaGiocatoreGroupBox.Visible = false;
            // 
            // amicoCromaticoLabel
            // 
            amicoCromaticoLabel.AutoSize = true;
            amicoCromaticoLabel.Location = new Point(260, 160);
            amicoCromaticoLabel.Name = "amicoCromaticoLabel";
            amicoCromaticoLabel.Size = new Size(0, 15);
            amicoCromaticoLabel.TabIndex = 10;
            // 
            // labelSquadraAmico
            // 
            labelSquadraAmico.AutoSize = true;
            labelSquadraAmico.Location = new Point(16, 233);
            labelSquadraAmico.Name = "labelSquadraAmico";
            labelSquadraAmico.Size = new Size(147, 15);
            labelSquadraAmico.TabIndex = 0;
            labelSquadraAmico.Text = "Squadra Attiva dell'Amico:";
            // 
            // squadraAmicoListView
            // 
            squadraAmicoListView.Columns.AddRange(new ColumnHeader[] { id, name, level, columnHeader13 });
            squadraAmicoListView.FullRowSelect = true;
            squadraAmicoListView.GridLines = true;
            squadraAmicoListView.Location = new Point(16, 251);
            squadraAmicoListView.Name = "squadraAmicoListView";
            squadraAmicoListView.Size = new Size(360, 298);
            squadraAmicoListView.TabIndex = 1;
            squadraAmicoListView.UseCompatibleStateImageBehavior = false;
            squadraAmicoListView.View = View.Details;
            // 
            // id
            // 
            id.Text = "ID";
            id.Width = 40;
            // 
            // name
            // 
            name.Text = "Nome";
            name.Width = 130;
            // 
            // level
            // 
            level.Text = "Livello";
            // 
            // columnHeader13
            // 
            columnHeader13.Text = "";
            columnHeader13.Width = 30;
            // 
            // pokemonPreferitoCercaGiocatoreLabel
            // 
            pokemonPreferitoCercaGiocatoreLabel.AutoSize = true;
            pokemonPreferitoCercaGiocatoreLabel.Location = new Point(170, 70);
            pokemonPreferitoCercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            pokemonPreferitoCercaGiocatoreLabel.Name = "pokemonPreferitoCercaGiocatoreLabel";
            pokemonPreferitoCercaGiocatoreLabel.Size = new Size(109, 15);
            pokemonPreferitoCercaGiocatoreLabel.TabIndex = 9;
            pokemonPreferitoCercaGiocatoreLabel.Text = "Pokemon preferito:";
            // 
            // cercaGiocatorePokemonPreferitoPictureBox
            // 
            cercaGiocatorePokemonPreferitoPictureBox.Location = new Point(170, 90);
            cercaGiocatorePokemonPreferitoPictureBox.Margin = new Padding(2);
            cercaGiocatorePokemonPreferitoPictureBox.Name = "cercaGiocatorePokemonPreferitoPictureBox";
            cercaGiocatorePokemonPreferitoPictureBox.Size = new Size(85, 85);
            cercaGiocatorePokemonPreferitoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            cercaGiocatorePokemonPreferitoPictureBox.TabIndex = 8;
            cercaGiocatorePokemonPreferitoPictureBox.TabStop = false;
            // 
            // cercaGiocatoreRimuoviButton
            // 
            cercaGiocatoreRimuoviButton.Location = new Point(16, 186);
            cercaGiocatoreRimuoviButton.Margin = new Padding(2);
            cercaGiocatoreRimuoviButton.Name = "cercaGiocatoreRimuoviButton";
            cercaGiocatoreRimuoviButton.Size = new Size(95, 40);
            cercaGiocatoreRimuoviButton.TabIndex = 7;
            cercaGiocatoreRimuoviButton.Text = "Rimuovi amico";
            cercaGiocatoreRimuoviButton.UseVisualStyleBackColor = true;
            cercaGiocatoreRimuoviButton.Visible = false;
            cercaGiocatoreRimuoviButton.Click += cercaGiocatoreRimuoviButton_Click;
            // 
            // cercaGiocatoreSbloccaButton
            // 
            cercaGiocatoreSbloccaButton.Location = new Point(117, 186);
            cercaGiocatoreSbloccaButton.Margin = new Padding(2);
            cercaGiocatoreSbloccaButton.Name = "cercaGiocatoreSbloccaButton";
            cercaGiocatoreSbloccaButton.Size = new Size(95, 40);
            cercaGiocatoreSbloccaButton.TabIndex = 6;
            cercaGiocatoreSbloccaButton.Text = "Sblocca";
            cercaGiocatoreSbloccaButton.UseVisualStyleBackColor = true;
            cercaGiocatoreSbloccaButton.Visible = false;
            cercaGiocatoreSbloccaButton.Click += cercaGiocatoreSbloccaButton_Click;
            // 
            // cercaGiocatoreBloccaButton
            // 
            cercaGiocatoreBloccaButton.Location = new Point(117, 186);
            cercaGiocatoreBloccaButton.Margin = new Padding(2);
            cercaGiocatoreBloccaButton.Name = "cercaGiocatoreBloccaButton";
            cercaGiocatoreBloccaButton.Size = new Size(95, 40);
            cercaGiocatoreBloccaButton.TabIndex = 5;
            cercaGiocatoreBloccaButton.Text = "Blocca";
            cercaGiocatoreBloccaButton.UseVisualStyleBackColor = true;
            cercaGiocatoreBloccaButton.Visible = false;
            cercaGiocatoreBloccaButton.Click += cercaGiocatoreBloccaButton_Click;
            // 
            // cercaGiocatoreAggiungiButton
            // 
            cercaGiocatoreAggiungiButton.Location = new Point(16, 186);
            cercaGiocatoreAggiungiButton.Margin = new Padding(2);
            cercaGiocatoreAggiungiButton.Name = "cercaGiocatoreAggiungiButton";
            cercaGiocatoreAggiungiButton.Size = new Size(95, 40);
            cercaGiocatoreAggiungiButton.TabIndex = 4;
            cercaGiocatoreAggiungiButton.Text = "Aggiungi come amico";
            cercaGiocatoreAggiungiButton.UseVisualStyleBackColor = true;
            cercaGiocatoreAggiungiButton.Visible = false;
            cercaGiocatoreAggiungiButton.Click += cercaGiocatoreAggiungiButton_Click;
            // 
            // cercaGiocatorePictureBox
            // 
            cercaGiocatorePictureBox.Location = new Point(16, 25);
            cercaGiocatorePictureBox.Margin = new Padding(2);
            cercaGiocatorePictureBox.Name = "cercaGiocatorePictureBox";
            cercaGiocatorePictureBox.Size = new Size(150, 150);
            cercaGiocatorePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            cercaGiocatorePictureBox.TabIndex = 3;
            cercaGiocatorePictureBox.TabStop = false;
            // 
            // nicknameCercaGiocatoreLabel
            // 
            nicknameCercaGiocatoreLabel.AutoSize = true;
            nicknameCercaGiocatoreLabel.Location = new Point(170, 25);
            nicknameCercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            nicknameCercaGiocatoreLabel.Name = "nicknameCercaGiocatoreLabel";
            nicknameCercaGiocatoreLabel.Size = new Size(64, 15);
            nicknameCercaGiocatoreLabel.TabIndex = 2;
            nicknameCercaGiocatoreLabel.Text = "Nickname:";
            // 
            // cognomeCercaGiocatoreLabel
            // 
            cognomeCercaGiocatoreLabel.AutoSize = true;
            cognomeCercaGiocatoreLabel.Location = new Point(170, 55);
            cognomeCercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            cognomeCercaGiocatoreLabel.Name = "cognomeCercaGiocatoreLabel";
            cognomeCercaGiocatoreLabel.Size = new Size(63, 15);
            cognomeCercaGiocatoreLabel.TabIndex = 1;
            cognomeCercaGiocatoreLabel.Text = "Cognome:";
            // 
            // nomeCercaGiocatoreLabel
            // 
            nomeCercaGiocatoreLabel.AutoSize = true;
            nomeCercaGiocatoreLabel.Location = new Point(170, 40);
            nomeCercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            nomeCercaGiocatoreLabel.Name = "nomeCercaGiocatoreLabel";
            nomeCercaGiocatoreLabel.Size = new Size(43, 15);
            nomeCercaGiocatoreLabel.TabIndex = 0;
            nomeCercaGiocatoreLabel.Text = "Nome:";
            // 
            // cercaGiocatoreTextBox
            // 
            cercaGiocatoreTextBox.Location = new Point(451, 37);
            cercaGiocatoreTextBox.Margin = new Padding(2);
            cercaGiocatoreTextBox.Name = "cercaGiocatoreTextBox";
            cercaGiocatoreTextBox.Size = new Size(163, 23);
            cercaGiocatoreTextBox.TabIndex = 2;
            // 
            // cercaGiocatoreLabel
            // 
            cercaGiocatoreLabel.AutoSize = true;
            cercaGiocatoreLabel.Location = new Point(451, 20);
            cercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            cercaGiocatoreLabel.Name = "cercaGiocatoreLabel";
            cercaGiocatoreLabel.Size = new Size(90, 15);
            cercaGiocatoreLabel.TabIndex = 1;
            cercaGiocatoreLabel.Text = "Cerca giocatore";
            // 
            // amiciList
            // 
            amiciList.Columns.AddRange(new ColumnHeader[] { amico, bloccato });
            amiciList.FullRowSelect = true;
            amiciList.GridLines = true;
            amiciList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            amiciList.Location = new Point(8, 8);
            amiciList.Margin = new Padding(2);
            amiciList.Name = "amiciList";
            amiciList.Size = new Size(439, 610);
            amiciList.TabIndex = 0;
            amiciList.UseCompatibleStateImageBehavior = false;
            amiciList.View = View.Details;
            amiciList.SelectedIndexChanged += amiciList_SelectedIndexChanged;
            // 
            // amico
            // 
            amico.Text = "Amico";
            amico.Width = 250;
            // 
            // bloccato
            // 
            bloccato.Text = "";
            bloccato.Width = 100;
            // 
            // visualizzaPokedex
            // 
            visualizzaPokedex.Controls.Add(pokedexFiltraPerAbilitaLabel);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerColoreLabel);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerMossaLabel);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerColoreComboBox);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerMossaComboBox);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerAbilitaComboBox);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerBiomaComboBox);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerBiomaLabel);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerMetodoEvolutivoComboBox);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerMetodoEvolutivoLabel);
            visualizzaPokedex.Controls.Add(pokedexFiltraPerTipoLabel);
            visualizzaPokedex.Controls.Add(pokedexFIltraPerNomeLabel);
            visualizzaPokedex.Controls.Add(pokedexFiltraLabel);
            visualizzaPokedex.Controls.Add(filtroNomeTextBox);
            visualizzaPokedex.Controls.Add(filtroElementoComboBox);
            visualizzaPokedex.Controls.Add(applicaFiltroButton);
            visualizzaPokedex.Controls.Add(resetFiltroButton);
            visualizzaPokedex.Controls.Add(lineaEvolutivaPokemonLayout);
            visualizzaPokedex.Controls.Add(label1);
            visualizzaPokedex.Controls.Add(abilitaPokemonLabel);
            visualizzaPokedex.Controls.Add(biomaPokemonLabel);
            visualizzaPokedex.Controls.Add(mossePokemonLabel);
            visualizzaPokedex.Controls.Add(mossePokemonListView);
            visualizzaPokedex.Controls.Add(descrizionePokemonTextBox);
            visualizzaPokedex.Controls.Add(statistichePokemonTotaleLabel);
            visualizzaPokedex.Controls.Add(statistichePokemonVelocitaLabel);
            visualizzaPokedex.Controls.Add(statistichePokemonDifesaSpecialeLabel);
            visualizzaPokedex.Controls.Add(statistichePokemonAttaccoSpecialeLabel);
            visualizzaPokedex.Controls.Add(statistichePokemonDifesaLabel);
            visualizzaPokedex.Controls.Add(statistichePokemonAttaccoLabel);
            visualizzaPokedex.Controls.Add(statistichePokemonPuntiSaluteLabel);
            visualizzaPokedex.Controls.Add(statistichePokemonLabel);
            visualizzaPokedex.Controls.Add(elementiPokemonLabel);
            visualizzaPokedex.Controls.Add(descrizionePokemonLabel);
            visualizzaPokedex.Controls.Add(improntaPokemonLabel);
            visualizzaPokedex.Controls.Add(pesoPokemonLabel);
            visualizzaPokedex.Controls.Add(altezzaPokemonLabel);
            visualizzaPokedex.Controls.Add(speciePokemonLabel);
            visualizzaPokedex.Controls.Add(pokemonLabel);
            visualizzaPokedex.Controls.Add(pokedexPicture);
            visualizzaPokedex.Controls.Add(pokedexList);
            visualizzaPokedex.Controls.Add(pannelloStat);
            visualizzaPokedex.Location = new Point(4, 24);
            visualizzaPokedex.Name = "visualizzaPokedex";
            visualizzaPokedex.Padding = new Padding(3);
            visualizzaPokedex.Size = new Size(1121, 625);
            visualizzaPokedex.TabIndex = 1;
            visualizzaPokedex.Text = "Visualizza Pokedex";
            visualizzaPokedex.UseVisualStyleBackColor = true;
            // 
            // pokedexFiltraPerAbilitaLabel
            // 
            pokedexFiltraPerAbilitaLabel.AutoSize = true;
            pokedexFiltraPerAbilitaLabel.Location = new Point(262, 511);
            pokedexFiltraPerAbilitaLabel.Name = "pokedexFiltraPerAbilitaLabel";
            pokedexFiltraPerAbilitaLabel.Size = new Size(41, 15);
            pokedexFiltraPerAbilitaLabel.TabIndex = 38;
            pokedexFiltraPerAbilitaLabel.Text = "Abilità";
            // 
            // pokedexFiltraPerColoreLabel
            // 
            pokedexFiltraPerColoreLabel.AutoSize = true;
            pokedexFiltraPerColoreLabel.Location = new Point(135, 467);
            pokedexFiltraPerColoreLabel.Name = "pokedexFiltraPerColoreLabel";
            pokedexFiltraPerColoreLabel.Size = new Size(42, 15);
            pokedexFiltraPerColoreLabel.TabIndex = 37;
            pokedexFiltraPerColoreLabel.Text = "Colore";
            // 
            // pokedexFiltraPerMossaLabel
            // 
            pokedexFiltraPerMossaLabel.AutoSize = true;
            pokedexFiltraPerMossaLabel.Location = new Point(135, 511);
            pokedexFiltraPerMossaLabel.Name = "pokedexFiltraPerMossaLabel";
            pokedexFiltraPerMossaLabel.Size = new Size(41, 15);
            pokedexFiltraPerMossaLabel.TabIndex = 36;
            pokedexFiltraPerMossaLabel.Text = "Mossa";
            // 
            // pokedexFiltraPerColoreComboBox
            // 
            pokedexFiltraPerColoreComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            pokedexFiltraPerColoreComboBox.Location = new Point(135, 485);
            pokedexFiltraPerColoreComboBox.Name = "pokedexFiltraPerColoreComboBox";
            pokedexFiltraPerColoreComboBox.Size = new Size(121, 23);
            pokedexFiltraPerColoreComboBox.TabIndex = 34;
            pokedexFiltraPerColoreComboBox.Tag = "";
            // 
            // pokedexFiltraPerMossaComboBox
            // 
            pokedexFiltraPerMossaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            pokedexFiltraPerMossaComboBox.Location = new Point(135, 529);
            pokedexFiltraPerMossaComboBox.Name = "pokedexFiltraPerMossaComboBox";
            pokedexFiltraPerMossaComboBox.Size = new Size(121, 23);
            pokedexFiltraPerMossaComboBox.TabIndex = 33;
            pokedexFiltraPerMossaComboBox.Tag = "";
            // 
            // pokedexFiltraPerAbilitaComboBox
            // 
            pokedexFiltraPerAbilitaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            pokedexFiltraPerAbilitaComboBox.Location = new Point(262, 529);
            pokedexFiltraPerAbilitaComboBox.Name = "pokedexFiltraPerAbilitaComboBox";
            pokedexFiltraPerAbilitaComboBox.Size = new Size(121, 23);
            pokedexFiltraPerAbilitaComboBox.TabIndex = 31;
            pokedexFiltraPerAbilitaComboBox.Tag = "";
            // 
            // pokedexFiltraPerBiomaComboBox
            // 
            pokedexFiltraPerBiomaComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            pokedexFiltraPerBiomaComboBox.Location = new Point(262, 485);
            pokedexFiltraPerBiomaComboBox.Name = "pokedexFiltraPerBiomaComboBox";
            pokedexFiltraPerBiomaComboBox.Size = new Size(121, 23);
            pokedexFiltraPerBiomaComboBox.TabIndex = 30;
            pokedexFiltraPerBiomaComboBox.Tag = "";
            // 
            // pokedexFiltraPerBiomaLabel
            // 
            pokedexFiltraPerBiomaLabel.AutoSize = true;
            pokedexFiltraPerBiomaLabel.Location = new Point(262, 467);
            pokedexFiltraPerBiomaLabel.Name = "pokedexFiltraPerBiomaLabel";
            pokedexFiltraPerBiomaLabel.Size = new Size(41, 15);
            pokedexFiltraPerBiomaLabel.TabIndex = 29;
            pokedexFiltraPerBiomaLabel.Text = "Bioma";
            // 
            // pokedexFiltraPerMetodoEvolutivoComboBox
            // 
            pokedexFiltraPerMetodoEvolutivoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            pokedexFiltraPerMetodoEvolutivoComboBox.Location = new Point(8, 529);
            pokedexFiltraPerMetodoEvolutivoComboBox.Name = "pokedexFiltraPerMetodoEvolutivoComboBox";
            pokedexFiltraPerMetodoEvolutivoComboBox.Size = new Size(121, 23);
            pokedexFiltraPerMetodoEvolutivoComboBox.TabIndex = 28;
            pokedexFiltraPerMetodoEvolutivoComboBox.Tag = "";
            // 
            // pokedexFiltraPerMetodoEvolutivoLabel
            // 
            pokedexFiltraPerMetodoEvolutivoLabel.AutoSize = true;
            pokedexFiltraPerMetodoEvolutivoLabel.Location = new Point(8, 511);
            pokedexFiltraPerMetodoEvolutivoLabel.Name = "pokedexFiltraPerMetodoEvolutivoLabel";
            pokedexFiltraPerMetodoEvolutivoLabel.Size = new Size(101, 15);
            pokedexFiltraPerMetodoEvolutivoLabel.TabIndex = 27;
            pokedexFiltraPerMetodoEvolutivoLabel.Text = "Metodo evolutivo";
            // 
            // pokedexFiltraPerTipoLabel
            // 
            pokedexFiltraPerTipoLabel.AutoSize = true;
            pokedexFiltraPerTipoLabel.Location = new Point(8, 467);
            pokedexFiltraPerTipoLabel.Name = "pokedexFiltraPerTipoLabel";
            pokedexFiltraPerTipoLabel.Size = new Size(57, 15);
            pokedexFiltraPerTipoLabel.TabIndex = 26;
            pokedexFiltraPerTipoLabel.Text = "Elemento";
            // 
            // pokedexFIltraPerNomeLabel
            // 
            pokedexFIltraPerNomeLabel.AutoSize = true;
            pokedexFIltraPerNomeLabel.Location = new Point(8, 423);
            pokedexFIltraPerNomeLabel.Name = "pokedexFIltraPerNomeLabel";
            pokedexFIltraPerNomeLabel.Size = new Size(40, 15);
            pokedexFIltraPerNomeLabel.TabIndex = 25;
            pokedexFIltraPerNomeLabel.Text = "Nome";
            // 
            // pokedexFiltraLabel
            // 
            pokedexFiltraLabel.AutoSize = true;
            pokedexFiltraLabel.Location = new Point(8, 405);
            pokedexFiltraLabel.Name = "pokedexFiltraLabel";
            pokedexFiltraLabel.Size = new Size(33, 15);
            pokedexFiltraLabel.TabIndex = 24;
            pokedexFiltraLabel.Text = "Filtra";
            // 
            // filtroNomeTextBox
            // 
            filtroNomeTextBox.Location = new Point(8, 441);
            filtroNomeTextBox.Name = "filtroNomeTextBox";
            filtroNomeTextBox.PlaceholderText = "Cerca nome...";
            filtroNomeTextBox.Size = new Size(100, 23);
            filtroNomeTextBox.TabIndex = 0;
            // 
            // filtroElementoComboBox
            // 
            filtroElementoComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            filtroElementoComboBox.Location = new Point(8, 485);
            filtroElementoComboBox.Name = "filtroElementoComboBox";
            filtroElementoComboBox.Size = new Size(121, 23);
            filtroElementoComboBox.TabIndex = 1;
            filtroElementoComboBox.Tag = "";
            // 
            // applicaFiltroButton
            // 
            applicaFiltroButton.Location = new Point(82, 578);
            applicaFiltroButton.Name = "applicaFiltroButton";
            applicaFiltroButton.Size = new Size(75, 23);
            applicaFiltroButton.TabIndex = 2;
            applicaFiltroButton.Text = "Filtra";
            applicaFiltroButton.Click += ApplicaFiltroButton_Click;
            // 
            // resetFiltroButton
            // 
            resetFiltroButton.Location = new Point(235, 578);
            resetFiltroButton.Name = "resetFiltroButton";
            resetFiltroButton.Size = new Size(75, 23);
            resetFiltroButton.TabIndex = 3;
            resetFiltroButton.Text = "Reset";
            resetFiltroButton.Click += ResetFiltroButton_Click;
            // 
            // lineaEvolutivaPokemonLayout
            // 
            lineaEvolutivaPokemonLayout.AutoScroll = true;
            lineaEvolutivaPokemonLayout.ColumnCount = 3;
            lineaEvolutivaPokemonLayout.ColumnStyles.Add(new ColumnStyle());
            lineaEvolutivaPokemonLayout.ColumnStyles.Add(new ColumnStyle());
            lineaEvolutivaPokemonLayout.ColumnStyles.Add(new ColumnStyle());
            lineaEvolutivaPokemonLayout.Location = new Point(736, 23);
            lineaEvolutivaPokemonLayout.Margin = new Padding(2);
            lineaEvolutivaPokemonLayout.Name = "lineaEvolutivaPokemonLayout";
            lineaEvolutivaPokemonLayout.RowCount = 1;
            lineaEvolutivaPokemonLayout.RowStyles.Add(new RowStyle());
            lineaEvolutivaPokemonLayout.Size = new Size(377, 234);
            lineaEvolutivaPokemonLayout.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(736, 6);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 23;
            label1.Text = "Linea evolutiva";
            // 
            // abilitaPokemonLabel
            // 
            abilitaPokemonLabel.AutoSize = true;
            abilitaPokemonLabel.Location = new Point(560, 51);
            abilitaPokemonLabel.Name = "abilitaPokemonLabel";
            abilitaPokemonLabel.Size = new Size(44, 15);
            abilitaPokemonLabel.TabIndex = 21;
            abilitaPokemonLabel.Text = "Abilità:";
            // 
            // biomaPokemonLabel
            // 
            biomaPokemonLabel.AutoSize = true;
            biomaPokemonLabel.Location = new Point(560, 111);
            biomaPokemonLabel.Name = "biomaPokemonLabel";
            biomaPokemonLabel.Size = new Size(44, 15);
            biomaPokemonLabel.TabIndex = 20;
            biomaPokemonLabel.Text = "Bioma:";
            // 
            // mossePokemonLabel
            // 
            mossePokemonLabel.AutoSize = true;
            mossePokemonLabel.Location = new Point(402, 405);
            mossePokemonLabel.Name = "mossePokemonLabel";
            mossePokemonLabel.Size = new Size(41, 15);
            mossePokemonLabel.TabIndex = 19;
            mossePokemonLabel.Text = "Mosse";
            // 
            // mossePokemonListView
            // 
            mossePokemonListView.Columns.AddRange(new ColumnHeader[] { Nome, Elemento, Danno, Precisione, Descrizione });
            mossePokemonListView.FullRowSelect = true;
            mossePokemonListView.GridLines = true;
            mossePokemonListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            mossePokemonListView.Location = new Point(402, 423);
            mossePokemonListView.Name = "mossePokemonListView";
            mossePokemonListView.Size = new Size(711, 194);
            mossePokemonListView.TabIndex = 18;
            mossePokemonListView.UseCompatibleStateImageBehavior = false;
            mossePokemonListView.View = View.Details;
            // 
            // Nome
            // 
            Nome.Text = "Nome";
            Nome.Width = 160;
            // 
            // Elemento
            // 
            Elemento.Text = "Tipo";
            Elemento.Width = 100;
            // 
            // Danno
            // 
            Danno.Text = "Danno";
            Danno.Width = 80;
            // 
            // Precisione
            // 
            Precisione.Text = "Precisione";
            Precisione.Width = 100;
            // 
            // Descrizione
            // 
            Descrizione.Text = "Descrizione";
            Descrizione.Width = 600;
            // 
            // descrizionePokemonTextBox
            // 
            descrizionePokemonTextBox.Location = new Point(329, 263);
            descrizionePokemonTextBox.Name = "descrizionePokemonTextBox";
            descrizionePokemonTextBox.ReadOnly = true;
            descrizionePokemonTextBox.Size = new Size(339, 139);
            descrizionePokemonTextBox.TabIndex = 6;
            descrizionePokemonTextBox.Text = "";
            // 
            // statistichePokemonTotaleLabel
            // 
            statistichePokemonTotaleLabel.AutoSize = true;
            statistichePokemonTotaleLabel.Location = new Point(562, 242);
            statistichePokemonTotaleLabel.Name = "statistichePokemonTotaleLabel";
            statistichePokemonTotaleLabel.Size = new Size(41, 15);
            statistichePokemonTotaleLabel.TabIndex = 17;
            statistichePokemonTotaleLabel.Text = "Totale:";
            // 
            // statistichePokemonVelocitaLabel
            // 
            statistichePokemonVelocitaLabel.AutoSize = true;
            statistichePokemonVelocitaLabel.Location = new Point(560, 227);
            statistichePokemonVelocitaLabel.Name = "statistichePokemonVelocitaLabel";
            statistichePokemonVelocitaLabel.Size = new Size(51, 15);
            statistichePokemonVelocitaLabel.TabIndex = 16;
            statistichePokemonVelocitaLabel.Text = "Velocità:";
            // 
            // statistichePokemonDifesaSpecialeLabel
            // 
            statistichePokemonDifesaSpecialeLabel.AutoSize = true;
            statistichePokemonDifesaSpecialeLabel.Location = new Point(560, 212);
            statistichePokemonDifesaSpecialeLabel.Name = "statistichePokemonDifesaSpecialeLabel";
            statistichePokemonDifesaSpecialeLabel.Size = new Size(87, 15);
            statistichePokemonDifesaSpecialeLabel.TabIndex = 15;
            statistichePokemonDifesaSpecialeLabel.Text = "Difesa speciale:";
            // 
            // statistichePokemonAttaccoSpecialeLabel
            // 
            statistichePokemonAttaccoSpecialeLabel.AutoSize = true;
            statistichePokemonAttaccoSpecialeLabel.Location = new Point(560, 197);
            statistichePokemonAttaccoSpecialeLabel.Name = "statistichePokemonAttaccoSpecialeLabel";
            statistichePokemonAttaccoSpecialeLabel.Size = new Size(96, 15);
            statistichePokemonAttaccoSpecialeLabel.TabIndex = 14;
            statistichePokemonAttaccoSpecialeLabel.Text = "Attacco speciale:";
            // 
            // statistichePokemonDifesaLabel
            // 
            statistichePokemonDifesaLabel.AutoSize = true;
            statistichePokemonDifesaLabel.Location = new Point(560, 182);
            statistichePokemonDifesaLabel.Name = "statistichePokemonDifesaLabel";
            statistichePokemonDifesaLabel.Size = new Size(42, 15);
            statistichePokemonDifesaLabel.TabIndex = 13;
            statistichePokemonDifesaLabel.Text = "Difesa:";
            // 
            // statistichePokemonAttaccoLabel
            // 
            statistichePokemonAttaccoLabel.AutoSize = true;
            statistichePokemonAttaccoLabel.Location = new Point(560, 167);
            statistichePokemonAttaccoLabel.Name = "statistichePokemonAttaccoLabel";
            statistichePokemonAttaccoLabel.Size = new Size(51, 15);
            statistichePokemonAttaccoLabel.TabIndex = 12;
            statistichePokemonAttaccoLabel.Text = "Attacco:";
            // 
            // statistichePokemonPuntiSaluteLabel
            // 
            statistichePokemonPuntiSaluteLabel.AutoSize = true;
            statistichePokemonPuntiSaluteLabel.Location = new Point(560, 152);
            statistichePokemonPuntiSaluteLabel.Name = "statistichePokemonPuntiSaluteLabel";
            statistichePokemonPuntiSaluteLabel.Size = new Size(72, 15);
            statistichePokemonPuntiSaluteLabel.TabIndex = 11;
            statistichePokemonPuntiSaluteLabel.Text = "Punti salute:";
            // 
            // statistichePokemonLabel
            // 
            statistichePokemonLabel.AutoSize = true;
            statistichePokemonLabel.Location = new Point(560, 137);
            statistichePokemonLabel.Name = "statistichePokemonLabel";
            statistichePokemonLabel.Size = new Size(61, 15);
            statistichePokemonLabel.TabIndex = 10;
            statistichePokemonLabel.Text = "Statistiche";
            // 
            // elementiPokemonLabel
            // 
            elementiPokemonLabel.AutoSize = true;
            elementiPokemonLabel.Location = new Point(560, 36);
            elementiPokemonLabel.Name = "elementiPokemonLabel";
            elementiPokemonLabel.Size = new Size(56, 15);
            elementiPokemonLabel.TabIndex = 9;
            elementiPokemonLabel.Text = "Elementi:";
            // 
            // descrizionePokemonLabel
            // 
            descrizionePokemonLabel.AutoSize = true;
            descrizionePokemonLabel.Location = new Point(329, 245);
            descrizionePokemonLabel.Name = "descrizionePokemonLabel";
            descrizionePokemonLabel.Size = new Size(70, 15);
            descrizionePokemonLabel.TabIndex = 8;
            descrizionePokemonLabel.Text = "Descrizione:";
            // 
            // improntaPokemonLabel
            // 
            improntaPokemonLabel.AutoSize = true;
            improntaPokemonLabel.Location = new Point(560, 96);
            improntaPokemonLabel.Name = "improntaPokemonLabel";
            improntaPokemonLabel.Size = new Size(59, 15);
            improntaPokemonLabel.TabIndex = 7;
            improntaPokemonLabel.Text = "Impronta:";
            // 
            // pesoPokemonLabel
            // 
            pesoPokemonLabel.AutoSize = true;
            pesoPokemonLabel.Location = new Point(560, 81);
            pesoPokemonLabel.Name = "pesoPokemonLabel";
            pesoPokemonLabel.Size = new Size(35, 15);
            pesoPokemonLabel.TabIndex = 5;
            pesoPokemonLabel.Text = "Peso:";
            // 
            // altezzaPokemonLabel
            // 
            altezzaPokemonLabel.AutoSize = true;
            altezzaPokemonLabel.Location = new Point(560, 66);
            altezzaPokemonLabel.Name = "altezzaPokemonLabel";
            altezzaPokemonLabel.Size = new Size(47, 15);
            altezzaPokemonLabel.TabIndex = 4;
            altezzaPokemonLabel.Text = "Altezza:";
            // 
            // speciePokemonLabel
            // 
            speciePokemonLabel.AutoSize = true;
            speciePokemonLabel.Location = new Point(560, 21);
            speciePokemonLabel.Name = "speciePokemonLabel";
            speciePokemonLabel.Size = new Size(61, 15);
            speciePokemonLabel.TabIndex = 3;
            speciePokemonLabel.Text = "Pokemon:";
            // 
            // pokemonLabel
            // 
            pokemonLabel.AutoSize = true;
            pokemonLabel.Location = new Point(560, 6);
            pokemonLabel.Name = "pokemonLabel";
            pokemonLabel.Size = new Size(54, 15);
            pokemonLabel.TabIndex = 2;
            pokemonLabel.Text = "Numero:";
            // 
            // pokedexPicture
            // 
            pokedexPicture.Location = new Point(329, 6);
            pokedexPicture.Name = "pokedexPicture";
            pokedexPicture.Size = new Size(225, 225);
            pokedexPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pokedexPicture.TabIndex = 1;
            pokedexPicture.TabStop = false;
            // 
            // pokedexList
            // 
            pokedexList.Columns.AddRange(new ColumnHeader[] { ids, names, captured });
            pokedexList.FullRowSelect = true;
            pokedexList.GridLines = true;
            pokedexList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            pokedexList.Location = new Point(8, 6);
            pokedexList.Name = "pokedexList";
            pokedexList.Size = new Size(317, 396);
            pokedexList.TabIndex = 0;
            pokedexList.UseCompatibleStateImageBehavior = false;
            pokedexList.View = View.Details;
            pokedexList.SelectedIndexChanged += pokedexList_SelectedIndexChanged;
            // 
            // ids
            // 
            ids.Text = "#";
            // 
            // names
            // 
            names.Text = "Name";
            names.Width = 160;
            // 
            // captured
            // 
            captured.Text = "";
            captured.TextAlign = HorizontalAlignment.Center;
            captured.Width = 40;
            // 
            // pannelloStat
            // 
            pannelloStat.Controls.Add(lblColori);
            pannelloStat.Controls.Add(lblMetodi);
            pannelloStat.Controls.Add(listColori);
            pannelloStat.Controls.Add(listMetodi);
            pannelloStat.Location = new Point(674, 263);
            pannelloStat.Name = "pannelloStat";
            pannelloStat.Size = new Size(439, 139);
            pannelloStat.TabIndex = 0;
            pannelloStat.TabStop = false;
            pannelloStat.Text = "Curiosità Pokedex";
            // 
            // lblColori
            // 
            lblColori.AutoSize = true;
            lblColori.Location = new Point(10, 25);
            lblColori.Name = "lblColori";
            lblColori.Size = new Size(106, 15);
            lblColori.TabIndex = 0;
            lblColori.Text = "Colori più comuni:";
            // 
            // lblMetodi
            // 
            lblMetodi.AutoSize = true;
            lblMetodi.Location = new Point(210, 25);
            lblMetodi.Name = "lblMetodi";
            lblMetodi.Size = new Size(160, 15);
            lblMetodi.TabIndex = 0;
            lblMetodi.Text = "Metodi evolutivi più comuni:";
            // 
            // listColori
            // 
            listColori.Columns.AddRange(new ColumnHeader[] { columnHeader7, columnHeader8 });
            listColori.FullRowSelect = true;
            listColori.GridLines = true;
            listColori.Location = new Point(10, 45);
            listColori.Name = "listColori";
            listColori.Size = new Size(185, 88);
            listColori.TabIndex = 0;
            listColori.UseCompatibleStateImageBehavior = false;
            listColori.View = View.Details;
            // 
            // columnHeader7
            // 
            columnHeader7.Text = "Colore";
            columnHeader7.Width = 115;
            // 
            // columnHeader8
            // 
            columnHeader8.Text = "Qt";
            columnHeader8.Width = 45;
            // 
            // listMetodi
            // 
            listMetodi.Columns.AddRange(new ColumnHeader[] { columnHeader9, columnHeader10 });
            listMetodi.FullRowSelect = true;
            listMetodi.GridLines = true;
            listMetodi.Location = new Point(210, 45);
            listMetodi.Name = "listMetodi";
            listMetodi.Size = new Size(215, 88);
            listMetodi.TabIndex = 0;
            listMetodi.UseCompatibleStateImageBehavior = false;
            listMetodi.View = View.Details;
            // 
            // columnHeader9
            // 
            columnHeader9.Text = "Metodo";
            columnHeader9.Width = 145;
            // 
            // columnHeader10
            // 
            columnHeader10.Text = "Qt";
            columnHeader10.Width = 45;
            // 
            // cercaECattura
            // 
            cercaECattura.Controls.Add(panel2);
            cercaECattura.Location = new Point(4, 24);
            cercaECattura.Name = "cercaECattura";
            cercaECattura.Padding = new Padding(3);
            cercaECattura.Size = new Size(1121, 625);
            cercaECattura.TabIndex = 0;
            cercaECattura.Text = "Cerca e cattura";
            cercaECattura.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(outputBox);
            panel2.Controls.Add(panel1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(3, 3);
            panel2.Margin = new Padding(2);
            panel2.Name = "panel2";
            panel2.Size = new Size(1115, 619);
            panel2.TabIndex = 3;
            // 
            // outputBox
            // 
            outputBox.Location = new Point(3, 3);
            outputBox.MinimumSize = new Size(211, 122);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(826, 611);
            outputBox.TabIndex = 0;
            outputBox.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(shinyCheckBox);
            panel1.Controls.Add(selezionaPokemonLabel);
            panel1.Controls.Add(tentaCatturaButton);
            panel1.Controls.Add(pokemonDisponibiliBox);
            panel1.Controls.Add(cercaPokemonButton);
            panel1.Location = new Point(832, 4);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 610);
            panel1.TabIndex = 2;
            // 
            // shinyCheckBox
            // 
            shinyCheckBox.AutoSize = true;
            shinyCheckBox.Location = new Point(4, 49);
            shinyCheckBox.Name = "shinyCheckBox";
            shinyCheckBox.Size = new Size(113, 19);
            shinyCheckBox.TabIndex = 8;
            shinyCheckBox.Text = "Cerca cromatico";
            shinyCheckBox.UseVisualStyleBackColor = true;
            // 
            // selezionaPokemonLabel
            // 
            selezionaPokemonLabel.AutoSize = true;
            selezionaPokemonLabel.Location = new Point(4, 2);
            selezionaPokemonLabel.Margin = new Padding(2, 0, 2, 0);
            selezionaPokemonLabel.Name = "selezionaPokemonLabel";
            selezionaPokemonLabel.Size = new Size(110, 15);
            selezionaPokemonLabel.TabIndex = 7;
            selezionaPokemonLabel.Text = "Seleziona pokemon";
            // 
            // tentaCatturaButton
            // 
            tentaCatturaButton.Enabled = false;
            tentaCatturaButton.Location = new Point(4, 103);
            tentaCatturaButton.Name = "tentaCatturaButton";
            tentaCatturaButton.Size = new Size(113, 40);
            tentaCatturaButton.TabIndex = 5;
            tentaCatturaButton.Text = "Tenta cattura";
            tentaCatturaButton.UseVisualStyleBackColor = true;
            tentaCatturaButton.Click += TentaCatturaButtonOnClick;
            // 
            // pokemonDisponibiliBox
            // 
            pokemonDisponibiliBox.FormattingEnabled = true;
            pokemonDisponibiliBox.Items.AddRange(new object[] { "Qualsiasi" });
            pokemonDisponibiliBox.Location = new Point(4, 20);
            pokemonDisponibiliBox.Name = "pokemonDisponibiliBox";
            pokemonDisponibiliBox.Size = new Size(113, 23);
            pokemonDisponibiliBox.TabIndex = 4;
            // 
            // cercaPokemonButton
            // 
            cercaPokemonButton.Location = new Point(4, 74);
            cercaPokemonButton.Name = "cercaPokemonButton";
            cercaPokemonButton.Size = new Size(113, 23);
            cercaPokemonButton.TabIndex = 6;
            cercaPokemonButton.Text = "Cerca Pokemon";
            cercaPokemonButton.UseVisualStyleBackColor = true;
            cercaPokemonButton.Click += CercaPokemonButtonOnClick;
            // 
            // battagliaTab
            // 
            battagliaTab.Controls.Add(cercaECattura);
            battagliaTab.Controls.Add(visualizzaPokedex);
            battagliaTab.Controls.Add(visualizzaAmici);
            battagliaTab.Controls.Add(gestisciSquadraTab);
            battagliaTab.Controls.Add(battagliaTabPage);
            battagliaTab.Controls.Add(personalizzaUtenteTabPage);
            battagliaTab.Dock = DockStyle.Fill;
            battagliaTab.Location = new Point(0, 0);
            battagliaTab.Name = "battagliaTab";
            battagliaTab.SelectedIndex = 0;
            battagliaTab.Size = new Size(1129, 653);
            battagliaTab.TabIndex = 7;
            // 
            // gestisciSquadraTab
            // 
            gestisciSquadraTab.Controls.Add(labelBox);
            gestisciSquadraTab.Controls.Add(labelSquadra);
            gestisciSquadraTab.Controls.Add(boxListView);
            gestisciSquadraTab.Controls.Add(squadraListView);
            gestisciSquadraTab.Controls.Add(spostaInSquadraButton);
            gestisciSquadraTab.Controls.Add(spostaInBoxButton);
            gestisciSquadraTab.Location = new Point(4, 24);
            gestisciSquadraTab.Name = "gestisciSquadraTab";
            gestisciSquadraTab.Size = new Size(1121, 625);
            gestisciSquadraTab.TabIndex = 1;
            gestisciSquadraTab.Text = "Gestisci Squadra";
            // 
            // labelBox
            // 
            labelBox.AutoSize = true;
            labelBox.Location = new Point(3, 8);
            labelBox.Name = "labelBox";
            labelBox.Size = new Size(81, 15);
            labelBox.TabIndex = 0;
            labelBox.Text = "Box Pokemon";
            // 
            // labelSquadra
            // 
            labelSquadra.AutoSize = true;
            labelSquadra.Location = new Point(593, 11);
            labelSquadra.Name = "labelSquadra";
            labelSquadra.Size = new Size(84, 15);
            labelSquadra.TabIndex = 1;
            labelSquadra.Text = "Squadra Attiva";
            // 
            // boxListView
            // 
            boxListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader15 });
            boxListView.FullRowSelect = true;
            boxListView.GridLines = true;
            boxListView.Location = new Point(3, 26);
            boxListView.Name = "boxListView";
            boxListView.Size = new Size(320, 596);
            boxListView.TabIndex = 2;
            boxListView.UseCompatibleStateImageBehavior = false;
            boxListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Nome";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Livello";
            columnHeader3.Width = 80;
            // 
            // columnHeader15
            // 
            columnHeader15.Text = "";
            columnHeader15.Width = 30;
            // 
            // squadraListView
            // 
            squadraListView.Columns.AddRange(new ColumnHeader[] { columnHeader4, columnHeader5, columnHeader6, columnHeader14 });
            squadraListView.FullRowSelect = true;
            squadraListView.GridLines = true;
            squadraListView.Location = new Point(593, 29);
            squadraListView.Name = "squadraListView";
            squadraListView.Size = new Size(320, 596);
            squadraListView.TabIndex = 3;
            squadraListView.UseCompatibleStateImageBehavior = false;
            squadraListView.View = View.Details;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "ID";
            columnHeader4.Width = 40;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Nome";
            columnHeader5.Width = 150;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Livello";
            columnHeader6.Width = 80;
            // 
            // columnHeader14
            // 
            columnHeader14.Text = "";
            columnHeader14.Width = 30;
            // 
            // spostaInSquadraButton
            // 
            spostaInSquadraButton.Location = new Point(462, 365);
            spostaInSquadraButton.Name = "spostaInSquadraButton";
            spostaInSquadraButton.Size = new Size(99, 49);
            spostaInSquadraButton.TabIndex = 4;
            spostaInSquadraButton.Text = "Aggiungi a Squadra ->";
            spostaInSquadraButton.Click += SpostaInSquadraButton_Click;
            // 
            // spostaInBoxButton
            // 
            spostaInBoxButton.Location = new Point(356, 365);
            spostaInBoxButton.Name = "spostaInBoxButton";
            spostaInBoxButton.Size = new Size(100, 49);
            spostaInBoxButton.TabIndex = 5;
            spostaInBoxButton.Text = "<- Sposta nel Box";
            spostaInBoxButton.Click += SpostaInBoxButton_Click;
            // 
            // battagliaTabPage
            // 
            battagliaTabPage.Controls.Add(label3);
            battagliaTabPage.Controls.Add(storicoBattaglieListView);
            battagliaTabPage.Controls.Add(avversarioLabel);
            battagliaTabPage.Controls.Add(avversarioComboBox);
            battagliaTabPage.Controls.Add(luogoLabel);
            battagliaTabPage.Controls.Add(luogoBattagliaComboBox);
            battagliaTabPage.Controls.Add(cercaGiocatoreSfidaButton);
            battagliaTabPage.Location = new Point(4, 24);
            battagliaTabPage.Name = "battagliaTabPage";
            battagliaTabPage.Size = new Size(1121, 625);
            battagliaTabPage.TabIndex = 0;
            battagliaTabPage.Text = "Battaglia";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(412, 17);
            label3.Name = "label3";
            label3.Size = new Size(93, 15);
            label3.TabIndex = 6;
            label3.Text = "Storico battaglie";
            // 
            // storicoBattaglieListView
            // 
            storicoBattaglieListView.Columns.AddRange(new ColumnHeader[] { columnHeader16, columnHeader17, columnHeader18, columnHeader19 });
            storicoBattaglieListView.GridLines = true;
            storicoBattaglieListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            storicoBattaglieListView.Location = new Point(412, 35);
            storicoBattaglieListView.Name = "storicoBattaglieListView";
            storicoBattaglieListView.Size = new Size(405, 582);
            storicoBattaglieListView.TabIndex = 5;
            storicoBattaglieListView.UseCompatibleStateImageBehavior = false;
            storicoBattaglieListView.View = View.Details;
            // 
            // columnHeader16
            // 
            columnHeader16.Text = "Avversario";
            columnHeader16.Width = 120;
            // 
            // columnHeader17
            // 
            columnHeader17.Text = "Risultato";
            // 
            // columnHeader18
            // 
            columnHeader18.Text = "Luogo";
            // 
            // columnHeader19
            // 
            columnHeader19.Text = "Data";
            columnHeader19.Width = 150;
            // 
            // avversarioLabel
            // 
            avversarioLabel.Location = new Point(8, 14);
            avversarioLabel.Name = "avversarioLabel";
            avversarioLabel.Size = new Size(95, 18);
            avversarioLabel.TabIndex = 0;
            avversarioLabel.Text = "Scegli avversario";
            // 
            // avversarioComboBox
            // 
            avversarioComboBox.Location = new Point(8, 35);
            avversarioComboBox.Name = "avversarioComboBox";
            avversarioComboBox.Size = new Size(121, 23);
            avversarioComboBox.TabIndex = 1;
            // 
            // luogoLabel
            // 
            luogoLabel.Location = new Point(8, 61);
            luogoLabel.Name = "luogoLabel";
            luogoLabel.Size = new Size(73, 15);
            luogoLabel.TabIndex = 2;
            luogoLabel.Text = "Scegli luogo";
            // 
            // luogoBattagliaComboBox
            // 
            luogoBattagliaComboBox.Location = new Point(8, 79);
            luogoBattagliaComboBox.Name = "luogoBattagliaComboBox";
            luogoBattagliaComboBox.Size = new Size(121, 23);
            luogoBattagliaComboBox.TabIndex = 3;
            // 
            // cercaGiocatoreSfidaButton
            // 
            cercaGiocatoreSfidaButton.Location = new Point(8, 108);
            cercaGiocatoreSfidaButton.Name = "cercaGiocatoreSfidaButton";
            cercaGiocatoreSfidaButton.Size = new Size(121, 36);
            cercaGiocatoreSfidaButton.TabIndex = 4;
            cercaGiocatoreSfidaButton.Text = "Sfida giocatore!";
            cercaGiocatoreSfidaButton.Click += CercaGiocatoreSfidaButton_Click;
            // 
            // personalizzaUtenteTabPage
            // 
            personalizzaUtenteTabPage.Controls.Add(profiloCromaticoLabel);
            personalizzaUtenteTabPage.Controls.Add(label2);
            personalizzaUtenteTabPage.Controls.Add(anteprimaPokemonPreferitoPictureBox);
            personalizzaUtenteTabPage.Controls.Add(anteprimaImmagineProfiloPictureBox);
            personalizzaUtenteTabPage.Controls.Add(pokemonPreferitoLabel);
            personalizzaUtenteTabPage.Controls.Add(immagineProfiloLabel);
            personalizzaUtenteTabPage.Controls.Add(scegliPokemonPreferitoLabel);
            personalizzaUtenteTabPage.Controls.Add(scegliImmagineProfiloLabel);
            personalizzaUtenteTabPage.Controls.Add(scegliPokemonPreferitoComboBox);
            personalizzaUtenteTabPage.Controls.Add(scegliImmagineProfiloComboBox);
            personalizzaUtenteTabPage.Controls.Add(cambiaPokemonPreferitoButton);
            personalizzaUtenteTabPage.Controls.Add(cambiaImmagineProfiloButton);
            personalizzaUtenteTabPage.Controls.Add(cambiaPokemonPreferitoPictureBox);
            personalizzaUtenteTabPage.Controls.Add(cambiaImmagineProfiloPictureBox);
            personalizzaUtenteTabPage.Location = new Point(4, 24);
            personalizzaUtenteTabPage.Name = "personalizzaUtenteTabPage";
            personalizzaUtenteTabPage.Padding = new Padding(3);
            personalizzaUtenteTabPage.Size = new Size(1121, 625);
            personalizzaUtenteTabPage.TabIndex = 3;
            personalizzaUtenteTabPage.Text = "Personalizza profilo";
            personalizzaUtenteTabPage.UseVisualStyleBackColor = true;
            // 
            // profiloCromaticoLabel
            // 
            profiloCromaticoLabel.AutoSize = true;
            profiloCromaticoLabel.Location = new Point(320, 209);
            profiloCromaticoLabel.Name = "profiloCromaticoLabel";
            profiloCromaticoLabel.Size = new Size(0, 15);
            profiloCromaticoLabel.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 254);
            label2.Name = "label2";
            label2.Size = new Size(120, 15);
            label2.TabIndex = 12;
            label2.Text = "Anteprima immagine";
            // 
            // anteprimaPokemonPreferitoPictureBox
            // 
            anteprimaPokemonPreferitoPictureBox.Location = new Point(13, 277);
            anteprimaPokemonPreferitoPictureBox.Name = "anteprimaPokemonPreferitoPictureBox";
            anteprimaPokemonPreferitoPictureBox.Size = new Size(100, 100);
            anteprimaPokemonPreferitoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            anteprimaPokemonPreferitoPictureBox.TabIndex = 11;
            anteprimaPokemonPreferitoPictureBox.TabStop = false;
            // 
            // anteprimaImmagineProfiloPictureBox
            // 
            anteprimaImmagineProfiloPictureBox.Location = new Point(426, 39);
            anteprimaImmagineProfiloPictureBox.Name = "anteprimaImmagineProfiloPictureBox";
            anteprimaImmagineProfiloPictureBox.Size = new Size(100, 100);
            anteprimaImmagineProfiloPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            anteprimaImmagineProfiloPictureBox.TabIndex = 10;
            anteprimaImmagineProfiloPictureBox.TabStop = false;
            // 
            // pokemonPreferitoLabel
            // 
            pokemonPreferitoLabel.AutoSize = true;
            pokemonPreferitoLabel.Location = new Point(214, 106);
            pokemonPreferitoLabel.Name = "pokemonPreferitoLabel";
            pokemonPreferitoLabel.Size = new Size(106, 15);
            pokemonPreferitoLabel.TabIndex = 9;
            pokemonPreferitoLabel.Text = "Pokemon preferito";
            // 
            // immagineProfiloLabel
            // 
            immagineProfiloLabel.AutoSize = true;
            immagineProfiloLabel.Location = new Point(8, 6);
            immagineProfiloLabel.Name = "immagineProfiloLabel";
            immagineProfiloLabel.Size = new Size(99, 15);
            immagineProfiloLabel.TabIndex = 8;
            immagineProfiloLabel.Text = "Immagine profilo";
            // 
            // scegliPokemonPreferitoLabel
            // 
            scegliPokemonPreferitoLabel.AutoSize = true;
            scegliPokemonPreferitoLabel.Location = new Point(137, 272);
            scegliPokemonPreferitoLabel.Name = "scegliPokemonPreferitoLabel";
            scegliPokemonPreferitoLabel.Size = new Size(92, 15);
            scegliPokemonPreferitoLabel.TabIndex = 7;
            scegliPokemonPreferitoLabel.Text = "Scegli Pokemon";
            // 
            // scegliImmagineProfiloLabel
            // 
            scegliImmagineProfiloLabel.AutoSize = true;
            scegliImmagineProfiloLabel.Location = new Point(426, 21);
            scegliImmagineProfiloLabel.Name = "scegliImmagineProfiloLabel";
            scegliImmagineProfiloLabel.Size = new Size(120, 15);
            scegliImmagineProfiloLabel.TabIndex = 6;
            scegliImmagineProfiloLabel.Text = "Anteprima immagine";
            // 
            // scegliPokemonPreferitoComboBox
            // 
            scegliPokemonPreferitoComboBox.FormattingEnabled = true;
            scegliPokemonPreferitoComboBox.Location = new Point(137, 295);
            scegliPokemonPreferitoComboBox.Name = "scegliPokemonPreferitoComboBox";
            scegliPokemonPreferitoComboBox.Size = new Size(121, 23);
            scegliPokemonPreferitoComboBox.TabIndex = 5;
            scegliPokemonPreferitoComboBox.SelectedIndexChanged += scegliPokemonPreferitoComboBox_SelectedIndexChanged;
            // 
            // scegliImmagineProfiloComboBox
            // 
            scegliImmagineProfiloComboBox.FormattingEnabled = true;
            scegliImmagineProfiloComboBox.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
            scegliImmagineProfiloComboBox.Location = new Point(426, 145);
            scegliImmagineProfiloComboBox.Name = "scegliImmagineProfiloComboBox";
            scegliImmagineProfiloComboBox.Size = new Size(121, 23);
            scegliImmagineProfiloComboBox.TabIndex = 4;
            scegliImmagineProfiloComboBox.SelectedIndexChanged += scegliImmagineProfiloComboBox_SelectedIndexChanged;
            // 
            // cambiaPokemonPreferitoButton
            // 
            cambiaPokemonPreferitoButton.Location = new Point(137, 329);
            cambiaPokemonPreferitoButton.Name = "cambiaPokemonPreferitoButton";
            cambiaPokemonPreferitoButton.Size = new Size(121, 48);
            cambiaPokemonPreferitoButton.TabIndex = 3;
            cambiaPokemonPreferitoButton.Text = "Cambia Pokemon preferito";
            cambiaPokemonPreferitoButton.UseVisualStyleBackColor = true;
            cambiaPokemonPreferitoButton.Click += cambiaPokemonPreferitoButton_Click;
            // 
            // cambiaImmagineProfiloButton
            // 
            cambiaImmagineProfiloButton.Location = new Point(426, 174);
            cambiaImmagineProfiloButton.Name = "cambiaImmagineProfiloButton";
            cambiaImmagineProfiloButton.Size = new Size(123, 50);
            cambiaImmagineProfiloButton.TabIndex = 2;
            cambiaImmagineProfiloButton.Text = "Cambia immagine profilo";
            cambiaImmagineProfiloButton.UseVisualStyleBackColor = true;
            cambiaImmagineProfiloButton.Click += cambiaImmagineProfiloButton_Click;
            // 
            // cambiaPokemonPreferitoPictureBox
            // 
            cambiaPokemonPreferitoPictureBox.Location = new Point(214, 124);
            cambiaPokemonPreferitoPictureBox.Name = "cambiaPokemonPreferitoPictureBox";
            cambiaPokemonPreferitoPictureBox.Size = new Size(100, 100);
            cambiaPokemonPreferitoPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            cambiaPokemonPreferitoPictureBox.TabIndex = 1;
            cambiaPokemonPreferitoPictureBox.TabStop = false;
            // 
            // cambiaImmagineProfiloPictureBox
            // 
            cambiaImmagineProfiloPictureBox.Location = new Point(8, 24);
            cambiaImmagineProfiloPictureBox.Name = "cambiaImmagineProfiloPictureBox";
            cambiaImmagineProfiloPictureBox.Size = new Size(200, 200);
            cambiaImmagineProfiloPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            cambiaImmagineProfiloPictureBox.TabIndex = 0;
            cambiaImmagineProfiloPictureBox.TabStop = false;
            // 
            // FormUtente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1129, 653);
            Controls.Add(battagliaTab);
            Cursor = Cursors.IBeam;
            Name = "FormUtente";
            Text = "FormUtente";
            visualizzaAmici.ResumeLayout(false);
            visualizzaAmici.PerformLayout();
            boxShiny.ResumeLayout(false);
            cercaGiocatoreGroupBox.ResumeLayout(false);
            cercaGiocatoreGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePokemonPreferitoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePictureBox).EndInit();
            visualizzaPokedex.ResumeLayout(false);
            visualizzaPokedex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).EndInit();
            pannelloStat.ResumeLayout(false);
            pannelloStat.PerformLayout();
            cercaECattura.ResumeLayout(false);
            cercaECattura.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            battagliaTab.ResumeLayout(false);
            gestisciSquadraTab.ResumeLayout(false);
            gestisciSquadraTab.PerformLayout();
            battagliaTabPage.ResumeLayout(false);
            battagliaTabPage.PerformLayout();
            personalizzaUtenteTabPage.ResumeLayout(false);
            personalizzaUtenteTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)anteprimaPokemonPreferitoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)anteprimaImmagineProfiloPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)cambiaPokemonPreferitoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)cambiaImmagineProfiloPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TabPage visualizzaAmici;
        private Label cercaGiocatoreFallitaLabel;
        private Button cercaGiocatoreButton;
        private GroupBox cercaGiocatoreGroupBox;
        private Label pokemonPreferitoCercaGiocatoreLabel;
        private PictureBox cercaGiocatorePokemonPreferitoPictureBox;
        private Button cercaGiocatoreRimuoviButton;
        private Button cercaGiocatoreSbloccaButton;
        private Button cercaGiocatoreBloccaButton;
        private Button cercaGiocatoreAggiungiButton;
        private PictureBox cercaGiocatorePictureBox;
        private Label nicknameCercaGiocatoreLabel;
        private Label cognomeCercaGiocatoreLabel;
        private Label nomeCercaGiocatoreLabel;
        private TextBox cercaGiocatoreTextBox;
        private Label cercaGiocatoreLabel;
        private ListView amiciList;
        private ColumnHeader amico;
        private ColumnHeader bloccato;
        private TabPage visualizzaPokedex;
        private Label label1;
        private Label abilitaPokemonLabel;
        private Label biomaPokemonLabel;
        private Label mossePokemonLabel;
        private ListView mossePokemonListView;
        private ColumnHeader Nome;
        private ColumnHeader Elemento;
        private ColumnHeader Danno;
        private ColumnHeader Precisione;
        private ColumnHeader Descrizione;
        private RichTextBox descrizionePokemonTextBox;
        private Label statistichePokemonTotaleLabel;
        private Label statistichePokemonVelocitaLabel;
        private Label statistichePokemonDifesaSpecialeLabel;
        private Label statistichePokemonAttaccoSpecialeLabel;
        private Label statistichePokemonDifesaLabel;
        private Label statistichePokemonAttaccoLabel;
        private Label statistichePokemonPuntiSaluteLabel;
        private Label statistichePokemonLabel;
        private Label elementiPokemonLabel;
        private Label descrizionePokemonLabel;
        private Label improntaPokemonLabel;
        private Label pesoPokemonLabel;
        private Label altezzaPokemonLabel;
        private Label speciePokemonLabel;
        private Label pokemonLabel;
        private PictureBox pokedexPicture;
        private ListView pokedexList;
        private ColumnHeader ids;
        private ColumnHeader names;
        private ColumnHeader captured;
        private TabPage cercaECattura;
        private Panel panel2;
        private RichTextBox outputBox;
        private Panel panel1;
        private Label selezionaPokemonLabel;
        private Button tentaCatturaButton;
        private ComboBox pokemonDisponibiliBox;
        private Button cercaPokemonButton;
        private TabControl battagliaTab;
        private TableLayoutPanel lineaEvolutivaPokemonLayout;
        private TextBox filtroNomeTextBox;
        private ComboBox filtroElementoComboBox;
        private Button applicaFiltroButton;
        private Button resetFiltroButton;
        private TabPage gestisciSquadraTab;
        private TabPage battagliaTabPage;
        private ListView boxListView;
        private ListView squadraListView;
        private Button spostaInSquadraButton;
        private Button spostaInBoxButton;
        private Button cercaGiocatoreSfidaButton;
        private ComboBox luogoBattagliaComboBox;
        private ComboBox avversarioComboBox;
        private ListView squadraAmicoListView;
        private Label labelBox;
        private Label labelSquadra;
        private Label avversarioLabel;
        private Label luogoLabel;
        private Label labelSquadraAmico;
        private Label pokedexFiltraPerBiomaLabel;
        private ComboBox pokedexFiltraPerMetodoEvolutivoComboBox;
        private Label pokedexFiltraPerMetodoEvolutivoLabel;
        private Label pokedexFiltraPerTipoLabel;
        private Label pokedexFIltraPerNomeLabel;
        private Label pokedexFiltraLabel;
        private ComboBox pokedexFiltraPerBiomaComboBox;
        private Label pokedexFiltraPerColoreLabel;
        private Label pokedexFiltraPerMossaLabel;
        private ComboBox comboBox5;
        private ComboBox pokedexFiltraPerColoreComboBox;
        private ComboBox pokedexFiltraPerMossaComboBox;
        private ComboBox scegliPokemonPreferitoComboBox;
        private ComboBox pokedexFiltraPerAbilitaComboBox;
        private Label pokedexFiltraPerAbilitaLabel;
        private ColumnHeader id;
        private ColumnHeader name;
        private ColumnHeader level;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private GroupBox boxShiny;
        private ListView listShiny;
        private TabPage personalizzaUtenteTabPage;
        private Button cambiaPokemonPreferitoButton;
        private Button cambiaImmagineProfiloButton;
        private PictureBox cambiaPokemonPreferitoPictureBox;
        private PictureBox cambiaImmagineProfiloPictureBox;
        private ComboBox scegliImmagineProfiloComboBox;
        private Label scegliPokemonPreferitoLabel;
        private Label scegliImmagineProfiloLabel;
        private Label immagineProfiloLabel;
        private PictureBox anteprimaImmagineProfiloPictureBox;
        private Label pokemonPreferitoLabel;
        private PictureBox anteprimaPokemonPreferitoPictureBox;
        private Label label2;
        private GroupBox pannelloStat;
        private ListView listMetodi;
        private ListView listColori;
        private Label lblColori;
        private Label lblMetodi;
        private CheckBox shinyCheckBox;
        private Label amicoCromaticoLabel;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader14;
        private Label profiloCromaticoLabel;
        private Label label3;
        private ListView storicoBattaglieListView;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
    }
}
