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
            cercaPokemonButton = new Button();
            pokemonDisponibiliBox = new ComboBox();
            button1 = new Button();
            button2 = new Button();
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
            amico = new ColumnHeader();
            data = new ColumnHeader();
            listaAmici = new ListView();
            tabControl1.SuspendLayout();
            cercaECattura.SuspendLayout();
            visualizzaPokedex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).BeginInit();
            visualizzaAmici.SuspendLayout();
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
            // cercaPokemonButton
            // 
            cercaPokemonButton.Location = new Point(917, 172);
            cercaPokemonButton.Margin = new Padding(4, 5, 4, 5);
            cercaPokemonButton.Name = "cercaPokemonButton";
            cercaPokemonButton.Size = new Size(171, 65);
            cercaPokemonButton.TabIndex = 3;
            cercaPokemonButton.Text = "Cerca Pokemon selezionato";
            cercaPokemonButton.UseVisualStyleBackColor = true;
            cercaPokemonButton.Click += CercaPokemonSelezionatoButtonOnClick;
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
            // button1
            // 
            button1.Location = new Point(917, 327);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(171, 38);
            button1.TabIndex = 5;
            button1.Text = "Tenta cattura";
            button1.UseVisualStyleBackColor = true;
            button1.Click += TentaCatturaButtonOnClick;
            // 
            // button2
            // 
            button2.Location = new Point(917, 263);
            button2.Margin = new Padding(4, 5, 4, 5);
            button2.Name = "button2";
            button2.Size = new Size(171, 38);
            button2.TabIndex = 6;
            button2.Text = "Cerca Pokemon";
            button2.UseVisualStyleBackColor = true;
            button2.Click += CercaPokemonButtonOnClick;
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
            cercaECattura.Controls.Add(button1);
            cercaECattura.Controls.Add(button2);
            cercaECattura.Controls.Add(mostraStato);
            cercaECattura.Controls.Add(pokemonDisponibiliBox);
            cercaECattura.Controls.Add(cercaPokemonButton);
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
            visualizzaAmici.Controls.Add(listaAmici);
            visualizzaAmici.Location = new Point(4, 34);
            visualizzaAmici.Margin = new Padding(4, 5, 4, 5);
            visualizzaAmici.Name = "visualizzaAmici";
            visualizzaAmici.Size = new Size(1101, 672);
            visualizzaAmici.TabIndex = 2;
            visualizzaAmici.Text = "Visualizza Amici";
            visualizzaAmici.UseVisualStyleBackColor = true;
            // 
            // amico
            // 
            amico.Text = "Amico";
            amico.Width = 250;
            // 
            // data
            // 
            data.Text = "Data";
            data.Width = 100;
            // 
            // listaAmici
            // 
            listaAmici.Columns.AddRange(new ColumnHeader[] { amico, data });
            listaAmici.FullRowSelect = true;
            listaAmici.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listaAmici.Location = new Point(18, 16);
            listaAmici.Name = "listaAmici";
            listaAmici.Size = new Size(379, 638);
            listaAmici.TabIndex = 0;
            listaAmici.UseCompatibleStateImageBehavior = false;
            listaAmici.View = View.Details;
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
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox outputBox;
        private Button mostraStato;
        private Button cercaPokemonButton;
        private ComboBox pokemonDisponibiliBox;
        private Button button1;
        private Button button2;
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
        private ListView listaAmici;
        private ColumnHeader amico;
        private ColumnHeader data;
    }
}
