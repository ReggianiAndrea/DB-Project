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
            SuspendLayout();
            // 
            // outputBox
            // 
            outputBox.Location = new Point(26, 27);
            outputBox.Name = "outputBox";
            outputBox.Size = new Size(575, 352);
            outputBox.TabIndex = 0;
            outputBox.Text = "";
            // 
            // mostraStato
            // 
            mostraStato.Location = new Point(644, 41);
            mostraStato.Name = "mostraStato";
            mostraStato.Size = new Size(120, 33);
            mostraStato.TabIndex = 1;
            mostraStato.Text = "Mostra stato";
            mostraStato.UseVisualStyleBackColor = true;
            mostraStato.Click += MostraStatoButtonOnClick;
            // 
            // cercaPokemonButton
            // 
            cercaPokemonButton.Location = new Point(644, 136);
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
            pokemonDisponibiliBox.Location = new Point(644, 107);
            pokemonDisponibiliBox.Name = "pokemonDisponibiliBox";
            pokemonDisponibiliBox.Size = new Size(120, 23);
            pokemonDisponibiliBox.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(644, 210);
            button1.Name = "button1";
            button1.Size = new Size(120, 23);
            button1.TabIndex = 5;
            button1.Text = "Tenta cattura";
            button1.UseVisualStyleBackColor = true;
            button1.Click += TentaCatturaButtonOnClick;
            // 
            // button2
            // 
            button2.Location = new Point(644, 181);
            button2.Name = "button2";
            button2.Size = new Size(120, 23);
            button2.TabIndex = 6;
            button2.Text = "Cerca Pokemon";
            button2.UseVisualStyleBackColor = true;
            button2.Click += CercaPokemonButtonOnClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pokemonDisponibiliBox);
            Controls.Add(cercaPokemonButton);
            Controls.Add(mostraStato);
            Controls.Add(outputBox);
            Cursor = Cursors.IBeam;
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox outputBox;
        private Button mostraStato;
        private Button cercaPokemonButton;
        private ComboBox pokemonDisponibiliBox;
        private Button button1;
        private Button button2;
    }
}
