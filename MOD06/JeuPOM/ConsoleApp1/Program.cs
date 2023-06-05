using info;

namespace ConsoleApp1
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
            if(historique != null )
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
            Personne joueur = null;
            string info = getString("vous voulez s'authentifier ?");
            if (info.ToLower() == "oui") {
                string nom = getString("quel est votre nom ?");
                string prenom = getString("quel est votre prenom ?");
                joueur = new Personne(nom, prenom);
            }


        }

        static void LeJeu(Personne p)
        {
            int valeurSecrete, valuerSaisie = -1, nbTentative = 0, meilleurScore = 0, nbParties = 0;
            string reponse;
            Partie[] historiquee = new Partie[20];
            Random rnd = new Random();
            valeurSecrete = rnd.Next(100);
            string nom_du_fichier = "";
            try
            {
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
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                meilleurScore = 50;
            }

            do
            {
                nbTentative = 0;
                nbParties++;
                historiquee[nbParties] = new Partie(valeurSecrete);
                Console.WriteLine(historiquee[nbParties]);
                do
                {
                    try
                    {
                        nom_du_fichier = "";
                        nbTentative++;
                        valuerSaisie = getEntier("saisir un nombre");
                        Console.WriteLine(valeurSecrete.ToString(), valuerSaisie);


                    }
                    catch (Exception e) { Console.WriteLine(e.Message); }

                    if (valuerSaisie == valeurSecrete)
                    {
                        Console.WriteLine("vous avez gagner");

                    }
                    else if (valuerSaisie > valeurSecrete)
                    {
                        Console.WriteLine("tres grande");
                    }
                    else if (valuerSaisie < valeurSecrete)
                    {
                        Console.WriteLine("tres petite");
                    }
                } while (valuerSaisie != valeurSecrete);

                historiquee[nbParties].tentative = nbTentative;
                Console.WriteLine(historiquee[nbParties]);

                Console.WriteLine("Vous avez trouvé en {0} coup(s).", nbTentative);

                if (meilleurScore < nbTentative)
                {
                    Console.WriteLine("vous n'avez pas réussi a battre le meilleur score avec nombre de tentatives est egal a {0}", nbTentative);


                }
                else
                {
                    Console.WriteLine("vous avez réussi de battre le meilleur score avec nombre de tentatives est egal a {0}", nbTentative);
                    meilleurScore = nbTentative;
                    FileStream fs = new FileStream("high.txt", FileMode.Create);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(meilleurScore);
                    sw.Close();
                    fs.Close();
                }

                reponse = getString("vous voulez rejouer ? repondre par oui ou non");
                valeurSecrete = rnd.Next(100);
            } while (reponse == "oui");

            if (p == null)
            {
                reponse = getString("Veuillez saisir un nom de fichier pour" +
               " stocker votre historique ou taper Entrée pour l'afficher ici.");
                if (reponse != "")
                    afficheHistorique(nbParties, historiquee, reponse);
                else
                    afficheHistorique(nbParties, historiquee);
            }
            else
            {
                string nom_fichier = p.prenom + "_" +p.nom;
                nom_fichier += "_" + DateTime.Now.ToShortDateString().Replace("/", "_");
                nom_fichier += ".text";
                afficheHistorique(nbParties, historiquee, nom_fichier);


            }


        }
    }
}