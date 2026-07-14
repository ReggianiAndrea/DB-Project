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
            outputBox = new RichTextBox();
            mostraStato = new Button();
            cercaPokemonSelezionatoButton = new Button();
            pokemonDisponibiliBox = new ComboBox();
            tentaCatturaButton = new Button();
            cercaPokemonButton = new Button();
            tabControl1 = new TabControl();
            cercaECattura = new TabPage();
            visualizzaPokedex = new TabPage();
            descrizionePokemonLabel = new Label();
            improntaPokemonLabel = new Label();
            descrizionePokemonTextBox = new RichTextBox();
            pesoPokemonLabel = new Label();
            altezzaPokemonLabel = new Label();
            speciePokemonLabel = new Label();
            pokemonLabel = new Label();
            pokedexPicture = new PictureBox();
            pokedexList = new ListView();
            ids = new ColumnHeader();
            names = new ColumnHeader();
            captured = new ColumnHeader();
            visualizzaAmici = new TabPage();
            cercaGiocatoreFallitaLabel = new Label();
            cercaGiocatoreButton = new Button();
            cercaGiocatoreGroupBox = new GroupBox();
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
            tabControl1.SuspendLayout();
            cercaECattura.SuspendLayout();
            visualizzaPokedex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).BeginInit();
            visualizzaAmici.SuspendLayout();
            cercaGiocatoreGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePictureBox).BeginInit();
            SuspendLayout();
            // 
            // outputBox
            // 
            outputBox.Location = new Point(9, 10);
            outputBox.Margin = new Padding(4, 5, 4, 5);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(898, 641);
            outputBox.TabIndex = 0;
            outputBox.Text = "";
            // 
            // mostraStato
            // 
            mostraStato.Location = new Point(917, 10);
            mostraStato.Margin = new Padding(4, 5, 4, 5);
            mostraStato.Name = "mostraStato";
            mostraStato.Size = new Size(171, 55);
            mostraStato.TabIndex = 1;
            mostraStato.Text = "Mostra stato";
            mostraStato.UseVisualStyleBackColor = true;
            mostraStato.Click += MostraStatoButtonOnClick;
            // 
            // cercaPokemonSelezionatoButton
            // 
            cercaPokemonSelezionatoButton.Location = new Point(917, 172);
            cercaPokemonSelezionatoButton.Margin = new Padding(4, 5, 4, 5);
            cercaPokemonSelezionatoButton.Name = "cercaPokemonSelezionatoButton";
            cercaPokemonSelezionatoButton.Size = new Size(171, 65);
            cercaPokemonSelezionatoButton.TabIndex = 3;
            cercaPokemonSelezionatoButton.Text = "Cerca Pokemon selezionato";
            cercaPokemonSelezionatoButton.UseVisualStyleBackColor = true;
            cercaPokemonSelezionatoButton.Click += CercaPokemonSelezionatoButtonOnClick;
            // 
            // pokemonDisponibiliBox
            // 
            pokemonDisponibiliBox.FormattingEnabled = true;
            pokemonDisponibiliBox.Location = new Point(917, 100);
            pokemonDisponibiliBox.Margin = new Padding(4, 5, 4, 5);
            pokemonDisponibiliBox.Name = "pokemonDisponibiliBox";
            pokemonDisponibiliBox.Size = new Size(170, 33);
            pokemonDisponibiliBox.TabIndex = 4;
            // 
            // tentaCatturaButton
            // 
            tentaCatturaButton.Location = new Point(917, 327);
            tentaCatturaButton.Margin = new Padding(4, 5, 4, 5);
            tentaCatturaButton.Name = "tentaCatturaButton";
            tentaCatturaButton.Size = new Size(171, 38);
            tentaCatturaButton.TabIndex = 5;
            tentaCatturaButton.Text = "Tenta cattura";
            tentaCatturaButton.UseVisualStyleBackColor = true;
            tentaCatturaButton.Click += TentaCatturaButtonOnClick;
            // 
            // cercaPokemonButton
            // 
            cercaPokemonButton.Location = new Point(917, 263);
            cercaPokemonButton.Margin = new Padding(4, 5, 4, 5);
            cercaPokemonButton.Name = "cercaPokemonButton";
            cercaPokemonButton.Size = new Size(171, 38);
            cercaPokemonButton.TabIndex = 6;
            cercaPokemonButton.Text = "Cerca Pokemon";
            cercaPokemonButton.UseVisualStyleBackColor = true;
            cercaPokemonButton.Click += CercaPokemonButtonOnClick;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(cercaECattura);
            tabControl1.Controls.Add(visualizzaPokedex);
            tabControl1.Controls.Add(visualizzaAmici);
            tabControl1.Location = new Point(17, 20);
            tabControl1.Margin = new Padding(4, 5, 4, 5);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1109, 710);
            tabControl1.TabIndex = 7;
            // 
            // cercaECattura
            // 
            cercaECattura.Controls.Add(outputBox);
            cercaECattura.Controls.Add(tentaCatturaButton);
            cercaECattura.Controls.Add(cercaPokemonButton);
            cercaECattura.Controls.Add(mostraStato);
            cercaECattura.Controls.Add(pokemonDisponibiliBox);
            cercaECattura.Controls.Add(cercaPokemonSelezionatoButton);
            cercaECattura.Location = new Point(4, 34);
            cercaECattura.Margin = new Padding(4, 5, 4, 5);
            cercaECattura.Name = "cercaECattura";
            cercaECattura.Padding = new Padding(4, 5, 4, 5);
            cercaECattura.Size = new Size(1101, 672);
            cercaECattura.TabIndex = 0;
            cercaECattura.Text = "Cerca e cattura";
            cercaECattura.UseVisualStyleBackColor = true;
            // 
            // visualizzaPokedex
            // 
            visualizzaPokedex.Controls.Add(descrizionePokemonLabel);
            visualizzaPokedex.Controls.Add(improntaPokemonLabel);
            visualizzaPokedex.Controls.Add(descrizionePokemonTextBox);
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
            visualizzaPokedex.Size = new Size(1101, 672);
            visualizzaPokedex.TabIndex = 1;
            visualizzaPokedex.Text = "Visualizza Pokedex";
            visualizzaPokedex.UseVisualStyleBackColor = true;
            // 
            // descrizionePokemonLabel
            // 
            descrizionePokemonLabel.AutoSize = true;
            descrizionePokemonLabel.Location = new Point(470, 290);
            descrizionePokemonLabel.Margin = new Padding(4, 0, 4, 0);
            descrizionePokemonLabel.Name = "descrizionePokemonLabel";
            descrizionePokemonLabel.Size = new Size(106, 25);
            descrizionePokemonLabel.TabIndex = 8;
            descrizionePokemonLabel.Text = "Descrizione:";
            // 
            // improntaPokemonLabel
            // 
            improntaPokemonLabel.AutoSize = true;
            improntaPokemonLabel.Location = new Point(707, 110);
            improntaPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            improntaPokemonLabel.Name = "improntaPokemonLabel";
            improntaPokemonLabel.Size = new Size(90, 25);
            improntaPokemonLabel.TabIndex = 7;
            improntaPokemonLabel.Text = "Impronta:";
            // 
            // descrizionePokemonTextBox
            // 
            descrizionePokemonTextBox.Location = new Point(470, 320);
            descrizionePokemonTextBox.Margin = new Padding(4, 5, 4, 5);
            descrizionePokemonTextBox.Name = "descrizionePokemonTextBox";
            descrizionePokemonTextBox.ReadOnly = true;
            descrizionePokemonTextBox.Size = new Size(583, 152);
            descrizionePokemonTextBox.TabIndex = 6;
            descrizionePokemonTextBox.Text = "";
            // 
            // pesoPokemonLabel
            // 
            pesoPokemonLabel.AutoSize = true;
            pesoPokemonLabel.Location = new Point(707, 85);
            pesoPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            pesoPokemonLabel.Name = "pesoPokemonLabel";
            pesoPokemonLabel.Size = new Size(53, 25);
            pesoPokemonLabel.TabIndex = 5;
            pesoPokemonLabel.Text = "Peso:";
            // 
            // altezzaPokemonLabel
            // 
            altezzaPokemonLabel.AutoSize = true;
            altezzaPokemonLabel.Location = new Point(707, 60);
            altezzaPokemonLabel.Margin = new Padding(4, 0, 4, 0);
            altezzaPokemonLabel.Name = "altezzaPokemonLabel";
            altezzaPokemonLabel.Size = new Size(72, 25);
            altezzaPokemonLabel.TabIndex = 4;
            altezzaPokemonLabel.Text = "Altezza:";
            // 
            // speciePokemonLabel
            // 
            speciePokemonLabel.AutoSize = true;
            speciePokemonLabel.Location = new Point(707, 35);
            speciePokemonLabel.Margin = new Padding(4, 0, 4, 0);
            speciePokemonLabel.Name = "speciePokemonLabel";
            speciePokemonLabel.Size = new Size(91, 25);
            speciePokemonLabel.TabIndex = 3;
            speciePokemonLabel.Text = "Pokemon:";
            // 
            // pokemonLabel
            // 
            pokemonLabel.AutoSize = true;
            pokemonLabel.Location = new Point(707, 10);
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
            pokedexPicture.Size = new Size(200, 200);
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
            pokedexList.Size = new Size(390, 641);
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
            visualizzaAmici.Size = new Size(1101, 672);
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
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatoreSbloccaButton);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatoreBloccaButton);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatoreAggiungiButton);
            cercaGiocatoreGroupBox.Controls.Add(cercaGiocatorePictureBox);
            cercaGiocatoreGroupBox.Controls.Add(nicknameCercaGiocatoreLabel);
            cercaGiocatoreGroupBox.Controls.Add(cognomeCercaGiocatoreLabel);
            cercaGiocatoreGroupBox.Controls.Add(nomeCercaGiocatoreLabel);
            cercaGiocatoreGroupBox.Location = new Point(518, 122);
            cercaGiocatoreGroupBox.Name = "cercaGiocatoreGroupBox";
            cercaGiocatoreGroupBox.Size = new Size(561, 530);
            cercaGiocatoreGroupBox.TabIndex = 3;
            cercaGiocatoreGroupBox.TabStop = false;
            cercaGiocatoreGroupBox.Text = "Giocatore";
            cercaGiocatoreGroupBox.Visible = false;
            // 
            // cercaGiocatoreSbloccaButton
            // 
            cercaGiocatoreSbloccaButton.Location = new Point(23, 258);
            cercaGiocatoreSbloccaButton.Name = "cercaGiocatoreSbloccaButton";
            cercaGiocatoreSbloccaButton.Size = new Size(136, 34);
            cercaGiocatoreSbloccaButton.TabIndex = 6;
            cercaGiocatoreSbloccaButton.Text = "Sblocca";
            cercaGiocatoreSbloccaButton.UseVisualStyleBackColor = true;
            cercaGiocatoreSbloccaButton.Visible = false;
            cercaGiocatoreSbloccaButton.Click += cercaGiocatoreSbloccaButton_Click;
            // 
            // cercaGiocatoreBloccaButton
            // 
            cercaGiocatoreBloccaButton.Location = new Point(23, 258);
            cercaGiocatoreBloccaButton.Name = "cercaGiocatoreBloccaButton";
            cercaGiocatoreBloccaButton.Size = new Size(136, 34);
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
            amiciList.Size = new Size(379, 638);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Controls.Add(tabControl1);
            Cursor = Cursors.IBeam;
            Margin = new Padding(4, 5, 4, 5);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            cercaECattura.ResumeLayout(false);
            visualizzaPokedex.ResumeLayout(false);
            visualizzaPokedex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).EndInit();
            visualizzaAmici.ResumeLayout(false);
            visualizzaAmici.PerformLayout();
            cercaGiocatoreGroupBox.ResumeLayout(false);
            cercaGiocatoreGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cercaGiocatorePictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox outputBox;
        private Button mostraStato;
        private Button cercaPokemonSelezionatoButton;
        private ComboBox pokemonDisponibiliBox;
        private Button tentaCatturaButton;
        private Button cercaPokemonButton;
        private TabControl tabControl1;
        private TabPage cercaECattura;
        private TabPage visualizzaPokedex;
        private TabPage visualizzaAmici;
        private ListView pokedexList;
        private PictureBox pokedexPicture;
        private ColumnHeader ids;
        private ColumnHeader names;
        private ColumnHeader captured;
        private Label pokemonLabel;
        private Label speciePokemonLabel;
        private Label altezzaPokemonLabel;
        private Label pesoPokemonLabel;
        private RichTextBox descrizionePokemonTextBox;
        private Label improntaPokemonLabel;
        private Label descrizionePokemonLabel;
        private ListView amiciList;
        private ColumnHeader amico;
        private ColumnHeader bloccato;
        private TextBox cercaGiocatoreTextBox;
        private Label cercaGiocatoreLabel;
        private GroupBox cercaGiocatoreGroupBox;
        private Label nomeCercaGiocatoreLabel;
        private Label nicknameCercaGiocatoreLabel;
        private Label cognomeCercaGiocatoreLabel;
        private Button cercaGiocatoreBloccaButton;
        private Button cercaGiocatoreAggiungiButton;
        private PictureBox cercaGiocatorePictureBox;
        private Button cercaGiocatoreButton;
        private Label cercaGiocatoreFallitaLabel;
        private Button cercaGiocatoreSbloccaButton;
    }
}
