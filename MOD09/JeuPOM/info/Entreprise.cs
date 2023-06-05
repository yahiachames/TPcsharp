using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace info
{
    public class Entreprise : IDisposable ,IEnumerable<Employe>
    {

   
            #region Attributs
            public string nom;
            private List<Employe> employes;
            public event Action<Object, EntEventArgs> InfoEffectif = null;
            #endregion
            #region Constructeurs
            public Entreprise(string nom)
            {
                this.nom = nom;
                employes = new List<Employe>();
            }
            public Entreprise()
            : this("Ib Formation") { }
            #endregion
            #region Méthodes
            public void embauche(Employe e)
            {
                employes.Add(e);
                e.setNumero(employes.Count);
            }
        //public List<Employe> rechercheParNom(string nom)
        //{
        //    var req = from e in employes
        //              where e.nom == nom
        //              select e;
        //    return req.ToList<Employe>();
        //}
        // ou
        public List<Employe> rechercheParNom(string nom)
        {
            return employes.Where(e => e.nom == nom).ToList<Employe>();
        }
        public List<Employe> rechercheParFonction(string fonction)
        {
            var req = from e in employes
                      where e.fonction == fonction
                      select e;
            return req.ToList<Employe>();
        }
//        public int chargeSalarialeParFonction(string fonction, out double
//chargeSalariale)
//        {
//            int nb = 0;
//            chargeSalariale = 0;

//            foreach (Employe item in this.rechercheParFonction(function))
//            {
//                nb++;
//                chargeSalariale += item.Salaire;
//            }
//            return nb;
//        }
        // ou
        public int chargeSalarialeParFonction(string fonction, out double
        chargeSalariale)
        {
            var liste = this.rechercheParFonction(fonction);
            chargeSalariale = liste.Sum(e => e.Salaire);
            return liste.Count();
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
        #region Propriétés
        public int effectif
            {
                get
                {
                    return employes.Count;
                }
            }
            public double ChargeSalariale
            {
                get
                {
                    double total = 0;
                    for (int i = 0; i < this.effectif; i++)
                    {
                        total += this.employes[i].Salaire;
                    }
                    return total;
                }
            }
            public Employe this[int index]
            {
                get
                {
                    if (index < 0 || index >= this.effectif)
                        return null;
                    else
                        return this.employes[index];
                }
                set
                {
                    if (index < 0 || index >= this.effectif)
                        throw new IndexOutOfRangeException();
                    else
                        this.employes[index] = value;
                }
            }
        #endregion
        #region Enumerable
        public IEnumerator<Employe> GetEnumerator()
        {
            return employes.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return employes.GetEnumerator();
        }
        #endregion


    }
}
