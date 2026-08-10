namespace PokedexADA
{
    partial class Form1
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
            cercaGiocatoreFallitaLabel = new Label();
            cercaGiocatoreButton = new Button();
            cercaGiocatoreGroupBox = new GroupBox();
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
            cercaECattura = new TabPage();
            panel2 = new Panel();
            outputBox = new RichTextBox();
            panel1 = new Panel();
            selezionaPokemonLabel = new Label();
            tentaCatturaButton = new Button();
            pokemonDisponibiliBox = new ComboBox();
            cercaPokemonButton = new Button();
            cercaPokemonSelezionatoButton = new Button();
            esemplariCatturati = new TabControl();
            visualizzaAmici.SuspendLayout();
            cercaGiocatoreGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePokemonPreferitoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePictureBox).BeginInit();
            visualizzaPokedex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).BeginInit();
            cercaECattura.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            esemplariCatturati.SuspendLayout();
            SuspendLayout();
            // 
            // visualizzaAmici
            // 
            visualizzaAmici.Controls.Add(cercaGiocatoreFallitaLabel);
            visualizzaAmici.Controls.Add(cercaGiocatoreButton);
            visualizzaAmici.Controls.Add(cercaGiocatoreGroupBox);
            visualizzaAmici.Controls.Add(cercaGiocatoreTextBox);
            visualizzaAmici.Controls.Add(cercaGiocatoreLabel);
            visualizzaAmici.Controls.Add(amiciList);
            visualizzaAmici.Location = new Point(4, 34);
            visualizzaAmici.Margin = new Padding(4, 5, 4, 5);
            visualizzaAmici.Name = "visualizzaAmici";
            visualizzaAmici.Size = new Size(1260, 923);
            visualizzaAmici.TabIndex = 2;
            visualizzaAmici.Text = "Visualizza Amici";
            visualizzaAmici.UseVisualStyleBackColor = true;
            // 
            // cercaGiocatoreFallitaLabel
            // 
            cercaGiocatoreFallitaLabel.AutoSize = true;
            cercaGiocatoreFallitaLabel.Location = new Point(844, 62);
            cercaGiocatoreFallitaLabel.Name = "cercaGiocatoreFallitaLabel";
            cercaGiocatoreFallitaLabel.Size = new Size(0, 25);
            cercaGiocatoreFallitaLabel.TabIndex = 7;
            // 
            // cercaGiocatoreButton
            // 
            cercaGiocatoreButton.Location = new Point(713, 62);
            cercaGiocatoreButton.Name = "cercaGiocatoreButton";
            cercaGiocatoreButton.Size = new Size(125, 31);
            cercaGiocatoreButton.TabIndex = 6;
            cercaGiocatoreButton.Text = "Cerca";
            cercaGiocatoreButton.UseVisualStyleBackColor = true;
            cercaGiocatoreButton.Click += cercaGiocatoreButton_Click;
            // 
            // cercaGiocatoreGroupBox
            // 
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
            cercaGiocatoreGroupBox.Location = new Point(518, 122);
            cercaGiocatoreGroupBox.Name = "cercaGiocatoreGroupBox";
            cercaGiocatoreGroupBox.Size = new Size(734, 793);
            cercaGiocatoreGroupBox.TabIndex = 3;
            cercaGiocatoreGroupBox.TabStop = false;
            cercaGiocatoreGroupBox.Text = "Giocatore";
            cercaGiocatoreGroupBox.Visible = false;
            // 
            // pokemonPreferitoCercaGiocatoreLabel
            // 
            pokemonPreferitoCercaGiocatoreLabel.AutoSize = true;
            pokemonPreferitoCercaGiocatoreLabel.Location = new Point(209, 115);
            pokemonPreferitoCercaGiocatoreLabel.Name = "pokemonPreferitoCercaGiocatoreLabel";
            pokemonPreferitoCercaGiocatoreLabel.Size = new Size(164, 25);
            pokemonPreferitoCercaGiocatoreLabel.TabIndex = 9;
            pokemonPreferitoCercaGiocatoreLabel.Text = "Pokemon preferito:";
            // 
            // cercaGiocatorePokemonPreferitoPictureBox
            // 
            cercaGiocatorePokemonPreferitoPictureBox.Location = new Point(209, 145);
            cercaGiocatorePokemonPreferitoPictureBox.Name = "cercaGiocatorePokemonPreferitoPictureBox";
            cercaGiocatorePokemonPreferitoPictureBox.Size = new Size(76, 76);
            cercaGiocatorePokemonPreferitoPictureBox.TabIndex = 8;
            cercaGiocatorePokemonPreferitoPictureBox.TabStop = false;
            // 
            // cercaGiocatoreRimuoviButton
            // 
            cercaGiocatoreRimuoviButton.Location = new Point(23, 258);
            cercaGiocatoreRimuoviButton.Name = "cercaGiocatoreRimuoviButton";
            cercaGiocatoreRimuoviButton.Size = new Size(136, 67);
            cercaGiocatoreRimuoviButton.TabIndex = 7;
            cercaGiocatoreRimuoviButton.Text = "Rimuovi amico";
            cercaGiocatoreRimuoviButton.UseVisualStyleBackColor = true;
            cercaGiocatoreRimuoviButton.Visible = false;
            cercaGiocatoreRimuoviButton.Click += cercaGiocatoreRimuoviButton_Click;
            // 
            // cercaGiocatoreSbloccaButton
            // 
            cercaGiocatoreSbloccaButton.Location = new Point(167, 258);
            cercaGiocatoreSbloccaButton.Name = "cercaGiocatoreSbloccaButton";
            cercaGiocatoreSbloccaButton.Size = new Size(136, 67);
            cercaGiocatoreSbloccaButton.TabIndex = 6;
            cercaGiocatoreSbloccaButton.Text = "Sblocca";
            cercaGiocatoreSbloccaButton.UseVisualStyleBackColor = true;
            cercaGiocatoreSbloccaButton.Visible = false;
            cercaGiocatoreSbloccaButton.Click += cercaGiocatoreSbloccaButton_Click;
            // 
            // cercaGiocatoreBloccaButton
            // 
            cercaGiocatoreBloccaButton.Location = new Point(167, 258);
            cercaGiocatoreBloccaButton.Name = "cercaGiocatoreBloccaButton";
            cercaGiocatoreBloccaButton.Size = new Size(136, 67);
            cercaGiocatoreBloccaButton.TabIndex = 5;
            cercaGiocatoreBloccaButton.Text = "Blocca";
            cercaGiocatoreBloccaButton.UseVisualStyleBackColor = true;
            cercaGiocatoreBloccaButton.Visible = false;
            cercaGiocatoreBloccaButton.Click += cercaGiocatoreBloccaButton_Click;
            // 
            // cercaGiocatoreAggiungiButton
            // 
            cercaGiocatoreAggiungiButton.Location = new Point(23, 258);
            cercaGiocatoreAggiungiButton.Name = "cercaGiocatoreAggiungiButton";
            cercaGiocatoreAggiungiButton.Size = new Size(136, 67);
            cercaGiocatoreAggiungiButton.TabIndex = 4;
            cercaGiocatoreAggiungiButton.Text = "Aggiungi come amico";
            cercaGiocatoreAggiungiButton.UseVisualStyleBackColor = true;
            cercaGiocatoreAggiungiButton.Visible = false;
            cercaGiocatoreAggiungiButton.Click += cercaGiocatoreAggiungiButton_Click;
            // 
            // cercaGiocatorePictureBox
            // 
            cercaGiocatorePictureBox.Location = new Point(23, 41);
            cercaGiocatorePictureBox.Name = "cercaGiocatorePictureBox";
            cercaGiocatorePictureBox.Size = new Size(180, 180);
            cercaGiocatorePictureBox.TabIndex = 3;
            cercaGiocatorePictureBox.TabStop = false;
            // 
            // nicknameCercaGiocatoreLabel
            // 
            nicknameCercaGiocatoreLabel.AutoSize = true;
            nicknameCercaGiocatoreLabel.Location = new Point(209, 40);
            nicknameCercaGiocatoreLabel.Name = "nicknameCercaGiocatoreLabel";
            nicknameCercaGiocatoreLabel.Size = new Size(94, 25);
            nicknameCercaGiocatoreLabel.TabIndex = 2;
            nicknameCercaGiocatoreLabel.Text = "Nickname:";
            // 
            // cognomeCercaGiocatoreLabel
            // 
            cognomeCercaGiocatoreLabel.AutoSize = true;
            cognomeCercaGiocatoreLabel.Location = new Point(208, 90);
            cognomeCercaGiocatoreLabel.Name = "cognomeCercaGiocatoreLabel";
            cognomeCercaGiocatoreLabel.Size = new Size(95, 25);
            cognomeCercaGiocatoreLabel.TabIndex = 1;
            cognomeCercaGiocatoreLabel.Text = "Cognome:";
            // 
            // nomeCercaGiocatoreLabel
            // 
            nomeCercaGiocatoreLabel.AutoSize = true;
            nomeCercaGiocatoreLabel.Location = new Point(209, 65);
            nomeCercaGiocatoreLabel.Name = "nomeCercaGiocatoreLabel";
            nomeCercaGiocatoreLabel.Size = new Size(65, 25);
            nomeCercaGiocatoreLabel.TabIndex = 0;
            nomeCercaGiocatoreLabel.Text = "Nome:";
            // 
            // cercaGiocatoreTextBox
            // 
            cercaGiocatoreTextBox.Location = new Point(518, 62);
            cercaGiocatoreTextBox.Name = "cercaGiocatoreTextBox";
            cercaGiocatoreTextBox.Size = new Size(189, 31);
            cercaGiocatoreTextBox.TabIndex = 2;
            // 
            // cercaGiocatoreLabel
            // 
            cercaGiocatoreLabel.AutoSize = true;
            cercaGiocatoreLabel.Location = new Point(518, 34);
            cercaGiocatoreLabel.Name = "cercaGiocatoreLabel";
            cercaGiocatoreLabel.Size = new Size(135, 25);
            cercaGiocatoreLabel.TabIndex = 1;
            cercaGiocatoreLabel.Text = "Cerca giocatore";
            // 
            // amiciList
            // 
            amiciList.Columns.AddRange(new ColumnHeader[] { amico, bloccato });
            amiciList.FullRowSelect = true;
            amiciList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            amiciList.Location = new Point(12, 14);
            amiciList.Name = "amiciList";
            amiciList.Size = new Size(442, 901);
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
            visualizzaPokedex.Location = new Point(4, 34);
            visualizzaPokedex.Margin = new Padding(4, 5, 4, 5);
            visualizzaPokedex.Name = "visualizzaPokedex";
            visualizzaPokedex.Padding = new Padding(4, 5, 4, 5);
            visualizzaPokedex.Size = new Size(1260, 923);
            visualizzaPokedex.TabIndex = 1;
            visualizzaPokedex.Text = "Visualizza Pokedex";
            visualizzaPokedex.UseVisualStyleBackColor = true;
            // 
            // lineaEvolutivaPokemonLayout
            // 
            lineaEvolutivaPokemonLayout.HorizontalScroll.Maximum = 0;
            lineaEvolutivaPokemonLayout.HorizontalScroll.Visible = false;
            lineaEvolutivaPokemonLayout.AutoScroll = true;
            lineaEvolutivaPokemonLayout.ColumnCount = 3;
            lineaEvolutivaPokemonLayout.ColumnStyles.Add(new ColumnStyle());
            lineaEvolutivaPokemonLayout.ColumnStyles.Add(new ColumnStyle());
            lineaEvolutivaPokemonLayout.ColumnStyles.Add(new ColumnStyle());
            lineaEvolutivaPokemonLayout.Location = new Point(470, 424);
            lineaEvolutivaPokemonLayout.Name = "lineaEvolutivaPokemonLayout";
            lineaEvolutivaPokemonLayout.RowCount = 1;
            lineaEvolutivaPokemonLayout.RowStyles.Add(new RowStyle());
            lineaEvolutivaPokemonLayout.Size = new Size(753, 178);
            lineaEvolutivaPokemonLayout.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(470, 396);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(128, 25);
            label1.TabIndex = 23;
            label1.Text = "Linea evolutiva";
            // 
            // abilitaPokemonLabel
            // 
            abilitaPokemonLabel.AutoSize = true;
            abilitaPokemonLabel.Location = new Point(703, 85);
            abilitaPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            abilitaPokemonLabel.Name = "abilitaPokemonLabel";
            abilitaPokemonLabel.Size = new Size(66, 25);
            abilitaPokemonLabel.TabIndex = 21;
            abilitaPokemonLabel.Text = "Abilità:";
            // 
            // biomaPokemonLabel
            // 
            biomaPokemonLabel.AutoSize = true;
            biomaPokemonLabel.Location = new Point(703, 185);
            biomaPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            biomaPokemonLabel.Name = "biomaPokemonLabel";
            biomaPokemonLabel.Size = new Size(66, 25);
            biomaPokemonLabel.TabIndex = 20;
            biomaPokemonLabel.Text = "Bioma:";
            // 
            // mossePokemonLabel
            // 
            mossePokemonLabel.AutoSize = true;
            mossePokemonLabel.Location = new Point(470, 605);
            mossePokemonLabel.Margin = new Padding(4, 0, 4, 0);
            mossePokemonLabel.Name = "mossePokemonLabel";
            mossePokemonLabel.Size = new Size(64, 25);
            mossePokemonLabel.TabIndex = 19;
            mossePokemonLabel.Text = "Mosse";
            // 
            // mossePokemonListView
            // 
            mossePokemonListView.Columns.AddRange(new ColumnHeader[] { Nome, Elemento, Danno, Precisione, Descrizione });
            mossePokemonListView.FullRowSelect = true;
            mossePokemonListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            mossePokemonListView.Location = new Point(470, 635);
            mossePokemonListView.Margin = new Padding(4, 5, 4, 5);
            mossePokemonListView.Name = "mossePokemonListView";
            mossePokemonListView.Size = new Size(753, 250);
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
            descrizionePokemonTextBox.Location = new Point(470, 284);
            descrizionePokemonTextBox.Margin = new Padding(4, 5, 4, 5);
            descrizionePokemonTextBox.Name = "descrizionePokemonTextBox";
            descrizionePokemonTextBox.ReadOnly = true;
            descrizionePokemonTextBox.Size = new Size(753, 107);
            descrizionePokemonTextBox.TabIndex = 6;
            descrizionePokemonTextBox.Text = "";
            // 
            // statistichePokemonTotaleLabel
            // 
            statistichePokemonTotaleLabel.AutoSize = true;
            statistichePokemonTotaleLabel.Location = new Point(971, 185);
            statistichePokemonTotaleLabel.Margin = new Padding(4, 0, 4, 0);
            statistichePokemonTotaleLabel.Name = "statistichePokemonTotaleLabel";
            statistichePokemonTotaleLabel.Size = new Size(62, 25);
            statistichePokemonTotaleLabel.TabIndex = 17;
            statistichePokemonTotaleLabel.Text = "Totale:";
            // 
            // statistichePokemonVelocitaLabel
            // 
            statistichePokemonVelocitaLabel.AutoSize = true;
            statistichePokemonVelocitaLabel.Location = new Point(968, 160);
            statistichePokemonVelocitaLabel.Margin = new Padding(4, 0, 4, 0);
            statistichePokemonVelocitaLabel.Name = "statistichePokemonVelocitaLabel";
            statistichePokemonVelocitaLabel.Size = new Size(77, 25);
            statistichePokemonVelocitaLabel.TabIndex = 16;
            statistichePokemonVelocitaLabel.Text = "Velocità:";
            // 
            // statistichePokemonDifesaSpecialeLabel
            // 
            statistichePokemonDifesaSpecialeLabel.AutoSize = true;
            statistichePokemonDifesaSpecialeLabel.Location = new Point(968, 135);
            statistichePokemonDifesaSpecialeLabel.Margin = new Padding(4, 0, 4, 0);
            statistichePokemonDifesaSpecialeLabel.Name = "statistichePokemonDifesaSpecialeLabel";
            statistichePokemonDifesaSpecialeLabel.Size = new Size(132, 25);
            statistichePokemonDifesaSpecialeLabel.TabIndex = 15;
            statistichePokemonDifesaSpecialeLabel.Text = "Difesa speciale:";
            // 
            // statistichePokemonAttaccoSpecialeLabel
            // 
            statistichePokemonAttaccoSpecialeLabel.AutoSize = true;
            statistichePokemonAttaccoSpecialeLabel.Location = new Point(968, 110);
            statistichePokemonAttaccoSpecialeLabel.Margin = new Padding(4, 0, 4, 0);
            statistichePokemonAttaccoSpecialeLabel.Name = "statistichePokemonAttaccoSpecialeLabel";
            statistichePokemonAttaccoSpecialeLabel.Size = new Size(143, 25);
            statistichePokemonAttaccoSpecialeLabel.TabIndex = 14;
            statistichePokemonAttaccoSpecialeLabel.Text = "Attacco speciale:";
            // 
            // statistichePokemonDifesaLabel
            // 
            statistichePokemonDifesaLabel.AutoSize = true;
            statistichePokemonDifesaLabel.Location = new Point(968, 85);
            statistichePokemonDifesaLabel.Margin = new Padding(4, 0, 4, 0);
            statistichePokemonDifesaLabel.Name = "statistichePokemonDifesaLabel";
            statistichePokemonDifesaLabel.Size = new Size(65, 25);
            statistichePokemonDifesaLabel.TabIndex = 13;
            statistichePokemonDifesaLabel.Text = "Difesa:";
            // 
            // statistichePokemonAttaccoLabel
            // 
            statistichePokemonAttaccoLabel.AutoSize = true;
            statistichePokemonAttaccoLabel.Location = new Point(968, 60);
            statistichePokemonAttaccoLabel.Margin = new Padding(4, 0, 4, 0);
            statistichePokemonAttaccoLabel.Name = "statistichePokemonAttaccoLabel";
            statistichePokemonAttaccoLabel.Size = new Size(76, 25);
            statistichePokemonAttaccoLabel.TabIndex = 12;
            statistichePokemonAttaccoLabel.Text = "Attacco:";
            // 
            // statistichePokemonPuntiSaluteLabel
            // 
            statistichePokemonPuntiSaluteLabel.AutoSize = true;
            statistichePokemonPuntiSaluteLabel.Location = new Point(968, 35);
            statistichePokemonPuntiSaluteLabel.Margin = new Padding(4, 0, 4, 0);
            statistichePokemonPuntiSaluteLabel.Name = "statistichePokemonPuntiSaluteLabel";
            statistichePokemonPuntiSaluteLabel.Size = new Size(107, 25);
            statistichePokemonPuntiSaluteLabel.TabIndex = 11;
            statistichePokemonPuntiSaluteLabel.Text = "Punti salute:";
            // 
            // statistichePokemonLabel
            // 
            statistichePokemonLabel.AutoSize = true;
            statistichePokemonLabel.Location = new Point(968, 10);
            statistichePokemonLabel.Margin = new Padding(4, 0, 4, 0);
            statistichePokemonLabel.Name = "statistichePokemonLabel";
            statistichePokemonLabel.Size = new Size(91, 25);
            statistichePokemonLabel.TabIndex = 10;
            statistichePokemonLabel.Text = "Statistiche";
            // 
            // elementiPokemonLabel
            // 
            elementiPokemonLabel.AutoSize = true;
            elementiPokemonLabel.Location = new Point(703, 60);
            elementiPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            elementiPokemonLabel.Name = "elementiPokemonLabel";
            elementiPokemonLabel.Size = new Size(83, 25);
            elementiPokemonLabel.TabIndex = 9;
            elementiPokemonLabel.Text = "Elementi:";
            // 
            // descrizionePokemonLabel
            // 
            descrizionePokemonLabel.AutoSize = true;
            descrizionePokemonLabel.Location = new Point(470, 254);
            descrizionePokemonLabel.Margin = new Padding(4, 0, 4, 0);
            descrizionePokemonLabel.Name = "descrizionePokemonLabel";
            descrizionePokemonLabel.Size = new Size(106, 25);
            descrizionePokemonLabel.TabIndex = 8;
            descrizionePokemonLabel.Text = "Descrizione:";
            // 
            // improntaPokemonLabel
            // 
            improntaPokemonLabel.AutoSize = true;
            improntaPokemonLabel.Location = new Point(703, 160);
            improntaPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            improntaPokemonLabel.Name = "improntaPokemonLabel";
            improntaPokemonLabel.Size = new Size(90, 25);
            improntaPokemonLabel.TabIndex = 7;
            improntaPokemonLabel.Text = "Impronta:";
            // 
            // pesoPokemonLabel
            // 
            pesoPokemonLabel.AutoSize = true;
            pesoPokemonLabel.Location = new Point(703, 135);
            pesoPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            pesoPokemonLabel.Name = "pesoPokemonLabel";
            pesoPokemonLabel.Size = new Size(53, 25);
            pesoPokemonLabel.TabIndex = 5;
            pesoPokemonLabel.Text = "Peso:";
            // 
            // altezzaPokemonLabel
            // 
            altezzaPokemonLabel.AutoSize = true;
            altezzaPokemonLabel.Location = new Point(703, 110);
            altezzaPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            altezzaPokemonLabel.Name = "altezzaPokemonLabel";
            altezzaPokemonLabel.Size = new Size(72, 25);
            altezzaPokemonLabel.TabIndex = 4;
            altezzaPokemonLabel.Text = "Altezza:";
            // 
            // speciePokemonLabel
            // 
            speciePokemonLabel.AutoSize = true;
            speciePokemonLabel.Location = new Point(703, 35);
            speciePokemonLabel.Margin = new Padding(4, 0, 4, 0);
            speciePokemonLabel.Name = "speciePokemonLabel";
            speciePokemonLabel.Size = new Size(91, 25);
            speciePokemonLabel.TabIndex = 3;
            speciePokemonLabel.Text = "Pokemon:";
            // 
            // pokemonLabel
            // 
            pokemonLabel.AutoSize = true;
            pokemonLabel.Location = new Point(703, 10);
            pokemonLabel.Margin = new Padding(4, 0, 4, 0);
            pokemonLabel.Name = "pokemonLabel";
            pokemonLabel.Size = new Size(81, 25);
            pokemonLabel.TabIndex = 2;
            pokemonLabel.Text = "Numero:";
            // 
            // pokedexPicture
            // 
            pokedexPicture.Location = new Point(470, 10);
            pokedexPicture.Margin = new Padding(4, 5, 4, 5);
            pokedexPicture.Name = "pokedexPicture";
            pokedexPicture.Size = new Size(225, 225);
            pokedexPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            pokedexPicture.TabIndex = 1;
            pokedexPicture.TabStop = false;
            // 
            // pokedexList
            // 
            pokedexList.Columns.AddRange(new ColumnHeader[] { ids, names, captured });
            pokedexList.FullRowSelect = true;
            pokedexList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            pokedexList.Location = new Point(9, 10);
            pokedexList.Margin = new Padding(4, 5, 4, 5);
            pokedexList.Name = "pokedexList";
            pokedexList.Size = new Size(390, 875);
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
            // cercaECattura
            // 
            cercaECattura.Controls.Add(panel2);
            cercaECattura.Location = new Point(4, 34);
            cercaECattura.Margin = new Padding(4, 5, 4, 5);
            cercaECattura.Name = "cercaECattura";
            cercaECattura.Padding = new Padding(4, 5, 4, 5);
            cercaECattura.Size = new Size(1260, 923);
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
            panel2.Location = new Point(4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1252, 913);
            panel2.TabIndex = 3;
            // 
            // outputBox
            // 
            outputBox.Location = new Point(4, 5);
            outputBox.Margin = new Padding(4, 5, 4, 5);
            outputBox.MinimumSize = new Size(300, 200);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(1056, 903);
            outputBox.TabIndex = 0;
            outputBox.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(selezionaPokemonLabel);
            panel1.Controls.Add(tentaCatturaButton);
            panel1.Controls.Add(pokemonDisponibiliBox);
            panel1.Controls.Add(cercaPokemonButton);
            panel1.Controls.Add(cercaPokemonSelezionatoButton);
            panel1.Location = new Point(1067, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(181, 903);
            panel1.TabIndex = 2;
            // 
            // selezionaPokemonLabel
            // 
            selezionaPokemonLabel.AutoSize = true;
            selezionaPokemonLabel.Location = new Point(5, 3);
            selezionaPokemonLabel.Name = "selezionaPokemonLabel";
            selezionaPokemonLabel.Size = new Size(168, 25);
            selezionaPokemonLabel.TabIndex = 7;
            selezionaPokemonLabel.Text = "Seleziona pokemon";
            // 
            // tentaCatturaButton
            // 
            tentaCatturaButton.Location = new Point(5, 199);
            tentaCatturaButton.Margin = new Padding(4, 5, 4, 5);
            tentaCatturaButton.Name = "tentaCatturaButton";
            tentaCatturaButton.Size = new Size(171, 38);
            tentaCatturaButton.TabIndex = 5;
            tentaCatturaButton.Text = "Tenta cattura";
            tentaCatturaButton.UseVisualStyleBackColor = true;
            tentaCatturaButton.Click += TentaCatturaButtonOnClick;
            // 
            // pokemonDisponibiliBox
            // 
            pokemonDisponibiliBox.FormattingEnabled = true;
            pokemonDisponibiliBox.Location = new Point(5, 33);
            pokemonDisponibiliBox.Margin = new Padding(4, 5, 4, 5);
            pokemonDisponibiliBox.Name = "pokemonDisponibiliBox";
            pokemonDisponibiliBox.Size = new Size(170, 33);
            pokemonDisponibiliBox.TabIndex = 4;
            // 
            // cercaPokemonButton
            // 
            cercaPokemonButton.Location = new Point(4, 151);
            cercaPokemonButton.Margin = new Padding(4, 5, 4, 5);
            cercaPokemonButton.Name = "cercaPokemonButton";
            cercaPokemonButton.Size = new Size(171, 38);
            cercaPokemonButton.TabIndex = 6;
            cercaPokemonButton.Text = "Cerca Pokemon";
            cercaPokemonButton.UseVisualStyleBackColor = true;
            cercaPokemonButton.Click += CercaPokemonButtonOnClick;
            // 
            // cercaPokemonSelezionatoButton
            // 
            cercaPokemonSelezionatoButton.Location = new Point(5, 76);
            cercaPokemonSelezionatoButton.Margin = new Padding(4, 5, 4, 5);
            cercaPokemonSelezionatoButton.Name = "cercaPokemonSelezionatoButton";
            cercaPokemonSelezionatoButton.Size = new Size(171, 65);
            cercaPokemonSelezionatoButton.TabIndex = 3;
            cercaPokemonSelezionatoButton.Text = "Cerca Pokemon selezionato";
            cercaPokemonSelezionatoButton.UseVisualStyleBackColor = true;
            cercaPokemonSelezionatoButton.Click += CercaPokemonSelezionatoButtonOnClick;
            // 
            // esemplariCatturati
            // 
            esemplariCatturati.Controls.Add(cercaECattura);
            esemplariCatturati.Controls.Add(visualizzaPokedex);
            esemplariCatturati.Controls.Add(visualizzaAmici);
            esemplariCatturati.Dock = DockStyle.Fill;
            esemplariCatturati.Location = new Point(0, 0);
            esemplariCatturati.Margin = new Padding(4, 5, 4, 5);
            esemplariCatturati.Name = "esemplariCatturati";
            esemplariCatturati.SelectedIndex = 0;
            esemplariCatturati.Size = new Size(1268, 961);
            esemplariCatturati.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1268, 961);
            Controls.Add(esemplariCatturati);
            Cursor = Cursors.IBeam;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            visualizzaAmici.ResumeLayout(false);
            visualizzaAmici.PerformLayout();
            cercaGiocatoreGroupBox.ResumeLayout(false);
            cercaGiocatoreGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePokemonPreferitoPictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePictureBox).EndInit();
            visualizzaPokedex.ResumeLayout(false);
            visualizzaPokedex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).EndInit();
            cercaECattura.ResumeLayout(false);
            cercaECattura.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            esemplariCatturati.ResumeLayout(false);
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
        private Button cercaPokemonSelezionatoButton;
        private TabControl esemplariCatturati;
        private TableLayoutPanel lineaEvolutivaPokemonLayout;
    }
}
