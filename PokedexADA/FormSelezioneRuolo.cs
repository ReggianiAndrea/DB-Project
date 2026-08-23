using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using PokedexADA.PokedexADA;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PokedexADA
{
    public partial class FormSelezioneRuolo : Form
    {
        public FormSelezioneRuolo()
        {
            InitializeComponent();
            InizializzaInterfacciaDinamica();
        }

        private void InizializzaInterfacciaDinamica()
        {
            // Impostazioni generali del pannello
            this.Text = "Seleziona Ruolo";
            this.Size = new Size(700, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Creazione dinamica del bottone Allenatore
            Button btnAllenatore = new Button();
            btnAllenatore.Text = "Entra come Allenatore";
            btnAllenatore.Size = new Size(280, 80);
            btnAllenatore.Location = new Point(220, 80);
            btnAllenatore.Click += BtnAllenatore_Click;

            // Creazione dinamica del bottone Amministratore
            Button btnAmministratore = new Button();
            btnAmministratore.Text = "Entra come Amministratore";
            btnAmministratore.Size = new Size(280, 80);
            btnAmministratore.Location = new Point(220, 180);
            btnAmministratore.Click += BtnAmministratore_Click;

            // Aggiunta dei controlli alla vista del Form
            this.Controls.Add(btnAllenatore);
            this.Controls.Add(btnAmministratore);
        }

        private void BtnAllenatore_Click(object? sender, EventArgs e)
        {
            using var db = new PokedexAdaContext();
            string nickname = nomeUtenteTextBox.Text;
            int idGiocatore = db.Giocatores.Where(g => g.Nickname == nickname).Select(g => g.IdGiocatore).FirstOrDefault();
            if (idGiocatore == 0)
            {
                MessageBox.Show("Questo giocatore non esiste", "Errore", MessageBoxButtons.OK);
                return;
            }
            FormUtente formAllenatore = new FormUtente(idGiocatore);
            this.Hide();
            formAllenatore.FormClosed += (s, args) => this.Close();
            formAllenatore.Show();
        }

        private void BtnAmministratore_Click(object? sender, EventArgs e)
        {
            FormAdmin formAmministratore = new FormAdmin();
            this.Hide();
            formAmministratore.FormClosed += (s, args) => this.Close();
            formAmministratore.Show();
        }
    }
}