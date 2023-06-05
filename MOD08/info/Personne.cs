namespace info
{
    public class Personne
    {
        #region Attributes
        public string nom;
        public string prenom;
        public string addresse;
        public int age;
        #endregion

        #region Constructors
        public Personne() : this("Do", "JHON", "", 0) { }
        public Personne(string nom, string prenom) : this(nom, prenom, "", 0) { }
        public Personne(string nom, string prenom, string addresse, int age)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.addresse = addresse;
            this.age = age;
        }
        #endregion

        #region methods
        public string getInfo()
        {
            if (age == 0 & addresse == "")
            {
                return this.nom + " " + this.prenom + ",acune autre information disponible";
            }
            else
            {
                return this.nom + " " + this.prenom + ", " + this.age +
                    " ans, habite " + this.addresse;
            }


        }
        #endregion
    }
}