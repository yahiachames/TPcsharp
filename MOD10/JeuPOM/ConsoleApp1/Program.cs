using info;

namespace JeuPOM
{
    internal class Program
    {




        static void afficheHistorique(int compteur, Partie[] historique, string nomFichier)
        {
            if (historique != null)
            {
                try
                {
                    Console.WriteLine(historique.Length);
                    if (historique != null)
                    {
                        FileStream fs = new FileStream(nomFichier, FileMode.CreateNew,
                         FileAccess.Write);
                        StreamWriter sw = new StreamWriter(fs);
                        sw.WriteLine("Vos parties:");
                        Console.WriteLine(historique);
                        for (int i = 0; i <= compteur; i++)
                        {
                            sw.WriteLine("Partie N°{0}, " + historique[i].info(), i + 1);
                        }
                        sw.Close();
                        fs.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Erreur: " + e.Message);
                }
            }

        }

        static void afficheHistorique(int compteur, Partie[] historique)
        {
            if (historique != null)
            {

                Console.WriteLine("Vos parties:");
                for (int i = 0; i <= compteur; i++)
                {
                    Console.WriteLine("Partie N°{0}, " + historique[i].info(), i + 1);
                }
            }
        }


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
            Joueur joueur = null;
            string info = getString("vous voulez s'authentifier ?");
            if (info.ToLower() == "oui")
            {
                string nom = getString("quel est votre nom ?");
                string prenom = getString("quel est votre prenom ?");
                joueur = new Joueur(nom, prenom);
                LeJeu(joueur);

            }


        }

        static void LeJeu(Joueur p)
        {

            // déclaration des variables
            int valeurSecrete, valeurSaisie;
            int nbTentative, meilleurScore = 50;
            string reponse;
            Random rnd = new Random();
            // lecture du meilleur score
            if (File.Exists("high.txt"))
            {
                FileStream fsr = new FileStream("high.txt", FileMode.Open,
               FileAccess.Read);
                StreamReader sr = new StreamReader(fsr);
                if (!int.TryParse(sr.ReadLine(), out meilleurScore))
                    meilleurScore = 50;
                sr.Close();
                fsr.Close();
            }
            // boucle des parties
            do
            {
                valeurSecrete = rnd.Next(100);
                nbTentative = 0;
                Partie pa = new Partie(valeurSecrete);
                p.parties[Partie.getNbParties() - 1] = pa;
                // boucle des tentatives
                do
                {
                    try
                    {
                        nbTentative++;
                        valeurSaisie = getEntier("Veuillez saisir un" +
" entier entre 0 et 100");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        valeurSaisie = -1;
                        continue;
                    }
                    if (valeurSaisie > valeurSecrete)
                        Console.WriteLine("La valeur saisie est trop grande.");
                    if (valeurSaisie < valeurSecrete)
                        Console.WriteLine("La valeur saisie est trop petite.");
                } while (valeurSaisie != valeurSecrete);
                // gestion du meilleur score
                Console.WriteLine("Bravo, vous avez trouvé la bonne valeur");
                if (nbTentative < meilleurScore)
                {
                    Console.WriteLine("Vous avez battu le meilleur score.");
                    meilleurScore = nbTentative;
                }
                p.parties[Partie.getNbParties() - 1].tentative = nbTentative;
                Console.WriteLine("Vous avez trouvé en {0} coup(s).",
               nbTentative);
                reponse = getString("Voulez-vous rejouer?");
            } while (reponse.ToLower() == "o" || reponse.ToLower() == "oui");
            Console.WriteLine("Merci d'avoir joué avec moi.");
            // affichage de l'historique des parties
            // TODO : Exercice 2.3
            string nomFichier = p.nom + "_" + p.prenom;
            nomFichier += "_" + DateTime.Now.ToShortDateString().Replace('/', '_');
            nomFichier += ".txt";
            p.parties.afficheHistorique(Partie.getNbParties() - 1, nomFichier);

            Console.WriteLine("Au revoir.");
            // sauvegarde du meilleur score
            FileStream fsw = new FileStream("high.txt", FileMode.Create,
           FileAccess.Write);
            StreamWriter sw = new StreamWriter(fsw);
            sw.WriteLine(meilleurScore);
            sw.Close();
            fsw.Close();

        }
    }
}