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
            label1 = new Label();
            abilitaPokemonLabel = new Label();
            biomaPokemonLabel = new Label();
            mossePokemonLabel = new Label();
            lineaEvolutivaPokemonLayout = new FlowLayoutPanel();
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
            mostraStato = new Button();
            tentaCatturaButton = new Button();
            pokemonDisponibiliBox = new ComboBox();
            cercaPokemonButton = new Button();
            cercaPokemonSelezionatoButton = new Button();
            battagliaTab = new TabControl();
            visualizzaAmici.SuspendLayout();
            cercaGiocatoreGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePokemonPreferitoPictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePictureBox).BeginInit();
            visualizzaPokedex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).BeginInit();
            cercaECattura.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            battagliaTab.SuspendLayout();
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
            visualizzaAmici.Location = new Point(4, 24);
            visualizzaAmici.Name = "visualizzaAmici";
            visualizzaAmici.Size = new Size(880, 549);
            visualizzaAmici.TabIndex = 2;
            visualizzaAmici.Text = "Visualizza Amici";
            visualizzaAmici.UseVisualStyleBackColor = true;
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
            cercaGiocatoreButton.Location = new Point(499, 37);
            cercaGiocatoreButton.Margin = new Padding(2);
            cercaGiocatoreButton.Name = "cercaGiocatoreButton";
            cercaGiocatoreButton.Size = new Size(88, 19);
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
            cercaGiocatoreGroupBox.Location = new Point(363, 73);
            cercaGiocatoreGroupBox.Margin = new Padding(2);
            cercaGiocatoreGroupBox.Name = "cercaGiocatoreGroupBox";
            cercaGiocatoreGroupBox.Padding = new Padding(2);
            cercaGiocatoreGroupBox.Size = new Size(514, 476);
            cercaGiocatoreGroupBox.TabIndex = 3;
            cercaGiocatoreGroupBox.TabStop = false;
            cercaGiocatoreGroupBox.Text = "Giocatore";
            cercaGiocatoreGroupBox.Visible = false;
            // 
            // pokemonPreferitoCercaGiocatoreLabel
            // 
            pokemonPreferitoCercaGiocatoreLabel.AutoSize = true;
            pokemonPreferitoCercaGiocatoreLabel.Location = new Point(146, 69);
            pokemonPreferitoCercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            pokemonPreferitoCercaGiocatoreLabel.Name = "pokemonPreferitoCercaGiocatoreLabel";
            pokemonPreferitoCercaGiocatoreLabel.Size = new Size(109, 15);
            pokemonPreferitoCercaGiocatoreLabel.TabIndex = 9;
            pokemonPreferitoCercaGiocatoreLabel.Text = "Pokemon preferito:";
            // 
            // cercaGiocatorePokemonPreferitoPictureBox
            // 
            cercaGiocatorePokemonPreferitoPictureBox.Location = new Point(146, 87);
            cercaGiocatorePokemonPreferitoPictureBox.Margin = new Padding(2);
            cercaGiocatorePokemonPreferitoPictureBox.Name = "cercaGiocatorePokemonPreferitoPictureBox";
            cercaGiocatorePokemonPreferitoPictureBox.Size = new Size(53, 46);
            cercaGiocatorePokemonPreferitoPictureBox.TabIndex = 8;
            cercaGiocatorePokemonPreferitoPictureBox.TabStop = false;
            // 
            // cercaGiocatoreRimuoviButton
            // 
            cercaGiocatoreRimuoviButton.Location = new Point(16, 155);
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
            cercaGiocatoreSbloccaButton.Location = new Point(117, 155);
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
            cercaGiocatoreBloccaButton.Location = new Point(117, 155);
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
            cercaGiocatoreAggiungiButton.Location = new Point(16, 155);
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
            cercaGiocatorePictureBox.Size = new Size(126, 108);
            cercaGiocatorePictureBox.TabIndex = 3;
            cercaGiocatorePictureBox.TabStop = false;
            // 
            // nicknameCercaGiocatoreLabel
            // 
            nicknameCercaGiocatoreLabel.AutoSize = true;
            nicknameCercaGiocatoreLabel.Location = new Point(146, 24);
            nicknameCercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            nicknameCercaGiocatoreLabel.Name = "nicknameCercaGiocatoreLabel";
            nicknameCercaGiocatoreLabel.Size = new Size(64, 15);
            nicknameCercaGiocatoreLabel.TabIndex = 2;
            nicknameCercaGiocatoreLabel.Text = "Nickname:";
            // 
            // cognomeCercaGiocatoreLabel
            // 
            cognomeCercaGiocatoreLabel.AutoSize = true;
            cognomeCercaGiocatoreLabel.Location = new Point(146, 54);
            cognomeCercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            cognomeCercaGiocatoreLabel.Name = "cognomeCercaGiocatoreLabel";
            cognomeCercaGiocatoreLabel.Size = new Size(63, 15);
            cognomeCercaGiocatoreLabel.TabIndex = 1;
            cognomeCercaGiocatoreLabel.Text = "Cognome:";
            // 
            // nomeCercaGiocatoreLabel
            // 
            nomeCercaGiocatoreLabel.AutoSize = true;
            nomeCercaGiocatoreLabel.Location = new Point(146, 39);
            nomeCercaGiocatoreLabel.Margin = new Padding(2, 0, 2, 0);
            nomeCercaGiocatoreLabel.Name = "nomeCercaGiocatoreLabel";
            nomeCercaGiocatoreLabel.Size = new Size(43, 15);
            nomeCercaGiocatoreLabel.TabIndex = 0;
            nomeCercaGiocatoreLabel.Text = "Nome:";
            // 
            // cercaGiocatoreTextBox
            // 
            cercaGiocatoreTextBox.Location = new Point(363, 37);
            cercaGiocatoreTextBox.Margin = new Padding(2);
            cercaGiocatoreTextBox.Name = "cercaGiocatoreTextBox";
            cercaGiocatoreTextBox.Size = new Size(134, 23);
            cercaGiocatoreTextBox.TabIndex = 2;
            // 
            // cercaGiocatoreLabel
            // 
            cercaGiocatoreLabel.AutoSize = true;
            cercaGiocatoreLabel.Location = new Point(363, 20);
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
            amiciList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            amiciList.Location = new Point(8, 8);
            amiciList.Margin = new Padding(2);
            amiciList.Name = "amiciList";
            amiciList.Size = new Size(311, 542);
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
            visualizzaPokedex.Controls.Add(label1);
            visualizzaPokedex.Controls.Add(abilitaPokemonLabel);
            visualizzaPokedex.Controls.Add(biomaPokemonLabel);
            visualizzaPokedex.Controls.Add(mossePokemonLabel);
            visualizzaPokedex.Controls.Add(lineaEvolutivaPokemonLayout);
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
            visualizzaPokedex.Location = new Point(4, 24);
            visualizzaPokedex.Name = "visualizzaPokedex";
            visualizzaPokedex.Padding = new Padding(3);
            visualizzaPokedex.Size = new Size(880, 549);
            visualizzaPokedex.TabIndex = 1;
            visualizzaPokedex.Text = "Visualizza Pokedex";
            visualizzaPokedex.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(329, 238);
            label1.Name = "label1";
            label1.Size = new Size(86, 15);
            label1.TabIndex = 23;
            label1.Text = "Linea evolutiva";
            // 
            // abilitaPokemonLabel
            // 
            abilitaPokemonLabel.AutoSize = true;
            abilitaPokemonLabel.Location = new Point(492, 51);
            abilitaPokemonLabel.Name = "abilitaPokemonLabel";
            abilitaPokemonLabel.Size = new Size(44, 15);
            abilitaPokemonLabel.TabIndex = 21;
            abilitaPokemonLabel.Text = "Abilità:";
            // 
            // biomaPokemonLabel
            // 
            biomaPokemonLabel.AutoSize = true;
            biomaPokemonLabel.Location = new Point(492, 111);
            biomaPokemonLabel.Name = "biomaPokemonLabel";
            biomaPokemonLabel.Size = new Size(44, 15);
            biomaPokemonLabel.TabIndex = 20;
            biomaPokemonLabel.Text = "Bioma:";
            // 
            // mossePokemonLabel
            // 
            mossePokemonLabel.AutoSize = true;
            mossePokemonLabel.Location = new Point(329, 363);
            mossePokemonLabel.Name = "mossePokemonLabel";
            mossePokemonLabel.Size = new Size(41, 15);
            mossePokemonLabel.TabIndex = 19;
            mossePokemonLabel.Text = "Mosse";
            // 
            // lineaEvolutivaPokemonLayout
            // 
            lineaEvolutivaPokemonLayout.Location = new Point(329, 254);
            lineaEvolutivaPokemonLayout.Margin = new Padding(2);
            lineaEvolutivaPokemonLayout.Name = "lineaEvolutivaPokemonLayout";
            lineaEvolutivaPokemonLayout.Size = new Size(527, 107);
            lineaEvolutivaPokemonLayout.TabIndex = 22;
            // 
            // mossePokemonListView
            // 
            mossePokemonListView.Columns.AddRange(new ColumnHeader[] { Nome, Elemento, Danno, Precisione, Descrizione });
            mossePokemonListView.FullRowSelect = true;
            mossePokemonListView.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            mossePokemonListView.Location = new Point(329, 381);
            mossePokemonListView.Name = "mossePokemonListView";
            mossePokemonListView.Size = new Size(528, 152);
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
            descrizionePokemonTextBox.Location = new Point(329, 170);
            descrizionePokemonTextBox.Name = "descrizionePokemonTextBox";
            descrizionePokemonTextBox.ReadOnly = true;
            descrizionePokemonTextBox.Size = new Size(528, 66);
            descrizionePokemonTextBox.TabIndex = 6;
            descrizionePokemonTextBox.Text = "";
            // 
            // statistichePokemonTotaleLabel
            // 
            statistichePokemonTotaleLabel.AutoSize = true;
            statistichePokemonTotaleLabel.Location = new Point(680, 111);
            statistichePokemonTotaleLabel.Name = "statistichePokemonTotaleLabel";
            statistichePokemonTotaleLabel.Size = new Size(42, 15);
            statistichePokemonTotaleLabel.TabIndex = 17;
            statistichePokemonTotaleLabel.Text = "Totale:";
            // 
            // statistichePokemonVelocitaLabel
            // 
            statistichePokemonVelocitaLabel.AutoSize = true;
            statistichePokemonVelocitaLabel.Location = new Point(678, 96);
            statistichePokemonVelocitaLabel.Name = "statistichePokemonVelocitaLabel";
            statistichePokemonVelocitaLabel.Size = new Size(51, 15);
            statistichePokemonVelocitaLabel.TabIndex = 16;
            statistichePokemonVelocitaLabel.Text = "Velocità:";
            // 
            // statistichePokemonDifesaSpecialeLabel
            // 
            statistichePokemonDifesaSpecialeLabel.AutoSize = true;
            statistichePokemonDifesaSpecialeLabel.Location = new Point(678, 81);
            statistichePokemonDifesaSpecialeLabel.Name = "statistichePokemonDifesaSpecialeLabel";
            statistichePokemonDifesaSpecialeLabel.Size = new Size(87, 15);
            statistichePokemonDifesaSpecialeLabel.TabIndex = 15;
            statistichePokemonDifesaSpecialeLabel.Text = "Difesa speciale:";
            // 
            // statistichePokemonAttaccoSpecialeLabel
            // 
            statistichePokemonAttaccoSpecialeLabel.AutoSize = true;
            statistichePokemonAttaccoSpecialeLabel.Location = new Point(678, 66);
            statistichePokemonAttaccoSpecialeLabel.Name = "statistichePokemonAttaccoSpecialeLabel";
            statistichePokemonAttaccoSpecialeLabel.Size = new Size(96, 15);
            statistichePokemonAttaccoSpecialeLabel.TabIndex = 14;
            statistichePokemonAttaccoSpecialeLabel.Text = "Attacco speciale:";
            // 
            // statistichePokemonDifesaLabel
            // 
            statistichePokemonDifesaLabel.AutoSize = true;
            statistichePokemonDifesaLabel.Location = new Point(678, 51);
            statistichePokemonDifesaLabel.Name = "statistichePokemonDifesaLabel";
            statistichePokemonDifesaLabel.Size = new Size(42, 15);
            statistichePokemonDifesaLabel.TabIndex = 13;
            statistichePokemonDifesaLabel.Text = "Difesa:";
            // 
            // statistichePokemonAttaccoLabel
            // 
            statistichePokemonAttaccoLabel.AutoSize = true;
            statistichePokemonAttaccoLabel.Location = new Point(678, 36);
            statistichePokemonAttaccoLabel.Name = "statistichePokemonAttaccoLabel";
            statistichePokemonAttaccoLabel.Size = new Size(51, 15);
            statistichePokemonAttaccoLabel.TabIndex = 12;
            statistichePokemonAttaccoLabel.Text = "Attacco:";
            // 
            // statistichePokemonPuntiSaluteLabel
            // 
            statistichePokemonPuntiSaluteLabel.AutoSize = true;
            statistichePokemonPuntiSaluteLabel.Location = new Point(678, 21);
            statistichePokemonPuntiSaluteLabel.Name = "statistichePokemonPuntiSaluteLabel";
            statistichePokemonPuntiSaluteLabel.Size = new Size(72, 15);
            statistichePokemonPuntiSaluteLabel.TabIndex = 11;
            statistichePokemonPuntiSaluteLabel.Text = "Punti salute:";
            // 
            // statistichePokemonLabel
            // 
            statistichePokemonLabel.AutoSize = true;
            statistichePokemonLabel.Location = new Point(678, 6);
            statistichePokemonLabel.Name = "statistichePokemonLabel";
            statistichePokemonLabel.Size = new Size(61, 15);
            statistichePokemonLabel.TabIndex = 10;
            statistichePokemonLabel.Text = "Statistiche";
            // 
            // elementiPokemonLabel
            // 
            elementiPokemonLabel.AutoSize = true;
            elementiPokemonLabel.Location = new Point(492, 36);
            elementiPokemonLabel.Name = "elementiPokemonLabel";
            elementiPokemonLabel.Size = new Size(56, 15);
            elementiPokemonLabel.TabIndex = 9;
            elementiPokemonLabel.Text = "Elementi:";
            // 
            // descrizionePokemonLabel
            // 
            descrizionePokemonLabel.AutoSize = true;
            descrizionePokemonLabel.Location = new Point(329, 152);
            descrizionePokemonLabel.Name = "descrizionePokemonLabel";
            descrizionePokemonLabel.Size = new Size(70, 15);
            descrizionePokemonLabel.TabIndex = 8;
            descrizionePokemonLabel.Text = "Descrizione:";
            // 
            // improntaPokemonLabel
            // 
            improntaPokemonLabel.AutoSize = true;
            improntaPokemonLabel.Location = new Point(492, 96);
            improntaPokemonLabel.Name = "improntaPokemonLabel";
            improntaPokemonLabel.Size = new Size(59, 15);
            improntaPokemonLabel.TabIndex = 7;
            improntaPokemonLabel.Text = "Impronta:";
            // 
            // pesoPokemonLabel
            // 
            pesoPokemonLabel.AutoSize = true;
            pesoPokemonLabel.Location = new Point(492, 81);
            pesoPokemonLabel.Name = "pesoPokemonLabel";
            pesoPokemonLabel.Size = new Size(35, 15);
            pesoPokemonLabel.TabIndex = 5;
            pesoPokemonLabel.Text = "Peso:";
            // 
            // altezzaPokemonLabel
            // 
            altezzaPokemonLabel.AutoSize = true;
            altezzaPokemonLabel.Location = new Point(492, 66);
            altezzaPokemonLabel.Name = "altezzaPokemonLabel";
            altezzaPokemonLabel.Size = new Size(47, 15);
            altezzaPokemonLabel.TabIndex = 4;
            altezzaPokemonLabel.Text = "Altezza:";
            // 
            // speciePokemonLabel
            // 
            speciePokemonLabel.AutoSize = true;
            speciePokemonLabel.Location = new Point(492, 21);
            speciePokemonLabel.Name = "speciePokemonLabel";
            speciePokemonLabel.Size = new Size(61, 15);
            speciePokemonLabel.TabIndex = 3;
            speciePokemonLabel.Text = "Pokemon:";
            // 
            // pokemonLabel
            // 
            pokemonLabel.AutoSize = true;
            pokemonLabel.Location = new Point(492, 6);
            pokemonLabel.Name = "pokemonLabel";
            pokemonLabel.Size = new Size(54, 15);
            pokemonLabel.TabIndex = 2;
            pokemonLabel.Text = "Numero:";
            // 
            // pokedexPicture
            // 
            pokedexPicture.Location = new Point(329, 6);
            pokedexPicture.Name = "pokedexPicture";
            pokedexPicture.Size = new Size(158, 135);
            pokedexPicture.SizeMode = PictureBoxSizeMode.CenterImage;
            pokedexPicture.TabIndex = 1;
            pokedexPicture.TabStop = false;
            // 
            // pokedexList
            // 
            pokedexList.Columns.AddRange(new ColumnHeader[] { ids, names, captured });
            pokedexList.FullRowSelect = true;
            pokedexList.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            pokedexList.Location = new Point(6, 6);
            pokedexList.Name = "pokedexList";
            pokedexList.Size = new Size(274, 527);
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
            cercaECattura.Location = new Point(4, 24);
            cercaECattura.Name = "cercaECattura";
            cercaECattura.Padding = new Padding(3);
            cercaECattura.Size = new Size(880, 549);
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
            panel2.Size = new Size(874, 543);
            panel2.TabIndex = 3;
            // 
            // outputBox
            // 
            outputBox.Location = new Point(3, 3);
            outputBox.MinimumSize = new Size(211, 122);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(740, 543);
            outputBox.TabIndex = 0;
            outputBox.Text = "";
            // 
            // panel1
            // 
            panel1.Controls.Add(mostraStato);
            panel1.Controls.Add(tentaCatturaButton);
            panel1.Controls.Add(pokemonDisponibiliBox);
            panel1.Controls.Add(cercaPokemonButton);
            panel1.Controls.Add(cercaPokemonSelezionatoButton);
            panel1.Location = new Point(747, 3);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(127, 542);
            panel1.TabIndex = 2;
            // 
            // mostraStato
            // 
            mostraStato.Location = new Point(4, 9);
            mostraStato.Name = "mostraStato";
            mostraStato.Size = new Size(120, 33);
            mostraStato.TabIndex = 1;
            mostraStato.Text = "Mostra stato";
            mostraStato.UseVisualStyleBackColor = true;
            mostraStato.Click += MostraStatoButtonOnClick;
            // 
            // tentaCatturaButton
            // 
            tentaCatturaButton.Location = new Point(4, 148);
            tentaCatturaButton.Name = "tentaCatturaButton";
            tentaCatturaButton.Size = new Size(120, 23);
            tentaCatturaButton.TabIndex = 5;
            tentaCatturaButton.Text = "Tenta cattura";
            tentaCatturaButton.UseVisualStyleBackColor = true;
            tentaCatturaButton.Click += TentaCatturaButtonOnClick;
            // 
            // pokemonDisponibiliBox
            // 
            pokemonDisponibiliBox.FormattingEnabled = true;
            pokemonDisponibiliBox.Location = new Point(4, 48);
            pokemonDisponibiliBox.Name = "pokemonDisponibiliBox";
            pokemonDisponibiliBox.Size = new Size(120, 23);
            pokemonDisponibiliBox.TabIndex = 4;
            // 
            // cercaPokemonButton
            // 
            cercaPokemonButton.Location = new Point(4, 119);
            cercaPokemonButton.Name = "cercaPokemonButton";
            cercaPokemonButton.Size = new Size(120, 23);
            cercaPokemonButton.TabIndex = 6;
            cercaPokemonButton.Text = "Cerca Pokemon";
            cercaPokemonButton.UseVisualStyleBackColor = true;
            cercaPokemonButton.Click += CercaPokemonButtonOnClick;
            // 
            // cercaPokemonSelezionatoButton
            // 
            cercaPokemonSelezionatoButton.Location = new Point(4, 74);
            cercaPokemonSelezionatoButton.Name = "cercaPokemonSelezionatoButton";
            cercaPokemonSelezionatoButton.Size = new Size(120, 39);
            cercaPokemonSelezionatoButton.TabIndex = 3;
            cercaPokemonSelezionatoButton.Text = "Cerca Pokemon selezionato";
            cercaPokemonSelezionatoButton.UseVisualStyleBackColor = true;
            cercaPokemonSelezionatoButton.Click += CercaPokemonSelezionatoButtonOnClick;
            // 
            // battagliaTab
            // 
            battagliaTab.Controls.Add(cercaECattura);
            battagliaTab.Controls.Add(visualizzaPokedex);
            battagliaTab.Controls.Add(visualizzaAmici);
            battagliaTab.Dock = DockStyle.Fill;
            battagliaTab.Location = new Point(0, 0);
            battagliaTab.Name = "battagliaTab";
            battagliaTab.SelectedIndex = 0;
            battagliaTab.Size = new Size(888, 577);
            battagliaTab.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 577);
            Controls.Add(battagliaTab);
            Cursor = Cursors.IBeam;
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
            battagliaTab.ResumeLayout(false);
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
        private FlowLayoutPanel lineaEvolutivaPokemonLayout;
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
        private Button mostraStato;
        private Button tentaCatturaButton;
        private ComboBox pokemonDisponibiliBox;
        private Button cercaPokemonButton;
        private Button cercaPokemonSelezionatoButton;
        private TabControl battagliaTab;
    }
}
