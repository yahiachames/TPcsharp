using info;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuPOM
{
    internal class Joueur : Personne
    {
        public Partie[] parties;
        public Joueur(string nom ,string prenom ) : base( nom , prenom )
        {
            parties = new Partie[20];
        }
    }
}
