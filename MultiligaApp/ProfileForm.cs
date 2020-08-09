using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiligaApp
{
    public partial class ProfileForm : Form
    {
        public ProfileForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InviteButton_Click(object sender, EventArgs e)
        {
            if(InviteButton.Text == "Zaproś do drużyny")
            {
                //TODO - w miejsce if(true) zrobic ifa sprawdzajacego czy dany gracz juz jest w 
                //przynajmniej jednej druzynie. Jesli jest to nie mozna zaprosic do druzyny
                if(true)
                    MessageBox.Show("Zaproszono do drużyny", "Zaproszenie wysłane");
                else
                    MessageBox.Show("Nie można zaprosić do drużyny! Zawodnik jest już w innej drużynie", "Informacja");
            }
            else
            {
                //TODO - w miejsce if(true) zrobic ifa sprawdzajacego czy dana drużyna juz jest w 
                //przynajmniej jednych zawodach. Jesli jest to nie mozna zaprosic do zawodów

                if(true)
                    MessageBox.Show("Zaproszono do zawodów", "Zaproszenie wysłane");
                else
                    MessageBox.Show("Nie można zaprosić do zawodów! Drużyna jest już w innych zawodach", "Informacja");
            }
        }
    }
}
