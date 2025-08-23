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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            outputBox = new RichTextBox();
            mostraStato = new Button();
            cercaPokemonButton = new Button();
            pokemonDisponibiliBox = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            tabControl1 = new TabControl();
            cercaECattura = new TabPage();
            visualizzaPokedex = new TabPage();
            pokemonLabel = new Label();
            pokedexPicture = new PictureBox();
            pokedexList = new ListView();
            ids = new ColumnHeader();
            names = new ColumnHeader();
            captured = new ColumnHeader();
            visualizzaAmici = new TabPage();
            pokemonImageList = new ImageList(components);
            speciePokemonLabel = new Label();
            altezzaPokemonLabel = new Label();
            pesoPokemonLabel = new Label();
            descrizionePokemonTextBox = new RichTextBox();
            improntaPokemonLabel = new Label();
            tabControl1.SuspendLayout();
            cercaECattura.SuspendLayout();
            visualizzaPokedex.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).BeginInit();
            SuspendLayout();
            // 
            // outputBox
            // 
            outputBox.Location = new Point(6, 6);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(630, 386);
            outputBox.TabIndex = 0;
            outputBox.Text = "";
            // 
            // mostraStato
            // 
            mostraStato.Location = new Point(642, 6);
            mostraStato.Name = "mostraStato";
            mostraStato.Size = new Size(120, 33);
            mostraStato.TabIndex = 1;
            mostraStato.Text = "Mostra stato";
            mostraStato.UseVisualStyleBackColor = true;
            mostraStato.Click += MostraStatoButtonOnClick;
            // 
            // cercaPokemonButton
            // 
            cercaPokemonButton.Location = new Point(642, 103);
            cercaPokemonButton.Name = "cercaPokemonButton";
            cercaPokemonButton.Size = new Size(120, 39);
            cercaPokemonButton.TabIndex = 3;
            cercaPokemonButton.Text = "Cerca Pokemon selezionato";
            cercaPokemonButton.UseVisualStyleBackColor = true;
            cercaPokemonButton.Click += CercaPokemonSelezionatoButtonOnClick;
            // 
            // pokemonDisponibiliBox
            // 
            pokemonDisponibiliBox.FormattingEnabled = true;
            pokemonDisponibiliBox.Location = new Point(642, 60);
            pokemonDisponibiliBox.Name = "pokemonDisponibiliBox";
            pokemonDisponibiliBox.Size = new Size(120, 23);
            pokemonDisponibiliBox.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(642, 196);
            button1.Name = "button1";
            button1.Size = new Size(120, 23);
            button1.TabIndex = 5;
            button1.Text = "Tenta cattura";
            button1.UseVisualStyleBackColor = true;
            button1.Click += TentaCatturaButtonOnClick;
            // 
            // button2
            // 
            button2.Location = new Point(642, 158);
            button2.Name = "button2";
            button2.Size = new Size(120, 23);
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
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
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
            cercaECattura.Location = new Point(4, 24);
            cercaECattura.Name = "cercaECattura";
            cercaECattura.Padding = new Padding(3);
            cercaECattura.Size = new Size(768, 398);
            cercaECattura.TabIndex = 0;
            cercaECattura.Text = "Cerca e cattura";
            cercaECattura.UseVisualStyleBackColor = true;
            // 
            // visualizzaPokedex
            // 
            visualizzaPokedex.Controls.Add(improntaPokemonLabel);
            visualizzaPokedex.Controls.Add(descrizionePokemonTextBox);
            visualizzaPokedex.Controls.Add(pesoPokemonLabel);
            visualizzaPokedex.Controls.Add(altezzaPokemonLabel);
            visualizzaPokedex.Controls.Add(speciePokemonLabel);
            visualizzaPokedex.Controls.Add(pokemonLabel);
            visualizzaPokedex.Controls.Add(pokedexPicture);
            visualizzaPokedex.Controls.Add(pokedexList);
            visualizzaPokedex.Location = new Point(4, 24);
            visualizzaPokedex.Name = "visualizzaPokedex";
            visualizzaPokedex.Padding = new Padding(3);
            visualizzaPokedex.Size = new Size(768, 398);
            visualizzaPokedex.TabIndex = 1;
            visualizzaPokedex.Text = "Visualizza Pokedex";
            visualizzaPokedex.UseVisualStyleBackColor = true;
            // 
            // pokemonLabel
            // 
            pokemonLabel.AutoSize = true;
            pokemonLabel.Location = new Point(495, 6);
            pokemonLabel.Name = "pokemonLabel";
            pokemonLabel.Size = new Size(54, 15);
            pokemonLabel.TabIndex = 2;
            pokemonLabel.Text = "Numero:";
            // 
            // pokedexPicture
            // 
            pokedexPicture.Location = new Point(329, 6);
            pokedexPicture.Name = "pokedexPicture";
            pokedexPicture.Size = new Size(160, 160);
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
            pokedexList.Size = new Size(274, 386);
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
            captured.Width = 20;
            // 
            // visualizzaAmici
            // 
            visualizzaAmici.Location = new Point(4, 24);
            visualizzaAmici.Name = "visualizzaAmici";
            visualizzaAmici.Size = new Size(768, 398);
            visualizzaAmici.TabIndex = 2;
            visualizzaAmici.Text = "Visualizza Amici";
            visualizzaAmici.UseVisualStyleBackColor = true;
            // 
            // pokemonImageList
            // 
            pokemonImageList.ColorDepth = ColorDepth.Depth32Bit;
            pokemonImageList.ImageStream = (ImageListStreamer)resources.GetObject("pokemonImageList.ImageStream");
            pokemonImageList.TransparentColor = Color.Transparent;
            pokemonImageList.Images.SetKeyName(0, "001.png");
            pokemonImageList.Images.SetKeyName(1, "004.png");
            pokemonImageList.Images.SetKeyName(2, "025.png");
            // 
            // speciePokemonLabel
            // 
            speciePokemonLabel.AutoSize = true;
            speciePokemonLabel.Location = new Point(495, 21);
            speciePokemonLabel.Name = "speciePokemonLabel";
            speciePokemonLabel.Size = new Size(61, 15);
            speciePokemonLabel.TabIndex = 3;
            speciePokemonLabel.Text = "Pokemon:";
            // 
            // altezzaPokemonLabel
            // 
            altezzaPokemonLabel.AutoSize = true;
            altezzaPokemonLabel.Location = new Point(495, 36);
            altezzaPokemonLabel.Name = "altezzaPokemonLabel";
            altezzaPokemonLabel.Size = new Size(47, 15);
            altezzaPokemonLabel.TabIndex = 4;
            altezzaPokemonLabel.Text = "Altezza:";
            // 
            // pesoPokemonLabel
            // 
            pesoPokemonLabel.AutoSize = true;
            pesoPokemonLabel.Location = new Point(495, 51);
            pesoPokemonLabel.Name = "pesoPokemonLabel";
            pesoPokemonLabel.Size = new Size(35, 15);
            pesoPokemonLabel.TabIndex = 5;
            pesoPokemonLabel.Text = "Peso:";
            // 
            // descrizionePokemonTextBox
            // 
            descrizionePokemonTextBox.Location = new Point(329, 192);
            descrizionePokemonTextBox.Name = "descrizionePokemonTextBox";
            descrizionePokemonTextBox.ReadOnly = true;
            descrizionePokemonTextBox.Size = new Size(409, 93);
            descrizionePokemonTextBox.TabIndex = 6;
            descrizionePokemonTextBox.Text = "";
            // 
            // improntaPokemonLabel
            // 
            improntaPokemonLabel.AutoSize = true;
            improntaPokemonLabel.Location = new Point(495, 66);
            improntaPokemonLabel.Name = "improntaPokemonLabel";
            improntaPokemonLabel.Size = new Size(59, 15);
            improntaPokemonLabel.TabIndex = 7;
            improntaPokemonLabel.Text = "Impronta:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Cursor = Cursors.IBeam;
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            cercaECattura.ResumeLayout(false);
            visualizzaPokedex.ResumeLayout(false);
            visualizzaPokedex.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pokedexPicture).EndInit();
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
        private ImageList pokemonImageList;
        private ColumnHeader captured;
        private Label pokemonLabel;
        private Label speciePokemonLabel;
        private Label altezzaPokemonLabel;
        private Label pesoPokemonLabel;
        private RichTextBox descrizionePokemonTextBox;
        private Label improntaPokemonLabel;
    }
}
