using info;



namespace GestionRH
{
    internal class Program
    {


        static string getString(string message)
        {
            string chaine = "";
            Console.WriteLine(message);
            chaine = Console.ReadLine();
            return chaine;
        }

        static int getEntier(string message)
        {
            string chaine = "";
            int sortie;
            Console.WriteLine(message);
            chaine = Console.ReadLine();

            sortie = int.Parse(chaine);






            if (!int.TryParse(chaine, out sortie))
                sortie = -1;
            return sortie;
        }

        static void Main(string[] args)
        {

           // Employe e = new Employe("Martin", "Jean", "Paris", 35, "Technicien",
           //                         2500.0);
           // Console.WriteLine(e.getInfo());
           // e.affectation("Technicien Senior");
           // e.augmentation(500);
           // Console.WriteLine(e.getInfo());
           // using (Employe e2 = new Employe("Durand", "Michel", "Paris", 35,
           //"Ingénieur", 3000.0))
           // {
           //     Console.WriteLine(e2.getInfo());
           // }
            Entreprise ms = new Entreprise("microsoft");

            string nom = getString("Veuillez saisir le nom du nouvel employé");
            string prenom = getString("Veuillez saisir le prénom du nouvel employé");
            string adresse = getString("Veuillez saisir l'adresse du nouvel employé");
            int age = getEntier("Veuillez saisir l'âge du nouvel employé");
            string fonction = getString("Veuillez saisir la fonction du nouvel employé");
            int salaire = getEntier("Veuillez saisir le salaire du nouvel employé");
            Employe recrue = new Employe(nom, prenom, adresse, age, fonction,
           (double)salaire);
            ms.embauche(recrue);
            Employe emp = null;
            int numero = getEntier("Quel est le numéro matricule de l'employé à gérer?");
            if (numero <= 0 || numero > ms.effectif)
            {
                Console.WriteLine("Cet employé n'existe pas.");
       
            }
            emp = ms[numero - 1];

            Console.WriteLine("Nombre d'employés: " + ms.effectif.ToString());
            Console.WriteLine("Charge salariale: " + ms.ChargeSalariale.ToString());
            Console.WriteLine("Salaire moyen: " + ((int)(ms.ChargeSalariale /
           ms.effectif)).ToString());

            foreach (Employe e in ms)
            {
                if (e != null)
                    Console.WriteLine(e.getInfo());
            }
            string poste = getString("Quel est le nouveau poste?");
            // TODO : Exercice 1.2
            emp.affectation(poste, x => Console.WriteLine(x.ToUpper()));
            //if (ms.InfoEffectif != null)
            //    InfoEffectif(this, new EntEventArgs(30 - this.effectif));
            ms.InfoEffectif +=
                                new Action<Object, EntEventArgs>((o, e) => Console.WriteLine(e.posteRestant));

            string n = getString("Quel nom cherchez-vous?");
            foreach (Employe item in ms.rechercheParNom(n))
            {
                Console.WriteLine(item.getInfo());
            }
            string f = getString("Quel fonction cherchez-vous?");
            foreach (Employe item in ms.rechercheParFonction(f))
            {
                Console.WriteLine(item.getInfo());
            }

            double charge;
            int nb = ms.chargeSalarialeParFonction("group", out charge);
            if (nb != 0)
            {
                Console.WriteLine("Nombre d'employés: " + nb.ToString());
                Console.WriteLine("Charge salariale: " + charge.ToString());
                Console.WriteLine("Salaire moyen: " + ((int)(charge / nb)).ToString());
            }
            else
                Console.WriteLine("Il n'y a pas d'employé ayant cette fonction.");



        }
    }
}