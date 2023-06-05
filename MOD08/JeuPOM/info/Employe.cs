﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info
{
    public class Employe : Personne
    {
        #region Attributes
        private int numero;
        public string fonction;
        private double salaire;

        #endregion

        #region Constructeurs
        public Employe(string nom, string prenom, string adresse ,
            int age , string fonction,double salaire) : base(nom,prenom,adresse, age)
        {
            this.fonction = fonction;
            this.salaire = salaire;
            
        }

        public Employe(Personne p, string fonction, double salaire)
         : this(p.nom, p.prenom, p.addresse, p.age, fonction, salaire) { }


        #endregion

        #region Méthodes

        override public string getInfo()
        {
            return base.getInfo() + "\n\t" + this.fonction;
        }

        public void  augmentation(double montant)
        {
            this.salaire += montant;
        }
        public void affectation(string nouvelle_fonction)
        {
            this.fonction = nouvelle_fonction;
        }
        #endregion
    }
}
