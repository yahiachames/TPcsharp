using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Jeueur : Personne
    {
        public Partie[] parties;
        public string nom;
        public string prenom ;
        Jeueur(string nom , string prenom ) { 
            this.nom = nom;
            this.prenom = prenom;
            this.parties= new Partie[1];
        }
    }
}
