﻿namespace ConsoleApp1
{
    internal class Program
    {
        



static void afficheHistorique(int compteur, int[] tabValeur, int[] tabCoup, string nomFichier)
{
    try
    {
        FileStream fs = new FileStream(nomFichier, FileMode.CreateNew,
             FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine("Vos parties:");

        for (int i = 0; i <= compteur; i++)
        {
            sw.WriteLine("Partie N°{0}, valeur secrète={1}," +
           "trouvé en {2} coup(s).", i + 1, tabValeur[i], tabCoup[i]);
        }
        sw.Close();
        fs.Close();
    }
    catch (Exception e)
    {
        Console.WriteLine("Erreur: " + e.Message);
    }

}

        static void afficheHistorique(int compteur, int[] tabValeur, int[] tabCoup)
        {
            Console.WriteLine("Vos parties:");
            for (int i = 0; i <= compteur; i++)
            {
                Console.WriteLine("Partie N°{0}, valeur secrète={1}," +
               "trouvé en {2} coup(s).", i + 1, tabValeur[i], tabCoup[i]);
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
            int valeurSecrete, valuerSaisie = -1, nbTentative = 0, meilleurScore=0 , nbParties = 0;
            string reponse;
            int[] historiqueValeur = new int[20], historiqueTentative = new int[20];
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
                do
                {
                    try
                    {
                        nom_du_fichier = "";
                        nbTentative++;
                        valuerSaisie = getEntier("saisir un nombre");

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
                nbParties++;
                historiqueValeur[nbParties] = valeurSecrete;
                historiqueTentative[nbParties] = nbTentative;
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

            nom_du_fichier = getString("Veuillez saisir un nom de fichier pour stocker votre" +
" historique ou taper Entrée pour l'afficher ici.");
            if (nom_du_fichier != "")
                afficheHistorique(nbParties, historiqueValeur, historiqueTentative,
               nom_du_fichier);
            else
                afficheHistorique(nbParties, historiqueValeur, historiqueTentative);
            Console.WriteLine("Au revoir.");

        }
    }
}