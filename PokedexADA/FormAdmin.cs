using System;
using System.Windows.Forms;

namespace PokedexADA
{
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
            this.Text = "Pannello di Amministrazione";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}