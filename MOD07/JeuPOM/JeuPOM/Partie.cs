using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Partie
    {
        #region Attributes
        public int valeur = 0;
        public int tentative = 0;
        #endregion

        #region membre statique
        private static int compteurParties = 0;
        public static int getNbParties() { return compteurParties; }
        #endregion

        #region Constructors
        public Partie() { }
        public Partie(int valeur)
        {
            this.valeur = valeur;
            this.tentative = 0;
            compteurParties++;
        }
        #endregion

        #region methods
        public string info()
        {
            return valeur.ToString() + " trouvé en " + tentative.ToString() +
                   " coup(s)";

        }
        #endregion
    }
}
