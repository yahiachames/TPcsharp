using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info
{
    internal class Entreprise : IDisposable
    {
        #region Attributs
        public int effectif;
        public string nom;
        public Employe[] employes;
        #endregion
        #region Constructeurs
        public Entreprise(string nom)
        {
            this.nom = nom;
            employes = new Employe[30];
            effectif = 0;
        }
        public Entreprise()
        : this("Ib Formation") { }
        #endregion
        #region Méthodes
        public void embauche(Employe e)
        {
            if (this.effectif < employes.Length)
            {
                employes[this.effectif] = e;
                this.effectif++;
                e.setNumero(this.effectif);
            }
            else
                throw new Exception("Le nombre maximum d'employé" +
               " est atteint.");
        }
        #endregion
        #region Dispose
        private bool isDisposed = false;
        ~Entreprise()
        {
            Dispose(false);
        }
        protected virtual void Dispose(bool isDisposing)
        {
            if (!isDisposed)
            {
                if (isDisposing)
                {
                    foreach (Employe e in employes)
                    {
                        if (e != null)
                            e.Dispose();
                    }
                }
                isDisposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    

}
}
